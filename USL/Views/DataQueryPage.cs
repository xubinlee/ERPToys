using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using System.Collections;
using EDMX;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using IBase;
using Utility;
using BLL;
using Factory;
using CommonLibrary;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using Microsoft.Practices.CompositeUI;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraGrid.Columns;
using System.Data.OleDb;
using System.IO;
using System.Data.Linq;
using DevExpress.XtraGrid.Views.Grid;
using Utility.Interceptor;
using ClientFactory;

namespace USL
{
    public partial class DataQueryPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail, IExtensions
    {
        private static BaseFactory baseFactory = LoggerInterceptor.CreateProxy<BaseFactory>();
        private static InventoryFactory inventoryFactory = LoggerInterceptor.CreateProxy<InventoryFactory>();
        public MainMenu mainMenu;
        IList dataSource;
        Object currentObj = null;
        PageGroup pageGroupCore;
        Dictionary<String, int> itemDetailButtonList; //子菜单按钮项
        //Dictionary<String, ItemDetailPage> itemDetailPageList;
        WindowsUIView view = null;
        //List<VUsersInfo> displayUsers;
        List<EnumHelper.ListItem<GoodsBigTypeEnum>> types;   //类型列表
        List<Warehouse> warehouseList;

        //[ServiceDependency]
        //public WorkItem RootWorkItem { get; set; }
        public DataQueryPage(MainMenu menu, IList list, PageGroup child, Dictionary<String, int> childButtonList)
        {
            InitializeComponent();
            pageGroupCore = child;
            itemDetailButtonList = childButtonList;
            gridView.ShowFindPanel();
            gridView.IndicatorWidth = 40;
            mainMenu = menu;
            dataSource = list;
            //itemDetailPageList = new Dictionary<string, ItemDetailPage>();
            types = EnumHelper.GetEnumValues<GoodsBigTypeEnum>(false);
            warehouseList = baseFactory.GetModelList<Warehouse>();
        }

