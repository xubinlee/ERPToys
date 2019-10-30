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
using Factory;
using BLL;
using DBML;
using CommonLibrary;
using Utility;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;

namespace USL
{
    public partial class MoldAllotPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail
    {
        List<MoldAllot> moldAllotList;
        List<MoldAllot> supplierMoldAllotList;
        Guid focusedID;
        bool addNew = false;  //是否新增BOM
        public MoldAllotPage()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            winExplorerView.ShowFindPanel();
            BindData();
        }

        public void BindData()
        {
            vSupplierBindingSource.DataSource = MainForm.dataSourceList[typeof(List<VSupplier>)];
            //vGoodsByBOMBindingSource.DataSource = ((List<VGoodsByBOM>)MainForm.dataSourceList[typeof(List<VGoodsByBOM>)]).FindAll(o => o.类型 == (int)BOMType.MoldList);//MainForm.dataSourceList[typeof(List<VGoods>)];
            goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)GoodsBigType.Mold);
            moldAllotList = ((List<MoldAllot>)MainForm.dataSourceList[typeof(List<MoldAllot>)]);
            GetMoldAllotDataSource();
        }

        private void winExplorerView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetMoldAllotDataSource();
        }

        private void winExplorerView_RowCountChanged(object sender, EventArgs e)
        {
            GetMoldAllotDataSource();
        }

        void GetMoldAllotDataSource()
        {
            if (winExplorerView.GetFocusedRowCellValue(colID) != null)
            {
                focusedID = new Guid(winExplorerView.GetFocusedRowCellValue(colID).ToString());
                moldAllotList = ((List<MoldAllot>)MainForm.dataSourceList[typeof(List<MoldAllot>)]);
                if (moldAllotList != null)
                {
                    bOMBindingSource.DataSource = supplierMoldAllotList = moldAllotList.FindAll(o => o.SupplierID == focusedID);
                }
                else
                {
                    bOMBindingSource.DataSource = supplierMoldAllotList = new List<MoldAllot>();
                }
            }
        }

        public void Add()
        {
            bOMBindingSource.DataSource = supplierMoldAllotList = new List<MoldAllot>();
            gridView.AddNewRow();
            addNew = true;
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public void Del()
        {
            throw new NotImplementedException();
        }

        
        public bool Save()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Hashtable hasGoods = new Hashtable();
                if (supplierMoldAllotList == null)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("请完整填写{0}", dpBOM.Text.Trim()));
                    return false;
                }
                //foreach (MoldAllot item in supplierMoldAllotList)
                //{
                //    item.SupplierID = focusedID;
                //}
                for (int i = supplierMoldAllotList.Count - 1; i >= 0; i--)
                {
                    if (supplierMoldAllotList[i].GoodsID == Guid.Empty || supplierMoldAllotList[i].Qty == 0)
                    {
                        supplierMoldAllotList.RemoveAt(i);
                        continue;
                    }
                    if (hasGoods[supplierMoldAllotList[i].GoodsID] == null)
                        hasGoods.Add(supplierMoldAllotList[i].GoodsID, supplierMoldAllotList[i]);
                    else
                    {
                        CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "不能重复选择货品。");
                        return false;
                    }
                    supplierMoldAllotList[i].SupplierID = focusedID;
                    if (supplierMoldAllotList[i].PCS == 0)
                        supplierMoldAllotList[i].PCS = 1;
                }
                //添加
                if (addNew)
                {
                    BLLFty.Create<MoldAllotBLL>().Insert(supplierMoldAllotList);
                }
                else//修改
                    BLLFty.Create<MoldAllotBLL>().Update(focusedID, supplierMoldAllotList);
                addNew = false;
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
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
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
            Goods goods = ((LookUpEdit)sender).GetSelectedDataRow() as Goods;
            if (goods != null)
            {
                //bool flag = false;
                ////if (focusedID == goods.ID)
                ////{
                ////    gridView.DeleteSelectedRows();
                ////    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "物料信息不能和货品重复。");
                ////    flag = true;
                ////}
                //if (supplierMoldAllotList != null && supplierMoldAllotList.Any(o => o.GoodsID == goods.ID))
                //{
                //    //gridView.SetRowCellValue(gridView.FocusedRowHandle, colGoodsID, null);
                //    gridView.DeleteSelectedRows();
                //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("不能重复选择{0}.", dpBOM.Text.Trim()));
                //    flag = true;

                //}
                //if (flag)
                //    return;
                //gridView.SetRowCellValue(gridView.FocusedRowHandle, colPCS, goods.装箱数);
                //gridView.SetRowCellValue(gridView.FocusedRowHandle, colInnerBox, goods.内盒);
                gridView.SetRowCellValue(gridView.FocusedRowHandle, colPrice, goods.Price);
                //gridView.SetRowCellValue(gridView.FocusedRowHandle, colPriceNoTax, goods.去税单价);
            }
        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            List<MoldAllot> list = ((BindingSource)view.DataSource).DataSource as List<MoldAllot>;
            if (e.IsGetData && list != null && list.Count > 0)
            {
                Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID == list[e.ListSourceRowIndex].GoodsID);
                if (goods != null)
                {
                    if (e.Column == colName)
                        e.Value = goods.Name;
                    if (e.Column == colSPEC)
                        e.Value = goods.SPEC;
                    if (e.Column == colUnit)
                        e.Value = goods.Unit;
                    if (e.Column == colRemark)
                        e.Value = goods.Remark;
                }
            }
        }

        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            Save();
            MainForm.DataPageRefresh(MainMenuConstants.MoldAllot);
        }

        private void gridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            Save();
            MainForm.DataPageRefresh(MainMenuConstants.MoldAllot);
        }
    }
}
