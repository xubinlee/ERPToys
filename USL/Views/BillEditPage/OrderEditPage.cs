using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IBase;
using DBML;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using Factory;
using BLL;
using Utility;
using DevExpress.XtraBars.Docking2010.Views;
using System.Collections;
using CommonLibrary;
using DevExpress.XtraGrid.Views.Grid;
using System.Threading;
using DevExpress.XtraReports.UI;
using Utility.Interceptor;

namespace USL
{
    public partial class OrderEditPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail,IExtensions
    {
        private static ClientFactory clientFactory = LoggerInterceptor.CreateProxy<ClientFactory>();
        OrderHd hd;
        List<OrderDtl> dtl;
        List<VOrderDtlByBOM> dtlByBOM;
        List<VOrderDtlByBOM> dtlByAssemble;
        List<OrderDtl> dtlByMoldMaterial;
        List<Warehouse> warehouseList;
        //PageGroup pageGroupCore;
        Guid headID;
        List<TypesList> types;   //类型列表
        //OrderBillType orderType;
        String billType;
        //bool isSLSalePrice = false;
        //int goodsBigType = 0;
        BOMType bomType;
        int businessContactType = 0;

        public OrderHd Hd
        {
            get
            {
                return hd;
            }

            set
            {
                hd = value;
            }
        }

        public OrderEditPage(Guid hdID, String type)
        {
            InitializeComponent();
            headID = hdID;
            //pageGroupCore = child;
            billType = type;
            BindData(headID);
            gridView.BestFitColumns();
        }

        void SetDtlHeader(bool flag)
        {
            meMainMark.Visible = flag;
            if (billType == MainMenuConstants.ProductionOrder)
            {
                ////col品名.Visible = false;
                ////col包装方式.Visible = false;
                ////col箱数.Visible = false;
                ////col装箱数.Visible = false;
                ////col内盒.Visible = false;
                ////col单位.Visible = false;
                ////col单价.Visible = false;
                ////col金额.Visible = false;
                ////col折扣.Visible = false;
                ////col额外费用.Visible = false;
                ////col规格.Visible = false;
                ////col外箱规格.Visible = false;
                //gvAssemble.RowHeight = 100;
                //dpBOM.Text = "包装清单";
                if (MainForm.SysInfo.CompanyType == (int)CompanyType.Trade)
                    lciBusinessContact.Text = "加工厂家";
            }
            else
            {
                //dpBOM.Text = "模具清单";
                gvAssemble.RowHeight = -1;
                if (flag)
                {
                    colQty.Caption = "箱数";
                    ////col箱数.Caption = "箱数";
                    ////col箱数.FieldName = "箱数";
                    ////col箱数.SummaryItem.FieldName = "箱数";
                }
                else
                {
                    colQty.Caption = "数量";
                    ////col箱数.Caption = "数量";
                    ////col箱数.FieldName = "数量";
                    ////col箱数.SummaryItem.FieldName = "数量";
                }
                colPackaging.Visible = flag;
                colMEAS.Visible = flag;
                colSPEC.Visible = !flag;
                colPCS.Visible = flag;
                colInnerBox.Visible = flag;
                colTotalQty.Visible = flag;
                ////col包装方式.Visible = flag;
                ////col装箱数.Visible = flag;
                ////col内盒.Visible = flag;
                ////col外箱规格.Visible = flag;
                ////col正唛.Visible = false;
                ////col侧唛.Visible = false;
                ////col内盒唛.Visible = false;
            }
            //bool showPrice = false;
            //if (billType == MainMenuConstants.ProductionOrder)
            //    showPrice = false;
            //else
            //    showPrice = true;
            //colPrice.Visible = showPrice;
            //colDiscount.Visible = showPrice;
            //colOtherFee.Visible = showPrice;
            //colAMT.Visible = showPrice;
            if ((MainForm.Company.Contains("大正") || MainForm.Company.Contains("纸")))
                lciWarehouseType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //dpBillDtlForPrint.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            //dpMoldMaterial.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            if (MainForm.Company.Contains("纸"))
            {
                colPackaging.Visible = false;
                colMEAS.Visible = false;
                colQty.Caption = "数量";
                colPCS.Visible = false;
                colInnerBox.Visible = false;
                colTotalQty.Visible = false;
                colCounts.Visible = false;
                colCavityNumber.Visible = false;
                colModulus.Visible = false;
            }
        }

        void SetBusinessContact(bool flag)
        {
            lueBusinessContact.Enabled = flag;
            txtContacts.Enabled = flag;
            lueWarehouseType.Enabled = flag;
            if (flag)
            {
                lciBillNo.Text = "订货编号";
                lciOrderDate.Text = "订货日期";
            }
            else
            {
                lciBillNo.Text = "单据编号";
                lciOrderDate.Text = "单据日期";
            }
        }