        void GetItemDetailPage()
        {
            BaseContentContainer documentContainer = pageGroupCore.Parent as BaseContentContainer;
            if (documentContainer != null)
            {
                view = documentContainer.Manager.View as WindowsUIView;
                //if (view != null)
                //{

                //    foreach (BaseDocument doc in view.Documents)
                //    {
                //        if (doc.Control is ItemDetailPage)
                //        {
                //            ItemDetailPage itemDetailPage = (ItemDetailPage)doc.Control;
                //            //if (itemDetailPage.menu==mainMenu)
                //            //    break;
                //            itemDetailPageList.Add(itemDetailPage.menu.Name, itemDetailPage);
                //        }

                //    }
                //}
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //displayUsers = BLLFty.Create<UsersInfoBLL>().GetVUsersInfo();
            GetItemDetailPage();
            BindData(dataSource);
            MainForm.SetQueryPageGridColumn(gridView, (MainMenuEnum)Enum.Parse(typeof(MainMenuEnum), mainMenu.Name));
            //SetGridSummaryItem();
            if (MainForm.Company.Contains("镇阳") && (
                MainForm.usersInfo.DeptID.Equals(new Guid("67ca70dc-7255-438d-9ecb-bcdf3bc6e71f")) ||
                MainForm.usersInfo.DeptID.Equals(new Guid("57c74e6c-18c3-4ce4-8167-463a912f349f"))))//部门是管理员或办公室的用户
            {
                this.gridView.OptionsView.ShowFooter = true;
                this.gridView.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleIfExpanded;
            }
            else
            {
                this.gridView.OptionsView.ShowFooter = false;
                this.gridView.OptionsView.GroupFooterShowMode = GroupFooterShowMode.Hidden;
            }
        }

        public void InitGrid<T>(IList list)
        {
            if (mainMenu.Name.Equals(typeof(T).Name))
            {
                gridControl.DataSource = list;
                //MainForm.SetQueryPageGridColumn(gridView, mainMenu);
            }
        }

        public void BindData(object list)
        {
            //类型相同才绑定
            //if (list.Count > 0 && mainMenu.Name.Equals(list[0].GetType().Name))
            if (list != null && mainMenu.Name.Equals(list.GetType().GenericTypeArguments[0].Name))
            {
                if (mainMenu.Name.ToLower().EndsWith("hd"))
                {
                    // 贪婪加载模式
                    List<OrderHd> oList = list as List<OrderHd>;
                    //var diffList = list.GroupBy(p => new { p.DeptID, p.GoodsCode }).GroupJoin(goodsList, st => st.Key.GoodsCode, g => g.Code, (st, g) => new { st, g }).SelectMany(
                    //        z => z.g.DefaultIfEmpty(), (x, y) => new { Stocktaking = x.st, goods = y }).Select(res =>
                    //        new ProfitAndLoss
                    //        {
                    //            ID = Guid.NewGuid(),
                    //            DeptID = res.Stocktaking.Key.DeptID,
                    //            DeptCode = res.Stocktaking.FirstOrDefault().DeptCode,
                    //            DeptName = res.Stocktaking.FirstOrDefault().DeptName,
                    //            Category = res.goods == null ? string.Empty : res.goods.Category,
                    //            GoodsCode = res.Stocktaking.FirstOrDefault().GoodsCode,
                    //            GoodsName = res.Stocktaking.FirstOrDefault().GoodsName,
                    //            Price = res.goods == null ? 0 : res.goods.Price,
                    //            //StockQty = res.goods == null ? 0 : res.goods.Qty.Value,
                    //            //StockAMT = Math.Round((decimal)(res.goods == null ? 0 : res.goods.Qty) * (res.goods == null ? 0 : res.goods.Price), 2),
                    //            CheckQty = res.Stocktaking.Sum(item => item.CheckQty),
                    //            CheckAMT = Math.Round((decimal)res.Stocktaking.Sum(item => item.CheckQty) * (res.goods == null ? 0 : res.goods.Price), 2),
                    //            //DiffQty = res.Stocktaking.Sum(item => item.CheckQty) - (res.goods == null ? 0 : res.goods.Qty.Value),
                    //            //DiffAMT = Math.Round((decimal)(res.Stocktaking.Sum(item => item.CheckQty) - (res.goods == null ? 0 : res.goods.Qty.Value * res.goods.Price)), 2)
                    //        }).ToList();
                }
                else
                    gridControl.DataSource = list;
                //MainForm.SetQueryPageGridColumn(gridView, mainMenu);
            }
        }

        private void gridView_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                GridHitInfo hInfo = gridView.CalcHitInfo(new Point(e.X, e.Y));
                MainMenuEnum menuEnum = (MainMenuEnum)Enum.Parse(typeof(MainMenuEnum), mainMenu.Name);
                //双击左键
                if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
                {
                    //判断光标是否在行范围内 
                    if (hInfo.InRow)
                    {
                        //currentObj = gridView.GetRow(hInfo.RowHandle);
                        //NavMenu(currentObj);
                        if ((gridView.FocusedColumn.FieldName == "图片" || gridView.FocusedColumn.FieldName == "照片") && gridView.GetFocusedValue() != null)  //双击图片单元格打开图片
                        {
                            //ImageHelper.WindowsPhotoViewer(ImageHelper.BinaryToImage((Binary)gridView.GetFocusedValue()));
                            //ImageHelper.WindowsPhotoViewer(Image.FromFile(gridView.GetFocusedRowCellValue("PicPath").ToString()));
                            if (!System.IO.Directory.Exists(MainForm.DownloadFilePath))
                                System.IO.Directory.CreateDirectory(MainForm.DownloadFilePath);
                            string downloadFileName = MainForm.DownloadFilePath + String.Format("{0}.jpg", gridView.GetFocusedRowCellValue("货号").ToString());
                            //FileHelper.DownloadFile(downloadFileName, MainForm.ServerUserName, MainForm.ServerPassword, MainForm.ServerDomain);
                            string strErrorinfo = string.Empty;
                            FtpUpDown ftpUpDown = new FtpUpDown(MainForm.ServerUrl, MainForm.ServerUserName, MainForm.ServerPassword);
                            ftpUpDown.Download(MainForm.DownloadFilePath, String.Format("{0}.jpg", gridView.GetFocusedRowCellValue("货号").ToString()), out strErrorinfo);
                            ImageHelper.WindowsPhotoViewer(Image.FromFile(downloadFileName));
                        }
                        else
                            Edit();
                    }
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1 && !mainMenu.Name.Contains("Report") && (mainMenu.Name.Contains("Bill") || mainMenu.Name.Contains("Order")))  //单击左键
                {
                    //object obj = gridView.GetRow(gridView.FocusedRowHandle);
                    if (hInfo.InRowCell)
                    {
                        if (Convert.ToInt32(gridView.GetRowCellValue(hInfo.RowHandle, "状态")) == 0)
                        {
                            MainForm.itemDetailPageList[menuEnum].btnAudit.Visible = true;
                            MainForm.itemDetailPageList[menuEnum].btnAudit.Caption = "审核";
                            MainForm.itemDetailPageList[menuEnum].btnAudit.Glyph = global::USL.Properties.Resources.audit;
                        }
                        else if (Convert.ToInt32(gridView.GetRowCellValue(hInfo.RowHandle, "状态")) == 1)// && !mainMenu.Name.Contains("Order"))
                        {
                            MainForm.itemDetailPageList[menuEnum].btnAudit.Visible = true;
                            MainForm.itemDetailPageList[menuEnum].btnAudit.Caption = "取消审核";
                            MainForm.itemDetailPageList[menuEnum].btnAudit.Glyph = global::USL.Properties.Resources.Undo_32x32;
                        }
                        else
                            MainForm.itemDetailPageList[menuEnum].btnAudit.Visible = false;
                    }
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1 && mainMenu.Name==MainMenuEnum.UsersInfo.ToString())  //单击左键
                {
                    //object obj = gridView.GetRow(gridView.FocusedRowHandle);
                    if (hInfo.InRowCell)
                    {
                        if (Convert.ToBoolean(gridView.GetRowCellValue(hInfo.RowHandle, "已删除")))
                        {
                            MainForm.itemDetailPageList[menuEnum].btnDel.Caption = "恢复";
                        }
                        else
                            MainForm.itemDetailPageList[menuEnum].btnDel.Caption = "删除";
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

        //查询面板切换到编辑面板
        MainMenu NavMenu(object currentObj)
        {
            if (view != null)
            {
                MainMenuEnum menuEnum = (MainMenuEnum)Enum.Parse(typeof(MainMenuEnum), mainMenu.Name.Replace("Query", ""));
                if (MainForm.itemDetailPageList.Count > 0)
                {
                    //加载窗体页面
                    if (MainForm.hasItemDetailPage[mainMenu.Name.Replace("Query", "")] == null)
                    {
                        MainForm.itemDetailPageList[menuEnum].LoadBusinessData(MainForm.mainMenuList[menuEnum]);
                        MainForm.hasItemDetailPage.Add(mainMenu.Name.Replace("Query", ""), true);
                    }
                    //切换到对应的单据界面并传递数据
                    if (mainMenu.Name.ToUpper().Contains("BILLQUERY"))
                    {
                        if (mainMenu.Name.ToUpper().Contains("STOCKOUT") || mainMenu.Name == MainMenuEnum.GetMaterialBillQuery.ToString()
                            || mainMenu.Name == MainMenuEnum.FSMDPReturnBillQuery.ToString() || mainMenu.Name == MainMenuEnum.EMSDPReturnBillQuery.ToString())
                        {
                            StockOutBillPage page = MainForm.itemDetailPageList[menuEnum].itemDetail as StockOutBillPage;
                            if (mainMenu.Name == MainMenuEnum.FGStockOutBillQuery.ToString())
                                page.BindData(((VStockOutBill)currentObj).HdID);
                            else
                                page.BindData(((VMaterialStockOutBill)currentObj).HdID);
                        }
                        else if (mainMenu.Name.ToUpper().Contains("STOCKIN") || mainMenu.Name.ToUpper().Contains("ReturnBill".ToUpper()) || mainMenu.Name == MainMenuEnum.ReturnedMaterialBillQuery.ToString())
                        {
                            StockInBillPage page = MainForm.itemDetailPageList[menuEnum].itemDetail as StockInBillPage;
                            if (mainMenu.Name == MainMenuEnum.ProductionStockInBillQuery.ToString() || mainMenu.Name == MainMenuEnum.SalesReturnBillQuery.ToString())
                                page.BindData(((VStockInBill)currentObj).HdID);
                            else
                                page.BindData(((VMaterialStockInBill)currentObj).HdID);
                        }
                        else if (mainMenu.Name == MainMenuEnum.ReceiptBillQuery.ToString())
                        {
                            ReceiptBillPage page = MainForm.itemDetailPageList[menuEnum].itemDetail as ReceiptBillPage;
                            page.BindData(((VReceiptBill)currentObj).HdID);
                        }
                        else if (mainMenu.Name == MainMenuEnum.PaymentBillQuery.ToString())
                        {
                            PaymentBillPage page = MainForm.itemDetailPageList[menuEnum].itemDetail as PaymentBillPage;
                            page.BindData(((VPaymentBill)currentObj).HdID);
                        }
                        else if (mainMenu.Name == MainMenuEnum.WageBillQuery.ToString())
                        {
                            WageBillPage page = MainForm.itemDetailPageList[menuEnum].itemDetail as WageBillPage;
                            page.BindData(((VWageBill)currentObj).HdID);
                        }
                        else if (mainMenu.Name == MainMenuEnum.AttWageBillQuery.ToString())
                        {
                            AttWageBillPage page = MainForm.itemDetailPageList[menuEnum].itemDetail as AttWageBillPage;
                            page.BindData(((VAttWageBill)currentObj).HdID);
                        }
                    }
                    else if (mainMenu.Name == MainMenuEnum.OrderQuery.ToString())
                    {
                        OrderEditPage page = MainForm.itemDetailPageList[MainMenuEnum.Order].itemDetail as OrderEditPage;
                        page.BindData(((VOrder)currentObj).HdID);
                    }
                    else if (mainMenu.Name == MainMenuEnum.FSMOrderQuery.ToString())
                    {
                        OrderEditPage page = MainForm.itemDetailPageList[MainMenuEnum.FSMOrder].itemDetail as OrderEditPage;
                        page.BindData(((VFSMOrder)currentObj).HdID);
                    }
                    else if (mainMenu.Name == MainMenuEnum.ProductionOrderQuery.ToString())
                    {
                        OrderEditPage page = MainForm.itemDetailPageList[MainMenuEnum.ProductionOrder].itemDetail as OrderEditPage;
                        page.BindData(((VProductionOrder)currentObj).HdID);
                    }
                    else
                        return MainForm.mainMenuList[menuEnum];

                    pageGroupCore.SetSelected(pageGroupCore.Items[itemDetailButtonList[mainMenu.Name] - 1]);
                    view.ActivateContainer(pageGroupCore);
                }
                return MainForm.mainMenuList[menuEnum];
            }
            else
                return mainMenu;
        }

        //显示行的序号 
        private void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        public void Add()
        {
            currentObj = null;
            DataEditForm form = new DataEditForm(mainMenu, currentObj, pageGroupCore);
            form.ShowDialog();
        }

        public void Edit()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                //if (mainMenu.ParentID == new Guid("ce85d24f-b4e9-43f0-b605-3b5b9d321935"))//系统信息
                //    return;
                if (gridView.SelectedRowsCount > 0)
                {
                    MainMenuEnum menuEnum = (MainMenuEnum)Enum.Parse(typeof(MainMenuEnum), mainMenu.Name.Replace("Query", ""));
                    currentObj = gridView.GetRow(gridView.FocusedRowHandle);
                    if (mainMenu.ParentID == new Guid("7ea0e093-592a-420c-9a7f-8316f88c35e2"))//基础资料
                    {
                        IList goodsList = null;
                        if (mainMenu.Name == MainMenuEnum.Material.ToString())
                        {
                            MainForm.GoodsBigType = types.FirstOrDefault(o => o.Name.Equals(MainForm.GoodsBigTypeName)).Index;
                        }
                        int focusRow = gridView.FocusedRowHandle;
                        DataEditForm form = new DataEditForm(mainMenu, currentObj, pageGroupCore);
                        form.ShowDialog();
                        if (mainMenu.Name == MainMenuEnum.Material.ToString())
                        {
                            goodsList = baseFactory.GetModelList<VMaterial>().FindAll(o => o.Type == MainForm.GoodsBigType);
                            BindData(goodsList);
                        }
                        //刷新数据
                        //itemDetailPage.DataQueryPageRefresh();
                        gridView.FocusedRowHandle = focusRow;
                    }
                    else if (mainMenu.Name.ToUpper().Contains("BILL") || mainMenu.Name.ToUpper().Contains("ORDER"))
                    {
                        MainMenu menu = NavMenu(currentObj);
                        //List<TypesList> types = baseFactory.GetModelList<TypesList>();
                        //string menuName = types.Find(o => (mainMenu.Name.Contains(o.Type.Substring(0, 7)) || mainMenu.Name.Contains(o.SubType)) && o.No == Convert.ToInt32(Convert.ToInt32(gridView.GetFocusedRowCellValue("单据类型")))).SubType;
                        if (Convert.ToInt32(gridView.GetFocusedRowCellValue("状态")) == 0)
                        //    itemDetailPageList[mainMenu.Name.Replace("Query", "")].setNavButtonStatus(ButtonType.btnSave);
                        //else
                            //    itemDetailPageList[mainMenu.Name.Replace("Query", "")].setNavButtonStatus(ButtonType.btnAudit);
                            MainForm.itemDetailPageList[menuEnum].setNavButtonStatus(menu, ButtonType.btnSave);
                        else
                            MainForm.itemDetailPageList[menuEnum].setNavButtonStatus(menu, ButtonType.btnAudit);
                    }
                    else if (mainMenu.Name == MainMenuEnum.AlertQuery.ToString())
                    {
                        VAlert obj = currentObj as VAlert;
                        MainMenu menu = null;
                        if (obj.BillID != null)
                        {
                            if (obj.内容.Contains("DH"))
                            {
                                menu = MainForm.mainMenuList[MainMenuEnum.Order];
                                MainForm.SetSelected(pageGroupCore, menu);
                                OrderEditPage page = MainForm.itemDetailPageList[MainMenuEnum.Order].itemDetail as OrderEditPage;
                                page.BindData(obj.BillID.Value);
                            }
                            else if (obj.内容.Contains("CK"))
                            {
                                menu = MainForm.mainMenuList[MainMenuEnum.FGStockOutBill];
                                MainForm.SetSelected(pageGroupCore, menu);
                                StockOutBillPage page = MainForm.itemDetailPageList[MainMenuEnum.FGStockOutBill].itemDetail as StockOutBillPage;
                                page.BindData(obj.BillID.Value);
                            }
                        }
                    }
                    else if (mainMenu.Name == MainMenuEnum.SampleStockOutReport.ToString())
                    {
                        VSampleStockOut obj = currentObj as VSampleStockOut;
                        MainMenu menu = MainForm.mainMenuList[MainMenuEnum.FGStockOutBill];
                        MainForm.SetSelected(pageGroupCore, menu);
                        StockOutBillPage page = MainForm.itemDetailPageList[MainMenuEnum.FGStockOutBill].itemDetail as StockOutBillPage;
                        page.BindData(obj.HdID);
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

        /// <summary>
        /// 刷新单据编辑界面基础数据
        /// </summary>
        //void BillEditPageRefresh()
        //{
        //    if (itemDetailPageList.Count >0)
        //    {
        //        //StockInBillPage stockInBillPage = itemDetailPage.itemDetailList[MainMenuEnum.stockinb] as StockInBillPage;
        //        //stockInBillPage.BindData(Guid.Empty);
        //        //OrderEditPage orderEditPage = itemDetailPage.itemDetailList[MainMenuEnum.Order] as OrderEditPage;
        //        //orderEditPage.BindData(Guid.Empty);
        //        //StockOutBillPage stockOutBillPage = itemDetailPage.itemDetailList[MainMenuEnum.OutStoreBill] as StockOutBillPage;
        //        //stockOutBillPage.BindData(Guid.Empty);
                
                
        //    }
        //}

        public void Del()
        {
             try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                MainMenuEnum menuEnum = (MainMenuEnum)Enum.Parse(typeof(MainMenuEnum), mainMenu.Name);
                string btnName = MainForm.itemDetailPageList[menuEnum].btnDel.Caption;
                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}选择的记录吗?", btnName), "操作提示",
                System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    currentObj = gridView.GetRow(gridView.FocusedRowHandle);
                    switch (Enum.Parse(typeof(MainMenuEnum), mainMenu.Name))
                    {
                        case MainMenuEnum.Department:
                            Department dept = currentObj as Department;
                            dept.IsDel = !dept.IsDel;
                            baseFactory.Update<Department>(dept);
                            break;
                        case MainMenuEnum.Company:
                            Company company = currentObj as Company;
                            company.IsDel = !company.IsDel;
                            baseFactory.Update<Company>(company);
                            break;
                        case MainMenuEnum.Supplier:
                            Supplier supplier = currentObj as Supplier;
                            supplier.IsDel = !supplier.IsDel;
                            baseFactory.Update<Supplier>(supplier);
                            break;
                        case MainMenuEnum.UsersInfo:
                            UsersInfo user = currentObj as UsersInfo;
                            user.IsDel = !user.IsDel;
                            baseFactory.Update<UsersInfo>(user);
                            break;
                        case MainMenuEnum.Goods:
                            Goods goods = baseFactory.GetModelList<Goods>().FirstOrDefault(o =>
                            o.ID.Equals(((VGoods)currentObj).ID));
                            goods.IsDel = !goods.IsDel;
                            baseFactory.Update<Goods>(goods);
                            break;
                        case MainMenuEnum.Material:
                            Goods material = currentObj as Goods;
                            material.IsDel = !material.IsDel;
                            baseFactory.Update<Goods>(material);
                            break;
                        case MainMenuEnum.GoodsType:
                            GoodsType goodsType = currentObj as GoodsType;
                            goodsType.IsDel = !goodsType.IsDel;
                            baseFactory.Update<GoodsType>(goodsType);
                            break;
                        case MainMenuEnum.Packaging:
                            Packaging packaging = currentObj as Packaging;
                            packaging.IsDel = !packaging.IsDel;
                            baseFactory.Update<Packaging>(packaging);
                            break;
                    }
                    //gridView.DeleteSelectedRows();
                    baseFactory.DataPageRefresh(menuEnum);
                    CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "删除成功");
                    //BillEditPageRefresh();
                    //itemDetailPageList[mainMenu.Name].DataPageRefresh();
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
            //盘点导入借用
                    int iCount = 1;
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                var openFileDialog = new System.Windows.Forms.OpenFileDialog();
                openFileDialog.Filter = "Excel 97-2003 工作簿|*.xls*|Excel 工作簿|*.xlsx|所有文件|*.*";
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DataSet ds = ExcelHelper.ImportExcel(openFileDialog.FileName);

                    Hashtable hasGoods = new Hashtable();
                    List<Stocktaking> stList = new List<Stocktaking>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        iCount++;

                        Stocktaking st = new Stocktaking();
                        //st.ID = Guid.NewGuid();
                        st.Warehouse = row["盘点仓库"].ToString().Trim();
                        st.WarehouseType = string.IsNullOrEmpty(row["仓库类型"].ToString().Trim()) ? 0 : (row["仓库类型"].ToString().Trim() == "内销" ? 0 : 1);
                        if (!string.IsNullOrEmpty(row["盘点厂商"].ToString().Trim()))
                        {
                            Supplier s = baseFactory.GetModelList<Supplier>().FirstOrDefault(o => o.Name.Contains(row["盘点厂商"].ToString().Trim()));
                            if (s != null)
                                st.SupplierID = s.ID;
                        }
                        st.GoodsBigType = string.IsNullOrEmpty(row["货品大类"].ToString().Trim()) ? 0 :
                            (int)EnumHelper.GetEnumValues<GoodsBigTypeEnum>(false).FirstOrDefault(o => o.Name.Contains(row["货品大类"].ToString().Trim())).Value;
                        st.Goods = row["货号"].ToString().Trim();
                        if (hasGoods[st.WarehouseType.ToString() + st.Goods + st.PCS.ToString()] == null)
                            hasGoods.Add(st.WarehouseType.ToString() + st.Goods + st.PCS.ToString(), st.WarehouseType.ToString() + st.Goods + st.PCS.ToString());
                        else
                        {
                            CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("货号{0}重复。", st.Goods));
                            return false;
                        }
                        st.Qty = Convert.ToDecimal(row["盘点数量"]);
                        st.PCS = Convert.ToInt32(row["装箱数"]);
                        if (!string.IsNullOrEmpty(row["外箱规格"].ToString().Trim()))
                            st.MEAS = row["外箱规格"].ToString().Trim();
                        else
                        {
                            Goods goods = baseFactory.GetModelList<Goods>().FirstOrDefault(o => o.Code.Trim().Equals(st.Goods));
                            if (goods != null)
                                st.MEAS = goods.MEAS;
                        }
                        st.Checker = row["盘点人"].ToString().Trim();
                        st.CheckingDate = DateTime.Today;//Convert.ToDateTime(row["盘点日期"]);
                        if (string.IsNullOrEmpty(st.Goods))
                        {
                            CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("第{0}行记录的货号不能为空。", iCount));
                            return false;
                        }
                        stList.Add(st);
                    }
                    if (stList.Count > 0)
                    {
                        baseFactory.AddByBulkCopy<Stocktaking>(stList);
                        //InitGrid(BLLFty.Create<InventoryBLL>().GetStocktaking());
                        //MainForm.DataQueryPageRefresh();
                        baseFactory.DataPageRefresh<Stocktaking>();
                        List<VProfitAndLoss> vpal = baseFactory.DataPageRefresh<VProfitAndLoss>();
                        //刷新盘点盈亏表
                        if (BaseFactory.itemDetailList.ContainsKey(MainMenuEnum.ProfitAndLoss.ToString()))
                        {
                            DataQueryPage page = BaseFactory.itemDetailList[MainMenuEnum.ProfitAndLoss.ToString()] as DataQueryPage;
                            if (stList[0].GoodsBigType == -1)
                                page.BindData(vpal.FindAll(o =>
                                    o.仓库 == stList[0].Warehouse && o.SupplierID == stList[0].SupplierID));
                            else
                                page.BindData(vpal.FindAll(o =>
                                o.仓库 == stList[0].Warehouse && o.SupplierID == stList[0].SupplierID && o.货品大类 == stList[0].GoodsBigType));
                            CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "导入成功");
                            return true;
                        }
                    }
                }
                return false;
                
            }
            catch (Exception ex)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), string.Format("第{0}行记录格式异常。", iCount) + "\r\n" + ex.Message);
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
                if (mainMenu.Name.Contains("Order") || mainMenu.Name.Contains("Bill"))
                {
                    if (gridView.SelectedRowsCount > 0)
                    {
                        currentObj = gridView.GetRow(gridView.FocusedRowHandle);

                        #region PrintData

                        if (BaseFactory.itemDetailList.ContainsKey(mainMenu.Name.Replace("Query", "").Trim()))
                        {
                            if (currentObj is VStockInBill)
                            {
                                VStockInBill bill = currentObj as VStockInBill;
                                StockInBillPage page = BaseFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as StockInBillPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.入库单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.HeadID = bill.HdID;
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VMaterialStockInBill)
                            {
                                VMaterialStockInBill bill = currentObj as VMaterialStockInBill;
                                StockInBillPage page = BaseFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as StockInBillPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.入库单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.HeadID = bill.HdID;
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VStockOutBill)
                            {
                                VStockOutBill bill = currentObj as VStockOutBill;
                                StockOutBillPage page = BaseFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as StockOutBillPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.出库单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.HeadID = bill.HdID;
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VMaterialStockOutBill)
                            {
                                VMaterialStockOutBill bill = currentObj as VMaterialStockOutBill;
                                StockOutBillPage page = BaseFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as StockOutBillPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.出库单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.HeadID = bill.HdID;
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VOrder)
                            {
                                VOrder bill = currentObj as VOrder;
                                OrderEditPage page = BaseFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as OrderEditPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.订货单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.HeadID = bill.HdID;
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VFSMOrder)
                            {
                                VFSMOrder bill = currentObj as VFSMOrder;
                                OrderEditPage page = BaseFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as OrderEditPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.订货单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.HeadID = bill.HdID;
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VProductionOrder)
                            {
                                VProductionOrder bill = currentObj as VProductionOrder;
                                OrderEditPage page = BaseFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as OrderEditPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.订货单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.HeadID = bill.HdID;
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VReceiptBill)
                            {
                                VReceiptBill bill = currentObj as VReceiptBill;
                                ReceiptBillPage page = BaseFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as ReceiptBillPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.收款单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.HeadID = bill.HdID;
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VPaymentBill)
                            {
                                VPaymentBill bill = currentObj as VPaymentBill;
                                PaymentBillPage page = BaseFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as PaymentBillPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.付款单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.Hd = BLLFty.Create<PaymentBillBLL>().GetPaymentBillHd(bill.HdID);
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VWageBill)
                            {
                                VWageBill bill = currentObj as VWageBill;
                                WageBillPage page = BaseFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as WageBillPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.工资单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.Hd = BLLFty.Create<WageBillBLL>().GetWageBillHd(bill.HdID); //baseFactory.GetData<WageBillHd>().FirstOrDefault(o=>o.ID.Equals(bill.HdID));
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VAttWageBill)
                            {
                                VAttWageBill bill = currentObj as VAttWageBill;
                                AttWageBillPage page = BaseFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as AttWageBillPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.工资单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.Hd = BLLFty.Create<AttWageBillBLL>().GetAttWageBillHd(bill.HdID);
                                    return page.Audit();
                                }
                            }
                        }
                        #endregion
                    }
                    return false;
                }
                else
                {
                    //更新库存盘点功能借用

                    if (gridView.DataRowCount > 0)
                    {
                        System.Windows.Forms.DialogResult result = XtraMessageBox.Show("确定要更新库存盘点吗?更新后将不能撤销。", "操作提示",
                    System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            List<Inventory> inventoryList = new List<Inventory>();
                            List<AccountBook> accountBooklist = new List<AccountBook>();
                            List<VProfitAndLoss> plList = gridControl.DataSource as List<VProfitAndLoss>;
                            foreach (VProfitAndLoss item in plList)
                            {
                                //库存数据
                                Inventory obj = new Inventory();
                                obj.ID = Guid.NewGuid();
                                obj.WarehouseID = item.WarehouseID;
                                obj.WarehouseType = item.仓库类型;
                                //obj.WarehouseType=item.wa
                                //obj.CompanyID=item  //盘点时货品没区分客户全盘在一起，所以不填
                                obj.SupplierID = item.SupplierID;
                                //obj.DeptID=item.//盘点时货品没区分部门全盘在一起，所以不填
                                obj.GoodsID = item.GoodsID;
                                obj.Qty = item.盘点数量.Value;
                                obj.MEAS = item.外箱规格;// baseFactory.GetModelList<Goods>().FirstOrDefault(o => o.ID == item.GoodsID).MEAS;
                                obj.PCS = item.装箱数;
                                obj.InnerBox = item.内盒;
                                obj.Price = item.单价;
                                obj.Discount = 1;
                                obj.OtherFee = 0;
                                obj.EntryDate = DateTime.Now;
                                obj.BillNo = "库存盘点";
                                obj.BillDate = DateTime.Now;
                                inventoryList.Add(obj);
                                //账页数据
                                AccountBook ab = new AccountBook();
                                ab.ID = Guid.NewGuid();
                                ab.WarehouseID = item.WarehouseID;
                                ab.WarehouseType = item.仓库类型;
                                ab.GoodsID = item.GoodsID;
                                ab.AccntDate = DateTime.Now;
                                ab.MEAS = item.外箱规格;
                                ab.PCS = item.装箱数;
                                ab.Price = item.单价;
                                ab.Discount = 1;
                                ab.OtherFee = 0;
                                ab.InQty = item.盘点数量.Value;
                                ab.BalanceQty = item.盘点数量.Value;
                                ab.BalanceCost = ab.BalanceQty * ab.Price * ab.Discount + ab.OtherFee;
                                ab.BillNo = "库存盘点";
                                ab.BillDate = DateTime.Now;
                                accountBooklist.Add(ab);
                            }
                            //BLLFty.Create<InventoryBLL>().StocktakingUpdate(inventoryList[0].WarehouseID, inventoryList);
                            List<VStocktaking> stocktakingList = baseFactory.GetModelList<VStocktaking>();
                            Guid warehouseID = Guid.Empty;
                            int goodsBigType = -1;
                            if (stocktakingList.Count > 0)
                            {
                                switch (stocktakingList[0].盘点仓库)
                                {
                                    case "成品仓":
                                        warehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseEnum.FG.ToString()).ID;
                                        break;
                                    case "半成品仓":
                                        warehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseEnum.SFG.ToString()).ID;
                                        break;
                                    case "外加工":
                                        warehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseEnum.EMS.ToString()).ID;
                                        break;
                                    case "自动机":
                                        warehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseEnum.FSM.ToString()).ID;
                                        break;
                                    default:
                                        break;
                                }
                                goodsBigType = stocktakingList[0].货品大类;
                            }
                            if (warehouseID == Guid.Empty)
                            {
                                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "没有盘点数据，请先导入盘点数据。");
                                return false;
                            }
                            inventoryFactory.StocktakingUpdate(warehouseID, goodsBigType, stocktakingList[0].SupplierID, inventoryList, accountBooklist);
                            //MainForm.DataQueryPageRefresh();
                            baseFactory.DataPageRefresh<VProfitAndLoss>();
                            CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "盘点库存更新成功");
                            return true;
                        }
                    }
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
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        public void Print()
        {
            PrintSettingController psc = null;
            //if (mainMenu.Name.Contains("Order") || mainMenu.Name.Contains("Bill"))
            if (mainMenu.Name.Contains("StatementOfAccount"))
            {
                if (gridView.SelectedRowsCount > 0)
                {
                    currentObj = gridView.GetRow(gridView.FocusedRowHandle);

                    #region PrintData
                    
                    if (currentObj is StatementOfAccountToCustomerReport && BaseFactory.itemDetailList.ContainsKey(MainMenuEnum.ReceiptBill.ToString()))
                    {
                        StatementOfAccountToCustomerReport bill = currentObj as StatementOfAccountToCustomerReport;
                        ReceiptBillPage page = BaseFactory.itemDetailList[MainMenuEnum.ReceiptBill.ToString()] as ReceiptBillPage;
                        page.BindData(baseFactory.GetModelList<ReceiptBillHd>().FirstOrDefault(o => o.BillNo == bill.收款单号).ID);
                        page.SendData(null);
                    }
                    else if (currentObj is StatementOfAccountToSupplierReport && BaseFactory.itemDetailList.ContainsKey(MainMenuEnum.PaymentBill.ToString()))
                    {
                        StatementOfAccountToSupplierReport bill = currentObj as StatementOfAccountToSupplierReport;
                        PaymentBillPage page = BaseFactory.itemDetailList[MainMenuEnum.PaymentBill.ToString()] as PaymentBillPage;
                        page.BindData(baseFactory.GetModelList<PaymentBillHd>().FirstOrDefault(o => o.BillNo == bill.付款单号).ID);
                        page.SendData(null);
                    }

                    #endregion
                }
                psc.IsBill = true;
            }
            else
            {
                //foreach (DevExpress.XtraGrid.Columns.GridColumn col in ((GridView)gridControl.MainView).Columns)
                //{
                //    col.BestFit();
                //}
                psc = new PrintSettingController(this.gridControl);
                //页眉 
                psc.PrintCompany = MainForm.Company;
                psc.PrintLeftHeader = this.lblHistoryFilter.Text.Substring(lblHistoryFilter.Text.IndexOf('：') + 1);
                if (mainMenu.Caption == "物料资料")
                    psc.PrintHeader = MainForm.GoodsBigTypeName;
                else
                    psc.PrintHeader = mainMenu.Caption;
                psc.PrintSubTitle = MainForm.Contacts.Replace("\\r\\n", "\r\n");
                //页脚 
                //psc.PrintRightFooter = "打印日期：" + DateTime.Now.ToString();

                psc.IsBill = false;

                //横纵向 
                //psc.LandScape = this.rbtnHorizon.Checked;
                if (psc.IsBill || (MainForm.Company.Contains("镇阳") && mainMenu.Name==MainMenuEnum.FGStockOutBillQuery.ToString()))
                    psc.LandScape = false;
                else
                    psc.LandScape = true;
                //纸型 
                psc.PaperKind = System.Drawing.Printing.PaperKind.A4;
                //加载页面设置信息 
                psc.LoadPageSetting();

                psc.Preview();
            }

        }

        private void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value != null)
            {
                //List<TypesList> types = baseFactory.GetModelList<TypesList>();
                //if (displayUsers != null && (e.Column.FieldName == "制单人" || e.Column.FieldName == "审核人") && e.Value is Guid)
                //{
                //    e.DisplayText = displayUsers.Find(o => o.ID == new Guid(e.Value.ToString())).姓名;
                //}
                if (e.Column.FieldName == "状态")
                {
                    e.DisplayText = EnumHelper.GetDescription<BillStatus>((BillStatus)e.Value, false);
                }
                if (e.Column.FieldName == "工资状态")
                {
                    e.DisplayText = EnumHelper.GetDescription<WageStatus>((WageStatus)e.Value, false);
                }
                if (e.Column.FieldName == "考勤状态")
                {
                    e.DisplayText = EnumHelper.GetDescription<AttStatusType>((AttStatusType)e.Value, false);
                }
                if (e.Column.FieldName == "订单类型")
                {
                    e.DisplayText = EnumHelper.GetDescription<OrderBillType>((OrderBillType)e.Value, false);
                }
                else if (e.Column.FieldName == "货品大类")
                {
                    e.DisplayText = EnumHelper.GetDescription<GoodsBigTypeEnum>((GoodsBigTypeEnum)e.Value, false);
                }
                else if (e.Column.FieldName == "班次" && mainMenu.Name != MainMenuEnum.AttWageBillQuery.ToString())
                {
                    e.DisplayText = EnumHelper.GetDescription<WorkShiftsType>((WorkShiftsType)e.Value, false);
                }
                else if (e.Column.FieldName == "机号")
                {
                    e.DisplayText = EnumHelper.GetDescription<MachineType>((MachineType)e.Value, false);
                }
                else if (e.Value is int && (e.Column.FieldName == "客户类型" || e.Column.FieldName == "仓库类型"))
                {
                    e.DisplayText = EnumHelper.GetDescription<CustomerTypeEnum>((CustomerTypeEnum)e.Value, false);// types.Find(o => o.Type == TypesEnum.CustomerType.ToString() && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                }
                else if (e.Value is int && e.Column.FieldName == "供应商类型")
                {
                    e.DisplayText = EnumHelper.GetDescription<SupplierTypeEnum>((SupplierTypeEnum)e.Value, false);//types.Find(o => o.Type == TypesListConstants.SupplierType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                }
                else if (e.Value is int && e.Column.FieldName.Contains("特权"))
                {
                    e.DisplayText = EnumHelper.GetDescription<PrivilegeTypeEnum>((PrivilegeTypeEnum)e.Value, false);//types.Find(o => o.Type == TypesListConstants.PrivilegeType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                }
                else if (e.Value is int && e.Column.FieldName == "验证方式")
                {
                    e.DisplayText = EnumHelper.GetDescription<VerifyMethodTypeEnum>((VerifyMethodTypeEnum)e.Value, false);//types.Find(o => o.Type == TypesListConstants.VerifyMethodType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                }
                else if (e.Value is int && e.Column.FieldName == "结算方式")
                {
                    e.DisplayText = EnumHelper.GetDescription<POClearTypeEnum>((POClearTypeEnum)e.Value, false);//types.Find(o => o.Type == TypesListConstants.POClearType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                }
                else if (e.Value is int && e.Column.FieldName == "收款类型")
                {
                    e.DisplayText = EnumHelper.GetDescription<ReceiptBillTypeEnum>((ReceiptBillTypeEnum)e.Value, false);// types.Find(o => o.Type == TypesListConstants.ReceiptBillType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                }
                else if (e.Value is int && e.Column.FieldName == "付款类型")
                {
                    e.DisplayText = EnumHelper.GetDescription<PaymentBillTypeEnum>((PaymentBillTypeEnum)e.Value, false); //types.Find(o => o.Type == TypesListConstants.PaymentBillType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                }
                else if (e.Value is int && e.Column.FieldName == "类型")
                {
                    if (mainMenu.Name.Contains(MainMenuEnum.GetMaterialBill.ToString()))
                        e.DisplayText = EnumHelper.GetDescription<StockOutBillTypeEnum>((StockOutBillTypeEnum)e.Value, false); //types.FirstOrDefault(o => o.Type == MainMenuEnum.StockOutBillType.ToString() && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                    else if (mainMenu.Name.Contains(MainMenuEnum.ReturnedMaterialBill.ToString()))
                        e.DisplayText = EnumHelper.GetDescription<StockInBillTypeEnum>((StockInBillTypeEnum)e.Value, false); //types.FirstOrDefault(o => o.Type == MainMenuEnum.StockInBillType.ToString() && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                    else
                        e.DisplayText = EnumHelper.GetDescription<MainMenuEnum>((MainMenuEnum)e.Value, false); //types.Find(o => (mainMenu.Name.Contains(o.Type.Substring(0, 7)) || mainMenu.Name.Contains(o.SubType)) && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                }
                    
            }
        }

        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "状态")
            {
                GridCellInfo gridCellInfo = e.Cell as GridCellInfo;
                if (gridCellInfo.IsDataCell && gridCellInfo.CellValue != null &&
                    (int.Parse(gridCellInfo.CellValue.ToString()) == (int)BillStatus.UnAudited ||
                    int.Parse(gridCellInfo.CellValue.ToString()) == (int)BillStatus.UnCleared ||
                    int.Parse(gridCellInfo.CellValue.ToString()) == (int)WageStatus.UnClosed))
                    e.Appearance.ForeColor = Color.Red;
            }
            if (e.Column.FieldName == "工资状态")
            {
                GridCellInfo gridCellInfo = e.Cell as GridCellInfo;
                if (gridCellInfo.IsDataCell && gridCellInfo.CellValue != null &&
                    int.Parse(gridCellInfo.CellValue.ToString()) == (int)WageStatus.UnClosed)
                    e.Appearance.ForeColor = Color.Red;
            }
            if (mainMenu.Name.ToUpper().Contains("ORDER") && e.Column.FieldName == "类型")
            {
                GridCellInfo gridCellInfo = e.Cell as GridCellInfo;
                if (gridCellInfo.IsDataCell && gridCellInfo.CellValue != null && int.Parse(gridCellInfo.CellValue.ToString()) == (int)OrderTypeEnum.Emergency)
                    e.Appearance.ForeColor = Color.Red;
            }

            MainMenuEnum menuEnum = (MainMenuEnum)Enum.Parse(typeof(MainMenuEnum), mainMenu.Name);
            if (MainForm.itemDetailPageList[menuEnum].btnConnect != null)
            {
                if (MainForm.IsConnected)
                {
                    MainForm.itemDetailPageList[menuEnum].btnConnect.Caption = "断开设备";
                    MainForm.itemDetailPageList[menuEnum].btnConnect.Glyph = global::USL.Properties.Resources.switch_off_54px;
                }
                else
                {
                    MainForm.itemDetailPageList[menuEnum].btnConnect.Caption = "连接设备";
                    MainForm.itemDetailPageList[menuEnum].btnConnect.Glyph = global::USL.Properties.Resources.switch_on_54px;
                }
            }
        
        }

        private void gvLedgerDtlForPrint_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.Column.FieldName == "Type")
                {
                    if (mainMenu.Name == MainMenuEnum.ReceiptBillQuery.ToString())
                        e.DisplayText = EnumHelper.GetDescription<ReceiptBillTypeEnum>((ReceiptBillTypeEnum)e.Value, false);
                        //e.DisplayText = types.Find(o => o.Type == TypesListConstants.ReceiptBillType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                    else if (mainMenu.Name == MainMenuEnum.PaymentBillQuery.ToString())
                        e.DisplayText = EnumHelper.GetDescription<PaymentBillTypeEnum>((PaymentBillTypeEnum)e.Value, false);
                    //e.DisplayText = types.Find(o => o.Type == TypesListConstants.PaymentBillType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                }
            }
        }

        private void gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            object o = gridView.GetRowCellValue(e.RowHandle, "已删除");
            if (o != null && bool.Parse(o.ToString()))
            {
                e.Appearance.Font = new Font(e.Appearance.Font,FontStyle.Italic);
                e.Appearance.FontStyleDelta = FontStyle.Strikeout;
            }
            object s = gridView.GetRowCellValue(e.RowHandle, "停产");
            if (s != null && bool.Parse(s.ToString()))
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }

        public void Import()
        {
            throw new NotImplementedException();
        }

        public void Export()
        {
            //借用于设置货品停产
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                System.Windows.Forms.DialogResult result = XtraMessageBox.Show("确定要停产选择的货品吗?", "操作提示",
                System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    MainMenuEnum menuEnum = (MainMenuEnum)Enum.Parse(typeof(MainMenuEnum), mainMenu.Name);
                    currentObj = gridView.GetRow(gridView.FocusedRowHandle);
                    Goods goods = currentObj as Goods;
                    baseFactory.Update<Goods>(goods);
                    baseFactory.DataPageRefresh(menuEnum);
                    CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "货品设置停产成功");
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

        public void SendData(object data)
        {
            throw new NotImplementedException();
        }

        public object ReceiveData()
        {
            currentObj = gridView.GetRow(gridView.FocusedRowHandle);
            if (mainMenu.Name == MainMenuEnum.ProductionOrderQuery.ToString())
            {
                if (currentObj == null)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请选择要产品回收的布产单。");
                    return null;
                }
                VProductionOrder order = currentObj as VProductionOrder;
                if (order == null || order.状态 == (int)BillStatus.UnAudited)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "未审核布产单不允许回收产品。");
                    return null;
                }
                if (order.SupplierID == null)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请填写加工厂家。");
                    return null;
                }
                if (order.未收箱数 <= 0)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "布产数量已经全部发完，不能再回收产品。");
                    return null;
                }

                System.Windows.Forms.DialogResult result = XtraMessageBox.Show("确定要回收产品吗?", "操作提示",
                               System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    return currentObj;
                }
                else
                    return null;
            }
            else if (mainMenu.Name == MainMenuEnum.SalesReturnBillQuery.ToString())
            {
                if (currentObj == null)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请选择要退料的退货单。");
                    return null;
                }
                VStockInBill bill = currentObj as VStockInBill;
                //if (bill == null || bill.状态 == (int)BillStatus.UnAudited)
                //{
                //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "未审核退货单不允许退料入库。");
                //    return null;
                //}
                if (bill.已退料入库 == true)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "该退货单物料已退货入库。");
                    return null;
                }

                System.Windows.Forms.DialogResult result = XtraMessageBox.Show("确定要将退货物料入库吗?", "操作提示",
                               System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    return currentObj;
                }
                else
                    return null;
            }
            else
                return currentObj;
        }
    }
}
