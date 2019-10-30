namespace SchedulerReportingExample
{
    partial class XtraSchedulerReport1
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.lblUserName = new DevExpress.XtraReports.UI.XRLabel();
            this.paramUserName = new DevExpress.XtraReports.Parameters.Parameter();
            this.verticalResourceHeaders1 = new DevExpress.XtraScheduler.Reporting.VerticalResourceHeaders();
            this.horizontalWeek1 = new DevExpress.XtraScheduler.Reporting.HorizontalWeek();
            this.reportMonthView1 = new DevExpress.XtraScheduler.Reporting.ReportMonthView();
            this.dayOfWeekHeaders1 = new DevExpress.XtraScheduler.Reporting.DayOfWeekHeaders();
            this.calendarControl1 = new DevExpress.XtraScheduler.Reporting.CalendarControl();
            this.timeIntervalInfo1 = new DevExpress.XtraScheduler.Reporting.TimeIntervalInfo();
            this.reportWeekView1 = new DevExpress.XtraScheduler.Reporting.ReportWeekView();
            this.reportDayView1 = new DevExpress.XtraScheduler.Reporting.ReportDayView();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.reportMonthView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportWeekView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportDayView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.lblUserName,
            this.verticalResourceHeaders1,
            this.horizontalWeek1,
            this.dayOfWeekHeaders1,
            this.calendarControl1,
            this.timeIntervalInfo1});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 1163.875F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblUserName
            // 
            this.lblUserName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.paramUserName, "Text", "")});
            this.lblUserName.Dpi = 100F;
            this.lblUserName.Font = new System.Drawing.Font("Times New Roman", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblUserName.SizeF = new System.Drawing.SizeF(358.9583F, 50F);
            this.lblUserName.StylePriority.UseFont = false;
            // 
            // paramUserName
            // 
            this.paramUserName.Description = "职工姓名：";
            this.paramUserName.Name = "paramUserName";
            // 
            // verticalResourceHeaders1
            // 
            this.verticalResourceHeaders1.Corners.Top = 24;
            this.verticalResourceHeaders1.Dpi = 100F;
            this.verticalResourceHeaders1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 150.0001F);
            this.verticalResourceHeaders1.Name = "verticalResourceHeaders1";
            this.verticalResourceHeaders1.SizeF = new System.Drawing.SizeF(25F, 649.1666F);
            this.verticalResourceHeaders1.TimeCells = this.horizontalWeek1;
            this.verticalResourceHeaders1.View = this.reportMonthView1;
            // 
            // horizontalWeek1
            // 
            this.horizontalWeek1.AppointmentDisplayOptions.StatusDisplayType = DevExpress.XtraScheduler.AppointmentStatusDisplayType.Bounds;
            this.horizontalWeek1.CompressWeekend = false;
            this.horizontalWeek1.Dpi = 100F;
            this.horizontalWeek1.LocationFloat = new DevExpress.Utils.PointFloat(24.58334F, 175F);
            this.horizontalWeek1.Name = "horizontalWeek1";
            this.horizontalWeek1.SizeF = new System.Drawing.SizeF(1035F, 601.1668F);
            this.horizontalWeek1.View = this.reportMonthView1;
            // 
            // reportMonthView1
            // 
            this.reportMonthView1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.None;
            // 
            // dayOfWeekHeaders1
            // 
            this.dayOfWeekHeaders1.Dpi = 100F;
            this.dayOfWeekHeaders1.LocationFloat = new DevExpress.Utils.PointFloat(25F, 150F);
            this.dayOfWeekHeaders1.Name = "dayOfWeekHeaders1";
            this.dayOfWeekHeaders1.SizeF = new System.Drawing.SizeF(1035F, 25F);
            this.dayOfWeekHeaders1.TimeCells = this.horizontalWeek1;
            this.dayOfWeekHeaders1.View = this.reportMonthView1;
            // 
            // calendarControl1
            // 
            this.calendarControl1.Dpi = 100F;
            this.calendarControl1.LocationFloat = new DevExpress.Utils.PointFloat(358.9583F, 0F);
            this.calendarControl1.Name = "calendarControl1";
            this.calendarControl1.SizeF = new System.Drawing.SizeF(350F, 150F);
            this.calendarControl1.TimeCells = this.horizontalWeek1;
            this.calendarControl1.View = this.reportMonthView1;
            // 
            // timeIntervalInfo1
            // 
            this.timeIntervalInfo1.Dpi = 100F;
            this.timeIntervalInfo1.FormatType = DevExpress.XtraScheduler.Reporting.TimeIntervalFormatType.Monthly;
            this.timeIntervalInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50F);
            this.timeIntervalInfo1.Name = "timeIntervalInfo1";
            this.timeIntervalInfo1.SizeF = new System.Drawing.SizeF(358.9583F, 100F);
            this.timeIntervalInfo1.TimeCells = this.horizontalWeek1;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel2.ForeColor = System.Drawing.Color.Gray;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(217.0833F, 776.1668F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(600F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseForeColor = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "软件开发公司：冰雪软件";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XtraSchedulerReport1
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(20, 20, 20, 20);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.paramUserName});
            this.Version = "16.1";
            this.Views.AddRange(new DevExpress.XtraScheduler.Reporting.ReportViewBase[] {
            this.reportMonthView1,
            this.reportWeekView1,
            this.reportDayView1});
            ((System.ComponentModel.ISupportInitialize)(this.reportMonthView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportWeekView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportDayView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraScheduler.Reporting.ReportDayView reportDayView1;
        private DevExpress.XtraScheduler.Reporting.CalendarControl calendarControl1;
        private DevExpress.XtraScheduler.Reporting.TimeIntervalInfo timeIntervalInfo1;
        private DevExpress.XtraScheduler.Reporting.VerticalResourceHeaders verticalResourceHeaders1;
        private DevExpress.XtraScheduler.Reporting.HorizontalWeek horizontalWeek1;
        private DevExpress.XtraScheduler.Reporting.ReportWeekView reportWeekView1;
        private DevExpress.XtraScheduler.Reporting.DayOfWeekHeaders dayOfWeekHeaders1;
        private DevExpress.XtraScheduler.Reporting.ReportMonthView reportMonthView1;
        private DevExpress.XtraReports.UI.XRLabel lblUserName;
        public DevExpress.XtraReports.Parameters.Parameter paramUserName;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
    }
}
