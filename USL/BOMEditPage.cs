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
using DevExpress.XtraGrid.Views.WinExplorer;
using Utility.Interceptor;

namespace USL
{
    public partial class BOMEditPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail
    {
        private static ClientFactory clientFactory = LoggerInterceptor.CreateProxy<ClientFactory>();
        List<BOM> bomList;
        List<BOM> goodsBOMList;
        Guid focusedGoodsID;
        bool addNew = false;  //是否新增BOM
        BOMType bomType;
        GoodsBigType goodsBigType = GoodsBigType.Goods;  //Goods大类
        GoodsBigType lueGoodsBigType = GoodsBigType.Goods;  //下拉Goods大类
        public BOMEditPage(BOMType type)
        {
            InitializeComponent();
            bomType = type;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            switch (bomType)
            {
                case BOMType.BOM:
                    dpGoods.Text = "成品列表";
                    dpBOM.Text = "包装列表";
                    goodsBigType = GoodsBigType.Goods;
                    lueGoodsBigType = GoodsBigType.SFGoods;
                    break;
                case BOMType.MoldList:
                    dpGoods.Text = "模具列表";
                    dpBOM.Text = "装配材料";
                    goodsBigType = GoodsBigType.Mold;
                    lueGoodsBigType = GoodsBigType.Stuff;
                    break;
                case BOMType.MoldMaterial:
                    dpGoods.Text = "模具列表";
                    dpBOM.Text = "原料信息";
                    goodsBigType = GoodsBigType.Mold;
                    lueGoodsBigType = GoodsBigType.Material;
                    break;
                case BOMType.Assemble:
                    dpGoods.Text = "包装/装配列表";
                    dpBOM.Text = "装配材料";
                    goodsBigType = GoodsBigType.SFGoods;
                    lueGoodsBigType = GoodsBigType.Stuff;
                    break;
                default:
                    break;
            }
            winExplorerView.ShowFindPanel();
            BindData(null);
        }

