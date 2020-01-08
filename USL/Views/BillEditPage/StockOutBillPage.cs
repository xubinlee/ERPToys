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
using EDMX;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using Factory;
using BLL;
using Utility;
using IBase;
using DevExpress.XtraBars.Docking2010.Views;
using System.Collections;
using CommonLibrary;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraGrid.Views.Grid;
using Utility.Interceptor;
using ClientFactory;

namespace USL
{
    public partial class StockOutBillPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail,IExtensions
    {
        private static BaseFactory baseFactory = LoggerInterceptor.CreateProxy<BaseFactory>();
        private static StockOutBillFactory stockOutBillFactory = LoggerInterceptor.CreateProxy<StockOutBillFactory>();
        //StockOutBillHd hd;
        //List<StockOutBillDtl> dtl;
        List<StockOutBillDtl> dtlByBOM;
        List<Warehouse> warehouseList;
        //PageGroup pageGroupCore;
        Guid headID;
        MainMenuEnum billType;
        //List<TypesList> types;   //类型列表
        //bool isSLSalePrice = false;
        //int goodsType = 0;
        BOMType bomType;
        int businessContactType = 0;

        public Guid HeadID { get => headID; set => headID = value; }

        public StockOutBillPage(Guid hdID, MainMenuEnum type)
        {
            InitializeComponent();
            if (MainForm.Company.Contains("创萌"))
            {
                this.colPrice.Caption = "单价(分)";
                this.colAMT.Caption = "金额(分)";
            }
            else
            {
                this.colPrice.Caption = "单价";
                this.colAMT.Caption = "金额";
            }
            headID = hdID;
            //pageGroupCore = child;
            billType = type;
            BindData(headID);
            if (type == MainMenuEnum.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
            {
                SetDtlHeader(true);
                businessContactType = (int)BusinessContactType.Customer;
            }
            else
            {
                SetDtlHeader(false);
                businessContactType = (int)BusinessContactType.Supplier;
            }
        }

        void SetDtlHeader(bool flag)
        {
            meMainMark.Visible = flag;
            if (flag)
            {
                colQty.Caption = "箱数";
                colModulus.Visible = false;
                colCounts.Visible = false;
            }
            else
            {
                if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory && ((billType == MainMenuEnum.EMSStockOutBill && lueType.ItemIndex == 0 || lueType.ItemIndex == -1)
                    || (billType == MainMenuEnum.GetMaterialBill && lueType.EditValue != null && Convert.ToInt32(lueType.EditValue) == 3)
                    || billType == MainMenuEnum.EMSDPReturnBill || billType == MainMenuEnum.FSMDPReturnBill))
                {
                    colQty.Caption = "重量";
                    colModulus.Visible = true;
                    colCounts.Visible = true;
                }
                //else if (billType == MainMenuEnum.EMSStockOutBill && lueType.ItemIndex == 0 || lueType.ItemIndex == -1)
                //{
                //    SetDtlHeader(true);
                //}
                else
                {
                    colQty.Caption = "数量";
                    colModulus.Visible = false;
                    colCounts.Visible = false;
                }
            }
            colPackaging.Visible = flag;
            colMEAS.Visible = flag;
            colSPEC.Visible = !flag;
            colPCS.Visible = flag;
            colInnerBox.Visible = flag;
            colTotalQty.Visible = flag;
            colNWeight.Visible = !flag;
            colCavityNumber.Visible = !flag;
            colUnit.Visible = !flag;

            lueOrderNo.Visible = flag;
            //colOrderQty.Visible = flag;
            if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory && billType == MainMenuEnum.GetMaterialBill)
            {
                colTonsQty.Visible = true;
                colTonsPrice.Visible = true;
            }
            else
            {
                colTonsQty.Visible = false;
                colTonsPrice.Visible = false;
            }
            //控制栏位顺序
            int i = 0;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView.Columns)
            {
                if (col.Visible)
                    col.VisibleIndex = i++;
            }
            if ((MainForm.Company.Contains("大正") || MainForm.Company.Contains("纸")))
                lciWarehouseType.Visibility = LayoutVisibility.Never;
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

