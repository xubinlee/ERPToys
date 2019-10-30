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
using IBase;
using DevExpress.XtraBars.Docking2010.Views;
using System.Collections;
using CommonLibrary;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraGrid.Views.Grid;

namespace USL
{
    public partial class StockOutBillPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail,IExtensions
    {
        StockOutBillHd hd;
        List<StockOutBillDtl> dtl;
        List<StockOutBillDtl> dtlByBOM;
        List<Warehouse> warehouseList;
        //PageGroup pageGroupCore;
        Guid headID;
        String billType;
        List<TypesList> types;   //类型列表
        //bool isSLSalePrice = false;
        //int goodsType = 0;
        BOMType bomType;
        int businessContactType = 0;

        public StockOutBillHd Hd
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

        public StockOutBillPage(Guid hdID, String type)
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
            if (type == MainMenuConstants.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
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
                if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory && ((billType == MainMenuConstants.EMSStockOutBill && lueType.ItemIndex == 0 || lueType.ItemIndex == -1)
                    || (billType == MainMenuConstants.GetMaterialBill && lueType.EditValue != null && Convert.ToInt32(lueType.EditValue) == 3)
                    || billType == MainMenuConstants.EMSDPReturnBill || billType == MainMenuConstants.FSMDPReturnBill))
                {
                    colQty.Caption = "重量";
                    colModulus.Visible = true;
                    colCounts.Visible = true;
                }
                //else if (billType == MainMenuConstants.EMSStockOutBill && lueType.ItemIndex == 0 || lueType.ItemIndex == -1)
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
            if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory && billType == MainMenuConstants.GetMaterialBill)
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

