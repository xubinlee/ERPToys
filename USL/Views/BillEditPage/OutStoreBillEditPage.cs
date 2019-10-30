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
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DBML;
using Factory;
using BLL;
using Utility;
using DevExpress.XtraBars.Docking2010.Views;
using System.Collections;
using CommonLibrary;

namespace USL
{
    public partial class OutStoreBillEditPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail
    {
        OutStoreBillHd hd;
        List<OutStoreBillDtl> dtl;
        List<Warehouse> warehouseList;
        PageGroup pageGroupCore;
        Guid headID;
        List<TypesList> types;   //类型列表
        public OutStoreBillEditPage(Guid hdID, PageGroup child)
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
                outStoreBillHdBindingSource.DataSource = hd = BLLFty.Create<OutStoreBillBLL>().GetOutStoreBillHd(hdID);
                outStoreBillDtlBindingSource.DataSource = dtl = BLLFty.Create<OutStoreBillBLL>().GetOutStoreBillDtl(hdID);
            }
            vCompanyBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VCompany>)];
            types = MainForm.dataSourceList[typeof(List<TypesList>)] as List<TypesList>;
            //单据类型
            billTypeBindingSource.DataSource = types.FindAll(o => o.Type == TypesListConstants.OutStoreBillType);
            warehouseList = MainForm.dataSourceList[typeof(List<Warehouse>)] as List<Warehouse>;
            vGoodsBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VGoods>)];
            vUsersInfoBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VUsersInfo>)];
        }

        public void Add()
        {
            outStoreBillHdBindingSource.DataSource = hd = new OutStoreBillHd();
            outStoreBillDtlBindingSource.DataSource = dtl = new List<OutStoreBillDtl>();
            gridView.AddNewRow();
            string no = BLLFty.Create<OutStoreBillBLL>().GetMaxBillNo();
            if (no == null)
                hd.BillNo = "FCK" + DateTime.Now.ToString("yyyyMMdd") + "001";
            else
            {
                if (no.Substring(3, 8).Equals(DateTime.Now.ToString("yyyyMMdd")))
                    hd.BillNo = "FCK" + DateTime.Now.ToString("yyyyMMdd") + Convert.ToString(int.Parse(no.Substring(11, 3)) + 1).PadLeft(3, '0');
                else
                    hd.BillNo = "FCK" + DateTime.Now.ToString("yyyyMMdd") + "001";
            }
            headID = Guid.Empty;
            deOrderDate.Focus();
        }

        public void Edit()
        {
            //单据编辑界面不需要
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
                    DataQueryPage page = itemDetailPage.itemDetailList[MainMenuConstants.OutStoreBilllQuery] as DataQueryPage;
                    MainForm.dataSourceList[typeof(List<VOutStoreBill>)] = BLLFty.Create<OutStoreBillBLL>().GetOutStoreBill();
                    IList list = MainForm.dataSourceList[typeof(List<VOutStoreBill>)] as IList;
                    page.InitGrid(list);
                }
            }
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
                        BLLFty.Create<InStoreBillBLL>().Delete(hd.ID);
                    DataQueryPageRefresh();
                    outStoreBillHdBindingSource.DataSource = hd = new OutStoreBillHd();
                    outStoreBillDtlBindingSource.DataSource = dtl = new List<OutStoreBillDtl>();
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
                //if (lueBillType.ItemIndex == 2)  //半成品发货
                //    hd.WarehouseID = warehouseList[1].ID;
                //else
                hd.WarehouseID = warehouseList[0].ID;  //成品仓
                //添加
                if (headID == Guid.Empty)
                {
                    hd.ID = Guid.NewGuid();
                    foreach (OutStoreBillDtl item in dtl)
                    {
                        item.ID = Guid.NewGuid();
                        item.HdID = hd.ID;
                    }
                    BLLFty.Create<OutStoreBillBLL>().Insert(hd, dtl);
                }
                else//修改
                    BLLFty.Create<OutStoreBillBLL>().Update(hd, dtl);
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
                    foreach (OutStoreBillDtl dtlItem in dtl)
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
            VGoods goods = ((LookUpEdit)sender).GetSelectedDataRow() as VGoods;
            if (goods != null)
            {
                gridView.SetRowCellValue(gridView.FocusedRowHandle, colPCS, goods.装箱数);
                gridView.SetRowCellValue(gridView.FocusedRowHandle, colInnerBox, goods.内盒);
                gridView.SetRowCellValue(gridView.FocusedRowHandle, colPrice, goods.单价);
                gridView.SetRowCellValue(gridView.FocusedRowHandle, colPriceNoTax, goods.去税单价);
                gridView.SetRowCellValue(gridView.FocusedRowHandle, colDiscount, 1);
            }
        }

        private void gridView_CalcPreviewText(object sender, DevExpress.XtraGrid.Views.Grid.CalcPreviewTextEventArgs e)
        {
            object obj = gridView.GetRowCellValue(e.RowHandle, colGoodsID);
            if (obj != null && new Guid(obj.ToString()) != Guid.Empty)
            {
                VGoods goods = ((List<VGoods>)MainForm.dataSourceList[typeof(List<VGoods>)]).Find(o => o.ID.Equals(new Guid(obj.ToString())));
                e.PreviewText = goods.品名 + (string.IsNullOrEmpty(goods.单位) ? "" : "    单位：" + goods.单位);
            }
        }

        private void lueCompany_EditValueChanged(object sender, EventArgs e)
        {
            VCompany company = ((LookUpEdit)sender).GetSelectedDataRow() as VCompany;
            if (company != null && hd !=null)
            {
                hd.CompanyID = company.ID;
                hd.Contacts = company.联系人;
            }
        }
    }
}
