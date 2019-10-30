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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Data.Linq;

namespace USL
{
    public partial class CustomerSLSalePricePage : DevExpress.XtraEditors.XtraUserControl, IItemDetail
    {
        List<CustomerSLSalePrice> sLSalePriceList;
        List<CustomerSLSalePrice> customerSLSalePriceList;
        Guid focusedID;
        bool addNew = false;  //是否新增BOM
        public CustomerSLSalePricePage()
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
            //内销客户
            vCustomerBindingSource.DataSource = ((List<VCompany>)MainForm.dataSourceList[typeof(List<VCompany>)]).FindAll(o=>o.客户类型==(int)CustomerType.DomesticSales);
            goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)GoodsBigType.Goods);
            sLSalePriceList = ((List<CustomerSLSalePrice>)MainForm.dataSourceList[typeof(List<CustomerSLSalePrice>)]);
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
                sLSalePriceList = ((List<CustomerSLSalePrice>)MainForm.dataSourceList[typeof(List<CustomerSLSalePrice>)]);
                if (sLSalePriceList != null)
                {
                    bOMBindingSource.DataSource = customerSLSalePriceList = sLSalePriceList.FindAll(o => o.CustomerID == focusedID);
                }
                else
                {
                    bOMBindingSource.DataSource = customerSLSalePriceList = new List<CustomerSLSalePrice>();
                }
            }
        }

        public void Add()
        {
            bOMBindingSource.DataSource = customerSLSalePriceList = new List<CustomerSLSalePrice>();
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
                if (customerSLSalePriceList == null)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("请完整填写{0}", dpBOM.Text.Trim()));
                    return false;
                }
                //foreach (MoldAllot item in supplierMoldAllotList)
                //{
                //    item.SupplierID = focusedID;
                //}
                for (int i = customerSLSalePriceList.Count - 1; i >= 0; i--)
                {
                    if (customerSLSalePriceList[i].GoodsID == Guid.Empty || customerSLSalePriceList[i].Price == 0)
                    {
                        customerSLSalePriceList.RemoveAt(i);
                        continue;
                    }
                    if (hasGoods[customerSLSalePriceList[i].GoodsID] == null)
                        hasGoods.Add(customerSLSalePriceList[i].GoodsID, customerSLSalePriceList[i]);
                    else
                    {
                        CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "不能重复选择货品。");
                        return false;
                    }
                    customerSLSalePriceList[i].CustomerID = focusedID;
                    //if (customerSLSalePriceList[i].PCS == 0)
                    //    customerSLSalePriceList[i].PCS = 1;
                }
                //添加
                if (addNew)
                {
                    BLLFty.Create<CustomerSLSalePriceBLL>().Insert(customerSLSalePriceList);
                }
                else//修改
                    BLLFty.Create<CustomerSLSalePriceBLL>().Update(focusedID, customerSLSalePriceList);
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
                bool flag = false;
                //if (focusedID == goods.ID)
                //{
                //    gridView.DeleteSelectedRows();
                //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "物料信息不能和货品重复。");
                //    flag = true;
                //}
                //if (customerSLSalePriceList != null && customerSLSalePriceList.Any(o => o.GoodsID == goods.ID))
                //{
                //    //gridView.SetRowCellValue(gridView.FocusedRowHandle, colGoodsID, null);
                //    gridView.DeleteSelectedRows();
                //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("不能重复选择{0}。", dpBOM.Text.Trim()));
                //    flag = true;

                //}
                if (flag)
                    return;
                //gridView.SetRowCellValue(gridView.FocusedRowHandle, colPCS, goods.装箱数);
                //gridView.SetRowCellValue(gridView.FocusedRowHandle, colInnerBox, goods.内盒);
                gridView.SetRowCellValue(gridView.FocusedRowHandle, colPrice, goods.Price);
                //gridView.SetRowCellValue(gridView.FocusedRowHandle, colPriceNoTax, goods.去税单价);
            }
        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            List<CustomerSLSalePrice> list = ((BindingSource)view.DataSource).DataSource as List<CustomerSLSalePrice>;
            if (e.IsGetData && list != null)
            {
                Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID == list[e.ListSourceRowIndex].GoodsID);
                if (goods != null)
                {
                    if (e.Column == colName)
                        e.Value = goods.Name;
                    if (e.Column == colPic)
                        e.Value = goods.Pic;
                    if (e.Column == colPackaging && goods.PackagingID != null && goods.PackagingID != Guid.Empty)
                        e.Value = ((List<Packaging>)MainForm.dataSourceList[typeof(List<Packaging>)]).Find(o => o.ID == goods.PackagingID).Name;
                    if (e.Column == colMEAS)
                        e.Value = goods.MEAS;
                    if (e.Column == colSPEC)
                        e.Value = goods.SPEC;
                    if (e.Column == colUnit)
                        e.Value = goods.Unit;
                    if (e.Column == colRemark)
                        e.Value = goods.Remark;
                }
            }
        }

        private void gridView_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                GridHitInfo hInfo = gridView.CalcHitInfo(new Point(e.X, e.Y));
                //双击左键
                if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
                {
                    //判断光标是否在行范围内 
                    if (hInfo.InRow)
                    {
                        //currentObj = gridView.GetRow(hInfo.RowHandle);
                        //NavMenu(currentObj);
                        if (gridView.FocusedColumn == colPic && gridView.GetFocusedValue() != null)  //双击图片单元格打开图片
                        {
                            //ImageHelper.WindowsPhotoViewer(ImageHelper.BinaryToImage((Binary)gridView.GetFocusedValue()));
                            //ImageHelper.WindowsPhotoViewer(Image.FromFile(gridView.GetFocusedRowCellValue("colPicPath").ToString()));
                            if (!System.IO.Directory.Exists(MainForm.DownloadFilePath))
                                System.IO.Directory.CreateDirectory(MainForm.DownloadFilePath);
                            string downloadFileName = MainForm.DownloadFilePath + String.Format("{0}.jpg", gridView.GetFocusedRowCellDisplayText("GoodsID").ToString());
                            //FileHelper.DownloadFile(downloadFileName, MainForm.ServerUserName, MainForm.ServerPassword, MainForm.ServerDomain);
                            string strErrorinfo = string.Empty;
                            FtpUpDown ftpUpDown = new FtpUpDown(MainForm.ServerUrl, MainForm.ServerUserName, MainForm.ServerPassword);
                            ftpUpDown.Download(MainForm.DownloadFilePath, String.Format("{0}.jpg", gridView.GetFocusedRowCellDisplayText("GoodsID").ToString()), out strErrorinfo);
                            ImageHelper.WindowsPhotoViewer(Image.FromFile(downloadFileName));
                        }
                    }
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

    }
}
