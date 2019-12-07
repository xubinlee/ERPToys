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
using DevExpress.XtraScheduler;
using SchedulerReportingExample;
using DevExpress.XtraScheduler.Reporting;
using DevExpress.XtraReports.UI;
using Utility.Interceptor;

namespace USL
{
    public partial class AttendanceSchedulingPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail
    {
        private static ClientFactory clientFactory = LoggerInterceptor.CreateProxy<ClientFactory>();
        Guid focusedID;
        Guid focusedDeptID;
        //bool addNew = false;  //是否新增
        public AttendanceSchedulingPage()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            winExplorerView.ShowFindPanel();
            BindData(null);
            dateNavigator.DateTime = DateTime.Now;
            schedulerControl1.ActiveViewType = SchedulerViewType.Month;
        }

        public void BindData(object obj)
        {
            schedulerStorage.BeginUpdate();
            vUsersInfoBindingSource.DataSource = ((List<VUsersInfo>)MainForm.dataSourceList[typeof(List<VUsersInfo>)]).FindAll(o =>
               o.已删除==false && o.部门 != "注塑机");
            GetStatus();
            GetLabels();
            GetASDataSource();
            schedulerStorage.RefreshData();
            schedulerStorage.EndUpdate();
        }

        void GetStatus()
        {
            //List<SchClass> schList = MainForm.dataSourceList[typeof(List<SchClass>)] as List<SchClass>;
            List<VStaffSchClass> schList = ((List<VStaffSchClass>)MainForm.dataSourceList[typeof(List<VStaffSchClass>)]).FindAll(o =>
                o.DeptID == focusedDeptID).OrderBy(o => o.SchSerialNo).ToList();
            schedulerStorage.Appointments.Statuses.Clear();
            foreach (VStaffSchClass sch in schList)
            {
                schedulerStorage.Appointments.Statuses.Add(Color.FromArgb(sch.Color.GetValueOrDefault()), sch.Name, sch.Name);
            }
        }

        void GetLabels()
        {
            schedulerStorage.Appointments.Labels.Clear();
            foreach (EnumHelper.ListItem<AttStatusType> item in EnumHelper.GetEnumValues<AttStatusType>(false))
            {
                //if (item.Value == AttStatusType.Valid || (int)item.Value > (int)AttStatusType.NoCheckOut)
                    schedulerStorage.Appointments.Labels.Add(Color.FromName(EnumHelper.GetDescription<AttStatusType>(item.Value, true)), item.Name, item.Name);                
            }
        }

