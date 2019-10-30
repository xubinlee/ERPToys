namespace USL
{
    partial class PermissionSettingPage
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
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.vUsersInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.colID = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colID = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.col照片 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col照片 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.col姓名 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col姓名 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.col账号 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col账号 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.col部门 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col部门 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.col职位 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col职位 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.col电话 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col电话 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.col地址 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col地址 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.col备注 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_col备注 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.Group1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dpPermissions = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.cuTreeListPermission = new CustomComponent.CustomTreeList();
            this.dpButtonPermission = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcButtonPermission = new DevExpress.XtraGrid.GridControl();
            this.buttonPermissionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.winevButtonPermission = new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView();
            this.colID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckBoxState = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vUsersInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col照片)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col姓名)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col账号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col部门)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col职位)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col电话)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col地址)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col备注)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.dpPermissions.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cuTreeListPermission)).BeginInit();
            this.dpButtonPermission.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcButtonPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPermissionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winevButtonPermission)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl.DataSource = this.vUsersInfoBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.layoutView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(440, 400);
            this.gridControl.TabIndex = 1;
            this.gridControl.UseEmbeddedNavigator = true;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView});
            // 
            // vUsersInfoBindingSource
            // 
            this.vUsersInfoBindingSource.DataSource = typeof(DBML.VUsersInfo);
            // 
            // layoutView
            // 
            this.layoutView.CardMinSize = new System.Drawing.Size(284, 188);
            this.layoutView.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.colID,
            this.col照片,
            this.col姓名,
            this.col账号,
            this.col部门,
            this.col职位,
            this.col电话,
            this.col地址,
            this.col备注});
            this.layoutView.GridControl = this.gridControl;
            this.layoutView.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_col备注,
            this.layoutViewField_colID});
            this.layoutView.Name = "layoutView";
            this.layoutView.OptionsBehavior.Editable = false;
            this.layoutView.OptionsBehavior.ReadOnly = true;
            this.layoutView.OptionsCarouselMode.PitchAngle = 1F;
            this.layoutView.OptionsCarouselMode.RollAngle = 8F;
            this.layoutView.OptionsCustomization.AllowFilter = false;
            this.layoutView.OptionsCustomization.AllowSort = false;
            this.layoutView.OptionsFind.FindNullPrompt = "请输入查找内容...";
            this.layoutView.OptionsFind.ShowCloseButton = false;
            this.layoutView.OptionsHeaderPanel.EnableCustomizeButton = false;
            this.layoutView.OptionsView.ShowCardCaption = false;
            this.layoutView.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Carousel;
            this.layoutView.TemplateCard = this.layoutViewCard1;
            this.layoutView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.layoutView_FocusedRowChanged);
            this.layoutView.RowCountChanged += new System.EventHandler(this.layoutView_RowCountChanged);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.LayoutViewField = this.layoutViewField_colID;
            this.colID.Name = "colID";
            // 
            // layoutViewField_colID
            // 
            this.layoutViewField_colID.EditorPreferredWidth = 167;
            this.layoutViewField_colID.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colID.Name = "layoutViewField_colID";
            this.layoutViewField_colID.Size = new System.Drawing.Size(264, 168);
            this.layoutViewField_colID.TextSize = new System.Drawing.Size(28, 20);
            this.layoutViewField_colID.TextToControlDistance = 5;
            // 
            // col照片
            // 
            this.col照片.FieldName = "照片";
            this.col照片.LayoutViewField = this.layoutViewField_col照片;
            this.col照片.Name = "col照片";
            // 
            // layoutViewField_col照片
            // 
            this.layoutViewField_col照片.EditorPreferredWidth = 116;
            this.layoutViewField_col照片.Location = new System.Drawing.Point(144, 0);
            this.layoutViewField_col照片.Name = "layoutViewField_col照片";
            this.layoutViewField_col照片.Size = new System.Drawing.Size(120, 120);
            this.layoutViewField_col照片.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_col照片.TextToControlDistance = 0;
            this.layoutViewField_col照片.TextVisible = false;
            // 
            // col姓名
            // 
            this.col姓名.FieldName = "姓名";
            this.col姓名.LayoutViewField = this.layoutViewField_col姓名;
            this.col姓名.Name = "col姓名";
            // 
            // layoutViewField_col姓名
            // 
            this.layoutViewField_col姓名.EditorPreferredWidth = 83;
            this.layoutViewField_col姓名.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_col姓名.Name = "layoutViewField_col姓名";
            this.layoutViewField_col姓名.Size = new System.Drawing.Size(120, 24);
            this.layoutViewField_col姓名.TextSize = new System.Drawing.Size(28, 14);
            this.layoutViewField_col姓名.TextToControlDistance = 5;
            // 
            // col账号
            // 
            this.col账号.FieldName = "账号";
            this.col账号.LayoutViewField = this.layoutViewField_col账号;
            this.col账号.Name = "col账号";
            // 
            // layoutViewField_col账号
            // 
            this.layoutViewField_col账号.EditorPreferredWidth = 83;
            this.layoutViewField_col账号.Location = new System.Drawing.Point(0, 24);
            this.layoutViewField_col账号.Name = "layoutViewField_col账号";
            this.layoutViewField_col账号.Size = new System.Drawing.Size(120, 24);
            this.layoutViewField_col账号.TextSize = new System.Drawing.Size(28, 14);
            this.layoutViewField_col账号.TextToControlDistance = 5;
            // 
            // col部门
            // 
            this.col部门.FieldName = "部门";
            this.col部门.LayoutViewField = this.layoutViewField_col部门;
            this.col部门.Name = "col部门";
            // 
            // layoutViewField_col部门
            // 
            this.layoutViewField_col部门.EditorPreferredWidth = 83;
            this.layoutViewField_col部门.Location = new System.Drawing.Point(0, 48);
            this.layoutViewField_col部门.Name = "layoutViewField_col部门";
            this.layoutViewField_col部门.Size = new System.Drawing.Size(120, 24);
            this.layoutViewField_col部门.TextSize = new System.Drawing.Size(28, 14);
            this.layoutViewField_col部门.TextToControlDistance = 5;
            // 
            // col职位
            // 
            this.col职位.FieldName = "职位";
            this.col职位.LayoutViewField = this.layoutViewField_col职位;
            this.col职位.Name = "col职位";
            // 
            // layoutViewField_col职位
            // 
            this.layoutViewField_col职位.EditorPreferredWidth = 83;
            this.layoutViewField_col职位.Location = new System.Drawing.Point(0, 72);
            this.layoutViewField_col职位.Name = "layoutViewField_col职位";
            this.layoutViewField_col职位.Size = new System.Drawing.Size(120, 24);
            this.layoutViewField_col职位.TextSize = new System.Drawing.Size(28, 14);
            this.layoutViewField_col职位.TextToControlDistance = 5;
            // 
            // col电话
            // 
            this.col电话.FieldName = "电话";
            this.col电话.LayoutViewField = this.layoutViewField_col电话;
            this.col电话.Name = "col电话";
            // 
            // layoutViewField_col电话
            // 
            this.layoutViewField_col电话.EditorPreferredWidth = 227;
            this.layoutViewField_col电话.Location = new System.Drawing.Point(0, 120);
            this.layoutViewField_col电话.Name = "layoutViewField_col电话";
            this.layoutViewField_col电话.Size = new System.Drawing.Size(264, 24);
            this.layoutViewField_col电话.TextSize = new System.Drawing.Size(28, 14);
            this.layoutViewField_col电话.TextToControlDistance = 5;
            // 
            // col地址
            // 
            this.col地址.FieldName = "地址";
            this.col地址.LayoutViewField = this.layoutViewField_col地址;
            this.col地址.Name = "col地址";
            // 
            // layoutViewField_col地址
            // 
            this.layoutViewField_col地址.EditorPreferredWidth = 227;
            this.layoutViewField_col地址.Location = new System.Drawing.Point(0, 144);
            this.layoutViewField_col地址.Name = "layoutViewField_col地址";
            this.layoutViewField_col地址.Size = new System.Drawing.Size(264, 24);
            this.layoutViewField_col地址.TextSize = new System.Drawing.Size(28, 14);
            this.layoutViewField_col地址.TextToControlDistance = 5;
            // 
            // col备注
            // 
            this.col备注.FieldName = "备注";
            this.col备注.LayoutViewField = this.layoutViewField_col备注;
            this.col备注.Name = "col备注";
            // 
            // layoutViewField_col备注
            // 
            this.layoutViewField_col备注.EditorPreferredWidth = 167;
            this.layoutViewField_col备注.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_col备注.Name = "layoutViewField_col备注";
            this.layoutViewField_col备注.Size = new System.Drawing.Size(264, 168);
            this.layoutViewField_col备注.TextSize = new System.Drawing.Size(28, 20);
            this.layoutViewField_col备注.TextToControlDistance = 5;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.GroupBordersVisible = false;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_col电话,
            this.layoutViewField_col地址,
            this.Group1,
            this.layoutViewField_col照片});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 5;
            this.layoutViewCard1.Text = "TemplateCard";
            this.layoutViewCard1.TextVisible = false;
            // 
            // Group1
            // 
            this.Group1.CustomizationFormText = "Group1";
            this.Group1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_col姓名,
            this.layoutViewField_col账号,
            this.layoutViewField_col部门,
            this.layoutViewField_col职位});
            this.Group1.Location = new System.Drawing.Point(0, 0);
            this.Group1.Name = "Group1";
            this.Group1.Size = new System.Drawing.Size(144, 120);
            this.Group1.Text = "Group1";
            this.Group1.TextVisible = false;
            // 
            // dockManager
            // 
            this.dockManager.Form = this;
            this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpPermissions,
            this.dpButtonPermission});
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
            // dpPermissions
            // 
            this.dpPermissions.Controls.Add(this.dockPanel1_Container);
            this.dpPermissions.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpPermissions.ID = new System.Guid("d292e337-e6cb-4fa8-8874-38803bc8cb12");
            this.dpPermissions.Location = new System.Drawing.Point(440, 0);
            this.dpPermissions.Name = "dpPermissions";
            this.dpPermissions.Options.ShowCloseButton = false;
            this.dpPermissions.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpPermissions.Size = new System.Drawing.Size(200, 480);
            this.dpPermissions.Text = "功能权限";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.cuTreeListPermission);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 453);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // cuTreeListPermission
            // 
            this.cuTreeListPermission.CheckedStateFieldName = "";
            this.cuTreeListPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cuTreeListPermission.Location = new System.Drawing.Point(0, 0);
            this.cuTreeListPermission.Name = "cuTreeListPermission";
            this.cuTreeListPermission.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.cuTreeListPermission.OptionsView.EnableAppearanceEvenRow = true;
            this.cuTreeListPermission.OptionsView.EnableAppearanceOddRow = true;
            this.cuTreeListPermission.OptionsView.ShowCheckBoxes = true;
            this.cuTreeListPermission.Size = new System.Drawing.Size(192, 453);
            this.cuTreeListPermission.TabIndex = 0;
            this.cuTreeListPermission.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.cuTreeListPermission_BeforeCheckNode);
            this.cuTreeListPermission.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.cuTreeListPermission_CustomDrawNodeCell);
            this.cuTreeListPermission.CustomDrawNodeCheckBox += new DevExpress.XtraTreeList.CustomDrawNodeCheckBoxEventHandler(this.cuTreeListPermission_CustomDrawNodeCheckBox);
            // 
            // dpButtonPermission
            // 
            this.dpButtonPermission.Controls.Add(this.controlContainer1);
            this.dpButtonPermission.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpButtonPermission.ID = new System.Guid("6f357a50-667e-47e5-8858-2676e601268b");
            this.dpButtonPermission.Location = new System.Drawing.Point(0, 400);
            this.dpButtonPermission.Name = "dpButtonPermission";
            this.dpButtonPermission.Options.ShowCloseButton = false;
            this.dpButtonPermission.OriginalSize = new System.Drawing.Size(200, 80);
            this.dpButtonPermission.Size = new System.Drawing.Size(440, 80);
            this.dpButtonPermission.Text = "按钮权限";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.gcButtonPermission);
            this.controlContainer1.Location = new System.Drawing.Point(4, 23);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(432, 53);
            this.controlContainer1.TabIndex = 0;
            // 
            // gcButtonPermission
            // 
            this.gcButtonPermission.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcButtonPermission.DataSource = this.buttonPermissionBindingSource;
            this.gcButtonPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcButtonPermission.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcButtonPermission.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcButtonPermission.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcButtonPermission.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcButtonPermission.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcButtonPermission.Location = new System.Drawing.Point(0, 0);
            this.gcButtonPermission.MainView = this.winevButtonPermission;
            this.gcButtonPermission.Name = "gcButtonPermission";
            this.gcButtonPermission.Size = new System.Drawing.Size(432, 53);
            this.gcButtonPermission.TabIndex = 4;
            this.gcButtonPermission.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.winevButtonPermission});
            // 
            // buttonPermissionBindingSource
            // 
            this.buttonPermissionBindingSource.DataSource = typeof(DBML.ButtonPermission);
            // 
            // winevButtonPermission
            // 
            this.winevButtonPermission.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID1,
            this.colUserID,
            this.colName,
            this.colCaption,
            this.colCheckBoxState});
            this.winevButtonPermission.ColumnSet.CheckBoxColumn = this.colCheckBoxState;
            this.winevButtonPermission.ColumnSet.TextColumn = this.colCaption;
            this.winevButtonPermission.GridControl = this.gcButtonPermission;
            this.winevButtonPermission.Name = "winevButtonPermission";
            this.winevButtonPermission.OptionsBehavior.Editable = false;
            this.winevButtonPermission.OptionsFind.ShowCloseButton = false;
            this.winevButtonPermission.OptionsView.ShowCheckBoxes = true;
            this.winevButtonPermission.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.List;
            // 
            // colID1
            // 
            this.colID1.FieldName = "ID";
            this.colID1.Name = "colID1";
            this.colID1.Visible = true;
            this.colID1.VisibleIndex = 0;
            // 
            // colUserID
            // 
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 1;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            // 
            // colCaption
            // 
            this.colCaption.FieldName = "Caption";
            this.colCaption.Name = "colCaption";
            this.colCaption.Visible = true;
            this.colCaption.VisibleIndex = 3;
            // 
            // colCheckBoxState
            // 
            this.colCheckBoxState.FieldName = "CheckBoxState";
            this.colCheckBoxState.Name = "colCheckBoxState";
            this.colCheckBoxState.Visible = true;
            this.colCheckBoxState.VisibleIndex = 4;
            // 
            // PermissionSettingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.dpButtonPermission);
            this.Controls.Add(this.dpPermissions);
            this.Name = "PermissionSettingPage";
            this.Size = new System.Drawing.Size(640, 480);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vUsersInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col照片)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col姓名)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col账号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col部门)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col职位)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col电话)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col地址)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_col备注)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.dpPermissions.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cuTreeListPermission)).EndInit();
            this.dpButtonPermission.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcButtonPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPermissionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winevButtonPermission)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel dpPermissions;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView;
        private System.Windows.Forms.BindingSource vUsersInfoBindingSource;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colID;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col照片;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col姓名;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col账号;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col部门;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col职位;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col电话;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col地址;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn col备注;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colID;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col照片;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col姓名;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col账号;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col部门;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col职位;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col电话;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col地址;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_col备注;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.LayoutControlGroup Group1;
        private CustomComponent.CustomTreeList cuTreeListPermission;
        private DevExpress.XtraBars.Docking.DockPanel dpButtonPermission;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraGrid.GridControl gcButtonPermission;
        private DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView winevButtonPermission;
        private System.Windows.Forms.BindingSource buttonPermissionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCaption;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckBoxState;
    }
}