        public void BindData(object hdID)
        {

            businessContactBindingSource.DataSource = null;
            lueBusinessContact.EditValue = null;
            //txtContacts.EditValue = null;
            this.lueBusinessContact.DataBindings.Clear();
            if (billType == MainMenuConstants.Order || billType == MainMenuConstants.ProductionOrder)
            {
                if (billType == MainMenuConstants.ProductionOrder)
                {
                    if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                    {
                        SetBusinessContact(false);
                        this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderHdBindingSource, "CompanyID", true));
                        businessContactBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VCompany>)];
                    }
                    else
                    {
                        SetBusinessContact(true);
                        this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderHdBindingSource, "SupplierID", true));
                        businessContactBindingSource.DataSource = ((List<VSupplier>)MainForm.dataSourceList[typeof(List<VSupplier>)]).FindAll(o => o.供应商类型 == (int)SupplierType.EMS);
                    }
                    vGoodsBindingSource.DataSource = ((List<VParentGoodsByBOM>)MainForm.dataSourceList[typeof(List<VParentGoodsByBOM>)]).FindAll(o => o.类型 == (int)BOMType.BOM);
                }
                else
                {
                    SetBusinessContact(true);
                    this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderHdBindingSource, "CompanyID", true));
                    vGoodsBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VGoods>)];
                    businessContactBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VCompany>)];
                }
                //goodsBigType = 0;
                SetDtlHeader(true);
                businessContactType = (int)BusinessContactType.Customer;
            }
            else if (billType== MainMenuConstants.FSMOrder)
            {
                SetBusinessContact(true);
                //SetBusinessContact(false);  //自家有自动机，不需要放外面做 
                this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderHdBindingSource, "SupplierID", true));
                businessContactBindingSource.DataSource = ((List<VSupplier>)MainForm.dataSourceList[typeof(List<VSupplier>)]).FindAll(o => o.供应商类型 == (int)SupplierType.FSM);
                vGoodsBindingSource.DataSource = ((List<VParentGoodsByBOM>)MainForm.dataSourceList[typeof(List<VParentGoodsByBOM>)]).FindAll(o => o.类型 == (int)BOMType.MoldList || o.类型 == (int)BOMType.MoldMaterial);
                //goodsBigType = 4;
                SetDtlHeader(false);
                businessContactType = (int)BusinessContactType.Supplier;
            }
            if (hdID is Guid && ((Guid)hdID) != Guid.Empty)
            {
                headID = (Guid)hdID;
                orderHdBindingSource.DataSource = hd = BLLFty.Create<OrderBLL>().GetOrderHd(headID);
                orderDtlBindingSource.DataSource = dtl = BLLFty.Create<OrderBLL>().GetOrderDtl(headID);
                if (billType == MainMenuConstants.ProductionOrder)
                {
                    billDtlByAssembleBindingSource.DataSource = dtlByAssemble= BLLFty.Create<OrderBLL>().GetVOrderDtlByBOM(headID, (int)BOMType.Assemble);
                    billDtlByBOMBindingSource.DataSource = dtlByBOM = BLLFty.Create<OrderBLL>().GetVOrderDtlByBOM(headID, (int)BOMType.BOM);
                }
                else if (billType == MainMenuConstants.FSMOrder)
                {
                    ////billDtlByBOMBindingSource.DataSource = dtlByBOM = BLLFty.Create<OrderBLL>().GetVFSMOrderDtlByMoldList(hdID);
                    vFSMOrderDtlByMoldMaterialBindingSource.DataSource = dtlByMoldMaterial = BLLFty.Create<OrderBLL>().GetVFSMOrderDtlByMoldMaterial(headID);
                }
                else
                {
                    billDtlByBOMBindingSource.DataSource = dtlByBOM = new List<VOrderDtlByBOM>();
                    billDtlByAssembleBindingSource.DataSource = dtlByAssemble = new List<VOrderDtlByBOM>();
                }
                    gvAssemble.BestFitColumns();
            }
            
            types = MainForm.dataSourceList[typeof(List<TypesList>)] as List<TypesList>;
            //单据类型
            billTypeBindingSource.DataSource = types.FindAll(o => o.Type == TypesListConstants.OrderType);
            //仓库类型
            warehouseTypeBindingSource.DataSource = types.FindAll(o => o.Type == TypesListConstants.CustomerType);
            warehouseBindingSource.DataSource = warehouseList = warehouseList = MainForm.dataSourceList[typeof(List<Warehouse>)] as List<Warehouse>;
            vGoodsByBOMBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VGoodsByBOM>)];
            vUsersInfoBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VUsersInfo>)];

        }

        public void Add()
        {
            orderHdBindingSource.DataSource = hd = new OrderHd();
            orderDtlBindingSource.DataSource = dtl = new List<OrderDtl>();
            if (billType == MainMenuConstants.ProductionOrder)
                billDtlByAssembleBindingSource.DataSource = dtlByAssemble = new List<VOrderDtlByBOM>();
            gridView.AddNewRow();
            gridView.FocusedColumn = colGoodsID;
            //hd.BillNo = GetOrderMaxBillNo();
            hd.BillNo = MainForm.GetMaxBillNo(MainMenuConstants.Order, true).MaxBillNo;
            headID = Guid.Empty;
            hd.OrderDate = DateTime.Today;
            hd.DeliveryDate = DateTime.Today;
            lueBusinessContact.Focus();
        }

        //string GetOrderMaxBillNo()
        //{
        //    string no = BLLFty.Create<OrderBLL>().GetMaxBillNo();
        //    if (no == null)
        //        no = "DH" + DateTime.Now.ToString("yyyyMMdd") + "001";
        //    else
        //    {
        //        if (no.Substring(2, 8).Equals(DateTime.Now.ToString("yyyyMMdd")))
        //            no = "DH" + DateTime.Now.ToString("yyyyMMdd") + Convert.ToString(int.Parse(no.Substring(10, 3)) + 1).PadLeft(3, '0');
        //        else
        //            no = "DH" + DateTime.Now.ToString("yyyyMMdd") + "001";
        //    }
        //    return no;
        //}

        public void Edit()
        {
            //单据编辑界面不需要
        }

        //刷新查询列表数据——只供删除单据时使用
        //void DataQueryPageRefresh()
        //{
        //    BaseContentContainer documentContainer = pageGroupCore.Parent as BaseContentContainer;
        //    if (documentContainer != null)
        //    {
        //        WindowsUIView view = documentContainer.Manager.View as WindowsUIView;
        //        if (view != null)
        //        {
        //            ItemDetailPage itemDetailPage = null;
        //            foreach (BaseDocument doc in view.Documents)
        //            {
        //                if (doc.Control is ItemDetailPage)
        //                {
        //                    itemDetailPage = (ItemDetailPage)doc.Control;
        //                    if (itemDetailPage.menu.Name == MainMenuConstants.OrderQuery)
        //                    break;
        //                }

        //            }
        //            //更新查询列表数据
        //            DataQueryPage page = itemDetailPage.itemDetail as DataQueryPage;
        //            MainForm.dataSourceList[typeof(List<VOrder>)] = BLLFty.Create<OrderBLL>().GetOrder();
        //            IList list = MainForm.dataSourceList[typeof(List<VOrder>)] as IList;
        //            page.InitGrid(list);
        //        }
        //    }
        //}

        public void Del()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                System.Windows.Forms.DialogResult result = XtraMessageBox.Show("确定要删除选择的记录吗?", "操作提示",
                System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    if (hd != null)
                    {
                //        bool flag = true;
                //        if (billType == MainMenuConstants.Order)
                //        {
                //            System.Windows.Forms.DialogResult orderResult = XtraMessageBox.Show("确定要删除对应的布产单吗?", "操作提示",
                //System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                //            if (orderResult == System.Windows.Forms.DialogResult.OK)
                //            {
                //                BLLFty.Create<OrderBLL>().Delete(hd.ID, hd.BillNo);
                //                flag = false;
                //            }
                //        }
                //        if (flag)
                        OrderHd dCheck = BLLFty.Create<OrderBLL>().GetOrderHd(hd.ID);
                        if (dCheck.Status == (int)BillStatus.UnAudited)
                            BLLFty.Create<OrderBLL>().Delete(hd.ID);
                        else
                        {
                            CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "该单据已审核，不允许删除。");
                            return;
                        }
                    }
                    //DataQueryPageRefresh();
                    //刷新查询界面
                    clientFactory.DataPageRefresh(billType);
                    orderHdBindingSource.DataSource = hd = new OrderHd();
                    orderDtlBindingSource.DataSource = dtl = new List<OrderDtl>();
                    if (billType == MainMenuConstants.ProductionOrder)
                        billDtlByAssembleBindingSource.DataSource = dtlByAssemble = new List<VOrderDtlByBOM>();
                    CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "删除成功");
                }
            }
            catch (Exception ex)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), ex.Message);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        bool BillValidated()
        {
            bool flag = true;
            Hashtable hasGoods = new Hashtable();
            if (hd == null)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请完整填写表头信息");
                flag = false;
            }
            if (lueBillType.EditValue == null)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请填写单据类型");
                flag = false;
            }
            if (lueBusinessContact.Enabled == true && string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("请填写{0}",lciBusinessContact.Text));
                flag = false;
            }
            //删除空记录、设置默认值
            hd.BillAMT = 0;
            for (int i = dtl.Count - 1; i >= 0; i--)
            {
                if (dtl[i].GoodsID == Guid.Empty)
                {
                    dtl.RemoveAt(i);
                    continue;
                }
                dtl[i].SerialNo = i;
                if (hasGoods[dtl[i].GoodsID.ToString().Trim() + dtl[i].PCS.ToString().Trim()] == null)
                    hasGoods.Add(dtl[i].GoodsID.ToString().Trim() + dtl[i].PCS.ToString().Trim(), dtl[i]);
                else
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "不能重复选择货品。");
                    flag = false;
                }
                if (dtl[i].Qty == 0)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), colQty.Caption + "不能为0");
                    flag = false;
                }
                Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID.Equals(dtl[i].GoodsID));
                //获取或设置客户商品售价
                //if (isSLSalePrice && lueBusinessContact.Enabled==true)
                if (lueBusinessContact.Enabled == true && !string.IsNullOrEmpty(lueBusinessContact.Text.Trim()) && MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                {
                   // SLSalePrice cSLSalePrice = ((List<SLSalePrice>)MainForm.dataSourceList[typeof(List<SLSalePrice>)]).Find(o =>
                    //o.CustomerID == new Guid(lueBusinessContact.EditValue.ToString()) && o.GoodsID == dtl[i].GoodsID);
                    SLSalePrice cSLSalePrice = BLLFty.Create<SLSalePriceBLL>().GetSLSalePrice().FirstOrDefault(o =>
                    o.ID == new Guid(lueBusinessContact.EditValue.ToString()) && o.GoodsID == dtl[i].GoodsID && o.Type == businessContactType);
                    if (cSLSalePrice == null)
                    {
                        SLSalePrice obj = new SLSalePrice();
                        obj.ID = new Guid(lueBusinessContact.EditValue.ToString());
                        obj.GoodsID = dtl[i].GoodsID;
                        obj.Type = businessContactType;
                        obj.Price = dtl[i].Price;
                        obj.PriceNoTax = dtl[i].PriceNoTax;
                        obj.Discount = dtl[i].Discount == 0 ? 1 : dtl[i].Discount;
                        obj.OtherFee = dtl[i].OtherFee;
                        BLLFty.Create<SLSalePriceBLL>().Insert(obj);
                    }
                    else if (cSLSalePrice.Price != dtl[i].Price || cSLSalePrice.Discount != dtl[i].Discount || cSLSalePrice.OtherFee != dtl[i].OtherFee)
                    {
                        cSLSalePrice.Price = dtl[i].Price;
                        cSLSalePrice.PriceNoTax = dtl[i].PriceNoTax;
                        cSLSalePrice.Discount = dtl[i].Discount == 0 ? 1 : dtl[i].Discount;
                        cSLSalePrice.OtherFee = dtl[i].OtherFee;
                        BLLFty.Create<SLSalePriceBLL>().Update(cSLSalePrice);
                    }
                }

                if (billType != MainMenuConstants.ProductionOrder)
                {
                    if (goods.NWeight != dtl[i].NWeight)
                    {
                        goods.NWeight = dtl[i].NWeight;
                        BLLFty.Create<GoodsBLL>().Update(goods);
                    }
                }
                if (dtl[i].PCS == 0)
                    dtl[i].PCS = 1;
                hd.BillAMT += decimal.Round(((goods.Unit == "斤" && billType == MainMenuConstants.FSMOrder) ? dtl[i].Qty * 500 / (goods.NWeight == 0 ? 1 : goods.NWeight) : dtl[i].Qty) * dtl[i].PCS * dtl[i].Price * dtl[i].Discount + dtl[i].OtherFee, 2);
            }
            hd.UnReceiptedAMT = hd.BillAMT;
            if (dtl == null || dtl.Count == 0 || gridView.RowCount == 0)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请完整填写货品信息");
                flag = false;
            }
            return flag;
        }

        public bool Save()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                gridView.CloseEditForm();
                hd = orderHdBindingSource.DataSource as OrderHd;
                dtl = orderDtlBindingSource.DataSource as List<OrderDtl>;
                if (string.IsNullOrEmpty(txtBillNo.Text.Trim()))
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "单据编号不能为空，请点击添加按钮添加单据。");
                    return false;
                }
                if (BillValidated() == false)
                    return false;
                hd.Maker = MainForm.usersInfo.ID;
                hd.MakeDate = DateTime.Now;
                hd.Auditor = null;
                hd.AuditDate = null;
                hd.Status = 0;
                if (billType == MainMenuConstants.Order)
                {
                    hd.WarehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.FG).ID;  //成品仓
                    hd.BillType = 0;
                }
                else if (billType == MainMenuConstants.FSMOrder)
                {
                    hd.BillType = 1;
                    hd.WarehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.SFG).ID;  //半成品仓
                }
                else if (billType == MainMenuConstants.ProductionOrder)
                {
                    hd.BillType = 2;
                    hd.WarehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.FG).ID;  //成品仓
                }
                //添加
                if (headID == Guid.Empty)
                {
                    hd.ID = Guid.NewGuid();
                    foreach (OrderDtl item in dtl)
                    {
                        item.ID = Guid.NewGuid();
                        item.HdID = hd.ID;
                    }
                    BLLFty.Create<OrderBLL>().Insert(hd, dtl);
                }
                else//修改
                    BLLFty.Create<OrderBLL>().Update(hd, dtl);
                headID = hd.ID;
                if (billType == MainMenuConstants.ProductionOrder)
                {
                    billDtlByAssembleBindingSource.DataSource = dtlByAssemble = BLLFty.Create<OrderBLL>().GetVOrderDtlByBOM(hd.ID, (int)BOMType.Assemble);
                    billDtlByBOMBindingSource.DataSource = dtlByBOM = BLLFty.Create<OrderBLL>().GetVOrderDtlByBOM(hd.ID, (int)BOMType.BOM);
                }
                else if (billType == MainMenuConstants.FSMOrder)
                {
                    ////billDtlByBOMBindingSource.DataSource = dtlByBOM = BLLFty.Create<OrderBLL>().GetVFSMOrderDtlByMoldList(hd.ID);
                    vFSMOrderDtlByMoldMaterialBindingSource.DataSource = dtlByMoldMaterial = BLLFty.Create<OrderBLL>().GetVFSMOrderDtlByMoldMaterial(hd.ID);
                }
                else
                {

                    billDtlByBOMBindingSource.DataSource = dtlByBOM = new List<VOrderDtlByBOM>();
                    billDtlByAssembleBindingSource.DataSource = dtlByAssemble = new List<VOrderDtlByBOM>();
                }
                gvAssemble.BestFitColumns();
                //DataQueryPageRefresh();
                //MainForm.BillSaveRefresh(billType + "Query");
                clientFactory.DataPageRefresh(billType);
                CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "保存成功");
                return true;
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232060)  //违反了PRIMARY KEY约束
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("单号:{0}已经存在,请重新添加新单。", hd.BillNo));
                else
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), ex.Message);
                return false;
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        //string GetStockOutBillMaxBillNo()
        //{
        //    string no = BLLFty.Create<StockOutBillBLL>().GetMaxBillNo();
        //    if (no == null)
        //        no = "CK" + DateTime.Now.ToString("yyyyMMdd") + "001";
        //    else
        //    {
        //        if (no.Substring(2, 8).Equals(DateTime.Now.ToString("yyyyMMdd")))
        //            no = "CK" + DateTime.Now.ToString("yyyyMMdd") + Convert.ToString(int.Parse(no.Substring(10, 3)) + 1).PadLeft(3, '0');
        //        else
        //            no = "CK" + DateTime.Now.ToString("yyyyMMdd") + "001";
        //    }
        //    return no;
        //}

        //string GetStockInBillMaxBillNo()
        //{
        //    string no = BLLFty.Create<StockInBillBLL>().GetMaxBillNo();
        //    if (no == null)
        //        no = "RK" + DateTime.Now.ToString("yyyyMMdd") + "001";
        //    else
        //    {
        //        if (no.Substring(2, 8).Equals(DateTime.Now.ToString("yyyyMMdd")))
        //            no = "RK" + DateTime.Now.ToString("yyyyMMdd") + Convert.ToString(int.Parse(no.Substring(10, 3)) + 1).PadLeft(3, '0');
        //        else
        //            no = "RK" + DateTime.Now.ToString("yyyyMMdd") + "001";
        //    }
        //    return no;
        //}

        public bool Audit()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                gridView.CloseEditForm();
                bool spanProductionOrder = false;
                //客户订单,询问是否生成成品布产单
                if (lueBusinessContact.Enabled == true && !string.IsNullOrEmpty(lueBusinessContact.Text.Trim()) && ((List<Company>)MainForm.dataSourceList[typeof(List<Company>)]).Exists(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString())))
                {
                    System.Windows.Forms.DialogResult result = XtraMessageBox.Show("是否生成成品布产单?", "操作提示",
                System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        spanProductionOrder = true;
                    }
                }
                
                if (hd != null)
                {
                    dtl = BLLFty.Create<OrderBLL>().GetOrderDtl(hd.ID);
                    if (billType == MainMenuConstants.ProductionOrder)
                    {
                        List<StockInBillHd> stockInList = BLLFty.Create<StockInBillBLL>().GetStockInBillHd().FindAll(o => o.OrderID == hd.ID);
                        foreach (StockInBillHd stockIn in stockInList)
                        {
                            if (stockIn != null && stockIn.Status > 0)
                            {
                                string billName = string.Empty; ;
                                if (stockIn.Type == 3)
                                    billName = "产品回收单";
                                else
                                    billName = "成品入库单";
                                CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), string.Format("{0}：{1}已审核或已结账不能取消审核", billName, stockIn.BillNo));
                                return false;
                            }
                        }
                    }
                    if (billType == MainMenuConstants.Order)
                    {
                        List<StockOutBillHd> stockOutList = BLLFty.Create<StockOutBillBLL>().GetStockOutBillHd().FindAll(o => o.OrderID == hd.ID);
                        foreach (StockOutBillHd stockOut in stockOutList)
                        {
                            if (stockOut != null && stockOut.Status > 0)
                            {
                                CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), string.Format("发货单：{0}已审核或已结账不能取消审核", stockOut.BillNo));
                                return false;
                            }
                        }
                    }
                    OrderHd order = BLLFty.Create<OrderBLL>().GetOrderHd(hd.ID);
                    if (order != null && order.Status == 1)
                    {
                        hd.Auditor = MainForm.usersInfo.ID;
                        hd.AuditDate = DateTime.Now;
                        hd.Status = 0;
                        BLLFty.Create<OrderBLL>().CancelAudit(hd);
                        //MainForm.BillSaveRefresh(billType + "Query");
                        //MainForm.InventoryRefresh();
                        clientFactory.DataPageRefresh(billType);
                        CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "取消审核成功");
                        return true;
                    }
                    if (order != null && order.Status == 0)
                    {
                        if (BillValidated() == false)
                            return false;
                    }
                    hd.Auditor = MainForm.usersInfo.ID;
                    hd.AuditDate = DateTime.Now;
                    hd.Status = 1;

                    //删除提醒信息
                    List<Alert> dellist = new List<Alert>();
                    Alert alertBill = ((List<Alert>)MainForm.dataSourceList[typeof(List<Alert>)]).Find(o => o.BillID == hd.ID);
                    if (alertBill != null)
                        dellist.Add(alertBill);
                    if (billType == MainMenuConstants.Order)
                    {
                        //生成发货单、成品布产单
                        //发货单表头数据
                        StockOutBillHd outHd = new StockOutBillHd();
                        outHd.ID = Guid.NewGuid();
                        outHd.BillNo = MainForm.GetMaxBillNo(MainMenuConstants.StockOutBillType, true).MaxBillNo;
                        outHd.WarehouseID = hd.WarehouseID;
                        outHd.WarehouseType = hd.WarehouseType;
                        outHd.OrderID = hd.ID;
                        outHd.OrderDate = hd.OrderDate;                        
                        outHd.CompanyID = hd.CompanyID;
                        outHd.Contacts = hd.Contacts;
                        outHd.SupplierID = hd.SupplierID;
                        outHd.BillDate = hd.AuditDate.Value.Date;
                        outHd.DeliveryDate = hd.DeliveryDate;
                        outHd.Maker = hd.Maker;
                        outHd.MakeDate = hd.MakeDate;
                        outHd.MainMark = hd.MainMark;
                        outHd.Remark = hd.Remark;
                        outHd.Type = 0;  //销售发货
                        outHd.Status = 0;
                        outHd.BillAMT = hd.BillAMT;
                        outHd.UnReceiptedAMT = hd.UnReceiptedAMT;

                        //成品布产单表头数据
                        OrderHd poHd = null;
                        if (spanProductionOrder)
                        {
                            //成品布产单表头数据
                            poHd = new OrderHd();
                            poHd.ID = Guid.NewGuid();
                            poHd.BillNo = MainForm.GetMaxBillNo(MainMenuConstants.Order, true).MaxBillNo;
                            poHd.WarehouseID = hd.WarehouseID;
                            poHd.WarehouseType = hd.WarehouseType;
                            poHd.CompanyID = hd.CompanyID;
                            poHd.Contacts = hd.Contacts;
                            poHd.SupplierID = hd.SupplierID;
                            poHd.OrderDate = hd.AuditDate.Value.Date;
                            poHd.DeliveryDate = hd.DeliveryDate;
                            poHd.Maker = hd.Maker;
                            poHd.MakeDate = hd.MakeDate;
                            poHd.MainMark = hd.MainMark;
                            poHd.Remark = hd.Remark;
                            poHd.Type = hd.Type;
                            poHd.Status = 0;
                            poHd.BillType = 2;
                            poHd.BillAMT = hd.BillAMT;
                            poHd.UnReceiptedAMT = hd.UnReceiptedAMT;
                        }
                        List<StockOutBillDtl> outDtlList = new List<StockOutBillDtl>();
                        foreach (OrderDtl dtlItem in dtl)
                        {
                            //发货单明细数据
                            StockOutBillDtl outDtl = new StockOutBillDtl();
                            outDtl.ID = Guid.NewGuid();
                            outDtl.HdID = outHd.ID;
                            outDtl.GoodsID = dtlItem.GoodsID;
                            outDtl.Qty = dtlItem.Qty;
                            outDtl.MEAS = dtlItem.MEAS;
                            outDtl.PCS = dtlItem.PCS;
                            outDtl.InnerBox = dtlItem.InnerBox;
                            outDtl.NWeight = dtlItem.NWeight == 0 ? 1 : dtlItem.NWeight;
                            outDtl.Price = dtlItem.Price;
                            outDtl.PriceNoTax = dtlItem.PriceNoTax;
                            outDtl.Discount = dtlItem.Discount;
                            outDtl.OtherFee = dtlItem.OtherFee;
                            outDtlList.Add(outDtl);
                        }

                        //成品布产单明细数据
                        List<OrderDtl> poDtlList = null;
                        if (spanProductionOrder)
                        {
                            //成品布产单明细数据
                            poDtlList = dtl;
                            foreach (OrderDtl poDtlItem in poDtlList)
                            {
                                poDtlItem.ID = Guid.NewGuid();
                                poDtlItem.HdID = poHd.ID;
                            }
                        }
                        BLLFty.Create<OrderBLL>().Audit(hd, outHd, outDtlList, poHd, poDtlList, dellist);
                        MainForm.SetAlertCount();
                    }
                    else if (billType == MainMenuConstants.ProductionOrder && MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                    ////if (billType == MainMenuConstants.Order) //根据订单自动生成成品入库单
                    {
                        //成品入库单表头数据
                        StockInBillHd inHd = new StockInBillHd();
                        inHd.ID = Guid.NewGuid();
                        inHd.BillNo = MainForm.GetMaxBillNo(MainMenuConstants.StockInBillType, true).MaxBillNo;
                        inHd.WarehouseID = hd.WarehouseID;
                        inHd.WarehouseType = hd.WarehouseType;
                        inHd.OrderID = hd.ID;
                        inHd.OrderDate = hd.OrderDate;
                        inHd.SupplierID = hd.SupplierID;
                        inHd.CompanyID = hd.CompanyID;
                        inHd.Contacts = hd.Contacts;
                        inHd.BillDate = hd.AuditDate.Value;
                        inHd.OrderID = hd.ID;
                        inHd.OrderDate = hd.OrderDate;
                        inHd.Maker = hd.Maker;
                        inHd.MakeDate = hd.MakeDate;
                        inHd.Remark = hd.Remark;
                        inHd.Type = 0;
                        inHd.Status = 0;
                        inHd.BillAMT = hd.BillAMT;
                        inHd.UnPaidAMT = hd.UnReceiptedAMT;
                        List<StockInBillDtl> inDtlList = new List<StockInBillDtl>();
                        foreach (OrderDtl dtlItem in dtl)
                        {
                            //成品入库单明细数据
                            StockInBillDtl inDtl = new StockInBillDtl();
                            inDtl.ID = Guid.NewGuid();
                            inDtl.HdID = inHd.ID;
                            inDtl.GoodsID = dtlItem.GoodsID;
                            inDtl.Qty = dtlItem.Qty;
                            inDtl.MEAS = dtlItem.MEAS;
                            inDtl.PCS = dtlItem.PCS;
                            inDtl.InnerBox = dtlItem.InnerBox;
                            inDtl.NWeight = dtlItem.NWeight == 0 ? 1 : dtlItem.NWeight;
                            inDtl.Price = dtlItem.Price;
                            inDtl.PriceNoTax = dtlItem.PriceNoTax;
                            inDtl.Discount = dtlItem.Discount;
                            inDtl.OtherFee = dtlItem.OtherFee;
                            inDtlList.Add(inDtl);
                        }
                        BLLFty.Create<StockInBillBLL>().Audit(hd, dtl, inHd, inDtlList);
                    }
                    else if (billType == MainMenuConstants.FSMOrder)
                    {
                        //材料入库单表头数据
                        StockInBillHd inHd = new StockInBillHd();
                        inHd.ID = Guid.NewGuid();
                        inHd.BillNo = MainForm.GetMaxBillNo(MainMenuConstants.StockInBillType, true).MaxBillNo;
                        inHd.WarehouseID = hd.WarehouseID;
                        inHd.OrderID = hd.ID;
                        inHd.OrderDate = hd.OrderDate;
                        inHd.SupplierID = hd.SupplierID;                        
                        inHd.CompanyID = hd.CompanyID;
                        inHd.Contacts = hd.Contacts;
                        inHd.BillDate = hd.AuditDate.Value.Date;
                        inHd.OrderID = hd.ID;
                        inHd.OrderDate = hd.OrderDate;
                        inHd.Maker = hd.Maker;
                        inHd.MakeDate = hd.MakeDate;
                        inHd.Remark = hd.Remark;
                        inHd.Type = 6;
                        inHd.Status = 0;
                        inHd.BillAMT = hd.BillAMT;
                        inHd.UnPaidAMT = hd.UnReceiptedAMT;
                        List<StockInBillDtl> inDtlList = new List<StockInBillDtl>();
                        //foreach (OrderDtl dtlItem in dtlByBOM)  //添加模具对应的材料明细
                        foreach (VOrderDtlByBOM dtlItem in dtlByBOM)  //添加模具对应的材料明细
                        {
                            //材料入库单明细数据
                            StockInBillDtl inDtl = new StockInBillDtl();
                            inDtl.ID = Guid.NewGuid();
                            inDtl.HdID = inHd.ID;
                            inDtl.GoodsID = dtlItem.GoodsID;
                            inDtl.Qty = dtlItem.Qty.Value;
                            //inDtl.MEAS = dtlItem.MEAS;
                            inDtl.PCS = dtlItem.PCS;
                            inDtl.InnerBox = (int)dtlItem.InnerBox;
                            inDtl.NWeight = dtlItem.NWeight == 0 ? 1 : dtlItem.NWeight;
                            inDtl.Price = dtlItem.Price;
                            inDtl.PriceNoTax = dtlItem.PriceNoTax;
                            inDtl.Discount = dtlItem.Discount;
                            inDtl.OtherFee = dtlItem.OtherFee;
                            inDtlList.Add(inDtl);
                        }
                        BLLFty.Create<StockInBillBLL>().Audit(hd, dtl, inHd, inDtlList);
                    }
                    else
                        BLLFty.Create<OrderBLL>().Update(hd);
                }
                //DataQueryPageRefresh();
                //MainForm.BillSaveRefresh(billType + "Query");
                //MainForm.InventoryRefresh();
                clientFactory.DataPageRefresh(billType);
                CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "审核成功");
                return true;
            }
            catch (Exception ex)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), ex.Message);
                return false;
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        public void Print()
        {
            DevExpress.XtraGrid.GridControl printControl = null;
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (dtl == null)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "没有可打印的数据");
                    return;
                }
                //if (billType == MainMenuConstants.ProductionOrder)
                //{
                //    printControl = gcBillDtlForPrint;
                //    //for (int i = 0; i < gvBillDtlForPrint.RowCount; i++)
                //    //{
                //    //    Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID.Equals(new Guid(gvBillDtlForPrint.GetRowCellValue(i, colGoodsID).ToString())));
                //    //    StringBuilder sb = new StringBuilder();
                //    //    sb.AppendFormat("\r\nITEM NO: {0}\r\n", goods.Code);
                //    //    sb.AppendFormat("QTY: {0} PCS\r\n", gvBillDtlForPrint.GetRowCellValue(i, colQty));
                //    //    sb.AppendFormat("G.W: {0} KGS\r\n", goods.GWeight);
                //    //    sb.AppendFormat("N.W: {0} KGS\r\n", goods.NWeight);
                //    //    sb.AppendFormat("MEAS: {0} CM\r\n", goods.MEAS);
                //    //    gvBillDtlForPrint.SetRowCellValue(i, gvBillDtlForPrint.Columns["侧唛"], sb.ToString());
                //    //}
                //    //gvBillDtlForPrint.Columns["货号"].GroupIndex = 0;
                //    //gvBillDtlForPrint.Columns["货号"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                //    ////金额转大写
                //    //gvBillDtlForPrint.Columns["品名"].Summary.Clear();
                //    //gvBillDtlForPrint.Columns["品名"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                //    //    new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "金额", "合计金额:"+Rexlib.MoneyToUpper(hd.BillAMT.Value))});
                //}
                //else
                printControl = gridControl;
                if (MainForm.itemDetailPageList[billType].isBOMPrint)
                {
                    switch (bomType)
                    {
                        case BOMType.BOM:
                            printControl = gcBOM;
                            break;
                        case BOMType.MoldList:
                            printControl = gcBOM;
                            break;
                        case BOMType.MoldMaterial:
                            printControl = gcMoldMaterial;
                            break;
                        case BOMType.Assemble:
                            printControl = gcBOM;
                            break;
                        default:
                            break;
                    }
                    gcBOM.DataSource = dtlByBOM;
                }
                if (billType == MainMenuConstants.ProductionOrder)
                {
                    gcBOM.DataSource = dtlByBOM;
                    //foreach (DevExpress.XtraGrid.Columns.GridColumn col in ((GridView)gcBOM.MainView).Columns)
                    //{
                    //    col.BestFit();
                    //}
                }
                else if (billType == MainMenuConstants.FSMOrder)
                {
                    gcMoldMaterial.DataSource = dtlByMoldMaterial;
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in ((GridView)gcMoldMaterial.MainView).Columns)
                    {
                        col.BestFit();
                    }
                }
                //隐藏部分列
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in ((GridView)printControl.MainView).Columns)
                {
                    if (col == colPackaging || col == colInnerBox || col == colDiscount || col == colOtherFee)
                        col.Visible = false;
                    if (MainForm.Company.Contains("谷铭达") && (col == colPrice || col == colAMT))
                        col.Visible = false;
                }
                ((GridView)gcMoldMaterial.MainView).BestFitColumns();
                PrintSettingController psc = new PrintSettingController(printControl);

                //页眉 
                if (hd != null)
                {
                    psc.PrintCompany = MainForm.Company;
                    List<TypesList> types = MainForm.dataSourceList[typeof(List<TypesList>)] as List<TypesList>;
                    if (billType == MainMenuConstants.ProductionOrder)
                        psc.PrintHeader = "货品布产单";
                    else if (billType == MainMenuConstants.FSMOrder)
                        psc.PrintHeader = "模具布产单";
                    else
                        psc.PrintHeader = "订货单";
                    psc.PrintSubTitle = MainForm.Contacts.Replace("\\r\\n", "\r\n");
                    psc.PrintLeftHeader = "单据编号：" + hd.BillNo + "\r\n"
                        + "    仓库：" + lueWarehouse.Text + "\r\n"
                        + "业务往来：" + lueBusinessContact.Text;
                    psc.PrintRightHeader = "订货日期：" + deOrderDate.Text + "\r\n"
                        + "交货日期：" + deDeliveryDate.Text + "\r\n"
                        + "联系人：" + txtContacts.EditValue;
                    //if (!string.IsNullOrEmpty(meRemark.Text))
                    //    psc.PrintRightHeader = "备注：" + meRemark.Text;

                    //页脚 
                    //psc.PrintLeftFooter = "制单人：" + lueMaker.Text + "  制单日期：" + deMakeDate.Text + "\r\n"
                    //    + "审核人：" + lueAuditor.Text + "  审核日期：" + deAuditDate.Text;
                    ////psc.PrintFooter = "审核人：" + lueAuditor.Text + "  审核日期：" + deAuditDate.Text;
                    psc.PrintLeftFooter = "送货单位(盖章):";
                    psc.PrintFooter = "收货单位(盖章):";
                    psc.PrintRightFooter = "制单人：" + lueMaker.Text;

                    //金额转大写
                    //gridView.Columns["colName"].Summary.Clear();
                    //gridView.Columns["colName"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    //    new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "金额", "合计金额:"+Rexlib.MoneyToUpper(hd.BillAMT.Value))});
                }
                //横纵向 
                //psc.LandScape = this.rbtnHorizon.Checked;
                if (billType == MainMenuConstants.ProductionOrder)
                {
                    psc.LandScape = false;
                    //纸型 
                    psc.PaperKind = System.Drawing.Printing.PaperKind.A4;
                }
                else
                {
                    psc.LandScape = MainForm.IsLandScape;
                    //纸型 
                    psc.PaperKind = MainForm.PrintPaperKind;
                    psc.PaperSize = MainForm.PaperSize;
                }
                //加载页面设置信息 
                psc.LoadPageSetting();

                psc.Preview();
            }
            catch (Exception ex)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "没有可打印的数据。\r\n错误信息：" + ex.Message);
            }
            finally
            {
                //gridView.AddNewRow();
                //SendKeys.Send("{UP}");
                //gridControl.EndUpdate();
                //还原隐藏列
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in ((GridView)printControl.MainView).Columns)
                {
                    if (col == colPackaging || col == colInnerBox || col == colDiscount || col == colOtherFee)
                        col.Visible = true;
                    if (MainForm.Company.Contains("谷铭达") && (col == colPrice || col == colAMT))
                        col.Visible = true;
                }
                //控制栏位顺序
                int i = 0;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in ((GridView)printControl.MainView).Columns)
                {
                    if (col.Visible)
                        col.VisibleIndex = i++;
                }
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void gridView_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn == colRemark
                && new Guid(gridView.GetRowCellValue(gridView.FocusedRowHandle, colGoodsID).ToString()) != Guid.Empty
                && decimal.Parse(gridView.GetRowCellValue(gridView.FocusedRowHandle, colQty).ToString()) > 0)
            {
                gridView.AddNewRow();
            }
        }

        private void repositoryItemLueGoods_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (lueBusinessContact.Enabled == true && string.IsNullOrEmpty(lueBusinessContact.EditValue.ToString()))
                {
                    gridView.DeleteSelectedRows();
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请先选择业务往来信息。");
                    return;
                }
                //gridControl.BeginUpdate();
                if (billType == MainMenuConstants.Order)
                {
                    VGoods goods = ((LookUpEdit)sender).GetSelectedDataRow() as VGoods;
                    if (goods != null)
                    {
                        //if (dtl != null && dtl.Any(o => o.GoodsID == goods.ID))
                        //{
                        //    //gridView.SetRowCellValue(gridView.FocusedRowHandle, colGoodsID, null);
                        //    gridView.DeleteSelectedRows();
                        //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "不能重复选择货品。");
                        //    return;

                        //}
                        //gridView.SetRowCellValue(gridView.FocusedRowHandle, colGoodsID, goods.ID);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colMEAS, goods.外箱规格);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colPCS, goods.装箱数);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colInnerBox, goods.内盒);
                        //gridView.SetRowCellValue(gridView.FocusedRowHandle, colNWeight, goods.NWeight == 0 ? 1 : goods.NWeight);
                        //客户设置固定售价
                        Decimal price = goods.单价;
                        Decimal disCount = 1;
                        Decimal otherFee = 0;
                        //if (((List<Company>)MainForm.dataSourceList[typeof(List<Company>)]).Exists(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == (int)CustomerType.DomesticSales))
                        if (((List<Company>)MainForm.dataSourceList[typeof(List<Company>)]).Exists(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString())))
                        {
                            //获取或设置客户商品售价
                            SLSalePrice cSLSalePrice = ((List<SLSalePrice>)MainForm.dataSourceList[typeof(List<SLSalePrice>)]).Find(o =>
                               o.ID == new Guid(lueBusinessContact.EditValue.ToString()) && o.GoodsID == goods.ID && o.Type == businessContactType);
                            //if (cSLSalePrice == null)
                            //    isSLSalePrice = true;
                            //else
                            if (cSLSalePrice!=null)
                            {
                                price = cSLSalePrice.Price;
                                disCount = cSLSalePrice.Discount;
                                otherFee = cSLSalePrice.OtherFee;
                            }
                        }
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colPrice, price);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colDiscount, disCount);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colOtherFee, otherFee);
                        //gridView.SetRowCellValue(gridView.FocusedRowHandle, colPriceNoTax, goods.去税单价);
                    }
                }
                else
                {
                    VParentGoodsByBOM goods = ((LookUpEdit)sender).GetSelectedDataRow() as VParentGoodsByBOM;
                    if (goods != null)
                    {
                        //if (dtl != null && dtl.Any(o => o.GoodsID == goods.ID))
                        //{
                        //    //gridView.SetRowCellValue(gridView.FocusedRowHandle, colGoodsID, null);
                        //    gridView.DeleteSelectedRows();
                        //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "不能重复选择货品。");
                        //    return;

                        //}
                        //gridView.SetRowCellValue(gridView.FocusedRowHandle, colGoodsID, goods.ID);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colMEAS, goods.外箱规格);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colPCS, goods.装箱数);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colInnerBox, goods.内盒);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colPrice, goods.单价);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colPriceNoTax, goods.去税单价);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colDiscount, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), ex.Message);
            }
            finally
            {
                //gridView.AddNewRow();
                //SendKeys.Send("{UP}");
                //gridControl.EndUpdate();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void lueCompany_EditValueChanged(object sender, EventArgs e)
        {
            if (billType == MainMenuConstants.Order)
            {
                VCompany company = ((LookUpEdit)sender).GetSelectedDataRow() as VCompany;
                if (company != null && hd != null)
                {
                    hd.CompanyID = company.ID;
                    hd.Contacts = company.联系人;
                    if (headID == Guid.Empty)
                        hd.WarehouseType = company.客户类型;
                }
            }
            else
            {
                VSupplier supplier = ((LookUpEdit)sender).GetSelectedDataRow() as VSupplier;
                if (supplier != null && hd != null)
                {
                    hd.SupplierID = supplier.ID;
                    hd.Contacts = supplier.联系人;
                }
            }
        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            List<OrderDtl> list = ((BindingSource)view.DataSource).DataSource as List<OrderDtl>;
            if (e.IsGetData && list != null && list.Count > 0)
            {
                Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID == list[e.ListSourceRowIndex].GoodsID);
                if (goods != null)
                {
                    if (e.Column == colName)
                        e.Value = goods.Name;
                    if (e.Column == colPackaging && goods.PackagingID != null && goods.PackagingID != Guid.Empty)
                        e.Value = ((List<Packaging>)MainForm.dataSourceList[typeof(List<Packaging>)]).Find(o => o.ID == goods.PackagingID).Name;
                    if (e.Column == colSPEC)
                        e.Value = goods.SPEC;
                    if (e.Column == colUnit)
                        e.Value = goods.Unit;
                    if (e.Column == colRemark)
                        e.Value = goods.Remark;
                }
            }
        }

        private void gvBOM_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            List<VOrderDtlByBOM> list = view.DataSource as List<VOrderDtlByBOM>;
            if (list == null)
                list = ((BindingSource)view.DataSource).DataSource as List<VOrderDtlByBOM>;
            if (e.IsGetData && list != null && list.Count > 0)
            {
                Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID == list[e.ListSourceRowIndex].GoodsID);
                if (goods != null)
                {
                    if (e.Column == colName1)
                        e.Value = goods.Name;
                    if (e.Column == colSPEC1)
                        e.Value = goods.SPEC;
                    if (e.Column == colUnit1)
                        e.Value = goods.Unit;
                    if (e.Column == colRemark1)
                        e.Value = goods.Remark;
                }
            }
        }

        private void gvAssemble_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            List<VOrderDtlByBOM> list = view.DataSource as List<VOrderDtlByBOM>;
            if (list == null)
                list = ((BindingSource)view.DataSource).DataSource as List<VOrderDtlByBOM>;
            if (e.IsGetData && list != null && list.Count > 0)
            {
                Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID == list[e.ListSourceRowIndex].GoodsID);
                if (goods != null)
                {
                    if (e.Column == colName3)
                        e.Value = goods.Name;
                    if (e.Column == colSPEC3)
                        e.Value = goods.SPEC;
                    if (e.Column == colUnit3)
                        e.Value = goods.Unit;
                    if (e.Column == colRemark3)
                        e.Value = goods.Remark;
                }
            }
        }

        private void gvMoldMaterial_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            List<OrderDtl> list = ((BindingSource)view.DataSource).DataSource as List<OrderDtl>;
            if (e.IsGetData && list != null && list.Count > 0)
            {
                Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID == list[e.ListSourceRowIndex].GoodsID);
                if (goods != null)
                {
                    if (e.Column == colName2)
                        e.Value = goods.Name;
                    if (e.Column == colSPEC2)
                        e.Value = goods.SPEC;
                    if (e.Column == colUnit2)
                        e.Value = goods.Unit;
                    if (e.Column == colRemark2)
                        e.Value = goods.Remark;
                }
            }
        }

        public void Import()
        {
            throw new NotImplementedException();
        }

        public void Export()
        {
            throw new NotImplementedException();
        }

        public void SendData(object data)
        {
            //bomType = (BOMType)data;
            //Print();
            #region #showreport
            XtraMRPReport xr = new XtraMRPReport();
            List<VProductionOrder> vorder = BLLFty.Create<OrderBLL>().GetVProductionOrder(hd.ID);
            List<VOrderDtlByColor> color= BLLFty.Create<OrderBLL>().GetVOrderDtlByColor(hd.ID, (int)BOMType.Assemble);
            xr.SetReportDataSource(vorder, dtlByBOM.OrderBy(o => o.货号), dtlByAssemble.OrderBy(o => o.货号), color);
            xr.CreateDocument(true);
            xr.paramCompany.Value = MainForm.Company;
            xr.paramTitle.Value = "物料需求计划表";
            xr.paramContacts.Value = MainForm.Contacts.Replace("\\r\\n", "\r\n");
            xr.paramBillNo.Value = hd.BillNo;
            xr.paramCustomer.Value = lueBusinessContact.Text;
            xr.paramStartDate.Value = hd.OrderDate.ToString("yyyy-MM-dd");
            xr.parameEndDate.Value = hd.DeliveryDate.ToString("yyyy-MM-dd");

            using (ReportPrintTool printTool = new ReportPrintTool(xr))
            {
                printTool.AutoShowParametersPanel = false;
                printTool.ShowRibbonPreviewDialog();
            }
            #endregion #show
        }

        public object ReceiveData()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (billType == MainMenuConstants.ProductionOrder)
                {
                    //List<VStockInBillDtlByBOM> boms = BLLFty.Create<StockInBillBLL>().GetVStockInBillDtlByBOM2(hd.ID, (int)BOMType.Assemble).OrderBy(o => o.货号).ToList();
                    if (dtlByBOM.Count > 0 || dtlByAssemble.Count >0)
                    {
                        System.Windows.Forms.DialogResult result = XtraMessageBox.Show("确定要生成领料出库单吗?", "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            //生成领料出库单表头数据
                            StockOutBillHd outHd = new StockOutBillHd();
                            outHd.ID = Guid.NewGuid();
                            outHd.BillNo = MainForm.GetMaxBillNo(MainMenuConstants.StockOutBillType, true).MaxBillNo;
                            outHd.WarehouseID = hd.WarehouseID;
                            outHd.WarehouseType = hd.WarehouseType;
                            outHd.OrderID = hd.ID;
                            outHd.OrderDate = hd.OrderDate;
                            outHd.CompanyID = hd.CompanyID;
                            outHd.Contacts = hd.Contacts;
                            outHd.SupplierID = hd.SupplierID;
                            outHd.BillDate = DateTime.Now;
                            outHd.DeliveryDate = DateTime.Now;
                            outHd.Maker = hd.Maker;
                            outHd.MakeDate = DateTime.Now;
                            //outHd.MainMark = hd.MainMark;
                            outHd.Remark = hd.Remark;
                            outHd.Type = 6;  //领料出库
                            outHd.Status = 0;
                            outHd.BillAMT = hd.BillAMT;
                            //outHd.UnReceiptedAMT = hd.UnReceiptedAMT;
                            List<StockOutBillDtl> outDtlList = new List<StockOutBillDtl>();
                            int i = 0;
                            foreach (VOrderDtlByBOM dtlItem in dtlByBOM.OrderBy(o => o.货号))
                            {
                                //领料单明细数据
                                StockOutBillDtl outDtl = new StockOutBillDtl();
                                outDtl.ID = Guid.NewGuid();
                                outDtl.HdID = outHd.ID;
                                outDtl.GoodsID = dtlItem.GoodsID;
                                outDtl.Qty = dtlItem.Qty == null ? 0 : dtlItem.Qty.Value;
                                //outDtl.MEAS = dtlItem.MEAS;
                                outDtl.PCS = dtlItem.PCS;
                                outDtl.InnerBox = dtlItem.InnerBox;
                                outDtl.NWeight = dtlItem.NWeight == 0 ? 1 : dtlItem.NWeight;
                                outDtl.Price = dtlItem.Price;
                                outDtl.PriceNoTax = dtlItem.PriceNoTax;
                                outDtl.Discount = dtlItem.Discount;
                                outDtl.OtherFee = dtlItem.OtherFee;
                                outDtl.SerialNo = i++;
                                outDtlList.Add(outDtl);
                            }
                            foreach (VOrderDtlByBOM dtlItem in dtlByAssemble.OrderBy(o => o.货号))
                            {
                                //领料单明细数据
                                StockOutBillDtl outDtl = new StockOutBillDtl();
                                outDtl.ID = Guid.NewGuid();
                                outDtl.HdID = outHd.ID;
                                outDtl.GoodsID = dtlItem.GoodsID;
                                outDtl.Qty = dtlItem.Qty == null ? 0 : dtlItem.Qty.Value;
                                //outDtl.MEAS = dtlItem.MEAS;
                                outDtl.PCS = dtlItem.PCS;
                                outDtl.InnerBox = dtlItem.InnerBox;
                                outDtl.NWeight = dtlItem.NWeight == 0 ? 1 : dtlItem.NWeight;
                                outDtl.Price = dtlItem.Price;
                                outDtl.PriceNoTax = dtlItem.PriceNoTax;
                                outDtl.Discount = dtlItem.Discount;
                                outDtl.OtherFee = dtlItem.OtherFee;
                                outDtl.SerialNo = i++;
                                outDtlList.Add(outDtl);
                            }
                            BLLFty.Create<StockOutBillBLL>().Insert(outHd, outDtlList);
                            //MainForm.BillSaveRefresh(MainMenuConstants.GetMaterialBillQuery);
                            clientFactory.DataPageRefresh<VMaterialStockOutBill>();
                            XtraMessageBox.Show("领料出库单已成功生成。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "没有可生成的数据。");
                }
            }
            catch (Exception ex)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), ex.Message);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            return null;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBillNo.Text.Trim()) && lueBillType.EditValue != null)
            {
                List<OrderHd> bills = ((List<OrderHd>)MainForm.dataSourceList[typeof(List<OrderHd>)]).FindAll(o =>
                    o.BillType == (int)EnumHelper.GetEnumValues<OrderBillType>(true).FirstOrDefault(t => t.Name == billType).Value).OrderBy(o => o.BillNo).ToList();
                for (int i = 0; i < bills.Count; i++)
                {
                    if (bills[i].BillNo.Equals(txtBillNo.Text.Trim()))
                    {
                        if (i - 1 >= 0)
                        {
                            BindData(bills[i - 1].ID);
                            btnNext.Enabled = true;
                            if (i - 1 == 0)
                                btnPrev.Enabled = false;
                            if (bills[i - 1].Status == 0)
                                MainForm.itemDetailPageList[billType].setNavButtonStatus(MainForm.mainMenuList[billType], ButtonType.btnSave);
                            else
                                MainForm.itemDetailPageList[billType].setNavButtonStatus(MainForm.mainMenuList[billType], ButtonType.btnAudit);
                            break;
                        }
                        else
                        {
                            btnPrev.Enabled = false;
                            btnNext.Enabled = true;
                            break;
                        }
                    }
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBillNo.Text.Trim()) && lueBillType.EditValue != null)
            {
                List<OrderHd> bills = ((List<OrderHd>)MainForm.dataSourceList[typeof(List<OrderHd>)]).FindAll(o =>
                    o.BillType == (int)EnumHelper.GetEnumValues<OrderBillType>(true).FirstOrDefault(t => t.Name == billType).Value).OrderBy(o => o.BillNo).ToList();
                for (int i = 0; i < bills.Count; i++)
                {
                    if (bills[i].BillNo.Equals(txtBillNo.Text.Trim()))
                    {
                        if (i + 1 < bills.Count)
                        {
                            BindData(bills[i + 1].ID);
                            btnPrev.Enabled = true;
                            if (i + 1 == bills.Count - 1)
                                btnNext.Enabled = false;
                            if (bills[i + 1].Status == 0)
                                MainForm.itemDetailPageList[billType].setNavButtonStatus(MainForm.mainMenuList[billType], ButtonType.btnSave);
                            else
                                MainForm.itemDetailPageList[billType].setNavButtonStatus(MainForm.mainMenuList[billType], ButtonType.btnAudit);
                            break;
                        }
                        else
                        {
                            btnPrev.Enabled = true;
                            btnNext.Enabled = false;
                            break;
                        }
                    }
                }
            }
        }

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            List<StockOutBillDtl> list = ((BindingSource)view.DataSource).DataSource as List<StockOutBillDtl>;
            if (list != null && list.Count > 0)
            {
                if (e.Column == colGoodsID)
                {
                    object disCount = view.GetRowCellValue(e.RowHandle, colDiscount);
                    if (disCount == null || Convert.ToInt32(disCount) == 0)
                        view.SetRowCellValue(e.RowHandle, colDiscount, 1);
                }
            }
        }
    }
}