        public void BindData(Guid hdID)
        {
            if (hdID != Guid.Empty)
            {
                headID = hdID;
                stockOutBillHdBindingSource.DataSource = hd = BLLFty.Create<StockOutBillBLL>().GetStockOutBillHd(hdID);
                stockOutBillDtlBindingSource.DataSource = dtl = BLLFty.Create<StockOutBillBLL>().GetStockOutBillDtl(hdID);
                if (billType == MainMenuConstants.EMSStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1) ||
                    billType == MainMenuConstants.FSMDPReturnBill)
                    billDtlByBOMBindingSource.DataSource = dtlByBOM = BLLFty.Create<StockOutBillBLL>().GetVStockOutBillDtlByBOM(hdID, (int)BOMType.Assemble);
                else
                    billDtlByBOMBindingSource.DataSource = dtlByBOM = new List<StockOutBillDtl>();
            }
            types = MainForm.dataSourceList[typeof(List<TypesList>)] as List<TypesList>;
            //单据类型
            if (billType == MainMenuConstants.GetMaterialBill)
            {
                if (MainForm.ISnowSoftVersion == ISnowSoftVersion.PurchaseSellStock)
                    typesListBindingSource.DataSource = types.FindAll(o => o.Type == MainMenuConstants.StockOutBillType && o.No == 6);
                else if (MainForm.ISnowSoftVersion == ISnowSoftVersion.EMS)
                    typesListBindingSource.DataSource = types.FindAll(o => o.Type == MainMenuConstants.StockOutBillType && (o.No == 3 || o.No == 6));
                else if (MainForm.ISnowSoftVersion == ISnowSoftVersion.FSM)
                    typesListBindingSource.DataSource = types.FindAll(o => o.Type == MainMenuConstants.StockOutBillType && (o.No == 5 || o.No == 6));
                else if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                    typesListBindingSource.DataSource = types.FindAll(o => o.Type == MainMenuConstants.StockOutBillType && (o.No == 3 || o.No == 5 || o.No == 6));
                else
                    typesListBindingSource.DataSource = types.FindAll(o => o.Type == MainMenuConstants.StockOutBillType && (o.No == 3));
            }
            else if (billType == MainMenuConstants.EMSStockOutBill && MainForm.SysInfo.CompanyType == (int)CompanyType.Trade)
            {
                typesListBindingSource.DataSource = types.FindAll(o => o.Type == MainMenuConstants.StockOutBillType && o.No == 3);
            }
            else if (MainForm.ISnowSoftVersion == ISnowSoftVersion.Sales || MainForm.ISnowSoftVersion == ISnowSoftVersion.SalesManagement)
                typesListBindingSource.DataSource = types.FindAll(o => o.SubType == billType && o.No == 0);
            else
                typesListBindingSource.DataSource = types.FindAll(o => o.SubType == billType);
            //仓库类型
            warehouseTypeBindingSource.DataSource = types.FindAll(o => o.Type == TypesListConstants.CustomerType);
            warehouseBindingSource.DataSource = warehouseList = MainForm.dataSourceList[typeof(List<Warehouse>)] as List<Warehouse>;
            vGoodsBindingSource.DataSource = null;
            if (billType == MainMenuConstants.EMSStockOutBill)
            {
                if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                {
                    if ((lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                    {
                        if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                            vGoodsBindingSource.DataSource = ((List<VGoodsByBOM>)MainForm.dataSourceList[typeof(List<VGoodsByBOM>)]).FindAll(o => o.类型 == (int)BOMType.BOM);
                        else
                            vGoodsBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VGoods>)];
                    }
                    else if (lueType.ItemIndex == 1)
                    {
                        if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                            vGoodsBindingSource.DataSource = ((List<VGoodsByBOM>)MainForm.dataSourceList[typeof(List<VGoodsByBOM>)]).FindAll(o => o.类型 == (int)BOMType.Assemble);
                        else
                            vGoodsBindingSource.DataSource = ((List<VGoodsByBOM>)MainForm.dataSourceList[typeof(List<VGoodsByBOM>)]).FindAll(o => o.类型 == (int)BOMType.Assemble || o.类型 == (int)BOMType.BOM);
                    }
                }
                else
                    vGoodsBindingSource.DataSource = ((List<VGoodsByBOM>)MainForm.dataSourceList[typeof(List<VGoodsByBOM>)]).FindAll(o => o.类型 == (int)BOMType.Assemble || o.类型 == (int)BOMType.BOM);
            }
            else
            {
                if (billType == MainMenuConstants.FGStockOutBill)
                {
                    if ((lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                    {
                        vGoodsBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VGoods>)];
                        if (!string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))
                            orderHdBindingSource.DataSource = BLLFty.Create<OrderBLL>().GetOrderHd().FindAll(o => o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Status == 1);
                    }
                    else
                        vGoodsBindingSource.DataSource = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type == (int)GoodsBigType.SFGoods);
                }
                else if (billType == MainMenuConstants.FSMStockOutBill)
                    vGoodsBindingSource.DataSource = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type == (int)GoodsBigType.Material || o.Type == (int)GoodsBigType.Basket);
                else if (billType == MainMenuConstants.FSMDPReturnBill || billType == MainMenuConstants.EMSDPReturnBill)
                    vGoodsBindingSource.DataSource = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type == (int)GoodsBigType.Stuff || o.Type == (int)GoodsBigType.Basket);
                else if (billType == MainMenuConstants.SFGStockOutBill)
                    vGoodsBindingSource.DataSource = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type > 0);
                else if (billType == MainMenuConstants.GetMaterialBill)
                {
                    switch (Convert.ToInt32(lueType.EditValue))
                    {
                        case 3:
                            if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                                vGoodsBindingSource.DataSource = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type == (int)GoodsBigType.Stuff || o.Type == (int)GoodsBigType.Basket);
                            else
                                vGoodsBindingSource.DataSource = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]);
                            break;
                        case 5:
                            vGoodsBindingSource.DataSource = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type == (int)GoodsBigType.Material || o.Type == (int)GoodsBigType.Basket);
                            break;
                        case 6:
                            vGoodsBindingSource.DataSource = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type == (int)GoodsBigType.SFGoods || o.Type == (int)GoodsBigType.Stuff || o.Type == (int)GoodsBigType.Mold);
                            break;
                        default:
                            break;
                    }
                }
            }
            vGoodsByBOMBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VGoodsByBOM>)];
            vUsersInfoBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VUsersInfo>)];
            if (billType == MainMenuConstants.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
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
            stockOutBillHdBindingSource.DataSource = hd = new StockOutBillHd();
            stockOutBillDtlBindingSource.DataSource = dtl = new List<StockOutBillDtl>();            
            gridView.AddNewRow();
            gridView.FocusedColumn = colGoodsID;
            //string no = BLLFty.Create<StockOutBillBLL>().GetMaxBillNo();
            //if (no == null)
            //    hd.BillNo = "CK" + DateTime.Now.ToString("yyyyMMdd") + "001";
            //else
            //{
            //    if (no.Substring(2, 8).Equals(DateTime.Now.ToString("yyyyMMdd")))
            //        hd.BillNo = "CK" + DateTime.Now.ToString("yyyyMMdd") + Convert.ToString(int.Parse(no.Substring(10, 3)) + 1).PadLeft(3, '0');
            //    else
            //        hd.BillNo = "CK" + DateTime.Now.ToString("yyyyMMdd") + "001";
            //}
            hd.BillNo = MainForm.GetBillMaxBillNo(MainMenuConstants.StockOutBillType, "CK");
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
                    if (hd != null)
                    {
                        StockOutBillHd dCheck = BLLFty.Create<StockOutBillBLL>().GetStockOutBillHd(hd.ID);
                        if (dCheck.Status == (int)BillStatus.UnAudited)
                            BLLFty.Create<StockOutBillBLL>().Delete(hd.ID);
                        else
                        {
                            CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "该单据已审核，不允许删除。");
                            return;
                        }

                    }
                    ////DataQueryPageRefresh();
                    //刷新查询界面
                    MainForm.DataQueryPageRefresh();
                    //DataQueryPage page = MainForm.itemDetailList[billType + "Query"] as DataQueryPage;
                    //MainForm.GetDataSource();
                    //page.InitGrid(MainForm.GetData(billType + "Query"));
                    stockOutBillHdBindingSource.DataSource = hd = new StockOutBillHd();
                    stockOutBillDtlBindingSource.DataSource = dtl = new List<StockOutBillDtl>();
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
                Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID.Equals(dtl[i].GoodsID));
                //获取或设置客户商品售价
                //if (isSLSalePrice && lueBusinessContact.Enabled == true)
                if (lueBusinessContact.Enabled == true && !string.IsNullOrEmpty(lueBusinessContact.Text.Trim()) && billType != MainMenuConstants.FSMDPReturnBill && billType != MainMenuConstants.FSMDPReturnBill)
                {
                    // SLSalePrice cSLSalePrice = ((List<SLSalePrice>)MainForm.dataSourceList[typeof(List<SLSalePrice>)]).Find(o =>
                    //o.CustomerID == new Guid(lueBusinessContact.EditValue.ToString()) && o.GoodsID == dtl[i].GoodsID);
                    if (billType == MainMenuConstants.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
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
                        obj.Type = businessContactType;
                        obj.Price = dtl[i].Price.Value;
                        obj.PriceNoTax = dtl[i].PriceNoTax;
                        obj.Discount = dtl[i].Discount == 0 ? 1 : dtl[i].Discount.Value;
                        obj.OtherFee = dtl[i].OtherFee.Value;
                        BLLFty.Create<SLSalePriceBLL>().Insert(obj);
                    }
                    else if (cSLSalePrice.Price != dtl[i].Price || cSLSalePrice.Discount != dtl[i].Discount || cSLSalePrice.OtherFee != dtl[i].OtherFee)
                    {
                        cSLSalePrice.Price = dtl[i].Price.Value;
                        cSLSalePrice.PriceNoTax = dtl[i].PriceNoTax;
                        cSLSalePrice.Discount = dtl[i].Discount == 0 ? 1 : dtl[i].Discount.Value;
                        cSLSalePrice.OtherFee = dtl[i].OtherFee.Value;
                        BLLFty.Create<SLSalePriceBLL>().Update(cSLSalePrice);
                    }
                }
                //if (MainForm.ISnowSoftVersion != ISnowSoftVersion.Procurement && MainForm.ISnowSoftVersion != ISnowSoftVersion.Sales)
                //{
                //    if (status == BillStatus.Audited && (billType == MainMenuConstants.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1)))
                //    {
                //        //List<Inventory> lst = BLLFty.Create<InventoryBLL>().GetInventory(hd.WarehouseID, dtl[i].GoodsID, dtl[i].PCS);
                //        List<VInventoryGroupByGoods> list = ((List<VInventoryGroupByGoods>)MainForm.dataSourceList[typeof(List<VInventoryGroupByGoods>)]).FindAll(o =>
                //            o.GoodsID.Equals(dtl[i].GoodsID) && o.装箱数 == dtl[i].PCS);
                //        //Company company = ((List<Company>)MainForm.dataSourceList[typeof(List<Company>)]).FirstOrDefault(o => o.ID == hd.CompanyID);
                //        //if (company != null && company.Type == (int)CustomerType.DomesticSales)
                //        if (!string.IsNullOrEmpty(lueWarehouseType.Text.Trim()))
                //        {
                //            if (list.Count >= 0 && (list.Where(o => o.仓库类型 == Convert.ToInt32(lueWarehouseType.EditValue)).Sum(o => o.箱数) - dtl[i].Qty) < 0)
                //            {
                //                string msg = string.Empty;
                //                if (goods == null)
                //                {
                //                    //msg = "货品没有库存，不允许出库！";
                //                    msg = "货品没有库存，是否继续出库？";
                //                    //CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), msg);
                //                }
                //                else
                //                {
                //                    msg = string.Format("货品[{0}]出库数量大于现库存数量，是否继续出库？", goods.Code);
                //                    //CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(),msg);
                //                }
                //                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(msg, "操作提示",
                //                System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                //                if (result == System.Windows.Forms.DialogResult.Yes)
                //                    flag = true;
                //                else
                //                    flag = false;
                //            }
                //        }
                //        //if (!string.IsNullOrEmpty(lueWarehouseType.Text.Trim()) && Convert.ToInt32(lueWarehouseType.EditValue) == (int)CustomerType.DomesticSales)
                //        //{
                //        //    if (list.Count >= 0 && (list.Where(o => o.仓库类型 == (int)CustomerType.DomesticSales).Sum(o => o.箱数) - dtl[i].Qty) < 0)
                //        //    {
                //        //        if (goods == null)
                //        //            CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "货品没有库存，不允许出库！");
                //        //        else
                //        //            CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("货品[{0}]出库数量大于现库存数量，不允许出库！", goods.Code));
                //        //        flag = false;
                //        //    }
                //        //}
                //        //else
                //        //{
                //        //    if (list.Count >= 0 && (list.Sum(o => o.箱数) - dtl[i].Qty) < 0)
                //        //    {
                //        //        if (goods == null)
                //        //            CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "货品没有库存，不允许出库！");
                //        //        else
                //        //            CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("货品[{0}]出库数量大于现库存数量，不允许出库！", goods.Code));
                //        //        flag = false;
                //        //    }
                //        //}
                //        ////if (flag==false)
                //        //{
                //        //    if (goods == null)
                //        //        CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "货品没有库存，不允许出库！");
                //        //    else
                //        //        CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("货品[{0}]出库数量大于现库存数量，不允许出库！", goods.Code));
                //        //    //flag = false;
                //        //}
                //    }
                //}

                if (billType != MainMenuConstants.FGStockOutBill)
                {
                    if (goods.NWeight != dtl[i].NWeight)
                    {
                        goods.NWeight = dtl[i].NWeight.Value;
                        BLLFty.Create<GoodsBLL>().Update(goods);
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
            //if (billType == MainMenuConstants.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1) && hd.Status != 1 && !string.IsNullOrEmpty(lueOrderNo.Text.Trim()))
            //{
            //    for (int i = 0; i < gridView.RowCount; i++)
            //    {
            //        decimal qty = gridView.GetRowCellValue(i, colQty) == null ? 0 : Convert.ToDecimal(gridView.GetRowCellValue(i, colQty));
            //        decimal orderQty = gridView.GetRowCellValue(i, colOrderQty) == null ? 0 : Convert.ToDecimal(gridView.GetRowCellValue(i, colOrderQty));
            //        if (orderQty - qty < 0)
            //        {
            //            CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "发货箱数不能大于未发货箱数");
            //            flag = false;
            //        }
            //    }
            //}
            return flag;
        }

        public bool Save()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                gridView.CloseEditForm();
                hd = stockOutBillHdBindingSource.DataSource as StockOutBillHd;
                dtl = stockOutBillDtlBindingSource.DataSource as List<StockOutBillDtl>;
                if (string.IsNullOrEmpty(txtBillNo.Text.Trim()))
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "单据编号不能为空，请点击添加按钮添加单据。");
                    return false;
                }
                if (billType == MainMenuConstants.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                    hd.WarehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.FG).ID;  //成品仓
                else
                    hd.WarehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.SFG).ID;  //半成品
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
                    BLLFty.Create<StockOutBillBLL>().Insert(hd, dtl);
                }
                else//修改
                    BLLFty.Create<StockOutBillBLL>().Update(hd, dtl);
                headID = hd.ID;
                //DataQueryPageRefresh();
                if (billType == MainMenuConstants.EMSStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1) ||
                    billType == MainMenuConstants.FSMDPReturnBill)
                    billDtlByBOMBindingSource.DataSource = dtlByBOM = BLLFty.Create<StockOutBillBLL>().GetVStockOutBillDtlByBOM(hd.ID, (int)BOMType.Assemble);
                else
                    billDtlByBOMBindingSource.DataSource = dtlByBOM = new List<StockOutBillDtl>();
                MainForm.BillSaveRefresh(billType + "Query");
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
                    if (billType == MainMenuConstants.EMSStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                    {
                        dtlList = dtlByBOM = BLLFty.Create<StockOutBillBLL>().GetVStockOutBillDtlByBOM(hd.ID, (int)BOMType.Assemble);
                    }
                    else
                        dtlList = dtl = BLLFty.Create<StockOutBillBLL>().GetStockOutBillDtl(hd.ID);
                    //删除提醒信息
                    Alert alertBill = ((List<Alert>)MainForm.dataSourceList[typeof(List<Alert>)]).Find(o => o.BillID == hd.ID);
                    if (alertBill != null)
                        dellist.Add(alertBill);
                    foreach (StockOutBillDtl dtlItem in dtlList)
                    {
                        if (MainForm.ISnowSoftVersion == ISnowSoftVersion.Procurement || MainForm.ISnowSoftVersion == ISnowSoftVersion.Sales)
                            continue;  //不处理库存
                        Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID.Equals(dtlItem.GoodsID));
                        //库存数据
                        Inventory ity = new Inventory();
                        ity.ID = Guid.NewGuid();
                        ity.WarehouseID = hd.WarehouseID;
                        ity.WarehouseType = hd.WarehouseType;
                        ity.CompanyID = hd.CompanyID;
                        ity.SupplierID = hd.SupplierID;
                        ity.DeptID = hd.DeptID;
                        ity.GoodsID = dtlItem.GoodsID;
                        //if (billType == MainMenuConstants.SFGStockOutBill || billType == MainMenuConstants.GetMaterialBill)
                        //{
                        //    switch (goods.Unit.ToUpper())
                        //    {
                        //        case "吨":
                        //        case "T":
                        //            ity.Qty = -dtlItem.Qty * 1000000;
                        //            break;
                        //        case "斤":
                        //            ity.Qty = -dtlItem.Qty * 500;
                        //            break;
                        //        case "公斤":
                        //        case "KG":
                        //            ity.Qty = -dtlItem.Qty * 1000;
                        //            break;
                        //        case "米":
                        //        case "M":
                        //            ity.Qty = -dtlItem.Qty * 100; //米转厘米
                        //            break;
                        //        default:
                        //            ity.Qty = -dtlItem.Qty;
                        //            break;
                        //    }
                        //}
                        //else
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
                        //if (billType == MainMenuConstants.SFGStockInBill || billType == MainMenuConstants.ReturnedMaterialBill)
                        //{
                        //    switch (goods.Unit.ToUpper())
                        //    {
                        //        case "吨":
                        //        case "T":
                        //            ab.OutQty = dtlItem.Qty * 1000000;
                        //            break;
                        //        case "斤":
                        //            ab.OutQty = dtlItem.Qty * 500;//转成克
                        //            break;
                        //        case "公斤":
                        //        case "KG":
                        //            ab.OutQty = dtlItem.Qty * 1000;//转成克
                        //            break;
                        //        case "米":
                        //        case "M":
                        //            ab.OutQty = dtlItem.Qty * 100; //米转厘米
                        //            break;
                        //        default:
                        //            ab.OutQty = dtlItem.Qty;
                        //            break;
                        //    }
                        //}
                        //else
                        ab.OutQty = Math.Abs(ity.Qty);
                        List<Inventory> lst = null;
                        if (billType == MainMenuConstants.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
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
                                Alert alert = ((List<Alert>)MainForm.dataSourceList[typeof(List<Alert>)]).Find(o => o.GoodsID == dtlItem.GoodsID);
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
                        if (billType == MainMenuConstants.EMSStockOutBill || billType == MainMenuConstants.FSMStockOutBill ||
                            (billType==MainMenuConstants.GetMaterialBill &&Convert.ToInt32(lueType.EditValue)!=6))
                        {
                            //库存数据
                            ity = new Inventory();
                            ity.ID = Guid.NewGuid();
                            ity.WarehouseID = (billType == MainMenuConstants.EMSStockOutBill || (billType == MainMenuConstants.GetMaterialBill && Convert.ToInt32(lueType.EditValue) == 3))
                                ? warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.EMS).ID : warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.FSM).ID;
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
                    if (billType == MainMenuConstants.FSMDPReturnBill)
                    {
                        foreach (StockOutBillDtl dbItem in dtlByBOM)
                        {
                            //库存数据
                            Inventory ity = new Inventory();
                            ity.ID = Guid.NewGuid();
                            ity.WarehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.FSM).ID;
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
                MainForm.BillSaveRefresh(billType + "Query");
                MainForm.InventoryRefresh();
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
                if (billType == MainMenuConstants.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
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
                    List<TypesList> types = MainForm.dataSourceList[typeof(List<TypesList>)] as List<TypesList>;
                    string customerAddress = string.Empty;
                    string logisticsAddress = string.Empty;
                    string logisticsTel = string.Empty;
                    Company customer = ((List<Company>)MainForm.dataSourceList[typeof(List<Company>)]).Find(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString()));
                    if (customer != null)
                    {
                        customerAddress = customer.Address;
                        logisticsAddress = customer.LogisticsAddress;
                        logisticsTel = customer.LogisticsTel;
                    }
                    if (billType == MainMenuConstants.GetMaterialBill)
                        psc.PrintHeader = types.Find(o => o.Type == MainMenuConstants.StockOutBillType && o.No == hd.Type).Name + "单";
                    else
                        psc.PrintHeader = types.Find(o => o.SubType == billType && o.No == hd.Type).Name + "单";
                    psc.PrintSubTitle = MainForm.Contacts.Replace("\\r\\n", "\r\n");
                    if (billType == MainMenuConstants.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
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
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "没有可打印的数据");
            }
            finally
            {
                if (billType == MainMenuConstants.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
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
                if ((billType == MainMenuConstants.EMSStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1)) && MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)//成套领料
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
                else if ((billType == MainMenuConstants.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1)) 
                    || (MainForm.SysInfo.CompanyType == (int)CompanyType.Trade && (billType == MainMenuConstants.EMSStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))))
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
                        //if (((List<Company>)MainForm.dataSourceList[typeof(List<Company>)]).Exists(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == (int)CustomerType.DomesticSales))
                        if (((List<Company>)MainForm.dataSourceList[typeof(List<Company>)]).Exists(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString())))
                        {
                            //获取或设置客户商品售价
                            SLSalePrice cSLSalePrice = ((List<SLSalePrice>)MainForm.dataSourceList[typeof(List<SLSalePrice>)]).Find(o =>
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
                        //if (((List<Supplier>)MainForm.dataSourceList[typeof(List<Supplier>)]).Exists(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Type == (int)SupplierType.Purchase))
                        if (((List<Supplier>)MainForm.dataSourceList[typeof(List<Supplier>)]).Exists(o => o.ID == new Guid(lueBusinessContact.EditValue.ToString())))
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
            if (billType == MainMenuConstants.FGStockOutBill)
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
            else if (billType == MainMenuConstants.GetMaterialBill && Convert.ToInt32(lueType.EditValue) == 6)
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
                case MainMenuConstants.FGStockOutBill:
                    this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockOutBillHdBindingSource, "CompanyID", true));
                    businessContactBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VCompany>)];
                    if ((lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                    {
                        vGoodsBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VGoods>)];
                        if (!string.IsNullOrEmpty(lueBusinessContact.Text.Trim()))
                            orderHdBindingSource.DataSource = BLLFty.Create<OrderBLL>().GetOrderHd().FindAll(o => o.CompanyID == new Guid(lueBusinessContact.EditValue.ToString()) && o.Status == 1);
                        SetDtlHeader(true);
                        lueWarehouseType.Enabled = true;
                        lueOrderNo.Enabled = true;
                    }
                    else
                    {
                        vGoodsBindingSource.DataSource = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type == 1);
                        SetDtlHeader(false);
                    }
                    break;
                case MainMenuConstants.EMSStockOutBill:
                    this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockOutBillHdBindingSource, "SupplierID", true));
                    businessContactBindingSource.DataSource = ((List<VSupplier>)MainForm.dataSourceList[typeof(List<VSupplier>)]).FindAll(o => o.供应商类型 == (int)SupplierType.EMS);
                    //成套领料货品明细控制
                    stockOutBillDtlBindingSource.DataSource = dtl = new List<StockOutBillDtl>();
                    billDtlByBOMBindingSource.DataSource = dtlByBOM = new List<StockOutBillDtl>();
                    gridView.AddNewRow();
                    if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                    {
                        if ((lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                        {
                            if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                                vGoodsBindingSource.DataSource = ((List<VGoodsByBOM>)MainForm.dataSourceList[typeof(List<VGoodsByBOM>)]).FindAll(o => o.类型 == (int)BOMType.BOM);
                            else
                                vGoodsBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VGoods>)];
                        }
                        else if (lueType.ItemIndex == 1)
                        {
                            if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                                vGoodsBindingSource.DataSource = ((List<VGoodsByBOM>)MainForm.dataSourceList[typeof(List<VGoodsByBOM>)]).FindAll(o => o.类型 == (int)BOMType.Assemble);
                            else
                                vGoodsBindingSource.DataSource = ((List<VGoodsByBOM>)MainForm.dataSourceList[typeof(List<VGoodsByBOM>)]).FindAll(o => o.类型 == (int)BOMType.Assemble || o.类型 == (int)BOMType.BOM);
                        }
                    }
                    else
                        vGoodsBindingSource.DataSource = ((List<VGoodsByBOM>)MainForm.dataSourceList[typeof(List<VGoodsByBOM>)]).FindAll(o => o.类型 == (int)BOMType.Assemble || o.类型 == (int)BOMType.BOM);
                    break;
                case MainMenuConstants.SFGStockOutBill:
                case MainMenuConstants.FSMStockOutBill:
                case MainMenuConstants.GetMaterialBill:
                case MainMenuConstants.FSMDPReturnBill:
                case MainMenuConstants.EMSDPReturnBill:
                    if (billType == MainMenuConstants.GetMaterialBill)
                    {
                        switch (Convert.ToInt32(lueType.EditValue))
                        {
                            case 3:
                                this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockOutBillHdBindingSource, "SupplierID", true));
                        businessContactBindingSource.DataSource = ((List<VSupplier>)MainForm.dataSourceList[typeof(List<VSupplier>)]).FindAll(o =>
                            o.供应商类型 == (billType == MainMenuConstants.SFGStockOutBill ? (int)SupplierType.Purchase : (int)SupplierType.EMS));
                                break;
                            case 5:
                                this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockOutBillHdBindingSource, "SupplierID", true));
                        businessContactBindingSource.DataSource = ((List<VSupplier>)MainForm.dataSourceList[typeof(List<VSupplier>)]).FindAll(o =>
                            o.供应商类型 == (billType == MainMenuConstants.SFGStockOutBill ? (int)SupplierType.Purchase : (int)SupplierType.FSM));
                                break;
                            case 6:
                                this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockOutBillHdBindingSource, "DeptID", true));
                                businessContactBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VDepartment>)];
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        SupplierType sType = SupplierType.Purchase;
                        if (billType == MainMenuConstants.SFGStockInBill)
                            sType = SupplierType.Purchase;
                        else if (billType == MainMenuConstants.FSMDPReturnBill)
                            sType = SupplierType.FSM;
                        else if (billType == MainMenuConstants.EMSDPReturnBill)
                            sType = SupplierType.EMS;
                        this.lueBusinessContact.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.stockOutBillHdBindingSource, "SupplierID", true));
                        businessContactBindingSource.DataSource = ((List<VSupplier>)MainForm.dataSourceList[typeof(List<VSupplier>)]).FindAll(o =>
                            o.供应商类型 == (int)sType);
                    }
                    if (billType == MainMenuConstants.FSMStockOutBill)
                        vGoodsBindingSource.DataSource = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type == (int)GoodsBigType.Material || o.Type == (int)GoodsBigType.Basket);
                    else if (billType == MainMenuConstants.SFGStockOutBill)
                        vGoodsBindingSource.DataSource = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type >0);
                    else if (billType == MainMenuConstants.FSMDPReturnBill || billType == MainMenuConstants.EMSDPReturnBill)
                        vGoodsBindingSource.DataSource = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type == (int)GoodsBigType.Stuff || o.Type == (int)GoodsBigType.Basket);
                    else if (billType == MainMenuConstants.GetMaterialBill)
                    {
                        switch (Convert.ToInt32(lueType.EditValue))
                        {
                            case 3:
                                if (MainForm.SysInfo.CompanyType == (int)CompanyType.Factory)
                                    vGoodsBindingSource.DataSource = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type == (int)GoodsBigType.Stuff || o.Type == (int)GoodsBigType.Basket);
                                else
                                    vGoodsBindingSource.DataSource = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type > (int)GoodsBigType.Goods);
                                break;
                            case 5:
                                vGoodsBindingSource.DataSource = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type == (int)GoodsBigType.Material || o.Type == (int)GoodsBigType.Basket);
                                break;
                            case 6:
                                vGoodsBindingSource.DataSource = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type == (int)GoodsBigType.SFGoods || o.Type == (int)GoodsBigType.Stuff || o.Type == (int)GoodsBigType.Mold);
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
                //if (billType == MainMenuConstants.FGStockOutBill && (lueType.ItemIndex == 0 || lueType.ItemIndex == -1))
                //{
                //    VStockOutBill goods = ((List<VStockOutBill>)MainForm.dataSourceList[typeof(List<VStockOutBill>)]).Find(o => o.GoodsID == list[e.ListSourceRowIndex].GoodsID && o.装箱数 == list[e.ListSourceRowIndex].PCS);
                //    if (goods != null)
                //    {
                //        if (e.Column == colName)
                //            e.Value = goods.品名;
                //        if (e.Column == colPackaging && !string.IsNullOrEmpty(goods.包装方式))
                //            e.Value = ((List<Packaging>)MainForm.dataSourceList[typeof(List<Packaging>)]).Find(o => o.Name == goods.包装方式).Name;
                //        if (e.Column == colSPEC)
                //            e.Value = goods.规格;
                //        if (e.Column == colUnit)
                //            e.Value = goods.单位;
                //        if (e.Column == colRemark)
                //            e.Value = goods.备注;
                //        if (e.Column == colOrderQty && !string.IsNullOrEmpty(lueOrderNo.Text.Trim()) && new Guid(lueOrderNo.EditValue.ToString()) != Guid.Empty)
                //        {
                //            VOrder order = ((List<VOrder>)MainForm.dataSourceList[typeof(List<VOrder>)]).FirstOrDefault(o => o.HdID == new Guid(lueOrderNo.EditValue.ToString()) && o.货号 == goods.货号 && o.装箱数 == goods.装箱数);
                //            if (order != null)
                //                e.Value = order.箱数 - ((List<VStockOutBill>)MainForm.dataSourceList[typeof(List<VStockOutBill>)]).Where(o => o.订单编号 == lueOrderNo.Text.Trim() && o.状态 > 0 && o.货号 == goods.货号 && o.装箱数 == goods.装箱数).Sum(o => o.箱数);
                //        }
                //    }
                //}
                //else
                //{
                    Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID == list[e.ListSourceRowIndex].GoodsID);
                    if (goods != null)
                    {
                        if (e.Column == colName)
                            e.Value = goods.Name;
                    if (e.Column == colPackaging && goods.PackagingID != null && goods.PackagingID != Guid.Empty)
                            e.Value = ((List<Packaging>)MainForm.dataSourceList[typeof(List<Packaging>)]).Find(o => o.ID == goods.PackagingID).Name;
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
                List<StockOutBillHd> bills = ((List<StockOutBillHd>)MainForm.dataSourceList[typeof(List<StockOutBillHd>)]).FindAll(o => o.Type == (int)lueType.EditValue).OrderBy(o => o.BillNo).ToList();
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
                List<StockOutBillHd> bills = ((List<StockOutBillHd>)MainForm.dataSourceList[typeof(List<StockOutBillHd>)]).FindAll(o => o.Type == (int)lueType.EditValue).OrderBy(o => o.BillNo).ToList();
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
