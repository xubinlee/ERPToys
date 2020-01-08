using DevExpress.XtraEditors;
using System.Collections.Generic;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010.Views;
using System.Drawing;
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
using System.Transactions;
using System.Reflection;
using Utility.Interceptor;
using EDMX;
using NLog;
using static Utility.EnumHelper;
using DevExpress.XtraEditors.Filtering;
using MainMenu = EDMX.MainMenu;
using System.Data.SqlClient;
using ClientFactory;

namespace USL
{
    public partial class MainForm : XtraForm,IToolbar,IStatusbar
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static BaseFactory baseFactory = LoggerInterceptor.CreateProxy<BaseFactory>();
        private static SystemInfoFactory systemInfoFactory = LoggerInterceptor.CreateProxy<SystemInfoFactory>();
        private static PermissionFactory permissionFactory = LoggerInterceptor.CreateProxy<PermissionFactory>();
        private static AttAppointmentsFactory attAppointmentsFactory = LoggerInterceptor.CreateProxy<AttAppointmentsFactory>();
        //Thread threadGetVDataSource;
        Thread threadGetUserInfo;
        Thread threadInsertAlert;
        public static Dictionary<String, int> alertCount;
        public static UsersInfo usersInfo;
        ////public static List<Permission> userPermissions; //功能项权限
        public static List<ButtonPermission> buttonPermissions;//按钮权限
        //PageGroup pageGroupCore;
        //SampleDataSource dataSource;
        //Dictionary<SampleDataGroup, PageGroup> groupsItemDetailPage;
        static List<MainMenu> menuList;
        Dictionary<MainMenu, PageGroup> groupsItemDetailPage;
        public static Dictionary<Guid, PageGroup> groupsItemDetailList;
        Dictionary<String, int> itemDetailButtonList; //子菜单按钮项
        //public static Dictionary<Type, object> dataSourceList;  //数据集
        //static IList list;
        public static AlertControl alertControl;
        //public static int exportSalesReceiptDate = int.Parse(ConfigurationManager.AppSettings["ExportSalesReceiptDate"]);  //外销账期
        static int goodsBigType = 0;  //Goods大类
        static string goodsBigTypeName = string.Empty;
        //static List<TypesList> types;   //类型列表
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
        //public static List<TypesList> Types
        //{
        //    get { return MainForm.types; }
        //    //set { MainForm.types = value; }
        //}

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
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                using (TransactionScope ts = new TransactionScope())
                {
                    //iSnowSoftVersion = EnumHelper.GetEnumValues<ISnowSoftVersion>(true).FirstOrDefault(o => o.Name == ConfigurationManager.AppSettings["ISnowSoftVersion"].ToString()).Value;
                    this.windowsUIView.Caption = Utility.ConfigAppSettings.GetValue("SystemName");
                    string company = Utility.ConfigAppSettings.GetValue("Company");
                    contacts = Utility.ConfigAppSettings.GetValue("Contacts"); 
                    accounts = Utility.ConfigAppSettings.GetValue("Accounts"); 
                    this.tileContainer.Properties.IndentBetweenGroups = int.Parse(Utility.ConfigAppSettings.GetValue("IndentBetweenGroups"));
                    this.tileContainer.Properties.ItemSize = int.Parse(Utility.ConfigAppSettings.GetValue("ItemSize"));
                    this.tileContainer.Properties.LargeItemWidth = int.Parse(Utility.ConfigAppSettings.GetValue("LargeItemWidth"));
                    this.tileContainer.Properties.RowCount = int.Parse(Utility.ConfigAppSettings.GetValue("RowCount"));
                    serverUrl = Utility.ConfigAppSettings.GetValue("ServerUrl"); 
                    serverUserName = Utility.ConfigAppSettings.GetValue("ServerUserName");
                    serverPassword = Security.Decrypt(Utility.ConfigAppSettings.GetValue("ServerPassword"));
                    serverDomain = Utility.ConfigAppSettings.GetValue("ServerDomain"); 

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
                        PaperSize = new Size((int)(215 / 25.4 * 100), (int)(139 / 25.4 * 100));
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
                    menuList = baseFactory.GetListByNoTracking<MainMenu>();
                    List<Permission> pList = baseFactory.GetModelList<Permission>().FindAll(o => o.UserID == usersInfo.ID);

                    //如果MainMenu有变更，更新用户权限列表
                    pList = updatePermission(pList);
                    
                    //设置权限
                    for (int i = menuList.Count - 1; i >= 0; i--)
                    {
                        if (menuList[i].ParentID == null)
                            continue;
                        Permission p = pList.FirstOrDefault(o => o.Caption.Trim() == menuList[i].Caption.Trim());
                        if (p!=null && p.CheckBoxState == false)
                        {
                            menuList.RemoveAt(i);
                            continue;
                        }
                    }
                    alertCount = new Dictionary<string, int>();
                    //groupsItemDetailPage = new Dictionary<SampleDataGroup, PageGroup>();
                    groupsItemDetailPage = new Dictionary<MainMenu, PageGroup>();
                    groupsItemDetailList = new Dictionary<Guid, PageGroup>();
                    itemDetailButtonList = new Dictionary<string, int>();
                    //dataSourceList = new Dictionary<Type, object>();
                    alertControl = new AlertControl(this.components);
                    alertControl.FormShowingEffect = AlertFormShowingEffect.SlideHorizontal;

                    SetStateBarInfo();
                    //GetDataSource();
                    //GetVDataSource();
                    //types = baseFactory.GetListByNoTracking<TypesList>();
                    warehouseList = baseFactory.GetListByNoTracking<Warehouse>();
                    ////userPermissions = baseFactory.GetModelList<Permission>().FindAll(o => o.UserID == usersInfo.ID);
                    buttonPermissions = baseFactory.GetModelList<ButtonPermission>().FindAll(o => o.UserID == usersInfo.ID);
                    attParam = baseFactory.GetListByNoTracking<AttParameters>().FirstOrDefault(o => o.CommMode == "TCP/IP");
                    sysInfo = baseFactory.GetModelList<SystemInfo>().FirstOrDefault(o => o.Company.Contains(MainForm.Company));
                    CreateLayout();
                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                string split = "\r\n------------" + DateTime.Now.ToString() + "------------\r\n";
                string exception = string.Format("\r\nException：{0}\r\nStackTrace：{1}{2}",
                    ex.Message, ex.StackTrace, split);
                Logger.Error(exception);
                //CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), ex.Message);
                XtraMessageBox.Show(ex.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

        }

        private List<Permission> updatePermission(List<Permission> pList)
        {
            List<Permission> insertList = new List<Permission>();
            menuList.ForEach(menu =>
            {
                Permission p = pList.FirstOrDefault(o => o.UserID == usersInfo.ID && o.Caption == menu.Caption);
                Permission obj = new Permission();
                if (p == null)
                    obj.CheckBoxState = false;
                else
                    obj.CheckBoxState = p.CheckBoxState;
                obj.ID = menu.SerialNo;
                string no = menu.SerialNo.ToString().Trim();
                if (menu.ParentID == null)
                    obj.ParentID = 0;
                else if (no.Length > 2)
                    obj.ParentID = int.Parse(no.Substring(0, no.Length - 2));
                obj.SerialNo = menu.SerialNo;
                obj.UserID = usersInfo.ID;
                obj.Caption = menu.Caption;
                insertList.Add(obj);
            });
            if (insertList.Count > 0)
            {
                permissionFactory.DeleteAndAdd(usersInfo.ID, insertList);
                return baseFactory.GetModelList<Permission>().FindAll(o => o.UserID == usersInfo.ID);
            }
            else
                return pList;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetErrorPanelInfo();
            //SetStateBarInfo();
            InnerHideDockPanel();
            //警告提醒
            ////List<Alert> alertList = BLLFty.Create<AlertBLL>().GetAlert();//baseFactory.GetModelList<Alert>();
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
            List<Alert> alertList = baseFactory.GetModelList<Alert>();
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
            List<OrderHd> orderList = baseFactory.GetModelList<OrderHd>();
            foreach (OrderHd order in orderList)
            {
                //Alert alert = BLLFty.Create<AlertBLL>().GetAlert().Find(o => o.BillID == order.ID);
                //if (alert != null)
                //    dellist.Add(alert);
                Company customer = baseFactory.GetModelList<Company>().FirstOrDefault(o => o.ID == order.CompanyID);
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
            List<StockOutBillHd> billList = baseFactory.GetModelList<StockOutBillHd>();
            foreach (StockOutBillHd bill in billList)
            {
                //Alert alert = BLLFty.Create<AlertBLL>().GetAlert().Find(o => o.BillID == bill.ID);
                //if (alert != null)
                //    dellist.Add(alert);
                Company customer = baseFactory.GetModelList<Company>().FirstOrDefault(o => o.ID == bill.CompanyID);
                //List<TypesList> types = baseFactory.GetData<TypesList>();
                //string billName = types.Find(o => o.Type == TypesListConstants.StockOutBillType && o.No == bill.Type).Name;
                string billName = EnumHelper.GetDescription<StockOutBillTypeEnum>((StockOutBillTypeEnum)bill.Type);
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
                    Company company = baseFactory.GetModelList<Company>().FirstOrDefault(o => o.ID == bill.CompanyID && o.Type == 1);//外销客户
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
            //if (dellist.Count > 0 || insertlist.Count > 0)
                //BLLFty.Create<AlertBLL>().Insert(dellist, insertlist);
        }

        public static void SetSelected(PageGroup pageGroupCore, MainMenu mainMenu)
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
                foreach (MainMenu mm in menuList.FindAll(o => o.ParentID == mainMenu.ParentID))
                {
                    if (hasItemDetailPage[mm.Name] == null)
                    {
                        MainMenuEnum menuEnum = (MainMenuEnum)Enum.Parse(typeof(MainMenuEnum), mm.Name);
                        itemDetailPageList[menuEnum].LoadBusinessData(mm);
                        hasItemDetailPage.Add(mm.Name, true);
                    }
                    if (mm.Name == mainMenu.Name)
                        index = i;
                    ++i;
                }
                pageGroupCore.SetSelected(pageGroupCore.Items[index]);
                view.ActivateContainer(pageGroupCore);
            }
        }

        /// <summary>
        /// 获取最大单号
        /// </summary>
        /// <param name="billType">单据类型</param>
        /// <param name="IsCreated">是否创建新单</param>
        /// <returns></returns>
        public static SystemStatus GetMaxBillNo(MainMenuEnum menuEnum, bool IsCreated)
        {
            string prefix = string.Empty;
            MainMenu menu = menuList.FirstOrDefault(o => o.Name.Equals(menuEnum.ToString()));
            if (menu != null)
                prefix = menu.Prefix;
            string no = prefix + DateTime.Now.ToString("yyyyMMdd") + "000";
            SystemStatus entity = null;
            List<SystemStatus> list = baseFactory.GetModelList<SystemStatus>();
            if (list != null)
            {
                entity = list.FirstOrDefault(o => o.MainMenuName.Equals(menuEnum.ToString()));
                if (entity != null)
                    no = entity.MaxBillNo.Trim();
            }
            if (entity == null)
            {
                entity = new SystemStatus()
                {
                    MainMenuName = menuEnum.ToString(),
                    MaxBillNo = no,
                    Status = 0
                };
            }
            if (IsCreated)
            {
                // 单号流水+1
                if (no.Length == 13)
                {
                    // 今天的单号
                    if (no.Substring(2, 8).Equals(DateTime.Now.ToString("yyyyMMdd")))
                        no = prefix + DateTime.Now.ToString("yyyyMMdd") + Convert.ToString(int.Parse(no.Substring(10, 3)) + 1).PadLeft(3, '0');
                    else
                        no = prefix + DateTime.Now.ToString("yyyyMMdd") + "001";
                    entity.MaxBillNo = no;
                }
                else
                {

                    XtraMessageBox.Show("单号格式错误。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            systemInfoFactory.AddOrUpdate(entity);
            return entity;
        }

        //public static string GetBillMaxBillNo(String billType, String prefix)
        //{
        //    string no = string.Empty;
        //    switch (billType)
        //    {
        //        case MainMenuEnum.Order:
        //            no = BLLFty.Create<OrderBLL>().GetMaxBillNo();
        //            break;
        //        case MainMenuEnum.StockInBillType:
        //            no = BLLFty.Create<StockInBillBLL>().GetMaxBillNo();
        //            break;
        //        case MainMenuEnum.StockOutBillType:
        //            no = BLLFty.Create<StockOutBillBLL>().GetMaxBillNo();
        //            break;
        //        case MainMenuEnum.ReceiptBill:
        //            no = BLLFty.Create<ReceiptBillBLL>().GetMaxBillNo();
        //            break;
        //        case MainMenuEnum.PaymentBill:
        //            no = BLLFty.Create<PaymentBillBLL>().GetMaxBillNo();
        //            break;
        //        case MainMenuEnum.WageBill:
        //            no = BLLFty.Create<WageBillBLL>().GetMaxBillNo();
        //            break;
        //        default:
        //            break;
        //    }
        //    if (string.IsNullOrEmpty(no))
        //        no = prefix + DateTime.Now.ToString("yyyyMMdd") + "001";
        //    else
        //    {
        //        if (no.Substring(2, 8).Equals(DateTime.Now.ToString("yyyyMMdd")))
        //            no = prefix + DateTime.Now.ToString("yyyyMMdd") + Convert.ToString(int.Parse(no.Substring(10, 3)) + 1).PadLeft(3, '0');
        //        else
        //            no = prefix + DateTime.Now.ToString("yyyyMMdd") + "001";
        //    }
        //    return no;
        //}

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
            List<VStaffSchClass> schList = baseFactory.GetModelList<VStaffSchClass>().FindAll(o => o.DeptID == deptID);
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
            List<AttGeneralLog> attGLogs = baseFactory.GetModelList<AttGeneralLog>();
            Hashtable hasAtt = new Hashtable();
            List<AttAppointments> aptList = baseFactory.GetModelList<AttAppointments>();
            List<AttAppointments> aptInsertList = new List<AttAppointments>();
            List<AttAppointments> aptUpdateList = new List<AttAppointments>();
            //List<VAttAppointments> vaptList = new List<VAttAppointments>();
            AttAppointments apt = null;
            VStaffSchClass vssc = null;
            foreach (AttGeneralLog log in attGLogs)
            {
                UsersInfo user = baseFactory.GetModelList<UsersInfo>().FirstOrDefault(o => o.Code == log.EnrollNumber && o.IsDel == false);
                if (user == null)
                    continue;
                if (log.SchClassID == null || log.SchClassID == Guid.Empty)
                {
                    vssc = GetStaffSchClass(log, user.DeptID);
                    if (vssc == null)
                        continue;  //排除那些无意义的打卡记录
                }
                else
                    vssc = baseFactory.GetModelList<VStaffSchClass>().FirstOrDefault(o =>
                        o.SchClassID == log.SchClassID && o.DeptID == user.DeptID);
                if (user != null && vssc != null)
                {
                    if (hasAtt[log.EnrollNumber + log.AttTime.ToString("yyyyMMdd") + vssc.Name] == null)
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
            }
            attAppointmentsFactory.AddAndUpdate(aptInsertList, aptUpdateList);
        }

        #region 注释

        //private void GetViewDataSource()
        //{
        //    //dataSourceList.Clear();
        //    //dataSourceList = null;
        //    Dictionary<Type, object> dataSources = BLLFty.Create<DataSourcesBLL>().GetVDataSources();
        //    foreach (KeyValuePair<Type, object> kvp in dataSources)
        //    {
        //        //dataSourceList.Add(kvp.Key, kvp.Value);
        //        dataSourceList[kvp.Key] = kvp.Value;
        //    }
        //}

        //static void GetNewList()
        //{
        //    dataSourceList.Add(typeof(List<VStockInBill>), new List<VStockInBill>());
        //    dataSourceList.Add(typeof(List<VStockOutBill>), new List<VStockOutBill>());
        //    dataSourceList.Add(typeof(List<VMaterialStockInBill>), new List<VMaterialStockInBill>());
        //    dataSourceList.Add(typeof(List<VMaterialStockOutBill>), new List<VMaterialStockOutBill>());
        //    dataSourceList.Add(typeof(List<StockInBillHd>), new List<StockInBillHd>());
        //    dataSourceList.Add(typeof(List<StockOutBillHd>), new List<StockOutBillHd>());
        //    dataSourceList.Add(typeof(List<OrderHd>), new List<OrderHd>());
        //    dataSourceList.Add(typeof(List<ReceiptBillHd>), new List<ReceiptBillHd>());
        //    dataSourceList.Add(typeof(List<PaymentBillHd>), new List<PaymentBillHd>());
        //    dataSourceList.Add(typeof(List<VPO>), new List<VPO>());
        //    dataSourceList.Add(typeof(List<VOrder>), new List<VOrder>());
        //    dataSourceList.Add(typeof(List<VFSMOrder>), new List<VFSMOrder>());
        //    dataSourceList.Add(typeof(List<VProductionOrder>), new List<VProductionOrder>());
        //    dataSourceList.Add(typeof(List<VInventory>), new List<VInventory>());
        //    dataSourceList.Add(typeof(List<VInventoryGroupByGoods>), new List<VInventoryGroupByGoods>());
        //    dataSourceList.Add(typeof(List<VMaterialInventory>), new List<VMaterialInventory>());
        //    dataSourceList.Add(typeof(List<VMaterialInventoryGroupByGoods>), new List<VMaterialInventoryGroupByGoods>());
        //    dataSourceList.Add(typeof(List<VEMSInventoryGroupByGoods>), new List<VEMSInventoryGroupByGoods>());
        //    dataSourceList.Add(typeof(List<VFSMInventoryGroupByGoods>), new List<VFSMInventoryGroupByGoods>());
        //    dataSourceList.Add(typeof(List<VAccountBook>), new List<VAccountBook>());
        //    dataSourceList.Add(typeof(List<VStocktaking>), new List<VStocktaking>());
        //    dataSourceList.Add(typeof(List<VProfitAndLoss>), new List<VProfitAndLoss>());
        //    dataSourceList.Add(typeof(List<SalesSummaryMonthlyReport>), new List<SalesSummaryMonthlyReport>());
        //    dataSourceList.Add(typeof(List<AnnualSalesSummaryByCustomerReport>), new List<AnnualSalesSummaryByCustomerReport>());
        //    dataSourceList.Add(typeof(List<AnnualSalesSummaryByGoodsReport>), new List<AnnualSalesSummaryByGoodsReport>());
        //    dataSourceList.Add(typeof(List<VSalesBillSummary>), new List<VSalesBillSummary>());
        //    dataSourceList.Add(typeof(List<VProductionOrderDtlForPrint>), new List<VProductionOrderDtlForPrint>());
        //    dataSourceList.Add(typeof(List<VAlert>), new List<VAlert>());
        //    dataSourceList.Add(typeof(List<Alert>), new List<Alert>());
        //    dataSourceList.Add(typeof(List<VReceiptBillDtl>), new List<VReceiptBillDtl>());
        //    dataSourceList.Add(typeof(List<VReceiptBill>), new List<VReceiptBill>());
        //    dataSourceList.Add(typeof(List<VPaymentBillDtl>), new List<VPaymentBillDtl>());
        //    dataSourceList.Add(typeof(List<VPaymentBill>), new List<VPaymentBill>());
        //    dataSourceList.Add(typeof(List<StatementOfAccountToBulkSalesReport>), new List<StatementOfAccountToBulkSalesReport>());
        //    dataSourceList.Add(typeof(List<StatementOfAccountToCustomerReport>), new List<StatementOfAccountToCustomerReport>());//.OrderBy(o => o.结算类型).OrderBy(o => o.出库日期).ToList());
        //    dataSourceList.Add(typeof(List<StatementOfAccountToSupplierReport>), new List<StatementOfAccountToSupplierReport>());//.OrderBy(o => o.结算类型).OrderBy(o => o.结算日期).ToList());
        //    dataSourceList.Add(typeof(List<VCustomerSettlement>), new List<VCustomerSettlement>());
        //    dataSourceList.Add(typeof(List<VSupplierSettlement>), new List<VSupplierSettlement>());
        //    dataSourceList.Add(typeof(List<VSampleStockOut>), new List<VSampleStockOut>());
        //    dataSourceList.Add(typeof(List<Resources>), new List<Resources>());
        //    dataSourceList.Add(typeof(List<Appointments>), new List<Appointments>());
        //    dataSourceList.Add(typeof(List<VAppointments>), new List<VAppointments>());
        //    dataSourceList.Add(typeof(List<WageDesign>), new List<WageDesign>());
        //    dataSourceList.Add(typeof(List<WageBillHd>), new List<WageBillHd>());
        //    dataSourceList.Add(typeof(List<WageBillDtl>), new List<WageBillDtl>());
        //    dataSourceList.Add(typeof(List<VWageBillDtl>), new List<VWageBillDtl>());
        //    dataSourceList.Add(typeof(List<VWageBill>), new List<VWageBill>());
        //    dataSourceList.Add(typeof(List<SalesSummaryByCustomerReport>), new List<SalesSummaryByCustomerReport>());
        //    dataSourceList.Add(typeof(List<SalesSummaryByGoodsReport>), new List<SalesSummaryByGoodsReport>());
        //    dataSourceList.Add(typeof(List<SalesSummaryByGoodsPriceReport>), new List<SalesSummaryByGoodsPriceReport>());
        //    dataSourceList.Add(typeof(List<GoodsSalesSummaryByCustomerReport>), new List<GoodsSalesSummaryByCustomerReport>());
        //    dataSourceList.Add(typeof(List<AttGeneralLog>), new List<AttGeneralLog>());
        //    dataSourceList.Add(typeof(List<VAttGeneralLog>), new List<VAttGeneralLog>());
        //    dataSourceList.Add(typeof(List<AttAppointments>), new List<AttAppointments>());
        //    dataSourceList.Add(typeof(List<VAttAppointments>), new List<VAttAppointments>());
        //    dataSourceList.Add(typeof(List<AttWageBillHd>), new List<AttWageBillHd>());
        //    dataSourceList.Add(typeof(List<AttWageBillDtl>), new List<AttWageBillDtl>());
        //    dataSourceList.Add(typeof(List<USPAttWageBillDtl>), new List<USPAttWageBillDtl>());
        //    dataSourceList.Add(typeof(List<VAttWageBill>), new List<VAttWageBill>());
        //}
        //public static void GetDataSource()
        //{
        //    dataSourceList.Clear();
        //    //dataSourceList = null;
        //    dataSourceList = BLLFty.Create<DataSourcesBLL>().GetDataSources();

        //    GetNewList();
        //}

        //public static IList GetData(String menuName)
        //{
        //    //IList list = null;
        //    switch (menuName)
        //    {
        //        case MainMenuEnum.Department:
        //            list = baseFactory.GetModelList<VDepartment>)] as IList;
        //            break;
        //        case MainMenuEnum.Company:
        //            list = baseFactory.GetModelList<VCompany>)] as IList;
        //            break;
        //        case MainMenuEnum.Supplier:
        //            list = baseFactory.GetModelList<VSupplier>)] as IList;
        //            break;
        //        case MainMenuEnum.Staff:
        //            list = baseFactory.GetModelList<VUsersInfo>)] as IList;
        //            break;
        //        case MainMenuEnum.Goods:
        //            list = baseFactory.GetModelList<VGoods>)] as IList;
        //            break;
        //        //case MainMenuEnum.Material:
        //        //    list = baseFactory.GetModelList<VMaterial>)] as IList;
        //        //    break;
        //        case MainMenuEnum.GoodsType:
        //            list = baseFactory.GetModelList<VGoodsType>)] as IList;
        //            break;
        //        case MainMenuEnum.Packaging:
        //            list = baseFactory.GetModelList<VPackaging>)] as IList;
        //            break;
        //        case MainMenuEnum.ProductionOrderQuery:
        //            list = baseFactory.GetModelList<VProductionOrder>)] as IList;
        //            break;
        //        //case MainMenuEnum.ProductionStockInBillQuery:
        //        //    list = baseFactory.GetModelList<VStockInBill>().FindAll(o => o.类型 < 2);
        //        //    break;
        //        case MainMenuEnum.ProductionStockInBillQuery:
        //            list = baseFactory.GetModelList<VStockInBill>().FindAll(o =>
        //                o.类型 == 0 || o.类型 == 1);
        //            break;
        //        case MainMenuEnum.SalesReturnBillQuery:
        //            list = baseFactory.GetModelList<VStockInBill>().FindAll(o =>
        //                o.类型 == types.Find(t => t.Type == TypesListConstants.StockInBillType && t.SubType == menuName.Replace("Query", "")).No);
        //            break;

        //        case MainMenuEnum.FGStockInBillQuery:
        //        case MainMenuEnum.EMSReturnBillQuery:
        //        case MainMenuEnum.SFGStockInBillQuery:
        //        case MainMenuEnum.FSMStockInBillQuery:
        //        case MainMenuEnum.FSMReturnBillQuery:
        //        case MainMenuEnum.AssembleStockInBillQuery:
        //            list = baseFactory.GetModelList<VMaterialStockInBill>().FindAll(o =>
        //                o.类型 == types.Find(t => t.Type == TypesListConstants.StockInBillType && t.SubType == menuName.Replace("Query", "")).No);
        //            break;
        //        case MainMenuEnum.ReturnedMaterialBillQuery:
        //            list = baseFactory.GetModelList<VMaterialStockInBill>().FindAll(o =>
        //                o.类型 == 4 || o.类型 == 7 || o.类型 == 9 || o.类型 == 10);
        //            break;
        //        case MainMenuEnum.OrderQuery:
        //            list = baseFactory.GetModelList<VOrder>)] as IList;
        //            break;
        //        case MainMenuEnum.FSMOrderQuery:
        //            list = baseFactory.GetModelList<VFSMOrder>)] as IList;
        //            break;
        //        //case MainMenuEnum.FGStockOutBillQuery:
        //        //    list = baseFactory.GetModelList<VStockOutBill>().FindAll(o => o.类型 < 2);
        //        //    break;
        //        //case MainMenuEnum.EMSStockOutBillQuery:
        //        //    list = baseFactory.GetModelList<VMaterialStockOutBill>().FindAll(o => o.类型 == 2 || o.类型 == 3);
        //        //    break;
        //        case MainMenuEnum.FGStockOutBillQuery:
        //            list = baseFactory.GetModelList<VStockOutBill>().FindAll(o =>
        //                o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == menuName.Replace("Query", "")).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
        //            break;
        //        case MainMenuEnum.EMSStockOutBillQuery:
        //            list = baseFactory.GetModelList<VMaterialStockOutBill>().FindAll(o =>
        //                o.类型 == 2 || o.类型 == 3);
        //            break;
        //        case MainMenuEnum.SFGStockOutBillQuery:
        //        case MainMenuEnum.FSMStockOutBillQuery:
        //        case MainMenuEnum.FSMDPReturnBillQuery:
        //        case MainMenuEnum.EMSDPReturnBillQuery:
        //            list = baseFactory.GetModelList<VMaterialStockOutBill>().FindAll(o =>
        //                o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == menuName.Replace("Query", "")).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
        //            break;
        //        case MainMenuEnum.GetMaterialBillQuery:
        //            list = baseFactory.GetModelList<VMaterialStockOutBill>().FindAll(o =>
        //                o.类型 == 3 || o.类型 == 5 || o.类型 == 6 || o.类型 == 9);
        //            break;
        //        case MainMenuEnum.InventoryQuery:
        //            list = baseFactory.GetModelList<VInventory>)] as IList;
        //            break;
        //        case MainMenuEnum.InventoryGroupByGoodsQuery:
        //            list = baseFactory.GetModelList<VInventoryGroupByGoods>)] as IList;
        //            break;
        //        case MainMenuEnum.MaterialInventoryQuery:
        //            list = baseFactory.GetModelList<VMaterialInventory>)] as IList;
        //            break;
        //        case MainMenuEnum.InventoryGroupByMaterialQuery:
        //            list = baseFactory.GetModelList<VMaterialInventoryGroupByGoods>)] as IList;
        //            break;
        //        case MainMenuEnum.FSMInventoryQuery:
        //            list = baseFactory.GetModelList<VFSMInventoryGroupByGoods>)] as IList;
        //            break;
        //        case MainMenuEnum.EMSInventoryQuery:
        //            list = baseFactory.GetModelList<VEMSInventoryGroupByGoods>)] as IList;
        //            break;
        //        case MainMenuEnum.AccountBookQuery:
        //            list = baseFactory.GetModelList<VAccountBook>)] as IList;
        //            break;
        //        case MainMenuEnum.Stocktaking:
        //            list = baseFactory.GetModelList<VStocktaking>)] as IList;
        //            break;
        //        case MainMenuEnum.ProfitAndLoss:
        //            list = baseFactory.GetModelList<VProfitAndLoss>)] as IList;
        //            break;
        //        case MainMenuEnum.ReceiptBillQuery:
        //            list = baseFactory.GetModelList<VReceiptBill>)] as IList;
        //            break;
        //        case MainMenuEnum.StatementOfAccountToCustomer:
        //            list = baseFactory.GetModelList<StatementOfAccountToCustomerReport>)] as IList;
        //            break;
        //        case MainMenuEnum.PaymentBillQuery:
        //            list = baseFactory.GetModelList<VPaymentBill>)] as IList;
        //            break;
        //        case MainMenuEnum.StatementOfAccountToSupplier:
        //            list = baseFactory.GetModelList<StatementOfAccountToSupplierReport>)] as IList;
        //            break;
        //        //case MainMenuEnum.EMSGoodsTrackingDailyReport:
        //        //    list = baseFactory.GetModelList<EMSGoodsTrackingDailyReport>)] as IList;
        //        //    break;
        //        //case MainMenuEnum.FSMGoodsTrackingDailyReport:
        //        //    list = baseFactory.GetModelList<FSMGoodsTrackingDailyReport>)] as IList;
        //        //    break;
        //        case MainMenuEnum.SampleStockOutReport:
        //            list = baseFactory.GetModelList<VSampleStockOut>)] as IList;
        //            break;
        //        case MainMenuEnum.SalesBillSummaryReport:
        //            list = baseFactory.GetModelList<VSalesBillSummary>)] as IList;
        //            break;
        //        case MainMenuEnum.SalesSummaryByCustomerReport:
        //            list = baseFactory.GetModelList<SalesSummaryByCustomerReport>)] as IList;
        //            break;
        //        //case MainMenuEnum.AnnualSalesSummaryByCustomerReport:
        //        //    list = baseFactory.GetModelList<AnnualSalesSummaryByCustomerReport>)] as IList;
        //        //    break;
        //        case MainMenuEnum.SalesSummaryByGoodsReport:
        //            list = baseFactory.GetModelList<SalesSummaryByGoodsReport>)] as IList;
        //            break;
        //        case MainMenuEnum.SalesSummaryByGoodsPriceReport:
        //            list = baseFactory.GetModelList<SalesSummaryByGoodsPriceReport>)] as IList;
        //            break;
        //        //case MainMenuEnum.AnnualSalesSummaryByGoodsReport:
        //        //    list = baseFactory.GetModelList<AnnualSalesSummaryByGoodsReport>)] as IList;
        //        //    break;
        //        case MainMenuEnum.GoodsSalesSummaryByCustomerReport:
        //            list = baseFactory.GetModelList<GoodsSalesSummaryByCustomerReport>)] as IList;
        //            break;
        //        case MainMenuEnum.AlertQuery:
        //            list = baseFactory.GetModelList<VAlert>)] as IList;
        //            break;
        //        case MainMenuEnum.AttGeneralLog:
        //            list = baseFactory.GetModelList<VAttGeneralLog>)] as IList;
        //            break;
        //        //case MainMenuEnum.SchClass:
        //        //    list = baseFactory.GetModelList<SchClass>)] as IList;
        //        //    break;
        //        case MainMenuEnum.SchedulingQuery:
        //            list = baseFactory.GetModelList<VAppointments>)] as IList;
        //            break;
        //        case MainMenuEnum.WageBillQuery:
        //            list = baseFactory.GetModelList<VWageBill>)] as IList;
        //            break;
        //        case MainMenuEnum.AttendanceQuery:
        //            list = baseFactory.GetModelList<VAttAppointments>)] as IList;
        //            break;
        //        case MainMenuEnum.AttWageBillQuery:
        //            list = baseFactory.GetModelList<VAttWageBill>)] as IList;
        //            break;
        //    }
        //    return list;
        //}

        //public static void GetDBData(String menuName,String filter)
        //{
        //    switch (menuName)
        //    {
        //        case MainMenuEnum.Department:
        //            baseFactory.GetModelList<Department>)] = BLLFty.Create<DepartmentBLL>().GetDepartment();
        //            baseFactory.GetModelList<VDepartment>)] = BLLFty.Create<DepartmentBLL>().GetVDepartment();
        //            break;
        //        case MainMenuEnum.Company:
        //            baseFactory.GetModelList<Company>)] = BLLFty.Create<CompanyBLL>().GetCompany();
        //            baseFactory.GetModelList<VCompany>)] = BLLFty.Create<CompanyBLL>().GetVCompany();
        //            break;
        //        case MainMenuEnum.Supplier:
        //            baseFactory.GetModelList<Supplier>)] = BLLFty.Create<SupplierBLL>().GetSupplier();
        //            baseFactory.GetModelList<VSupplier>)] = BLLFty.Create<SupplierBLL>().GetVSupplier();
        //            break;
        //        case MainMenuEnum.Staff:
        //            baseFactory.GetModelList<UsersInfo>)] = BLLFty.Create<UsersInfoBLL>().GetUsersInfo();
        //            baseFactory.GetModelList<VUsersInfo>)] = BLLFty.Create<UsersInfoBLL>().GetVUsersInfo();
        //            break;
        //        case MainMenuEnum.Goods:
        //            baseFactory.GetModelList<Goods>)] = BLLFty.Create<GoodsBLL>().GetGoods();
        //            baseFactory.GetModelList<VGoods>)] = BLLFty.Create<GoodsBLL>().GetVGoods();
        //            baseFactory.GetModelList<VParentGoodsByBOM>)] = BLLFty.Create<GoodsBLL>().GetVParentGoodsByBOM();
        //            break;
        //        case MainMenuEnum.Material:
        //            baseFactory.GetModelList<Goods>)] = BLLFty.Create<GoodsBLL>().GetGoods();
        //            baseFactory.GetModelList<VMaterial>)] = BLLFty.Create<GoodsBLL>().GetVMaterial();
        //            baseFactory.GetModelList<VGoodsByBOM>)] = BLLFty.Create<GoodsBLL>().GetVGoodsByBOM();
        //            baseFactory.GetModelList<VGoodsByMoldAllot>)] = BLLFty.Create<GoodsBLL>().GetVGoodsByMoldAllot();
        //            break;
        //        case MainMenuEnum.GoodsType:
        //            baseFactory.GetModelList<GoodsType>)] = BLLFty.Create<GoodsTypeBLL>().GetGoodsType();
        //            baseFactory.GetModelList<VGoodsType>)] = BLLFty.Create<GoodsTypeBLL>().GetVGoodsType();
        //            break;
        //        case MainMenuEnum.Packaging:
        //            baseFactory.GetModelList<Packaging>)] = BLLFty.Create<PackagingBLL>().GetPackaging();
        //            baseFactory.GetModelList<VPackaging>)] = BLLFty.Create<PackagingBLL>().GetVPackaging();
        //            break;
        //        case MainMenuEnum.BOM:
        //        case MainMenuEnum.MoldList:
        //        case MainMenuEnum.MoldMaterial:
        //        case MainMenuEnum.Assemble:
        //            baseFactory.GetModelList<BOM>)] = BLLFty.Create<BOMBLL>().GetBOM();
        //            break;
        //        case MainMenuEnum.MoldAllot:
        //            baseFactory.GetModelList<MoldAllot>)] = BLLFty.Create<MoldAllotBLL>().GetMoldAllot();
        //            break;
        //        case MainMenuEnum.CustomerSLSalePrice:
        //        case MainMenuEnum.SupplierSLSalePrice:
        //            baseFactory.GetModelList<SLSalePrice>)] = BLLFty.Create<SLSalePriceBLL>().GetSLSalePrice();
        //            break;
        //        case MainMenuEnum.PermissionSetting:
        //            baseFactory.GetModelList<Permission>)] = BLLFty.Create<PermissionBLL>().GetPermission();
        //            baseFactory.GetModelList<ButtonPermission>)] = BLLFty.Create<PermissionBLL>().GetButtonPermission();
        //            break;
        //        case MainMenuEnum.ProductionScheduling:
        //            baseFactory.GetModelList<Appointments>)] = BLLFty.Create<AppointmentsBLL>().GetAppointments();
        //            baseFactory.GetModelList<VAppointments>)] = BLLFty.Create<AppointmentsBLL>().GetVAppointments();
        //            break;
        //        case MainMenuEnum.SchClass:
        //            baseFactory.GetModelList<SchClass>)] = BLLFty.Create<SchClassBLL>().GetSchClass();
        //            break;
        //        case MainMenuEnum.StaffSchClass:
        //            baseFactory.GetModelList<StaffSchClass>)] = BLLFty.Create<StaffSchClassBLL>().GetStaffSchClass();
        //            baseFactory.GetModelList<VStaffSchClass>)] = BLLFty.Create<StaffSchClassBLL>().GetVStaffSchClass();
        //            break;
        //        case MainMenuEnum.StaffAttendance:
        //            baseFactory.GetModelList<AttAppointments>)] = BLLFty.Create<AttAppointmentsBLL>().GetAttAppointments();
        //            baseFactory.GetModelList<VAttAppointments>)] = BLLFty.Create<AttAppointmentsBLL>().GetVAttAppointments();
        //            break;

        //        case MainMenuEnum.ProductionOrderQuery:
        //            baseFactory.GetModelList<VProductionOrder>)] = BLLFty.Create<ReportBLL>().GetT<VProductionOrder>("VProductionOrder", filter).OrderByDescending(o => o.类型).OrderBy(o => o.状态).ToList();
        //            break;
        //        case MainMenuEnum.ProductionStockInBillQuery:
        //            baseFactory.GetModelList<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", filter).FindAll(o =>
        //                o.类型 == 0 || o.类型 == 1).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
        //            break;
        //        case MainMenuEnum.SalesReturnBillQuery:
        //            baseFactory.GetModelList<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", filter).FindAll(o =>
        //                o.类型 == types.Find(t => t.Type == TypesListConstants.StockInBillType && t.SubType == menuName.Replace("Query", "")).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
        //            break;
        //        case MainMenuEnum.FGStockInBillQuery:
        //        case MainMenuEnum.EMSReturnBillQuery:
        //        case MainMenuEnum.SFGStockInBillQuery:
        //        case MainMenuEnum.FSMStockInBillQuery:
        //        case MainMenuEnum.FSMReturnBillQuery:
        //        case MainMenuEnum.AssembleStockInBillQuery:
        //            baseFactory.GetModelList<VMaterialStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VMaterialStockInBill>("VMaterialStockInBill", filter).FindAll(o =>
        //                o.类型 == types.Find(t => t.Type == TypesListConstants.StockInBillType && t.SubType == menuName.Replace("Query", "")).No).OrderBy(o=>o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
        //            baseFactory.GetModelList<SLSalePrice>)] = BLLFty.Create<SLSalePriceBLL>().GetSLSalePrice();
        //            break;
        //        case MainMenuEnum.ReturnedMaterialBillQuery:
        //            baseFactory.GetModelList<VMaterialStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VMaterialStockInBill>("VMaterialStockInBill", filter).FindAll(o =>
        //                o.类型 == 4 || o.类型 == 7 || o.类型 == 9 || o.类型 == 10).OrderBy(o=>o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
        //            break;
        //        case MainMenuEnum.OrderQuery:
        //            baseFactory.GetModelList<VOrder>)] = BLLFty.Create<ReportBLL>().GetT<VOrder>("VOrder", filter).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o=>o.订货单号).ToList();
        //            baseFactory.GetModelList<SLSalePrice>)] = BLLFty.Create<SLSalePriceBLL>().GetSLSalePrice();
        //            break;
        //        case MainMenuEnum.FSMOrderQuery:
        //            baseFactory.GetModelList<VFSMOrder>)] = BLLFty.Create<ReportBLL>().GetT<VFSMOrder>("VFSMOrder", filter).OrderByDescending(o => o.类型).OrderBy(o => o.状态).ToList();
        //            break;
        //        case MainMenuEnum.FGStockOutBillQuery:
        //            baseFactory.GetModelList<VStockOutBill>)] =BLLFty.Create<ReportBLL>().GetT<VStockOutBill>("VStockOutBill", filter).FindAll(o =>
        //                o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == menuName.Replace("Query", "")).No).OrderBy(o=>o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
        //            baseFactory.GetModelList<SLSalePrice>)] = BLLFty.Create<SLSalePriceBLL>().GetSLSalePrice();
        //            break;
        //        case MainMenuEnum.EMSStockOutBillQuery:
        //            baseFactory.GetModelList<VMaterialStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VMaterialStockOutBill>("VMaterialStockOutBill", filter).FindAll(o =>
        //                o.类型 == 2 || o.类型 == 3).OrderBy(o=>o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
        //            break;
        //        case MainMenuEnum.SFGStockOutBillQuery:
        //        case MainMenuEnum.FSMStockOutBillQuery:
        //            baseFactory.GetModelList<VMaterialStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VMaterialStockOutBill>("VMaterialStockOutBill", filter).FindAll(o =>
        //                o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == menuName.Replace("Query", "")).No).OrderBy(o=>o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
        //            break;
        //        case MainMenuEnum.GetMaterialBillQuery:
        //            baseFactory.GetModelList<VMaterialStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VMaterialStockOutBill>("VMaterialStockOutBill", filter).FindAll(o =>
        //                o.类型 == 3 || o.类型 == 5 || o.类型 == 6 || o.类型 == 9).OrderBy(o=>o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
        //            break;
        //        case MainMenuEnum.ReceiptBillQuery:
        //            baseFactory.GetModelList<VReceiptBill>)] = BLLFty.Create<ReportBLL>().GetT<VReceiptBill>("VReceiptBill", filter);
        //            break;
        //        case MainMenuEnum.StatementOfAccountToCustomer:
        //            baseFactory.GetModelList<StatementOfAccountToCustomerReport>)] = BLLFty.Create<ReportBLL>().GetStatementOfAccountToCustomerReport(filter);
        //            break;
        //        case MainMenuEnum.PaymentBillQuery:
        //            baseFactory.GetModelList<VPaymentBill>)] = BLLFty.Create<ReportBLL>().GetT<VPaymentBill>("VPaymentBill", filter);
        //            break;
        //        case MainMenuEnum.StatementOfAccountToSupplier:
        //            baseFactory.GetModelList<StatementOfAccountToSupplierReport>)] = BLLFty.Create<ReportBLL>().GetStatementOfAccountToSupplierReport(filter);
        //            break;
        //        case MainMenuEnum.SampleStockOutReport:
        //            baseFactory.GetModelList<VSampleStockOut>)] = BLLFty.Create<ReportBLL>().GetT<VSampleStockOut>("VSampleStockOut", filter);
        //            break;
        //        case MainMenuEnum.SalesBillSummaryReport:
        //            baseFactory.GetModelList<VSalesBillSummary>)] = BLLFty.Create<ReportBLL>().GetT<VSalesBillSummary>("VSalesBillSummary", filter);
        //            break;
        //        case MainMenuEnum.SalesSummaryByCustomerReport:
        //            baseFactory.GetModelList<SalesSummaryByCustomerReport>)] = BLLFty.Create<ReportBLL>().GetSalesSummaryByCustomerReport(filter);
        //            break;
        //        case MainMenuEnum.SalesSummaryByGoodsReport:
        //            baseFactory.GetModelList<SalesSummaryByGoodsReport>)] = BLLFty.Create<ReportBLL>().GetSalesSummaryByGoodsReport(filter);
        //            break;
        //        case MainMenuEnum.SalesSummaryByGoodsPriceReport:
        //            baseFactory.GetModelList<SalesSummaryByGoodsPriceReport>)] = BLLFty.Create<ReportBLL>().GetSalesSummaryByGoodsPriceReport(filter);
        //            break;
        //        case MainMenuEnum.GoodsSalesSummaryByCustomerReport:
        //            baseFactory.GetModelList<GoodsSalesSummaryByCustomerReport>)] = BLLFty.Create<ReportBLL>().GetGoodsSalesSummaryByCustomerReport(filter);
        //            break;
        //        case MainMenuEnum.SchedulingQuery:
        //            baseFactory.GetModelList<VAppointments>)] = BLLFty.Create<ReportBLL>().GetT<VAppointments>("VAppointments", filter);
        //            break;
        //        case MainMenuEnum.WageBillQuery:
        //            baseFactory.GetModelList<VWageBill>)] = BLLFty.Create<ReportBLL>().GetT<VWageBill>("VWageBill", filter);
        //            break;
        //        case MainMenuEnum.AttWageBillQuery:
        //            baseFactory.GetModelList<VAttWageBill>)] = BLLFty.Create<ReportBLL>().GetT<VAttWageBill>("VAttWageBill", filter);
        //            break;
        //        case MainMenuEnum.InventoryQuery:
        //            baseFactory.GetModelList<VInventory>)] = BLLFty.Create<ReportBLL>().GetT<VInventory>("VInventory", filter);
        //            break;
        //        case MainMenuEnum.InventoryGroupByGoodsQuery:
        //            baseFactory.GetModelList<VInventoryGroupByGoods>)] = BLLFty.Create<ReportBLL>().GetT<VInventoryGroupByGoods>("VInventoryGroupByGoods", filter);
        //            break;
        //        case MainMenuEnum.MaterialInventoryQuery:
        //            baseFactory.GetModelList<VMaterialInventory>)] = BLLFty.Create<ReportBLL>().GetT<VMaterialInventory>("VMaterialInventory", filter);
        //            break;
        //        case MainMenuEnum.InventoryGroupByMaterialQuery:
        //            baseFactory.GetModelList<VMaterialInventoryGroupByGoods>)] = BLLFty.Create<ReportBLL>().GetT<VMaterialInventoryGroupByGoods>("VMaterialInventoryGroupByGoods", filter);
        //            break;
        //        case MainMenuEnum.FSMInventoryQuery:
        //            baseFactory.GetModelList<VFSMInventoryGroupByGoods>)] = BLLFty.Create<ReportBLL>().GetT<VFSMInventoryGroupByGoods>("VFSMInventoryGroupByGoods", filter);
        //            break;
        //        case MainMenuEnum.EMSInventoryQuery:
        //            baseFactory.GetModelList<VEMSInventoryGroupByGoods>)] = BLLFty.Create<ReportBLL>().GetT<VEMSInventoryGroupByGoods>("VEMSInventoryGroupByGoods", filter);
        //            break;
        //        case MainMenuEnum.AccountBookQuery:
        //            baseFactory.GetModelList<VAccountBook>)] = BLLFty.Create<ReportBLL>().GetT<VWageBill>("VAccountBook", filter);
        //            break;
        //    }
        //}

        //public static void BillSaveRefresh(String billType)
        //{
        //    //单据查询界面数据更新
        //    if (ClientFactory.itemDetailList.ContainsKey(billType))
        //    {
        //        DataQueryPage page = ClientFactory.itemDetailList[billType] as DataQueryPage;
        //        GetDBData(billType, string.Empty);
        //        if (billType==MainMenuEnum.OrderQuery)
        //        {
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.FGStockOutBillQuery))
        //            {
        //                DataQueryPage bill = ClientFactory.itemDetailList[MainMenuEnum.FGStockOutBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockOutBill>("VStockOutBill", string.Empty).FindAll(o =>
        //                    o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == MainMenuEnum.FGStockOutBill).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
        //                bill.InitGrid(MainForm.GetData(MainMenuEnum.FGStockOutBillQuery));
        //            }
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.ProductionOrderQuery))
        //            {
        //                DataQueryPage order = ClientFactory.itemDetailList[MainMenuEnum.ProductionOrderQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VProductionOrder>)] = BLLFty.Create<ReportBLL>().GetT<VProductionOrder>("VProductionOrder", string.Empty).OrderByDescending(o => o.类型).OrderBy(o => o.状态).ToList();
        //                order.InitGrid(MainForm.GetData(MainMenuEnum.ProductionOrderQuery));
        //            }
        //        }
        //        else if (billType == MainMenuEnum.ProductionOrderQuery)
        //        {
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.ProductionStockInBillQuery))
        //            {
        //                DataQueryPage bill = ClientFactory.itemDetailList[MainMenuEnum.ProductionStockInBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", string.Empty).FindAll(o =>
        //                    o.类型 == 0 || o.类型 == 1).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
        //                bill.InitGrid(MainForm.GetData(MainMenuEnum.ProductionStockInBillQuery));
        //            }
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.FGStockInBillQuery))
        //            {
        //                DataQueryPage bill = ClientFactory.itemDetailList[MainMenuEnum.FGStockInBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", string.Empty).FindAll(o =>
        //                    o.类型 == 3).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
        //                bill.InitGrid(MainForm.GetData(MainMenuEnum.FGStockInBillQuery));
        //            }
        //        }
        //        else if (billType == MainMenuEnum.FSMOrderQuery)
        //        {
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.FSMStockInBillQuery))
        //            {
        //                DataQueryPage bill = ClientFactory.itemDetailList[MainMenuEnum.FSMStockInBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VMaterialStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VMaterialStockInBill>("VMaterialStockInBill", string.Empty).FindAll(o =>
        //                    o.类型 == types.Find(t => t.Type == TypesListConstants.StockInBillType && t.SubType == MainMenuEnum.FSMStockInBill).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
        //                bill.InitGrid(MainForm.GetData(MainMenuEnum.FSMStockInBillQuery));
        //            }
        //        }
        //        else if (billType == MainMenuEnum.WageBillQuery)
        //        {
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.WageBillQuery))
        //            {
        //                DataQueryPage bill = ClientFactory.itemDetailList[MainMenuEnum.WageBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VWageBill>)] = BLLFty.Create<ReportBLL>().GetT<VWageBill>("VWageBill", string.Empty);
        //                bill.InitGrid(MainForm.GetData(MainMenuEnum.WageBillQuery));
        //            }
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.SchedulingQuery))
        //            {
        //                DataQueryPage bill = ClientFactory.itemDetailList[MainMenuEnum.SchedulingQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VAppointments>)] = BLLFty.Create<ReportBLL>().GetT<VAppointments>("VAppointments", string.Empty);
        //                bill.InitGrid(MainForm.GetData(MainMenuEnum.SchedulingQuery));
        //            }
        //        }
        //        else if (billType == MainMenuEnum.AttWageBillQuery)
        //        {
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.AttWageBillQuery))
        //            {
        //                DataQueryPage bill = ClientFactory.itemDetailList[MainMenuEnum.AttWageBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VAttWageBill>)] = BLLFty.Create<ReportBLL>().GetT<VAttWageBill>("VAttWageBill", string.Empty);
        //                bill.InitGrid(MainForm.GetData(MainMenuEnum.AttWageBillQuery));
        //            }
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.AttendanceQuery))
        //            {
        //                DataQueryPage bill = ClientFactory.itemDetailList[MainMenuEnum.AttendanceQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VAttAppointments>)] = BLLFty.Create<ReportBLL>().GetT<VAttAppointments>("VAttAppointments", string.Empty);
        //                bill.InitGrid(MainForm.GetData(MainMenuEnum.AttendanceQuery));
        //            }
        //        }
        //        else if (billType==MainMenuEnum.ReceiptBillQuery)
        //        {
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.StatementOfAccountToCustomer))
        //            {
        //                DataQueryPage billPurchase = ClientFactory.itemDetailList[MainMenuEnum.StatementOfAccountToCustomer] as DataQueryPage;
        //                baseFactory.GetModelList<StatementOfAccountToCustomerReport>)] = BLLFty.Create<ReportBLL>().GetStatementOfAccountToCustomerReport(string.Empty);
        //                billPurchase.InitGrid(MainForm.GetData(MainMenuEnum.StatementOfAccountToCustomer));
        //            }
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.ReceiptBillQuery))
        //            {
        //                DataQueryPage billPurchase = ClientFactory.itemDetailList[MainMenuEnum.ReceiptBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VReceiptBill>)] = BLLFty.Create<ReceiptBillBLL>().GetReceiptBill();
        //                billPurchase.InitGrid(MainForm.GetData(MainMenuEnum.ReceiptBillQuery));
        //            }
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.FGStockOutBillQuery))
        //            {
        //                DataQueryPage bill = ClientFactory.itemDetailList[MainMenuEnum.FGStockOutBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockOutBill>("VStockOutBill", string.Empty).FindAll(o =>
        //                    o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == MainMenuEnum.FGStockOutBill).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
        //                bill.InitGrid(MainForm.GetData(MainMenuEnum.FGStockOutBillQuery));
        //            }
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.SalesReturnBillQuery))
        //            {
        //                DataQueryPage billSalesReturn = ClientFactory.itemDetailList[MainMenuEnum.SalesReturnBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", string.Empty).FindAll(o =>
        //                    o.类型 == 0 || o.类型 == 1).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
        //                billSalesReturn.InitGrid(MainForm.GetData(MainMenuEnum.SalesReturnBillQuery));
        //            }
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.SFGStockOutBillQuery))
        //            {
        //                DataQueryPage billPurchaseReturn = ClientFactory.itemDetailList[MainMenuEnum.SFGStockOutBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockOutBill>("VStockOutBill", string.Empty).FindAll(o =>
        //                    o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == MainMenuEnum.FGStockOutBill).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
        //                billPurchaseReturn.InitGrid(MainForm.GetData(MainMenuEnum.SFGStockOutBillQuery));
        //            }
        //        }
        //        else if (billType==MainMenuEnum.PaymentBillQuery)
        //        {
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.StatementOfAccountToSupplier))
        //            {
        //                DataQueryPage billPurchase = ClientFactory.itemDetailList[MainMenuEnum.StatementOfAccountToSupplier] as DataQueryPage;
        //                baseFactory.GetModelList<StatementOfAccountToSupplierReport>)] = BLLFty.Create<ReportBLL>().GetStatementOfAccountToSupplierReport(string.Empty);
        //                billPurchase.InitGrid(MainForm.GetData(MainMenuEnum.StatementOfAccountToSupplier));
        //            }
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.PaymentBillQuery))
        //            {
        //                DataQueryPage billPurchase = ClientFactory.itemDetailList[MainMenuEnum.PaymentBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VPaymentBill>)] = BLLFty.Create<PaymentBillBLL>().GetPaymentBill();
        //                billPurchase.InitGrid(MainForm.GetData(MainMenuEnum.PaymentBillQuery));
        //            }
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.SFGStockInBillQuery))
        //            {
        //                DataQueryPage billPurchase = ClientFactory.itemDetailList[MainMenuEnum.SFGStockInBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", string.Empty).FindAll(o =>
        //                    o.类型 == 0 || o.类型 == 1).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
        //                billPurchase.InitGrid(MainForm.GetData(MainMenuEnum.SFGStockInBillQuery));
        //            }
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.SFGStockOutBillQuery))
        //            {
        //                DataQueryPage billPurchaseReturn = ClientFactory.itemDetailList[MainMenuEnum.SFGStockOutBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockOutBill>("VStockOutBill", string.Empty).FindAll(o =>
        //                    o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == MainMenuEnum.FGStockOutBill).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
        //                billPurchaseReturn.InitGrid(MainForm.GetData(MainMenuEnum.SFGStockOutBillQuery));
        //            }
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.SalesReturnBillQuery))
        //            {
        //                DataQueryPage billSalesReturn = ClientFactory.itemDetailList[MainMenuEnum.SalesReturnBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", string.Empty).FindAll(o =>
        //                    o.类型 == 0 || o.类型 == 1).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
        //                billSalesReturn.InitGrid(MainForm.GetData(MainMenuEnum.SalesReturnBillQuery));
        //            }
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.FGStockInBillQuery))
        //            {
        //                DataQueryPage billEMS = ClientFactory.itemDetailList[MainMenuEnum.FGStockInBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", string.Empty).FindAll(o =>
        //                    o.类型 == 0 || o.类型 == 1).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
        //                billEMS.InitGrid(MainForm.GetData(MainMenuEnum.FGStockInBillQuery));
        //            }
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.EMSDPReturnBillQuery))
        //            {
        //                DataQueryPage billEMSDPReturn = ClientFactory.itemDetailList[MainMenuEnum.EMSDPReturnBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockOutBill>("VStockOutBill", string.Empty).FindAll(o =>
        //                    o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == MainMenuEnum.FGStockOutBill).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
        //                billEMSDPReturn.InitGrid(MainForm.GetData(MainMenuEnum.EMSDPReturnBillQuery));
        //            }
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.FSMStockInBillQuery))
        //            {
        //                DataQueryPage billFSM = ClientFactory.itemDetailList[MainMenuEnum.FSMStockInBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VStockInBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockInBill>("VStockInBill", string.Empty).FindAll(o =>
        //                    o.类型 == 0 || o.类型 == 1).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
        //                billFSM.InitGrid(MainForm.GetData(MainMenuEnum.FSMStockInBillQuery));
        //            }
        //            if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.FSMDPReturnBillQuery))
        //            {
        //                DataQueryPage billFSMDPReturn = ClientFactory.itemDetailList[MainMenuEnum.FSMDPReturnBillQuery] as DataQueryPage;
        //                baseFactory.GetModelList<VStockOutBill>)] = BLLFty.Create<ReportBLL>().GetT<VStockOutBill>("VStockOutBill", string.Empty).FindAll(o =>
        //                    o.类型 == types.Find(t => t.Type == TypesListConstants.StockOutBillType && t.SubType == MainMenuEnum.FGStockOutBill).No).OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
        //                billFSMDPReturn.InitGrid(MainForm.GetData(MainMenuEnum.FSMDPReturnBillQuery));
        //            }
        //        }
        //        page.InitGrid(MainForm.GetData(billType));
        //    }
        //}

        //public static void InventoryRefresh()
        //{
        //    //刷新库存界面
        //    if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.InventoryQuery))
        //    {
        //        DataQueryPage page = ClientFactory.itemDetailList[MainMenuEnum.InventoryQuery] as DataQueryPage;
        //        baseFactory.GetModelList<VInventory>)] = BLLFty.Create<InventoryBLL>().GetInventory();
        //        page.InitGrid(MainForm.GetData(MainMenuEnum.InventoryQuery));
        //    }
        //    if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.InventoryGroupByGoodsQuery))
        //    {
        //        DataQueryPage page = ClientFactory.itemDetailList[MainMenuEnum.InventoryGroupByGoodsQuery] as DataQueryPage;
        //        baseFactory.GetModelList<VInventoryGroupByGoods>)] = BLLFty.Create<InventoryBLL>().GetInventoryGroupByGoods();
        //        page.InitGrid(MainForm.GetData(MainMenuEnum.InventoryGroupByGoodsQuery));
        //    }
        //    if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.MaterialInventoryQuery))
        //    {
        //        DataQueryPage page = ClientFactory.itemDetailList[MainMenuEnum.MaterialInventoryQuery] as DataQueryPage;
        //        baseFactory.GetModelList<VMaterialInventory>)] = BLLFty.Create<InventoryBLL>().GetMaterialInventory();
        //        page.InitGrid(MainForm.GetData(MainMenuEnum.MaterialInventoryQuery));
        //    }
        //    if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.InventoryGroupByMaterialQuery))
        //    {
        //        DataQueryPage page = ClientFactory.itemDetailList[MainMenuEnum.InventoryGroupByMaterialQuery] as DataQueryPage;
        //        baseFactory.GetModelList<VMaterialInventoryGroupByGoods>)] = BLLFty.Create<InventoryBLL>().GetMaterialInventoryGroupByGoods();
        //        page.InitGrid(MainForm.GetData(MainMenuEnum.InventoryGroupByMaterialQuery));
        //    }
        //    if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.FSMInventoryQuery))
        //    {
        //        DataQueryPage page = ClientFactory.itemDetailList[MainMenuEnum.FSMInventoryQuery] as DataQueryPage;
        //        baseFactory.GetModelList<VFSMInventoryGroupByGoods>)] = BLLFty.Create<InventoryBLL>().GetFSMInventoryGroupByGoods();
        //        page.InitGrid(MainForm.GetData(MainMenuEnum.FSMInventoryQuery));
        //    }
        //    if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.EMSInventoryQuery))
        //    {
        //        DataQueryPage page = ClientFactory.itemDetailList[MainMenuEnum.EMSInventoryQuery] as DataQueryPage;
        //        baseFactory.GetModelList<VEMSInventoryGroupByGoods>)] = BLLFty.Create<InventoryBLL>().GetEMSInventoryGroupByGoods();
        //        page.InitGrid(MainForm.GetData(MainMenuEnum.EMSInventoryQuery));
        //    }
        //    if (ClientFactory.itemDetailList.ContainsKey(MainMenuEnum.AccountBookQuery))
        //    {
        //        DataQueryPage page = ClientFactory.itemDetailList[MainMenuEnum.AccountBookQuery] as DataQueryPage;
        //        baseFactory.GetModelList<VAccountBook>)] = BLLFty.Create<InventoryBLL>().GetAccountBook();
        //        page.InitGrid(MainForm.GetData(MainMenuEnum.AccountBookQuery));
        //    }
        //}
        #endregion

        public static void SetQueryPageGridColumn(DevExpress.XtraGrid.Views.Grid.GridView gv, MainMenuEnum menu)
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

                if ((menu == MainMenuEnum.InventoryQuery || menu == MainMenuEnum.MaterialInventoryQuery))
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
                else if (menu == MainMenuEnum.InventoryGroupByGoodsQuery)
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
                else if (menu == MainMenuEnum.EMSInventoryQuery)
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
                else if (menu == MainMenuEnum.FSMInventoryQuery)
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
                else if (menu == MainMenuEnum.AccountBookQuery)
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
                else if ((menu == MainMenuEnum.EMSGoodsTrackingDailyReport || menu == MainMenuEnum.FSMGoodsTrackingDailyReport))
                {
                    if (col.FieldName == "委托厂商")
                        col.GroupIndex = 0;
                    else if (col.FieldName == "日期")
                    {
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                        col.BestFit();
                    }
                }
                else if (menu == MainMenuEnum.SampleStockOutReport)
                {
                    if (col.FieldName == "客户名称")
                        col.GroupIndex = 0;
                    else if (col.FieldName == "出库单号" || col.FieldName == "出库日期" || col.FieldName == "交货日期" || col.FieldName == "仓库" || col.FieldName == "类型" ||
                        col.FieldName == "制单人" || col.FieldName == "制单日期" || col.FieldName == "审核人" || col.FieldName == "审核日期" || col.FieldName == "状态")
                        col.Visible = false;
                }
                else if (menu == MainMenuEnum.StatementOfAccountToCustomer)
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
                else if (menu == MainMenuEnum.StatementOfAccountToSupplier)
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
                //else if (menu.Name == MainMenuEnum.SalesSummaryByCustomerReport)
                //{
                //    gv.OptionsPrint.ExpandAllGroups = false;
                //    if (col.FieldName == "客户名称")
                //        col.GroupIndex = 0;
                //    else if (col.FieldName == "状态")
                //    {
                //        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                //    }
                //}
                else if (menu == MainMenuEnum.SalesSummaryByGoodsPriceReport)
                {
                    gv.OptionsBehavior.AutoExpandAllGroups = true;
                    if (col.FieldName == "货号")
                        col.GroupIndex = 0;
                    else if (col.FieldName == "品名")
                    {
                        col.Width = 200;
                    }
                }
                else if (menu == MainMenuEnum.GoodsSalesSummaryByCustomerReport)
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
                else if (menu == MainMenuEnum.AlertQuery)
                {
                    if (col.FieldName == "标题")
                    {
                        col.GroupIndex = 0;
                    }
                }
                else if (menu == MainMenuEnum.AttGeneralLog)
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
                else if (menu == MainMenuEnum.AttendanceQuery)
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
                else if (menu == MainMenuEnum.SchedulingQuery)
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
            if (menu == MainMenuEnum.StatementOfAccountToCustomer)
            {
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Min, "客户名称", null, "客户名称:{0}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    //new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Min, "客户类型", null, "客户类型:"+types.Find(o => o.Type == TypesListConstants.CustomerType && o.No == Convert.ToInt32(DevExpress.Data.SummaryItemType.Min)).Name.Trim())});
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Min, "客户类型", null, "客户类型:"+EnumHelper.GetDescription<CustomerTypeEnum>((CustomerTypeEnum)DevExpress.Data.SummaryItemType.Min))});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Min, "出库日期", null, "开始日期:{0:d}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Max, "出库日期", null, "结束日期:{0:d}")});
            }
            else if (menu == MainMenuEnum.StatementOfAccountToSupplier)
            {
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Min, "供应商名称", null, "供应商名称:{0}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Min, "结算日期", null, "开始日期:{0:d}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Max, "结算日期", null, "结束日期:{0:d}")});
            }
            else if (menu == MainMenuEnum.SalesSummaryByCustomerReport)
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
            else if (menu == MainMenuEnum.SalesSummaryByGoodsReport)
            {
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "箱数", null, "箱数:{0}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "总数量", null, "总数量:{0}")});
                gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "金额", null, "金额:{0}")});
            }
            else if (menu == MainMenuEnum.GoodsSalesSummaryByCustomerReport)
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

        static void SetColumnCaption(string typeName, GridColumn col)
        {
            string enumTypeName = typeName + "Enum";
            ListItem st = EnumHelper.GetEnumValues(nameof(ClientFactory), enumTypeName, false).FirstOrDefault(o => o.Value.ToString().Equals(col.FieldName));
            if (st != null)
                col.Caption = st.Name;
            else
                col.Visible = false;
        }

        public static void SetColumnCaption(string typeName, FilterColumn col)
        {
            string enumTypeName = typeName + "Enum";
            ListItem st = EnumHelper.GetEnumValues(nameof(ClientFactory), enumTypeName, false).FirstOrDefault(o => o.Value.ToString().Equals(col.FieldName));
            if (st != null)
                col.SetColumnCaption(st.Name);
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
        //private void GetVDataSource()
        //{
        //    threadGetVDataSource = new Thread(GetViewDataSource);
        //    threadGetVDataSource.Start();

        //    ////threadInsertAlert = new Thread(InsertAlert);
        //    ////threadInsertAlert.Start();
        //}

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

        public static Dictionary<MainMenuEnum, MainMenu> mainMenuList = new Dictionary<MainMenuEnum, MainMenu>();
        public static Dictionary<MainMenuEnum, ItemDetailPage> itemDetailPageList = new Dictionary<MainMenuEnum, ItemDetailPage>();
        public static Hashtable hasItemDetailPage = new Hashtable();
        void CreateLayout()
        {
            //foreach (SampleDataGroup group in dataSource.Data.Groups)
            foreach (MainMenu group in menuList.FindAll(o => o.ParentID == null))
            {
                //根据用户权限控制是否显示Tile
                ////if (MainForm.userPermissions.Count > 0 && MainForm.userPermissions.Find(o => o.Caption.Trim() == group.Caption.Trim()).CheckBoxState)
                tileContainer.Buttons.Add(new DevExpress.XtraBars.Docking2010.WindowsUIButton(group.Caption, null, -1, DevExpress.XtraBars.Docking2010.ImageLocation.AboveText, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, null, true, -1, true, null, false, false, true, null, group, -1, false, false));
                PageGroup pageGroup = new PageGroup();
                pageGroup.Parent = tileContainer;
                //pageGroup.Caption = group.Title;
                pageGroup.Caption = group.Caption;
                windowsUIView.ContentContainers.Add(pageGroup);
                List<MainMenu> dataItemList = menuList.FindAll(o => o.ID == group.ID || o.ParentID == group.ID);
                if (dataItemList != null)
                {
                    groupsItemDetailPage.Add(group, CreateGroupItemDetailPage(dataItemList, pageGroup));
                    groupsItemDetailList.Add(group.ID, pageGroup);
                }
                foreach (MainMenu item in menuList.FindAll(o => o.ParentID == group.ID))
                {
                    //ItemDetailPage itemDetailPage = new ItemDetailPage(item, pageGroup, groupsItemDetailList, menuList, itemDetailButtonList);
                    //itemDetailPage.Dock = System.Windows.Forms.DockStyle.Fill;
                    //BaseDocument document = windowsUIView.AddDocument(itemDetailPage);
                    //BaseDocument document = windowsUIView.AddDocument(item.Caption, item.Name);

                    MainMenuEnum menuEnum = (MainMenuEnum)Enum.Parse(typeof(MainMenuEnum), item.Name);
                    ItemDetailPage itemDetailPage = new ItemDetailPage(item, pageGroup, menuList, itemDetailButtonList);
                    itemDetailPage.Dock = System.Windows.Forms.DockStyle.Fill;
                    itemDetailPageList.Add(menuEnum, itemDetailPage);
                    mainMenuList.Add(menuEnum, item);
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
        Tile CreateTile(Document document, MainMenu item)
        {
            Tile tile = new Tile();
            tile.Document = document;
            //tile.Group = item.GroupName;
            tile.Group = menuList.Find(o => o.ID == item.ParentID).Caption;
            tile.Tag = item;
            //if (item.Name == "GoodsType")
            //根据用户权限控制是否显示Tile
            ////if (MainForm.userPermissions.Count > 0 && item.Name != MainMenuEnum.AboutBox)
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
                    MainMenu menu = e.Tile.Tag as MainMenu;
                    foreach (MainMenu item in menuList.FindAll(o => o.ParentID == menu.ParentID))
                    {
                        if (hasItemDetailPage[item.Name] == null)
                        {
                            MainMenuEnum menuEnum = (MainMenuEnum)Enum.Parse(typeof(MainMenuEnum), item.Name);
                            itemDetailPageList[menuEnum].LoadBusinessData(item);
                            hasItemDetailPage.Add(item.Name, true);
                        }
                    }
                    //if (hasItemDetailPage[menu.Name] == null)
                    //{
                    //    itemDetailPageList[menu.Name].LoadBusinessData(menu);
                    //    hasItemDetailPage.Add(menu.Name, true);
                    //}
                    if (menu.Name == MainMenuEnum.AboutBox.ToString())
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
        PageGroup CreateGroupItemDetailPage(List<MainMenu> group, PageGroup child)
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
            MainMenu tileGroup = (e.Button.Properties.Tag as MainMenu);
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