        private void winExplorerView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetASDataSource();
        }

        private void winExplorerView_RowCountChanged(object sender, EventArgs e)
        {
            GetASDataSource();
        }
        
        void GetASDataSource()
        {
            if (winExplorerView.GetFocusedRowCellValue(colID) != null)
            {
                focusedID = new Guid(winExplorerView.GetFocusedRowCellValue(colID).ToString());
                focusedDeptID = GetDeptID(focusedID);
                attAppointmentsBindingSource.DataSource = ((List<AttAppointments>)MainForm.dataSourceList[typeof(List<AttAppointments>)]).FindAll(o => o.UserID == focusedID);
                GetStatus();
                picStatus.Visible = false;
                //DataView dv = erpToysDataSet.Appointments.DefaultView;
                //dv.RowFilter = string.Format("UserID='{0}'", focusedID);
                //appointmentsBindingSource.DataSource = dv.ToTable();
            }
        }

        Guid GetDeptID(Guid? userID)
        {
            return ((List<UsersInfo>)MainForm.dataSourceList[typeof(List<UsersInfo>)]).FirstOrDefault(o =>
                o.ID == userID).DeptID.GetValueOrDefault();
        }
        public void Add()
        {
            //bOMBindingSource.DataSource = goodsBOMList = new List<BOM>();
            //gridView.AddNewRow();
            //addNew = true;
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
            throw new NotImplementedException();
        }

        public bool Audit()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            #region #showreport
            XtraSchedulerReport1 xr = new XtraSchedulerReport1();
            SchedulerControlPrintAdapter scPrintAdapter =
                new SchedulerControlPrintAdapter(this.schedulerControl1);
            xr.SchedulerAdapter = scPrintAdapter;
            xr.CreateDocument(true);
            xr.paramUserName.Value = ((List<UsersInfo>)MainForm.dataSourceList[typeof(List<UsersInfo>)]).FirstOrDefault(o =>
                o.ID == focusedID).Name;
            //xr.paramAMT.Value = ((List<VAppointments>)MainForm.dataSourceList[typeof(List<VAppointments>)]).FindAll(o =>
            //    o.UserID == focusedID && o.日期.Value.Month == dateNavigator.DateTime.Month).Sum(o => o.当班金额);

            using (ReportPrintTool printTool = new ReportPrintTool(xr))
            {
                printTool.ShowRibbonPreviewDialog();
            }
            #endregion #showreport
        }

        List<AttAppointments> GetAttAppointmentsList(IList list)
        {
            List<AttAppointments> aptList = new List<AttAppointments>();
            foreach (Appointment apt in list)
            {
                AttAppointments dbApt = (AttAppointments)apt.GetSourceObject(this.schedulerStorage);
                if (dbApt == null || dbApt.UserID == null || dbApt.UserID == Guid.Empty)
                    continue;
                VStaffSchClass vssc = ((List<VStaffSchClass>)MainForm.dataSourceList[typeof(List<VStaffSchClass>)]).FirstOrDefault(o =>
                    o.SchClassID == dbApt.SchClassID && o.DeptID ==  GetDeptID(dbApt.UserID));
                if (dbApt.AttStatus < (int)AttStatusType.Absent)
                {
                    int late = (int)(dbApt.CheckInTime.Value.TimeOfDay - vssc.StartTime.Value.TimeOfDay).TotalMinutes;
                    if (late > vssc.LateMinutes)
                        dbApt.LateMinutes = late;
                    else
                        dbApt.LateMinutes = null;
                    int early = (int)(vssc.EndTime.Value.TimeOfDay - dbApt.CheckOutTime.Value.TimeOfDay).TotalMinutes;
                    if (early > vssc.EarlyMinutes)
                        dbApt.EarlyMinutes = early;
                    else
                        dbApt.EarlyMinutes = null;
                    if ((dbApt.LateMinutes != null && dbApt.LateMinutes > 0) || (dbApt.EarlyMinutes != null && dbApt.EarlyMinutes > 0))
                        dbApt.Location = string.Format("{0} {1}", dbApt.LateMinutes, dbApt.EarlyMinutes);
                    dbApt.AttStatus = SetAttStaus(dbApt.CheckInTime, dbApt.CheckOutTime, late, early);
                }
                else
                {
                    dbApt.LateMinutes = null;
                    dbApt.EarlyMinutes = null;
                    dbApt.Location = string.Empty;
                }
                dbApt.Subject = EnumHelper.GetDescription<AttStatusType>((AttStatusType)dbApt.AttStatus, false);
                aptList.Add(dbApt);
            }
            return aptList;
        }

        //List<AttGeneralLog> GetAppointmentsList(IList list)
        //{
        //    List<AttGeneralLog> logList = new List<AttGeneralLog>();
        //    foreach (Appointment apt in list)
        //    {
        //        AttAppointments dbApt = (AttAppointments)apt.GetSourceObject(this.schedulerStorage);
        //        if (dbApt == null || dbApt.UserID == null || dbApt.UserID == Guid.Empty)
        //            continue;
        //        UsersInfo user = ((List<UsersInfo>)MainForm.dataSourceList[typeof(List<UsersInfo>)]).FirstOrDefault(o => o.ID == dbApt.UserID);
        //        AttGeneralLog dbLogStart = ((List<AttGeneralLog>)MainForm.dataSourceList[typeof(List<AttGeneralLog>)]).FirstOrDefault(o => o.ID == dbApt.GLogStartID);
        //        if (dbLogStart != null)
        //        {
        //            dbLogStart.AttFlag = true;
        //            dbLogStart.EnrollNumber = user == null ? string.Empty : user.Code;
        //            dbLogStart.AttTime = dbApt.CheckInTime.GetValueOrDefault();
        //            dbLogStart.AttStatus = dbApt.AttStatus;
        //            dbLogStart.Description = dbApt.Description;
        //            logList.Add(dbLogStart);
        //        }
        //        AttGeneralLog dbLogEnd = ((List<AttGeneralLog>)MainForm.dataSourceList[typeof(List<AttGeneralLog>)]).FirstOrDefault(o => o.ID == dbApt.GLogEndID);
        //        if (dbLogEnd != null)
        //        {
        //            dbLogEnd.AttFlag = false;
        //            dbLogEnd.EnrollNumber = user == null ? string.Empty : user.Code;
        //            dbLogEnd.AttTime = dbApt.CheckOutTime.GetValueOrDefault();
        //            dbLogEnd.AttStatus = dbApt.AttStatus;
        //            dbLogEnd.Description = dbApt.Description;
        //            logList.Add(dbLogEnd);
        //        }
        //    }
        //    return logList;
        //}

        private void schedulerStorage_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            BLLFty.Create<AttAppointmentsBLL>().Update(GetAttAppointmentsList(e.Objects));
            //刷新数据
            clientFactory.UpdateCache<AttAppointments>();
            clientFactory.DataPageRefresh<VAttAppointments>();
        }

        private void schedulerStorage_AppointmentsInserted(object sender, PersistentObjectsEventArgs e)
        {
            //List<AttGeneralLog> logList = new List<AttGeneralLog>();
            List<AttAppointments> attAptList = new List<AttAppointments>();
            foreach (Appointment apt in e.Objects)
            {
                AttAppointments dbApt = (AttAppointments)apt.GetSourceObject(this.schedulerStorage);
                if (dbApt == null || dbApt.UserID == null || dbApt.UserID == Guid.Empty)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "添加失败，请刷新数据后重试。");
                    break;
                }
                //UsersInfo user = ((List<UsersInfo>)MainForm.dataSourceList[typeof(List<UsersInfo>)]).FirstOrDefault(o => o.ID == dbApt.UserID);
                //AttGeneralLog dbLogStart = new AttGeneralLog();
                //dbLogStart.ID = Guid.NewGuid();
                //dbLogStart.AttFlag = true;
                //dbLogStart.EnrollNumber = user == null ? string.Empty : user.Code;
                //dbLogStart.AttTime = dbApt.CheckInTime.GetValueOrDefault();
                //dbLogStart.AttStatus = dbApt.AttStatus;
                //dbLogStart.Description = dbApt.Description;
                //dbLogStart.SchClassID = dbApt.SchClassID;
                //logList.Add(dbLogStart);
                //AttGeneralLog dbLogEnd = new AttGeneralLog();
                //dbLogEnd.ID = Guid.NewGuid();
                //dbLogEnd.AttFlag = false;
                //dbLogEnd.EnrollNumber = user == null ? string.Empty : user.Code;
                //dbLogEnd.AttTime = dbApt.CheckOutTime.GetValueOrDefault();
                //dbLogEnd.AttStatus = dbApt.AttStatus;
                //dbLogEnd.Description = dbApt.Description;
                //dbLogEnd.SchClassID = dbApt.SchClassID;
                //logList.Add(dbLogEnd);
                VStaffSchClass vssc=((List<VStaffSchClass>)MainForm.dataSourceList[typeof(List<VStaffSchClass>)]).FirstOrDefault(o =>
                    o.SchClassID == dbApt.SchClassID && o.DeptID == GetDeptID(dbApt.UserID));
                AttAppointments attApt = new AttAppointments();
                attApt.GLogStartID = Guid.NewGuid();
                attApt.GLogEndID = Guid.NewGuid();
                attApt.UserID = dbApt.UserID;
                attApt.SchClassID = dbApt.SchClassID;
                attApt.SchClassName = dbApt.SchClassName;
                attApt.SchSerialNo = vssc.SchSerialNo;
                attApt.SchStartTime = vssc.StartTime;
                attApt.SchEndTime = vssc.EndTime;
                attApt.CheckInTime = dbApt.CheckInTime.Value.Date;
                attApt.CheckOutTime = dbApt.CheckInTime.Value.Date;
                attApt.AttStatus = dbApt.AttStatus;
                if (attApt.AttStatus == (int)AttStatusType.Valid)
                {
                    attApt.CheckInTime += attApt.SchStartTime.Value.TimeOfDay;
                    attApt.CheckOutTime += attApt.SchEndTime.Value.TimeOfDay;
                }
                //if (attApt.AttStatus < (int)AttStatusType.Absent)
                //{
                //    int late = (int)(attApt.CheckInTime.Value.TimeOfDay - vssc.StartTime.Value.TimeOfDay).TotalMinutes;
                //    if (late > vssc.LateMinutes)
                //        attApt.LateMinutes = late;
                //    int early = (int)(vssc.EndTime.Value.TimeOfDay - attApt.CheckOutTime.Value.TimeOfDay).TotalMinutes;
                //    if (early > vssc.EarlyMinutes)
                //        attApt.EarlyMinutes = early;
                //    if ((dbApt.LateMinutes != null && dbApt.LateMinutes > 0) || (dbApt.EarlyMinutes != null && dbApt.EarlyMinutes > 0))
                //        dbApt.Location = string.Format("{0} {1}", dbApt.LateMinutes, dbApt.EarlyMinutes);
                //    attApt.AttStatus = SetAttStaus(attApt.CheckInTime, attApt.CheckOutTime, late, early);
                //}
                attApt.Subject = EnumHelper.GetDescription<AttStatusType>((AttStatusType)attApt.AttStatus, false);
                attApt.Description = dbApt.Description;
                attApt.WageStatus = 0;
                attAptList.Add(attApt);
                break;
            }
            BLLFty.Create<AttAppointmentsBLL>().Insert(attAptList);
            //BLLFty.Create<AttGeneralLogBLL>().Insert(logList);
            //刷新数据
            clientFactory.UpdateCache<AttAppointments>();
            clientFactory.DataPageRefresh<VAttAppointments>();
        }

        int SetAttStaus( DateTime? checkinTime, DateTime? checkOutTime,int late, int early)
        {
            int attStaus = 0;
            if (late>0)
                attStaus = (int)AttStatusType.Late;
            if (early > 0)
                attStaus = (int)AttStatusType.Early;
            if (late > 0 && early > 0)
                attStaus = (int)AttStatusType.LateEarly;
            if (checkinTime == null)
                attStaus = (int)AttStatusType.NoCheckIn;
            if (checkOutTime == null)
                attStaus = (int)AttStatusType.NoCheckOut;
            if (checkinTime == null && checkinTime == null)
                attStaus = (int)AttStatusType.Absent;
            return attStaus;
        }

        private void schedulerStorage_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            //foreach (Appointment apt in e.Objects)
            //{
            //    //if (apt.Id == null)
            //    //{
            //    //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "删除失败。");
            //    //    break;
            //    //}
            //    AttAppointments dbApt = (AttAppointments)apt.GetSourceObject(this.schedulerStorage);
            //    if (dbApt == null || dbApt.UserID == null || dbApt.UserID == Guid.Empty)
            //    {
            //        CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "删除失败，请刷新数据后重试。");
            //        break;
            //    }
            //    //List<AttGeneralLog> dbLogs = ((List<AttGeneralLog>)MainForm.dataSourceList[typeof(List<AttGeneralLog>)]).FindAll(o =>
            //    //    o.ID == dbApt.GLogStartID || o.ID == dbApt.GLogEndID);
            //    BLLFty.Create<AttGeneralLogBLL>().Delete(dbApt);
            //}
            foreach (Appointment apt in e.Objects)
            {
                if (apt.Id == null)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "删除失败。");
                    break;
                }
                BLLFty.Create<AttAppointmentsBLL>().Delete((Int64)apt.Id);
            }
            //刷新数据
            clientFactory.UpdateCache<AttAppointments>();
            clientFactory.DataPageRefresh<VAttAppointments>();
        }

        private void schedulerStorage_AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e)
        {
            //Appointment apt = e.Object as Appointment;
            //if (apt == null)
            //{
            //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "删除失败。");
            //    return;
            //}
            //AttAppointments dbApt = (AttAppointments)apt.GetSourceObject(this.schedulerStorage);
            //if (dbApt == null || dbApt.UserID == null || dbApt.UserID == Guid.Empty)
            //{
            //    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "删除失败，请刷新数据后重试。");
            //    return;
            //}
            //BLLFty.Create<AttGeneralLogBLL>().Delete(dbApt);
            ////刷新数据
            //PageRefresh();
        }
        private void schedulerControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)  //防止点右键拖放日程
                schedulerControl1.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.None;
            else
                schedulerControl1.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.All;
        }

        private void schedulerControl1_SelectionChanged(object sender, EventArgs e)
        {
            VAttWageBill wage = ((List<VAttWageBill>)MainForm.dataSourceList[typeof(List<VAttWageBill>)]).FirstOrDefault(o => o.UserID==focusedID &&
                o.年月 == Convert.ToString(((SchedulerControl)sender).SelectedInterval.Start.Year + "-" + ((SchedulerControl)sender).SelectedInterval.Start.Month.ToString().PadLeft(2,'0')));
            if (wage != null && wage.状态 == (int)BillStatus.Audited)
            {
                schedulerControl1.OptionsCustomization.AllowAppointmentConflicts = AppointmentConflictsMode.Forbidden;
                schedulerControl1.OptionsCustomization.AllowAppointmentCopy = UsedAppointmentType.None;
                schedulerControl1.OptionsCustomization.AllowAppointmentCreate = UsedAppointmentType.None;
                schedulerControl1.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.None;
                schedulerControl1.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.None;
                schedulerControl1.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.None;
                picStatus.Visible = true;
            }
            else
            {
                schedulerControl1.OptionsCustomization.AllowAppointmentConflicts = AppointmentConflictsMode.Allowed;
                schedulerControl1.OptionsCustomization.AllowAppointmentCopy = UsedAppointmentType.All;
                schedulerControl1.OptionsCustomization.AllowAppointmentCreate = UsedAppointmentType.All;
                schedulerControl1.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.All;
                schedulerControl1.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.All;
                schedulerControl1.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.All;
                picStatus.Visible = false;
            }
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            DevExpress.XtraScheduler.SchedulerControl scheduler = ((DevExpress.XtraScheduler.SchedulerControl)(sender));
            //传值
            if (focusedID == null || focusedID == Guid.Empty)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "请先选择职工。");
                return;
            }
            e.Appointment.CustomFields["UserID"] = focusedID;
            USL.AttAppointmentForm form = new USL.AttAppointmentForm(scheduler, e.Appointment, e.OpenRecurrenceForm);
            try
            {
                e.DialogResult = form.ShowDialog();
                e.Handled = true;
            }
            finally
            {
                form.Dispose();
            }
        }

    }
}
