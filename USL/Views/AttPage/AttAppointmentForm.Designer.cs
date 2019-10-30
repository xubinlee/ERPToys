namespace USL
{
    partial class AttAppointmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttAppointmentForm));
            this.seSchStartTime = new DevExpress.XtraEditors.TimeEdit();
            this.seSchEndTime = new DevExpress.XtraEditors.TimeEdit();
            this.lblLateMinutes = new DevExpress.XtraEditors.LabelControl();
            this.lblEarlyMinutes = new DevExpress.XtraEditors.LabelControl();
            this.seLateMinutes = new DevExpress.XtraEditors.SpinEdit();
            this.seEarlyMinutes = new DevExpress.XtraEditors.SpinEdit();
            this.lblDescription = new DevExpress.XtraEditors.LabelControl();
            this.lblAttStatus = new DevExpress.XtraEditors.LabelControl();
            this.icboAttStatus = new DevExpress.XtraScheduler.UI.AppointmentLabelEdit();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chkAllDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShowTimeAs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResources.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResources.ResourcesCheckedListBoxControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReminder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbReminder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            this.progressPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seSchStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seSchEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLateMinutes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seEarlyMinutes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icboAttStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSubject
            // 
            this.lblSubject.Visible = false;
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(409, 20);
            this.lblLocation.Visible = false;
            // 
            // lblLabel
            // 
            this.lblLabel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblLabel.Location = new System.Drawing.Point(14, 6);
            this.lblLabel.Size = new System.Drawing.Size(52, 14);
            this.lblLabel.Text = "考勤状态:";
            // 
            // lblStartTime
            // 
            this.lblStartTime.Size = new System.Drawing.Size(52, 14);
            this.lblStartTime.Text = "签到时间:";
            // 
            // lblEndTime
            // 
            this.lblEndTime.Size = new System.Drawing.Size(52, 14);
            this.lblEndTime.Text = "签退时间:";
            // 
            // lblShowTimeAs
            // 
            this.lblShowTimeAs.Size = new System.Drawing.Size(52, 14);
            this.lblShowTimeAs.Text = "班次时段:";
            // 
            // chkAllDay
            // 
            // 
            // btnRecurrence
            // 
            this.btnRecurrence.Visible = false;
            // 
            // edtStartDate
            // 
            this.edtStartDate.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.edtStartDate.EnterMoveNextControl = true;
            // 
            // edtEndDate
            // 
            this.edtEndDate.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.edtEndDate.EnterMoveNextControl = true;
            // 
            // edtStartTime
            // 
            this.edtStartTime.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.edtStartTime.EnterMoveNextControl = true;
            // 
            // edtEndTime
            // 
            this.edtEndTime.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.edtEndTime.EnterMoveNextControl = true;
            // 
            // edtLabel
            // 
            this.edtLabel.EnterMoveNextControl = true;
            this.edtLabel.Location = new System.Drawing.Point(116, 3);
            this.edtLabel.Size = new System.Drawing.Size(101, 20);
            this.edtLabel.EditValueChanged += new System.EventHandler(this.edtLabel_EditValueChanged);
            // 
            // edtShowTimeAs
            // 
            this.edtShowTimeAs.EnterMoveNextControl = true;
            this.edtShowTimeAs.EditValueChanged += new System.EventHandler(this.edtShowTimeAs_EditValueChanged);
            // 
            // tbSubject
            // 
            this.tbSubject.EnterMoveNextControl = true;
            this.tbSubject.Size = new System.Drawing.Size(252, 20);
            this.tbSubject.Visible = false;
            // 
            // edtResource
            // 
            this.edtResource.Size = new System.Drawing.Size(131, 20);
            this.edtResource.Storage = this.schedulerStorage1;
            // 
            // edtResources
            // 
            // 
            // 
            // 
            this.edtResources.ResourcesCheckedListBoxControl.CheckOnClick = true;
            this.edtResources.ResourcesCheckedListBoxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtResources.ResourcesCheckedListBoxControl.Location = new System.Drawing.Point(0, 0);
            this.edtResources.ResourcesCheckedListBoxControl.Name = "";
            this.edtResources.ResourcesCheckedListBoxControl.Size = new System.Drawing.Size(200, 100);
            this.edtResources.ResourcesCheckedListBoxControl.TabIndex = 0;
            // 
            // chkReminder
            // 
            // 
            // tbDescription
            // 
            this.tbDescription.EnterMoveNextControl = true;
            this.tbDescription.Location = new System.Drawing.Point(50, 217);
            this.tbDescription.Size = new System.Drawing.Size(548, 149);
            // 
            // cbReminder
            // 
            // 
            // tbLocation
            // 
            this.tbLocation.EnterMoveNextControl = true;
            this.tbLocation.Location = new System.Drawing.Point(502, 17);
            this.tbLocation.Size = new System.Drawing.Size(96, 20);
            this.tbLocation.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(381, 46);
            this.panel1.Size = new System.Drawing.Size(223, 32);
            // 
            // tbProgress
            // 
            this.tbProgress.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.tbProgress.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            // 
            // lblPercentComplete
            // 
            this.lblPercentComplete.Appearance.BackColor = System.Drawing.Color.Transparent;
            // 
            // lblPercentCompleteValue
            // 
            this.lblPercentCompleteValue.Appearance.BackColor = System.Drawing.Color.Transparent;
            // 
            // seSchStartTime
            // 
            this.seSchStartTime.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.seSchStartTime.Location = new System.Drawing.Point(381, 151);
            this.seSchStartTime.Name = "seSchStartTime";
            this.seSchStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seSchStartTime.Properties.ReadOnly = true;
            this.seSchStartTime.Size = new System.Drawing.Size(100, 20);
            this.seSchStartTime.TabIndex = 29;
            // 
            // seSchEndTime
            // 
            this.seSchEndTime.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.seSchEndTime.Location = new System.Drawing.Point(497, 150);
            this.seSchEndTime.Name = "seSchEndTime";
            this.seSchEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seSchEndTime.Properties.ReadOnly = true;
            this.seSchEndTime.Size = new System.Drawing.Size(100, 20);
            this.seSchEndTime.TabIndex = 30;
            // 
            // lblLateMinutes
            // 
            this.lblLateMinutes.Location = new System.Drawing.Point(395, 87);
            this.lblLateMinutes.Name = "lblLateMinutes";
            this.lblLateMinutes.Size = new System.Drawing.Size(86, 14);
            this.lblLateMinutes.TabIndex = 31;
            this.lblLateMinutes.Text = "迟到时间(分钟):";
            // 
            // lblEarlyMinutes
            // 
            this.lblEarlyMinutes.Location = new System.Drawing.Point(395, 114);
            this.lblEarlyMinutes.Name = "lblEarlyMinutes";
            this.lblEarlyMinutes.Size = new System.Drawing.Size(86, 14);
            this.lblEarlyMinutes.TabIndex = 32;
            this.lblEarlyMinutes.Text = "早退时间(分钟):";
            // 
            // seLateMinutes
            // 
            this.seLateMinutes.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seLateMinutes.Location = new System.Drawing.Point(497, 84);
            this.seLateMinutes.Name = "seLateMinutes";
            this.seLateMinutes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seLateMinutes.Properties.ReadOnly = true;
            this.seLateMinutes.Size = new System.Drawing.Size(100, 20);
            this.seLateMinutes.TabIndex = 33;
            // 
            // seEarlyMinutes
            // 
            this.seEarlyMinutes.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seEarlyMinutes.Location = new System.Drawing.Point(497, 111);
            this.seEarlyMinutes.Name = "seEarlyMinutes";
            this.seEarlyMinutes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seEarlyMinutes.Properties.ReadOnly = true;
            this.seEarlyMinutes.Size = new System.Drawing.Size(100, 20);
            this.seEarlyMinutes.TabIndex = 34;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(16, 217);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(28, 14);
            this.lblDescription.TabIndex = 35;
            this.lblDescription.Text = "备注:";
            // 
            // lblAttStatus
            // 
            this.lblAttStatus.Location = new System.Drawing.Point(19, 52);
            this.lblAttStatus.Name = "lblAttStatus";
            this.lblAttStatus.Size = new System.Drawing.Size(52, 14);
            this.lblAttStatus.TabIndex = 37;
            this.lblAttStatus.Text = "状态设置:";
            // 
            // icboAttStatus
            // 
            this.icboAttStatus.EnterMoveNextControl = true;
            this.icboAttStatus.Location = new System.Drawing.Point(112, 49);
            this.icboAttStatus.Name = "icboAttStatus";
            this.icboAttStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icboAttStatus.Size = new System.Drawing.Size(252, 20);
            this.icboAttStatus.Storage = this.schedulerStorage1;
            this.icboAttStatus.TabIndex = 36;
            this.icboAttStatus.EditValueChanged += new System.EventHandler(this.icboAttStatus_EditValueChanged);
            // 
            // AttAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(616, 411);
            this.Controls.Add(this.lblAttStatus);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.seEarlyMinutes);
            this.Controls.Add(this.seLateMinutes);
            this.Controls.Add(this.lblEarlyMinutes);
            this.Controls.Add(this.lblLateMinutes);
            this.Controls.Add(this.seSchEndTime);
            this.Controls.Add(this.seSchStartTime);
            this.Controls.Add(this.icboAttStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(602, 328);
            this.Name = "AttAppointmentForm";
            this.Controls.SetChildIndex(this.icboAttStatus, 0);
            this.Controls.SetChildIndex(this.seSchStartTime, 0);
            this.Controls.SetChildIndex(this.edtShowTimeAs, 0);
            this.Controls.SetChildIndex(this.edtEndTime, 0);
            this.Controls.SetChildIndex(this.edtEndDate, 0);
            this.Controls.SetChildIndex(this.btnRecurrence, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblShowTimeAs, 0);
            this.Controls.SetChildIndex(this.lblEndTime, 0);
            this.Controls.SetChildIndex(this.tbLocation, 0);
            this.Controls.SetChildIndex(this.lblSubject, 0);
            this.Controls.SetChildIndex(this.lblLocation, 0);
            this.Controls.SetChildIndex(this.tbSubject, 0);
            this.Controls.SetChildIndex(this.lblStartTime, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.edtStartDate, 0);
            this.Controls.SetChildIndex(this.edtStartTime, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.progressPanel, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.seSchEndTime, 0);
            this.Controls.SetChildIndex(this.lblLateMinutes, 0);
            this.Controls.SetChildIndex(this.lblEarlyMinutes, 0);
            this.Controls.SetChildIndex(this.seLateMinutes, 0);
            this.Controls.SetChildIndex(this.seEarlyMinutes, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.Controls.SetChildIndex(this.lblAttStatus, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chkAllDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShowTimeAs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResources.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResources.ResourcesCheckedListBoxControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReminder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbReminder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.progressPanel.ResumeLayout(false);
            this.progressPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seSchStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seSchEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLateMinutes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seEarlyMinutes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icboAttStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TimeEdit seSchStartTime;
        private DevExpress.XtraEditors.TimeEdit seSchEndTime;
        private DevExpress.XtraEditors.LabelControl lblLateMinutes;
        private DevExpress.XtraEditors.LabelControl lblEarlyMinutes;
        private DevExpress.XtraEditors.SpinEdit seLateMinutes;
        private DevExpress.XtraEditors.SpinEdit seEarlyMinutes;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        private DevExpress.XtraEditors.LabelControl lblAttStatus;
        private DevExpress.XtraScheduler.UI.AppointmentLabelEdit icboAttStatus;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
    }
}
