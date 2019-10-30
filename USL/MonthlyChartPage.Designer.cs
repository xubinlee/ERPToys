namespace USL
{
    partial class MonthlyChartPage
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
            DevExpress.XtraCharts.XYDiagram3D xyDiagram3D1 = new DevExpress.XtraCharts.XYDiagram3D();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBar3DSeriesView sideBySideBar3DSeriesView1 = new DevExpress.XtraCharts.SideBySideBar3DSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBar3DSeriesView sideBySideBar3DSeriesView2 = new DevExpress.XtraCharts.SideBySideBar3DSeriesView();
            DevExpress.XtraCharts.SideBySideBar3DSeriesView sideBySideBar3DSeriesView3 = new DevExpress.XtraCharts.SideBySideBar3DSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager();
            this.dpYearMonth = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.clbYearMonth = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.btnUnCheckAll = new DevExpress.XtraEditors.SimpleButton();
            this.dpChart = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.icbo3DModle = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnRestoreDefaultAngles = new DevExpress.XtraEditors.SimpleButton();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.documentManager = new DevExpress.XtraBars.Docking2010.DocumentManager();
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView();
            this.documentGroup1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup();
            this.document2 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document();
            this.document1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.dpYearMonth.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clbYearMonth)).BeginInit();
            this.dpChart.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icbo3DModle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3D1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBar3DSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBar3DSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBar3DSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager
            // 
            this.dockManager.Form = this;
            this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpYearMonth,
            this.dpChart});
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
            // dpYearMonth
            // 
            this.dpYearMonth.Controls.Add(this.controlContainer1);
            this.dpYearMonth.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpYearMonth.ID = new System.Guid("24cbd62b-eb90-4a2d-a919-1a95131dced3");
            this.dpYearMonth.Location = new System.Drawing.Point(0, 0);
            this.dpYearMonth.Name = "dpYearMonth";
            this.dpYearMonth.Options.ShowCloseButton = false;
            this.dpYearMonth.OriginalSize = new System.Drawing.Size(250, 300);
            this.dpYearMonth.Size = new System.Drawing.Size(250, 480);
            this.dpYearMonth.Text = "月份列表";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.clbYearMonth);
            this.controlContainer1.Controls.Add(this.btnUnCheckAll);
            this.controlContainer1.Location = new System.Drawing.Point(4, 23);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(242, 453);
            this.controlContainer1.TabIndex = 0;
            // 
            // clbYearMonth
            // 
            this.clbYearMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbYearMonth.Location = new System.Drawing.Point(0, 23);
            this.clbYearMonth.Name = "clbYearMonth";
            this.clbYearMonth.Size = new System.Drawing.Size(242, 430);
            this.clbYearMonth.TabIndex = 0;
            this.clbYearMonth.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.clbYearMonth_ItemCheck);
            // 
            // btnUnCheckAll
            // 
            this.btnUnCheckAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUnCheckAll.Location = new System.Drawing.Point(0, 0);
            this.btnUnCheckAll.Name = "btnUnCheckAll";
            this.btnUnCheckAll.Size = new System.Drawing.Size(242, 23);
            this.btnUnCheckAll.TabIndex = 4;
            this.btnUnCheckAll.Text = "清空选中月份";
            this.btnUnCheckAll.Click += new System.EventHandler(this.btnUnCheckAll_Click);
            // 
            // dpChart
            // 
            this.dpChart.Controls.Add(this.dockPanel2_Container);
            this.dpChart.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dpChart.DockedAsTabbedDocument = true;
            this.dpChart.FloatLocation = new System.Drawing.Point(272, 531);
            this.dpChart.FloatVertical = true;
            this.dpChart.ID = new System.Guid("599518cb-584c-4130-ae32-4e3ae94f2bf7");
            this.dpChart.Location = new System.Drawing.Point(0, 0);
            this.dpChart.Name = "dpChart";
            this.dpChart.Options.ShowCloseButton = false;
            this.dpChart.OriginalSize = new System.Drawing.Size(300, 300);
            this.dpChart.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpChart.SavedIndex = 1;
            this.dpChart.Size = new System.Drawing.Size(384, 451);
            this.dpChart.Text = "图表";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.icbo3DModle);
            this.dockPanel2_Container.Controls.Add(this.btnRestoreDefaultAngles);
            this.dockPanel2_Container.Controls.Add(this.chartControl1);
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(384, 451);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // icbo3DModle
            // 
            this.icbo3DModle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.icbo3DModle.EditValue = "Box";
            this.icbo3DModle.Location = new System.Drawing.Point(105, 429);
            this.icbo3DModle.Name = "icbo3DModle";
            this.icbo3DModle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbo3DModle.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("长方体", "Box", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("圆柱体", "Cylinder", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("圆锥体", "Cone", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("角锥体", "Pyramid", -1)});
            this.icbo3DModle.Size = new System.Drawing.Size(100, 20);
            this.icbo3DModle.TabIndex = 4;
            this.icbo3DModle.SelectedIndexChanged += new System.EventHandler(this.icbo3DModle_SelectedIndexChanged);
            // 
            // btnRestoreDefaultAngles
            // 
            this.btnRestoreDefaultAngles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRestoreDefaultAngles.Location = new System.Drawing.Point(-1, 428);
            this.btnRestoreDefaultAngles.Name = "btnRestoreDefaultAngles";
            this.btnRestoreDefaultAngles.Size = new System.Drawing.Size(100, 23);
            this.btnRestoreDefaultAngles.TabIndex = 3;
            this.btnRestoreDefaultAngles.Text = "恢复默认角度";
            this.btnRestoreDefaultAngles.Click += new System.EventHandler(this.btnRestoreDefaultAngles_Click);
            // 
            // chartControl1
            // 
            this.chartControl1.Cursor = System.Windows.Forms.Cursors.Default;
            xyDiagram3D1.AxisY.Label.TextPattern = "{V:c}";
            xyDiagram3D1.RotationMatrixSerializable = "0.766044443118978;-0.219846310392954;0.604022773555054;0;0;0.939692620785908;0.34" +
    "2020143325669;0;-0.642787609686539;-0.262002630229385;0.719846310392954;0;0;0;0;" +
    "1";
            xyDiagram3D1.RuntimeRotation = true;
            xyDiagram3D1.RuntimeScrolling = true;
            xyDiagram3D1.RuntimeZooming = true;
            xyDiagram3D1.VerticalScrollPercent = 6D;
            xyDiagram3D1.ZoomPercent = 150;
            this.chartControl1.Diagram = xyDiagram3D1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            series1.Name = "Series 1";
            series1.View = sideBySideBar3DSeriesView1;
            series2.Name = "Series 2";
            series2.View = sideBySideBar3DSeriesView2;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chartControl1.SeriesTemplate.View = sideBySideBar3DSeriesView3;
            this.chartControl1.Size = new System.Drawing.Size(384, 451);
            this.chartControl1.TabIndex = 2;
            chartTitle1.Alignment = System.Drawing.StringAlignment.Far;
            chartTitle1.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Bottom;
            chartTitle1.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle1.Text = "技术支持:冰雪软件";
            chartTitle1.TextColor = System.Drawing.Color.Gray;
            this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
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
            this.document2});
            this.tabbedView1.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // documentGroup1
            // 
            this.documentGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.document2});
            // 
            // document2
            // 
            this.document2.Caption = "图表";
            this.document2.FloatLocation = new System.Drawing.Point(272, 531);
            this.document2.FloatSize = new System.Drawing.Size(200, 200);
            this.document2.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            this.document2.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document2.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // document1
            // 
            this.document1.Caption = "图表";
            this.document1.FloatLocation = new System.Drawing.Point(272, 531);
            this.document1.FloatSize = new System.Drawing.Size(200, 200);
            this.document1.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            this.document1.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // MonthlyChartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dpYearMonth);
            this.Name = "MonthlyChartPage";
            this.Size = new System.Drawing.Size(640, 480);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.dpYearMonth.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clbYearMonth)).EndInit();
            this.dpChart.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icbo3DModle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3D1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBar3DSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBar3DSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBar3DSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel dpChart;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document2;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraEditors.SimpleButton btnRestoreDefaultAngles;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbo3DModle;
        private DevExpress.XtraBars.Docking.DockPanel dpYearMonth;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraEditors.CheckedListBoxControl clbYearMonth;
        private DevExpress.XtraEditors.SimpleButton btnUnCheckAll;

    }
}