        public void BindData(object obj)
        {
            if (bomType == BOMType.Assemble)
            {
                Guid bzID = Guid.Empty;
                Guid pjID = Guid.Empty;
                GoodsType bz = ((List<GoodsType>)MainForm.dataSourceList[typeof(List<GoodsType>)]).Find(t => t.Name.Contains("包装"));
                if (bz != null)
                    bzID = bz.ID;
                GoodsType pj = ((List<GoodsType>)MainForm.dataSourceList[typeof(List<GoodsType>)]).Find(t => t.Name.Contains("配件"));
                if (pj != null)
                    pjID = pj.ID;
                goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o =>
                (o.Type == (int)GoodsBigType.SFGoods && o.GoodsTypeID != bzID) || (o.Type == (int)GoodsBigType.Stuff && o.GoodsTypeID != pjID));
            }
            else
                goodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)goodsBigType);
            if (bomType == BOMType.BOM)
                lueGoodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o =>
                    o.Type == (int)GoodsBigType.SFGoods || o.Type == (int)GoodsBigType.Stuff);  //一些自动机生产的材料可以直接用来包装成成品
            else if (bomType==BOMType.Assemble)
                lueGoodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o =>
                    o.Type == (int)GoodsBigType.Stuff || o.Type == (int)GoodsBigType.Material || o.Type == (int)GoodsBigType.Mold);  //外加工装配，自动机材料按损耗率扣减原料
            else
                lueGoodsBindingSource.DataSource = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FindAll(o => o.Type == (int)lueGoodsBigType);
            bomList = ((List<BOM>)MainForm.dataSourceList[typeof(List<BOM>)]).FindAll(o => o.Type == (int)bomType);
            GetBOMDataSource();
        }

        private void winExplorerView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetBOMDataSource();
        }

        private void winExplorerView_RowCountChanged(object sender, EventArgs e)
        {
            GetBOMDataSource();
        }

        void GetBOMDataSource()
        {
            if (winExplorerView.GetFocusedRowCellValue(colID) != null)
            {
                focusedGoodsID = new Guid(winExplorerView.GetFocusedRowCellValue(colID).ToString());
                bomList = ((List<BOM>)MainForm.dataSourceList[typeof(List<BOM>)]).FindAll(o => o.Type == (int)bomType);
                if (bomList != null)
                {
                    bOMBindingSource.DataSource = goodsBOMList = bomList.FindAll(o => o.ParentGoodsID == focusedGoodsID);
                }
                else
                {
                    bOMBindingSource.DataSource = goodsBOMList = new List<BOM>();
                }
            }
        }

        public void Add()
        {
            bOMBindingSource.DataSource = goodsBOMList = new List<BOM>();
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
                if (goodsBOMList == null)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("请完整填写{0}", dpBOM.Text.Trim()));
                    return false;
                }
                //foreach (BOM item in goodsBOMList)
                //{
                //    item.ParentGoodsID = focusedGoodsID;
                //    item.Type = (int)bomType;
                //}
                for (int i = goodsBOMList.Count - 1; i >= 0; i--)
                {
                    if (goodsBOMList[i].GoodsID == Guid.Empty || goodsBOMList[i].Qty == 0)
                    {
                        goodsBOMList.RemoveAt(i);
                        continue;
                    }
                    if (hasGoods[goodsBOMList[i].GoodsID] == null)
                        hasGoods.Add(goodsBOMList[i].GoodsID, goodsBOMList[i]);
                    else
                    {
                        CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "不能重复选择货品。");
                        return false;
                    }
                    goodsBOMList[i].ParentGoodsID = focusedGoodsID;
                    goodsBOMList[i].Type = (int)bomType;
                    if (goodsBOMList[i].PCS == 0)
                        goodsBOMList[i].PCS = 1;
                }
                //添加
                if (addNew)
                {
                    BLLFty.Create<BOMBLL>().Insert(goodsBOMList);
                }
                else//修改
                    BLLFty.Create<BOMBLL>().Update((int)bomType, focusedGoodsID, goodsBOMList);
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
            if (e.FocusedColumn == colRemark1
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
                if (focusedGoodsID == goods.ID)
                {
                    gridView.DeleteSelectedRows();
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("{0}不能和{1}信息重复。", dpBOM.Text.Trim(), dpGoods.Text.Trim()));
                    flag = true;
                }
                //if (goodsBOMList != null && goodsBOMList.Any(o => o.GoodsID == goods.ID))
                //{
                //    //gridView.SetRowCellValue(gridView.FocusedRowHandle, colGoodsID, null);
                //    gridView.DeleteSelectedRows();
                //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("不能重复选择{0}", dpBOM.Text.Trim()));
                //    flag = true;

                //}
                if (flag)
                    return;
                Goods parentGoods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID == focusedGoodsID);
                gridView.SetRowCellValue(gridView.FocusedRowHandle, colPCS, parentGoods.PCS);
                gridView.SetRowCellValue(gridView.FocusedRowHandle, colInnerBox, goods.InnerBox);
                gridView.SetRowCellValue(gridView.FocusedRowHandle, colPrice, goods.Price);
                gridView.SetRowCellValue(gridView.FocusedRowHandle, colPriceNoTax, goods.PriceNoTax);
            }
        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            List<BOM> list = ((BindingSource)view.DataSource).DataSource as List<BOM>;
            if (e.IsGetData && list != null && list.Count > 0)
            {
                Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).Find(o => o.ID == list[e.ListSourceRowIndex].GoodsID);
                if (goods != null)
                {
                    if (e.Column == colPic1)
                        e.Value = goods.Pic;
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
                        if (gridView.FocusedColumn==colPic1 && gridView.GetFocusedValue() != null)  //双击图片单元格打开图片
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

        private void gridControl_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Append && gridView.RowCount==0)
            {
                bOMBindingSource.DataSource = goodsBOMList = new List<BOM>();
                addNew = true;
            }
        }

        private void winExplorerView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            WinExplorerView view = sender as WinExplorerView;
            List<Goods> list = ((BindingSource)view.DataSource).DataSource as List<Goods>;
            if (e.IsGetData && list != null && list.Count > 0)
            {
                GoodsType goodsType = ((List<GoodsType>)MainForm.dataSourceList[typeof(List<GoodsType>)]).FirstOrDefault(o => o.ID == list[e.ListSourceRowIndex].GoodsTypeID);
                if (goodsType != null)
                {
                    if (e.Column == colGoodsType)
                        e.Value = goodsType.Name;
                }
            }
        }

        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            Save();
            clientFactory.DataPageRefresh<BOM>();
        }

        private void gridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            this.Save();
            clientFactory.DataPageRefresh<BOM>();
        }
    }
}
