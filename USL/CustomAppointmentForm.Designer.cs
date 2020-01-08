namespace USL
{
    partial class CustomAppointmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomAppointmentForm));
            this.lueGoods = new DevExpress.XtraEditors.LookUpEdit();
            this.goodsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtNWeight = new DevExpress.XtraEditors.TextEdit();
            this.lblNWeight = new DevExpress.XtraEditors.LabelControl();
            this.lblCycle = new DevExpress.XtraEditors.LabelControl();
            this.txtCycle = new DevExpress.XtraEditors.TextEdit();
            this.gcTotal = new DevExpress.XtraEditors.GroupControl();
            this.txtPlanYield = new DevExpress.XtraEditors.TextEdit();
            this.lblYielded = new DevExpress.XtraEditors.LabelControl();
            this.txtYielded = new DevExpress.XtraEditors.TextEdit();
            this.lblPlanYield = new DevExpress.XtraEditors.LabelControl();
            this.lblWeight = new DevExpress.XtraEditors.LabelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.wageDesignBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.focusCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWages = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.seManHour = new DevExpress.XtraEditors.SpinEdit();
            this.lblManHour = new DevExpress.XtraEditors.LabelControl();
            this.txtWeight = new DevExpress.XtraEditors.TextEdit();
            this.lblRemark = new DevExpress.XtraEditors.LabelControl();
            this.pePic = new DevExpress.XtraEditors.PictureEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.lueGoods.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCycle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTotal)).BeginInit();
            this.gcTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanYield.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYielded.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wageDesignBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusCheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seManHour.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pePic.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSubject
            // 
            this.lblSubject.Size = new System.Drawing.Size(28, 14);
            this.lblSubject.Text = "产品:";
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(25, 209);
            this.lblLocation.Size = new System.Drawing.Size(52, 14);
            this.lblLocation.Text = "当班金额:";
            // 
            // lblLabel
            // 
            this.lblLabel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblLabel.Location = new System.Drawing.Point(3, 3);
            this.lblLabel.Size = new System.Drawing.Size(28, 14);
            this.lblLabel.Text = "机器:";
            // 
            // lblStartTime
            // 
            this.lblStartTime.Location = new System.Drawing.Point(95, 248);
            this.lblStartTime.Visible = false;
            // 
            // lblEndTime
            // 
            this.lblEndTime.Location = new System.Drawing.Point(95, 275);
            this.lblEndTime.Visible = false;
            // 
            // lblShowTimeAs
            // 
            this.lblShowTimeAs.Location = new System.Drawing.Point(19, 73);
            this.lblShowTimeAs.Size = new System.Drawing.Size(28, 14);
            this.lblShowTimeAs.Text = "班次:";
            // 
            // chkAllDay
            // 
            this.chkAllDay.Location = new System.Drawing.Point(7, 80);
            this.chkAllDay.Visible = false;
            // 
            // edtStartDate
            // 
            this.edtStartDate.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.edtStartDate.Location = new System.Drawing.Point(160, 244);
            this.edtStartDate.Visible = false;
            // 
            // edtEndDate
            // 
            this.edtEndDate.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.edtEndDate.Location = new System.Drawing.Point(160, 271);
            this.edtEndDate.Visible = false;
            // 
            // edtStartTime
            // 
            this.edtStartTime.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.edtStartTime.Location = new System.Drawing.Point(309, 245);
            // 
            // edtEndTime
            // 
            this.edtEndTime.EditValue = new System.DateTime(2005, 3, 31, 0, 0, 0, 0);
            this.edtEndTime.Location = new System.Drawing.Point(309, 271);
            // 
            // edtLabel
            // 
            this.edtLabel.EnterMoveNextControl = true;
            this.edtLabel.Location = new System.Drawing.Point(68, 3);
            this.edtLabel.Size = new System.Drawing.Size(140, 20);
            this.edtLabel.TabIndex = 8;
            // 
            // edtShowTimeAs
            // 
            this.edtShowTimeAs.EnterMoveNextControl = true;
            this.edtShowTimeAs.Location = new System.Drawing.Point(84, 70);
            this.edtShowTimeAs.Size = new System.Drawing.Size(140, 20);
            this.edtShowTimeAs.TabIndex = 6;
            // 
            // tbSubject
            // 
            this.tbSubject.Enabled = false;
            this.tbSubject.EnterMoveNextControl = true;
            this.tbSubject.Location = new System.Drawing.Point(233, 16);
            this.tbSubject.Size = new System.Drawing.Size(262, 20);
            this.tbSubject.TabIndex = 2;
            // 
            // edtResource
            // 
            this.edtResource.Location = new System.Drawing.Point(80, 60);
            this.edtResource.Size = new System.Drawing.Size(131, 20);
            // 
            // lblResource
            // 
            this.lblResource.Location = new System.Drawing.Point(2, 63);
            // 
            // edtResources
            // 
            this.edtResources.Location = new System.Drawing.Point(80, 60);
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
            this.chkReminder.Location = new System.Drawing.Point(3, 29);
            // 
            // tbDescription
            // 
            this.tbDescription.EnterMoveNextControl = true;
            this.tbDescription.Location = new System.Drawing.Point(84, 271);
            this.tbDescription.Size = new System.Drawing.Size(514, 66);
            this.tbDescription.TabIndex = 11;
            // 
            // cbReminder
            // 
            this.cbReminder.EnterMoveNextControl = true;
            this.cbReminder.Location = new System.Drawing.Point(68, 29);
            this.cbReminder.Size = new System.Drawing.Size(140, 20);
            this.cbReminder.TabIndex = 9;
            // 
            // tbLocation
            // 
            this.tbLocation.EnterMoveNextControl = true;
            this.tbLocation.Location = new System.Drawing.Point(87, 206);
            this.tbLocation.Properties.Mask.EditMask = "f";
            this.tbLocation.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbLocation.Size = new System.Drawing.Size(137, 20);
            this.tbLocation.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(16, 93);
            this.panel1.Size = new System.Drawing.Size(211, 54);
            // 
            // progressPanel
            // 
            this.progressPanel.Location = new System.Drawing.Point(95, 297);
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
            // lueGoods
            // 
            this.lueGoods.EnterMoveNextControl = true;
            this.lueGoods.Location = new System.Drawing.Point(84, 16);
            this.lueGoods.Name = "lueGoods";
            this.lueGoods.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.lueGoods.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGoods.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "代码", 38, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "名称", 41, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Cycle", "计算周期", 38, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NWeight", "净重", 58, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Unit", "单位", 32, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SPEC", "规格", 38, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Price", "单价", 36, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far)});
            this.lueGoods.Properties.DataSource = this.goodsBindingSource;
            this.lueGoods.Properties.DisplayMember = "Code";
            this.lueGoods.Properties.DropDownRows = 15;
            this.lueGoods.Properties.NullText = "";
            this.lueGoods.Properties.PopupWidth = 500;
            this.lueGoods.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lueGoods.Properties.ValueMember = "ID";
            this.lueGoods.Size = new System.Drawing.Size(140, 20);
            this.lueGoods.TabIndex = 1;
            this.lueGoods.EditValueChanged += new System.EventHandler(this.lueGoods_EditValueChanged);
            // 
            // goodsBindingSource
            // 
            this.goodsBindingSource.DataSource = typeof(EDMX.Goods);
            // 
            // txtNWeight
            // 
            this.txtNWeight.Enabled = false;
            this.txtNWeight.EnterMoveNextControl = true;
            this.txtNWeight.Location = new System.Drawing.Point(289, 44);
            this.txtNWeight.Name = "txtNWeight";
            this.txtNWeight.Properties.Mask.EditMask = "n";
            this.txtNWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNWeight.Size = new System.Drawing.Size(60, 20);
            this.txtNWeight.TabIndex = 4;
            this.txtNWeight.EditValueChanged += new System.EventHandler(this.txtNWeight_EditValueChanged);
            // 
            // lblNWeight
            // 
            this.lblNWeight.Location = new System.Drawing.Point(233, 47);
            this.lblNWeight.Name = "lblNWeight";
            this.lblNWeight.Size = new System.Drawing.Size(50, 14);
            this.lblNWeight.TabIndex = 31;
            this.lblNWeight.Text = "净重(克):";
            // 
            // lblCycle
            // 
            this.lblCycle.Location = new System.Drawing.Point(355, 47);
            this.lblCycle.Name = "lblCycle";
            this.lblCycle.Size = new System.Drawing.Size(74, 14);
            this.lblCycle.TabIndex = 33;
            this.lblCycle.Text = "计算周期(秒):";
            // 
            // txtCycle
            // 
            this.txtCycle.Enabled = false;
            this.txtCycle.EnterMoveNextControl = true;
            this.txtCycle.Location = new System.Drawing.Point(435, 44);
            this.txtCycle.Name = "txtCycle";
            this.txtCycle.Properties.Mask.EditMask = "n";
            this.txtCycle.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCycle.Size = new System.Drawing.Size(60, 20);
            this.txtCycle.TabIndex = 5;
            this.txtCycle.EditValueChanged += new System.EventHandler(this.txtCycle_EditValueChanged);
            // 
            // gcTotal
            // 
            this.gcTotal.Controls.Add(this.txtPlanYield);
            this.gcTotal.Controls.Add(this.lblYielded);
            this.gcTotal.Controls.Add(this.txtYielded);
            this.gcTotal.Controls.Add(this.lblPlanYield);
            this.gcTotal.Location = new System.Drawing.Point(19, 148);
            this.gcTotal.Name = "gcTotal";
            this.gcTotal.ShowCaption = false;
            this.gcTotal.Size = new System.Drawing.Size(208, 84);
            this.gcTotal.TabIndex = 42;
            this.gcTotal.Text = "合计";
            // 
            // txtPlanYield
            // 
            this.txtPlanYield.Location = new System.Drawing.Point(68, 5);
            this.txtPlanYield.Name = "txtPlanYield";
            this.txtPlanYield.Properties.ReadOnly = true;
            this.txtPlanYield.Size = new System.Drawing.Size(137, 20);
            this.txtPlanYield.TabIndex = 48;
            // 
            // lblYielded
            // 
            this.lblYielded.Location = new System.Drawing.Point(6, 34);
            this.lblYielded.Name = "lblYielded";
            this.lblYielded.Size = new System.Drawing.Size(52, 14);
            this.lblYielded.TabIndex = 45;
            this.lblYielded.Text = "实产模数:";
            // 
            // txtYielded
            // 
            this.txtYielded.Location = new System.Drawing.Point(68, 31);
            this.txtYielded.Name = "txtYielded";
            this.txtYielded.Properties.ReadOnly = true;
            this.txtYielded.Size = new System.Drawing.Size(137, 20);
            this.txtYielded.TabIndex = 44;
            // 
            // lblPlanYield
            // 
            this.lblPlanYield.Location = new System.Drawing.Point(6, 8);
            this.lblPlanYield.Name = "lblPlanYield";
            this.lblPlanYield.Size = new System.Drawing.Size(52, 14);
            this.lblPlanYield.TabIndex = 43;
            this.lblPlanYield.Text = "应产模数:";
            // 
            // lblWeight
            // 
            this.lblWeight.Location = new System.Drawing.Point(18, 47);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(50, 14);
            this.lblWeight.TabIndex = 47;
            this.lblWeight.Text = "重量(斤):";
            // 
            // gridControl
            // 
            this.gridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl.DataSource = this.wageDesignBindingSource;
            this.gridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl.Location = new System.Drawing.Point(233, 93);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit,
            this.focusCheckEdit});
            this.gridControl.Size = new System.Drawing.Size(365, 139);
            this.gridControl.TabIndex = 43;
            this.gridControl.UseEmbeddedNavigator = true;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // wageDesignBindingSource
            // 
            this.wageDesignBindingSource.DataSource = typeof(EDMX.WageDesign);
            // 
            // gridView
            // 
            this.gridView.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView.Appearance.FilterPanel.Options.UseFont = true;
            this.gridView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView.Appearance.GroupFooter.Options.UseFont = true;
            this.gridView.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView.Appearance.GroupRow.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView.AppearancePrint.FilterPanel.Options.UseFont = true;
            this.gridView.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridView.AppearancePrint.FooterPanel.Options.UseBackColor = true;
            this.gridView.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.gridView.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridView.AppearancePrint.GroupFooter.Options.UseBackColor = true;
            this.gridView.AppearancePrint.GroupFooter.Options.UseFont = true;
            this.gridView.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView.AppearancePrint.GroupRow.Options.UseFont = true;
            this.gridView.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridView.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridView.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridView.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView.AppearancePrint.Row.Options.UseFont = true;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCheck,
            this.colName,
            this.colWages,
            this.colPrice,
            this.colManHour,
            this.colErrorRate,
            this.colRemark});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsFind.FindNullPrompt = "请输入查找内容...";
            this.gridView.OptionsFind.ShowCloseButton = false;
            this.gridView.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView.OptionsPrint.AutoWidth = false;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView.OptionsView.EnableAppearanceOddRow = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView_CustomUnboundColumnData);
            this.gridView.Click += new System.EventHandler(this.gridView_Click);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colCheck
            // 
            this.colCheck.Caption = " ";
            this.colCheck.ColumnEdit = this.focusCheckEdit;
            this.colCheck.FieldName = "colCheck";
            this.colCheck.Name = "colCheck";
            this.colCheck.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colCheck.Visible = true;
            this.colCheck.VisibleIndex = 0;
            this.colCheck.Width = 30;
            // 
            // focusCheckEdit
            // 
            this.focusCheckEdit.AutoHeight = false;
            this.focusCheckEdit.Caption = "Check";
            this.focusCheckEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.focusCheckEdit.Name = "focusCheckEdit";
            // 
            // colName
            // 
            this.colName.Caption = "工资方案";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colWages
            // 
            this.colWages.Caption = "工价";
            this.colWages.FieldName = "Wages";
            this.colWages.Name = "colWages";
            this.colWages.Visible = true;
            this.colWages.VisibleIndex = 2;
            this.colWages.Width = 60;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "计件单价";
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 3;
            // 
            // colManHour
            // 
            this.colManHour.Caption = "工时";
            this.colManHour.FieldName = "ManHour";
            this.colManHour.Name = "colManHour";
            this.colManHour.Visible = true;
            this.colManHour.VisibleIndex = 4;
            this.colManHour.Width = 50;
            // 
            // colErrorRate
            // 
            this.colErrorRate.Caption = "误差率";
            this.colErrorRate.FieldName = "ErrorRate";
            this.colErrorRate.Name = "colErrorRate";
            this.colErrorRate.Visible = true;
            this.colErrorRate.VisibleIndex = 5;
            this.colErrorRate.Width = 50;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            // 
            // repositoryItemPictureEdit
            // 
            this.repositoryItemPictureEdit.Name = "repositoryItemPictureEdit";
            // 
            // seManHour
            // 
            this.seManHour.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seManHour.EnterMoveNextControl = true;
            this.seManHour.Location = new System.Drawing.Point(289, 70);
            this.seManHour.Name = "seManHour";
            this.seManHour.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seManHour.Properties.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.seManHour.Properties.Mask.EditMask = "n1";
            this.seManHour.Properties.MaxValue = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.seManHour.Size = new System.Drawing.Size(60, 20);
            this.seManHour.TabIndex = 7;
            this.seManHour.EditValueChanged += new System.EventHandler(this.seManHour_EditValueChanged);
            // 
            // lblManHour
            // 
            this.lblManHour.Location = new System.Drawing.Point(233, 73);
            this.lblManHour.Name = "lblManHour";
            this.lblManHour.Size = new System.Drawing.Size(28, 14);
            this.lblManHour.TabIndex = 45;
            this.lblManHour.Text = "工时:";
            // 
            // txtWeight
            // 
            this.txtWeight.Enabled = false;
            this.txtWeight.Location = new System.Drawing.Point(84, 44);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Properties.Mask.EditMask = "n";
            this.txtWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtWeight.Size = new System.Drawing.Size(140, 20);
            this.txtWeight.TabIndex = 3;
            this.txtWeight.EditValueChanged += new System.EventHandler(this.txtWeight_EditValueChanged);
            // 
            // lblRemark
            // 
            this.lblRemark.Location = new System.Drawing.Point(19, 275);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(28, 14);
            this.lblRemark.TabIndex = 48;
            this.lblRemark.Text = "备注:";
            // 
            // pePic
            // 
            this.pePic.Location = new System.Drawing.Point(501, 12);
            this.pePic.Name = "pePic";
            this.pePic.Properties.ReadOnly = true;
            this.pePic.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pePic.Size = new System.Drawing.Size(97, 78);
            this.pePic.TabIndex = 49;
            this.pePic.ToolTip = "鼠标双击显示图片";
            this.pePic.DoubleClick += new System.EventHandler(this.pePic_DoubleClick);
            // 
            // CustomAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(616, 411);
            this.Controls.Add(this.pePic);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.lblManHour);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.seManHour);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.gcTotal);
            this.Controls.Add(this.lblCycle);
            this.Controls.Add(this.txtCycle);
            this.Controls.Add(this.lblNWeight);
            this.Controls.Add(this.txtNWeight);
            this.Controls.Add(this.lueGoods);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(602, 328);
            this.Name = "CustomAppointmentForm";
            this.Controls.SetChildIndex(this.lueGoods, 0);
            this.Controls.SetChildIndex(this.txtNWeight, 0);
            this.Controls.SetChildIndex(this.lblNWeight, 0);
            this.Controls.SetChildIndex(this.txtCycle, 0);
            this.Controls.SetChildIndex(this.lblCycle, 0);
            this.Controls.SetChildIndex(this.gcTotal, 0);
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
            this.Controls.SetChildIndex(this.progressPanel, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.seManHour, 0);
            this.Controls.SetChildIndex(this.lblWeight, 0);
            this.Controls.SetChildIndex(this.lblManHour, 0);
            this.Controls.SetChildIndex(this.txtWeight, 0);
            this.Controls.SetChildIndex(this.lblRemark, 0);
            this.Controls.SetChildIndex(this.pePic, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.lueGoods.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCycle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTotal)).EndInit();
            this.gcTotal.ResumeLayout(false);
            this.gcTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanYield.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYielded.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wageDesignBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusCheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seManHour.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pePic.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lueGoods;
        private System.Windows.Forms.BindingSource goodsBindingSource;
        private DevExpress.XtraEditors.TextEdit txtNWeight;
        private DevExpress.XtraEditors.LabelControl lblNWeight;
        private DevExpress.XtraEditors.LabelControl lblCycle;
        private DevExpress.XtraEditors.TextEdit txtCycle;
        private DevExpress.XtraEditors.GroupControl gcTotal;
        private DevExpress.XtraEditors.LabelControl lblWeight;
        private DevExpress.XtraEditors.LabelControl lblYielded;
        private DevExpress.XtraEditors.TextEdit txtYielded;
        private DevExpress.XtraEditors.LabelControl lblPlanYield;
        private DevExpress.XtraGrid.GridControl gridControl;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit;
        private DevExpress.XtraEditors.TextEdit txtPlanYield;
        private System.Windows.Forms.BindingSource wageDesignBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colWages;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colManHour;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorRate;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colCheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit focusCheckEdit;
        private DevExpress.XtraEditors.SpinEdit seManHour;
        private DevExpress.XtraEditors.LabelControl lblManHour;
        private DevExpress.XtraEditors.TextEdit txtWeight;
        private DevExpress.XtraEditors.LabelControl lblRemark;
        private DevExpress.XtraEditors.PictureEdit pePic;
    }
}
