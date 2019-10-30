namespace USL
{
    partial class AttendanceSchedulingPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dpUser = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.vUsersInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.winExplorerView = new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col照片 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col姓名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col账号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col职位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col电话 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col地址 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col宿舍号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col考勤卡号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col考勤特权 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col启用考勤 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col已删除 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dpDN = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dateNavigator = new DevExpress.XtraScheduler.DateNavigator();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.attAppointmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dpAS = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.picStatus = new DevExpress.XtraEditors.PictureEdit();
            this.documentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.documentGroup1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
            this.document1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.panelContainer1.SuspendLayout();
            this.dpUser.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vUsersInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView)).BeginInit();
            this.dpDN.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attAppointmentsBindingSource)).BeginInit();
            this.dpAS.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager
            // 
            this.dockManager.Form = this;
            this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.panelContainer1,
            this.dpAS});
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar"});
            // 
            // panelContainer1
            // 
            this.panelContainer1.Controls.Add(this.dpUser);
            this.panelContainer1.Controls.Add(this.dpDN);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.panelContainer1.ID = new System.Guid("60d5f236-dd26-47ab-be90-0d3293513b2a");
            this.panelContainer1.Location = new System.Drawing.Point(0, 0);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(250, 300);
            this.panelContainer1.Size = new System.Drawing.Size(250, 480);
            this.panelContainer1.Text = "panelContainer1";
            // 
            // dpUser
            // 
            this.dpUser.Controls.Add(this.dockPanel1_Container);
            this.dpUser.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dpUser.ID = new System.Guid("fde4d5c5-7ae7-48f4-bcb7-8c3b4c543394");
            this.dpUser.Location = new System.Drawing.Point(0, 0);
            this.dpUser.Name = "dpUser";
            this.dpUser.Options.ShowCloseButton = false;
            this.dpUser.OriginalSize = new System.Drawing.Size(250, 280);
            this.dpUser.Size = new System.Drawing.Size(250, 300);
            this.dpUser.Text = "职工列表";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gridControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(242, 273);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.DataSource = this.vUsersInfoBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.winExplorerView;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(242, 273);
            this.gridControl1.TabIndex = 22;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.winExplorerView});
            // 
            // vUsersInfoBindingSource
            // 
            this.vUsersInfoBindingSource.DataSource = typeof(DBML.VUsersInfo);
            // 
            // winExplorerView
            // 
            this.winExplorerView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.col照片,
            this.col姓名,
            this.col账号,
            this.col部门,
            this.col职位,
            this.col电话,
            this.col地址,
            this.col宿舍号,
            this.col考勤卡号,
            this.col考勤特权,
            this.col启用考勤,
            this.col备注,
            this.col已删除});
            this.winExplorerView.ColumnSet.DescriptionColumn = this.col姓名;
            this.winExplorerView.ColumnSet.GroupColumn = this.col部门;
            this.winExplorerView.ColumnSet.MediumImageColumn = this.col照片;
            this.winExplorerView.ColumnSet.TextColumn = this.col账号;
            this.winExplorerView.GridControl = this.gridControl1;
            this.winExplorerView.GroupCount = 1;
            this.winExplorerView.Name = "winExplorerView";
            this.winExplorerView.OptionsBehavior.Editable = false;
            this.winExplorerView.OptionsFind.FindNullPrompt = "请输入查找内容...";
            this.winExplorerView.OptionsFind.ShowCloseButton = false;
            this.winExplorerView.OptionsFind.ShowFindButton = false;
            this.winExplorerView.OptionsView.ShowExpandCollapseButtons = true;
            this.winExplorerView.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.Tiles;
            this.winExplorerView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.winExplorerView_FocusedRowChanged);
            this.winExplorerView.RowCountChanged += new System.EventHandler(this.winExplorerView_RowCountChanged);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // col照片
            // 
            this.col照片.FieldName = "照片";
            this.col照片.Name = "col照片";
            this.col照片.Visible = true;
            this.col照片.VisibleIndex = 1;
            // 
            // col姓名
            // 
            this.col姓名.FieldName = "姓名";
            this.col姓名.Name = "col姓名";
            this.col姓名.Visible = true;
            this.col姓名.VisibleIndex = 2;
            // 
            // col账号
            // 
            this.col账号.FieldName = "账号";
            this.col账号.Name = "col账号";
            this.col账号.Visible = true;
            this.col账号.VisibleIndex = 3;
            // 
            // col部门
            // 
            this.col部门.FieldName = "部门";
            this.col部门.Name = "col部门";
            this.col部门.Visible = true;
            this.col部门.VisibleIndex = 4;
            // 
            // col职位
            // 
            this.col职位.FieldName = "职位";
            this.col职位.Name = "col职位";
            this.col职位.Visible = true;
            this.col职位.VisibleIndex = 5;
            // 
            // col电话
            // 
            this.col电话.FieldName = "电话";
            this.col电话.Name = "col电话";
            this.col电话.Visible = true;
            this.col电话.VisibleIndex = 6;
            // 
            // col地址
            // 
            this.col地址.FieldName = "地址";
            this.col地址.Name = "col地址";
            this.col地址.Visible = true;
            this.col地址.VisibleIndex = 7;
            // 
            // col宿舍号
            // 
            this.col宿舍号.FieldName = "宿舍号";
            this.col宿舍号.Name = "col宿舍号";
            this.col宿舍号.Visible = true;
            this.col宿舍号.VisibleIndex = 8;
            // 
            // col考勤卡号
            // 
            this.col考勤卡号.FieldName = "考勤卡号";
            this.col考勤卡号.Name = "col考勤卡号";
            this.col考勤卡号.Visible = true;
            this.col考勤卡号.VisibleIndex = 9;
            // 
            // col考勤特权
            // 
            this.col考勤特权.FieldName = "考勤特权";
            this.col考勤特权.Name = "col考勤特权";
            this.col考勤特权.Visible = true;
            this.col考勤特权.VisibleIndex = 10;
            // 
            // col启用考勤
            // 
            this.col启用考勤.FieldName = "启用考勤";
            this.col启用考勤.Name = "col启用考勤";
            this.col启用考勤.Visible = true;
            this.col启用考勤.VisibleIndex = 11;
            // 
            // col备注
            // 
            this.col备注.FieldName = "备注";
            this.col备注.Name = "col备注";
            this.col备注.Visible = true;
            this.col备注.VisibleIndex = 12;
            // 
            // col已删除
            // 
            this.col已删除.FieldName = "已删除";
            this.col已删除.Name = "col已删除";
            this.col已删除.Visible = true;
            this.col已删除.VisibleIndex = 13;
            // 
            // dpDN
            // 
            this.dpDN.Controls.Add(this.controlContainer1);
            this.dpDN.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dpDN.ID = new System.Guid("f774f8d9-459f-4c82-ab73-9e64020f8c97");
            this.dpDN.Location = new System.Drawing.Point(0, 300);
            this.dpDN.Name = "dpDN";
            this.dpDN.Options.ShowCloseButton = false;
            this.dpDN.OriginalSize = new System.Drawing.Size(250, 200);
            this.dpDN.Size = new System.Drawing.Size(250, 180);
            this.dpDN.Text = "日期导航";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.dateNavigator);
            this.controlContainer1.Location = new System.Drawing.Point(4, 23);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(242, 153);
            this.controlContainer1.TabIndex = 0;
            // 
            // dateNavigator
            // 
            this.dateNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateNavigator.HotDate = null;
            this.dateNavigator.Location = new System.Drawing.Point(0, 0);
            this.dateNavigator.Name = "dateNavigator";
            this.dateNavigator.CellPadding = new System.Windows.Forms.Padding(2);
            this.dateNavigator.ReadOnly = true;
            this.dateNavigator.SchedulerControl = this.schedulerControl1;
            this.dateNavigator.ShowTodayButton = false;
            this.dateNavigator.Size = new System.Drawing.Size(242, 153);
            this.dateNavigator.TabIndex = 0;
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.Location = new System.Drawing.Point(0, 0);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.Size = new System.Drawing.Size(384, 451);
            this.schedulerControl1.Start = new System.DateTime(2015, 12, 28, 0, 0, 0, 0);
            this.schedulerControl1.Storage = this.schedulerStorage;
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.MonthView.AppointmentDisplayOptions.StatusDisplayType = DevExpress.XtraScheduler.AppointmentStatusDisplayType.Bounds;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.SelectionChanged += new System.EventHandler(this.schedulerControl1_SelectionChanged);
            this.schedulerControl1.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.schedulerControl1_EditAppointmentFormShowing);
            this.schedulerControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.schedulerControl1_MouseDown);
            // 
            // schedulerStorage
            // 
            this.schedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("UserID", "UserID"));
            this.schedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("EarlyMinutes", "EarlyMinutes"));
            this.schedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("SchEndTime", "SchEndTime"));
            this.schedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("SchStartTime", "SchStartTime"));
            this.schedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("LateMinutes", "LateMinutes"));
            this.schedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("GLogEndID", "GLogEndID"));
            this.schedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("GLogStartID", "GLogStartID"));
            this.schedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("SchClassID", "SchClassID"));
            this.schedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("WageStatus", "WageStatus"));
            this.schedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("SchClassName", "SchClassName"));
            this.schedulerStorage.Appointments.DataSource = this.attAppointmentsBindingSource;
            this.schedulerStorage.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel("无"));
            this.schedulerStorage.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(190))))), "1号机"));
            this.schedulerStorage.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(213)))), ((int)(((byte)(255))))), "2号机"));
            this.schedulerStorage.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(244)))), ((int)(((byte)(156))))), "3号机"));
            this.schedulerStorage.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(228)))), ((int)(((byte)(199))))), "4号机"));
            this.schedulerStorage.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(206)))), ((int)(((byte)(147))))), "5号机"));
            this.schedulerStorage.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(244)))), ((int)(((byte)(255))))), "6号机"));
            this.schedulerStorage.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(152))))), "7号机"));
            this.schedulerStorage.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(207)))), ((int)(((byte)(233))))), "8号机"));
            this.schedulerStorage.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(233)))), ((int)(((byte)(223))))), "9号机"));
            this.schedulerStorage.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(165))))), "10号机"));
            this.schedulerStorage.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.SkyBlue, "两台机"));
            this.schedulerStorage.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStorage.Appointments.Mappings.AppointmentId = "UniqueID";
            this.schedulerStorage.Appointments.Mappings.Description = "Description";
            this.schedulerStorage.Appointments.Mappings.End = "CheckOutTime";
            this.schedulerStorage.Appointments.Mappings.Label = "AttStatus";
            this.schedulerStorage.Appointments.Mappings.Location = "Location";
            this.schedulerStorage.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            this.schedulerStorage.Appointments.Mappings.ReminderInfo = "ReminderInfo";
            this.schedulerStorage.Appointments.Mappings.ResourceId = "ResourceID";
            this.schedulerStorage.Appointments.Mappings.Start = "CheckInTime";
            this.schedulerStorage.Appointments.Mappings.Status = "SchSerialNo";
            this.schedulerStorage.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage.Appointments.Mappings.Type = "Type";
            this.schedulerStorage.AppointmentsInserted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage_AppointmentsInserted);
            this.schedulerStorage.AppointmentsChanged += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage_AppointmentsChanged);
            this.schedulerStorage.AppointmentDeleting += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.schedulerStorage_AppointmentDeleting);
            this.schedulerStorage.AppointmentsDeleted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage_AppointmentsDeleted);
            // 
            // attAppointmentsBindingSource
            // 
            this.attAppointmentsBindingSource.DataSource = typeof(DBML.AttAppointments);
            // 
            // dpAS
            // 
            this.dpAS.Controls.Add(this.dockPanel2_Container);
            this.dpAS.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dpAS.DockedAsTabbedDocument = true;
            this.dpAS.FloatLocation = new System.Drawing.Point(272, 531);
            this.dpAS.FloatVertical = true;
            this.dpAS.ID = new System.Guid("599518cb-584c-4130-ae32-4e3ae94f2bf7");
            this.dpAS.Location = new System.Drawing.Point(0, 0);
            this.dpAS.Name = "dpAS";
            this.dpAS.Options.ShowCloseButton = false;
            this.dpAS.OriginalSize = new System.Drawing.Size(300, 300);
            this.dpAS.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpAS.SavedIndex = 1;
            this.dpAS.Size = new System.Drawing.Size(384, 451);
            this.dpAS.Text = "考勤排程";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.picStatus);
            this.dockPanel2_Container.Controls.Add(this.schedulerControl1);
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(384, 451);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // picStatus
            // 
            this.picStatus.EditValue = global::USL.Properties.Resources.Closed;
            this.picStatus.Location = new System.Drawing.Point(3, 3);
            this.picStatus.Name = "picStatus";
            this.picStatus.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picStatus.Properties.Appearance.Options.UseBackColor = true;
            this.picStatus.Size = new System.Drawing.Size(95, 37);
            this.picStatus.TabIndex = 25;
            this.picStatus.Visible = false;
            // 
            // documentManager
            // 
            this.documentManager.ContainerControl = this;
            this.documentManager.View = this.tabbedView1;
            this.documentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // tabbedView1
            // 
            this.tabbedView1.DocumentGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup[] {
            this.documentGroup1});
            this.tabbedView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.document1});
            this.tabbedView1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tabbedView1.WindowsDialogProperties.NameColumnWidth = 5;
            this.tabbedView1.WindowsDialogProperties.PathColumnWidth = 5;
            this.tabbedView1.WindowsDialogProperties.Size = new System.Drawing.Size(465, 321);
            // 
            // documentGroup1
            // 
            this.documentGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.document1});
            // 
            // document1
            // 
            this.document1.Caption = "考勤排程";
            this.document1.FloatLocation = new System.Drawing.Point(272, 531);
            this.document1.FloatSize = new System.Drawing.Size(200, 200);
            this.document1.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            this.document1.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // AttendanceSchedulingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContainer1);
            this.Name = "AttendanceSchedulingPage";
            this.Size = new System.Drawing.Size(640, 480);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.panelContainer1.ResumeLayout(false);
            this.dpUser.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vUsersInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView)).EndInit();
            this.dpDN.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attAppointmentsBindingSource)).EndInit();
            this.dpAS.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel dpUser;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dpAS;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView winExplorerView;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraBars.Docking.DockPanel dpDN;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage;
        private DevExpress.XtraEditors.PictureEdit picStatus;
        private System.Windows.Forms.BindingSource attAppointmentsBindingSource;
        private System.Windows.Forms.BindingSource vUsersInfoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn col照片;
        private DevExpress.XtraGrid.Columns.GridColumn col姓名;
        private DevExpress.XtraGrid.Columns.GridColumn col账号;
        private DevExpress.XtraGrid.Columns.GridColumn col部门;
        private DevExpress.XtraGrid.Columns.GridColumn col职位;
        private DevExpress.XtraGrid.Columns.GridColumn col电话;
        private DevExpress.XtraGrid.Columns.GridColumn col地址;
        private DevExpress.XtraGrid.Columns.GridColumn col宿舍号;
        private DevExpress.XtraGrid.Columns.GridColumn col考勤卡号;
        private DevExpress.XtraGrid.Columns.GridColumn col考勤特权;
        private DevExpress.XtraGrid.Columns.GridColumn col启用考勤;
        private DevExpress.XtraGrid.Columns.GridColumn col备注;
        private DevExpress.XtraGrid.Columns.GridColumn col已删除;

    }
}
