namespace USL
{
    partial class SchClassPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchClassPage));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.schClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.colID = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemTimeEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.layoutViewField_colID = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colName = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colName = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colStartTime = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colStartTime = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colEndTime = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colEndTime = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colLateMinutes = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemSpinEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.layoutViewField_colLateMinutes = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colEarlyMinutes = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colEarlyMinutes = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colCheckInStartTime = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colCheckInStartTime = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colCheckInEndTime = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colCheckInEndTime = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colCheckOutStartTime = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colCheckOutStartTime = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colCheckOutEndTime = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colCheckOutEndTime = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colColor = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemSchColor = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.layoutViewField_colColor = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schClassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colLateMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colEarlyMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCheckInStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCheckInEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCheckOutStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCheckOutEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSchColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl.DataSource = this.schClassBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.layoutView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTimeEdit,
            this.repositoryItemSpinEdit,
            this.repositoryItemSchColor});
            this.gridControl.Size = new System.Drawing.Size(640, 480);
            this.gridControl.TabIndex = 2;
            this.gridControl.UseEmbeddedNavigator = true;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView});
            // 
            // schClassBindingSource
            // 
            this.schClassBindingSource.DataSource = typeof(EDMX.SchClass);
            // 
            // layoutView
            // 
            this.layoutView.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.colID,
            this.colName,
            this.colStartTime,
            this.colEndTime,
            this.colLateMinutes,
            this.colEarlyMinutes,
            this.colCheckInStartTime,
            this.colCheckInEndTime,
            this.colCheckOutStartTime,
            this.colCheckOutEndTime,
            this.colColor});
            this.layoutView.GridControl = this.gridControl;
            this.layoutView.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_colID});
            this.layoutView.Name = "layoutView";
            this.layoutView.OptionsCarouselMode.PitchAngle = 1.5F;
            this.layoutView.OptionsCarouselMode.RollAngle = 3F;
            this.layoutView.OptionsCustomization.AllowFilter = false;
            this.layoutView.OptionsCustomization.AllowSort = false;
            this.layoutView.OptionsFind.FindNullPrompt = "请输入查找内容...";
            this.layoutView.OptionsFind.ShowCloseButton = false;
            this.layoutView.OptionsHeaderPanel.EnableCustomizeButton = false;
            this.layoutView.OptionsView.ShowCardFieldBorders = true;
            this.layoutView.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiRow;
            this.layoutView.TemplateCard = this.layoutViewCard1;
            this.layoutView.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.layoutView_RowDeleted);
            this.layoutView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.layoutView_RowUpdated);
            // 
            // colID
            // 
            this.colID.ColumnEdit = this.repositoryItemTimeEdit;
            this.colID.FieldName = "ID";
            this.colID.LayoutViewField = this.layoutViewField_colID;
            this.colID.Name = "colID";
            // 
            // repositoryItemTimeEdit
            // 
            this.repositoryItemTimeEdit.AutoHeight = false;
            this.repositoryItemTimeEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTimeEdit.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTimeEdit.DisplayFormat.FormatString = "t";
            this.repositoryItemTimeEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemTimeEdit.EditFormat.FormatString = "t";
            this.repositoryItemTimeEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemTimeEdit.Mask.EditMask = "t";
            this.repositoryItemTimeEdit.MinValue = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.repositoryItemTimeEdit.Name = "repositoryItemTimeEdit";
            // 
            // layoutViewField_colID
            // 
            this.layoutViewField_colID.EditorPreferredWidth = 71;
            this.layoutViewField_colID.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colID.Name = "layoutViewField_colID";
            this.layoutViewField_colID.Size = new System.Drawing.Size(180, 240);
            this.layoutViewField_colID.TextSize = new System.Drawing.Size(124, 20);
            this.layoutViewField_colID.TextToControlDistance = 5;
            // 
            // colName
            // 
            this.colName.Caption = "时段名称";
            this.colName.FieldName = "Name";
            this.colName.Image = ((System.Drawing.Image)(resources.GetObject("colName.Image")));
            this.colName.LayoutViewField = this.layoutViewField_colName;
            this.colName.Name = "colName";
            // 
            // layoutViewField_colName
            // 
            this.layoutViewField_colName.EditorPreferredWidth = 73;
            this.layoutViewField_colName.Image = ((System.Drawing.Image)(resources.GetObject("layoutViewField_colName.Image")));
            this.layoutViewField_colName.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutViewField_colName.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colName.Name = "layoutViewField_colName";
            this.layoutViewField_colName.Size = new System.Drawing.Size(180, 24);
            this.layoutViewField_colName.TextSize = new System.Drawing.Size(98, 16);
            this.layoutViewField_colName.TextToControlDistance = 5;
            // 
            // colStartTime
            // 
            this.colStartTime.Caption = "上班时间";
            this.colStartTime.ColumnEdit = this.repositoryItemTimeEdit;
            this.colStartTime.DisplayFormat.FormatString = "t";
            this.colStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Image = ((System.Drawing.Image)(resources.GetObject("colStartTime.Image")));
            this.colStartTime.LayoutViewField = this.layoutViewField_colStartTime;
            this.colStartTime.Name = "colStartTime";
            // 
            // layoutViewField_colStartTime
            // 
            this.layoutViewField_colStartTime.EditorPreferredWidth = 73;
            this.layoutViewField_colStartTime.Image = ((System.Drawing.Image)(resources.GetObject("layoutViewField_colStartTime.Image")));
            this.layoutViewField_colStartTime.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutViewField_colStartTime.Location = new System.Drawing.Point(0, 24);
            this.layoutViewField_colStartTime.Name = "layoutViewField_colStartTime";
            this.layoutViewField_colStartTime.Size = new System.Drawing.Size(180, 24);
            this.layoutViewField_colStartTime.TextSize = new System.Drawing.Size(98, 16);
            this.layoutViewField_colStartTime.TextToControlDistance = 5;
            // 
            // colEndTime
            // 
            this.colEndTime.Caption = "下班时间";
            this.colEndTime.ColumnEdit = this.repositoryItemTimeEdit;
            this.colEndTime.DisplayFormat.FormatString = "t";
            this.colEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.Image = ((System.Drawing.Image)(resources.GetObject("colEndTime.Image")));
            this.colEndTime.LayoutViewField = this.layoutViewField_colEndTime;
            this.colEndTime.Name = "colEndTime";
            // 
            // layoutViewField_colEndTime
            // 
            this.layoutViewField_colEndTime.EditorPreferredWidth = 73;
            this.layoutViewField_colEndTime.Image = ((System.Drawing.Image)(resources.GetObject("layoutViewField_colEndTime.Image")));
            this.layoutViewField_colEndTime.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutViewField_colEndTime.Location = new System.Drawing.Point(0, 48);
            this.layoutViewField_colEndTime.Name = "layoutViewField_colEndTime";
            this.layoutViewField_colEndTime.Size = new System.Drawing.Size(180, 24);
            this.layoutViewField_colEndTime.TextSize = new System.Drawing.Size(98, 16);
            this.layoutViewField_colEndTime.TextToControlDistance = 5;
            // 
            // colLateMinutes
            // 
            this.colLateMinutes.Caption = "记迟到时间(分钟)";
            this.colLateMinutes.ColumnEdit = this.repositoryItemSpinEdit;
            this.colLateMinutes.FieldName = "LateMinutes";
            this.colLateMinutes.LayoutViewField = this.layoutViewField_colLateMinutes;
            this.colLateMinutes.Name = "colLateMinutes";
            // 
            // repositoryItemSpinEdit
            // 
            this.repositoryItemSpinEdit.AutoHeight = false;
            this.repositoryItemSpinEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit.Mask.EditMask = "\\d{0,5}";
            this.repositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repositoryItemSpinEdit.Name = "repositoryItemSpinEdit";
            // 
            // layoutViewField_colLateMinutes
            // 
            this.layoutViewField_colLateMinutes.EditorPreferredWidth = 73;
            this.layoutViewField_colLateMinutes.Location = new System.Drawing.Point(0, 72);
            this.layoutViewField_colLateMinutes.Name = "layoutViewField_colLateMinutes";
            this.layoutViewField_colLateMinutes.Size = new System.Drawing.Size(180, 24);
            this.layoutViewField_colLateMinutes.TextSize = new System.Drawing.Size(98, 14);
            this.layoutViewField_colLateMinutes.TextToControlDistance = 5;
            // 
            // colEarlyMinutes
            // 
            this.colEarlyMinutes.Caption = "记早退时间(分钟)";
            this.colEarlyMinutes.ColumnEdit = this.repositoryItemSpinEdit;
            this.colEarlyMinutes.FieldName = "EarlyMinutes";
            this.colEarlyMinutes.LayoutViewField = this.layoutViewField_colEarlyMinutes;
            this.colEarlyMinutes.Name = "colEarlyMinutes";
            // 
            // layoutViewField_colEarlyMinutes
            // 
            this.layoutViewField_colEarlyMinutes.EditorPreferredWidth = 73;
            this.layoutViewField_colEarlyMinutes.Location = new System.Drawing.Point(0, 96);
            this.layoutViewField_colEarlyMinutes.Name = "layoutViewField_colEarlyMinutes";
            this.layoutViewField_colEarlyMinutes.Size = new System.Drawing.Size(180, 24);
            this.layoutViewField_colEarlyMinutes.TextSize = new System.Drawing.Size(98, 14);
            this.layoutViewField_colEarlyMinutes.TextToControlDistance = 5;
            // 
            // colCheckInStartTime
            // 
            this.colCheckInStartTime.Caption = "开始签到时间";
            this.colCheckInStartTime.ColumnEdit = this.repositoryItemTimeEdit;
            this.colCheckInStartTime.DisplayFormat.FormatString = "t";
            this.colCheckInStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCheckInStartTime.FieldName = "CheckInStartTime";
            this.colCheckInStartTime.LayoutViewField = this.layoutViewField_colCheckInStartTime;
            this.colCheckInStartTime.Name = "colCheckInStartTime";
            // 
            // layoutViewField_colCheckInStartTime
            // 
            this.layoutViewField_colCheckInStartTime.EditorPreferredWidth = 73;
            this.layoutViewField_colCheckInStartTime.Location = new System.Drawing.Point(0, 120);
            this.layoutViewField_colCheckInStartTime.Name = "layoutViewField_colCheckInStartTime";
            this.layoutViewField_colCheckInStartTime.Size = new System.Drawing.Size(180, 24);
            this.layoutViewField_colCheckInStartTime.TextSize = new System.Drawing.Size(98, 14);
            this.layoutViewField_colCheckInStartTime.TextToControlDistance = 5;
            // 
            // colCheckInEndTime
            // 
            this.colCheckInEndTime.Caption = "结束签到时间";
            this.colCheckInEndTime.ColumnEdit = this.repositoryItemTimeEdit;
            this.colCheckInEndTime.DisplayFormat.FormatString = "t";
            this.colCheckInEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCheckInEndTime.FieldName = "CheckInEndTime";
            this.colCheckInEndTime.LayoutViewField = this.layoutViewField_colCheckInEndTime;
            this.colCheckInEndTime.Name = "colCheckInEndTime";
            // 
            // layoutViewField_colCheckInEndTime
            // 
            this.layoutViewField_colCheckInEndTime.EditorPreferredWidth = 73;
            this.layoutViewField_colCheckInEndTime.Location = new System.Drawing.Point(0, 144);
            this.layoutViewField_colCheckInEndTime.Name = "layoutViewField_colCheckInEndTime";
            this.layoutViewField_colCheckInEndTime.Size = new System.Drawing.Size(180, 24);
            this.layoutViewField_colCheckInEndTime.TextSize = new System.Drawing.Size(98, 14);
            this.layoutViewField_colCheckInEndTime.TextToControlDistance = 5;
            // 
            // colCheckOutStartTime
            // 
            this.colCheckOutStartTime.Caption = "开始签退时间";
            this.colCheckOutStartTime.ColumnEdit = this.repositoryItemTimeEdit;
            this.colCheckOutStartTime.DisplayFormat.FormatString = "t";
            this.colCheckOutStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCheckOutStartTime.FieldName = "CheckOutStartTime";
            this.colCheckOutStartTime.LayoutViewField = this.layoutViewField_colCheckOutStartTime;
            this.colCheckOutStartTime.Name = "colCheckOutStartTime";
            // 
            // layoutViewField_colCheckOutStartTime
            // 
            this.layoutViewField_colCheckOutStartTime.EditorPreferredWidth = 73;
            this.layoutViewField_colCheckOutStartTime.Location = new System.Drawing.Point(0, 168);
            this.layoutViewField_colCheckOutStartTime.Name = "layoutViewField_colCheckOutStartTime";
            this.layoutViewField_colCheckOutStartTime.Size = new System.Drawing.Size(180, 24);
            this.layoutViewField_colCheckOutStartTime.TextSize = new System.Drawing.Size(98, 14);
            this.layoutViewField_colCheckOutStartTime.TextToControlDistance = 5;
            // 
            // colCheckOutEndTime
            // 
            this.colCheckOutEndTime.Caption = "结束签退时间";
            this.colCheckOutEndTime.ColumnEdit = this.repositoryItemTimeEdit;
            this.colCheckOutEndTime.DisplayFormat.FormatString = "t";
            this.colCheckOutEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCheckOutEndTime.FieldName = "CheckOutEndTime";
            this.colCheckOutEndTime.LayoutViewField = this.layoutViewField_colCheckOutEndTime;
            this.colCheckOutEndTime.Name = "colCheckOutEndTime";
            // 
            // layoutViewField_colCheckOutEndTime
            // 
            this.layoutViewField_colCheckOutEndTime.EditorPreferredWidth = 73;
            this.layoutViewField_colCheckOutEndTime.Location = new System.Drawing.Point(0, 192);
            this.layoutViewField_colCheckOutEndTime.Name = "layoutViewField_colCheckOutEndTime";
            this.layoutViewField_colCheckOutEndTime.Size = new System.Drawing.Size(180, 24);
            this.layoutViewField_colCheckOutEndTime.TextSize = new System.Drawing.Size(98, 14);
            this.layoutViewField_colCheckOutEndTime.TextToControlDistance = 5;
            // 
            // colColor
            // 
            this.colColor.Caption = "时段颜色";
            this.colColor.ColumnEdit = this.repositoryItemSchColor;
            this.colColor.FieldName = "Color";
            this.colColor.LayoutViewField = this.layoutViewField_colColor;
            this.colColor.Name = "colColor";
            // 
            // repositoryItemSchColor
            // 
            this.repositoryItemSchColor.AutoHeight = false;
            this.repositoryItemSchColor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSchColor.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemSchColor.Name = "repositoryItemSchColor";
            this.repositoryItemSchColor.StoreColorAsInteger = true;
            // 
            // layoutViewField_colColor
            // 
            this.layoutViewField_colColor.EditorPreferredWidth = 73;
            this.layoutViewField_colColor.Location = new System.Drawing.Point(0, 216);
            this.layoutViewField_colColor.Name = "layoutViewField_colColor";
            this.layoutViewField_colColor.Size = new System.Drawing.Size(180, 24);
            this.layoutViewField_colColor.TextSize = new System.Drawing.Size(98, 14);
            this.layoutViewField_colColor.TextToControlDistance = 5;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_colName,
            this.layoutViewField_colStartTime,
            this.layoutViewField_colEndTime,
            this.layoutViewField_colLateMinutes,
            this.layoutViewField_colEarlyMinutes,
            this.layoutViewField_colCheckInStartTime,
            this.layoutViewField_colCheckInEndTime,
            this.layoutViewField_colCheckOutStartTime,
            this.layoutViewField_colCheckOutEndTime,
            this.layoutViewField_colColor});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 5;
            this.layoutViewCard1.Text = "TemplateCard";
            this.layoutViewCard1.TextVisible = false;
            // 
            // SchClassPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Name = "SchClassPage";
            this.Size = new System.Drawing.Size(640, 480);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schClassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colLateMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colEarlyMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCheckInStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCheckInEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCheckOutStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCheckOutEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSchColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView;
        private System.Windows.Forms.BindingSource schClassBindingSource;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colID;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colName;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colStartTime;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colEndTime;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colLateMinutes;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colEarlyMinutes;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colCheckInStartTime;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colCheckInEndTime;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colCheckOutStartTime;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colCheckOutEndTime;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemTimeEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemSchColor;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colID;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colName;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colStartTime;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colEndTime;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colLateMinutes;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colEarlyMinutes;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colCheckInStartTime;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colCheckInEndTime;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colCheckOutStartTime;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colCheckOutEndTime;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colColor;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
    }
}
