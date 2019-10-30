using DevExpress.XtraEditors;
using System.Collections.Generic;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010.Views;
using System.Drawing;
using DBML;
using Factory;
using BLL;
using DevExpress.XtraBars;
using System;
using CommonLibrary;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using IBase;
using System.Collections;
using Utility;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraGrid.Columns;
using System.Linq;
using System.Configuration;
using DevExpress.XtraBars.Docking2010;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization;
using System.Data.OleDb;
using System.Data;
using System.Text.RegularExpressions;

namespace USL
{
    public partial class MainForm : XtraForm,IToolbar,IStatusbar
    {
        Thread threadGetVDataSource;
        Thread threadGetUserInfo;
        Thread threadInsertAlert;
        public static Dictionary<String, int> alertCount;
        public static UsersInfo usersInfo;
        ////public static List<Permission> userPermissions; //功能项权限
        public static List<ButtonPermission> buttonPermissions;//按钮权限
        //PageGroup pageGroupCore;
        //SampleDataSource dataSource;
        //Dictionary<SampleDataGroup, PageGroup> groupsItemDetailPage;
        static List<DBML.MainMenu> menuList;
        Dictionary<DBML.MainMenu, PageGroup> groupsItemDetailPage;
        public static Dictionary<Guid, PageGroup> groupsItemDetailList;
        public static Dictionary<String, IItemDetail> itemDetailList;
        Dictionary<String, int> itemDetailButtonList; //子菜单按钮项
        public static Dictionary<Type, object> dataSourceList;  //数据集
        static IList list;
        public static AlertControl alertControl;
        //public static int exportSalesReceiptDate = int.Parse(ConfigurationManager.AppSettings["ExportSalesReceiptDate"]);  //外销账期
        static int goodsBigType = 0;  //Goods大类
        static string goodsBigTypeName = string.Empty;
        static List<TypesList> types;   //类型列表
        //考勤组件
        private static zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();

        public static zkemkeeper.CZKEMClass AxCZKEM1
        {
            get { return axCZKEM1; }
            //set { axCZKEM1 = value; }
        }
        private static bool isConnected = false;//the boolean value identifies whether the device is connected

        public static bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
        }
        public static List<TypesList> Types
        {
            get { return MainForm.types; }
            //set { MainForm.types = value; }
        }

        public static string GoodsBigTypeName
        {
            get { return MainForm.goodsBigTypeName; }
            set { MainForm.goodsBigTypeName = value; }
        }

        public static int GoodsBigType
        {
            get { return MainForm.goodsBigType; }
            set { MainForm.goodsBigType = value; }
        }

        //[ServiceDependency]
        //public WorkItem RootWorkItem { get; set; }
        static string serverUrl = string.Empty;

        public static string ServerUrl
        {
            get { return MainForm.serverUrl; }
            set { MainForm.serverUrl = value; }
        }

        static string serverUserName = string.Empty;

        public static string ServerUserName
        {
            get { return MainForm.serverUserName; }
            set { MainForm.serverUserName = value; }
        }
        static string serverPassword = string.Empty;

        public static string ServerPassword
        {
            get { return MainForm.serverPassword; }
            set { MainForm.serverPassword = value; }
        }
        static string serverDomain = string.Empty;

        public static string ServerDomain
        {
            get { return MainForm.serverDomain; }
            set { MainForm.serverDomain = value; }
        }

        static string downloadPath = Application.StartupPath + "\\PicFile\\";

        public static string DownloadFilePath
        {
            get { return MainForm.downloadPath; }
            set { MainForm.downloadPath = value; }
        }

        static string company = string.Empty;

        public static string Company
        {
            get { return MainForm.company; }
            set { MainForm.company = value; }
        }

        static AttParameters attParam = null;

        public static AttParameters AttParam
        {
            get { return MainForm.attParam; }
            set { MainForm.attParam = value; }
        }

        static SystemInfo sysInfo = null;

        public static SystemInfo SysInfo
        {
            get { return MainForm.sysInfo; }
            set { MainForm.sysInfo = value; }
        }

        static bool isLandScape = true;

        public static bool IsLandScape
        {
            get { return MainForm.isLandScape; }
            set { MainForm.isLandScape = value; }
        }

        static System.Drawing.Printing.PaperKind printPaperKind = System.Drawing.Printing.PaperKind.A5Rotated;

        public static System.Drawing.Printing.PaperKind PrintPaperKind
        {
            get { return MainForm.printPaperKind; }
            set { MainForm.printPaperKind = value; }
        }

        static Size paperSize = new Size((int)(215 / 25.4 * 100), (int)(139 / 25.4 * 100));

        public static Size PaperSize
        {
            get { return MainForm.paperSize; }
            set { MainForm.paperSize = value; }
        }

        static string contacts = string.Empty;

        public static string Contacts
        {
            get { return MainForm.contacts; }
            set { MainForm.contacts = value; }
        }

        static string accounts = string.Empty;

        public static string Accounts
        {
            get { return MainForm.accounts; }
            set { MainForm.accounts = value; }
        }

        static ISnowSoftVersion iSnowSoftVersion = ISnowSoftVersion.ALL;

        public static ISnowSoftVersion ISnowSoftVersion
        {
            get { return MainForm.iSnowSoftVersion; }
            //set { MainForm.iSnowSoftVersion = value; }
        }

        bool authorised = true;  //判断系统是否已经授权使用

        public MainForm()
        {
            InitializeComponent();
            //iSnowSoftVersion = EnumHelper.GetEnumValues<ISnowSoftVersion>(true).FirstOrDefault(o => o.Name == ConfigurationManager.AppSettings["ISnowSoftVersion"].ToString()).Value;
            this.windowsUIView.Caption = ConfigurationManager.AppSettings["SystemName"];
            company = ConfigurationManager.AppSettings["Company"];
            contacts = ConfigurationManager.AppSettings["Contacts"];
            accounts = ConfigurationManager.AppSettings["Accounts"];
            this.tileContainer.Properties.IndentBetweenGroups = int.Parse(ConfigurationManager.AppSettings["IndentBetweenGroups"]);
            this.tileContainer.Properties.ItemSize = int.Parse(ConfigurationManager.AppSettings["ItemSize"]);
            this.tileContainer.Properties.LargeItemWidth = int.Parse(ConfigurationManager.AppSettings["LargeItemWidth"]);
            this.tileContainer.Properties.RowCount = int.Parse(ConfigurationManager.AppSettings["RowCount"]);
            serverUrl = ConfigurationManager.AppSettings["ServerUrl"];
            serverUserName = ConfigurationManager.AppSettings["ServerUserName"];
            serverPassword = Security.Decrypt(ConfigurationManager.AppSettings["ServerPassword"].ToString());
            serverDomain = ConfigurationManager.AppSettings["ServerDomain"];
            //if (MainForm.Company.Contains("镇阳"))
            //{
            //    isLandScape = false;
            //    printPaperKind = System.Drawing.Printing.PaperKind.A5Rotated;
            //}
            if (MainForm.Company.Contains("创萌"))
            {
                isLandScape = false;
                printPaperKind = System.Drawing.Printing.PaperKind.Custom;
                PaperSize = new Size((int)(218 / 25.4 * 100), (int)(140 / 25.4 * 100));
            }
            else if (MainForm.Company.Contains("谷铭达") || MainForm.Company.Contains("镇阳") || MainForm.Company.Contains("盛兴"))
            {
                isLandScape = false;
                printPaperKind = System.Drawing.Printing.PaperKind.Custom;
                PaperSize= new Size((int)(215 / 25.4 * 100), (int)(139 / 25.4 * 100));
            }
            else
            {
                isLandScape = false;
                printPaperKind = System.Drawing.Printing.PaperKind.A5Rotated;
            }

            this.tools.Visible = false;
            windowsUIView.AddTileWhenCreatingDocument = DevExpress.Utils.DefaultBoolean.False;
            //dataSource = new SampleDataSource();
            //userPermissions.Find(o => o.Caption.Trim() == item.Caption.Trim()).CheckBoxState;
            menuList = BLLFty.Create<MainMenuBLL>().GetMainMenu();
            List<Permission> pList = BLLFty.Create<PermissionBLL>().GetPermission().FindAll(o => o.UserID == usersInfo.ID);

            #region 如果MainMenu有变更，更新用户权限列表

            //更新功能权限信息
            int iCount = 0;
            foreach (DBML.MainMenu menu in menuList)
            {
                Permission p = pList.FirstOrDefault(o => o.UserID == usersInfo.ID && o.Caption == menu.Caption);
                if (p == null)
                {
                    p = new Permission();
                    p.ID = ++iCount;
                    if (menu.ParentID == null)
                        p.ParentID = 0;
                    else if (menu.SerialNo.ToString().Length > 2)
                        p.ParentID = int.Parse(menu.SerialNo.ToString().Substring(0, menu.SerialNo.ToString().Length - 2));
                    p.SerialNo = menu.SerialNo;
                    p.UserID = usersInfo.ID;
                    p.Caption = menu.Caption;
                    p.CheckBoxState = false;
                    BLLFty.Create<PermissionBLL>().Insert(p);
                }
                else
                {
                    p.ID = ++iCount;
                    if (menu.ParentID == null)
                        p.ParentID = 0;
                    else if (menu.SerialNo.ToString().Length > 2)
                        p.ParentID = int.Parse(menu.SerialNo.ToString().Substring(0, menu.SerialNo.ToString().Length - 2));
                    //else
                    //    p.ParentID = int.Parse(menu.SerialNo.ToString().Substring(0, 1));
                    p.SerialNo = menu.SerialNo;
                    //p.UserID = usersInfo.ID;
                    //p.Caption = menu.Caption;
                    BLLFty.Create<PermissionBLL>().Update(p);
                }
            }

            #endregion

            pList = BLLFty.Create<PermissionBLL>().GetPermission().FindAll(o => o.UserID == usersInfo.ID);
            //设置权限
            for (int i = menuList.Count - 1; i >= 0; i--)
            {
                if (menuList[i].ParentID == null)
                    continue;
                if (pList.FirstOrDefault(o => o.Caption.Trim() == menuList[i].Caption.Trim()).CheckBoxState == false)
                {
                    menuList.RemoveAt(i);
                    continue;
                }
            }
            alertCount = new Dictionary<string, int>();
            //groupsItemDetailPage = new Dictionary<SampleDataGroup, PageGroup>();
            groupsItemDetailPage = new Dictionary<DBML.MainMenu, PageGroup>();
            groupsItemDetailList = new Dictionary<Guid, PageGroup>();
            itemDetailList = new Dictionary<String, IItemDetail>();  //ItemDetailPage页面所有加载的Control
            itemDetailButtonList = new Dictionary<string, int>();
            dataSourceList = new Dictionary<Type, object>();
            alertControl = new AlertControl(this.components);
            alertControl.FormShowingEffect = AlertFormShowingEffect.SlideHorizontal;
            
            SetStateBarInfo();
            GetDataSource();
            GetVDataSource();
            types = MainForm.dataSourceList[typeof(List<TypesList>)] as List<TypesList>;
            warehouseList = MainForm.dataSourceList[typeof(List<Warehouse>)] as List<Warehouse>;
            ////userPermissions = ((List<Permission>)MainForm.dataSourceList[typeof(List<Permission>)]).FindAll(o => o.UserID == usersInfo.ID);
            buttonPermissions = ((List<ButtonPermission>)MainForm.dataSourceList[typeof(List<ButtonPermission>)]).FindAll(o => o.UserID == usersInfo.ID);
            attParam = ((List<AttParameters>)MainForm.dataSourceList[typeof(List<AttParameters>)]).FirstOrDefault(o => o.CommMode == "TCP/IP");
            sysInfo = ((List<SystemInfo>)MainForm.dataSourceList[typeof(List<SystemInfo>)]).FirstOrDefault(o => o.Company.Contains(MainForm.Company));
            CreateLayout();
   
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetErrorPanelInfo();
            //SetStateBarInfo();
            InnerHideDockPanel();
            //警告提醒
            ////List<Alert> alertList = BLLFty.Create<AlertBLL>().GetAlert();//((List<Alert>)MainForm.dataSourceList[typeof(List<Alert>)]);
            ////foreach (Alert item in alertList)
            ////{
            ////    alertControl.Show(this, item.Caption, item.Text, global::USL.Properties.Resources.Alarm_Clock);
            ////}
            SetAlertCount();
            barUserInfo.ItemClick += barUserInfo_ItemClick;
            //AlertControl ac = new AlertControl();
            //ac.AppearanceCaption.Font = new Font("宋体", 15);
            //ac.AppearanceText.Font = new Font("宋体", 15);
            ////ac.AutoHeight = true;
            //ac.Show(this, "购买咨询：", "\r\n15220288727 李先生", global::USL.Properties.Resources.phone_32);

            //判断电脑系统时间是否和互联网标准北京时间一致（或者时间等于2015-01-01，即不能上网，获取不了系统时间）
            //if (Program.SysDateTime.ToString("yyyy-MM-dd") != Security.DataStandardTime().ToString("yyyy-MM-dd") || Security.Encrypt(Security.DataStandardTime().ToString("yyyy-MM-dd")).Equals("7877984B2FAE09F6A4B7C75AC9DD29BC"))
            //{
            //    authorised = false;
            //    XtraMessageBox.Show("系统未授权使用，请联系系统开发人员。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Close();
            //}
        }

        /// <summary>
        /// 提醒记录数量
        /// </summary>
        public static void SetAlertCount()
        {
            List<Alert> alertList = BLLFty.Create<AlertBLL>().GetAlert();//((List<Alert>)MainForm.dataSourceList[typeof(List<Alert>)]);
            alertCount.Clear();
            foreach (Alert item in alertList)
            {
                if (alertCount.ContainsKey(item.Caption) == false)
                {
                    alertCount.Add(item.Caption, 1);
                }
                else
                    alertCount[item.Caption] = ++alertCount[item.Caption];
            }
            lblAlert.Caption = "提醒信息：";
            foreach (KeyValuePair<String, int> kvp in alertCount)
            {
                lblAlert.Caption += string.Format("{0}条{1}；", kvp.Value, kvp.Key);
            }
        }

