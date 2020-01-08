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
using DevExpress.XtraGrid.Views.WinExplorer;
using DevExpress.XtraScheduler;
using SchedulerReportingExample;
using DevExpress.XtraScheduler.Reporting;
using DevExpress.XtraReports.UI;
using Utility.Interceptor;
using ClientFactory;

namespace USL
{
    public partial class ProductionSchedulingPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail
    {
        private static BaseFactory baseFactory = LoggerInterceptor.CreateProxy<BaseFactory>();
        Guid focusedID;
        //bool addNew = false;  //是否新增
        public ProductionSchedulingPage()
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
            vUsersInfoBindingSource.DataSource = baseFactory.GetModelList<VUsersInfo>().FindAll(o =>
                o.已删除 == false && o.部门 == "注塑机");
            GetPSDataSource();
            schedulerStorage.RefreshData();
            schedulerStorage.EndUpdate();
        }

        private void winExplorerView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetPSDataSource();
        }

        private void winExplorerView_RowCountChanged(object sender, EventArgs e)
        {
            GetPSDataSource();
        }
        
        void GetPSDataSource()
        {
            if (winExplorerView.GetFocusedRowCellValue(colID) != null)
            {
                focusedID = new Guid(winExplorerView.GetFocusedRowCellValue(colID).ToString());
                appointmentsBindingSource.DataSource = baseFactory.GetModelList<Appointments>().FindAll(o => o.UserID == focusedID);
                picStatus.Visible = false;
                //DataView dv = erpToysDataSet.Appointments.DefaultView;
                //dv.RowFilter = string.Format("UserID='{0}'", focusedID);
                //appointmentsBindingSource.DataSource = dv.ToTable();
            }
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
            xr.paramUserName.Value = baseFactory.GetModelList<UsersInfo>().FirstOrDefault(o =>
                o.ID == focusedID).Name;
            //xr.paramAMT.Value = ((List<VAppointments>)baseFactory.GetModelList<VAppointments>().FindAll(o =>
            //    o.UserID == focusedID && o.日期.Value.Month == dateNavigator.DateTime.Month).Sum(o => o.当班金额);

            using (ReportPrintTool printTool = new ReportPrintTool(xr))
            {
                printTool.ShowRibbonPreviewDialog();
            }
            #endregion #showreport
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
            USL.CustomAppointmentForm form = new USL.CustomAppointmentForm(scheduler, e.Appointment, e.OpenRecurrenceForm);
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

        List<Appointments> GetAppointmentsList(IList list)
        {
            List<Appointments> aptList = new List<Appointments>();
            foreach (Appointment apt in list)
            {
                Appointments dbApt = (Appointments)apt.GetSourceObject(this.schedulerStorage);
                if (dbApt == null || dbApt.UserID == null || dbApt.UserID == Guid.Empty)
                    continue;
                aptList.Add(dbApt);
            }
            return aptList;
        }

        private void schedulerStorage_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            baseFactory.ModifyByList<Appointments>(GetAppointmentsList(e.Objects));
            //刷新数据
            baseFactory.DataPageRefresh<Appointments>();
            baseFactory.DataPageRefresh<VAppointments>();
        }

        private void schedulerStorage_AppointmentsInserted(object sender, PersistentObjectsEventArgs e)
        {
            foreach (Appointment apt in e.Objects)
            {
                Appointments dbApt = (Appointments)apt.GetSourceObject(this.schedulerStorage);
                if (dbApt == null || dbApt.UserID == null || dbApt.UserID == Guid.Empty)
                {
                    CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "添加失败，请刷新数据后重试。");
                    break;
                }
                baseFactory.Add<Appointments>(dbApt);
                break;
            }
            //刷新数据
            baseFactory.DataPageRefresh<Appointments>();
            baseFactory.DataPageRefresh<VAppointments>();
        }

        private void schedulerStorage_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            //foreach (Appointment apt in e.Objects)
            //{
            //    if (apt.Id == null)
            //    {
            //        CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), "删除失败。");
            //        break;
            //    }
            //    BLLFty.Create<AppointmentsBLL>().Delete((Int64)apt.Id);
            //}
            baseFactory.DelByBulk<Appointments>(GetAppointmentsList(e.Objects));
            //刷新数据
            baseFactory.DataPageRefresh<Appointments>();
            baseFactory.DataPageRefresh<VAppointments>();
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
            VWageBill wage= baseFactory.GetModelList<VWageBill>().FirstOrDefault(o =>o.UserID==focusedID &&
                o.年月 == Convert.ToString(((SchedulerControl)sender).SelectedInterval.Start.Year + "-" + ((SchedulerControl)sender).SelectedInterval.Start.Month.ToString().PadLeft(2,'0')));
            //if (((SchedulerControl)sender).SelectedAppointments.Count > 0 &&
            //    Convert.ToInt32(((SchedulerControl)sender).SelectedAppointments[0].CustomFields["WageStatus"]) == (int)WageStatus.Closed)
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

    }
}
