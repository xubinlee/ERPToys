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
using DBML;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using Factory;
using BLL;
using Utility;
using DevExpress.XtraBars.Docking2010.Views;
using System.Collections;
using IBase;
using CommonLibrary;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Utility.Interceptor;

namespace USL
{
    public partial class StockInBillPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail, IExtensions
    {
        private static ClientFactory clientFactory = LoggerInterceptor.CreateProxy<ClientFactory>();
        StockInBillHd hd;
        List<StockInBillDtl> dtl;
        List<Warehouse> warehouseList;
        Guid headID;
        String billType;
        //bool isSLSalePrice = false;
        PageGroup pageGroupCore;
        GoodsBigType goodsBigType = GoodsBigType.Goods;
        int businessContactType = 0;

        public StockInBillHd Hd
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

        public StockInBillPage(Guid hdID, PageGroup child, String type)
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
            pageGroupCore = child;
            billType = type;
            BindData(headID);

            if (type == MainMenuConstants.ProductionStockInBill || type == MainMenuConstants.SalesReturnBill)
            {
                SetDtlHeader(true);
                businessContactType = (int)BusinessContactType.Customer;
            }
            else if (MainForm.SysInfo.CompanyType == (int)CompanyType.Trade && type == MainMenuConstants.FGStockInBill)
            {
                SetDtlHeader(true);
                businessContactType = (int)BusinessContactType.Supplier;
            }
            else
            {
                SetDtlHeader(false);
                businessContactType = (int)BusinessContactType.Supplier;
            }
        }