        void barUserInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }

        void InsertAlert()
        {
            // 删除所有单据提醒记录
            BLLFty.Create<AlertBLL>().DeleteBill();
            //单据交货日期提醒
            List<Alert> dellist = new List<Alert>();
            List<Alert> insertlist = new List<Alert>();
            //订货单
            List<OrderHd> orderList = BLLFty.Create<OrderBLL>().GetOrderHd();
            foreach (OrderHd order in orderList)
            {
                //Alert alert = BLLFty.Create<AlertBLL>().GetAlert().Find(o => o.BillID == order.ID);
                //if (alert != null)
                //    dellist.Add(alert);
                Company customer = BLLFty.Create<CompanyBLL>().GetCompany().FirstOrDefault(o => o.ID == order.CompanyID);
                if (order.Status == 0 && order.DeliveryDate <= DateTime.Now.AddDays(3))
                {
                    Alert obj = new Alert();
                    obj.ID = Guid.NewGuid();
                    obj.BillID = order.ID;
                    obj.Caption = "交货提醒";
                    obj.Text = string.Format("客户:[{0}],唛头:[{1}]的订货单[{2}]交货日期是:[{3}].请尽快发货。\r\n备注:{4}", customer == null ? string.Empty : customer.Name, order.MainMark, order.BillNo, order.DeliveryDate.ToString("yyyy-MM-dd"), order.Remark);
                    obj.AddTime = DateTime.Now;
                    insertlist.Add(obj);
                }
            }

            //出库单
            List<StockOutBillHd> billList = BLLFty.Create<StockOutBillBLL>().GetStockOutBillHd();
            foreach (StockOutBillHd bill in billList)
            {
                //Alert alert = BLLFty.Create<AlertBLL>().GetAlert().Find(o => o.BillID == bill.ID);
                //if (alert != null)
                //    dellist.Add(alert);
                Company customer = BLLFty.Create<CompanyBLL>().GetCompany().FirstOrDefault(o => o.ID == bill.CompanyID);
                List<TypesList> types = BLLFty.Create<TypesListBLL>().GetTypesList();// MainForm.dataSourceList[typeof(List<TypesList>)] as List<TypesList>;
                string billName = types.Find(o => o.Type == TypesListConstants.StockOutBillType && o.No == bill.Type).Name;
                if (bill.Status == 0 && bill.DeliveryDate <= DateTime.Now.AddDays(3))
                {
                    Alert obj = new Alert();
                    obj.ID = Guid.NewGuid();
                    obj.BillID = bill.ID;
                    obj.Caption = "交货提醒";
                    obj.Text = string.Format("客户:[{0}],唛头:[{1}]的{2}单[{3}]交货日期是:[{4}].请尽快发货。\r\n备注:{5}", customer == null ? string.Empty : customer.Name, bill.MainMark, billName, bill.BillNo, bill.DeliveryDate.ToString("yyyy-MM-dd"), bill.Remark);
                    obj.AddTime = DateTime.Now;
                    insertlist.Add(obj);
                }
                if (bill.CompanyID != null)  
                {
                    Company company = BLLFty.Create<CompanyBLL>().GetCompany().Find(o => o.ID == bill.CompanyID && o.Type == 1);//外销客户
                    if (bill.Status == 1 && company != null && company.AccountPeriod.HasValue && company.AccountPeriod.Value > 0 && bill.BillDate.AddDays(company.AccountPeriod.Value) <= DateTime.Now)  //外销账期，如交货后45天收款
                    {
                        Alert obj = new Alert();
                        obj.ID = Guid.NewGuid();
                        obj.BillID = bill.ID;
                        obj.Caption = "收款提醒";
                        obj.Text = string.Format("客户:[{0}],唛头:[{1}]的{2}单[{3}]的账期{4}天已到.可以收款了。\r\n备注:{5}", company.Name, bill.MainMark, billName, bill.BillNo, company.AccountPeriod.Value, bill.Remark);
                        obj.AddTime = DateTime.Now;
                        insertlist.Add(obj);
                    }
                }
            }
            if (dellist.Count > 0 || insertlist.Count > 0)
                BLLFty.Create<AlertBLL>().Insert(dellist, insertlist);
        }

        public static void SetSelected(PageGroup pageGroupCore, DBML.MainMenu mainMenu)
        {
            BaseContentContainer documentContainer = pageGroupCore.Parent as BaseContentContainer;
            if (documentContainer != null)
            {
                //进入一级菜单
                WindowsUIView view = documentContainer.Manager.View as WindowsUIView;
                if (view != null)
                {
                    pageGroupCore = MainForm.groupsItemDetailList[mainMenu.ParentID.Value];
                    view.ActivateContainer(MainForm.groupsItemDetailList[mainMenu.ParentID.Value]);
                }
                //进入二级菜单
                int i = 0, index = 0;
                foreach (DBML.MainMenu mm in menuList.FindAll(o => o.ParentID == mainMenu.ParentID))
                {
                    if (MainForm.hasItemDetailPage[mm.Name] == null)
                    {
                        MainForm.itemDetailPageList[mm.Name].LoadBusinessData(MainForm.mainMenuList[mm.Name]);
                        MainForm.hasItemDetailPage.Add(mm.Name, true);
                    }
                    if (mm.Name == mainMenu.Name)
                        index = i;
                    ++i;
                }
                pageGroupCore.SetSelected(pageGroupCore.Items[index]);
                view.ActivateContainer(pageGroupCore);
            }
        }

        public static DataSet ImportExcelOleDb(string connStr)
        {
            //把EXCEL导入到DataSet
            DataSet ds = new DataSet();
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                ArrayList al = new ArrayList();
                conn.Open();
                DataTable sheetNames = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                foreach (DataRow item in sheetNames.Rows)
                {
                    al.Add(item[2]);  //itme[2]是获取Excel表单薄名称
                }
                int n = al.Count;
                string[] SheetSet = new string[n];
                for (int i = 0; i < n; i++)
                {
                    SheetSet[i] = (string)al[i];
                }
                OleDbDataAdapter da;
                for (int i = 0; i < n; i++)
                {
                    string sql = "select * from [" + SheetSet[i] + "] ";
                    da = new OleDbDataAdapter(sql, conn);
                    da.Fill(ds, SheetSet[i]);
                    da.Dispose();
                }
                conn.Close();
                conn.Dispose();
            }
            return ds;
        }
        public static string GetBillMaxBillNo(String billType, String prefix)
        {
            string no = string.Empty;
            switch (billType)
            {
                case MainMenuConstants.Order:
                    no = BLLFty.Create<OrderBLL>().GetMaxBillNo();
                    break;
                case MainMenuConstants.StockInBillType:
                    no = BLLFty.Create<StockInBillBLL>().GetMaxBillNo();
                    break;
                case MainMenuConstants.StockOutBillType:
                    no = BLLFty.Create<StockOutBillBLL>().GetMaxBillNo();
                    break;
                case MainMenuConstants.ReceiptBill:
                    no = BLLFty.Create<ReceiptBillBLL>().GetMaxBillNo();
                    break;
                case MainMenuConstants.PaymentBill:
                    no = BLLFty.Create<PaymentBillBLL>().GetMaxBillNo();
                    break;
                case MainMenuConstants.WageBill:
                    no = BLLFty.Create<WageBillBLL>().GetMaxBillNo();
                    break;
                default:
                    break;
            }
            if (string.IsNullOrEmpty(no))
                no = prefix + DateTime.Now.ToString("yyyyMMdd") + "001";
            else
            {
                if (no.Substring(2, 8).Equals(DateTime.Now.ToString("yyyyMMdd")))
                    no = prefix + DateTime.Now.ToString("yyyyMMdd") + Convert.ToString(int.Parse(no.Substring(10, 3)) + 1).PadLeft(3, '0');
                else
                    no = prefix + DateTime.Now.ToString("yyyyMMdd") + "001";
            }
            return no;
        }

        /// <summary>
        /// 获得外箱规格对应的体积
        /// </summary>
        /// <param name="meas"></param>
        /// <returns></returns>
        public static decimal GetVolume(string meas)
        {
            decimal iVolume = 1;
            string sVolume = Regex.Replace(meas, "[X-×-&]", "*");
            foreach (string item in sVolume.Split('*'))
            {
                if (Rexlib.IsValidDecimal2(item))
                    iVolume *= decimal.Parse(item);
            }
            return iVolume;
        }

        static VStaffSchClass GetStaffSchClass(AttGeneralLog log, Guid? deptID)
        {
            //AttFlag:True表示签到，False表示签退
            VStaffSchClass result = null;
            List<VStaffSchClass> schList = ((List<VStaffSchClass>)dataSourceList[typeof(List<VStaffSchClass>)]).FindAll(o => o.DeptID == deptID);
            VStaffSchClass schIn = schList.FirstOrDefault(o =>
                o.CheckInStartTime.Value.TimeOfDay <= log.AttTime.TimeOfDay && o.CheckInEndTime.Value.TimeOfDay >= log.AttTime.TimeOfDay);
            if (schIn == null)
            {
                VStaffSchClass schOut = schList.FirstOrDefault(o =>
                    o.CheckOutStartTime.Value.TimeOfDay <= log.AttTime.TimeOfDay && o.CheckOutEndTime.Value.TimeOfDay >= log.AttTime.TimeOfDay);
                if (schOut != null)
                {
                    log.AttFlag = false;
                    result = schOut;
                }
            }
            else
            {
                log.AttFlag = true;
                result = schIn;
            }
            return result;
        }

        public static void GetAttAppointments()
        {
            //添加考勤报表
            List<AttGeneralLog> attGLogs = dataSourceList[typeof(List<AttGeneralLog>)] as List<AttGeneralLog>;
            Hashtable hasAtt = new Hashtable();
            List<AttAppointments> aptList = BLLFty.Create<AttAppointmentsBLL>().GetAttAppointments();
            List<AttAppointments> aptInsertList = new List<AttAppointments>();
            List<AttAppointments> aptUpdateList = new List<AttAppointments>();
            //List<VAttAppointments> vaptList = new List<VAttAppointments>();
            AttAppointments apt = null;
            VStaffSchClass vssc = null;
            foreach (AttGeneralLog log in attGLogs)
            {
                UsersInfo user = ((List<UsersInfo>)dataSourceList[typeof(List<UsersInfo>)]).FirstOrDefault(o => o.Code == log.EnrollNumber && o.IsDel == false);
                if (user == null)
                    continue;
                if (log.SchClassID == null || log.SchClassID == Guid.Empty)
                {
                    vssc = GetStaffSchClass(log, user.DeptID);
                    if (vssc == null)
                        continue;  //排除那些无意义的打卡记录
                }
                else
                    vssc = ((List<VStaffSchClass>)dataSourceList[typeof(List<VStaffSchClass>)]).FirstOrDefault(o =>
                        o.SchClassID == log.SchClassID && o.DeptID == user.DeptID);
                if (user != null && vssc != null)
                {
                    if (hasAtt[log.EnrollNumber + log.AttTime.ToString("yyyyMMdd") + vssc.Name] == null)
                    //AttAppointments apt = aptList.FirstOrDefault(o => o.UserID == user.ID
                    //    && (o.CheckInTime.Value.ToString("yyyyMM") == log.AttTime.ToString("yyyyMM") || o.CheckOutTime.Value.ToString("yyyyMM") == log.AttTime.ToString("yyyyMM"))
                    //    && o.SchClassName == vssc.Name);
                    //if (apt == null)
                    {
                        apt = new AttAppointments();
                        apt.UserID = user.ID;
                        apt.SchClassID = vssc.SchClassID;
                        apt.SchClassName = vssc.Name;
                        apt.SchSerialNo = vssc.SchSerialNo;
                        apt.SchStartTime = vssc.StartTime;
                        apt.SchEndTime = vssc.EndTime;
                        if (log.AttFlag)
                        {
                            apt.CheckInTime = log.AttTime;
                            apt.GLogStartID = log.ID;
                            int late = (int)(log.AttTime.TimeOfDay - vssc.StartTime.Value.TimeOfDay).TotalMinutes;
                            if (late > vssc.LateMinutes)
                                apt.LateMinutes = late;
                        }
                        else if (log.AttFlag == false)
                        {
                            apt.CheckOutTime = log.AttTime;
                            apt.GLogEndID = log.ID;
                            int early = (int)(vssc.EndTime.Value.TimeOfDay - log.AttTime.TimeOfDay).TotalMinutes;
                            if (early > vssc.EarlyMinutes)
                                apt.EarlyMinutes = early;
                        }
                        apt.AttStatus = log.AttStatus;
                        apt.Description = log.Description;
                        //apt = SetAttStatus(apt);
                        //aptInsertList.Add(apt);
                        hasAtt.Add(log.EnrollNumber + log.AttTime.ToString("yyyyMMdd") + vssc.Name, apt);
                    }
                    else
                    {
                        apt = hasAtt[log.EnrollNumber + log.AttTime.ToString("yyyyMMdd") + vssc.Name] as AttAppointments;
                        apt.UserID = user.ID;
                        apt.SchClassID = vssc.SchClassID;
                        apt.SchClassName = vssc.Name;
                        apt.SchSerialNo = vssc.SchSerialNo;
                        apt.SchStartTime = vssc.StartTime;
                        apt.SchEndTime = vssc.EndTime;
                        if (log.AttFlag)
                        {
                            apt.CheckInTime = log.AttTime;
                            apt.GLogStartID = log.ID;
                            int late = (int)(log.AttTime.TimeOfDay - vssc.StartTime.Value.TimeOfDay).TotalMinutes;
                            if (late > vssc.LateMinutes)
                                apt.LateMinutes = late;
                        }
                        else if (log.AttFlag == false)
                        {
                            apt.CheckOutTime = log.AttTime;
                            apt.GLogEndID = log.ID;
                            int early = (int)(vssc.EndTime.Value.TimeOfDay - log.AttTime.TimeOfDay).TotalMinutes;
                            if (early > vssc.EarlyMinutes)
                                apt.EarlyMinutes = early;
                        }
                        apt.AttStatus = log.AttStatus;
                        apt.Description = log.Description;
                        //apt = SetAttStatus(apt);
                        //aptUpdateList.Add(apt);
                        hasAtt[log.EnrollNumber + log.AttTime.ToString("yyyyMMdd") + vssc.Name] = apt;
                    }
                }
            }

            foreach (DictionaryEntry de in hasAtt)
            {
                AttAppointments obj = de.Value as AttAppointments;               
                if (obj.AttStatus < (int)AttStatusType.Absent)  //判断考勤状态
                {
                    if (obj.LateMinutes != null && obj.LateMinutes > 0)
                        obj.AttStatus = (int)AttStatusType.Late;
                    if (obj.EarlyMinutes != null && obj.EarlyMinutes > 0)
                        obj.AttStatus = (int)AttStatusType.Early;
                    if (obj.LateMinutes != null && obj.LateMinutes > 0 && obj.EarlyMinutes != null && obj.EarlyMinutes > 0)
                        obj.AttStatus = (int)AttStatusType.LateEarly;
                    if (obj.CheckInTime == null)
                    {
                        obj.AttStatus = (int)AttStatusType.NoCheckIn;
                        obj.CheckInTime = obj.CheckOutTime.Value.Date;
                    }
                    if (obj.CheckOutTime == null)
                    {
                        obj.AttStatus = (int)AttStatusType.NoCheckOut;
                        obj.CheckOutTime = obj.CheckInTime.Value.Date;
                    }
                    if (obj.CheckInTime == null && obj.CheckOutTime == null)
                        obj.AttStatus = (int)AttStatusType.Absent;
                }
                else
                {
                    if (obj.CheckInTime == null)
                        obj.CheckInTime = obj.CheckOutTime.Value.Date;
                    if (obj.CheckOutTime == null)
                        obj.CheckOutTime = obj.CheckInTime.Value.Date;
                    if (obj.LateMinutes != null && obj.LateMinutes >= 0)
                        obj.LateMinutes = null;
                    if (obj.EarlyMinutes != null && obj.EarlyMinutes >= 0)
                        obj.EarlyMinutes = null;
                }
                if (obj.LateMinutes.GetValueOrDefault() > 0 || obj.EarlyMinutes.GetValueOrDefault() > 0)
                    obj.Location = string.Format("{0} {1}", obj.LateMinutes, obj.EarlyMinutes);
                obj.Subject = EnumHelper.GetDescription<AttStatusType>((AttStatusType)obj.AttStatus, false);

                AttAppointments attApt = aptList.FirstOrDefault(o => o.UserID == obj.UserID
                    && o.CheckInTime.Value.ToString("yyyyMMdd") == obj.CheckInTime.Value.ToString("yyyyMMdd")
                    && o.SchClassName == obj.SchClassName);
                if (attApt == null)
                    aptInsertList.Add(obj);
                else
                {
                    attApt.SchClassID = obj.SchClassID;
                    attApt.SchClassName = obj.SchClassName;
                    attApt.SchSerialNo = obj.SchSerialNo;
                    attApt.SchStartTime = obj.SchStartTime;
                    attApt.SchEndTime = obj.SchEndTime;
                    attApt.CheckInTime = obj.CheckInTime;
                    attApt.CheckOutTime = obj.CheckOutTime;
                    attApt.LateMinutes = obj.LateMinutes;
                    attApt.EarlyMinutes = obj.EarlyMinutes;
                    attApt.AttStatus = obj.AttStatus;
                    attApt.Subject = obj.Subject;
                    attApt.Location = obj.Location;
                    attApt.Description = obj.Description;
                    aptUpdateList.Add(attApt);
                }

                //UsersInfo u = ((List<UsersInfo>)dataSourceList[typeof(List<UsersInfo>)]).FirstOrDefault(o => o.ID == obj.UserID);
                //VAttAppointments vObj = new VAttAppointments();
                //vObj.UniqueID = obj.UniqueID;
                //vObj.GLogStartID = obj.GLogStartID;
                //vObj.GLogEndID = obj.GLogEndID;
                //vObj.UserID = obj.UserID;
                //vObj.工号 = u.Code;
                //vObj.姓名 = u.Name;
                //vObj.SchSerialNo = obj.SchSerialNo;
                //vObj.日期 = obj.CheckInTime;
                //vObj.上班时间 = obj.SchStartTime;
                //vObj.下班时间 = obj.SchEndTime;
                //vObj.签到时间 = obj.CheckInTime;
                //vObj.签退时间 = obj.CheckOutTime;
                //vObj.考勤状态 = obj.AttStatus;
                //vObj.迟到分钟数 = obj.LateMinutes;
                //vObj.早退分钟数 = obj.EarlyMinutes;
                //vObj.备注 = obj.Description;
                //vaptList.Add(vObj);
            }
            //dataSourceList[typeof(List<AttAppointments>)] = aptList;
            //dataSourceList[typeof(List<VAttAppointments>)] = vaptList;

            //BLLFty.Create<AttAppointmentsBLL>().Insert(aptList);
            BLLFty.Create<AttAppointmentsBLL>().Save(aptInsertList, aptUpdateList);
        }

        //static AttAppointments SetAttStatus(AttAppointments obj)
        //{
        //    //foreach (AttAppointments obj in apts)
        //    //{
        //        if (obj.AttStatus < (int)AttStatusType.Absent)  //判断考勤状态
        //        {
        //            if (obj.LateMinutes != null && obj.LateMinutes > 0)
        //                obj.AttStatus = (int)AttStatusType.Late;
        //            if (obj.EarlyMinutes != null && obj.EarlyMinutes > 0)
        //                obj.AttStatus = (int)AttStatusType.Early;
        //            if (obj.LateMinutes != null && obj.LateMinutes > 0 && obj.EarlyMinutes != null && obj.EarlyMinutes > 0)
        //                obj.AttStatus = (int)AttStatusType.LateEarly;
        //            if (obj.CheckInTime == null)
        //            {
        //                obj.AttStatus = (int)AttStatusType.NoCheckIn;
        //                obj.CheckInTime = obj.CheckOutTime.Value.Date;
        //            }
        //            if (obj.CheckOutTime == null)
        //            {
        //                obj.AttStatus = (int)AttStatusType.NoCheckOut;
        //                obj.CheckOutTime = obj.CheckInTime.Value.Date;
        //            }
        //            if (obj.CheckInTime == null && obj.CheckOutTime == null)
        //                obj.AttStatus = (int)AttStatusType.Absent;
        //        }
        //        else
        //        {
        //            if (obj.CheckInTime == null)
        //                obj.CheckInTime = obj.CheckOutTime.Value.Date;
        //            if (obj.CheckOutTime == null)
        //                obj.CheckOutTime = obj.CheckInTime.Value.Date;
        //            if (obj.LateMinutes != null && obj.LateMinutes >= 0)
        //                obj.LateMinutes = null;
        //            if (obj.EarlyMinutes != null && obj.EarlyMinutes >= 0)
        //                obj.EarlyMinutes = null;
        //        }
        //        if (obj.LateMinutes.GetValueOrDefault() > 0 || obj.EarlyMinutes.GetValueOrDefault() > 0)
        //            obj.Location = string.Format("{0} {1}", obj.LateMinutes, obj.EarlyMinutes);
        //        obj.Subject = EnumHelper.GetDescription<AttStatusType>((AttStatusType)obj.AttStatus, false);
        //        //aptList.Add(obj);
        //        return obj;
        //        //UsersInfo u = ((List<UsersInfo>)dataSourceList[typeof(List<UsersInfo>)]).FirstOrDefault(o => o.ID == obj.UserID);
        //        //VAttAppointments vObj = new VAttAppointments();
        //        //vObj.UniqueID = obj.UniqueID;
        //        //vObj.GLogStartID = obj.GLogStartID;
        //        //vObj.GLogEndID = obj.GLogEndID;
        //        //vObj.UserID = obj.UserID;
        //        //vObj.工号 = u.Code;
        //        //vObj.姓名 = u.Name;
        //        //vObj.SchSerialNo = obj.SchSerialNo;
        //        //vObj.日期 = obj.CheckInTime;
        //        //vObj.上班时间 = obj.SchStartTime;
        //        //vObj.下班时间 = obj.SchEndTime;
        //        //vObj.签到时间 = obj.CheckInTime;
        //        //vObj.签退时间 = obj.CheckOutTime;
        //        //vObj.考勤状态 = obj.AttStatus;
        //        //vObj.迟到分钟数 = obj.LateMinutes;
        //        //vObj.早退分钟数 = obj.EarlyMinutes;
        //        //vObj.备注 = obj.Description;
        //        //vaptList.Add(vObj);
        //    //}
        //    //dataSourceList[typeof(List<AttAppointments>)] = aptList;
        //    //dataSourceList[typeof(List<VAttAppointments>)] = vaptList;
        //}
        private void GetViewDataSource()
        {
            //dataSourceList.Clear();
            //dataSourceList = null;
            Dictionary<Type, object> dataSources = BLLFty.Create<DataSourcesBLL>().GetVDataSources();
            foreach (KeyValuePair<Type, object> kvp in dataSources)
            {
                //dataSourceList.Add(kvp.Key, kvp.Value);
                dataSourceList[kvp.Key] = kvp.Value;
            }
        }

        static void GetNewList()
        {
            dataSourceList.Add(typeof(List<VStockInBill>), new List<VStockInBill>());
            dataSourceList.Add(typeof(List<VStockOutBill>), new List<VStockOutBill>());
            dataSourceList.Add(typeof(List<VMaterialStockInBill>), new List<VMaterialStockInBill>());
            dataSourceList.Add(typeof(List<VMaterialStockOutBill>), new List<VMaterialStockOutBill>());
            dataSourceList.Add(typeof(List<StockInBillHd>), new List<StockInBillHd>());
            dataSourceList.Add(typeof(List<StockOutBillHd>), new List<StockOutBillHd>());
            dataSourceList.Add(typeof(List<OrderHd>), new List<OrderHd>());
            dataSourceList.Add(typeof(List<ReceiptBillHd>), new List<ReceiptBillHd>());
            dataSourceList.Add(typeof(List<PaymentBillHd>), new List<PaymentBillHd>());
            dataSourceList.Add(typeof(List<VPO>), new List<VPO>());
            dataSourceList.Add(typeof(List<VOrder>), new List<VOrder>());
            dataSourceList.Add(typeof(List<VFSMOrder>), new List<VFSMOrder>());
            dataSourceList.Add(typeof(List<VProductionOrder>), new List<VProductionOrder>());
            dataSourceList.Add(typeof(List<VInventory>), new List<VInventory>());
            dataSourceList.Add(typeof(List<VInventoryGroupByGoods>), new List<VInventoryGroupByGoods>());
            dataSourceList.Add(typeof(List<VMaterialInventory>), new List<VMaterialInventory>());
            dataSourceList.Add(typeof(List<VMaterialInventoryGroupByGoods>), new List<VMaterialInventoryGroupByGoods>());
            dataSourceList.Add(typeof(List<VEMSInventoryGroupByGoods>), new List<VEMSInventoryGroupByGoods>());
            dataSourceList.Add(typeof(List<VFSMInventoryGroupByGoods>), new List<VFSMInventoryGroupByGoods>());
            dataSourceList.Add(typeof(List<VAccountBook>), new List<VAccountBook>());
            dataSourceList.Add(typeof(List<VStocktaking>), new List<VStocktaking>());
            dataSourceList.Add(typeof(List<VProfitAndLoss>), new List<VProfitAndLoss>());
            dataSourceList.Add(typeof(List<SalesSummaryMonthlyReport>), new List<SalesSummaryMonthlyReport>());
            dataSourceList.Add(typeof(List<AnnualSalesSummaryByCustomerReport>), new List<AnnualSalesSummaryByCustomerReport>());
            dataSourceList.Add(typeof(List<AnnualSalesSummaryByGoodsReport>), new List<AnnualSalesSummaryByGoodsReport>());
            dataSourceList.Add(typeof(List<VSalesBillSummary>), new List<VSalesBillSummary>());
            dataSourceList.Add(typeof(List<VProductionOrderDtlForPrint>), new List<VProductionOrderDtlForPrint>());
            dataSourceList.Add(typeof(List<VAlert>), new List<VAlert>());
            dataSourceList.Add(typeof(List<Alert>), new List<Alert>());
            dataSourceList.Add(typeof(List<VReceiptBillDtl>), new List<VReceiptBillDtl>());
            dataSourceList.Add(typeof(List<VReceiptBill>), new List<VReceiptBill>());
            dataSourceList.Add(typeof(List<VPaymentBillDtl>), new List<VPaymentBillDtl>());
            dataSourceList.Add(typeof(List<VPaymentBill>), new List<VPaymentBill>());
            dataSourceList.Add(typeof(List<StatementOfAccountToBulkSalesReport>), new List<StatementOfAccountToBulkSalesReport>());
            dataSourceList.Add(typeof(List<StatementOfAccountToCustomerReport>), new List<StatementOfAccountToCustomerReport>());//.OrderBy(o => o.结算类型).OrderBy(o => o.出库日期).ToList());
            dataSourceList.Add(typeof(List<StatementOfAccountToSupplierReport>), new List<StatementOfAccountToSupplierReport>());//.OrderBy(o => o.结算类型).OrderBy(o => o.结算日期).ToList());
            dataSourceList.Add(typeof(List<VCustomerSettlement>), new List<VCustomerSettlement>());
            dataSourceList.Add(typeof(List<VSupplierSettlement>), new List<VSupplierSettlement>());
            dataSourceList.Add(typeof(List<VSampleStockOut>), new List<VSampleStockOut>());
            dataSourceList.Add(typeof(List<Resources>), new List<Resources>());
            dataSourceList.Add(typeof(List<Appointments>), new List<Appointments>());
            dataSourceList.Add(typeof(List<VAppointments>), new List<VAppointments>());
            dataSourceList.Add(typeof(List<WageDesign>), new List<WageDesign>());
            dataSourceList.Add(typeof(List<WageBillHd>), new List<WageBillHd>());
            dataSourceList.Add(typeof(List<WageBillDtl>), new List<WageBillDtl>());
            dataSourceList.Add(typeof(List<VWageBillDtl>), new List<VWageBillDtl>());
            dataSourceList.Add(typeof(List<VWageBill>), new List<VWageBill>());
            dataSourceList.Add(typeof(List<SalesSummaryByCustomerReport>), new List<SalesSummaryByCustomerReport>());
            dataSourceList.Add(typeof(List<SalesSummaryByGoodsReport>), new List<SalesSummaryByGoodsReport>());
            dataSourceList.Add(typeof(List<SalesSummaryByGoodsPriceReport>), new List<SalesSummaryByGoodsPriceReport>());
            dataSourceList.Add(typeof(List<GoodsSalesSummaryByCustomerReport>), new List<GoodsSalesSummaryByCustomerReport>());
            dataSourceList.Add(typeof(List<AttGeneralLog>), new List<AttGeneralLog>());
            dataSourceList.Add(typeof(List<VAttGeneralLog>), new List<VAttGeneralLog>());
            dataSourceList.Add(typeof(List<AttAppointments>), new List<AttAppointments>());
            dataSourceList.Add(typeof(List<VAttAppointments>), new List<VAttAppointments>());
            dataSourceList.Add(typeof(List<AttWageBillHd>), new List<AttWageBillHd>());
            dataSourceList.Add(typeof(List<AttWageBillDtl>), new List<AttWageBillDtl>());
            dataSourceList.Add(typeof(List<USPAttWageBillDtl>), new List<USPAttWageBillDtl>());
            dataSourceList.Add(typeof(List<VAttWageBill>), new List<VAttWageBill>());
        }
        public static void GetDataSource()
        {
            dataSourceList.Clear();
            //dataSourceList = null;
            dataSourceList = BLLFty.Create<DataSourcesBLL>().GetDataSources();

            GetNewList();
            ////添加考勤报表
            //GetAttAppointments();
            //List<Goods> lst = MainForm.dataSourceList[typeof(List<Goods>)] as List<Goods>;
            //foreach (Goods item in lst)
            //{
            //    if (!string.IsNullOrEmpty(item.Code) && item.Pic != null)
            //        ImageHelper.BinaryToImage(item.Pic).Save(string.Format("D:\\ERPToysPic\\{0}.jpg", item.Code));
            //}
            //string dir = @"D:\ERPToysPic\";
            //string[] pics = Directory.GetFiles(dir, "*.jpg");
            //foreach (string item in pics)
            //{
            //    string strCode = Path.GetFileNameWithoutExtension(item).Trim();

            //    //////制作缩略图
            //    Image img = ImageHelper.GetReducedImage(Image.FromFile(item), 24, 24);
            //    ////img.Save(string.Format("D:\\ERPToysPic\\Thumbnail\\{0}.jpg", strCode));
            //    Goods g = ((List<Goods>)MainForm.dataSourceList[typeof(List<Goods>)]).FirstOrDefault(o => o.Code == strCode);
            //    if (g != null && !string.IsNullOrEmpty(g.Code))
            //    {
            //        g.Pic = ImageHelper.MakeBuff(img);
            //        //        g.PicPath = item;
            //        BLLFty.Create<GoodsBLL>().Update(g);
            //    }
            //}

            //DataContractSerializer serializer = new DataContractSerializer(typeof(List<EMSGoodsTrackingDailyReport>));
            //using (FileStream fs = new FileStream("d:\\EMSGoodsTrackingDailyReport.xml", FileMode.Create))
            //{
            //    using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(fs))
            //    {
            //        serializer.WriteObject(writer, dataSourceList[typeof(List<EMSGoodsTrackingDailyReport>)]);
            //    }
            //}

            //using (FileStream fs = new FileStream("c:\\UsersInfo.xml", FileMode.Open, FileAccess.Read))
            //{
            //    using (XmlReader reader = new XmlTextReader("c:\\UsersInfo.xml", fs))
            //    {
            //        List<UsersInfo> pp = (List<UsersInfo>)serializer.ReadObject(reader);
            //    }
            //}
        }

        public static IList GetData(String menuName)
        {
            //IList list = null;
            switch (menuName)
            {
                case MainMenuConstants.Department:
                    list = MainForm.dataSourceList[typeof(List<VDepartment>)] as IList;
                    break;
                case MainMenuConstants.Company:
                    list = MainForm.dataSourceList[typeof(List<VCompany>)] as IList;
                    break;
                case MainMenuConstants.Supplier:
                    list = MainForm.dataSourceList[typeof(List<VSupplier>)] as IList;
                    break;
                case MainMenuConstants.Staff:
                    list = MainForm.dataSourceList[typeof(List<VUsersInfo>)] as IList;
                    break;
                case MainMenuConstants.Goods:
                    list = MainForm.dataSourceList[typeof(List<VGoods>)] as IList;
                    break;
                //case MainMenuConstants.Material:
                //    list = MainForm.dataSourceList[typeof(List<VMaterial>)] as IList;
                //    break;
                case MainMenuConstants.GoodsType:
                    list = MainForm.dataSourceList[typeof(List<VGoodsType>)] as IList;
                    break;
                case MainMenuConstants.Packaging:
                    list = MainForm.dataSourceList[typeof(List<VPackaging>)] as IList;
                    break;
                case MainMenuConstants.ProductionOrderQuery:
                    list = MainForm.dataSourceList[typeof(List<VProductionOrder>)] as IList;
                    break;
                //case MainMenuConstants.ProductionStockInBillQuery:
                //    list = ((List<VStockInBill>)MainForm.dataSourceList[typeof(List<VStockInBill>)]).FindAll(o => o.类型 < 2);
                //    break;
                case MainMenuConstants.ProductionStockInBillQuery:
                    list = ((List<VStockInBill>)MainForm.dataSourceList[typeof(List<VStockInBill>)]).FindAll(o =>
                        o.类型 == 0 || o.类型 == 1);
                    break;
                case MainMenuConstants.SalesReturnBillQuery:
                    list = ((List<VStockInBill>)MainForm.dataSourceList[typeof(List<VStockInBill>)]).FindAll(o =>
                        o.类型 == types.Find(t => t.Type == TypesListConstants.StockInBillType && t.SubType == menuName.Replace("Query", "")).No);
                    break;

                case MainMenuConstants.FGStockInBillQuery:
                case MainMenuConstants.EMSReturnBillQuery:
                case MainMenuConstants.SFGStockInBillQuery:
                case MainMenuConstants.FSMStockInBillQuery:
                case MainMenuConstants.FSMReturnBillQuery:
                case MainMenuConstants.AssembleStockInBillQuery:
                    list = ((List<VMaterialStockInBill>)MainForm.dataSourceList[typeof(List<VMaterialStockInBill>)]).FindAll(o =>
                        o.类型 == types.Find(t => t.Type == TypesListConstants.StockInBillType && t.SubType == menuName.Replace("Query", "")).No);
                    break;
                case MainMenuConstants.ReturnedMaterialBillQuery:
                    list = ((List<VMaterialStockInBill>)MainForm.dataSourceList[typeof(List<VMaterialStockInBill>)]).FindAll(o =>
                        o.类型 == 4 || o.类型 == 7 || o.类型 == 9 || o.类型 == 10);
                    break;
                case MainMenuConstants.OrderQuery:
                    list = MainForm.dataSourceList[typeof(List<VOrder>)] as IList;
                    break;
                case MainMenuConstants.FSMOrderQuery:
                    list = MainForm.dataSourceList[typeof(List<VFSMOrder>)] as IList;
                    break;
                //case MainMenuConstants.FGStockOutBillQuery:
                //    list = ((List<VStockOutBill>)MainForm.dataSourceList[typeof(List<VStockOutBill>)]).FindAll(o => o.类型 < 2);
                //    break;
                //case MainMenuConstants.EMSStockOutBillQuery:
                //    list = ((List<VMaterialStockOutBill>)MainForm.dataSourceList[typeof(List<VMaterialStockOutBill>)]).FindAll(o => o.类型 == 2 || o.类型 == 3);
                //    break;
                case MainMenuConstants.FGStockOutBillQuery:
                    list = ((List<VStockOutBill>)MainForm.dataSourceList[typeof(List<VStockOutBill>)]).FindAll(o =>
                        o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == menuName.Replace("Query", "")).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
                    break;
                case MainMenuConstants.EMSStockOutBillQuery:
                    list = ((List<VMaterialStockOutBill>)MainForm.dataSourceList[typeof(List<VMaterialStockOutBill>)]).FindAll(o =>
                        o.类型 == 2 || o.类型 == 3);
                    break;
                case MainMenuConstants.SFGStockOutBillQuery:
                case MainMenuConstants.FSMStockOutBillQuery:
                case MainMenuConstants.FSMDPReturnBillQuery:
                case MainMenuConstants.EMSDPReturnBillQuery:
                    list = ((List<VMaterialStockOutBill>)MainForm.dataSourceList[typeof(List<VMaterialStockOutBill>)]).FindAll(o =>
                        o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == menuName.Replace("Query", "")).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
                    break;
                case MainMenuConstants.GetMaterialBillQuery:
                    list = ((List<VMaterialStockOutBill>)MainForm.dataSourceList[typeof(List<VMaterialStockOutBill>)]).FindAll(o =>
                        o.类型 == 3 || o.类型 == 5 || o.类型 == 6 || o.类型 == 9);
                    break;
                case MainMenuConstants.InventoryQuery:
                    list = MainForm.dataSourceList[typeof(List<VInventory>)] as IList;
                    break;
                case MainMenuConstants.InventoryGroupByGoodsQuery:
                    list = MainForm.dataSourceList[typeof(List<VInventoryGroupByGoods>)] as IList;
                    break;
                case MainMenuConstants.MaterialInventoryQuery:
                    list = MainForm.dataSourceList[typeof(List<VMaterialInventory>)] as IList;
                    break;
                case MainMenuConstants.InventoryGroupByMaterialQuery:
                    list = MainForm.dataSourceList[typeof(List<VMaterialInventoryGroupByGoods>)] as IList;
                    break;
                case MainMenuConstants.FSMInventoryQuery:
                    list = MainForm.dataSourceList[typeof(List<VFSMInventoryGroupByGoods>)] as IList;
                    break;
                case MainMenuConstants.EMSInventoryQuery:
                    list = MainForm.dataSourceList[typeof(List<VEMSInventoryGroupByGoods>)] as IList;
                    break;
                case MainMenuConstants.AccountBookQuery:
                    list = MainForm.dataSourceList[typeof(List<VAccountBook>)] as IList;
                    break;
                case MainMenuConstants.Stocktaking:
                    list = MainForm.dataSourceList[typeof(List<VStocktaking>)] as IList;
                    break;
                case MainMenuConstants.ProfitAndLoss:
                    list = MainForm.dataSourceList[typeof(List<VProfitAndLoss>)] as IList;
                    break;
                case MainMenuConstants.ReceiptBillQuery:
                    list = MainForm.dataSourceList[typeof(List<VReceiptBill>)] as IList;
                    break;
                case MainMenuConstants.StatementOfAccountToCustomer:
                    list = MainForm.dataSourceList[typeof(List<StatementOfAccountToCustomerReport>)] as IList;
                    break;
                case MainMenuConstants.PaymentBillQuery:
                    list = MainForm.dataSourceList[typeof(List<VPaymentBill>)] as IList;
                    break;
                case MainMenuConstants.StatementOfAccountToSupplier:
                    list = MainForm.dataSourceList[typeof(List<StatementOfAccountToSupplierReport>)] as IList;
                    break;
                //case MainMenuConstants.EMSGoodsTrackingDailyReport:
                //    list = MainForm.dataSourceList[typeof(List<EMSGoodsTrackingDailyReport>)] as IList;
                //    break;
                //case MainMenuConstants.FSMGoodsTrackingDailyReport:
                //    list = MainForm.dataSourceList[typeof(List<FSMGoodsTrackingDailyReport>)] as IList;
                //    break;
                case MainMenuConstants.SampleStockOutReport:
                    list = MainForm.dataSourceList[typeof(List<VSampleStockOut>)] as IList;
                    break;
                case MainMenuConstants.SalesBillSummaryReport:
                    list = MainForm.dataSourceList[typeof(List<VSalesBillSummary>)] as IList;
                    break;
                case MainMenuConstants.SalesSummaryByCustomerReport:
                    list = MainForm.dataSourceList[typeof(List<SalesSummaryByCustomerReport>)] as IList;
                    break;
                //case MainMenuConstants.AnnualSalesSummaryByCustomerReport:
                //    list = MainForm.dataSourceList[typeof(List<AnnualSalesSummaryByCustomerReport>)] as IList;
                //    break;
                case MainMenuConstants.SalesSummaryByGoodsReport:
                    list = MainForm.dataSourceList[typeof(List<SalesSummaryByGoodsReport>)] as IList;
                    break;
                case MainMenuConstants.SalesSummaryByGoodsPriceReport:
                    list = MainForm.dataSourceList[typeof(List<SalesSummaryByGoodsPriceReport>)] as IList;
                    break;
                //case MainMenuConstants.AnnualSalesSummaryByGoodsReport:
                //    list = MainForm.dataSourceList[typeof(List<AnnualSalesSummaryByGoodsReport>)] as IList;
                //    break;
                case MainMenuConstants.GoodsSalesSummaryByCustomerReport:
                    list = MainForm.dataSourceList[typeof(List<GoodsSalesSummaryByCustomerReport>)] as IList;
                    break;
                case MainMenuConstants.AlertQuery:
                    list = MainForm.dataSourceList[typeof(List<VAlert>)] as IList;
                    break;
                case MainMenuConstants.AttGeneralLog:
                    list = MainForm.dataSourceList[typeof(List<VAttGeneralLog>)] as IList;
                    break;
                //case MainMenuConstants.SchClass:
                //    list = MainForm.dataSourceList[typeof(List<SchClass>)] as IList;
                //    break;
                case MainMenuConstants.SchedulingQuery:
                    list = MainForm.dataSourceList[typeof(List<VAppointments>)] as IList;
                    break;
                case MainMenuConstants.WageBillQuery:
                    list = MainForm.dataSourceList[typeof(List<VWageBill>)] as IList;
                    break;
                case MainMenuConstants.AttendanceQuery:
                    list = MainForm.dataSourceList[typeof(List<VAttAppointments>)] as IList;
                    break;
                case MainMenuConstants.AttWageBillQuery:
                    list = MainForm.dataSourceList[typeof(List<VAttWageBill>)] as IList;
                    break;
            }
            return list;
        }

        public static void GetDBData(String menuName,String filter)
        {
            switch (menuName)
            {
                case MainMenuConstants.Department:
                    MainForm.dataSourceList[typeof(List<Department>)] = BLLFty.Create<DepartmentBLL>().GetDepartment();
                    MainForm.dataSourceList[typeof(List<VDepartment>)] = BLLFty.Create<DepartmentBLL>().GetVDepartment();
                    break;
                case MainMenuConstants.Company:
                    MainForm.dataSourceList[typeof(List<Company>)] = BLLFty.Create<CompanyBLL>().GetCompany();
                    MainForm.dataSourceList[typeof(List<VCompany>)] = BLLFty.Create<CompanyBLL>().GetVCompany();
                    break;
                case MainMenuConstants.Supplier:
                    MainForm.dataSourceList[typeof(List<Supplier>)] = BLLFty.Create<SupplierBLL>().GetSupplier();
                    MainForm.dataSourceList[typeof(List<VSupplier>)] = BLLFty.Create<SupplierBLL>().GetVSupplier();
                    break;
                case MainMenuConstants.Staff:
                    MainForm.dataSourceList[typeof(List<UsersInfo>)] = BLLFty.Create<UsersInfoBLL>().GetUsersInfo();
                    MainForm.dataSourceList[typeof(List<VUsersInfo>)] = BLLFty.Create<UsersInfoBLL>().GetVUsersInfo();
                    break;
                case MainMenuConstants.Goods:
                    MainForm.dataSourceList[typeof(List<Goods>)] = BLLFty.Create<GoodsBLL>().GetGoods();
                    MainForm.dataSourceList[typeof(List<VGoods>)] = BLLFty.Create<GoodsBLL>().GetVGoods();
                    MainForm.dataSourceList[typeof(List<VParentGoodsByBOM>)] = BLLFty.Create<GoodsBLL>().GetVParentGoodsByBOM();
                    break;
                case MainMenuConstants.Material:
                    MainForm.dataSourceList[typeof(List<Goods>)] = BLLFty.Create<GoodsBLL>().GetGoods();
                    MainForm.dataSourceList[typeof(List<VMaterial>)] = BLLFty.Create<GoodsBLL>().GetVMaterial();
                    MainForm.dataSourceList[typeof(List<VGoodsByBOM>)] = BLLFty.Create<GoodsBLL>().GetVGoodsByBOM();
                    MainForm.dataSourceList[typeof(List<VGoodsByMoldAllot>)] = BLLFty.Create<GoodsBLL>().GetVGoodsByMoldAllot();
                    break;
                case MainMenuConstants.GoodsType:
                    MainForm.dataSourceList[typeof(List<GoodsType>)] = BLLFty.Create<GoodsTypeBLL>().GetGoodsType();
                    MainForm.dataSourceList[typeof(List<VGoodsType>)] = BLLFty.Create<GoodsTypeBLL>().GetVGoodsType();
                    break;
                case MainMenuConstants.Packaging:
                    MainForm.dataSourceList[typeof(List<Packaging>)] = BLLFty.Create<PackagingBLL>().GetPackaging();
                    MainForm.dataSourceList[typeof(List<VPackaging>)] = BLLFty.Create<PackagingBLL>().GetVPackaging();
                    break;
                case MainMenuConstants.BOM:
                case MainMenuConstants.MoldList:
                case MainMenuConstants.MoldMaterial:
                case MainMenuConstants.Assemble:
                    MainForm.dataSourceList[typeof(List<BOM>)] = BLLFty.Create<BOMBLL>().GetBOM();
                    break;
                case MainMenuConstants.MoldAllot:
                    MainForm.dataSourceList[typeof(List<MoldAllot>)] = BLLFty.Create<MoldAllotBLL>().GetMoldAllot();
                    break;
                case MainMenuConstants.CustomerSLSalePrice:
                case MainMenuConstants.SupplierSLSalePrice:
                    MainForm.dataSourceList[typeof(List<SLSalePrice>)] = BLLFty.Create<SLSalePriceBLL>().GetSLSalePrice();
                    break;
                case MainMenuConstants.PermissionSetting:
                    MainForm.dataSourceList[typeof(List<Permission>)] = BLLFty.Create<PermissionBLL>().GetPermission();
                    MainForm.dataSourceList[typeof(List<ButtonPermission>)] = BLLFty.Create<PermissionBLL>().GetButtonPermission();
                    break;
                case MainMenuConstants.ProductionScheduling:
                    MainForm.dataSourceList[typeof(List<Appointments>)] = BLLFty.Create<AppointmentsBLL>().GetAppointments();
                    MainForm.dataSourceList[typeof(List<VAppointments>)] = BLLFty.Create<AppointmentsBLL>().GetVAppointments();
                    break;
                case MainMenuConstants.SchClass:
                    MainForm.dataSourceList[typeof(List<SchClass>)] = BLLFty.Create<SchClassBLL>().GetSchClass();
                    break;
                case MainMenuConstants.StaffSchClass:
                    MainForm.dataSourceList[typeof(List<StaffSchClass>)] = BLLFty.Create<StaffSchClassBLL>().GetStaffSchClass();
                    MainForm.dataSourceList[typeof(List<VStaffSchClass>)] = BLLFty.Create<StaffSchClassBLL>().GetVStaffSchClass();
                    break;
                case MainMenuConstants.StaffAttendance:
                    MainForm.dataSourceList[typeof(List<AttAppointments>)] = BLLFty.Create<AttAppointmentsBLL>().GetAttAppointments();
                    MainForm.dataSourceList[typeof(List<VAttAppointments>)] = BLLFty.Create<AttAppointmentsBLL>().GetVAttAppointments();
                    break;

                case MainMenuConstants.ProductionOrderQuery:
                    MainForm.dataSourceList[typeof(List<VProductionOrder>)] = BLLFty.Create<ReportBLL>().GetT<VProductionOrder>("VProductionOrder", filter).OrderByDescending(o => o.类型).OrderBy(o => o.状态).ToList();
                    break;
                case MainMenuConstants.ProductionStockInBillQuery:
                    MainForm.dataSourceList[typeof(List<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", filter).FindAll(o =>
                        o.类型 == 0 || o.类型 == 1).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
                    break;
                case MainMenuConstants.SalesReturnBillQuery:
                    MainForm.dataSourceList[typeof(List<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", filter).FindAll(o =>
                        o.类型 == types.Find(t => t.Type == TypesListConstants.StockInBillType && t.SubType == menuName.Replace("Query", "")).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
                    break;
                case MainMenuConstants.FGStockInBillQuery:
                case MainMenuConstants.EMSReturnBillQuery:
                case MainMenuConstants.SFGStockInBillQuery:
                case MainMenuConstants.FSMStockInBillQuery:
                case MainMenuConstants.FSMReturnBillQuery:
                case MainMenuConstants.AssembleStockInBillQuery:
                    MainForm.dataSourceList[typeof(List<VMaterialStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VMaterialStockInBill>("VMaterialStockInBill", filter).FindAll(o =>
                        o.类型 == types.Find(t => t.Type == TypesListConstants.StockInBillType && t.SubType == menuName.Replace("Query", "")).No).OrderBy(o=>o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
                    MainForm.dataSourceList[typeof(List<SLSalePrice>)] = BLLFty.Create<SLSalePriceBLL>().GetSLSalePrice();
                    break;
                case MainMenuConstants.ReturnedMaterialBillQuery:
                    MainForm.dataSourceList[typeof(List<VMaterialStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VMaterialStockInBill>("VMaterialStockInBill", filter).FindAll(o =>
                        o.类型 == 4 || o.类型 == 7 || o.类型 == 9 || o.类型 == 10).OrderBy(o=>o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
                    break;
                case MainMenuConstants.OrderQuery:
                    MainForm.dataSourceList[typeof(List<VOrder>)] = BLLFty.Create<ReportBLL>().GetT<VOrder>("VOrder", filter).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o=>o.订货单号).ToList();
                    MainForm.dataSourceList[typeof(List<SLSalePrice>)] = BLLFty.Create<SLSalePriceBLL>().GetSLSalePrice();
                    break;
                case MainMenuConstants.FSMOrderQuery:
                    MainForm.dataSourceList[typeof(List<VFSMOrder>)] = BLLFty.Create<ReportBLL>().GetT<VFSMOrder>("VFSMOrder", filter).OrderByDescending(o => o.类型).OrderBy(o => o.状态).ToList();
                    break;
                case MainMenuConstants.FGStockOutBillQuery:
                    MainForm.dataSourceList[typeof(List<VStockOutBill>)] =BLLFty.Create<ReportBLL>().GetT<VStockOutBill>("VStockOutBill", filter).FindAll(o =>
                        o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == menuName.Replace("Query", "")).No).OrderBy(o=>o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
                    MainForm.dataSourceList[typeof(List<SLSalePrice>)] = BLLFty.Create<SLSalePriceBLL>().GetSLSalePrice();
                    break;
                case MainMenuConstants.EMSStockOutBillQuery:
                    MainForm.dataSourceList[typeof(List<VMaterialStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VMaterialStockOutBill>("VMaterialStockOutBill", filter).FindAll(o =>
                        o.类型 == 2 || o.类型 == 3).OrderBy(o=>o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
                    break;
                case MainMenuConstants.SFGStockOutBillQuery:
                case MainMenuConstants.FSMStockOutBillQuery:
                    MainForm.dataSourceList[typeof(List<VMaterialStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VMaterialStockOutBill>("VMaterialStockOutBill", filter).FindAll(o =>
                        o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == menuName.Replace("Query", "")).No).OrderBy(o=>o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
                    break;
                case MainMenuConstants.GetMaterialBillQuery:
                    MainForm.dataSourceList[typeof(List<VMaterialStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VMaterialStockOutBill>("VMaterialStockOutBill", filter).FindAll(o =>
                        o.类型 == 3 || o.类型 == 5 || o.类型 == 6 || o.类型 == 9).OrderBy(o=>o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
                    break;
                case MainMenuConstants.ReceiptBillQuery:
                    MainForm.dataSourceList[typeof(List<VReceiptBill>)] = BLLFty.Create<ReportBLL>().GetT<VReceiptBill>("VReceiptBill", filter);
                    break;
                case MainMenuConstants.StatementOfAccountToCustomer:
                    MainForm.dataSourceList[typeof(List<StatementOfAccountToCustomerReport>)] = BLLFty.Create<ReportBLL>().GetStatementOfAccountToCustomerReport(filter);
                    break;
                case MainMenuConstants.PaymentBillQuery:
                    MainForm.dataSourceList[typeof(List<VPaymentBill>)] = BLLFty.Create<ReportBLL>().GetT<VPaymentBill>("VPaymentBill", filter);
                    break;
                case MainMenuConstants.StatementOfAccountToSupplier:
                    MainForm.dataSourceList[typeof(List<StatementOfAccountToSupplierReport>)] = BLLFty.Create<ReportBLL>().GetStatementOfAccountToSupplierReport(filter);
                    break;
                case MainMenuConstants.SampleStockOutReport:
                    MainForm.dataSourceList[typeof(List<VSampleStockOut>)] = BLLFty.Create<ReportBLL>().GetT<VSampleStockOut>("VSampleStockOut", filter);
                    break;
                case MainMenuConstants.SalesBillSummaryReport:
                    MainForm.dataSourceList[typeof(List<VSalesBillSummary>)] = BLLFty.Create<ReportBLL>().GetT<VSalesBillSummary>("VSalesBillSummary", filter);
                    break;
                case MainMenuConstants.SalesSummaryByCustomerReport:
                    MainForm.dataSourceList[typeof(List<SalesSummaryByCustomerReport>)] = BLLFty.Create<ReportBLL>().GetSalesSummaryByCustomerReport(filter);
                    break;
                case MainMenuConstants.SalesSummaryByGoodsReport:
                    MainForm.dataSourceList[typeof(List<SalesSummaryByGoodsReport>)] = BLLFty.Create<ReportBLL>().GetSalesSummaryByGoodsReport(filter);
                    break;
                case MainMenuConstants.SalesSummaryByGoodsPriceReport:
                    MainForm.dataSourceList[typeof(List<SalesSummaryByGoodsPriceReport>)] = BLLFty.Create<ReportBLL>().GetSalesSummaryByGoodsPriceReport(filter);
                    break;
                case MainMenuConstants.GoodsSalesSummaryByCustomerReport:
                    MainForm.dataSourceList[typeof(List<GoodsSalesSummaryByCustomerReport>)] = BLLFty.Create<ReportBLL>().GetGoodsSalesSummaryByCustomerReport(filter);
                    break;
                case MainMenuConstants.SchedulingQuery:
                    MainForm.dataSourceList[typeof(List<VAppointments>)] = BLLFty.Create<ReportBLL>().GetT<VAppointments>("VAppointments", filter);
                    break;
                case MainMenuConstants.WageBillQuery:
                    MainForm.dataSourceList[typeof(List<VWageBill>)] = BLLFty.Create<ReportBLL>().GetT<VWageBill>("VWageBill", filter);
                    break;
                case MainMenuConstants.AttWageBillQuery:
                    MainForm.dataSourceList[typeof(List<VAttWageBill>)] = BLLFty.Create<ReportBLL>().GetT<VAttWageBill>("VAttWageBill", filter);
                    break;
                case MainMenuConstants.InventoryQuery:
                    MainForm.dataSourceList[typeof(List<VInventory>)] = BLLFty.Create<ReportBLL>().GetT<VInventory>("VInventory", filter);
                    break;
                case MainMenuConstants.InventoryGroupByGoodsQuery:
                    MainForm.dataSourceList[typeof(List<VInventoryGroupByGoods>)] = BLLFty.Create<ReportBLL>().GetT<VInventoryGroupByGoods>("VInventoryGroupByGoods", filter);
                    break;
                case MainMenuConstants.MaterialInventoryQuery:
                    MainForm.dataSourceList[typeof(List<VMaterialInventory>)] = BLLFty.Create<ReportBLL>().GetT<VMaterialInventory>("VMaterialInventory", filter);
                    break;
                case MainMenuConstants.InventoryGroupByMaterialQuery:
                    MainForm.dataSourceList[typeof(List<VMaterialInventoryGroupByGoods>)] = BLLFty.Create<ReportBLL>().GetT<VMaterialInventoryGroupByGoods>("VMaterialInventoryGroupByGoods", filter);
                    break;
                case MainMenuConstants.FSMInventoryQuery:
                    MainForm.dataSourceList[typeof(List<VFSMInventoryGroupByGoods>)] = BLLFty.Create<ReportBLL>().GetT<VFSMInventoryGroupByGoods>("VFSMInventoryGroupByGoods", filter);
                    break;
                case MainMenuConstants.EMSInventoryQuery:
                    MainForm.dataSourceList[typeof(List<VEMSInventoryGroupByGoods>)] = BLLFty.Create<ReportBLL>().GetT<VEMSInventoryGroupByGoods>("VEMSInventoryGroupByGoods", filter);
                    break;
                case MainMenuConstants.AccountBookQuery:
                    MainForm.dataSourceList[typeof(List<VAccountBook>)] = BLLFty.Create<ReportBLL>().GetT<VWageBill>("VAccountBook", filter);
                    break;
            }
        }

        public static void BillSaveRefresh(String billType)
        {
            //单据查询界面数据更新
            if (MainForm.itemDetailList.ContainsKey(billType))
            {
                DataQueryPage page = MainForm.itemDetailList[billType] as DataQueryPage;
                GetDBData(billType, string.Empty);
                if (billType==MainMenuConstants.OrderQuery)
                {
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.FGStockOutBillQuery))
                    {
                        DataQueryPage bill = MainForm.itemDetailList[MainMenuConstants.FGStockOutBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockOutBill>("VStockOutBill", string.Empty).FindAll(o =>
                            o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == MainMenuConstants.FGStockOutBill).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
                        bill.InitGrid(MainForm.GetData(MainMenuConstants.FGStockOutBillQuery));
                    }
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.ProductionOrderQuery))
                    {
                        DataQueryPage order = MainForm.itemDetailList[MainMenuConstants.ProductionOrderQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VProductionOrder>)] = BLLFty.Create<ReportBLL>().GetT<VProductionOrder>("VProductionOrder", string.Empty).OrderByDescending(o => o.类型).OrderBy(o => o.状态).ToList();
                        order.InitGrid(MainForm.GetData(MainMenuConstants.ProductionOrderQuery));
                    }
                }
                else if (billType == MainMenuConstants.ProductionOrderQuery)
                {
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.ProductionStockInBillQuery))
                    {
                        DataQueryPage bill = MainForm.itemDetailList[MainMenuConstants.ProductionStockInBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", string.Empty).FindAll(o =>
                            o.类型 == 0 || o.类型 == 1).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
                        bill.InitGrid(MainForm.GetData(MainMenuConstants.ProductionStockInBillQuery));
                    }
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.FGStockInBillQuery))
                    {
                        DataQueryPage bill = MainForm.itemDetailList[MainMenuConstants.FGStockInBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", string.Empty).FindAll(o =>
                            o.类型 == 3).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
                        bill.InitGrid(MainForm.GetData(MainMenuConstants.FGStockInBillQuery));
                    }
                }
                else if (billType == MainMenuConstants.FSMOrderQuery)
                {
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.FSMStockInBillQuery))
                    {
                        DataQueryPage bill = MainForm.itemDetailList[MainMenuConstants.FSMStockInBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VMaterialStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VMaterialStockInBill>("VMaterialStockInBill", string.Empty).FindAll(o =>
                            o.类型 == types.Find(t => t.Type == TypesListConstants.StockInBillType && t.SubType == MainMenuConstants.FSMStockInBill).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
                        bill.InitGrid(MainForm.GetData(MainMenuConstants.FSMStockInBillQuery));
                    }
                }
                else if (billType == MainMenuConstants.WageBillQuery)
                {
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.WageBillQuery))
                    {
                        DataQueryPage bill = MainForm.itemDetailList[MainMenuConstants.WageBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VWageBill>)] = BLLFty.Create<ReportBLL>().GetT<VWageBill>("VWageBill", string.Empty);
                        bill.InitGrid(MainForm.GetData(MainMenuConstants.WageBillQuery));
                    }
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.SchedulingQuery))
                    {
                        DataQueryPage bill = MainForm.itemDetailList[MainMenuConstants.SchedulingQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VAppointments>)] = BLLFty.Create<ReportBLL>().GetT<VAppointments>("VAppointments", string.Empty);
                        bill.InitGrid(MainForm.GetData(MainMenuConstants.SchedulingQuery));
                    }
                }
                else if (billType == MainMenuConstants.AttWageBillQuery)
                {
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.AttWageBillQuery))
                    {
                        DataQueryPage bill = MainForm.itemDetailList[MainMenuConstants.AttWageBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VAttWageBill>)] = BLLFty.Create<ReportBLL>().GetT<VAttWageBill>("VAttWageBill", string.Empty);
                        bill.InitGrid(MainForm.GetData(MainMenuConstants.AttWageBillQuery));
                    }
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.AttendanceQuery))
                    {
                        DataQueryPage bill = MainForm.itemDetailList[MainMenuConstants.AttendanceQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VAttAppointments>)] = BLLFty.Create<ReportBLL>().GetT<VAttAppointments>("VAttAppointments", string.Empty);
                        bill.InitGrid(MainForm.GetData(MainMenuConstants.AttendanceQuery));
                    }
                }
                else if (billType==MainMenuConstants.ReceiptBillQuery)
                {
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.StatementOfAccountToCustomer))
                    {
                        DataQueryPage billPurchase = MainForm.itemDetailList[MainMenuConstants.StatementOfAccountToCustomer] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<StatementOfAccountToCustomerReport>)] = BLLFty.Create<ReportBLL>().GetStatementOfAccountToCustomerReport(string.Empty);
                        billPurchase.InitGrid(MainForm.GetData(MainMenuConstants.StatementOfAccountToCustomer));
                    }
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.ReceiptBillQuery))
                    {
                        DataQueryPage billPurchase = MainForm.itemDetailList[MainMenuConstants.ReceiptBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VReceiptBill>)] = BLLFty.Create<ReceiptBillBLL>().GetReceiptBill();
                        billPurchase.InitGrid(MainForm.GetData(MainMenuConstants.ReceiptBillQuery));
                    }
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.FGStockOutBillQuery))
                    {
                        DataQueryPage bill = MainForm.itemDetailList[MainMenuConstants.FGStockOutBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockOutBill>("VStockOutBill", string.Empty).FindAll(o =>
                            o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == MainMenuConstants.FGStockOutBill).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
                        bill.InitGrid(MainForm.GetData(MainMenuConstants.FGStockOutBillQuery));
                    }
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.SalesReturnBillQuery))
                    {
                        DataQueryPage billSalesReturn = MainForm.itemDetailList[MainMenuConstants.SalesReturnBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", string.Empty).FindAll(o =>
                            o.类型 == 0 || o.类型 == 1).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
                        billSalesReturn.InitGrid(MainForm.GetData(MainMenuConstants.SalesReturnBillQuery));
                    }
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.SFGStockOutBillQuery))
                    {
                        DataQueryPage billPurchaseReturn = MainForm.itemDetailList[MainMenuConstants.SFGStockOutBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockOutBill>("VStockOutBill", string.Empty).FindAll(o =>
                            o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == MainMenuConstants.FGStockOutBill).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
                        billPurchaseReturn.InitGrid(MainForm.GetData(MainMenuConstants.SFGStockOutBillQuery));
                    }
                }
                else if (billType==MainMenuConstants.PaymentBillQuery)
                {
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.StatementOfAccountToSupplier))
                    {
                        DataQueryPage billPurchase = MainForm.itemDetailList[MainMenuConstants.StatementOfAccountToSupplier] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<StatementOfAccountToSupplierReport>)] = BLLFty.Create<ReportBLL>().GetStatementOfAccountToSupplierReport(string.Empty);
                        billPurchase.InitGrid(MainForm.GetData(MainMenuConstants.StatementOfAccountToSupplier));
                    }
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.PaymentBillQuery))
                    {
                        DataQueryPage billPurchase = MainForm.itemDetailList[MainMenuConstants.PaymentBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VPaymentBill>)] = BLLFty.Create<PaymentBillBLL>().GetPaymentBill();
                        billPurchase.InitGrid(MainForm.GetData(MainMenuConstants.PaymentBillQuery));
                    }
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.SFGStockInBillQuery))
                    {
                        DataQueryPage billPurchase = MainForm.itemDetailList[MainMenuConstants.SFGStockInBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", string.Empty).FindAll(o =>
                            o.类型 == 0 || o.类型 == 1).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
                        billPurchase.InitGrid(MainForm.GetData(MainMenuConstants.SFGStockInBillQuery));
                    }
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.SFGStockOutBillQuery))
                    {
                        DataQueryPage billPurchaseReturn = MainForm.itemDetailList[MainMenuConstants.SFGStockOutBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockOutBill>("VStockOutBill", string.Empty).FindAll(o =>
                            o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == MainMenuConstants.FGStockOutBill).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
                        billPurchaseReturn.InitGrid(MainForm.GetData(MainMenuConstants.SFGStockOutBillQuery));
                    }
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.SalesReturnBillQuery))
                    {
                        DataQueryPage billSalesReturn = MainForm.itemDetailList[MainMenuConstants.SalesReturnBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", string.Empty).FindAll(o =>
                            o.类型 == 0 || o.类型 == 1).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
                        billSalesReturn.InitGrid(MainForm.GetData(MainMenuConstants.SalesReturnBillQuery));
                    }
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.FGStockInBillQuery))
                    {
                        DataQueryPage billEMS = MainForm.itemDetailList[MainMenuConstants.FGStockInBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", string.Empty).FindAll(o =>
                            o.类型 == 0 || o.类型 == 1).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
                        billEMS.InitGrid(MainForm.GetData(MainMenuConstants.FGStockInBillQuery));
                    }
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.EMSDPReturnBillQuery))
                    {
                        DataQueryPage billEMSDPReturn = MainForm.itemDetailList[MainMenuConstants.EMSDPReturnBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockOutBill>("VStockOutBill", string.Empty).FindAll(o =>
                            o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == MainMenuConstants.FGStockOutBill).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
                        billEMSDPReturn.InitGrid(MainForm.GetData(MainMenuConstants.EMSDPReturnBillQuery));
                    }
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.FSMStockInBillQuery))
                    {
                        DataQueryPage billFSM = MainForm.itemDetailList[MainMenuConstants.FSMStockInBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", string.Empty).FindAll(o =>
                            o.类型 == 0 || o.类型 == 1).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
                        billFSM.InitGrid(MainForm.GetData(MainMenuConstants.FSMStockInBillQuery));
                    }
                    if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.FSMDPReturnBillQuery))
                    {
                        DataQueryPage billFSMDPReturn = MainForm.itemDetailList[MainMenuConstants.FSMDPReturnBillQuery] as DataQueryPage;
                        MainForm.dataSourceList[typeof(List<VStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockOutBill>("VStockOutBill", string.Empty).FindAll(o =>
                            o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == MainMenuConstants.FGStockOutBill).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
                        billFSMDPReturn.InitGrid(MainForm.GetData(MainMenuConstants.FSMDPReturnBillQuery));
                    }
                }
                page.InitGrid(MainForm.GetData(billType));
            }
        }

        public static void InventoryRefresh()
        {
            //刷新库存界面
            if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.InventoryQuery))
            {
                DataQueryPage page = MainForm.itemDetailList[MainMenuConstants.InventoryQuery] as DataQueryPage;
                MainForm.dataSourceList[typeof(List<VInventory>)] = BLLFty.Create<InventoryBLL>().GetInventory();
                page.InitGrid(MainForm.GetData(MainMenuConstants.InventoryQuery));
            }
            if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.InventoryGroupByGoodsQuery))
            {
                DataQueryPage page = MainForm.itemDetailList[MainMenuConstants.InventoryGroupByGoodsQuery] as DataQueryPage;
                MainForm.dataSourceList[typeof(List<VInventoryGroupByGoods>)] = BLLFty.Create<InventoryBLL>().GetInventoryGroupByGoods();
                page.InitGrid(MainForm.GetData(MainMenuConstants.InventoryGroupByGoodsQuery));
            }
            if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.MaterialInventoryQuery))
            {
                DataQueryPage page = MainForm.itemDetailList[MainMenuConstants.MaterialInventoryQuery] as DataQueryPage;
                MainForm.dataSourceList[typeof(List<VMaterialInventory>)] = BLLFty.Create<InventoryBLL>().GetMaterialInventory();
                page.InitGrid(MainForm.GetData(MainMenuConstants.MaterialInventoryQuery));
            }
            if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.InventoryGroupByMaterialQuery))
            {
                DataQueryPage page = MainForm.itemDetailList[MainMenuConstants.InventoryGroupByMaterialQuery] as DataQueryPage;
                MainForm.dataSourceList[typeof(List<VMaterialInventoryGroupByGoods>)] = BLLFty.Create<InventoryBLL>().GetMaterialInventoryGroupByGoods();
                page.InitGrid(MainForm.GetData(MainMenuConstants.InventoryGroupByMaterialQuery));
            }
            if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.FSMInventoryQuery))
            {
                DataQueryPage page = MainForm.itemDetailList[MainMenuConstants.FSMInventoryQuery] as DataQueryPage;
                MainForm.dataSourceList[typeof(List<VFSMInventoryGroupByGoods>)] = BLLFty.Create<InventoryBLL>().GetFSMInventoryGroupByGoods();
                page.InitGrid(MainForm.GetData(MainMenuConstants.FSMInventoryQuery));
            }
            if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.EMSInventoryQuery))
            {
                DataQueryPage page = MainForm.itemDetailList[MainMenuConstants.EMSInventoryQuery] as DataQueryPage;
                MainForm.dataSourceList[typeof(List<VEMSInventoryGroupByGoods>)] = BLLFty.Create<InventoryBLL>().GetEMSInventoryGroupByGoods();
                page.InitGrid(MainForm.GetData(MainMenuConstants.EMSInventoryQuery));
            }
            if (MainForm.itemDetailList.ContainsKey(MainMenuConstants.AccountBookQuery))
            {
                DataQueryPage page = MainForm.itemDetailList[MainMenuConstants.AccountBookQuery] as DataQueryPage;
                MainForm.dataSourceList[typeof(List<VAccountBook>)] = BLLFty.Create<InventoryBLL>().GetAccountBook();
                page.InitGrid(MainForm.GetData(MainMenuConstants.AccountBookQuery));
            }
        }

        public static void DataPageRefresh(String menuName)
        {
            if (menuName == string.Empty)
                GetDataSource();
            else
                GetDBData(menuName, string.Empty);
            foreach (KeyValuePair<String, IItemDetail> kvp in itemDetailList)
            {
                if (kvp.Value is DataQueryPage)
                {
                    DataQueryPage page = ((DataQueryPage)kvp.Value);
                    GetData(kvp.Key);
                    page.InitGrid(list);
                }
                else if (kvp.Value is GoodsEditPage)
                {
                    GoodsEditPage page = kvp.Value as GoodsEditPage;
                    if (page != null)
                        page.BindData();
                }
                //单据编辑界面数据更新
                else if (kvp.Value is OrderEditPage)
                {
                    OrderEditPage page = kvp.Value as OrderEditPage;
                    if (page != null)
                        page.BindData(Guid.Empty);
                }
                else if (kvp.Value is StockInBillPage)
                {
                    StockInBillPage page = kvp.Value as StockInBillPage;
                    if (page != null)
                        page.BindData(Guid.Empty);
                }
                else if (kvp.Value is StockOutBillPage)
                {
                    StockOutBillPage page = kvp.Value as StockOutBillPage;
                    if (page != null)
                        page.BindData(Guid.Empty);
                }
                else if (kvp.Value is ReceiptBillPage)
                {
                    ReceiptBillPage page = kvp.Value as ReceiptBillPage;
                    if (page != null)
                        page.BindData(Guid.Empty);
                }
                else if (kvp.Value is PaymentBillPage)
                {
                    PaymentBillPage page = kvp.Value as PaymentBillPage;
                    if (page != null)
                        page.BindData(Guid.Empty);
                }
                else if (kvp.Value is BOMEditPage)
                {
                    BOMEditPage page = kvp.Value as BOMEditPage;
                    if (page != null)
                        page.BindData();
                }
                else if (kvp.Value is MoldAllotPage)
                {
                    MoldAllotPage page = kvp.Value as MoldAllotPage;
                    if (page != null)
                        page.BindData();
                }
                else if (kvp.Value is SLSalePricePage)
                {
                    SLSalePricePage page = kvp.Value as SLSalePricePage;
                    if (page != null)
                        page.BindData();
                }
                else if (kvp.Value is PermissionSettingPage)
                {
                    PermissionSettingPage page = kvp.Value as PermissionSettingPage;
                    if (page != null)
                        page.BindData();
                }
                else if (kvp.Value is ProductionSchedulingPage)
                {
                    ProductionSchedulingPage page = kvp.Value as ProductionSchedulingPage;
                    if (page != null)
                        page.BindData();
                }
                else if (kvp.Value is WageBillPage)
                {
                    WageBillPage page = kvp.Value as WageBillPage;
                    if (page != null)
                        page.BindData(Guid.Empty);
                }
                else if (kvp.Value is AttendanceSchedulingPage)
                {
                    AttendanceSchedulingPage page = kvp.Value as AttendanceSchedulingPage;
                    if (page != null)
                        page.BindData();
                }
                else if (kvp.Value is StaffSchClassPage)
                {
                    StaffSchClassPage page = kvp.Value as StaffSchClassPage;
                    if (page != null)
                        page.BindData();
                }
                else if (kvp.Value is AttWageBillPage)
                {
                    AttWageBillPage page = kvp.Value as AttWageBillPage;
                    if (page != null)
                        page.BindData(Guid.Empty);
                }
            }
        }

        public static void DataQueryPageRefresh()
        {
            GetDataSource();
            foreach (KeyValuePair<String, IItemDetail> kvp in itemDetailList)
            {
                if (kvp.Value is DataQueryPage)
                {
                    DataQueryPage page = ((DataQueryPage)kvp.Value);
                    GetData(kvp.Key);
                    page.InitGrid(list);
                }
                else if (kvp.Value is GoodsEditPage)
                {
                    GoodsEditPage page = kvp.Value as GoodsEditPage;
                    if (page != null)
                        page.BindData();
                }
            }
        }

        public static void SetQueryPageGridColumn(DevExpress.XtraGrid.Views.Grid.GridView gv, DBML.MainMenu menu)
        {
            ////gv.BestFitColumns();
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gv.Columns)
            {
                //if (col.Name.ToUpper() == "colID".ToUpper() || col.Name.ToUpper() == "colHdID".ToUpper())
                if (col.Name.ToUpper().Contains("ID".ToUpper()) || col.Name.ToUpper() == "COLTYPE" || col.Name.ToUpper() == "COLPICPATH" || col.Name.ToUpper().Contains("SERIALNO") || col.Name.ToUpper().Contains("PASSWORD"))
                //|| col.FieldName == "制单人" || col.FieldName == "制单日期" || col.FieldName == "审核人" || col.FieldName == "审核日期")
                    col.Visible = false;
                if (MainForm.Company.Contains("纸"))
                {
                    if (col.FieldName == "包装方式" || col.FieldName == "装箱数" || col.FieldName == "内盒" || col.FieldName == "外箱规格" || col.FieldName == "体积" || col.FieldName == "一出几"
                        || col.FieldName == "正唛" || col.FieldName == "总数量")
                        col.Visible = false;
                    if (col.FieldName == "箱数")
                        col.Caption = "数量";
                    if (col.FieldName == "待发箱数")
                        col.Caption = "待发数量";
                    if (col.FieldName == "可用箱数")
                        col.Caption = "可用数量";
                }
                if (col.ColumnType.Equals(typeof(System.Data.Linq.Binary)))
                {
                    col.Width = 50;  //调整图片的列宽度
                }
                if (col.FieldName.Contains("单号") || col.FieldName.Contains("编号"))
                    col.Width = 120;
                if (col.FieldName == "已退料入库")
                    col.Width = 80;
                if (col.FieldName == "单价" || col.FieldName == "售价" || col.FieldName == "进价" || col.FieldName == "成本价")
                {
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.DisplayFormat.FormatString = "c5";
                }
                if (col.FieldName.Contains("金额") || col.FieldName == "额外费用" ||
                    col.FieldName == "成本" || col.FieldName == "毛利")
                {
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.DisplayFormat.FormatString = "c";
                }
                if (col.FieldName.Contains("率"))
                {
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.DisplayFormat.FormatString = "p";
                }
                if (col.FieldName.Contains("数量"))
                {
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.DisplayFormat.FormatString = "n";
                }
                if (col.FieldName == "去税单价")
                {
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.DisplayFormat.FormatString = "c6";
                }
                if (col.FieldName == "上班时间" || col.FieldName == "下班时间" || col.FieldName == "签到时间" || col.FieldName == "签退时间")
                {
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    col.DisplayFormat.FormatString = "T";
                }
                if (col.FieldName == "出勤时间")
                {
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    col.DisplayFormat.FormatString = "G";
                    col.Width = 130;
                }
                if (col.FieldName == "类型" || col.FieldName == "订单类型" || col.FieldName == "状态")
                    col.AppearanceHeader.ForeColor = Color.Blue;
                //else if (col.FieldName == "品名")
                //{
                //    //总计
                //    col.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                //    new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count,"货号", "总计:{0}")});
                //    //组计
                //    gv.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, "货号", col, "小组合计:{0}");
                //}

                if ((menu.Name == MainMenuConstants.InventoryQuery || menu.Name == MainMenuConstants.MaterialInventoryQuery))
                {
                    if (col.FieldName == "货号")
                    {
                        col.GroupIndex = 0;
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                    else if (col.FieldName == "品名")
                    {
                        col.BestFit();
                    }
                }
                else if (menu.Name == MainMenuConstants.InventoryGroupByGoodsQuery)
                {
                    if (col.FieldName == "仓库类型")
                    {
                        col.GroupIndex = 0;
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                    else if (col.FieldName == "货号")
                    {
                        col.BestFit();
                    }
                }
                else if (menu.Name == MainMenuConstants.EMSInventoryQuery)
                {
                    if (col.FieldName == "供应商名称")
                    {
                        col.GroupIndex = 0;
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                    else if (col.FieldName == "供应商代码")
                    {
                        col.BestFit();
                    }
                }
                else if (menu.Name == MainMenuConstants.FSMInventoryQuery)
                {
                    if (col.FieldName == "供应商名称")
                    {
                        col.GroupIndex = 0;
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                    else if (col.FieldName == "供应商代码")
                    {
                        col.BestFit();
                    }
                }
                else if (menu.Name == MainMenuConstants.AccountBookQuery)
                {
                    if (col.FieldName == "仓库")
                    {
                        col.GroupIndex = 0;
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                    }
                    else if (col.FieldName == "货号")
                    {
                        col.GroupIndex = 1;
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                    else if (col.FieldName == "品名")
                    {
                        col.BestFit();
                    }
                }
                else if ((menu.Name == MainMenuConstants.EMSGoodsTrackingDailyReport || menu.Name == MainMenuConstants.FSMGoodsTrackingDailyReport))
                {
                    if (col.FieldName == "委托厂商")
                        col.GroupIndex = 0;
                    else if (col.FieldName == "日期")
                    {
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                        col.BestFit();
                    }
                }
                else if (menu.Name == MainMenuConstants.SampleStockOutReport)
                {
                    if (col.FieldName == "客户名称")
                        col.GroupIndex = 0;
                    else if (col.FieldName == "出库单号" || col.FieldName == "出库日期" || col.FieldName == "交货日期" || col.FieldName == "仓库" || col.FieldName == "类型" ||
                        col.FieldName == "制单人" || col.FieldName == "制单日期" || col.FieldName == "审核人" || col.FieldName == "审核日期" || col.FieldName == "状态")
                        col.Visible = false;
                }
                else if (menu.Name == MainMenuConstants.StatementOfAccountToCustomer)
                {
                    if (col.FieldName == "收款单号")
                    {
                        col.GroupIndex = 0;
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                    }
                    //else if (col.FieldName == "客户代码")
                    //    col.Visible = false;
                    //else if (col.FieldName == "客户名称")
                    //    col.Visible = false;
                    else if (col.FieldName == "客户类型")
                        col.Visible = false;
                    else if (col.FieldName == "货品类型代码")
                        col.Visible = false;
                    else if (col.FieldName == "货品类型名称")
                        col.Visible = false;
                    else if (col.FieldName == "单位")
                        col.Visible = false;
                    else if (col.FieldName == "规格")
                        col.Visible = false;
                    else if (col.FieldName == "体积")
                        col.Visible = false;
                    else if (col.FieldName == "毛重")
                        col.Visible = false;
                    else if (col.FieldName == "净重")
                        col.Visible = false;
                    else if (col.FieldName == "结算类型")
                    {
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                    else if (col.FieldName == "出库日期")
                    {
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                    else if (col.FieldName == "收款日期")
                    {
                        col.BestFit();
                    }
                }
                else if (menu.Name == MainMenuConstants.StatementOfAccountToSupplier)
                {
                    if (col.FieldName == "付款单号")
                    {
                        col.GroupIndex = 0;
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                    }
                    //else if (col.FieldName == "供应商代码")
                    //    col.Visible = false;
                    //else if (col.FieldName == "供应商名称")
                        //col.Visible = false;
                    else if (col.FieldName == "货品类型代码")
                        col.Visible = false;
                    else if (col.FieldName == "货品类型名称")
                        col.Visible = false;
                    else if (col.FieldName == "结算类型")
                    {
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                    else if (col.FieldName == "结算日期")
                    {
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                    else if (col.FieldName == "付款日期")
                    {
                        col.BestFit();
                    }
                }
                //else if (menu.Name == MainMenuConstants.SalesSummaryByCustomerReport)
                //{
                //    gv.OptionsPrint.ExpandAllGroups = false;
                //    if (col.FieldName == "客户名称")
                //        col.GroupIndex = 0;
                //    else if (col.FieldName == "状态")
                //    {
                //        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                //    }
                //}
                else if (menu.Name == MainMenuConstants.SalesSummaryByGoodsPriceReport)
                {
                    gv.OptionsBehavior.AutoExpandAllGroups = true;
                    if (col.FieldName == "货号")
                        col.GroupIndex = 0;
                    else if (col.FieldName == "品名")
                    {
                        col.Width = 200;
                    }
                }
                else if (menu.Name == MainMenuConstants.GoodsSalesSummaryByCustomerReport)
                {
                    gv.OptionsPrint.ExpandAllGroups = false;
                    if (col.FieldName == "客户名称")
                    {
                        col.GroupIndex = 0;
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                    //else if (col.FieldName == "货号")
                    //{
                    //    col.GroupIndex = 1;
                    //    col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    //}
                    else if (col.FieldName == "状态")
                    {
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                }
                else if (menu.Name == MainMenuConstants.AlertQuery)
                {
                    if (col.FieldName == "标题")
                    {
                        col.GroupIndex = 0;
                    }
                }
                else if (menu.Name == MainMenuConstants.AttGeneralLog)
                {
                    if (col.FieldName == "姓名")
                        col.GroupIndex = 0;
                    //else if (col.FieldName == "工号")
                    //    col.Width = 75;
                    else if (col.FieldName == "出勤日期")
                    {
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                }
                else if (menu.Name == MainMenuConstants.AttendanceQuery)
                {
                    if (col.FieldName == "姓名")
                        col.GroupIndex = 0;
                    else if (col.FieldName == "工号")
                        col.Width = 75;
                    else if (col.FieldName == "年月")
                        col.GroupIndex = 1;
                    else if (col.FieldName == "日期")
                    {
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                }
                else if (menu.Name == MainMenuConstants.SchedulingQuery)
                {
                    if (col.FieldName == "姓名")
                        col.GroupIndex = 0;
                    else if (col.FieldName == "工号")
                        col.Width = 75;
                    else if (col.FieldName == "年月")
                        col.GroupIndex = 1;
                    else if (col.FieldName == "日期")
                    {
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                }
                if ((MainForm.Company.Contains("大正") || MainForm.Company.Contains("纸")) && (col.FieldName == "仓库类型" || col.FieldName == "客户类型"))
                    col.Visible = false;
            }
            //设置合计列
            SetSummaryItemColumns(gv);

            gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "货号", null, "(合计={0})")});
            if (menu.Name == MainMenuConstants.StatementOfAccountToCustomer)
            {
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Min, "客户名称", null, "客户名称:{0}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Min, "客户类型", null, "客户类型:"+types.Find(o => o.Type == TypesListConstants.CustomerType && o.No == Convert.ToInt32(DevExpress.Data.SummaryItemType.Min)).Name.Trim())});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Min, "出库日期", null, "开始日期:{0:d}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Max, "出库日期", null, "结束日期:{0:d}")});
            }
            else if (menu.Name == MainMenuConstants.StatementOfAccountToSupplier)
            {
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Min, "供应商名称", null, "供应商名称:{0}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Min, "结算日期", null, "开始日期:{0:d}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Max, "结算日期", null, "结束日期:{0:d}")});
            }
            else if (menu.Name == MainMenuConstants.SalesSummaryByCustomerReport)
            {

                //gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                //new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Min, "单据日期", null, "开始日期:{0:d}")});
                //gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                //new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Max, "单据日期", null, "结束日期:{0:d}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "箱数", null, "箱数:{0}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "总数量", null, "总数量:{0}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "金额", null, "金额:{0}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "已收金额", null, "已收金额:{0}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "未收金额", null, "未收金额:{0}")});
            }
            else if (menu.Name == MainMenuConstants.SalesSummaryByGoodsReport)
            {
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "箱数", null, "箱数:{0}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "总数量", null, "总数量:{0}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "金额", null, "金额:{0}")});
            }
            else if (menu.Name == MainMenuConstants.GoodsSalesSummaryByCustomerReport)
            {
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "箱数", null, "箱数:{0}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "总数量", null, "总数量:{0}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "金额", null, "金额:{0}")});
            }
            ////if (menu.ParentID != new Guid("7ea0e093-592a-420c-9a7f-8316f88c35e2"))//基础资料
            ////    gv.BestFitColumns();
        }

        public static void SetSummaryItemColumns(DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            foreach (string item in Enum.GetNames(typeof(SummaryItemColumns)))
            {
                GridColumn col = gv.Columns.FirstOrDefault(c => c.FieldName == item);
                if (col != null)
                {
                    if (col.FieldName == "品名")
                    {
                        //合计说明
                        col.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                        new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "品名", "总计:")});

                        gv.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "品名", col, "小组合计:");
                    }
                    else
                    {
                        string sumFormat = string.Empty;
                        if (item.Contains("金额") || item.Contains("工资") || item.Contains("福利") || item.Contains("扣款") || item.Contains("代扣"))
                            sumFormat = "{0:c}";
                        else
                            sumFormat = "{0}";
                        //总计
                        col.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                        new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, item, sumFormat)});
                        //组计
                        gv.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, item, col, sumFormat);
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void GetVDataSource()
        {
            threadGetVDataSource = new Thread(GetViewDataSource);
            threadGetVDataSource.Start();

            ////threadInsertAlert = new Thread(InsertAlert);
            ////threadInsertAlert.Start();
        }

        /// <summary>
        /// 状态栏信息设置
        /// </summary>
        private void SetStateBarInfo()
        {
            threadGetUserInfo = new Thread(GetUserInfo);
            threadGetUserInfo.Start();

            ////threadInsertAlert = new Thread(InsertAlert);
            ////threadInsertAlert.Start();
        }

        private void GetUserInfo()
        {
            if (usersInfo != null)
                lblUser.Caption = usersInfo.Name;
        }

        private delegate void SetErrorPanelInfoDelegate();
        /// <summary>
        /// 错误面板设置
        /// </summary>
        private void SetErrorPanelInfo()
        {
            if (this.InvokeRequired)
            {
                SetErrorPanelInfoDelegate setDelegate = new SetErrorPanelInfoDelegate(InnerSetErrorPanelInfo);
                this.Invoke(setDelegate);
            }
            else
            {
                InnerSetErrorPanelInfo();
            }

        }

        private void InnerSetErrorPanelInfo()
        {
            //错误面板设置
            // dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            this.errorInfoControl1.OnShowPanel += delegate(object sender, EventArgs e1)
            {
                if (this.InvokeRequired)
                {
                    SetErrorPanelInfoDelegate setDelegate = new SetErrorPanelInfoDelegate(InnerShowDockPanel1);
                    this.Invoke(setDelegate);
                }
                else
                {
                    InnerShowDockPanel1();
                }

            };
            this.errorInfoControl1.OnHidePanel += delegate(object sender, EventArgs e2)
            {
                if (this.InvokeRequired)
                {
                    SetErrorPanelInfoDelegate setDelegate = new SetErrorPanelInfoDelegate(InnerHideDockPanel);
                    this.Invoke(setDelegate);
                }
                else
                {
                    InnerHideDockPanel();
                }

            };
        }

        private void InnerHideDockPanel()
        {
            dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
        }

        private void InnerShowDockPanel1()
        {
            dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            dockPanel1.Show();
        }

        public ErrorInfoControl ErrorListControl
        {
            get
            {
                return this.errorInfoControl1;
            }
        }
        
        static List<Warehouse> warehouseList;

        public static List<Warehouse> WarehouseList
        {
            get
            {
                return warehouseList;
            }

            //set
            //{
            //    warehouseList = value;
            //}
        }

        public static Dictionary<String, DBML.MainMenu> mainMenuList = new Dictionary<String, DBML.MainMenu>();
        public static Dictionary<String, ItemDetailPage> itemDetailPageList = new Dictionary<String, ItemDetailPage>();
        public static Hashtable hasItemDetailPage = new Hashtable();
        void CreateLayout()
        {
            //foreach (SampleDataGroup group in dataSource.Data.Groups)
            foreach (DBML.MainMenu group in menuList.FindAll(o => o.ParentID == null))
            {
                //根据用户权限控制是否显示Tile
                ////if (MainForm.userPermissions.Count > 0 && MainForm.userPermissions.Find(o => o.Caption.Trim() == group.Caption.Trim()).CheckBoxState)
                tileContainer.Buttons.Add(new DevExpress.XtraBars.Docking2010.WindowsUIButton(group.Caption, null, -1, DevExpress.XtraBars.Docking2010.ImageLocation.AboveText, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, null, true, -1, true, null, false, false, true, null, group, -1, false, false));
                PageGroup pageGroup = new PageGroup();
                pageGroup.Parent = tileContainer;
                //pageGroup.Caption = group.Title;
                pageGroup.Caption = group.Caption;
                windowsUIView.ContentContainers.Add(pageGroup);
                List<DBML.MainMenu> dataItemList = menuList.FindAll(o => o.ID == group.ID || o.ParentID == group.ID);
                if (dataItemList != null)
                {
                    groupsItemDetailPage.Add(group, CreateGroupItemDetailPage(dataItemList, pageGroup));
                    groupsItemDetailList.Add(group.ID, pageGroup);
                }
                foreach (DBML.MainMenu item in menuList.FindAll(o => o.ParentID == group.ID))
                {
                    //ItemDetailPage itemDetailPage = new ItemDetailPage(item, pageGroup, groupsItemDetailList, menuList, itemDetailButtonList);
                    //itemDetailPage.Dock = System.Windows.Forms.DockStyle.Fill;
                    //BaseDocument document = windowsUIView.AddDocument(itemDetailPage);
                    //BaseDocument document = windowsUIView.AddDocument(item.Caption, item.Name);
                    ItemDetailPage itemDetailPage = new ItemDetailPage(item, pageGroup, menuList, itemDetailButtonList);
                    itemDetailPage.Dock = System.Windows.Forms.DockStyle.Fill;
                    itemDetailPageList.Add(item.Name, itemDetailPage);
                    mainMenuList.Add(item.Name, item);
                    BaseDocument document = windowsUIView.AddDocument(itemDetailPage);
                    document.Caption = item.Caption;
                    pageGroup.Items.Add(document as Document);
                    //////pageGroup.SetLength(document as Document, 5000);
                    CreateTile(document as Document, item).ActivationTarget = pageGroup;
                }
            }
            windowsUIView.ActivateContainer(tileContainer);
            //tileContainer.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(buttonClick);
        }
        Tile CreateTile(Document document, DBML.MainMenu item)
        {
            Tile tile = new Tile();
            tile.Document = document;
            //tile.Group = item.GroupName;
            tile.Group = menuList.Find(o => o.ID == item.ParentID).Caption;
            tile.Tag = item;
            //if (item.Name == "GoodsType")
            //根据用户权限控制是否显示Tile
            ////if (MainForm.userPermissions.Count > 0 && item.Name != MainMenuConstants.AboutBox)
            ////tile.Visible = userPermissions.Find(o => o.Caption.Trim() == item.Caption.Trim()).CheckBoxState;
            //tile.Elements.Add(CreateTileItemElement(item.Subtitle, TileItemContentAlignment.BottomLeft, Point.Empty, 9));
            //tile.Elements.Add(CreateTileItemElement(item.Subtitle, TileItemContentAlignment.Manual, new Point(0, 100), 12));
            tile.Elements.Add(CreateTileItemElement(item.Caption, TileItemContentAlignment.BottomLeft, Point.Empty, 11));
            tile.Elements.Add(CreateTileItemElement(item.Caption, TileItemContentAlignment.Manual, new Point(0, 100), 12));
            tile.Appearances.Selected.BackColor = tile.Appearances.Hovered.BackColor = tile.Appearances.Normal.BackColor = Color.FromArgb(45, 116, 169);//Color.FromArgb(140, 140, 140);//GetRandomColor(); 
            tile.Appearances.Selected.BorderColor = tile.Appearances.Hovered.BorderColor = tile.Appearances.Normal.BorderColor = Color.FromArgb(45, 116, 169);
            tile.Click += new TileClickEventHandler(tile_Click);
            windowsUIView.Tiles.Add(tile);
            tileContainer.Items.Add(tile);
            return tile;
        }

        #region 获得随机颜色
        
        public static System.Drawing.Color GetRandomColor()
        {
            Random randomNum_1 = new Random(Guid.NewGuid().GetHashCode());
            System.Threading.Thread.Sleep(randomNum_1.Next(1));
            int int_Red = randomNum_1.Next(255);

            Random randomNum_2 = new Random((int)DateTime.Now.Ticks);
            int int_Green = randomNum_2.Next(255);

            Random randomNum_3 = new Random(Guid.NewGuid().GetHashCode());

            int int_Blue = randomNum_3.Next(255);
            int_Blue = (int_Red + int_Green > 380) ? int_Red + int_Green - 380 : int_Blue;
            int_Blue = (int_Blue > 255) ? 255 : int_Blue;


            return GetDarkerColor(System.Drawing.Color.FromArgb(int_Red, int_Green, int_Blue));
        }

        //获取加深颜色
        public static Color GetDarkerColor(Color color)
        {
            const int max = 255;
            int increase = new Random(Guid.NewGuid().GetHashCode()).Next(30, 255); //还可以根据需要调整此处的值

            int r = Math.Abs(Math.Min(color.R - increase, max));
            int g = Math.Abs(Math.Min(color.G - increase, max));
            int b = Math.Abs(Math.Min(color.B - increase, max));

            return Color.FromArgb(r, g, b);
        }

        #endregion

        TileItemElement CreateTileItemElement(string text, TileItemContentAlignment alignment, Point location, float fontSize)
        {
            TileItemElement element = new TileItemElement();
            element.TextAlignment = alignment;
            if (!location.IsEmpty) element.TextLocation = location;
            element.Appearance.Normal.Options.UseFont = true;
            element.Appearance.Normal.Font = new System.Drawing.Font(new FontFamily("Segoe UI Symbol"), fontSize);
            element.Text = text;
            return element;
        }
        void tile_Click(object sender, TileClickEventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                PageGroup page = ((e.Tile as Tile).ActivationTarget as PageGroup);
                if (page != null)
                {
                    DBML.MainMenu menu = e.Tile.Tag as DBML.MainMenu;
                    foreach (DBML.MainMenu item in menuList.FindAll(o => o.ParentID == menu.ParentID))
                    {
                        if (hasItemDetailPage[item.Name] == null)
                        {
                            itemDetailPageList[item.Name].LoadBusinessData(item);
                            hasItemDetailPage.Add(item.Name, true);
                        }
                    }
                    //if (hasItemDetailPage[menu.Name] == null)
                    //{
                    //    itemDetailPageList[menu.Name].LoadBusinessData(menu);
                    //    hasItemDetailPage.Add(menu.Name, true);
                    //}
                    if (menu.Name == MainMenuConstants.AboutBox)
                    {
                        AboutBox ab = new AboutBox();
                        ab.ShowDialog();
                        e.Handled = true;
                    }
                    page.Parent = tileContainer;
                    page.SetSelected((e.Tile as Tile).Document);
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

        //PageGroup CreateGroupItemDetailPage(SampleDataGroup group, PageGroup child)
        PageGroup CreateGroupItemDetailPage(List<DBML.MainMenu> group, PageGroup child)
        {
            GroupDetailPage page = new GroupDetailPage(group, child);
            PageGroup pageGroup = page.PageGroup;
            BaseDocument document = windowsUIView.AddDocument(page);
            pageGroup.Parent = tileContainer;
            pageGroup.Items.Add(document as Document);
            windowsUIView.ContentContainers.Add(pageGroup);
            windowsUIView.ActivateContainer(pageGroup);
            return pageGroup;
        }
        void buttonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            //SampleDataGroup tileGroup = (e.Button.Properties.Tag as SampleDataGroup);
            DBML.MainMenu tileGroup = (e.Button.Properties.Tag as DBML.MainMenu);
            if (tileGroup != null)
            {
                windowsUIView.ActivateContainer(groupsItemDetailPage[tileGroup]);
            }
        }
        void clearPanel(DevExpress.XtraBars.BarStaticItem label)
        {
            ThreadStart start = new ThreadStart(
                delegate
                {
                    Thread.Sleep(3000);
                    label.Caption = string.Empty;
                    label.Glyph = null;
                }
                );

            Thread thread = new Thread(start);
            thread.Start();
        }

        public void AddButton(string text, Image image, EventHandler onClick)
        {
            
        }

        public void AddToolStripItem(System.Windows.Forms.ToolStripItem item)
        {
            
        }

        void IStatusbar.SetStatusBarPanel(string text)
        {
            this.Invoke(new EventHandler(delegate
            {
                lblTip.Caption = text;
                clearPanel(lblTip);
            }));
        }

        void IStatusbar.SetStatusBarPanel1(string text)
        {
            ((IStatusbar)this).SetStatusBarPanel(text);
        }

        class ImageText : IDisposable
        {
            public void Dispose()
            {
                if (Image != null)
                {
                    Image.Dispose();
                    Image = null;
                }
            }
            public string Text { get; set; }
            public Image Image { get; set; }
            public Exception AttachedException { get; set; }
        }

        Dictionary<object, ImageText> lifecycleStatusText = new Dictionary<object, ImageText>();

        void IStatusbar.SetStatusBarPanel(string text, Image image, Control lifecycleWith)
        {
            this.Invoke(new EventHandler(delegate
            {
                if (lifecycleStatusText.ContainsKey(lifecycleWith))
                {
                    lifecycleStatusText[lifecycleWith] = new ImageText { Image = image, Text = text };
                }
                else
                {
                    lifecycleStatusText.Add(lifecycleWith, new ImageText { Image = image, Text = text });
                }

                lifecycleWith.Disposed += delegate(object sender, EventArgs e)
                {
                    lifecycleStatusText.Remove(lifecycleWith);
                };

                this.lblTip.Caption = text;
                lblTip.Glyph = image;
            }));
        }

        void IStatusbar.SetStatusBarPanel(string text, StatusIconType iconType, Control lifecycleWith)
        {
            Image image;
            switch (iconType)
            {
                case StatusIconType.Warning:
                    image =global::USL.Properties.Resources.Warning;// global ::ICP.Framework.Client.Properties.Resources.warning;
                    break;
                case StatusIconType.Error:
                    image = global::USL.Properties.Resources.Warning;// global ::ICP.Framework.Client.Properties.Resources.warning;
                    break;
                case StatusIconType.Info:
                    image = global::USL.Properties.Resources.Info;// global ::ICP.Framework.Client.Properties.Resources.info;
                    break;
                default:
                    image = null;
                    break;
            }
            ((IStatusbar)this).SetStatusBarPanel(text, image, lifecycleWith);
        }

        void IStatusbar.SetStatusBarPanel(Exception ex, Control lifecycleWith)
        {
            Image image = global::USL.Properties.Resources.mark;// global::ICP.Framework.Client.Properties.Resources.warning;
            string text = ex.Message;
            this.Invoke(new EventHandler(delegate
            {
                if (lifecycleStatusText.ContainsKey(lifecycleWith))
                {
                    lifecycleStatusText[lifecycleWith] = new ImageText { Text = text, Image = image, AttachedException = ex };
                }
                else
                {
                    lifecycleStatusText.Add(lifecycleWith, new ImageText { Text = text, Image = image, AttachedException = ex });
                }
                lifecycleWith.Disposed += delegate(object sender, EventArgs e)
                {
                    lifecycleStatusText.Remove(lifecycleWith);
                };

                lblTip.Caption = text;
                lblTip.Glyph = image;
            }));
        }

        delegate void _addNotifyIconDelegate(string text, Image image, EventHandler click);
        public void AddNotifyIcon(string text, Image image, EventHandler click)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new _addNotifyIconDelegate(AddNotifyIcon), new object[] { text, image, click });
                return;
            }

            DevExpress.XtraBars.BarButtonItem item = new BarButtonItem();
            item.Caption = text;
            item.Glyph = image;
            item.ItemClick += delegate(object sender, ItemClickEventArgs e) { click(sender, EventArgs.Empty); };
            this.status.AddItem(item);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (authorised)
            {
                System.Windows.Forms.DialogResult result = XtraMessageBox.Show("确定要退出系统吗?", "操作提示",
                    System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
    }
}
