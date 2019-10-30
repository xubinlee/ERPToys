namespace CommonLibrary
{
    partial class ErrorInfoControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorInfoControl));
            this.barManagerErrorInfo = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barClear = new DevExpress.XtraBars.BarButtonItem();
            this.barSendEmail = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridErrorList = new DevExpress.XtraGrid.GridControl();
            this.bsErrorInfoList = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colErrorType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.colModuleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerErrorInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridErrorList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsErrorInfoList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManagerErrorInfo
            // 
            this.barManagerErrorInfo.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManagerErrorInfo.DockControls.Add(this.barDockControlTop);
            this.barManagerErrorInfo.DockControls.Add(this.barDockControlBottom);
            this.barManagerErrorInfo.DockControls.Add(this.barDockControlLeft);
            this.barManagerErrorInfo.DockControls.Add(this.barDockControlRight);
            this.barManagerErrorInfo.Form = this;
            this.barManagerErrorInfo.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barClear,
            this.barSendEmail});
            this.barManagerErrorInfo.MainMenu = this.bar2;
            this.barManagerErrorInfo.MaxItemId = 2;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSendEmail)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barClear
            // 
            this.barClear.Caption = "清空";
            this.barClear.Id = 0;
            this.barClear.Name = "barClear";
            this.barClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barClear_ItemClick);
            // 
            // barSendEmail
            // 
            this.barSendEmail.Caption = "报告错误";
            this.barSendEmail.Id = 1;
            this.barSendEmail.Name = "barSendEmail";
            this.barSendEmail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSendEmail_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(456, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 150);
            this.barDockControlBottom.Size = new System.Drawing.Size(456, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 126);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(456, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 126);
            // 
            // gridErrorList
            // 
            this.gridErrorList.DataSource = this.bsErrorInfoList;
            this.gridErrorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridErrorList.Location = new System.Drawing.Point(0, 24);
            this.gridErrorList.MainView = this.gridView1;
            this.gridErrorList.MenuManager = this.barManagerErrorInfo;
            this.gridErrorList.Name = "gridErrorList";
            this.gridErrorList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.gridErrorList.Size = new System.Drawing.Size(456, 126);
            this.gridErrorList.TabIndex = 4;
            this.gridErrorList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridErrorList.DoubleClick += new System.EventHandler(this.gridErrorList_DoubleClick);
            // 
            // bsErrorInfoList
            // 
            this.bsErrorInfoList.DataSource = typeof(CommonLibrary.ErrorInfoData);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colErrorType,
            this.colModuleName,
            this.colMessage});
            this.gridView1.GridControl = this.gridErrorList;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colErrorType
            // 
            this.colErrorType.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colErrorType.FieldName = "ErrorType";
            this.colErrorType.Name = "colErrorType";
            this.colErrorType.OptionsColumn.AllowEdit = false;
            this.colErrorType.OptionsColumn.FixedWidth = true;
            this.colErrorType.OptionsColumn.ReadOnly = true;
            this.colErrorType.Visible = true;
            this.colErrorType.VisibleIndex = 0;
            this.colErrorType.Width = 20;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SmallImages = this.imageList1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ProgressError.ico");
            // 
            // colModuleName
            // 
            this.colModuleName.Caption = "模块";
            this.colModuleName.FieldName = "ModuleName";
            this.colModuleName.Name = "colModuleName";
            this.colModuleName.OptionsColumn.AllowEdit = false;
            this.colModuleName.OptionsColumn.FixedWidth = true;
            this.colModuleName.OptionsColumn.ReadOnly = true;
            this.colModuleName.Visible = true;
            this.colModuleName.VisibleIndex = 1;
            this.colModuleName.Width = 135;
            // 
            // colMessage
            // 
            this.colMessage.Caption = "错误信息";
            this.colMessage.FieldName = "Message";
            this.colMessage.Name = "colMessage";
            this.colMessage.OptionsColumn.AllowEdit = false;
            this.colMessage.OptionsColumn.ReadOnly = true;
            this.colMessage.Visible = true;
            this.colMessage.VisibleIndex = 2;
            this.colMessage.Width = 280;
            // 
            // ErrorInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridErrorList);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ErrorInfoControl";
            this.Size = new System.Drawing.Size(456, 150);
            ((System.ComponentModel.ISupportInitialize)(this.barManagerErrorInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridErrorList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsErrorInfoList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerErrorInfo;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barClear;
        private DevExpress.XtraBars.BarButtonItem barSendEmail;
        private DevExpress.XtraGrid.GridControl gridErrorList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource bsErrorInfoList;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorType;
        private DevExpress.XtraGrid.Columns.GridColumn colModuleName;
        private DevExpress.XtraGrid.Columns.GridColumn colMessage;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private System.Windows.Forms.ImageList imageList1;

    }
}
