namespace USL
{
    partial class DataEditForm
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
            this.panelControl = new DevExpress.XtraEditors.PanelControl();
            this.tileNavPane = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerBottom = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dpMoldAllot = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.vGoodsByMoldAllotBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col货号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col品名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col货品类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col包装方式 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col单价 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col去税单价 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col装箱数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col内盒 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col单位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col规格 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col外箱规格 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col毛重 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col净重 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col体积 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col条形码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col库存上限 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col库存下限 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col进项税 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col销项税 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.hideContainerBottom.SuspendLayout();
            this.dpMoldAllot.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGoodsByMoldAllotBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 40);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(784, 502);
            this.panelControl.TabIndex = 1;
            // 
            // tileNavPane
            // 
            this.tileNavPane.ButtonPadding = new System.Windows.Forms.Padding(12);
            // 
            // tileNavCategory1
            // 
            this.tileNavPane.DefaultCategory.Name = "tileNavCategory1";
            this.tileNavPane.DefaultCategory.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane.DefaultCategory.OwnerCollection = null;
            // 
            // 
            // 
            this.tileNavPane.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileNavPane.DefaultCategory.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tileNavPane.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileNavPane.Location = new System.Drawing.Point(0, 0);
            this.tileNavPane.Name = "tileNavPane";
            this.tileNavPane.OptionsPrimaryDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane.OptionsSecondaryDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane.Size = new System.Drawing.Size(784, 40);
            this.tileNavPane.TabIndex = 2;
            this.tileNavPane.Text = "tileNavPane1";
            // 
            // dockManager
            // 
            this.dockManager.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerBottom});
            this.dockManager.Form = this;
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
            // hideContainerBottom
            // 
            this.hideContainerBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerBottom.Controls.Add(this.dpMoldAllot);
            this.hideContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hideContainerBottom.Location = new System.Drawing.Point(0, 542);
            this.hideContainerBottom.Name = "hideContainerBottom";
            this.hideContainerBottom.Size = new System.Drawing.Size(784, 20);
            // 
            // dpMoldAllot
            // 
            this.dpMoldAllot.Controls.Add(this.dockPanel1_Container);
            this.dpMoldAllot.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpMoldAllot.ID = new System.Guid("9d5c544a-d9a4-4831-93b0-c6491e7490ee");
            this.dpMoldAllot.Location = new System.Drawing.Point(0, 0);
            this.dpMoldAllot.Name = "dpMoldAllot";
            this.dpMoldAllot.Options.ShowCloseButton = false;
            this.dpMoldAllot.OriginalSize = new System.Drawing.Size(200, 300);
            this.dpMoldAllot.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpMoldAllot.SavedIndex = 0;
            this.dpMoldAllot.Size = new System.Drawing.Size(784, 300);
            this.dpMoldAllot.Text = "模具分配";
            this.dpMoldAllot.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gridControl);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(776, 273);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // gridControl
            // 
            this.gridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl.DataSource = this.vGoodsByMoldAllotBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(776, 273);
            this.gridControl.TabIndex = 1;
            this.gridControl.UseEmbeddedNavigator = true;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // vGoodsByMoldAllotBindingSource
            // 
            this.vGoodsByMoldAllotBindingSource.DataSource = typeof(DBML.VGoodsByMoldAllot);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colSupplierID,
            this.col货号,
            this.col品名,
            this.col货品类型,
            this.col包装方式,
            this.col单价,
            this.col去税单价,
            this.col装箱数,
            this.col内盒,
            this.col单位,
            this.col规格,
            this.col外箱规格,
            this.col毛重,
            this.col净重,
            this.col体积,
            this.col条形码,
            this.col库存上限,
            this.col库存下限,
            this.col进项税,
            this.col销项税});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsFind.FindNullPrompt = "请输入查找内容...";
            this.gridView.OptionsFind.ShowCloseButton = false;
            this.gridView.OptionsPrint.AutoWidth = false;
            this.gridView.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gridView.OptionsPrint.EnableAppearanceOddRow = true;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView.OptionsView.EnableAppearanceOddRow = true;
            this.gridView.OptionsView.ShowFooter = true;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colSupplierID
            // 
            this.colSupplierID.FieldName = "SupplierID";
            this.colSupplierID.Name = "colSupplierID";
            this.colSupplierID.Visible = true;
            this.colSupplierID.VisibleIndex = 1;
            // 
            // col货号
            // 
            this.col货号.FieldName = "货号";
            this.col货号.Name = "col货号";
            this.col货号.Visible = true;
            this.col货号.VisibleIndex = 2;
            // 
            // col品名
            // 
            this.col品名.FieldName = "品名";
            this.col品名.Name = "col品名";
            this.col品名.Visible = true;
            this.col品名.VisibleIndex = 3;
            // 
            // col货品类型
            // 
            this.col货品类型.FieldName = "货品类型";
            this.col货品类型.Name = "col货品类型";
            this.col货品类型.Visible = true;
            this.col货品类型.VisibleIndex = 4;
            // 
            // col包装方式
            // 
            this.col包装方式.FieldName = "包装方式";
            this.col包装方式.Name = "col包装方式";
            this.col包装方式.Visible = true;
            this.col包装方式.VisibleIndex = 5;
            // 
            // col单价
            // 
            this.col单价.FieldName = "单价";
            this.col单价.Name = "col单价";
            this.col单价.Visible = true;
            this.col单价.VisibleIndex = 6;
            // 
            // col去税单价
            // 
            this.col去税单价.FieldName = "去税单价";
            this.col去税单价.Name = "col去税单价";
            this.col去税单价.Visible = true;
            this.col去税单价.VisibleIndex = 7;
            // 
            // col装箱数
            // 
            this.col装箱数.FieldName = "装箱数";
            this.col装箱数.Name = "col装箱数";
            this.col装箱数.Visible = true;
            this.col装箱数.VisibleIndex = 8;
            // 
            // col内盒
            // 
            this.col内盒.FieldName = "内盒";
            this.col内盒.Name = "col内盒";
            this.col内盒.Visible = true;
            this.col内盒.VisibleIndex = 9;
            // 
            // col单位
            // 
            this.col单位.FieldName = "单位";
            this.col单位.Name = "col单位";
            this.col单位.Visible = true;
            this.col单位.VisibleIndex = 10;
            // 
            // col规格
            // 
            this.col规格.FieldName = "规格";
            this.col规格.Name = "col规格";
            this.col规格.Visible = true;
            this.col规格.VisibleIndex = 11;
            // 
            // col外箱规格
            // 
            this.col外箱规格.FieldName = "外箱规格";
            this.col外箱规格.Name = "col外箱规格";
            this.col外箱规格.Visible = true;
            this.col外箱规格.VisibleIndex = 12;
            // 
            // col毛重
            // 
            this.col毛重.FieldName = "毛重";
            this.col毛重.Name = "col毛重";
            this.col毛重.Visible = true;
            this.col毛重.VisibleIndex = 13;
            // 
            // col净重
            // 
            this.col净重.FieldName = "净重";
            this.col净重.Name = "col净重";
            this.col净重.Visible = true;
            this.col净重.VisibleIndex = 14;
            // 
            // col体积
            // 
            this.col体积.FieldName = "体积";
            this.col体积.Name = "col体积";
            this.col体积.Visible = true;
            this.col体积.VisibleIndex = 15;
            // 
            // col条形码
            // 
            this.col条形码.FieldName = "条形码";
            this.col条形码.Name = "col条形码";
            this.col条形码.Visible = true;
            this.col条形码.VisibleIndex = 16;
            // 
            // col库存上限
            // 
            this.col库存上限.FieldName = "库存上限";
            this.col库存上限.Name = "col库存上限";
            this.col库存上限.Visible = true;
            this.col库存上限.VisibleIndex = 17;
            // 
            // col库存下限
            // 
            this.col库存下限.FieldName = "库存下限";
            this.col库存下限.Name = "col库存下限";
            this.col库存下限.Visible = true;
            this.col库存下限.VisibleIndex = 18;
            // 
            // col进项税
            // 
            this.col进项税.FieldName = "进项税";
            this.col进项税.Name = "col进项税";
            this.col进项税.Visible = true;
            this.col进项税.VisibleIndex = 19;
            // 
            // col销项税
            // 
            this.col销项税.FieldName = "销项税";
            this.col销项税.Name = "col销项税";
            this.col销项税.Visible = true;
            this.col销项税.VisibleIndex = 20;
            // 
            // DataEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.tileNavPane);
            this.Controls.Add(this.hideContainerBottom);
            this.Name = "DataEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.hideContainerBottom.ResumeLayout(false);
            this.dpMoldAllot.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGoodsByMoldAllotBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl;
        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerBottom;
        private DevExpress.XtraBars.Docking.DockPanel dpMoldAllot;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private System.Windows.Forms.BindingSource vGoodsByMoldAllotBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierID;
        private DevExpress.XtraGrid.Columns.GridColumn col货号;
        private DevExpress.XtraGrid.Columns.GridColumn col品名;
        private DevExpress.XtraGrid.Columns.GridColumn col货品类型;
        private DevExpress.XtraGrid.Columns.GridColumn col包装方式;
        private DevExpress.XtraGrid.Columns.GridColumn col单价;
        private DevExpress.XtraGrid.Columns.GridColumn col去税单价;
        private DevExpress.XtraGrid.Columns.GridColumn col装箱数;
        private DevExpress.XtraGrid.Columns.GridColumn col内盒;
        private DevExpress.XtraGrid.Columns.GridColumn col单位;
        private DevExpress.XtraGrid.Columns.GridColumn col规格;
        private DevExpress.XtraGrid.Columns.GridColumn col外箱规格;
        private DevExpress.XtraGrid.Columns.GridColumn col毛重;
        private DevExpress.XtraGrid.Columns.GridColumn col净重;
        private DevExpress.XtraGrid.Columns.GridColumn col体积;
        private DevExpress.XtraGrid.Columns.GridColumn col条形码;
        private DevExpress.XtraGrid.Columns.GridColumn col库存上限;
        private DevExpress.XtraGrid.Columns.GridColumn col库存下限;
        private DevExpress.XtraGrid.Columns.GridColumn col进项税;
        private DevExpress.XtraGrid.Columns.GridColumn col销项税;
    }
}