        public void BindData(object hdID)
        {
            if (hdID is Guid && ((Guid)hdID) != Guid.Empty)
            {
                headID = (Guid)hdID;
                StockOutBillHd hd = baseFactory.GetModelList<StockOutBillHd>().FirstOrDefault(o => o.ID.Equals(headID));
                stockOutBillHdBindingSource.DataSource = hd;
                stockOutBillDtlBindingSource.DataSource = hd.StockOutBillDtl;
                if (billType == MainMenuEnum.EMSStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1) ||
                    billType == MainMenuEnum.FSMDPReturnBill)
                {
                    Predicate<VStockOutBillDtlByBOM> predicate = o => o.HdID == headID && o.Type == (int)BOMType.Assemble;
                    List<VStockOutBillDtlByBOM> vList = baseFactory.GetModelList<VStockOutBillDtlByBOM>().FindAll(predicate);
                    vList.ForEach(item => {
                        StockOutBillDtl dtl = new StockOutBillDtl();
                        dtl.ID = item.ID;
                        dtl.HdID = item.HdID;
                        dtl.GoodsID = item.GoodsID;
                        dtl.Qty = item.Qty.Value;
                        dtl.PCS = item.PCS;
                        dtl.InnerBox = item.InnerBox;
                        //dtl.NWeight = item.NWeight == 0 ? 1 : item.NWeight;
                        dtl.Price = item.Price;
                        dtl.PriceNoTax = item.PriceNoTax;
                        dtl.Discount = item.Discount;
                        dtl.OtherFee = item.OtherFee;
                        dtlByBOM.Add(dtl);
                    });
                    billDtlByBOMBindingSource.DataSource = dtlByBOM;
                }
                else
                    billDtlByBOMBindingSource.DataSource = dtlByBOM = new List<StockOutBillDtl>();
            }
            //types = baseFactory.GetModelList<TypesList>();
            //单据类型
            typesListBindingSource.DataSource = EnumHelper.GetEnumValues<StockOutBillTypeEnum>(false).FindAll(o => o.Value.ToString() == billType.ToString());
            //if (billType == MainMenuEnum.GetMaterialBill)
            //{
            //    if (MainForm.ISnowSoftVersion == ISnowSoftVersion.PurchaseSellStock)
            //        typesListBindingSource.DataSource = types.FindAll(o => o.Type == MainMenuEnum.StockOutBillType.ToString() && o.No == 6);
            //    else if (MainForm.ISnowSoftVersion == ISnowSoftVersion.EMS)
            //        typesListBindingSource.DataSource = types.FindAll(o => o.Type == MainMenuEnum.StockOutBillType.ToString() && (o.No == 3 || o.No == 6));
            //    else if (MainForm.ISnowSoftVersion == ISnowSoftVersion.FSM)
            //        typesListBindingSource.DataSource = types.FindAll(o => o.Type == MainMenuEnum.StockOutBillType.ToString() && (o.No == 5 || o.No == 6));
            //    else if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
            //        typesListBindingSource.DataSource = types.FindAll(o => o.Type == MainMenuEnum.StockOutBillType.ToString() && (o.No == 3 || o.No == 5 || o.No == 6));
            //    else
            //        typesListBindingSource.DataSource = types.FindAll(o => o.Type == MainMenuEnum.StockOutBillType.ToString() && (o.No == 3));
            //}
            //else if (billType == MainMenuEnum.EMSStockOutBill && MainForm.SysInfo.CompanyType == (int)CompanyType.Trade)
            //{
            //    typesListBindingSource.DataSource = types.FindAll(o => o.Type == MainMenuEnum.StockOutBillType.ToString() && o.No == 3);
            //}
            //else if (MainForm.ISnowSoftVersion == ISnowSoftVersion.Sales || MainForm.ISnowSoftVersion == ISnowSoftVersion.SalesManagement)
            //    typesListBindingSource.DataSource = types.FindAll(o => o.SubType == billType.ToString() && o.No == 0);
            //else
            //    typesListBindingSource.DataSource = types.FindAll(o => o.SubType == billType.ToString());
            //仓库类型
            warehouseTypeBindingSource.DataSource = EnumHelper.GetEnumValues<CustomerTypeEnum>(false); //types.FindAll(o => o.Type == TypesListConstants.CustomerType);
            warehouseBindingSource.DataSource = warehouseList = baseFactory.GetModelList<Warehouse>();
            vGoodsBindingSource.DataSource = null;
            if (billType == MainMenuEnum.EMSStockOutBill)
            {
                List<VGoodsByBOM> vGoodsByBOMList = baseFactory.GetModelList<VGoodsByBOM>();
                if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                {
                    if ((lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                    {
                        if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                            vGoodsBindingSource.DataSource = vGoodsByBOMList.FindAll(o => o.类型 == (int)BOMType.BOM);
                        else
                            vGoodsBindingSource.DataSource = baseFactory.GetModelList<VGoods>();
                    }
                    else if (lueType.ItemIndex == 1)
                    {
                        if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                            vGoodsBindingSource.DataSource = vGoodsByBOMList.FindAll(o => o.类型 == (int)BOMType.Assemble);
                        else
                            vGoodsBindingSource.DataSource = vGoodsByBOMList.FindAll(o => o.类型 == (int)BOMType.Assemble || o.类型 == (int)BOMType.BOM);
                    }
                }
                else
                    vGoodsBindingSource.DataSource = vGoodsByBOMList.FindAll(o => o.类型 == (int)BOMType.Assemble || o.类型 == (int)BOMType.BOM);
            }
            else
            {
                List<VMaterial> vMaterialList = baseFactory.GetModelList<VMaterial>();
                if (billType == MainMenuEnum.FGStockOutBill)
                {
                    if ((lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                    {
                        vGoodsBindingSource.DataSource = baseFactory.GetModelList<VGoods>();
                        //if (!string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))
                        //    orderHdBindingSource.DataSource = BLLFty.Create<OrderBLL>().GetOrderHd().FindAll(o => o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Status == 1);
                    }
                    else
                        vGoodsBindingSource.DataSource = vMaterialList.FindAll(o => o.Type == (int)GoodsBigTypeEnum.SFGoods);
                }
                else if (billType == MainMenuEnum.FSMStockOutBill)
                    vGoodsBindingSource.DataSource = vMaterialList.FindAll(o => o.Type == (int)GoodsBigTypeEnum.Material || o.Type == (int)GoodsBigTypeEnum.Basket);
                else if (billType == MainMenuEnum.FSMDPReturnBill || billType == MainMenuEnum.EMSDPReturnBill)
                    vGoodsBindingSource.DataSource = vMaterialList.FindAll(o => o.Type == (int)GoodsBigTypeEnum.Stuff || o.Type == (int)GoodsBigTypeEnum.Basket);
                else if (billType == MainMenuEnum.SFGStockOutBill)
                    vGoodsBindingSource.DataSource = baseFactory.GetModelList<VMaterial>().FindAll(o => o.Type > 0);
                else if (billType == MainMenuEnum.GetMaterialBill)
                {
                    switch (Convert.ToInt32(lueType.EditValue))
                    {
                        case 3:
                            if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                                vGoodsBindingSource.DataSource = vMaterialList.FindAll(o => o.Type == (int)GoodsBigTypeEnum.Stuff || o.Type == (int)GoodsBigTypeEnum.Basket);
                            else
                                vGoodsBindingSource.DataSource = vMaterialList;
                            break;
                        case 5:
                            vGoodsBindingSource.DataSource = vMaterialList.FindAll(o => o.Type == (int)GoodsBigTypeEnum.Material || o.Type == (int)GoodsBigTypeEnum.Basket);
                            break;
                        case 6:
                            vGoodsBindingSource.DataSource = vMaterialList.FindAll(o => o.Type == (int)GoodsBigTypeEnum.SFGoods || o.Type == (int)GoodsBigTypeEnum.Stuff || o.Type == (int)GoodsBigTypeEnum.Mold);
                            break;
                        default:
                            break;
                    }
                }
            }
            vGoodsByBOMBindingSource.DataSource = baseFactory.GetModelList<VGoodsByBOM>();
            vUsersInfoBindingSource.DataSource = baseFactory.GetModelList<VUsersInfo>();
            if (billType == MainMenuEnum.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
            {
                businessContactType = (int)BusinessContactType.Customer;
                SetDtlHeader(true);
            }
            else
            {
                businessContactType = (int)BusinessContactType.Supplier;
                SetDtlHeader(false);
            }
        }

        public void Add()
        {
            StockOutBillHd hd = new StockOutBillHd();
            stockOutBillHdBindingSource.DataSource = hd;
            stockOutBillDtlBindingSource.DataSource = new List<StockOutBillDtl>();            
            gridView.AddNewRow();
            gridView.FocusedColumn = colGoodsID;
            hd.BillNo = MainForm.GetMaxBillNo(MainMenuEnum.StockOutBillType, true).MaxBillNo;
            headID = Guid.Empty;
            hd.BillDate = DateTime.Today;
            hd.DeliveryDate = DateTime.Today;
            lueType.Focus();
            lueType_EditValueChanged(null, null);
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public void Del()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                System.Windows.Forms.DialogResult result = XtraMessageBox.Show("确定要删除选择的记录吗?", "操作提示",
                System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    if (headID != null && headID !=Guid.Empty)
                    {
                        StockOutBillHd dCheck = stockOutBillFactory.GetStockOutBill(headID).FirstOrDefault();
                        if (dCheck.Status == (int)BillStatus.UnAudited)
                            stockOutBillFactory.Delete(headID);
                        else
                        {
                            CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "该单据已审核，不允许删除。");
                            return;
                        }

                    }
                    ////DataQueryPageRefresh();
                    //刷新查询界面
                    baseFactory.DataPageRefresh(billType);
                    //MainForm.DataQueryPageRefresh();
                    //DataQueryPage page = ClientFactory.itemDetailList[billType + "Query"] as DataQueryPage;
                    //MainForm.GetDataSource();
                    //page.InitGrid(MainForm.GetData(billType + "Query"));
                    stockOutBillHdBindingSource.DataSource = new StockOutBillHd();
                    stockOutBillDtlBindingSource.DataSource = new List<StockOutBillDtl>();
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

        bool BillValidated(BillStatus status)
        {
            bool flag = true;
            Hashtable hasGoods = new Hashtable();
            StockOutBillHd hd = stockOutBillHdBindingSource.DataSource as StockOutBillHd;
            List<StockOutBillDtl> dtl = stockOutBillDtlBindingSource.DataSource as List<StockOutBillDtl>;
            if (hd == null)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请完整填写表头信息");
                flag = false;
            }
            if (lueType.EditValue == null)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请填写单据类型");
                flag = false;
            }
            if (lueBusinessContact.Enabled == true && string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请填写业务往来信息");
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
                //if (dtl != null && dtl.Any(o => o.GoodsID == goods.ID))
                if (dtl[i].Qty == 0)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), colQty.Caption + "不能为0");
                    flag = false;
                    continue;
                }
                Goods goods = baseFactory.GetModelList<Goods>().FirstOrDefault(o => o.ID.Equals(dtl[i].GoodsID));
                //获取或设置客户商品售价
                //if (isSLSalePrice && lueBusinessContact.Enabled == true)
                if (lueBusinessContact.Enabled == true && !string.IsNullOrEmpty(lueBusinessContact.Text.Trim()) && billType != MainMenuEnum.FSMDPReturnBill && billType != MainMenuEnum.FSMDPReturnBill)
                {
                    // SLSalePrice cSLSalePrice = baseFactory.GetModelList<SLSalePrice>().Find(o =>
                    //o.CustomerID == new Guid(lueBusinessContact.EditValue.ToString()) && o.GoodsID == dtl[i].GoodsID);
                    if (billType == MainMenuEnum.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                        businessContactType = (int)BusinessContactType.Customer;
                    else
                        businessContactType = (int)BusinessContactType.Supplier;
                    Func<SLSalePrice, bool> func = o => o.ID == new Guid(lueBusinessContact.EditValue.ToString()) && o.GoodsID == dtl[i].GoodsID && o.Type == businessContactType;
                    SLSalePrice cSLSalePrice = baseFactory.GetModelList<SLSalePrice>().FirstOrDefault(func);
                    if (cSLSalePrice == null)
                    {
                        SLSalePrice obj = new SLSalePrice();
                        obj.ID = new Guid(lueBusinessContact.EditValue.ToString());
                        obj.GoodsID = dtl[i].GoodsID;
                        obj.Type = businessContactType;
                        obj.Price = dtl[i].Price.Value;
                        obj.PriceNoTax = dtl[i].PriceNoTax;
                        obj.Discount = dtl[i].Discount == 0 ? 1 : dtl[i].Discount.Value;
                        obj.OtherFee = dtl[i].OtherFee.Value;
                        baseFactory.Add<SLSalePrice>(obj);
                    }
                    else if (cSLSalePrice.Price != dtl[i].Price || cSLSalePrice.Discount != dtl[i].Discount || cSLSalePrice.OtherFee != dtl[i].OtherFee)
                    {
                        cSLSalePrice.Price = dtl[i].Price.Value;
                        cSLSalePrice.PriceNoTax = dtl[i].PriceNoTax;
                        cSLSalePrice.Discount = dtl[i].Discount == 0 ? 1 : dtl[i].Discount.Value;
                        cSLSalePrice.OtherFee = dtl[i].OtherFee.Value;
                        baseFactory.Update<SLSalePrice>(cSLSalePrice);
                    }
                }
                if (billType != MainMenuEnum.FGStockOutBill)
                {
                    if (goods.NWeight != dtl[i].NWeight)
                    {
                        goods.NWeight = dtl[i].NWeight.Value;
                        baseFactory.Update<Goods>(goods);

                    }
                }
                if (dtl[i].PCS == 0)
                    dtl[i].PCS = 1;
                hd.BillAMT += decimal.Round((goods.Unit == "斤" ? dtl[i].Qty.Value * 500 / (goods.NWeight == 0 ? 1 : goods.NWeight) : dtl[i].Qty.Value) * dtl[i].PCS.Value * dtl[i].Price.Value * dtl[i].Discount.Value + dtl[i].OtherFee.Value, 2);
            }
            hd.UnReceiptedAMT = hd.BillAMT;
            if (dtl == null || dtl.Count == 0)
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
                StockOutBillHd hd = stockOutBillHdBindingSource.DataSource as StockOutBillHd;
                List<StockOutBillDtl>  dtl = stockOutBillDtlBindingSource.DataSource as List<StockOutBillDtl>;
                if (string.IsNullOrEmpty(txtBillNo.Text.Trim()))
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "单据编号不能为空，请点击添加按钮添加单据。");
                    return false;
                }
                if (billType == MainMenuEnum.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                    hd.WarehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseEnum.FG.ToString()).ID;  //成品仓
                else
                    hd.WarehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseEnum.SFG.ToString()).ID;  //半成品
                if (BillValidated(BillStatus.UnAudited) == false)
                    return false;
                hd.Maker = MainForm.usersInfo.ID;
                hd.MakeDate = DateTime.Now;
                hd.Auditor = null;
                hd.AuditDate = null;
                hd.Status = 0;

                //添加
                if (headID == Guid.Empty)
                {
                    hd.ID = Guid.NewGuid();
                    foreach (StockOutBillDtl item in dtl)
                    {
                        item.ID = Guid.NewGuid();
                        item.HdID = hd.ID;
                    }
                    
                }
                stockOutBillFactory.SaveBill(hd, dtl);
                headID = hd.ID;
                //DataQueryPageRefresh();
                if (billType == MainMenuEnum.EMSStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1) ||
                    billType == MainMenuEnum.FSMDPReturnBill)
                {
                    List<VStockOutBillDtlByBOM> vList = baseFactory.GetModelList<VStockOutBillDtlByBOM>().FindAll(o => o.HdID.Equals(hd.ID) && o.Type == (int)BOMType.Assemble);
                    vList.ForEach(item=> {
                        StockOutBillDtl dtl = new StockOutBillDtl();
                        dtl.ID = item.ID;
                        dtl.HdID = item.HdID;
                        dtl.GoodsID = item.GoodsID;
                        dtl.Qty = item.Qty.Value;
                        dtl.PCS = item.PCS;
                        dtl.InnerBox = item.InnerBox;
                        //dtl.NWeight = item.NWeight == 0 ? 1 : item.NWeight;
                        dtl.Price = item.Price;
                        dtl.PriceNoTax = item.PriceNoTax;
                        dtl.Discount = item.Discount;
                        dtl.OtherFee = item.OtherFee;
                        dtlByBOM.Add(dtl);
                    });
                    billDtlByBOMBindingSource.DataSource = dtlByBOM;
                }
                else
                    billDtlByBOMBindingSource.DataSource = dtlByBOM = new List<StockOutBillDtl>();
                //MainForm.BillSaveRefresh(billType + "Query");
                baseFactory.DataPageRefresh(billType);
                CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "保存成功");
                return true;
            }
            catch (Exception ex)
            {
                //if (ex.HResult == -2146232060)  //违反了PRIMARY KEY约束
                //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("单号:{0}已经存在,请重新添加新单。", hd.BillNo));
                //else
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), ex.Message);
                return false;
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        public bool Audit()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                gridView.CloseEditForm();
                if (hd != null)
                {
                    StockOutBillHd stockOut = BLLFty.Create<StockOutBillBLL>().GetStockOutBillHd(hd.ID);
                    if (stockOut != null && stockOut.Status > 1)
                    {
                        CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "已结账单据不能取消审核");
                        return false;
                    }
                    if (MainForm.ISnowSoftVersion != ISnowSoftVersion.Procurement && MainForm.ISnowSoftVersion != ISnowSoftVersion.Sales)
                    {
                        if (stockOut != null && stockOut.Status == 0)
                        {
                            if (BillValidated(BillStatus.Audited) == false)
                                return false;
                        }
                    }
                    hd.Auditor = MainForm.usersInfo.ID;
                    hd.AuditDate = DateTime.Now;
                    hd.Status = 1;

                    List<Inventory> inventorylist = new List<Inventory>();
                    List<AccountBook> accountBooklist = new List<AccountBook>();
                    List<Alert> alertlist = new List<Alert>();
                    List<Alert> dellist = new List<Alert>();
                    //Dictionary<Guid, Decimal> totaiQty = BLLFty.Create<InventoryBLL>().GetGoodsTotalQty(hd.WarehouseID);//商品库存数
                    //成套出库需将成品转为BOM对应的半成品
                    List<StockOutBillDtl> dtlList = null;
                    bool flag = false;
                    if (billType == MainMenuEnum.EMSStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                    {
                        dtlList = dtlByBOM = BLLFty.Create<StockOutBillBLL>().GetVStockOutBillDtlByBOM(hd.ID, (int)BOMType.Assemble);
                    }
                    else
                        dtlList = dtl = BLLFty.Create<StockOutBillBLL>().GetStockOutBillDtl(hd.ID);
                    //删除提醒信息
                    Alert alertBill = baseFactory.GetModelList<Alert>().FirstOrDefault(o => o.BillID == hd.ID);
                    if (alertBill != null)
                        dellist.Add(alertBill);
                    foreach (StockOutBillDtl dtlItem in dtlList)
                    {
                        if (MainForm.ISnowSoftVersion == ISnowSoftVersion.Procurement || MainForm.ISnowSoftVersion == ISnowSoftVersion.Sales)
                            continue;  //不处理库存
                        Goods goods = baseFactory.GetModelList<Goods>().FirstOrDefault(o => o.ID.Equals(dtlItem.GoodsID));
                        //库存数据
                        Inventory ity = new Inventory();
                        ity.ID = Guid.NewGuid();
                        ity.WarehouseID = hd.WarehouseID;
                        ity.WarehouseType = hd.WarehouseType;
                        ity.CompanyID = hd.CompanyID;
                        ity.SupplierID = hd.SupplierID;
                        ity.DeptID = hd.DeptID;
                        ity.GoodsID = dtlItem.GoodsID;
                        ity.Qty = -Math.Abs(dtlItem.Qty.Value);  //出库数量为负数
                        ity.MEAS = dtlItem.MEAS;
                        ity.PCS = dtlItem.PCS.Value;
                        ity.InnerBox = dtlItem.InnerBox == null ? 0 : dtlItem.InnerBox.Value;
                        ity.NWeight = dtlItem.NWeight == 0 ? 1 : dtlItem.NWeight.Value;
                        ity.Price = dtlItem.Price.Value;
                        ity.Discount = dtlItem.Discount.Value;
                        ity.OtherFee = dtlItem.OtherFee.Value;
                        ity.EntryDate = DateTime.Now;
                        ity.BillNo = hd.BillNo;
                        ity.BillDate = hd.BillDate;
                        inventorylist.Add(ity);
                        //账页数据
                        AccountBook ab = new AccountBook();
                        ab.ID = Guid.NewGuid();
                        ab.WarehouseID = hd.WarehouseID;
                        ab.WarehouseType = hd.WarehouseType;
                        ab.GoodsID = dtlItem.GoodsID;
                        ab.AccntDate = DateTime.Now;
                        ab.MEAS = dtlItem.MEAS;
                        ab.PCS = dtlItem.PCS.Value;
                        ab.NWeight = dtlItem.NWeight == 0 ? 1 : dtlItem.NWeight.Value;
                        ab.Price = dtlItem.Price.Value;
                        ab.Discount = dtlItem.Discount.Value;
                        ab.OtherFee = dtlItem.OtherFee.Value;
                        ab.OutQty = Math.Abs(ity.Qty);
                        List<Inventory> lst = null;
                        if (billType == MainMenuEnum.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                            lst = BLLFty.Create<InventoryBLL>().GetInventory(hd.WarehouseID, dtlItem.GoodsID, dtlItem.PCS.Value);
                        else
                            lst = BLLFty.Create<InventoryBLL>().GetInventory(hd.WarehouseID, dtlItem.GoodsID);
                        if (lst!=null  && lst.Count > 0)
                        {
                            decimal totalAMT = lst.Sum(o => o.Qty * o.Price * o.Discount + o.OtherFee);
                            ab.BalanceQty = lst.Sum(o => o.Qty) - ab.OutQty;
                            ab.BalanceCost = totalAMT - (ab.OutQty * dtlItem.Price.Value * dtlItem.Discount.Value + dtlItem.OtherFee.Value);
                        }
                        else
                        {
                            ab.BalanceQty = -ab.OutQty;
                            ab.BalanceCost = -(ab.OutQty * dtlItem.Price.Value * dtlItem.Discount.Value + dtlItem.OtherFee.Value);
                        }
                        ab.BillNo = hd.BillNo;
                        ab.BillDate = hd.BillDate;
                        accountBooklist.Add(ab);

                        if (stockOut != null && stockOut.Status == 0)
                        {
                            if (ab.BalanceQty < 0)
                            {
                                //CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("货品[{0}]出库数量大于现库存数量，不允许出库！", goods.Code));
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("货品[{0}]出库数量大于现库存数量，是否继续出库？", goods.Code), "操作提示",
                                System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.Yes)
                                    flag = false;
                                else
                                    flag = true;
                            }
                            if (flag == false)
                            {
                                //添加提醒信息
                                decimal total = 0;
                                if (lst.Count > 0)
                                    total = lst.Sum(o => o.Qty) - Math.Abs(dtlItem.Qty.Value);
                                else
                                    total = -Math.Abs(dtlItem.Qty.Value);
                                Alert alert = baseFactory.GetModelList<Alert>().FirstOrDefault(o => o.GoodsID == dtlItem.GoodsID);
                                if (alert != null)
                                    dellist.Add(alert);
                                if (goods != null && total < goods.LowerLimit)
                                {
                                    Alert obj = new Alert();
                                    obj.ID = Guid.NewGuid();
                                    obj.GoodsID = dtlItem.GoodsID;
                                    obj.Caption = "库存不足";
                                    obj.Text = string.Format("货品[{0}]库存数量为:[{1}].已低于库存下限，请及时补货。", goods.Code, total);
                                    obj.AddTime = DateTime.Now;
                                    alertlist.Add(obj);

                                    MainForm.alertControl.Show(this.FindForm(), obj.Caption, obj.Text, global::USL.Properties.Resources.Alarm_Clock);
                                }
                            }
                        }
                        //外加工、自动机库存处理
                        if (billType == MainMenuEnum.EMSStockOutBill || billType == MainMenuEnum.FSMStockOutBill ||
                            (billType==MainMenuEnum.GetMaterialBill &&Convert.ToInt32(lueType.EditValue)!=6))
                        {
                            //库存数据
                            ity = new Inventory();
                            ity.ID = Guid.NewGuid();
                            ity.WarehouseID = (billType == MainMenuEnum.EMSStockOutBill || (billType == MainMenuEnum.GetMaterialBill && Convert.ToInt32(lueType.EditValue) == 3))
                                ? warehouseList.FirstOrDefault(o => o.Code == WarehouseEnum.EMS.ToString()).ID : warehouseList.FirstOrDefault(o => o.Code == WarehouseEnum.FSM.ToString()).ID;
                            ity.WarehouseType = hd.WarehouseType;
                            ity.CompanyID = hd.CompanyID;
                            ity.SupplierID = hd.SupplierID;
                            ity.DeptID = hd.DeptID;
                            ity.GoodsID = dtlItem.GoodsID;
                            ity.Qty = Math.Abs(dtlItem.Qty.Value);
                            ity.MEAS = dtlItem.MEAS;
                            ity.PCS = dtlItem.PCS.Value;
                            ity.InnerBox = dtlItem.InnerBox == null ? 0 : dtlItem.InnerBox.Value;
                            ity.NWeight = dtlItem.NWeight == 0 ? 1 : dtlItem.NWeight.Value;
                            ity.Price = dtlItem.Price.Value;
                            ity.Discount = dtlItem.Discount.Value;
                            ity.OtherFee = dtlItem.OtherFee.Value;
                            ity.EntryDate = DateTime.Now;
                            ity.BillNo = hd.BillNo;
                            ity.BillDate = hd.BillDate;
                            inventorylist.Add(ity);
                            //账页数据
                            ab = new AccountBook();
                            ab.ID = Guid.NewGuid();
                            ab.WarehouseID = ity.WarehouseID;
                            ab.WarehouseType = hd.WarehouseType;
                            ab.GoodsID = dtlItem.GoodsID;
                            ab.AccntDate = DateTime.Now;
                            ab.MEAS = dtlItem.MEAS;
                            ab.PCS = dtlItem.PCS.Value;
                            ab.NWeight = dtlItem.NWeight == 0 ? 1 : dtlItem.NWeight.Value;
                            ab.Price = dtlItem.Price.Value;
                            ab.Discount = dtlItem.Discount.Value;
                            ab.OtherFee = dtlItem.OtherFee.Value;
                            ab.OutQty = ity.Qty;
                            //List<Inventory> lst = BLLFty.Create<InventoryBLL>().GetInventory(hd.WarehouseID, dtlItem.GoodsID, dtlItem.PCS);
                            if (lst.Count > 0)
                            {
                                decimal totalAMT = lst.Sum(o => o.Qty * o.Price * o.Discount + o.OtherFee);
                                ab.BalanceQty = lst.Sum(o => o.Qty) + ab.OutQty;
                                ab.BalanceCost = totalAMT + (ab.OutQty * dtlItem.Price.Value * dtlItem.Discount.Value + dtlItem.OtherFee.Value);
                            }
                            else
                            {
                                ab.BalanceQty = ab.OutQty;
                                ab.BalanceCost = ab.OutQty * dtlItem.Price.Value * dtlItem.Discount.Value + dtlItem.OtherFee.Value;
                            }
                            ab.BillNo = hd.BillNo;
                            ab.BillDate = hd.BillDate;
                            accountBooklist.Add(ab);
                        }
                    }
                    //自动机残次材料退货，增加自动机厂家残次材料对应原料库存
                    if (billType == MainMenuEnum.FSMDPReturnBill)
                    {
                        foreach (StockOutBillDtl dbItem in dtlByBOM)
                        {
                            //库存数据
                            Inventory ity = new Inventory();
                            ity.ID = Guid.NewGuid();
                            ity.WarehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseEnum.FSM.ToString()).ID;
                            ity.WarehouseType = hd.WarehouseType;
                            ity.CompanyID = hd.CompanyID;
                            ity.SupplierID = hd.SupplierID;
                            ity.DeptID = hd.DeptID;
                            ity.GoodsID = dbItem.GoodsID;
                            ity.Qty = Math.Abs(dbItem.Qty.Value);
                            ity.MEAS = dbItem.MEAS;
                            ity.PCS = dbItem.PCS.Value;
                            ity.InnerBox = dbItem.InnerBox == null ? 0 : dbItem.InnerBox.Value;
                            ity.NWeight = dbItem.NWeight == 0 ? 1 : dbItem.NWeight.Value;
                            ity.Price = dbItem.Price.Value;
                            ity.Discount = dbItem.Discount.Value;
                            ity.OtherFee = dbItem.OtherFee.Value;
                            ity.EntryDate = DateTime.Now;
                            ity.BillNo = hd.BillNo;
                            ity.BillDate = hd.BillDate;
                            inventorylist.Add(ity);
                            //账页数据
                            AccountBook ab = new AccountBook();
                            ab.ID = Guid.NewGuid();
                            ab.WarehouseID = ity.WarehouseID;
                            ab.WarehouseType = hd.WarehouseType;
                            ab.GoodsID = dbItem.GoodsID;
                            ab.AccntDate = DateTime.Now;
                            ab.MEAS = dbItem.MEAS;
                            ab.PCS = dbItem.PCS.Value;
                            ab.NWeight = dbItem.NWeight == 0 ? 1 : dbItem.NWeight.Value;
                            ab.Price = dbItem.Price.Value;
                            ab.Discount = dbItem.Discount.Value;
                            ab.OtherFee = dbItem.OtherFee.Value;
                            ab.InQty = ity.Qty;
                            List<Inventory> lst = BLLFty.Create<InventoryBLL>().GetInventory(hd.WarehouseID, dbItem.GoodsID, dbItem.PCS.Value);
                            if (lst.Count > 0)
                            {
                                decimal totalAMT = lst.Sum(o => o.Qty * o.Price * o.Discount + o.OtherFee);
                                ab.BalanceQty = lst.Sum(o => o.Qty) + ab.OutQty;
                                ab.BalanceCost = totalAMT + (ab.OutQty * dbItem.Price.Value * dbItem.Discount.Value + dbItem.OtherFee.Value);
                            }
                            else
                            {
                                ab.BalanceQty = ab.OutQty;
                                ab.BalanceCost = ab.OutQty * dbItem.Price.Value * dbItem.Discount.Value + dbItem.OtherFee.Value;
                            }
                            ab.BillNo = hd.BillNo;
                            ab.BillDate = hd.BillDate;
                            accountBooklist.Add(ab);
                        }
                    }
                    if (flag)
                        return false;

                    if (stockOut != null && stockOut.Status == 1)
                    {
                        hd.Auditor = MainForm.usersInfo.ID;
                        hd.AuditDate = DateTime.Now;
                        hd.Status = 0;
                        BLLFty.Create<InventoryBLL>().CancelAudit(hd, inventorylist, accountBooklist);
                        CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "取消审核成功");
                        return true;
                    }
                    else
                    {
                        BLLFty.Create<InventoryBLL>().Insert(hd, dtl, inventorylist, accountBooklist, dellist, alertlist);
                        MainForm.SetAlertCount();
                        CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "审核成功");
                        return true;
                    }
                }
                else
                {
                    //DataQueryPageRefresh();
                    CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "没有可审核的单据");
                    return false;
                }
            }
            catch (Exception ex)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), ex.Message);
                return false;
            }
            finally
            {
                //MainForm.BillSaveRefresh(billType + "Query");
                //MainForm.InventoryRefresh();
                baseFactory.DataPageRefresh(billType);
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        public void Print()
        {

            if (dtl == null)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "没有可打印的数据");
                return;
            }
            DevExpress.XtraGrid.GridControl printControl = gridControl;
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
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
                            break;
                        case BOMType.Assemble:
                            printControl = gcBOM;
                            break;
                        default:
                            break;
                    }
                    gcBOM.DataSource = dtlByBOM;
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in ((GridView)gcBOM.MainView).Columns)
                    {
                        col.BestFit();
                    }
                }
                if (printControl == null)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "没有可打印的数据");
                    return;
                }
                if (billType == MainMenuEnum.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                {
                    //隐藏部分列
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in ((GridView)printControl.MainView).Columns)
                    {
                        if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                        {
                            if (col == colPackaging || col == colInnerBox || col == colOtherFee)
                                col.Visible = false;
                        }
                        else
                        {
                            if (col == colPackaging || col == colInnerBox || col == colOtherFee || col == colRemark)
                                col.Visible = false;
                        }
                        //if (MainForm.Company.Contains("谷铭达") && (col == colPrice || col == colAMT))
                        //    col.Visible = false;
                        if (MainForm.Company.Contains("纸"))
                        {
                            if (col == colGoodsID)
                                col.Visible = false;
                            if (col == colPrice || col == colAMT)
                                col.Visible = true;
                        }
                    }
                }
                ((GridView)printControl.MainView).BestFitColumns();
                PrintSettingController psc = new PrintSettingController(printControl);

                //页眉 
                if (hd != null)
                {
                    psc.PrintCompany = MainForm.Company;
                //List<TypesList> types = baseFactory.GetModelList<TypesList>();
                    string customerAddress = string.Empty;
                    string logisticsAddress = string.Empty;
                    string logisticsTel = string.Empty;
                    Company customer = baseFactory.GetModelList<Company>().FirstOrDefault(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString()));
                    if (customer != null)
                    {
                        customerAddress = customer.Address;
                        logisticsAddress = customer.LogisticsAddress;
                        logisticsTel = customer.LogisticsTel;
                    }
                    //if (billType == MainMenuEnum.GetMaterialBill)
                        psc.PrintHeader = EnumHelper.GetDescription<StockOutBillTypeEnum>((StockOutBillTypeEnum)hd.Type, false) + "单";// types.Find(o => o.Type == MainMenuEnum.StockOutBillType.ToString() && o.No == hd.Type).Name + "单";
                    //else
                    //    psc.PrintHeader = types.Find(o => o.SubType == billType.ToString() && o.No == hd.Type).Name + "单";
                    psc.PrintSubTitle = MainForm.Contacts.Replace("\\r\\n", "\r\n");
                    if (billType == MainMenuEnum.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                    {
                        psc.PrintLeftHeader = "客户名称：" + lueBusinessContact.Text + "\r\n"
                            + "联系人：" + txtContacts.EditValue + "\r\n"
                        + "客户地址：" + customerAddress + "\r\n"
                        + "物流地址：" + logisticsAddress;
                        psc.PrintRightHeader = "单据编号：" + hd.BillNo + "\r\n"+
                            "出库日期：" + deBillDate.Text + "\r\n"
                            + "交货日期：" + deDeliveryDate.Text + "\r\n"
                            + "物流电话：" + logisticsTel;
                    }
                    else
                    {
                        psc.PrintLeftHeader = "单据编号：" + hd.BillNo + "\r\n"
                        + "业务往来：" + lueBusinessContact.Text + "\r\n"
                        + "联系地址：" + customerAddress;
                        psc.PrintRightHeader = "出库日期：" + deBillDate.Text + "\r\n"
                            + "交货日期：" + deDeliveryDate.Text + "\r\n"
                            + "联系人：" + txtContacts.EditValue;
                    }
                    //if (!string.IsNullOrEmpty(meRemark.Text))
                    //    psc.PrintRightHeader = "备注：" + meRemark.Text;

                    //页脚 
                    //psc.PrintLeftFooter = "制单人：" + lueMaker.Text + "  制单日期：" + deMakeDate.Text;
                    //psc.PrintFooter = "审核人：" + lueAuditor.Text + "  审核日期：" + deAuditDate.Text;
                    psc.PrintLeftFooter = "送货单位(盖章):";
                    psc.PrintFooter = "收货单位(盖章):";
                    psc.PrintRightFooter = "制单人：" + lueMaker.Text;

                    //金额转大写
                    //gridView.Columns["colName"].Summary.Clear();
                    //gridView.Columns["colName"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    //    new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "金额", "金额:"+Rexlib.MoneyToUpper(hd.BillAMT.Value))});
                }
                //横纵向 
                //psc.LandScape = this.rbtnHorizon.Checked;
                psc.LandScape = MainForm.IsLandScape;

                //纸型 
                psc.PaperKind = MainForm.PrintPaperKind;
                psc.PaperSize = MainForm.PaperSize;
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
                if (billType == MainMenuEnum.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                {
                    //还原隐藏列
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in ((GridView)printControl.MainView).Columns)
                    {
                        if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                        {
                            if (col == colPackaging || col == colInnerBox || col == colOtherFee)
                                col.Visible = true;
                        }
                        else
                        {
                            if (col == colPackaging || col == colInnerBox || col == colOtherFee || col == colRemark)
                                col.Visible = true;
                        }
                        //if (MainForm.Company.Contains("谷铭达") && (col == colPrice || col == colAMT))
                        //    col.Visible = true;
                        if (MainForm.Company.Contains("纸"))
                        {
                            if (col == colGoodsID)
                                col.Visible = true;
                        }
                    }
                    //控制栏位顺序
                    int i = 0;
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in ((GridView)printControl.MainView).Columns)
                    {
                        if (col.Visible)
                            col.VisibleIndex = i++;
                    }
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
                List<SLSalePrice> slSalePriceList = BLLFty.Create<SLSalePriceBLL>().GetSLSalePrice(new Guid(lueBusinessContact.EditValue.ToString()));
                //gridControl.BeginUpdate();
                if ((billType == MainMenuEnum.EMSStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1)) && MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)//成套领料
                {
                    VGoodsByBOM goodsByBOM = ((LookUpEdit)sender).GetSelectedDataRow() as VGoodsByBOM;
                    if (goodsByBOM != null)
                    {
                        //if (dtl != null && dtl.Any(o => o.GoodsID == goodsByBOM.ID))
                        //{
                        //    //gridView.SetRowCellValue(gridView.FocusedRowHandle, colGoodsID, null);
                        //    gridView.DeleteSelectedRows();
                        //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "不能重复选择货品。");
                        //    return;

                        //}
                        //gridView.SetRowCellValue(gridView.FocusedRowHandle, colGoodsID, goodsByBOM.ID);
                        //gridView.SetRowCellValue(gridView.FocusedRowHandle, colPCS, goodsByBOM.装箱数);
                        //gridView.SetRowCellValue(gridView.FocusedRowHandle, colInnerBox, goodsByBOM.内盒);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colPrice, goodsByBOM.单价);
                        //gridView.SetRowCellValue(gridView.FocusedRowHandle, colPriceNoTax, goodsByBOM.去税单价);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colDiscount, 1);
                    }
                }
                else if ((billType == MainMenuEnum.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1)) 
                    || (MainForm.SysInfo.CompanyType == (int)CompanyType.Trade && (billType == MainMenuEnum.EMSStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))))
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
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colNWeight, goods.净重 == 0 ? 1 : goods.净重);
                        //gridView.SetRowCellValue(gridView.FocusedRowHandle, colCavityNumber, goods.一出几 == 0 ? 1 : goods.一出几);
                        //if (billType == TypesListConstants.FGStockOutBill && lueType.ItemIndex == 1)//样品发放
                        //{
                        //    gridView.SetRowCellValue(gridView.FocusedRowHandle, colPrice, 0);
                        //    gridView.SetRowCellValue(gridView.FocusedRowHandle, colPriceNoTax, 0);
                        //}
                        //else
                        //{
                        //客户设置固定售价
                        Decimal price = goods.单价;
                        Decimal disCount = 1;
                        Decimal otherFee = 0;
                        //if (baseFactory.GetModelList<Company>().Exists(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == (int)CustomerType.DomesticSales))
                        if (baseFactory.GetModelList<Company>().Exists(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString())))
                        {
                            //获取或设置客户商品售价
                            SLSalePrice cSLSalePrice = baseFactory.GetModelList<SLSalePrice>().FirstOrDefault(o =>
                               o.ID == new Guid(lueBusinessContact.EditValue.ToString()) && o.GoodsID == goods.ID && o.Type == businessContactType);
                            //SLSalePrice cSLSalePrice = slSalePriceList.FirstOrDefault(o =>
                            //  o.GoodsID == goods.ID && o.Type == businessContactType);
                            //if (cSLSalePrice == null)
                            //    isSLSalePrice = true;
                            //else
                            if (cSLSalePrice != null)
                            {
                                price = cSLSalePrice.Price;
                                disCount = cSLSalePrice.Discount;
                                otherFee = cSLSalePrice.OtherFee;
                            }
                        }
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colPrice, price);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colDiscount, disCount);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colOtherFee, otherFee);
                        //}
                    }
                }
                else
                {
                    VMaterial goods = ((LookUpEdit)sender).GetSelectedDataRow() as VMaterial;
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
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colPCS, goods.PCS);
                        //gridView.SetRowCellValue(gridView.FocusedRowHandle, colInnerBox, goods.内盒);
                        //gridView.SetRowCellValue(gridView.FocusedRowHandle, colPrice, goods.单价);
                        //gridView.SetRowCellValue(gridView.FocusedRowHandle, colPriceNoTax, goods.去税单价);
                        //gridView.SetRowCellValue(gridView.FocusedRowHandle, colDiscount, 1);
                        //供应商设置固定价格
                        Decimal price = goods.单价;
                        Decimal disCount = 1;
                        Decimal otherFee = 0;
                        //if (baseFactory.GetModelList<Supplier>().Exists(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == (int)SupplierTypeEnum.Purchase))
                        if (baseFactory.GetModelList<Supplier>().Exists(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString())))
                        {
                            //获取或设置价格
                            SLSalePrice cSLSalePrice = slSalePriceList.FirstOrDefault(o => o.GoodsID == goods.ID && o.Type == businessContactType);
                            //if (cSLSalePrice == null)
                            //    isSLSalePrice = true;
                            //else
                            if (cSLSalePrice != null)
                            {
                                price = cSLSalePrice.Price;
                                disCount = cSLSalePrice.Discount;
                                otherFee = cSLSalePrice.OtherFee;
                            }
                        }
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colPrice, price);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colDiscount, disCount);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colOtherFee, otherFee);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colNWeight, goods.净重 == 0 ? 1 : goods.净重);
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

        private void lueBusinessContact_EditValueChanged(object sender, EventArgs e)
        {
            if (billType == MainMenuEnum.FGStockOutBill)
            {
                VCompany company = ((LookUpEdit)sender).GetSelectedDataRow() as VCompany;
                if (company != null && hd != null)
                {
                    hd.CompanyID = company.ID;
                    hd.Contacts = company.联系人;
                    if (headID == Guid.Empty)
                        hd.WarehouseType = company.客户类型;
                    if ((lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                        orderHdBindingSource.DataSource = BLLFty.Create<OrderBLL>().GetOrderHd().FindAll(o => o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Status == 1);
                }
            }
            else if (billType == MainMenuEnum.GetMaterialBill && Convert.ToInt32(lueType.EditValue) == 6)
            {
                VDepartment dept = ((LookUpEdit)sender).GetSelectedDataRow() as VDepartment;
                if (dept != null && hd != null)
                {
                    hd.DeptID = dept.ID;
                    hd.Contacts = dept.联系人;
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

        private void lueType_EditValueChanged(object sender, EventArgs e)
        {
            businessContactBindingSource.DataSource = null;
            vGoodsBindingSource.DataSource = null;
            lueBusinessContact.EditValue = null;
            txtContacts.EditValue = null;
            lueWarehouseType.EditValue = null;
            this.lueBusinessContact.DataBindings.Clear();
            lueWarehouseType.Enabled = false;
            lueOrderNo.Enabled = false;
            switch (billType)
            {
                case MainMenuEnum.FGStockOutBill:
                    this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockOutBillHdBindingSource, "CompanyID", true));
                    businessContactBindingSource.DataSource = baseFactory.GetModelList<VCompany>();
                    if ((lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                    {
                        vGoodsBindingSource.DataSource = baseFactory.GetModelList<VGoods>();
                        if (!string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))
                            orderHdBindingSource.DataSource = BLLFty.Create<OrderBLL>().GetOrderHd().FindAll(o => o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Status == 1);
                        SetDtlHeader(true);
                        lueWarehouseType.Enabled = true;
                        lueOrderNo.Enabled = true;
                    }
                    else
                    {
                        vGoodsBindingSource.DataSource = baseFactory.GetModelList<VMaterial>().FindAll(o => o.Type == 1);
                        SetDtlHeader(false);
                    }
                    break;
                case MainMenuEnum.EMSStockOutBill:
                    this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockOutBillHdBindingSource, "SupplierID", true));
                    businessContactBindingSource.DataSource = baseFactory.GetModelList<VSupplier>().FindAll(o => o.供应商类型 == (int)SupplierTypeEnum.EMS);
                    //成套领料货品明细控制
                    stockOutBillDtlBindingSource.DataSource = dtl = new List<StockOutBillDtl>();
                    billDtlByBOMBindingSource.DataSource = dtlByBOM = new List<StockOutBillDtl>();
                    gridView.AddNewRow();
                    if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                    {
                        if ((lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                        {
                            if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                                vGoodsBindingSource.DataSource = baseFactory.GetModelList<VGoodsByBOM>().FindAll(o => o.类型 == (int)BOMType.BOM);
                            else
                                vGoodsBindingSource.DataSource = baseFactory.GetModelList<VGoods>();
                        }
                        else if (lueType.ItemIndex == 1)
                        {
                            if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                                vGoodsBindingSource.DataSource = baseFactory.GetModelList<VGoodsByBOM>().FindAll(o => o.类型 == (int)BOMType.Assemble);
                            else
                                vGoodsBindingSource.DataSource = baseFactory.GetModelList<VGoodsByBOM>().FindAll(o => o.类型 == (int)BOMType.Assemble || o.类型 == (int)BOMType.BOM);
                        }
                    }
                    else
                        vGoodsBindingSource.DataSource = baseFactory.GetModelList<VGoodsByBOM>().FindAll(o => o.类型 == (int)BOMType.Assemble || o.类型 == (int)BOMType.BOM);
                    break;
                case MainMenuEnum.SFGStockOutBill:
                case MainMenuEnum.FSMStockOutBill:
                case MainMenuEnum.GetMaterialBill:
                case MainMenuEnum.FSMDPReturnBill:
                case MainMenuEnum.EMSDPReturnBill:
                    if (billType == MainMenuEnum.GetMaterialBill)
                    {
                        switch (Convert.ToInt32(lueType.EditValue))
                        {
                            case 3:
                                this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockOutBillHdBindingSource, "SupplierID", true));
                        businessContactBindingSource.DataSource = baseFactory.GetModelList<VSupplier>().FindAll(o =>
                            o.供应商类型 == (billType == MainMenuEnum.SFGStockOutBill ? (int)SupplierTypeEnum.Purchase : (int)SupplierTypeEnum.EMS));
                                break;
                            case 5:
                                this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockOutBillHdBindingSource, "SupplierID", true));
                        businessContactBindingSource.DataSource = baseFactory.GetModelList<VSupplier>().FindAll(o =>
                            o.供应商类型 == (billType == MainMenuEnum.SFGStockOutBill ? (int)SupplierTypeEnum.Purchase : (int)SupplierTypeEnum.FSM));
                                break;
                            case 6:
                                this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockOutBillHdBindingSource, "DeptID", true));
                                businessContactBindingSource.DataSource = baseFactory.GetModelList<VDepartment>();
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        SupplierTypeEnum sType = SupplierTypeEnum.Purchase;
                        if (billType == MainMenuEnum.SFGStockInBill)
                            sType = SupplierTypeEnum.Purchase;
                        else if (billType == MainMenuEnum.FSMDPReturnBill)
                            sType = SupplierTypeEnum.FSM;
                        else if (billType == MainMenuEnum.EMSDPReturnBill)
                            sType = SupplierTypeEnum.EMS;
                        this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockOutBillHdBindingSource, "SupplierID", true));
                        businessContactBindingSource.DataSource = baseFactory.GetModelList<VSupplier>().FindAll(o =>
                            o.供应商类型 == (int)sType);
                    }
                    List<VMaterial> vMaterialList = baseFactory.GetModelList<VMaterial>();
                    if (billType == MainMenuEnum.FSMStockOutBill)
                        vGoodsBindingSource.DataSource = vMaterialList.FindAll(o => o.Type == (int)GoodsBigTypeEnum.Material || o.Type == (int)GoodsBigTypeEnum.Basket);
                    else if (billType == MainMenuEnum.SFGStockOutBill)
                        vGoodsBindingSource.DataSource = vMaterialList.FindAll(o => o.Type >0);
                    else if (billType == MainMenuEnum.FSMDPReturnBill || billType == MainMenuEnum.EMSDPReturnBill)
                        vGoodsBindingSource.DataSource = vMaterialList.FindAll(o => o.Type == (int)GoodsBigTypeEnum.Stuff || o.Type == (int)GoodsBigTypeEnum.Basket);
                    else if (billType == MainMenuEnum.GetMaterialBill)
                    {
                        switch (Convert.ToInt32(lueType.EditValue))
                        {
                            case 3:
                                if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                                    vGoodsBindingSource.DataSource = vMaterialList.FindAll(o => o.Type == (int)GoodsBigTypeEnum.Stuff || o.Type == (int)GoodsBigTypeEnum.Basket);
                                else
                                    vGoodsBindingSource.DataSource = vMaterialList.FindAll(o => o.Type > (int)GoodsBigTypeEnum.Goods);
                                break;
                            case 5:
                                vGoodsBindingSource.DataSource = vMaterialList.FindAll(o => o.Type == (int)GoodsBigTypeEnum.Material || o.Type == (int)GoodsBigTypeEnum.Basket);
                                break;
                            case 6:
                                vGoodsBindingSource.DataSource = vMaterialList.FindAll(o => o.Type == (int)GoodsBigTypeEnum.SFGoods || o.Type == (int)GoodsBigTypeEnum.Stuff || o.Type == (int)GoodsBigTypeEnum.Mold);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
            }
        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            List<StockOutBillDtl> list = ((BindingSource)view.DataSource).DataSource as List<StockOutBillDtl>;
            if (e.IsGetData && list != null && list.Count >0)
            {
                //if (billType == MainMenuEnum.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                //{
                //    VStockOutBill goods = baseFactory.GetModelList<VStockOutBill>().Find(o => o.GoodsID == list[e.ListSourceRowIndex].GoodsID && o.装箱数 == list[e.ListSourceRowIndex].PCS);
                //    if (goods != null)
                //    {
                //        if (e.Column == colName)
                //            e.Value = goods.品名;
                //        if (e.Column == colPackaging && !string.IsNullOrEmpty(goods.包装方式))
                //            e.Value = baseFactory.GetModelList<Packaging>().Find(o => o.Name == goods.包装方式).Name;
                //        if (e.Column == colSPEC)
                //            e.Value = goods.规格;
                //        if (e.Column == colUnit)
                //            e.Value = goods.单位;
                //        if (e.Column == colRemark)
                //            e.Value = goods.备注;
                //        if (e.Column == colOrderQty && !string.IsNullOrEmpty(lueOrderNo.Text.Trim()) && new Guid(lueOrderNo.EditValue.ToString()) != Guid.Empty)
                //        {
                //            VOrder order = ((List<VOrder>)baseFactory.GetModelList<VOrder>().FirstOrDefault(o => o.HdID == new Guid(lueOrderNo.EditValue.ToString()) && o.货号 == goods.货号 && o.装箱数 == goods.装箱数);
                //            if (order != null)
                //                e.Value = order.箱数 - baseFactory.GetModelList<VStockOutBill>().Where(o => o.订单编号 == lueOrderNo.Text.Trim() && o.状态 > 0 && o.货号 == goods.货号 && o.装箱数 == goods.装箱数).Sum(o => o.箱数);
                //        }
                //    }
                //}
                //else
                //{
                    Goods goods = baseFactory.GetModelList<Goods>().Find(o => o.ID == list[e.ListSourceRowIndex].GoodsID);
                    if (goods != null)
                    {
                        if (e.Column == colName)
                            e.Value = goods.Name;
                    if (e.Column == colPackaging && goods.PackagingID != null && goods.PackagingID != Guid.Empty)
                            e.Value = baseFactory.GetModelList<Packaging>().Find(o => o.ID == goods.PackagingID).Name;
                        if (e.Column == colSPEC)
                            e.Value = goods.SPEC;
                    if (e.Column == colVolume)
                        e.Value = goods.Volume;
                    //if (e.Column == colNWeight)
                    //    e.Value = goods.NWeight == 0 ? 1 : goods.NWeight;
                    if (e.Column == colUnit)
                            e.Value = goods.Unit;
                        if (e.Column == colRemark)
                            e.Value = goods.Remark;
                        if (e.Column == colGoodsBigType)
                            e.Value = goods.Type;
                        if (e.Column == colBillType)
                            e.Value = billType;
                    }
                //}
            }
        }

        private void gvBOM_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            List<StockOutBillDtl> list = ((BindingSource)view.DataSource).DataSource as List<StockOutBillDtl>;
            if (e.IsGetData && list != null && list.Count >0)
            {
                Goods goods = baseFactory.GetModelList<Goods>().Find(o => o.ID == list[e.ListSourceRowIndex].GoodsID);
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
            bomType = (BOMType)data;
            Print();
        }

        public object ReceiveData()
        {
            throw new NotImplementedException();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBillNo.Text.Trim()) && lueType.EditValue != null)
            {
                List<StockOutBillHd> bills = baseFactory.GetModelList<StockOutBillHd>().FindAll(o => o.Type == (int)lueType.EditValue).OrderBy(o => o.BillNo).ToList();
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
            if (!string.IsNullOrEmpty(txtBillNo.Text.Trim()) && lueType.EditValue != null)
            {
                List<StockOutBillHd> bills = baseFactory.GetModelList<StockOutBillHd>().FindAll(o => o.Type == (int)lueType.EditValue).OrderBy(o => o.BillNo).ToList();
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

        private void gridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            List<StockOutBillDtl> inlist = ((BindingSource)view.DataSource).DataSource as List<StockOutBillDtl>;
            if (inlist != null && inlist.Count > 0)
            {
                //if (view.GetRowCellValue(e.RowHandle, colTonsQty) != null && (decimal)view.GetRowCellValue(e.RowHandle, colTonsQty) != 0)
                if (e.Column == view.FocusedColumn && e.Column == colTonsQty)
                {
                    view.SetRowCellValue(e.RowHandle, colQty, Convert.ToDecimal(e.Value) * 2000 / (decimal)view.GetRowCellValue(e.RowHandle, colNWeight));
                }
                //if (view.GetRowCellValue(e.RowHandle, colQty) != null && (decimal)view.GetRowCellValue(e.RowHandle, colQty) != 0)
                if (e.Column == view.FocusedColumn && e.Column == colQty)
                {
                    view.SetRowCellValue(e.RowHandle, colTonsQty, Convert.ToDecimal(e.Value) * (decimal)view.GetRowCellValue(e.RowHandle, colNWeight) / 2000);
                }
                //if (view.GetRowCellValue(e.RowHandle, colTonsPrice) != null && (decimal)view.GetRowCellValue(e.RowHandle, colTonsPrice) != 0)
                if (e.Column == view.FocusedColumn && e.Column == colTonsPrice)
                {
                    view.SetRowCellValue(e.RowHandle, colPrice, Convert.ToDecimal(e.Value) / 2000 * (decimal)view.GetRowCellValue(e.RowHandle, colNWeight));
                }
                //if (view.GetRowCellValue(e.RowHandle, colPrice) != null && (decimal)view.GetRowCellValue(e.RowHandle, colPrice) != 0)
                if (e.Column == view.FocusedColumn && e.Column == colPrice)
                {
                    view.SetRowCellValue(e.RowHandle, colTonsPrice, Convert.ToDecimal(e.Value) / (decimal)view.GetRowCellValue(e.RowHandle, colNWeight) * 2000);
                }
            }
        }
    }
}
