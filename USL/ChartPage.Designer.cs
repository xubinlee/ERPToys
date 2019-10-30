namespace USL
{
    partial class ChartPage
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
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.icbo3DModle = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnRestoreDefaultAngles = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lci3DModle = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciChart = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3D1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBar3DSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBar3DSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBar3DSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbo3DModle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci3DModle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciChart)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.chartControl1);
            this.layoutControl.Controls.Add(this.icbo3DModle);
            this.layoutControl.Controls.Add(this.btnRestoreDefaultAngles);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(640, 480);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
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
            xyDiagram3D1.ZoomPercent = 130;
            this.chartControl1.Diagram = xyDiagram3D1;
            this.chartControl1.Legend.UseCheckBoxes = true;
            this.chartControl1.Location = new System.Drawing.Point(12, 38);
            this.chartControl1.Name = "chartControl1";
            series1.Name = "Series 1";
            series1.View = sideBySideBar3DSeriesView1;
            series2.Name = "Series 2";
            series2.View = sideBySideBar3DSeriesView2;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chartControl1.SeriesTemplate.View = sideBySideBar3DSeriesView3;
            this.chartControl1.Size = new System.Drawing.Size(616, 430);
            this.chartControl1.TabIndex = 1;
            chartTitle1.Alignment = System.Drawing.StringAlignment.Far;
            chartTitle1.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Bottom;
            chartTitle1.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle1.Text = "技术支持:冰雪软件";
            chartTitle1.TextColor = System.Drawing.Color.Gray;
            this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // icbo3DModle
            // 
            this.icbo3DModle.EditValue = "Box";
            this.icbo3DModle.Location = new System.Drawing.Point(364, 12);
            this.icbo3DModle.Name = "icbo3DModle";
            this.icbo3DModle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbo3DModle.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("长方体", "Box", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("圆柱体", "Cylinder", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("圆锥体", "Cone", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("角锥体", "Pyramid", -1)});
            this.icbo3DModle.Size = new System.Drawing.Size(264, 20);
            this.icbo3DModle.StyleController = this.layoutControl;
            this.icbo3DModle.TabIndex = 5;
            this.icbo3DModle.SelectedIndexChanged += new System.EventHandler(this.icbo3DModle_SelectedIndexChanged);
            // 
            // btnRestoreDefaultAngles
            // 
            this.btnRestoreDefaultAngles.Location = new System.Drawing.Point(12, 12);
            this.btnRestoreDefaultAngles.Name = "btnRestoreDefaultAngles";
            this.btnRestoreDefaultAngles.Size = new System.Drawing.Size(306, 22);
            this.btnRestoreDefaultAngles.StyleController = this.layoutControl;
            this.btnRestoreDefaultAngles.TabIndex = 4;
            this.btnRestoreDefaultAngles.Text = "恢复默认角度";
            this.btnRestoreDefaultAngles.Click += new System.EventHandler(this.btnRestoreDefaultAngles_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.lci3DModle,
            this.lciChart});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(640, 480);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnRestoreDefaultAngles;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(310, 26);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // lci3DModle
            // 
            this.lci3DModle.Control = this.icbo3DModle;
            this.lci3DModle.CustomizationFormText = "3D模型";
            this.lci3DModle.Location = new System.Drawing.Point(310, 0);
            this.lci3DModle.Name = "lci3DModle";
            this.lci3DModle.Size = new System.Drawing.Size(310, 26);
            this.lci3DModle.Text = "3D模型";
            this.lci3DModle.TextSize = new System.Drawing.Size(39, 14);
            // 
            // lciChart
            // 
            this.lciChart.Control = this.chartControl1;
            this.lciChart.CustomizationFormText = "图表";
            this.lciChart.Location = new System.Drawing.Point(0, 26);
            this.lciChart.Name = "lciChart";
            this.lciChart.Size = new System.Drawing.Size(620, 434);
            this.lciChart.Text = "图表";
            this.lciChart.TextSize = new System.Drawing.Size(0, 0);
            this.lciChart.TextToControlDistance = 0;
            this.lciChart.TextVisible = false;
            // 
            // ChartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Name = "ChartPage";
            this.Size = new System.Drawing.Size(640, 480);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3D1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBar3DSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBar3DSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBar3DSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbo3DModle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lci3DModle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.SimpleButton btnRestoreDefaultAngles;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbo3DModle;
        private DevExpress.XtraLayout.LayoutControlItem lci3DModle;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraLayout.LayoutControlItem lciChart;

    }
}
