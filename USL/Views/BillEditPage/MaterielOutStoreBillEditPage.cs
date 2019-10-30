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

namespace USL
{
    public partial class MaterielOutStoreBillEditPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail
    {
        MaterielOutStoreBillHd hd;
        List<MaterielOutStoreBillDtl> dtl;
        List<MaterielOutStoreBillDtl> dtlByBOM;
        List<Warehouse> warehouseList;
        PageGroup pageGroupCore;
        Guid headID;
        List<TypesList> types;   //类型列表
        public MaterielOutStoreBillEditPage(Guid hdID, PageGroup child)
        {
            InitializeComponent();
            headID = hdID;
            pageGroupCore = child;
            BindData(headID);
        }

        public void BindData(Guid hdID)
        {

            if (hdID != Guid.Empty)
            {
                headID = hdID;
                materielOutStoreBillHdBindingSource.DataSource = hd = BLLFty.Create<MaterielOutStoreBillBLL>().GetMaterielOutStoreBillHd(hdID);
                materielOutStoreBillDtlBindingSource.DataSource = dtl = BLLFty.Create<MaterielOutStoreBillBLL>().GetMaterielOutStoreBillDtl(hdID);
                if (lueBillType.ItemIndex == 0)
                    billDtlByBOMBindingSource.DataSource = dtlByBOM = BLLFty.Create<MaterielOutStoreBillBLL>().GetVBillDtlByBOM(hdID);
                else
                    billDtlByBOMBindingSource.DataSource = dtlByBOM = new List<MaterielOutStoreBillDtl>();
            }
            vSupplierBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VSupplier>)];
            types = MainForm.dataSourceList[typeof(List<TypesList>)] as List<TypesList>;
            //单据类型
            typeBindingSource.DataSource = types.FindAll(o => o.Type == TypesListConstants.MaterielOutStoreBillType);
            warehouseList = MainForm.dataSourceList[typeof(List<Warehouse>)] as List<Warehouse>;
            if (lueBillType.ItemIndex == 0)
                vGoodsBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VGoodsByBOM>)];
            else
                vGoodsBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VGoods>)];
            goodsByBOMBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VGoods>)];
            vUsersInfoBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VUsersInfo>)];
        }

        //刷新查询列表数据——只供删除单据时使用
        void DataQueryPageRefresh()
        {
            BaseContentContainer documentContainer = pageGroupCore.Parent as BaseContentContainer;
            if (documentContainer != null)
            {
                WindowsUIView view = documentContainer.Manager.View as WindowsUIView;
                if (view != null)
                {
                    ItemDetailPage itemDetailPage = null;
                    foreach (BaseDocument doc in view.Documents)
                    {
                        if (doc.Control is ItemDetailPage)
                        {
                            itemDetailPage = (ItemDetailPage)doc.Control;
                            break;
                        }

                    }
                    //更新查询列表数据
                    DataQueryPage page = itemDetailPage.itemDetailList[MainMenuConstants.MaterielOutStoreBillQuery] as DataQueryPage;
                    MainForm.dataSourceList[typeof(List<VMaterielOutStoreBill>)] = BLLFty.Create<MaterielOutStoreBillBLL>().GetMaterielOutStoreBill();
                    IList list = MainForm.dataSourceList[typeof(List<VMaterielOutStoreBill>)] as IList;
                    page.InitGrid(list);
                }
            }
        }

        public void Add()
        {
            materielOutStoreBillHdBindingSource.DataSource = hd = new MaterielOutStoreBillHd();
            materielOutStoreBillDtlBindingSource.DataSource = dtl = new List<MaterielOutStoreBillDtl>();
            billDtlByBOMBindingSource.DataSource = dtlByBOM = new List<MaterielOutStoreBillDtl>();
            gridView.AddNewRow();
            string no = BLLFty.Create<MaterielOutStoreBillBLL>().GetMaxBillNo();
            if (no == null)
                hd.BillNo = "MCK" + DateTime.Now.ToString("yyyyMMdd") + "001";
            else
            {
                if (no.Substring(3, 8).Equals(DateTime.Now.ToString("yyyyMMdd")))
                    hd.BillNo = "MCK" + DateTime.Now.ToString("yyyyMMdd") + Convert.ToString(int.Parse(no.Substring(11, 3)) + 1).PadLeft(3, '0');
                else
                    hd.BillNo = "MCK" + DateTime.Now.ToString("yyyyMMdd") + "001";
            }
            headID = Guid.Empty;
            deDeliveryDate.Focus();
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
                        BLLFty.Create<MaterielOutStoreBillBLL>().Delete(hd.ID);
                    DataQueryPageRefresh();
                    materielOutStoreBillHdBindingSource.DataSource = hd = new MaterielOutStoreBillHd();
                    materielOutStoreBillDtlBindingSource.DataSource = dtl = new List<MaterielOutStoreBillDtl>();
                    billDtlByBOMBindingSource.DataSource = dtlByBOM = new List<MaterielOutStoreBillDtl>();
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

        public bool Save()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                bool flag = false;
                if (hd == null)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请完整填写表头信息");
                    flag = true;
                }
                if (dtl == null)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请完整填写货品信息");
                    flag = true;
                }
                if (flag)
                    return false;
                hd.Maker = MainForm.usersInfo.ID;
                hd.MakeDate = DateTime.Now;
                hd.WarehouseID = warehouseList[1].ID;  //半成品出库
                //添加
                if (headID == Guid.Empty)
                {
                    hd.ID = Guid.NewGuid();
                    foreach (MaterielOutStoreBillDtl item in dtl)
                    {
                        item.ID = Guid.NewGuid();
                        item.HdID = hd.ID;
                    }
                    BLLFty.Create<MaterielOutStoreBillBLL>().Insert(hd, dtl);
                }
                else//修改
                    BLLFty.Create<MaterielOutStoreBillBLL>().Update(hd, dtl);
                headID = hd.ID;
                //DataQueryPageRefresh();
                CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "保存成功");
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

        public bool Audit()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (hd != null)
                {
                    hd.Auditor = MainForm.usersInfo.ID;
                    hd.AuditDate = DateTime.Now;
                    hd.Status = 1;

                    List<Inventory> inventorylist = new List<Inventory>();
                    List<AccountBook> accountBooklist = new List<AccountBook>();
                    Dictionary<Guid, Decimal> totaiQty = BLLFty.Create<InventoryBLL>().GetGoodsTotalQty();
                    //成套出库需将成品转为BOM对应的半成品
                    List<MaterielOutStoreBillDtl> dtlList = null;
                    if (lueBillType.ItemIndex == 0)
                    {
                        dtlList = dtlByBOM;
                    }
                    else
                        dtlList = dtl;
                    foreach (MaterielOutStoreBillDtl dtlItem in dtlList)
                    {
                        //库存数据
                        Inventory ity = new Inventory();
                        ity.ID = Guid.NewGuid();
                        ity.WarehouseID = hd.WarehouseID;
                        ity.GoodsID = dtlItem.GoodsID;
                        ity.Qty = -dtlItem.Qty;  //出库数量为负数
                        ity.PCS = dtlItem.PCS;
                        ity.InnerBox = dtlItem.InnerBox;
                        ity.Price = dtlItem.Price;
                        ity.EntryDate = DateTime.Now;
                        ity.BillNo = hd.BillNo;
                        ity.BillDate = hd.MakeDate;
                        inventorylist.Add(ity);
                        //账页数据
                        AccountBook ab = new AccountBook();
                        ab.ID = Guid.NewGuid();
                        ab.WarehouseID = hd.WarehouseID;
                        ab.GoodsID = dtlItem.GoodsID;
                        ab.AccntDate = DateTime.Now;
                        ab.Price = dtlItem.Price;
                        ab.OutQty = dtlItem.Qty;
                        if (totaiQty != null && totaiQty.ContainsKey(dtlItem.GoodsID))
                            ab.BalanceQty = totaiQty[dtlItem.GoodsID] - dtlItem.Qty;
                        else
                            ab.BalanceQty = dtlItem.Qty;
                        ab.BalanceCost = ab.BalanceQty * dtlItem.Price;
                        ab.BillNo = hd.BillNo;
                        ab.BillDate = hd.MakeDate;
                        accountBooklist.Add(ab);
                    }
                    BLLFty.Create<InventoryBLL>().Insert(hd, inventorylist, accountBooklist);
                }
                //DataQueryPageRefresh();
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
            throw new NotImplementedException();
        }

        private void gridView_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.Name == "colAMTNoTax" && new Guid(gridView.GetRowCellValue(gridView.FocusedRowHandle, colGoodsID).ToString()) != Guid.Empty)
            {
                gridView.AddNewRow();
            }
        }

        private void repositoryItemLueGoods_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBillType.ItemIndex == 0)
            {
                VGoodsByBOM goodsByBOM = ((LookUpEdit)sender).GetSelectedDataRow() as VGoodsByBOM;
                if (goodsByBOM != null)
                {
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colPCS, goodsByBOM.装箱数);
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colInnerBox, goodsByBOM.内盒);
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colPrice, goodsByBOM.单价);
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colPriceNoTax, goodsByBOM.去税单价);
                }
            }
            else
            {
                VGoods goods = ((LookUpEdit)sender).GetSelectedDataRow() as VGoods;
                if (goods != null)
                {
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colPCS, goods.装箱数);
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colInnerBox, goods.内盒);
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colPrice, goods.单价);
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colPriceNoTax, goods.去税单价);
                }
            }
        }

        private void gridView_CalcPreviewText(object sender, DevExpress.XtraGrid.Views.Grid.CalcPreviewTextEventArgs e)
        {
            Object obj = gridView.GetRowCellValue(e.RowHandle, colGoodsID);
            if (obj != null && new Guid(obj.ToString()) != Guid.Empty)
            {
                VGoods goods = ((List<VGoods>)MainForm.dataSourceList[typeof(List<VGoods>)]).Find(o => o.ID.Equals(new Guid(obj.ToString())));
                e.PreviewText = goods.品名 + (string.IsNullOrEmpty(goods.单位) ? "" : "    单位：" + goods.单位);
            }
        }

        private void gvBOM_CalcPreviewText(object sender, DevExpress.XtraGrid.Views.Grid.CalcPreviewTextEventArgs e)
        {
            Object obj = gvBOM.GetRowCellValue(e.RowHandle, colGoodsID);
            if (obj != null && new Guid(obj.ToString()) != Guid.Empty)
            {
                VGoods goods = ((List<VGoods>)MainForm.dataSourceList[typeof(List<VGoods>)]).Find(o => o.ID.Equals(new Guid(obj.ToString())));
                e.PreviewText = goods.品名 + (string.IsNullOrEmpty(goods.单位) ? "" : "    单位：" + goods.单位);
            }
        }
        private void lueSupplier_EditValueChanged(object sender, EventArgs e)
        {
            VSupplier supplier = ((LookUpEdit)sender).GetSelectedDataRow() as VSupplier;
            if (supplier != null && hd != null)
            {
                hd.SupplierID = supplier.ID;
                hd.Contacts = supplier.联系人;
            }
        }

        private void lueBillType_EditValueChanged(object sender, EventArgs e)
        {
            materielOutStoreBillDtlBindingSource.DataSource = dtl = new List<MaterielOutStoreBillDtl>();
            billDtlByBOMBindingSource.DataSource = dtlByBOM = new List<MaterielOutStoreBillDtl>();
            gridView.AddNewRow();
            if (lueBillType.ItemIndex == 0)
                vGoodsBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VGoodsByBOM>)];
            else
                vGoodsBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VGoods>)];
        }

    }
}
