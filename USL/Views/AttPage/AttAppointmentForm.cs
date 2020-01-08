#region Note
/*
{**************************************************************************************************************}
{  This file is automatically created when you open the Scheduler Control smart tag                            }
{  *and click Create Customizable Appointment Dialog.                                                          }
{  It contains a a descendant of the default appointment editing form created by visual inheritance.           }
{  In Visual Studio Designer add an editor that is required to edit your appointment custom field.             }
{  Modify the LoadFormData method to get data from a custom field and fill your editor with data.              }
{  Modify the SaveFormData method to retrieve data from the editor and set the appointment custom field value. }
{  The code that displays this form is automatically inserted                                                  }
{  *in the EditAppointmentFormShowing event handler of the SchedulerControl.                                   }
{                                                                                                              }
{**************************************************************************************************************}
*/
#endregion Note

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using EDMX;
using Utility;
using DevExpress.XtraEditors.Controls;
using Utility.Interceptor;
using ClientFactory;

namespace USL
{
    public partial class AttAppointmentForm : DevExpress.XtraScheduler.UI.AppointmentForm
    {
        private static BaseFactory baseFactory = LoggerInterceptor.CreateProxy<BaseFactory>();
        int? lateMinutes;
        int? earlyMinutes;
        Guid? schClassID;
        public AttAppointmentForm()
        {
            InitializeComponent();
        }
        public AttAppointmentForm(DevExpress.XtraScheduler.SchedulerControl control, DevExpress.XtraScheduler.Appointment apt)
            : base(control, apt)
        {
            InitializeComponent();
        }
        public AttAppointmentForm(DevExpress.XtraScheduler.SchedulerControl control, DevExpress.XtraScheduler.Appointment apt, bool openRecurrenceForm)
            : base(control, apt, openRecurrenceForm)
        {
            InitializeComponent();
        }

        void GetAttStatus()
        {
            schedulerStorage1.Appointments.Labels.Clear();
            foreach (EnumHelper.ListItem<AttStatusType> item in EnumHelper.GetEnumValues<AttStatusType>(false))
            {
                if (item.Value == AttStatusType.Valid || (int)item.Value > (int)AttStatusType.NoCheckOut)
                schedulerStorage1.Appointments.Labels.Add(Color.FromName(EnumHelper.GetDescription<AttStatusType>(item.Value, true)), item.Name, item.Name);
            }
        }

        /// <summary>
        /// Add your code to obtain a custom field value and fill the editor with data.
        /// </summary>
        public override void LoadFormData(DevExpress.XtraScheduler.Appointment appointment)
        {
            base.LoadFormData(appointment);
            GetAttStatus();
            edtLabel.Properties.ReadOnly = true;
            chkAllDay.Checked = false;
            edtEndDate.EditValue = edtStartDate.EditValue;
            edtStartDate.Enabled = false;
            edtEndDate.Enabled = false;
            edtStartTime.Enabled = false;
            edtEndTime.Enabled = false;
            if (appointment.CustomFields["LateMinutes"] != null)
                lateMinutes = int.Parse(appointment.CustomFields["LateMinutes"].ToString());
            if (appointment.CustomFields["EarlyMinutes"] != null)
                earlyMinutes = int.Parse(appointment.CustomFields["EarlyMinutes"].ToString());
            if (lateMinutes != null || earlyMinutes != null)
                tbLocation.EditValue = string.Format("{0} {1}", lateMinutes, earlyMinutes);
            seLateMinutes.EditValue = lateMinutes;
            seEarlyMinutes.EditValue = earlyMinutes;
            tbSubject.EditValue = edtLabel.Text;
            SetSchTime(edtShowTimeAs.Text);
            if (appointment.CustomFields["SchClassID"] != null)
                schClassID = new Guid(appointment.CustomFields["SchClassID"].ToString());
        }
        /// <summary>
        /// Add your code to retrieve a value from the editor and set the custom appointment field.
        /// </summary>
        public override bool SaveFormData(DevExpress.XtraScheduler.Appointment appointment)
        {
            SchClass sch = baseFactory.GetModelList<SchClass>().FirstOrDefault(o => o.Name == edtShowTimeAs.Text);
            if (sch != null)
            {
                appointment.CustomFields["SchClassID"] = sch.ID;
                appointment.CustomFields["SchClassName"] = sch.Name;
            }
            return base.SaveFormData(appointment);
        }
        /// <summary>
        /// Add your code to notify that any custom field is changed. Return true if a custom field is changed, otherwise false.
        /// </summary>
        public override bool IsAppointmentChanged(DevExpress.XtraScheduler.Appointment appointment)
        {
            return false;
        }

        //protected override void edtLabel_EditValueChanged(object sender, EventArgs e)
        //{
        //    base.edtLabel_EditValueChanged(sender, e);
        //    tbSubject.EditValue = edtLabel.Text;
        //}
        //protected override void edtShowTimeAs_EditValueChanged(object sender, EventArgs e)
        //{
        //    base.edtShowTimeAs_EditValueChanged(sender, e);
        //    SetSchTime(edtShowTimeAs.Text);
        //}

        private void edtShowTimeAs_EditValueChanged(object sender, EventArgs e)
        {
            SetSchTime(edtShowTimeAs.Text);
        }

        private void edtLabel_EditValueChanged(object sender, EventArgs e)
        {
            tbSubject.EditValue = edtLabel.Text;
        }

        void SetSchTime(string schName)
        {
            SchClass sch = baseFactory.GetModelList<SchClass>().FirstOrDefault(o =>
                o.Name == schName);
            if (sch != null)
            {
                seSchStartTime.EditValue = sch.StartTime;
                seSchEndTime.EditValue = sch.EndTime;
            }
        }

        private void icboAttStatus_EditValueChanged(object sender, EventArgs e)
        {
            edtLabel.SelectedIndex = (int)EnumHelper.GetEnumValues<AttStatusType>(false).FirstOrDefault(o => o.Name == icboAttStatus.Text).Value;
        }
    }
}
