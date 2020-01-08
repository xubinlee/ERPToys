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
using EDMX;
using CommonLibrary;
using Utility;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Data.Linq;
using Utility.Interceptor;
using ClientFactory;

namespace USL
{
    public partial class SLSalePricePage : DevExpress.XtraEditors.XtraUserControl, IItemDetail
    {
        private static BaseFactory baseFactory = LoggerInterceptor.CreateProxy<BaseFactory>();
        List<SLSalePrice> sLSalePriceList;
        List<SLSalePrice> SLSalePriceList;
        Guid focusedID;
        bool addNew = false;  //是否新增BOM\
        BusinessContactType businessContactType = BusinessContactType.Customer;
        public SLSalePricePage(BusinessContactType bcType)
        {
            InitializeComponent();
            businessContactType = bcType;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            winExplorerView.ShowFindPanel();
            BindData(null);
        }

        void SetDtlHeader(bool flag)
        {
            colPackaging.Visible = flag;
            colMEAS.Visible = flag;
            colSPEC.Visible = !flag;
        }

        public void BindData(object obj)
        {
            if (businessContactType == BusinessContactType.Customer)
            {
                //内销客户
                vBusinessContactBindingSource.DataSource = baseFactory.GetModelList<VCompany>().FindAll(o => o.客户类型 == (int)CustomerTypeEnum.DomesticSales);
                goodsBindingSource.DataSource = baseFactory.GetModelList<Goods>().FindAll(o => o.Type.Equals((int)GoodsBigTypeEnum.Goods)); 
                dpCustomer.Text = "客户列表";
                SetDtlHeader(true);
            }
            else
            {
                vBusinessContactBindingSource.DataSource = baseFactory.GetModelList<VSupplier>();
                goodsBindingSource.DataSource = baseFactory.GetModelList<Goods>().FindAll(o => o.Type > 0);
                dpCustomer.Text = "供应商列表";
                SetDtlHeader(false);
            }
            sLSalePriceList = baseFactory.GetModelList<SLSalePrice>();
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
                sLSalePriceList = baseFactory.GetModelList<SLSalePrice>();
                if (sLSalePriceList != null)
                {
                    bOMBindingSource.DataSource = SLSalePriceList = sLSalePriceList.FindAll(o => o.ID == focusedID);
                }
                else
                {
                    bOMBindingSource.DataSource = SLSalePriceList = new List<SLSalePrice>();
                }
            }
        }

        public void Add()
        {
            bOMBindingSource.DataSource = SLSalePriceList = new List<SLSalePrice>();
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
                if (SLSalePriceList == null)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("请完整填写{0}", dpBOM.Text.Trim()));
                    return false;
                }
                //foreach (MoldAllot item in supplierMoldAllotList)
                //{
                //    item.SupplierID = focusedID;
                //}
                List<SLSalePrice> oldList = BLLFty.Create<SLSalePriceBLL>().GetSLSalePrice();
                for (int i = SLSalePriceList.Count - 1; i >= 0; i--)
                {
                    if (SLSalePriceList[i].GoodsID == Guid.Empty || SLSalePriceList[i].Price == 0)
                    {
                        SLSalePriceList.RemoveAt(i);
                        continue;
                    }
                    if (hasGoods[SLSalePriceList[i].GoodsID] == null)
                        hasGoods.Add(SLSalePriceList[i].GoodsID, SLSalePriceList[i]);
                    else
                    {
                        CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "不能重复选择货品。");
                        return false;
                    }
                    SLSalePriceList[i].ID = focusedID;
                    SLSalePriceList[i].Type = (int)businessContactType;
                    SLSalePrice slSalePrict= oldList.FirstOrDefault(o =>
                  o.ID == SLSalePriceList[i].ID && o.GoodsID == SLSalePriceList[i].GoodsID);
                    if (slSalePrict != null && slSalePrict.Price == SLSalePriceList[i].Price)
                        SLSalePriceList[i].UpdateTime = slSalePrict.UpdateTime;
                    else
                        SLSalePriceList[i].UpdateTime = DateTime.Now;
                    if (slSalePrict != null && slSalePrict.Discount == SLSalePriceList[i].Discount)
                        SLSalePriceList[i].UpdateTime = slSalePrict.UpdateTime;
                    else
                        SLSalePriceList[i].UpdateTime = DateTime.Now;
                    //if (SLSalePriceList[i].PCS == 0)
                    //    SLSalePriceList[i].PCS = 1;
                }
                //添加
                if (addNew)
                {
                    BLLFty.Create<SLSalePriceBLL>().Insert(SLSalePriceList);
                }
                else//修改
                    BLLFty.Create<SLSalePriceBLL>().Update(focusedID, SLSalePriceList);
                addNew = false;
                //DataQueryPageRefresh();
                BindData(null);
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
                //if (SLSalePriceList != null && SLSalePriceList.Any(o => o.GoodsID == goods.ID))
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
            List<SLSalePrice> list = ((BindingSource)view.DataSource).DataSource as List<SLSalePrice>;
            if (e.IsGetData && list != null && list.Count > 0)
            {
                Goods goods = baseFactory.GetModelList<Goods>().Find(o => o.ID == list[e.ListSourceRowIndex].GoodsID);
                if (goods != null)
                {
                    if (e.Column == colName)
                        e.Value = goods.Name;
                    if (e.Column == colPic)
                        e.Value = goods.Pic;
                    if (e.Column == colPackaging && goods.PackagingID != null && goods.PackagingID != Guid.Empty)
                        e.Value = baseFactory.GetModelList<Packaging>().Find(o => o.ID == goods.PackagingID).Name;
                    if (e.Column == colMEAS)
                        e.Value = goods.MEAS;
                    if (e.Column == colSPEC)
                        e.Value = goods.SPEC;
                    if (e.Column == colUnit)
                        e.Value = goods.Unit;
                    if (e.Column == colRemark)
                        e.Value = goods.Remark;
                    if (e.Column == colUpdateTime)
                    {
                        SLSalePrice sl = list.FirstOrDefault(o => o.ID == focusedID && o.GoodsID == goods.ID);
                        if (sl != null)
                            e.Value = sl.UpdateTime;
                    }
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

        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            Save();
            MainMenuEnum menuName;
            if (businessContactType == BusinessContactType.Customer)
                menuName = MainMenuEnum.CustomerSLSalePrice;
            else
                menuName = MainMenuEnum.SupplierSLSalePrice;
            baseFactory.DataPageRefresh(menuName);
        }

        private void gridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            Save();
            MainMenuEnum menuName;
            if (businessContactType == BusinessContactType.Customer)
                menuName = MainMenuEnum.CustomerSLSalePrice;
            else
                menuName = MainMenuEnum.SupplierSLSalePrice;
            baseFactory.DataPageRefresh(menuName);
        }
    }
}