        void SetDtlHeader(bool flag)
        {
            if (flag)
            {
                if (billType == MainMenuConstants.SalesReturnBill)
                {
                    colQty.Caption = "数量";
                    colPackaging.Visible = false;
                    colPCS.Visible = false;
                    colInnerBox.Visible = false;
                    colTotalQty.Visible = false;
                    colModulus.Visible = false;
                    colCounts.Visible = false;
                }
                else if (MainForm.SysInfo.CompanyType == (int)CompanyType.Trade && billType == MainMenuConstants.FGStockInBill)
                {
                    colCavityNumber.Visible = false;
                    colModulus.Visible = false;
                    colQty.Caption = "箱数";
                }
                else
                    colQty.Caption = "箱数";
            }
            else
            {
                if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory && (billType == MainMenuConstants.FSMStockInBill || billType == MainMenuConstants.EMSReturnBill || billType == MainMenuConstants.FGStockInBill
                    || (billType == MainMenuConstants.ReturnedMaterialBill && lueType.EditValue != null && Convert.ToInt32(lueType.EditValue) == 4)))
                {
                    colQty.Caption = "重量";
                    colModulus.Visible = true;
                    colCounts.Visible = true;
                }
                else
                {
                    colQty.Caption = "数量";
                    colModulus.Visible = false;
                    colCounts.Visible = false;
                }
            }
            colMEAS.Visible = flag;
            colSPEC.Visible = !flag;
            if (billType != MainMenuConstants.SalesReturnBill)
            {
                colPackaging.Visible = flag;
                colPCS.Visible = flag;
                colInnerBox.Visible = flag;
                colTotalQty.Visible = flag;
            }
            colNWeight.Visible = !flag;
            colCavityNumber.Visible = !flag;
            colUnit.Visible = !flag;
            if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory && billType == MainMenuConstants.SFGStockInBill)
            {
                colTonsQty.Visible = true;
                colTonsPrice.Visible = true;
            }
            else
            {
                colTonsQty.Visible = false;
                colTonsPrice.Visible = false;
            }
            if ((MainForm.Company.Contains("大正") || MainForm.Company.Contains("纸")))
                lciWarehouseType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            if (MainForm.Company.Contains("纸"))
            {
                colCavityNumber.Visible = false;
                colMEAS.Visible = false;
            }
        }

        public void BindData(object hdID)
        {
            switch (billType)
            {
                case MainMenuConstants.ProductionStockInBill:
                case MainMenuConstants.SalesReturnBill:
                    goodsBigType = GoodsBigType.Goods;
                    break;
                case MainMenuConstants.FGStockInBill:
                    goodsBigType = GoodsBigType.Stuff;
                    break;
                case MainMenuConstants.AssembleStockInBill:
                    goodsBigType = GoodsBigType.SFGoods;
                    break;
                case MainMenuConstants.EMSReturnBill:
                case MainMenuConstants.FSMStockInBill:
                    goodsBigType = GoodsBigType.Stuff;
                    break;
                //case TypesListConstants.SFGStockInBill:
                //    break;
                case MainMenuConstants.FSMReturnBill:
                    goodsBigType = GoodsBigType.Material;
                    break;
            }
            if (billType == MainMenuConstants.SFGStockInBill)
                goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type > (int)GoodsBigType.Goods);
            else if (billType == MainMenuConstants.ReturnedMaterialBill)
            {
                switch (Convert.ToInt32(lueType.EditValue))
                {
                    case 4:
                        if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                        goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)GoodsBigType.Stuff);
                        else
                            goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type > (int)GoodsBigType.Goods);
                        break;
                    case 7:
                        goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)GoodsBigType.Material || o.Type == (int)GoodsBigType.Basket);
                        break;
                    case 9:
                        goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)GoodsBigType.SFGoods || o.Type == (int)GoodsBigType.Stuff || o.Type == (int)GoodsBigType.Mold);
                        break;
                    default:
                        break;
                }
            }
            else if (billType == MainMenuConstants.FSMStockInBill || billType == MainMenuConstants.FGStockInBill)
            {
                if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                    goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)goodsBigType || o.Type == (int)GoodsBigType.Basket);
                else
                    goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)GoodsBigType.Goods);
                if (!string.IsNullOrEmpty(lueBusinessContact.Text.Trim()) && billType == MainMenuConstants.FGStockInBill)
                    orderHdBindingSource.DataSource = BLLFty.Create<OrderBLL>().GetOrderHd().FindAll(o =>
                    o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Status == (int)BillStatus.Audited);
            }
            else if (billType == MainMenuConstants.AssembleStockInBill)
                goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)GoodsBigType.SFGoods || o.Type == (int)GoodsBigType.Stuff);
            else
                goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)goodsBigType);

            if (hdID is Guid && ((Guid)hdID) != Guid.Empty)
            {
                headID = (Guid)hdID;
                stockInBillHdBindingSource.DataSource = hd = BLLFty.Create<StockInBillBLL>().GetStockInBillHd(headID);
                stockInBillDtlBindingSource.DataSource = dtl = BLLFty.Create<StockInBillBLL>().GetStockInBillDtl(headID);
            }
            vUsersInfoBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VUsersInfo>)];
            warehouseBindingSource.DataSource = warehouseList = MainForm.dataSourceList[typeof(List<Warehouse>)] as List<Warehouse>;
            List<TypesList> types = MainForm.dataSourceList[typeof(List<TypesList>)] as List<TypesList>;
            //入库单类型
            if (billType == MainMenuConstants.ReturnedMaterialBill)
            {
                if (MainForm.ISnowSoftVersion == ISnowSoftVersion.PurchaseSellStock)
                    typesListBindingSource.DataSource = types.FindAll(o => o.Type == MainMenuConstants.StockInBillType && o.No == 9);
                else if (MainForm.ISnowSoftVersion == ISnowSoftVersion.EMS)
                    typesListBindingSource.DataSource = types.FindAll(o => o.Type == MainMenuConstants.StockInBillType && (o.No == 4 || o.No == 9));
                else if (MainForm.ISnowSoftVersion == ISnowSoftVersion.FSM)
                    typesListBindingSource.DataSource = types.FindAll(o => o.Type == MainMenuConstants.StockInBillType && (o.No == 7 || o.No == 9));
                else if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                    typesListBindingSource.DataSource = types.FindAll(o => o.Type == MainMenuConstants.StockInBillType && (o.No == 4 || o.No == 7 || o.No == 9 || o.No == 10));
                else
                    typesListBindingSource.DataSource = types.FindAll(o => o.Type == MainMenuConstants.StockInBillType && (o.No == 4 || o.No == 10));
            }
            else
                typesListBindingSource.DataSource = types.FindAll(o => o.SubType == billType);
            //仓库类型
            warehouseTypeBindingSource.DataSource = types.FindAll(o => o.Type == TypesListConstants.CustomerType);

            //SetBusinessContact(false);
            //businessContactBindingSource.DataSource = null;
            //txtContacts.EditValue = null;
            if (billType == MainMenuConstants.ProductionStockInBill || billType == MainMenuConstants.SalesReturnBill)
            {
                SetDtlHeader(true);
                businessContactType = (int)BusinessContactType.Customer;
            }
            else if (MainForm.SysInfo.CompanyType == (int)CompanyType.Trade && billType == MainMenuConstants.FGStockInBill)
            {
                SetDtlHeader(true);
                businessContactType = (int)BusinessContactType.Supplier;
            }
            else
            {
                SetDtlHeader(false);
                businessContactType = (int)BusinessContactType.Supplier;
            }
        }

        void SetBusinessContact(bool flag)
        {
            lueBusinessContact.Enabled = flag;
            txtContacts.Enabled = flag;
            lueWarehouseType.Enabled = flag;
        }

        public void Add()
        {
            stockInBillHdBindingSource.DataSource = hd = new StockInBillHd();
            stockInBillDtlBindingSource.DataSource = dtl = new List<StockInBillDtl>();
            gridView.AddNewRow();
            gridView.FocusedColumn = colGoodsID;
            //string no = BLLFty.Create<StockInBillBLL>().GetMaxBillNo();
            //if (no == null)
            //    hd.BillNo = "RK" + DateTime.Now.ToString("yyyyMMdd") + "001";
            //else
            //{
            //    if (no.Substring(2, 8).Equals(DateTime.Now.ToString("yyyyMMdd")))
            //        hd.BillNo = "RK" + DateTime.Now.ToString("yyyyMMdd") + Convert.ToString(int.Parse(no.Substring(10, 3)) + 1).PadLeft(3, '0');
            //    else
            //        hd.BillNo = "RK" + DateTime.Now.ToString("yyyyMMdd") + "001";
            //}
            hd.BillNo = MainForm.GetMaxBillNo(MainMenuConstants.StockInBillType, true).MaxBillNo;
            headID = Guid.Empty;
            hd.BillDate = DateTime.Today;
            lueType.Focus();
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
                    if (hd != null)
                    {
                        StockInBillHd dCheck = BLLFty.Create<StockInBillBLL>().GetStockInBillHd(hd.ID);
                        if (dCheck.Status == (int)BillStatus.UnAudited)
                            BLLFty.Create<StockInBillBLL>().Delete(hd.ID);
                        else
                        {
                            CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "该单据已审核，不允许删除。");
                            return;
                        }

                    }
                    ////DataQueryPageRefresh();
                    //刷新查询界面
                    clientFactory.DataPageRefresh(billType);
                    //MainForm.DataQueryPageRefresh();
                    //DataQueryPage page = ClientFactory.itemDetailList[billType + "Query"] as DataQueryPage;
                    //MainForm.GetDataSource();
                    //page.InitGrid(MainForm.GetData(billType + "Query"));
                    stockInBillHdBindingSource.DataSource = hd = new StockInBillHd();
                    stockInBillDtlBindingSource.DataSource = dtl = new List<StockInBillDtl>();
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
            //if (billType != TypesListConstants.ProductionStockInBill && lueBusinessContact.EditValue == null)
            if (billType != MainMenuConstants.ProductionStockInBill && lueBusinessContact.Enabled == true && string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请填写业务往来信息");
                flag = false;
            }
            if (billType ==MainMenuConstants.FGStockInBill && MainForm.SysInfo.CompanyType == (int)CompanyType.Trade && string.IsNullOrEmpty(lueOrderNo.Text.Trim()))
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("请填写{0}", lciOrderNo.Text));
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
                    continue;
                }
                Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID.Equals(dtl[i].GoodsID));
                //获取或设置客户商品售价
                //if (isSLSalePrice && lueBusinessContact.Enabled == true && !string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))
                //销售退货价格可能低于销售价格，所以退货单不保存客户价格
                if (lueBusinessContact.Enabled == true && !string.IsNullOrEmpty(lueBusinessContact.Text.Trim()) && billType != MainMenuConstants.SalesReturnBill)
                {
                   // SLSalePrice cSLSalePrice = ((List<SLSalePrice>)MainForm.dataSourceList[typeof(List<SLSalePrice>)]).Find(o =>
                   //o.CustomerID == new Guid(lueBusinessContact.EditValue.ToString()) && o.GoodsID == dtl[i].GoodsID);
                    if (billType == MainMenuConstants.ProductionStockInBill || billType == MainMenuConstants.SalesReturnBill)
                        businessContactType = (int)BusinessContactType.Customer;
                    else
                        businessContactType = (int)BusinessContactType.Supplier;
                    SLSalePrice cSLSalePrice = BLLFty.Create<SLSalePriceBLL>().GetSLSalePrice().FirstOrDefault(o =>
                   o.ID == new Guid(lueBusinessContact.EditValue.ToString()) && o.GoodsID == dtl[i].GoodsID && o.Type == businessContactType);
                    if (cSLSalePrice == null)
                    {
                        SLSalePrice obj = new SLSalePrice();
                        obj.ID = new Guid(lueBusinessContact.EditValue.ToString());
                        obj.GoodsID = dtl[i].GoodsID;
                        obj.Price = dtl[i].Price;
                        obj.Type = businessContactType;
                        obj.PriceNoTax = dtl[i].PriceNoTax;
                        obj.Discount = dtl[i].Discount==0?1: dtl[i].Discount;
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

                if (billType != MainMenuConstants.ProductionStockInBill && billType != MainMenuConstants.SalesReturnBill)
                {
                    if (goods.NWeight != dtl[i].NWeight)
                    {
                        goods.NWeight = dtl[i].NWeight;
                        BLLFty.Create<GoodsBLL>().Update(goods);
                    }
                }
                //if (status == BillStatus.Audited)
                //{
                //    List<Inventory> lst = BLLFty.Create<InventoryBLL>().GetInventory(hd.WarehouseID, dtl[i].GoodsID);
                //    Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID.Equals(dtl[i].GoodsID));
                //    if (lst.Count >= 0 && (lst.Sum(o => o.Qty) - dtl[i].Qty) < 0)
                //    {
                //        CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("货品[{0}]出库数量大于现库存数量，不允许出库！", goods.Code));
                //        flag = false;
                //    }
                //}
                if (dtl[i].PCS == 0)
                    dtl[i].PCS = 1;
                hd.BillAMT += decimal.Round((goods.Unit == "斤" 
                    && (billType!=MainMenuConstants.SFGStockInBill && billType != MainMenuConstants.ProductionStockInBill && billType != MainMenuConstants.SalesReturnBill) 
                    ? dtl[i].Qty * 500 / (goods.NWeight == 0 ? 1 : goods.NWeight) : dtl[i].Qty) * dtl[i].PCS * dtl[i].Price * dtl[i].Discount + dtl[i].OtherFee, 2);
            }
            hd.UnPaidAMT = hd.BillAMT;
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
                hd = stockInBillHdBindingSource.DataSource as StockInBillHd;
                dtl = stockInBillDtlBindingSource.DataSource as List<StockInBillDtl>;
                if (string.IsNullOrEmpty(txtBillNo.Text.Trim()))
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "单据编号不能为空，请点击添加按钮添加单据。");
                    return false;
                }
                if (BillValidated(BillStatus.UnAudited) == false)
                    return false;
                hd.Maker = MainForm.usersInfo.ID;
                hd.MakeDate = DateTime.Now;
                hd.Auditor = null;
                hd.AuditDate = null;
                hd.Status = 0;
                switch (billType)
                {
                    case MainMenuConstants.ProductionStockInBill:
                    case MainMenuConstants.SalesReturnBill:
                        hd.WarehouseID = warehouseList.FirstOrDefault(o=>o.Code==WarehouseConstants.FG).ID;  //成品仓
                        break;
                    case MainMenuConstants.EMSReturnBill:
                    case MainMenuConstants.SFGStockInBill:
                    case MainMenuConstants.FSMStockInBill:
                    case MainMenuConstants.FSMReturnBill:
                    case MainMenuConstants.AssembleStockInBill:
                    case MainMenuConstants.ReturnedMaterialBill:
                        hd.WarehouseID = warehouseList.FirstOrDefault(o=>o.Code==WarehouseConstants.SFG).ID;  //半成品
                        break;
                    case MainMenuConstants.FGStockInBill:
                        if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                            hd.WarehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.SFG).ID;  //半成品
                        else
                            hd.WarehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.FG).ID;  //成品仓
                        break;
                }

                if (billType == MainMenuConstants.ProductionStockInBill)
                {
                    if ((lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                        hd.Type = 0;
                    else
                        hd.Type = 1;
                }
                //添加
                if (headID == Guid.Empty)
                {
                    hd.ID = Guid.NewGuid();
                    foreach (StockInBillDtl item in dtl)
                    {
                        item.ID = Guid.NewGuid();
                        item.HdID = hd.ID;
                    }
                    BLLFty.Create<StockInBillBLL>().Insert(hd, dtl);
                }
                else//修改
                    BLLFty.Create<StockInBillBLL>().Update(hd, dtl);
                headID = hd.ID;
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

        public bool Audit()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                gridView.CloseEditForm();
                if (hd != null)
                {
                    dtl = BLLFty.Create<StockInBillBLL>().GetStockInBillDtl(hd.ID);
                    StockInBillHd stockIn = BLLFty.Create<StockInBillBLL>().GetStockInBillHd(hd.ID);
                    if (stockIn != null && stockIn.Status > 1)
                    {
                        CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "已结账单据不能取消审核");
                        return false;
                    }

                    if (stockIn != null && stockIn.Status == 0)
                    {
                        if (BillValidated(BillStatus.Audited) == false)
                            return false;
                    }
                    hd.Auditor = MainForm.usersInfo.ID;
                    hd.AuditDate = DateTime.Now;
                    hd.Status = 1;

                    List<Inventory> inventorylist = new List<Inventory>();
                    List<AccountBook> accountBooklist = new List<AccountBook>();
                    List<Alert> alertlist = new List<Alert>();
                    List<Alert> dellist = new List<Alert>();
                    //Dictionary<Guid, Decimal> totaiQty = BLLFty.Create<InventoryBLL>().GetGoodsTotalQty(hd.WarehouseID);
                    foreach (StockInBillDtl dtlItem in dtl)
                    {
                        if (billType == MainMenuConstants.SalesReturnBill)  //销售退货不需要增加库存
                            continue;
                        Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID == dtlItem.GoodsID && o.PCS == dtlItem.PCS);
                        //库存数据
                        Inventory ity = new Inventory();
                        ity.ID = Guid.NewGuid();
                        ity.WarehouseID = hd.WarehouseID;
                        ity.WarehouseType = hd.WarehouseType;
                        ity.CompanyID = hd.CompanyID;
                        ity.SupplierID = hd.SupplierID;
                        ity.DeptID = hd.DeptID;
                        ity.GoodsID = dtlItem.GoodsID;
                        //if (billType == MainMenuConstants.SFGStockInBill || billType == MainMenuConstants.ReturnedMaterialBill)
                        //{
                        //    switch (goods.Unit.ToUpper())
                        //    {
                        //        case "吨":
                        //        case "T":
                        //            ity.Qty = dtlItem.Qty * 1000000;
                        //            break;
                        //        case "斤":
                        //            ity.Qty = dtlItem.Qty * 500;
                        //            break;
                        //        case "公斤":
                        //        case "KG":
                        //            ity.Qty = dtlItem.Qty * 1000;
                        //            break;
                        //        case "米":
                        //        case "M":
                        //            ity.Qty = dtlItem.Qty * 100; //米转厘米
                        //            break;
                        //        default:
                        //            ity.Qty = dtlItem.Qty;
                        //            break;
                        //    }
                        //}
                        //else
                        if (billType == MainMenuConstants.ProductionStockInBill)//成品入库可以输入负数，为了临时调库存差异
                            ity.Qty = dtlItem.Qty;
                        else
                            ity.Qty = Math.Abs(dtlItem.Qty);
                        ity.MEAS = dtlItem.MEAS;
                        ity.PCS = dtlItem.PCS;
                        ity.InnerBox = dtlItem.InnerBox;
                        ity.NWeight = dtlItem.NWeight == 0 ? 1 : dtlItem.NWeight;
                        ity.Price = dtlItem.Price;
                        ity.Discount = dtlItem.Discount;
                        ity.OtherFee = dtlItem.OtherFee;
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
                        ab.PCS = dtlItem.PCS;
                        ab.NWeight = dtlItem.NWeight == 0 ? 1 : dtlItem.NWeight;
                        ab.Price = dtlItem.Price;
                        ab.Discount = dtlItem.Discount;
                        ab.OtherFee = dtlItem.OtherFee;
                        //if (billType == MainMenuConstants.SFGStockInBill || billType == MainMenuConstants.ReturnedMaterialBill)
                        //{
                        //    switch (goods.Unit.ToUpper())
                        //    {
                        //        case "吨":
                        //        case "T":
                        //            ab.InQty = dtlItem.Qty * 1000000;
                        //            break;
                        //        case "斤":
                        //            ab.InQty = dtlItem.Qty * 500;//转成克
                        //            break;
                        //        case "公斤":
                        //        case "KG":
                        //            ab.InQty = dtlItem.Qty * 1000;//转成克
                        //            break;
                        //        case "米":
                        //        case "M":
                        //            ab.InQty = dtlItem.Qty * 100; //米转厘米
                        //            break;
                        //        default:
                        //            ab.InQty = dtlItem.Qty;
                        //            break;
                        //    }
                        //}
                        //else
                        ab.InQty = ity.Qty;
                        List<Inventory> lst = BLLFty.Create<InventoryBLL>().GetInventory(hd.WarehouseID, dtlItem.GoodsID, dtlItem.PCS);
                        if (lst.Count>0)
                        {
                            decimal totalAMT = lst.Sum(o => o.Qty * o.Price * o.Discount + o.OtherFee);
                            ab.BalanceQty = lst.Sum(o => o.Qty) + ab.InQty;
                            ab.BalanceCost = totalAMT + (ab.InQty * dtlItem.Price * dtlItem.Discount + dtlItem.OtherFee);
                        }
                        else
                        {
                            ab.BalanceQty = ab.InQty;
                            ab.BalanceCost = ab.BalanceQty * dtlItem.Price * dtlItem.Discount + dtlItem.OtherFee;
                        }
                        ab.BillNo = hd.BillNo;
                        ab.BillDate = hd.BillDate;
                        accountBooklist.Add(ab);

                        if (stockIn != null && stockIn.Status == 0)
                        {
                            //添加提醒信息
                            decimal total = 0;
                            if (lst.Count > 0)
                                total = lst.Sum(o => o.Qty) + ab.InQty;
                            else
                                total = ab.InQty;
                            ////Alert alert = ((List<Alert>)MainForm.dataSourceList[typeof(List<Alert>)]).Find(o => o.GoodsID == dtlItem.GoodsID);
                            ////if (alert != null)
                            ////    dellist.Add(alert);
                            ////if (goods != null && total > goods.UpperLimit && goods.UpperLimit > 0)
                            ////{
                            ////    Alert obj = new Alert();
                            ////    obj.ID = Guid.NewGuid();
                            ////    obj.GoodsID = dtlItem.GoodsID;
                            ////    obj.Caption = "库存过多";
                            ////    obj.Text = string.Format("货品[{0}]库存数量为:[{1}].已超过库存上限，请考虑是否停止补货。", goods.Code, total);
                            ////    obj.AddTime = DateTime.Now;
                            ////    alertlist.Add(obj);

                            ////    MainForm.alertControl.Show(this.FindForm(), obj.Caption, obj.Text, global::USL.Properties.Resources.Alarm_Clock);
                            ////}
                        }
                    }
                    bool flag = false;
                    if (billType == MainMenuConstants.ProductionStockInBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))//成品入库单才减半成品库存，补差入库单不减
                    {
                        //因为要减去半成品，所以重新获取半成品库存
                        ////totaiQty = BLLFty.Create<InventoryBLL>().GetGoodsTotalQty(warehouseList[1].ID);  //半成品库存
                        //减少生产入库产品对应的半成品库存
                        //if (hd.OrderID != null || hd.OrderID != Guid.Empty)
                        //{注释掉由订单来获取半成品数量，因为由订单生成的入库单数量有可能修改再审核
                        //    List<OrderDtl> dtlByBOM = BLLFty.Create<OrderBLL>().GetVOrderDtlByBOM(hd.OrderID.Value, (int)BOMType.BOM);
                        //    foreach (OrderDtl dtlItem in dtlByBOM)
                        //    {
                        //        if (StockOut(inventorylist, accountBooklist, alertlist, dellist, totaiQty, dtlItem))
                        //            flag = true;
                        //    }
                        //}
                        //else
                        //{
                        List<StockInBillDtl> dtlByBOM = BLLFty.Create<StockInBillBLL>().GetVStockInBillDtlByBOM(hd.ID, (int)BOMType.BOM);
                        foreach (StockInBillDtl dtlItem in dtlByBOM)
                        {
                            if (StockOut(inventorylist, accountBooklist, alertlist, dellist, dtlItem, stockIn))
                                flag = true;
                        }
                        //}
                    }
                    else if (billType==MainMenuConstants.FGStockInBill || billType==MainMenuConstants.FSMStockInBill)//装配入库不减少对应材料库存，因为材料已经领料时出库
                    //else if (billType == MainMenuConstants.AssembleStockInBill || billType == MainMenuConstants.FGStockInBill || billType == MainMenuConstants.FSMStockInBill)
                    {
                        //减少入库产品对应的材料库存
                        List<StockInBillDtl> dtlByMoldMaterial = null;
                        if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                            dtlByMoldMaterial = BLLFty.Create<StockInBillBLL>().GetVStockInBillDtlByBOM(hd.ID, (int)BOMType.Assemble);
                        else
                            dtlByMoldMaterial = BLLFty.Create<StockInBillBLL>().GetVStockInBillDtlByBOM(hd.ID);
                        foreach (StockInBillDtl dtlItem in dtlByMoldMaterial)
                        {
                            if (StockOut(inventorylist, accountBooklist, alertlist, dellist, dtlItem,stockIn))
                                flag = true;
                        }
                    }
                    //else if (billType == MainMenuConstants.FSMStockInBill)
                    //{
                    //    //减少自动机入库产品对应的原料库存(按模具算原料)
                    //    List<OrderDtl> dtlByMoldMaterial = BLLFty.Create<OrderBLL>().GetVFSMOrderDtlByMoldMaterial(hd.OrderID.Value);
                    //    foreach (OrderDtl dtlItem in dtlByMoldMaterial)
                    //    {
                    //        if (StockOut(inventorylist, accountBooklist, alertlist, dellist, dtlItem))
                    //            flag = true;
                    //    }
                    //}
                    if (flag)
                        return false;

                    if (stockIn != null && stockIn.Status == 1)
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
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "没有可审核单据");
                    return false;
                }
                //DataQueryPageRefresh();
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
                clientFactory.DataPageRefresh(billType);
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="inventorylist"></param>
        /// <param name="accountBooklist"></param>
        /// <param name="alertlist"></param>
        /// <param name="dellist"></param>
        /// <param name="totaiQty"></param>
        /// <param name="dtlItem"></param>
        /// <returns></returns>
        bool StockOut(List<Inventory> inventorylist, List<AccountBook> accountBooklist, List<Alert> alertlist, List<Alert> dellist, StockInBillDtl dtlItem,StockInBillHd stockIn)
        {
            bool flag = false;
            //库存数据
            Inventory ity = new Inventory();
            ity.ID = Guid.NewGuid();
            //if (billType == MainMenuConstants.ProductionStockInBill)
            //    ity.WarehouseID = warehouseList[(int)WarehouseType.SFG].ID;
            //else
            //    ity.WarehouseID = hd.WarehouseID;
            switch (billType)
            {
                case MainMenuConstants.ProductionStockInBill:
                    ity.WarehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.SFG).ID;
                    break;
                case MainMenuConstants.FGStockInBill:
                    ity.WarehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.EMS).ID;
                    break;
                case MainMenuConstants.FSMStockInBill:
                    ity.WarehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.FSM).ID;
                    break;
                case MainMenuConstants.ReturnedMaterialBill:
                    if (Convert.ToInt32(lueType.EditValue) == 4)
                        ity.WarehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.EMS).ID;
                    else if (Convert.ToInt32(lueType.EditValue) == 7)
                        ity.WarehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.FSM).ID;
                    else
                        ity.WarehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.SFG).ID;
                    break;
                default:
                    ity.WarehouseID = hd.WarehouseID;
                    break;
            }
            ity.WarehouseType = hd.WarehouseType;
            ity.CompanyID = hd.CompanyID;
            ity.SupplierID = hd.SupplierID;
            ity.DeptID = hd.DeptID;
            ity.GoodsID = dtlItem.GoodsID;
            ity.Qty = -Math.Abs(dtlItem.Qty);  //出库数量为负数
            ity.MEAS = dtlItem.MEAS;
            ity.PCS = dtlItem.PCS;
            ity.InnerBox = dtlItem.InnerBox;
            ity.NWeight = dtlItem.NWeight == 0 ? 1 : dtlItem.NWeight;
            ity.Price = dtlItem.Price;
            ity.Discount = dtlItem.Discount;
            ity.OtherFee = dtlItem.OtherFee;
            ity.EntryDate = DateTime.Now;
            ity.BillNo = hd.BillNo;
            ity.BillDate = hd.BillDate;
            inventorylist.Add(ity);
            //账页数据
            AccountBook ab = new AccountBook();
            ab.ID = Guid.NewGuid();
            //if (billType == MainMenuConstants.ProductionStockInBill)
            //    ab.WarehouseID = warehouseList[1].ID;
            //else
            //    ab.WarehouseID = hd.WarehouseID;
            ab.WarehouseID = ity.WarehouseID;
            ab.WarehouseType = hd.WarehouseType;
            ab.GoodsID = dtlItem.GoodsID;
            ab.AccntDate = DateTime.Now;
            ab.NWeight = dtlItem.NWeight == 0 ? 1 : dtlItem.NWeight;
            ab.Price = dtlItem.Price;
            ab.Discount = dtlItem.Discount;
            ab.OtherFee = dtlItem.OtherFee;
            ab.OutQty = ity.Qty;
            //List<Inventory> lst = BLLFty.Create<InventoryBLL>().GetInventory(ity.WarehouseID, dtlItem.GoodsID, dtlItem.PCS);
            List<Inventory> lst = BLLFty.Create<InventoryBLL>().GetInventory(ity.WarehouseID, dtlItem.GoodsID);
            if (lst.Count>0)
            {
                decimal totalAMT = lst.Sum(o => o.Qty * o.Price * o.Discount + o.OtherFee);
                ab.BalanceQty = lst.Sum(o=>o.Qty) - Math.Abs(dtlItem.Qty);
                ab.BalanceCost = totalAMT - (Math.Abs(dtlItem.Qty) * dtlItem.Price * dtlItem.Discount + dtlItem.OtherFee);
            }
            else
            {
                ab.BalanceQty = -Math.Abs(dtlItem.Qty);
                ab.BalanceCost = -(Math.Abs(dtlItem.Qty) * dtlItem.Price * dtlItem.Discount + dtlItem.OtherFee);
            }
            ab.BillNo = hd.BillNo;
            ab.BillDate = hd.BillDate;
            accountBooklist.Add(ab);

            Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID.Equals(dtlItem.GoodsID) && o.PCS == dtlItem.PCS);
            if (stockIn != null && stockIn.Status == 0)
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

                //添加提醒信息
                decimal total = 0;
                if (lst.Count > 0)
                    total = lst.Sum(o => o.Qty) - Math.Abs(dtlItem.Qty);
                else
                    total = -Math.Abs(dtlItem.Qty);
                ////Alert alert = ((List<Alert>)MainForm.dataSourceList[typeof(List<Alert>)]).Find(o => o.GoodsID == dtlItem.GoodsID);
                ////if (alert != null)
                ////    dellist.Add(alert);
                ////if (goods != null && total < goods.LowerLimit)
                ////{
                ////    Alert obj = new Alert();
                ////    obj.ID = Guid.NewGuid();
                ////    obj.GoodsID = dtlItem.GoodsID;
                ////    obj.Caption = "库存不足";
                ////    obj.Text = string.Format("货品[{0}]库存数量为:[{1}].已低于库存下限，请及时补货。", goods.Code, total);
                ////    obj.AddTime = DateTime.Now;
                ////    alertlist.Add(obj);

                ////    MainForm.alertControl.Show(this.FindForm(), obj.Caption, obj.Text, global::USL.Properties.Resources.Alarm_Clock);
                ////}
            }
            return flag;
        }
        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="inventorylist"></param>
        /// <param name="accountBooklist"></param>
        /// <param name="alertlist"></param>
        /// <param name="dellist"></param>
        /// <param name="totaiQty"></param>
        /// <param name="dtlItem"></param>
        /// <param name="flag"></param>
        bool StockOut(List<Inventory> inventorylist, List<AccountBook> accountBooklist, List<Alert> alertlist, List<Alert> dellist, OrderDtl dtlItem, StockInBillHd stockIn)
        {
            bool flag = false;
            //库存数据
            Inventory ity = new Inventory();
            ity.ID = Guid.NewGuid();
            ity.WarehouseID = hd.WarehouseID;
            ity.WarehouseType = hd.WarehouseType;
            ity.CompanyID = hd.CompanyID;
            ity.SupplierID = hd.SupplierID;
            ity.DeptID = hd.DeptID;
            ity.GoodsID = dtlItem.GoodsID;
            ity.Qty = -Math.Abs(dtlItem.Qty);  //出库数量为负数
            ity.MEAS = dtlItem.MEAS;
            ity.PCS = dtlItem.PCS;
            ity.InnerBox = dtlItem.InnerBox;
            ity.NWeight = dtlItem.NWeight == 0 ? 1 : dtlItem.NWeight;
            ity.Price = dtlItem.Price;
            ity.Discount = dtlItem.Discount;
            ity.OtherFee = dtlItem.OtherFee;
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
            ab.NWeight = dtlItem.NWeight == 0 ? 1 : dtlItem.NWeight;
            ab.Price = dtlItem.Price;
            ab.Discount = dtlItem.Discount;
            ab.OtherFee = dtlItem.OtherFee;
            ab.OutQty = ity.Qty;
            //List<Inventory> lst = BLLFty.Create<InventoryBLL>().GetInventory(hd.WarehouseID, dtlItem.GoodsID, dtlItem.PCS);
            List<Inventory> lst = BLLFty.Create<InventoryBLL>().GetInventory(hd.WarehouseID, dtlItem.GoodsID);
            if (lst.Count>0)
            {
                decimal totalAMT = lst.Sum(o => o.Qty * o.Price * o.Discount + o.OtherFee);
                ab.BalanceQty = lst.Sum(o => o.Qty) - Math.Abs(dtlItem.Qty);
                ab.BalanceCost = totalAMT - (Math.Abs(dtlItem.Qty) * dtlItem.Price * dtlItem.Discount + dtlItem.OtherFee);
            }
            else
            {
                ab.BalanceQty = -Math.Abs(dtlItem.Qty);
                ab.BalanceCost = -(Math.Abs(dtlItem.Qty) * dtlItem.Price * dtlItem.Discount + dtlItem.OtherFee);
            }
            ab.BillNo = hd.BillNo;
            ab.BillDate = hd.BillDate;
            accountBooklist.Add(ab);

            Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID.Equals(dtlItem.GoodsID));
            if (stockIn != null && stockIn.Status == 0)
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
                //添加提醒信息
                decimal total = 0;
                if (lst.Count > 0)
                    total = lst.Sum(o => o.Qty) - Math.Abs(dtlItem.Qty);
                else
                    total = -Math.Abs(dtlItem.Qty);
                ////Alert alert = ((List<Alert>)MainForm.dataSourceList[typeof(List<Alert>)]).Find(o => o.GoodsID == dtlItem.GoodsID);
                ////if (alert != null)
                ////    dellist.Add(alert);
                ////if (goods != null && total < goods.LowerLimit)
                ////{
                ////    Alert obj = new Alert();
                ////    obj.ID = Guid.NewGuid();
                ////    obj.GoodsID = dtlItem.GoodsID;
                ////    obj.Caption = "库存不足";
                ////    obj.Text = string.Format("货品[{0}]库存数量为:[{1}].已低于库存下限，请及时补货。", goods.Code, total);
                ////    obj.AddTime = DateTime.Now;
                ////    alertlist.Add(obj);

                ////    MainForm.alertControl.Show(this.FindForm(), obj.Caption, obj.Text, global::USL.Properties.Resources.Alarm_Clock);
                ////}
            }
            return flag;
        }

        void GetPrintBillDtlGridControl()
        {
            
        }

        public void Print()
        {
            if (dtl == null)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "没有可打印的数据");
                return;
            }
            PrintSettingController psc = new PrintSettingController(this.gridControl);
            try
            {
                if (billType == MainMenuConstants.ProductionStockInBill)
                {
                    //隐藏部分列
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView.Columns)
                    {
                        if (col == colPackaging || col == colQty || col == colPCS || col == colInnerBox || col == colDiscount || col == colOtherFee)
                            col.Visible = false;
                    }
                }
                gridView.BestFitColumns();
                //页眉 
                if (hd != null)
                {
                    psc.PrintCompany = MainForm.Company;
                    List<TypesList> types = MainForm.dataSourceList[typeof(List<TypesList>)] as List<TypesList>;
                    if (billType == MainMenuConstants.ReturnedMaterialBill)
                        psc.PrintHeader = types.Find(o => o.Type == MainMenuConstants.StockInBillType && o.No == hd.Type).Name + "单";
                    else
                        psc.PrintHeader = types.Find(o => o.SubType == billType && o.No == hd.Type).Name + "单";// "\r\n";
                    psc.PrintSubTitle = MainForm.Contacts.Replace("\\r\\n", "\r\n");
                    psc.PrintLeftHeader = "单据编号：" + hd.BillNo + "\r\n"
                        + "业务往来：" + lueBusinessContact.Text + "\r\n"
                        + "    仓库：" + lueWarehouse.Text;
                    psc.PrintRightHeader = "入库日期：" + deBillDate.Text + "\r\n"
                        + "联系人：" + txtContacts.EditValue + "\r\n"
                        + "备注：" + meRemark.EditValue;

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
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "。\r\n错误信息：" + ex.Message);
            }
            finally
            {
                if (billType == MainMenuConstants.ProductionStockInBill)
                {
                    //还原隐藏列
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView.Columns)
                    {
                        if (col == colPackaging || col == colQty || col == colPCS || col == colInnerBox || col == colDiscount || col == colOtherFee)
                            col.Visible = true;
                    }
                    //控制栏位顺序
                    int i = 0;
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView.Columns)
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
                //gridControl.BeginUpdate();
                Goods goods = ((LookUpEdit)sender).GetSelectedDataRow() as Goods;
                if (goods != null)
                {
                    //if (dtl != null && dtl.Any(o => o.GoodsID == goods.ID))
                    //{
                    //    //gridView.SetRowCellValue(gridView.FocusedRowHandle, colGoodsID, null);
                    //    gridView.DeleteSelectedRows();
                    //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "不能重复选择货品。");
                    //    return;

                    //}
                    List<SLSalePrice> slSalePriceList = new List<SLSalePrice>();
                    if (lueBusinessContact.EditValue != null && lueBusinessContact.Text!=string.Empty)
                        slSalePriceList = BLLFty.Create<SLSalePriceBLL>().GetSLSalePrice(new Guid(lueBusinessContact.EditValue.ToString()));
                    //gridView.SetRowCellValue(gridView.FocusedRowHandle, colGoodsID, goods.ID);
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colMEAS, goods.MEAS);
                    if (billType == MainMenuConstants.SalesReturnBill)
                    {
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colPCS, 1);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colInnerBox, 0);
                    }
                    else
                    {
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colPCS, goods.PCS);
                        gridView.SetRowCellValue(gridView.FocusedRowHandle, colInnerBox, goods.InnerBox);
                    }
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colNWeight, goods.NWeight == 0 ? 1 : goods.NWeight);
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colCavityNumber, goods.CavityNumber == 0 ? 1 : goods.CavityNumber);
                    //客户设置固定售价
                    Decimal price = goods.Price;
                    Decimal disCount = 1;
                    Decimal otherFee = 0;
                    //if ((billType == MainMenuConstants.SalesReturnBill && ((List<Company>)MainForm.dataSourceList[typeof(List<Company>)]).Exists(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == (int)CustomerType.DomesticSales))
                    if ((billType == MainMenuConstants.SalesReturnBill && ((List<Company>)MainForm.dataSourceList[typeof(List<Company>)]).Exists(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString())))
                        || (billType == MainMenuConstants.SFGStockInBill && ((List<Supplier>)MainForm.dataSourceList[typeof(List<Supplier>)]).Exists(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString()))))
                    {
                        //获取或设置客户商品售价
                        //SLSalePrice cSLSalePrice = slSalePriceList.FirstOrDefault(o => o.GoodsID == goods.ID && o.Type == businessContactType);
                        SLSalePrice cSLSalePrice = BLLFty.Create<SLSalePriceBLL>().GetSLSalePrice().FirstOrDefault(o =>
                       o.ID == new Guid(lueBusinessContact.EditValue.ToString()) && o.GoodsID == goods.ID && o.Type == businessContactType);
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
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colPriceNoTax, goods.PriceNoTax);
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colDiscount, disCount);
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colOtherFee, otherFee);
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
            switch (billType)
            {
                case MainMenuConstants.FSMStockInBill:
                    SetBusinessContact(true);  //自动机给外面的人做
                    break;
                ////case MainMenuConstants.ProductionStockInBill:
                case MainMenuConstants.AssembleStockInBill:
                    SetBusinessContact(false);
                    break;
                case MainMenuConstants.ProductionStockInBill:
                case MainMenuConstants.SalesReturnBill:
                    VCompany company = ((LookUpEdit)sender).GetSelectedDataRow() as VCompany;
                    if (company != null && hd != null)
                    {
                        hd.CompanyID = company.ID;
                        hd.Contacts = company.联系人;
                        if (headID == Guid.Empty)
                            hd.WarehouseType = company.客户类型;
                    }
                    break;
                case MainMenuConstants.FGStockInBill:
                case MainMenuConstants.EMSReturnBill:
                case MainMenuConstants.SFGStockInBill:
                case MainMenuConstants.FSMReturnBill:
                    VSupplier supplier = ((LookUpEdit)sender).GetSelectedDataRow() as VSupplier;
                    if (supplier != null && hd != null)
                    {
                        hd.SupplierID = supplier.ID;
                        hd.Contacts = supplier.联系人;
                        if (billType == MainMenuConstants.FGStockInBill)
                            orderHdBindingSource.DataSource = BLLFty.Create<OrderBLL>().GetOrderHd().FindAll(o =>
                            o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Status == (int)BillStatus.Audited);
                    }
                    break;
                case MainMenuConstants.ReturnedMaterialBill:
                    if (Convert.ToInt32(lueType.EditValue) == 9)
                    {
                        VDepartment dept = ((LookUpEdit)sender).GetSelectedDataRow() as VDepartment;
                        if (dept != null && hd != null)
                        {
                            hd.DeptID = dept.ID;
                            hd.Contacts = dept.联系人;
                        }
                    }
                    else if (Convert.ToInt32(lueType.EditValue) == 10)
                    {
                        VCompany customer = ((LookUpEdit)sender).GetSelectedDataRow() as VCompany;
                        if (customer != null && hd != null)
                        {
                            hd.CompanyID = customer.ID;
                            hd.Contacts = customer.联系人;
                        }
                    }
                    else
                    {
                        VSupplier factory = ((LookUpEdit)sender).GetSelectedDataRow() as VSupplier;
                        if (factory != null && hd != null)
                        {
                            hd.SupplierID = factory.ID;
                            hd.Contacts = factory.联系人;
                        }
                    }
                    break;
            }
        }

        private void lueType_EditValueChanged(object sender, EventArgs e)
        {
            SetBusinessContact(true);
            businessContactBindingSource.DataSource = null;
            goodsBindingSource.DataSource = null;
            lueBusinessContact.EditValue = null;
            txtContacts.EditValue = null;
            this.lueBusinessContact.DataBindings.Clear();
            lueWarehouseType.Enabled = false;
            switch (billType)
            {
                case MainMenuConstants.ProductionStockInBill:
                    SetBusinessContact(true);
                    this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockInBillHdBindingSource, "CompanyID", true));
                    businessContactBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VCompany>)];
                    goodsBigType = GoodsBigType.Goods;
                    lueWarehouseType.Enabled = true;
                    break;
                case MainMenuConstants.FSMStockInBill:
                    //SetBusinessContact(false);     //自家有自动机，不需要放外面做               
                    SetBusinessContact(true);
                    this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockInBillHdBindingSource, "SupplierID", true));
                    businessContactBindingSource.DataSource = ((List<VSupplier>)MainForm.dataSourceList[typeof(List<VSupplier>)]).FindAll(o => o.供应商类型 == (int)SupplierType.FSM);
                    goodsBigType = GoodsBigType.Stuff;
                    break;
                case MainMenuConstants.SalesReturnBill:
                    this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockInBillHdBindingSource, "CompanyID", true));
                    businessContactBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VCompany>)];
                    goodsBigType = GoodsBigType.Goods;
                    break;
                case MainMenuConstants.FGStockInBill:
                    this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockInBillHdBindingSource, "SupplierID", true));
                    businessContactBindingSource.DataSource = ((List<VSupplier>)MainForm.dataSourceList[typeof(List<VSupplier>)]).FindAll(o => o.供应商类型 == (int)SupplierType.EMS);
                    if (!string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))
                        orderHdBindingSource.DataSource = BLLFty.Create<OrderBLL>().GetOrderHd().FindAll(o =>
                        o.SupplierID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Status == (int)BillStatus.Audited);
                    //goodsBigType = GoodsBigType.SFGoods;
                    goodsBigType = GoodsBigType.Stuff;
                    break;
                case MainMenuConstants.EMSReturnBill:
                case MainMenuConstants.SFGStockInBill:
                case MainMenuConstants.ReturnedMaterialBill:
                    if (billType == MainMenuConstants.ReturnedMaterialBill)
                    {
                        switch (Convert.ToInt32(lueType.EditValue))
                        {
                            case 4:
                                this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockInBillHdBindingSource, "SupplierID", true));
                                businessContactBindingSource.DataSource = ((List<VSupplier>)MainForm.dataSourceList[typeof(List<VSupplier>)]).FindAll(o => o.供应商类型 == (int)SupplierType.EMS);
                                break;
                            case 7:
                                this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockInBillHdBindingSource, "SupplierID", true));
                                businessContactBindingSource.DataSource = ((List<VSupplier>)MainForm.dataSourceList[typeof(List<VSupplier>)]).FindAll(o => o.供应商类型 == (int)SupplierType.FSM);
                                break;
                            case 9:
                                this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockInBillHdBindingSource, "DeptID", true));
                                businessContactBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VDepartment>)];
                                break;
                            case 10:
                                this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockInBillHdBindingSource, "CompanyID", true));
                                businessContactBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VCompany>)];
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockInBillHdBindingSource, "SupplierID", true));
                        businessContactBindingSource.DataSource = ((List<VSupplier>)MainForm.dataSourceList[typeof(List<VSupplier>)]).FindAll(o =>
                            o.供应商类型 == (billType == MainMenuConstants.EMSReturnBill ? (int)SupplierType.EMS : (int)SupplierType.Purchase));
                    }
                    goodsBigType = GoodsBigType.Stuff;
                    break;
                case MainMenuConstants.FSMReturnBill:
                    this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockInBillHdBindingSource, "SupplierID", true));
                    businessContactBindingSource.DataSource = ((List<VSupplier>)MainForm.dataSourceList[typeof(List<VSupplier>)]).FindAll(o => o.供应商类型 == (int)SupplierType.FSM);
                    goodsBigType =GoodsBigType.Material;
                    break;
                case MainMenuConstants.AssembleStockInBill:
                    SetBusinessContact(false);
                    goodsBigType = GoodsBigType.SFGoods;
                    break;
            }
            if (billType == MainMenuConstants.SFGStockInBill)
                goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type > 0);
            else if (billType == MainMenuConstants.ReturnedMaterialBill)
            {
                switch (Convert.ToInt32(lueType.EditValue))
                {
                    case 4:
                        if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                            goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)GoodsBigType.Stuff);
                        else
                            goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type > (int)GoodsBigType.Goods);
                        break;
                    case 7:
                        goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)GoodsBigType.Material || o.Type == (int)GoodsBigType.Basket);
                        break;
                    case 9:
                    case 10:
                        goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)GoodsBigType.SFGoods || o.Type == (int)GoodsBigType.Stuff || o.Type == (int)GoodsBigType.Mold);
                        break;
                    default:
                        break;
                }
            }
            else if (billType == MainMenuConstants.FGStockInBill || billType==MainMenuConstants.FSMStockInBill)
            {
                if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                    goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)goodsBigType || o.Type == (int)GoodsBigType.Basket);
                else
                    goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)GoodsBigType.Goods);
            }
            else if (billType == MainMenuConstants.AssembleStockInBill)
            {
                goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)GoodsBigType.SFGoods || o.Type == (int)GoodsBigType.Stuff);
            }
            else
                goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)goodsBigType);
        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            List<StockInBillDtl> list = ((BindingSource)view.DataSource).DataSource as List<StockInBillDtl>;
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
                    //if (e.Column == colNWeight)
                    //    e.Value = goods.NWeight == 0 ? 1 : goods.NWeight;
                    if (e.Column == colUnit)
                        e.Value = goods.Unit;
                    if (e.Column == colCavityNumber)
                        e.Value = goods.CavityNumber;
                    if (e.Column == colRemark)
                        e.Value = goods.Remark;
                    if (e.Column == colGoodsBigType)
                        e.Value = goods.Type;
                    if (e.Column == colGoodsBigType)
                        e.Value = goods.Type;
                    if (e.Column == colBillType)
                        e.Value = billType;

                }
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBillNo.Text.Trim()) && lueType.EditValue != null)
            {
                List<StockInBillHd> bills = ((List<StockInBillHd>)MainForm.dataSourceList[typeof(List<StockInBillHd>)]).FindAll(o => o.Type == (int)lueType.EditValue).OrderBy(o => o.BillNo).ToList();
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
                List<StockInBillHd> bills = ((List<StockInBillHd>)MainForm.dataSourceList[typeof(List<StockInBillHd>)]).FindAll(o => o.Type == (int)lueType.EditValue).OrderBy(o => o.BillNo).ToList();
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
            BOMType bomType = (BOMType)data;

            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (bomType== BOMType.MoldList && billType == MainMenuConstants.AssembleStockInBill)
                {
                    List<VStockInBillDtlByBOM> boms = BLLFty.Create<StockInBillBLL>().GetVStockInBillDtlByBOM2(hd.ID, (int)BOMType.Assemble).FindAll(o=>o.货品大类==(int)GoodsBigType.Mold).OrderBy(o => o.货号).ToList();
                    if (boms.Count > 0)
                    {
                        System.Windows.Forms.DialogResult result = XtraMessageBox.Show("确定要生成模具布产单吗?", "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            //单表头数据
                            OrderHd fsmHd = new OrderHd();
                            fsmHd.ID = Guid.NewGuid();
                            fsmHd.BillNo = MainForm.GetMaxBillNo(MainMenuConstants.Order, true).MaxBillNo;
                            fsmHd.WarehouseID = hd.WarehouseID;
                            fsmHd.WarehouseType = hd.WarehouseType;
                            fsmHd.CompanyID = hd.CompanyID;
                            fsmHd.Contacts = hd.Contacts;
                            fsmHd.SupplierID = hd.SupplierID;
                            fsmHd.OrderDate = DateTime.Now.Date;
                            fsmHd.DeliveryDate = DateTime.Now.Date;
                            fsmHd.Maker = hd.Maker;
                            fsmHd.MakeDate = hd.MakeDate;
                            //poHd.MainMark = hd.MainMark;
                            fsmHd.Remark = hd.Remark;
                            fsmHd.Type = hd.Type;
                            fsmHd.Status = 0;
                            fsmHd.BillType = 1;
                            fsmHd.BillAMT = hd.BillAMT;
                            //poHd.UnReceiptedAMT = hd.UnReceiptedAMT;

                            List<OrderDtl> fsmDtlList = new List<OrderDtl>();
                            int i = 0;
                            foreach (VStockInBillDtlByBOM dtlItem in boms)
                            {
                                OrderDtl fsmDtl = new OrderDtl();
                                fsmDtl.ID = Guid.NewGuid();
                                fsmDtl.HdID = fsmHd.ID;
                                fsmDtl.GoodsID = dtlItem.GoodsID;
                                fsmDtl.Qty = dtlItem.Qty == null ? 0 : dtlItem.Qty.Value;
                                //outDtl.MEAS = dtlItem.MEAS;
                                fsmDtl.PCS = dtlItem.PCS;
                                fsmDtl.InnerBox = dtlItem.InnerBox;
                                fsmDtl.NWeight = dtlItem.NWeight == 0 ? 1 : dtlItem.NWeight;
                                fsmDtl.Modulus = dtlItem.Modulus==null?0:dtlItem.Modulus.Value;
                                fsmDtl.Price = dtlItem.Price;
                                fsmDtl.PriceNoTax = dtlItem.PriceNoTax;
                                fsmDtl.Discount = dtlItem.Discount;
                                fsmDtl.OtherFee = dtlItem.OtherFee;
                                fsmDtl.SerialNo = i++;
                                fsmDtlList.Add(fsmDtl);
                            }
                            BLLFty.Create<OrderBLL>().Insert(fsmHd, fsmDtlList);
                            //MainForm.BillSaveRefresh(MainMenuConstants.FSMOrder);
                            clientFactory.DataPageRefresh<VFSMOrder>();
                            //XtraMessageBox.Show("领料出库单已成功生成。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //定位
                            MainForm.SetSelected(pageGroupCore, MainForm.mainMenuList[MainMenuConstants.FSMOrder]);
                            OrderEditPage page = MainForm.itemDetailPageList[MainMenuConstants.FSMOrder].itemDetail as OrderEditPage;
                            page.BindData(fsmHd.ID);
                        }
                    }
                    else
                        CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "没有可生成的数据。");
                }
                else
                {

                    #region #showreport
                    if (hd != null)
                    {
                        XtraAssembleMRPReport xr = new XtraAssembleMRPReport();
                        List<VMaterialStockInBill> inBill = BLLFty.Create<StockInBillBLL>().GetMaterialStockInBill(hd.ID);
                        List<VStockInBillDtlByBOM> boms = BLLFty.Create<StockInBillBLL>().GetVStockInBillDtlByBOM2(hd.ID, (int)BOMType.Assemble).OrderBy(o => o.货号).ToList();
                        List<VStockInBillDtlByColor> color = BLLFty.Create<StockInBillBLL>().GetVStockInBillDtlByColor(hd.ID, (int)BOMType.Assemble).OrderBy(o => o.Color).ToList();
                        xr.SetReportDataSource(inBill, boms, color);
                        xr.CreateDocument(true);
                        xr.paramCompany.Value = MainForm.Company;
                        xr.paramTitle.Value = "装配需求计划表";
                        xr.paramContacts.Value = MainForm.Contacts.Replace("\\r\\n", "\r\n");
                        xr.paramBillNo.Value = hd.BillNo;
                        //xr.paramCustomer.Value = lueBusinessContact.Text;
                        xr.paramStartDate.Value = hd.BillDate.ToString("yyyy-MM-dd");
                        //xr.parameEndDate.Value = hd.BillDate.ToString("yyyy-MM-dd");

                        using (ReportPrintTool printTool = new ReportPrintTool(xr))
                        {
                            printTool.AutoShowParametersPanel = false;
                            printTool.ShowRibbonPreviewDialog();
                        }
                    }
                    #endregion #show
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

        public object ReceiveData()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (billType == MainMenuConstants.AssembleStockInBill)
                {
                    List<VStockInBillDtlByBOM> boms = BLLFty.Create<StockInBillBLL>().GetVStockInBillDtlByBOM2(hd.ID, (int)BOMType.Assemble).OrderBy(o => o.货号).ToList();
                    if (boms.Count > 0)
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
                            outHd.OrderDate = hd.BillDate;
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
                            foreach (VStockInBillDtlByBOM dtlItem in boms)
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
                            //XtraMessageBox.Show("领料出库单已成功生成。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //定位
                            MainForm.SetSelected(pageGroupCore, MainForm.mainMenuList[MainMenuConstants.GetMaterialBill]);
                            StockOutBillPage page = MainForm.itemDetailPageList[MainMenuConstants.GetMaterialBill].itemDetail as StockOutBillPage;
                            page.BindData(outHd.ID);
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
            List<StockInBillDtl> inlist = ((BindingSource)view.DataSource).DataSource as List<StockInBillDtl>;
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
