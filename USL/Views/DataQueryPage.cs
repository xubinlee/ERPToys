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
using IWcfServiceInterface;
using Common;

namespace USL
{
    public partial class DataQueryPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail, IExtensions
    {
        private static IInventoryService inventoryService = ServiceProxyFactory.Create<IInventoryService>("InventoryService");
        private static ClientFactory clientFactory = LoggerInterceptor.CreateProxy<ClientFactory>();
        public MainMenu mainMenu;
        IList dataSource;
        Object currentObj = null;
        PageGroup pageGroupCore;
        Dictionary<String, int> itemDetailButtonList; //子菜单按钮项
        //Dictionary<String, ItemDetailPage> itemDetailPageList;
        WindowsUIView view = null;
        //List<VUsersInfo> displayUsers;
        List<TypesList> types;   //类型列表
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
            types = clientFactory.GetData<TypesList>();
            warehouseList = clientFactory.GetData<Warehouse>();
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
            MainForm.SetQueryPageGridColumn(gridView,mainMenu);
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
                            MainForm.itemDetailPageList[mainMenu.Name].btnAudit.Visible = true;
                            MainForm.itemDetailPageList[mainMenu.Name].btnAudit.Caption = "审核";
                            MainForm.itemDetailPageList[mainMenu.Name].btnAudit.Glyph = global::USL.Properties.Resources.audit;
                        }
                        else if (Convert.ToInt32(gridView.GetRowCellValue(hInfo.RowHandle, "状态")) == 1)// && !mainMenu.Name.Contains("Order"))
                        {
                            MainForm.itemDetailPageList[mainMenu.Name].btnAudit.Visible = true;
                            MainForm.itemDetailPageList[mainMenu.Name].btnAudit.Caption = "取消审核";
                            MainForm.itemDetailPageList[mainMenu.Name].btnAudit.Glyph = global::USL.Properties.Resources.Undo_32x32;
                        }
                        else
                            MainForm.itemDetailPageList[mainMenu.Name].btnAudit.Visible = false;
                    }
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1 && mainMenu.Name==MainMenuConstants.Staff)  //单击左键
                {
                    //object obj = gridView.GetRow(gridView.FocusedRowHandle);
                    if (hInfo.InRowCell)
                    {
                        if (Convert.ToBoolean(gridView.GetRowCellValue(hInfo.RowHandle, "已删除")))
                        {
                            MainForm.itemDetailPageList[mainMenu.Name].btnDel.Caption = "恢复";
                        }
                        else
                            MainForm.itemDetailPageList[mainMenu.Name].btnDel.Caption = "删除";
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
                if (MainForm.itemDetailPageList.Count > 0)
                {

                    //加载窗体页面
                    if (MainForm.hasItemDetailPage[mainMenu.Name.Replace("Query", "")] == null)
                    {
                        MainForm.itemDetailPageList[mainMenu.Name.Replace("Query", "")].LoadBusinessData(MainForm.mainMenuList[mainMenu.Name.Replace("Query", "")]);
                        MainForm.hasItemDetailPage.Add(mainMenu.Name.Replace("Query", ""), true);
                    }
                    //切换到对应的单据界面并传递数据
                    if (mainMenu.Name.ToUpper().Contains("BILLQUERY"))
                    {
                        if (mainMenu.Name.ToUpper().Contains("STOCKOUT") || mainMenu.Name == MainMenuConstants.GetMaterialBillQuery
                            || mainMenu.Name == MainMenuConstants.FSMDPReturnBillQuery || mainMenu.Name == MainMenuConstants.EMSDPReturnBillQuery)
                        {
                            StockOutBillPage page = MainForm.itemDetailPageList[mainMenu.Name.Replace("Query", "")].itemDetail as StockOutBillPage;
                            if (mainMenu.Name == MainMenuConstants.FGStockOutBillQuery)
                                page.BindData(((VStockOutBill)currentObj).HdID);
                            else
                                page.BindData(((VMaterialStockOutBill)currentObj).HdID);
                        }
                        else if (mainMenu.Name.ToUpper().Contains("STOCKIN") || mainMenu.Name.ToUpper().Contains("ReturnBill".ToUpper()) || mainMenu.Name == MainMenuConstants.ReturnedMaterialBillQuery)
                        {
                            StockInBillPage page = MainForm.itemDetailPageList[mainMenu.Name.Replace("Query", "")].itemDetail as StockInBillPage;
                            if (mainMenu.Name == MainMenuConstants.ProductionStockInBillQuery || mainMenu.Name == MainMenuConstants.SalesReturnBillQuery)
                                page.BindData(((VStockInBill)currentObj).HdID);
                            else
                                page.BindData(((VMaterialStockInBill)currentObj).HdID);
                        }
                        else if (mainMenu.Name == MainMenuConstants.ReceiptBillQuery)
                        {
                            ReceiptBillPage page = MainForm.itemDetailPageList[mainMenu.Name.Replace("Query", "")].itemDetail as ReceiptBillPage;
                            page.BindData(((VReceiptBill)currentObj).HdID);
                        }
                        else if (mainMenu.Name == MainMenuConstants.PaymentBillQuery)
                        {
                            PaymentBillPage page = MainForm.itemDetailPageList[mainMenu.Name.Replace("Query", "")].itemDetail as PaymentBillPage;
                            page.BindData(((VPaymentBill)currentObj).HdID);
                        }
                        else if (mainMenu.Name == MainMenuConstants.WageBillQuery)
                        {
                            WageBillPage page = MainForm.itemDetailPageList[mainMenu.Name.Replace("Query", "")].itemDetail as WageBillPage;
                            page.BindData(((VWageBill)currentObj).HdID);
                        }
                        else if (mainMenu.Name == MainMenuConstants.AttWageBillQuery)
                        {
                            AttWageBillPage page = MainForm.itemDetailPageList[mainMenu.Name.Replace("Query", "")].itemDetail as AttWageBillPage;
                            page.BindData(((VAttWageBill)currentObj).HdID);
                        }
                    }
                    else if (mainMenu.Name == MainMenuConstants.OrderQuery)
                    {
                        OrderEditPage page = MainForm.itemDetailPageList[MainMenuConstants.Order].itemDetail as OrderEditPage;
                        page.BindData(((VOrder)currentObj).HdID);
                    }
                    else if (mainMenu.Name == MainMenuConstants.FSMOrderQuery)
                    {
                        OrderEditPage page = MainForm.itemDetailPageList[MainMenuConstants.FSMOrder].itemDetail as OrderEditPage;
                        page.BindData(((VFSMOrder)currentObj).HdID);
                    }
                    else if (mainMenu.Name == MainMenuConstants.ProductionOrderQuery)
                    {
                        OrderEditPage page = MainForm.itemDetailPageList[MainMenuConstants.ProductionOrder].itemDetail as OrderEditPage;
                        page.BindData(((VProductionOrder)currentObj).HdID);
                    }
                    else
                        return MainForm.mainMenuList[mainMenu.Name.Replace("Query", "")];

                    pageGroupCore.SetSelected(pageGroupCore.Items[itemDetailButtonList[mainMenu.Name] - 1]);
                    view.ActivateContainer(pageGroupCore);
                }
                return MainForm.mainMenuList[mainMenu.Name.Replace("Query", "")];
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
                    currentObj = gridView.GetRow(gridView.FocusedRowHandle);
                    if (mainMenu.ParentID == new Guid("7ea0e093-592a-420c-9a7f-8316f88c35e2"))//基础资料
                    {
                        IList goodsList = null;
                        if (mainMenu.Name == MainMenuConstants.Material)
                        {
                            MainForm.GoodsBigType = types.Find(o =>
                                o.Type == TypesListConstants.GoodsType && o.Name == MainForm.GoodsBigTypeName).No;
                        }
                        int focusRow = gridView.FocusedRowHandle;
                        DataEditForm form = new DataEditForm(mainMenu, currentObj, pageGroupCore);
                        form.ShowDialog();
                        if (mainMenu.Name == MainMenuConstants.Material)
                        {
                            goodsList = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type == MainForm.GoodsBigType);
                            BindData(goodsList);
                        }
                        //刷新数据
                        //itemDetailPage.DataQueryPageRefresh();
                        gridView.FocusedRowHandle = focusRow;
                    }
                    else if (mainMenu.Name.ToUpper().Contains("BILL") || mainMenu.Name.ToUpper().Contains("ORDER"))
                    {
                        MainMenu menu = NavMenu(currentObj);
                        //List<TypesList> types = MainForm.dataSourceList[typeof(List<TypesList>)] as List<TypesList>;
                        //string menuName = types.Find(o => (mainMenu.Name.Contains(o.Type.Substring(0, 7)) || mainMenu.Name.Contains(o.SubType)) && o.No == Convert.ToInt32(Convert.ToInt32(gridView.GetFocusedRowCellValue("单据类型")))).SubType;
                        if (Convert.ToInt32(gridView.GetFocusedRowCellValue("状态")) == 0)
                        //    itemDetailPageList[mainMenu.Name.Replace("Query", "")].setNavButtonStatus(ButtonType.btnSave);
                        //else
                            //    itemDetailPageList[mainMenu.Name.Replace("Query", "")].setNavButtonStatus(ButtonType.btnAudit);
                            MainForm.itemDetailPageList[mainMenu.Name.Replace("Query", "")].setNavButtonStatus(menu, ButtonType.btnSave);
                        else
                            MainForm.itemDetailPageList[mainMenu.Name.Replace("Query", "")].setNavButtonStatus(menu, ButtonType.btnAudit);
                    }
                    else if (mainMenu.Name == MainMenuConstants.AlertQuery)
                    {
                        VAlert obj = currentObj as VAlert;
                        MainMenu menu = null;
                        if (obj.BillID != null)
                        {
                            if (obj.内容.Contains("DH"))
                            {
                                menu = MainForm.mainMenuList[MainMenuConstants.Order];
                                MainForm.SetSelected(pageGroupCore, menu);
                                OrderEditPage page = MainForm.itemDetailPageList[MainMenuConstants.Order].itemDetail as OrderEditPage;
                                page.BindData(obj.BillID.Value);
                            }
                            else if (obj.内容.Contains("CK"))
                            {
                                menu = MainForm.mainMenuList[MainMenuConstants.FGStockOutBill];
                                MainForm.SetSelected(pageGroupCore, menu);
                                StockOutBillPage page = MainForm.itemDetailPageList[MainMenuConstants.FGStockOutBill].itemDetail as StockOutBillPage;
                                page.BindData(obj.BillID.Value);
                            }
                        }
                    }
                    else if (mainMenu.Name == MainMenuConstants.SampleStockOutReport)
                    {
                        VSampleStockOut obj = currentObj as VSampleStockOut;
                        MainMenu menu = MainForm.mainMenuList[MainMenuConstants.FGStockOutBill];
                        MainForm.SetSelected(pageGroupCore, menu);
                        StockOutBillPage page = MainForm.itemDetailPageList[MainMenuConstants.FGStockOutBill].itemDetail as StockOutBillPage;
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
        //        //StockInBillPage stockInBillPage = itemDetailPage.itemDetailList[MainMenuConstants.stockinb] as StockInBillPage;
        //        //stockInBillPage.BindData(Guid.Empty);
        //        //OrderEditPage orderEditPage = itemDetailPage.itemDetailList[MainMenuConstants.Order] as OrderEditPage;
        //        //orderEditPage.BindData(Guid.Empty);
        //        //StockOutBillPage stockOutBillPage = itemDetailPage.itemDetailList[MainMenuConstants.OutStoreBill] as StockOutBillPage;
        //        //stockOutBillPage.BindData(Guid.Empty);
                
                
        //    }
        //}

        public void Del()
        {
             try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                string btnName = MainForm.itemDetailPageList[mainMenu.Name].btnDel.Caption;
                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}选择的记录吗?", btnName), "操作提示",
                System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    currentObj = gridView.GetRow(gridView.FocusedRowHandle);
                    switch (mainMenu.Name)
                    {
                        case MainMenuConstants.Department:
                            BLLFty.Create<DepartmentBLL>().Delete(((VDepartment)currentObj).ID);
                            break;
                        case MainMenuConstants.Company:
                            BLLFty.Create<CompanyBLL>().Delete(((VCompany)currentObj).ID);
                            break;
                        case MainMenuConstants.Supplier:
                            BLLFty.Create<SupplierBLL>().Delete(((VSupplier)currentObj).ID);
                            break;
                        case MainMenuConstants.Staff:
                            UsersInfo user = ((List<UsersInfo>)MainForm.dataSourceList[typeof(List<UsersInfo>)]).FirstOrDefault(o =>
                                o.ID == ((VUsersInfo)currentObj).ID);
                            if (user == null)
                            {
                                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "操作失败，请刷新数据重试。");
                                return;
                            }
                            else
                            {
                                user.IsDel = !user.IsDel;
                                clientFactory.Delete<UsersInfo>(user);
                            }
                            //BLLFty.Create<UsersInfoBLL>().Delete(((VUsersInfo)currentObj).ID);
                            break;
                        case MainMenuConstants.Goods:
                            BLLFty.Create<GoodsBLL>().Delete(((VGoods)currentObj).ID);
                            break;
                        case MainMenuConstants.Material:
                            BLLFty.Create<GoodsBLL>().Delete(((VMaterial)currentObj).ID);
                            break;
                        case MainMenuConstants.GoodsType:
                            BLLFty.Create<GoodsTypeBLL>().Delete(((VGoodsType)currentObj).ID);
                            break;
                        case MainMenuConstants.Packaging:
                            BLLFty.Create<PackagingBLL>().Delete(((VPackaging)currentObj).ID);
                            break;
                    }
                    //gridView.DeleteSelectedRows();
                    clientFactory.DataPageRefresh(mainMenu.Name);
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
                            Supplier s = ((List<Supplier>)MainForm.dataSourceList[typeof(List<Supplier>)]).FirstOrDefault(o => o.Name.Contains(row["盘点厂商"].ToString().Trim()));
                            if (s != null)
                                st.SupplierID = s.ID;
                        }
                        st.GoodsBigType = string.IsNullOrEmpty(row["货品大类"].ToString().Trim()) ? 0 :
                            (int)EnumHelper.GetEnumValues<GoodsBigType>(false).FirstOrDefault(o => o.Name.Contains(row["货品大类"].ToString().Trim())).Value;
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
                            Goods goods = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FirstOrDefault(o => o.Code.Trim().Equals(st.Goods));
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
                        clientFactory.AddByBulkCopy<Stocktaking>(stList);
                        //InitGrid(BLLFty.Create<InventoryBLL>().GetStocktaking());
                        //MainForm.DataQueryPageRefresh();
                        clientFactory.DataPageRefresh<Stocktaking>();
                        List<VProfitAndLoss> vpal = clientFactory.UpdateCache<VProfitAndLoss>();
                        //刷新盘点盈亏表
                        if (ClientFactory.itemDetailList.ContainsKey(MainMenuConstants.ProfitAndLoss))
                        {
                            DataQueryPage page = ClientFactory.itemDetailList[MainMenuConstants.ProfitAndLoss] as DataQueryPage;
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

                        if (ClientFactory.itemDetailList.ContainsKey(mainMenu.Name.Replace("Query", "").Trim()))
                        {
                            if (currentObj is VStockInBill)
                            {
                                VStockInBill bill = currentObj as VStockInBill;
                                StockInBillPage page = ClientFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as StockInBillPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.入库单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.Hd = BLLFty.Create<StockInBillBLL>().GetStockInBillHd(bill.HdID);
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VMaterialStockInBill)
                            {
                                VMaterialStockInBill bill = currentObj as VMaterialStockInBill;
                                StockInBillPage page = ClientFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as StockInBillPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.入库单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.Hd = BLLFty.Create<StockInBillBLL>().GetStockInBillHd(bill.HdID);
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VStockOutBill)
                            {
                                VStockOutBill bill = currentObj as VStockOutBill;
                                StockOutBillPage page = ClientFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as StockOutBillPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.出库单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.Hd = BLLFty.Create<StockOutBillBLL>().GetStockOutBillHd(bill.HdID); //clientFactory.GetData<StockOutBillHd>().FirstOrDefault(o => o.ID.Equals(bill.HdID));
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VMaterialStockOutBill)
                            {
                                VMaterialStockOutBill bill = currentObj as VMaterialStockOutBill;
                                StockOutBillPage page = ClientFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as StockOutBillPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.出库单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.Hd = BLLFty.Create<StockOutBillBLL>().GetStockOutBillHd(bill.HdID);// clientFactory.GetData<StockOutBillHd>().FirstOrDefault(o => o.ID.Equals(bill.HdID));
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VOrder)
                            {
                                VOrder bill = currentObj as VOrder;
                                OrderEditPage page = ClientFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as OrderEditPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.订货单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.Hd = BLLFty.Create<OrderBLL>().GetOrderHd(bill.HdID);
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VFSMOrder)
                            {
                                VFSMOrder bill = currentObj as VFSMOrder;
                                OrderEditPage page = ClientFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as OrderEditPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.订货单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.Hd = BLLFty.Create<OrderBLL>().GetOrderHd(bill.HdID);
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VProductionOrder)
                            {
                                VProductionOrder bill = currentObj as VProductionOrder;
                                OrderEditPage page = ClientFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as OrderEditPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.订货单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.Hd = BLLFty.Create<OrderBLL>().GetOrderHd(bill.HdID);
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VReceiptBill)
                            {
                                VReceiptBill bill = currentObj as VReceiptBill;
                                ReceiptBillPage page = ClientFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as ReceiptBillPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.收款单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.Hd = BLLFty.Create<ReceiptBillBLL>().GetReceiptBillHd(bill.HdID);
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VPaymentBill)
                            {
                                VPaymentBill bill = currentObj as VPaymentBill;
                                PaymentBillPage page = ClientFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as PaymentBillPage;
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
                                WageBillPage page = ClientFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as WageBillPage;
                                page.BindData(bill.HdID);
                                System.Windows.Forms.DialogResult result = XtraMessageBox.Show(string.Format("确定要{0}审核单据:{1}吗?", bill.状态 == 1 ? "取消" : "", bill.工资单号), "操作提示",
                        System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    page.Hd = BLLFty.Create<WageBillBLL>().GetWageBillHd(bill.HdID); //clientFactory.GetData<WageBillHd>().FirstOrDefault(o=>o.ID.Equals(bill.HdID));
                                    return page.Audit();
                                }
                            }
                            else if (currentObj is VAttWageBill)
                            {
                                VAttWageBill bill = currentObj as VAttWageBill;
                                AttWageBillPage page = ClientFactory.itemDetailList[mainMenu.Name.Replace("Query", "").Trim()] as AttWageBillPage;
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
                                obj.MEAS = item.外箱规格;// ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FirstOrDefault(o => o.ID == item.GoodsID).MEAS;
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
                            List<VStocktaking> stocktakingList = clientFactory.GetData<VStocktaking>();
                            Guid warehouseID = Guid.Empty;
                            int goodsBigType = -1;
                            if (stocktakingList.Count > 0)
                            {
                                switch (stocktakingList[0].盘点仓库)
                                {
                                    case "成品仓":
                                        warehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.FG).ID;
                                        break;
                                    case "半成品仓":
                                        warehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.SFG).ID;
                                        break;
                                    case "外加工":
                                        warehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.EMS).ID;
                                        break;
                                    case "自动机":
                                        warehouseID = warehouseList.FirstOrDefault(o => o.Code == WarehouseConstants.FSM).ID;
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
                            inventoryService.StocktakingUpdate(warehouseID, goodsBigType, stocktakingList[0].SupplierID, inventoryList, accountBooklist);
                            //MainForm.DataQueryPageRefresh();
                            clientFactory.DataPageRefresh<VProfitAndLoss>();
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
                    
                    if (currentObj is DBML.StatementOfAccountToCustomerReport && ClientFactory.itemDetailList.ContainsKey(MainMenuConstants.ReceiptBill))
                    {
                        DBML.StatementOfAccountToCustomerReport bill = currentObj as DBML.StatementOfAccountToCustomerReport;
                        ReceiptBillPage page = ClientFactory.itemDetailList[MainMenuConstants.ReceiptBill] as ReceiptBillPage;
                        page.BindData(((List<ReceiptBillHd>)MainForm.dataSourceList[typeof(List<ReceiptBillHd>)]).FirstOrDefault(o => o.BillNo == bill.收款单号).ID);
                        page.SendData(null);
                    }
                    else if (currentObj is DBML.StatementOfAccountToSupplierReport && ClientFactory.itemDetailList.ContainsKey(MainMenuConstants.PaymentBill))
                    {
                        DBML.StatementOfAccountToSupplierReport bill = currentObj as DBML.StatementOfAccountToSupplierReport;
                        PaymentBillPage page = ClientFactory.itemDetailList[MainMenuConstants.PaymentBill] as PaymentBillPage;
                        page.BindData(((List<PaymentBillHd>)MainForm.dataSourceList[typeof(List<PaymentBillHd>)]).FirstOrDefault(o => o.BillNo == bill.付款单号).ID);
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
                if (psc.IsBill || (MainForm.Company.Contains("镇阳") && mainMenu.Name==MainMenuConstants.FGStockOutBillQuery))
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
            if (e.Value != null && MainForm.dataSourceList.Count > 0)
            {
                List<TypesList> types = MainForm.dataSourceList[typeof(List<TypesList>)] as List<TypesList>;
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
                    e.DisplayText = EnumHelper.GetDescription<GoodsBigType>((GoodsBigType)e.Value, false);
                }
                else if (e.Column.FieldName == "班次" && mainMenu.Name != MainMenuConstants.AttWageBillQuery)
                {
                    e.DisplayText = EnumHelper.GetDescription<WorkShiftsType>((WorkShiftsType)e.Value, false);
                }
                else if (e.Column.FieldName == "机号")
                {
                    e.DisplayText = EnumHelper.GetDescription<MachineType>((MachineType)e.Value, false);
                }
                else if (e.Value is int && (e.Column.FieldName == "客户类型" || e.Column.FieldName == "仓库类型"))
                {
                    e.DisplayText = types.Find(o => o.Type == TypesListConstants.CustomerType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                }
                else if (e.Value is int && e.Column.FieldName == "供应商类型")
                {
                    e.DisplayText = types.Find(o => o.Type == TypesListConstants.SupplierType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                }
                else if (e.Value is int && e.Column.FieldName.Contains("特权"))
                {
                    e.DisplayText = types.Find(o => o.Type == TypesListConstants.PrivilegeType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                }
                else if (e.Value is int && e.Column.FieldName == "验证方式")
                {
                    e.DisplayText = types.Find(o => o.Type == TypesListConstants.VerifyMethodType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                }
                else if (e.Value is int && e.Column.FieldName == "结算方式")
                {
                    e.DisplayText = types.Find(o => o.Type == TypesListConstants.POClearType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                }
                else if (e.Value is int && e.Column.FieldName == "收款类型")
                {
                    e.DisplayText = types.Find(o => o.Type == TypesListConstants.ReceiptBillType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                }
                else if (e.Value is int && e.Column.FieldName == "付款类型")
                {
                    e.DisplayText = types.Find(o => o.Type == TypesListConstants.PaymentBillType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                }
                else if (e.Value is int && e.Column.FieldName == "类型")
                {
                    if (mainMenu.Name.Contains(MainMenuConstants.GetMaterialBill))
                        e.DisplayText = types.FirstOrDefault(o => o.Type == MainMenuConstants.StockOutBillType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                    else if (mainMenu.Name.Contains(MainMenuConstants.ReturnedMaterialBill))
                        e.DisplayText = types.FirstOrDefault(o => o.Type == MainMenuConstants.StockInBillType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                    else
                        e.DisplayText = types.Find(o => (mainMenu.Name.Contains(o.Type.Substring(0, 7)) || mainMenu.Name.Contains(o.SubType)) && o.No == Convert.ToInt32(e.Value)).Name.Trim();
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
                if (gridCellInfo.IsDataCell && gridCellInfo.CellValue != null && int.Parse(gridCellInfo.CellValue.ToString()) == (int)OrderType.Emergency)
                    e.Appearance.ForeColor = Color.Red;
            }

            if (MainForm.itemDetailPageList[mainMenu.Name].btnConnect != null)
            {
                if (MainForm.IsConnected)
                {
                    MainForm.itemDetailPageList[mainMenu.Name].btnConnect.Caption = "断开设备";
                    MainForm.itemDetailPageList[mainMenu.Name].btnConnect.Glyph = global::USL.Properties.Resources.switch_off_54px;
                }
                else
                {
                    MainForm.itemDetailPageList[mainMenu.Name].btnConnect.Caption = "连接设备";
                    MainForm.itemDetailPageList[mainMenu.Name].btnConnect.Glyph = global::USL.Properties.Resources.switch_on_54px;
                }
            }
        
        }

        private void gvLedgerDtlForPrint_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.Column.FieldName == "Type")
                {
                    if (mainMenu.Name == MainMenuConstants.ReceiptBillQuery)
                        e.DisplayText = types.Find(o => o.Type == TypesListConstants.ReceiptBillType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
                    else if (mainMenu.Name == MainMenuConstants.PaymentBillQuery)
                        e.DisplayText = types.Find(o => o.Type == TypesListConstants.PaymentBillType && o.No == Convert.ToInt32(e.Value)).Name.Trim();
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
                    currentObj = gridView.GetRow(gridView.FocusedRowHandle);
                    Goods goods = currentObj as Goods;
                    clientFactory.Modify<Goods>(goods);
                    clientFactory.DataPageRefresh(mainMenu.Name, string.Empty);
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
            if (mainMenu.Name == MainMenuConstants.ProductionOrderQuery)
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
            else if (mainMenu.Name == MainMenuConstants.SalesReturnBillQuery)
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
