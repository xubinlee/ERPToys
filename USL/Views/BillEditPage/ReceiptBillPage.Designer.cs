namespace USL
{
    partial class ReceiptBillPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptBillPage));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.meUnReceiptedAMT = new DevExpress.XtraEditors.TextEdit();
            this.receiptBillHdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.meReceiptedAM = new DevExpress.XtraEditors.TextEdit();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrev = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.vReceiptBillDtlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imageListCheck = new System.Windows.Forms.ImageList(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCheckItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMainMark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillAMT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceiptedAMT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnReceiptedAMT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastReceiptedAMT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueBusinessContact = new DevExpress.XtraEditors.LookUpEdit();
            this.businessContactBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lueBillType = new DevExpress.XtraEditors.LookUpEdit();
            this.billTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lueWarehouse = new DevExpress.XtraEditors.LookUpEdit();
            this.deAuditDate = new DevExpress.XtraEditors.DateEdit();
            this.deMakeDate = new DevExpress.XtraEditors.DateEdit();
            this.meRemark = new DevExpress.XtraEditors.MemoEdit();
            this.txtContacts = new DevExpress.XtraEditors.TextEdit();
            this.deBillDate = new DevExpress.XtraEditors.DateEdit();
            this.txtBillNo = new DevExpress.XtraEditors.TextEdit();
            this.lblWarehouse = new DevExpress.XtraEditors.LabelControl();
            this.lueMaker = new DevExpress.XtraEditors.LookUpEdit();
            this.vUsersInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lueAuditor = new DevExpress.XtraEditors.LookUpEdit();
            this.luePOClear = new DevExpress.XtraEditors.LookUpEdit();
            this.pOClearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.meBalance = new DevExpress.XtraEditors.TextEdit();
            this.meLastAMT = new DevExpress.XtraEditors.TextEdit();
            this.meTotalAMT = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciBillNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBillDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPOClear = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciContacts = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciMaker = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciMakeDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciAuditor = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciAuditDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciRemark = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBillType = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBusinessContact = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBalance = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciLastAMT = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTotalAMT = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciReceiptedAM = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciUnReceiptedAMT = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPrev = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNext = new DevExpress.XtraLayout.LayoutControlItem();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerBottom = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dpSOA = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcSOA = new DevExpress.XtraGrid.GridControl();
            this.statementOfAccountToCustomerReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvSOA = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col收款单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col收款日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col状态 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col客户代码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col客户名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col客户类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col结算类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col出库日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col货号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col正唛 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col品名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col箱数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col装箱数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col内盒 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col总数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col单价 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col额外费用 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col应收金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col折扣 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col实收金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col包装方式 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col外箱规格 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meUnReceiptedAMT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptBillHdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meReceiptedAM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vReceiptBillDtlBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBusinessContact.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessContactBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBillType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deAuditDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deAuditDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMakeDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMakeDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContacts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBillDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBillDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vUsersInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAuditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePOClear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOClearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meLastAMT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meTotalAMT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBillNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBillDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPOClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciContacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMaker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMakeDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAuditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAuditDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBillType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBusinessContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLastAMT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTotalAMT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciReceiptedAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUnReceiptedAMT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.hideContainerBottom.SuspendLayout();
            this.dpSOA.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSOA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statementOfAccountToCustomerReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSOA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // colStatus
            // 
            this.colStatus.Caption = "状态";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.meUnReceiptedAMT);
            this.layoutControl.Controls.Add(this.meReceiptedAM);
            this.layoutControl.Controls.Add(this.btnNext);
            this.layoutControl.Controls.Add(this.btnPrev);
            this.layoutControl.Controls.Add(this.gridControl);
            this.layoutControl.Controls.Add(this.lueBusinessContact);
            this.layoutControl.Controls.Add(this.lueBillType);
            this.layoutControl.Controls.Add(this.lueWarehouse);
            this.layoutControl.Controls.Add(this.deAuditDate);
            this.layoutControl.Controls.Add(this.deMakeDate);
            this.layoutControl.Controls.Add(this.meRemark);
            this.layoutControl.Controls.Add(this.txtContacts);
            this.layoutControl.Controls.Add(this.deBillDate);
            this.layoutControl.Controls.Add(this.txtBillNo);
            this.layoutControl.Controls.Add(this.lblWarehouse);
            this.layoutControl.Controls.Add(this.lueMaker);
            this.layoutControl.Controls.Add(this.lueAuditor);
            this.layoutControl.Controls.Add(this.luePOClear);
            this.layoutControl.Controls.Add(this.meBalance);
            this.layoutControl.Controls.Add(this.meLastAMT);
            this.layoutControl.Controls.Add(this.meTotalAMT);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7,
            this.layoutControlItem17});
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(674, 351, 371, 523);
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(640, 460);
            this.layoutControl.TabIndex = 3;
            this.layoutControl.Text = "layoutControl1";
            // 
            // meUnReceiptedAMT
            // 
            this.meUnReceiptedAMT.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBillHdBindingSource, "UnReceiptedAMT", true));
            this.meUnReceiptedAMT.Location = new System.Drawing.Point(547, 187);
            this.meUnReceiptedAMT.Name = "meUnReceiptedAMT";
            this.meUnReceiptedAMT.Properties.Mask.EditMask = "c";
            this.meUnReceiptedAMT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.meUnReceiptedAMT.Size = new System.Drawing.Size(50, 20);
            this.meUnReceiptedAMT.StyleController = this.layoutControl;
            this.meUnReceiptedAMT.TabIndex = 17;
            // 
            // receiptBillHdBindingSource
            // 
            this.receiptBillHdBindingSource.DataSource = typeof(DBML.ReceiptBillHd);
            // 
            // meReceiptedAM
            // 
            this.meReceiptedAM.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBillHdBindingSource, "ReceiptedAMT", true));
            this.meReceiptedAM.Location = new System.Drawing.Point(440, 187);
            this.meReceiptedAM.Name = "meReceiptedAM";
            this.meReceiptedAM.Properties.Mask.EditMask = "c";
            this.meReceiptedAM.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.meReceiptedAM.Size = new System.Drawing.Size(50, 20);
            this.meReceiptedAM.StyleController = this.layoutControl;
            this.meReceiptedAM.TabIndex = 16;
            this.meReceiptedAM.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.meReceiptedAM_EditValueChanging);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(613, 12);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(26, 419);
            this.btnNext.StyleController = this.layoutControl;
            this.btnNext.TabIndex = 19;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(12, 12);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(26, 419);
            this.btnPrev.StyleController = this.layoutControl;
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "<";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // gridControl
            // 
            this.gridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl.DataSource = this.vReceiptBillDtlBindingSource;
            this.gridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.ImageList = this.imageListCheck;
            this.gridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 0, true, true, "全选", "CheckAll"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 1, true, true, "取消选中", "CheckAllDelete")});
            this.gridControl.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl_EmbeddedNavigator_ButtonClick);
            this.gridControl.Location = new System.Drawing.Point(54, 211);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(543, 208);
            this.gridControl.TabIndex = 18;
            this.gridControl.UseEmbeddedNavigator = true;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // vReceiptBillDtlBindingSource
            // 
            this.vReceiptBillDtlBindingSource.DataSource = typeof(DBML.VReceiptBillDtl);
            // 
            // imageListCheck
            // 
            this.imageListCheck.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCheck.ImageStream")));
            this.imageListCheck.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListCheck.Images.SetKeyName(0, "input_checked_32px.png");
            this.imageListCheck.Images.SetKeyName(1, "checkbox_unchecked_32px.png");
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
            this.gridView.AppearancePrint.FilterPanel.BorderColor = System.Drawing.Color.Black;
            this.gridView.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.gridView.AppearancePrint.FilterPanel.Options.UseBorderColor = true;
            this.gridView.AppearancePrint.FilterPanel.Options.UseFont = true;
            this.gridView.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black;
            this.gridView.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold);
            this.gridView.AppearancePrint.FooterPanel.Options.UseBackColor = true;
            this.gridView.AppearancePrint.FooterPanel.Options.UseBorderColor = true;
            this.gridView.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.gridView.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black;
            this.gridView.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold);
            this.gridView.AppearancePrint.GroupFooter.Options.UseBackColor = true;
            this.gridView.AppearancePrint.GroupFooter.Options.UseBorderColor = true;
            this.gridView.AppearancePrint.GroupFooter.Options.UseFont = true;
            this.gridView.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black;
            this.gridView.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.gridView.AppearancePrint.GroupRow.Options.UseBorderColor = true;
            this.gridView.AppearancePrint.GroupRow.Options.UseFont = true;
            this.gridView.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black;
            this.gridView.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold);
            this.gridView.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridView.AppearancePrint.HeaderPanel.Options.UseBorderColor = true;
            this.gridView.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridView.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black;
            this.gridView.AppearancePrint.Row.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F);
            this.gridView.AppearancePrint.Row.Options.UseBorderColor = true;
            this.gridView.AppearancePrint.Row.Options.UseFont = true;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCheckItem,
            this.colBillID,
            this.colCompanyID,
            this.colSupplierID,
            this.colBillNo,
            this.colMainMark,
            this.colBillDate,
            this.colType,
            this.colQty,
            this.colBillAMT,
            this.colReceiptedAMT,
            this.colUnReceiptedAMT,
            this.colLastReceiptedAMT,
            this.colStatus,
            this.colRemark});
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colStatus;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = 3;
            this.gridView.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsFind.FindNullPrompt = "请输入查找内容...";
            this.gridView.OptionsFind.ShowCloseButton = false;
            this.gridView.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridView.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView.OptionsView.EnableAppearanceOddRow = true;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_CellValueChanged);
            this.gridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView_CustomUnboundColumnData);
            this.gridView.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView_CustomColumnDisplayText);
            // 
            // colCheckItem
            // 
            this.colCheckItem.Caption = "勾选";
            this.colCheckItem.FieldName = "CheckItem";
            this.colCheckItem.Name = "colCheckItem";
            this.colCheckItem.Visible = true;
            this.colCheckItem.VisibleIndex = 0;
            // 
            // colBillID
            // 
            this.colBillID.FieldName = "BillID";
            this.colBillID.Name = "colBillID";
            // 
            // colCompanyID
            // 
            this.colCompanyID.FieldName = "CompanyID";
            this.colCompanyID.Name = "colCompanyID";
            // 
            // colSupplierID
            // 
            this.colSupplierID.FieldName = "SupplierID";
            this.colSupplierID.Name = "colSupplierID";
            // 
            // colBillNo
            // 
            this.colBillNo.Caption = "单据编号";
            this.colBillNo.FieldName = "BillNo";
            this.colBillNo.Name = "colBillNo";
            this.colBillNo.OptionsColumn.AllowEdit = false;
            this.colBillNo.OptionsColumn.ReadOnly = true;
            this.colBillNo.Visible = true;
            this.colBillNo.VisibleIndex = 1;
            this.colBillNo.Width = 300;
            // 
            // colMainMark
            // 
            this.colMainMark.Caption = "正唛";
            this.colMainMark.FieldName = "MainMark";
            this.colMainMark.Name = "colMainMark";
            this.colMainMark.OptionsColumn.AllowEdit = false;
            this.colMainMark.OptionsColumn.ReadOnly = true;
            this.colMainMark.Visible = true;
            this.colMainMark.VisibleIndex = 2;
            // 
            // colBillDate
            // 
            this.colBillDate.Caption = "出库日期";
            this.colBillDate.FieldName = "BillDate";
            this.colBillDate.Name = "colBillDate";
            this.colBillDate.OptionsColumn.AllowEdit = false;
            this.colBillDate.OptionsColumn.ReadOnly = true;
            this.colBillDate.Visible = true;
            this.colBillDate.VisibleIndex = 3;
            // 
            // colType
            // 
            this.colType.Caption = "单据类型";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.OptionsColumn.AllowEdit = false;
            this.colType.OptionsColumn.ReadOnly = true;
            this.colType.Visible = true;
            this.colType.VisibleIndex = 4;
            // 
            // colQty
            // 
            this.colQty.Caption = "箱数";
            this.colQty.FieldName = "colQty";
            this.colQty.Name = "colQty";
            this.colQty.OptionsColumn.AllowEdit = false;
            this.colQty.OptionsColumn.ReadOnly = true;
            this.colQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "colQty", "{0}")});
            this.colQty.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 5;
            // 
            // colBillAMT
            // 
            this.colBillAMT.Caption = "单据金额(分)";
            this.colBillAMT.DisplayFormat.FormatString = "c";
            this.colBillAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBillAMT.FieldName = "BillAMT";
            this.colBillAMT.Name = "colBillAMT";
            this.colBillAMT.OptionsColumn.AllowEdit = false;
            this.colBillAMT.OptionsColumn.ReadOnly = true;
            this.colBillAMT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BillAMT", "{0:c}")});
            this.colBillAMT.Visible = true;
            this.colBillAMT.VisibleIndex = 6;
            // 
            // colReceiptedAMT
            // 
            this.colReceiptedAMT.Caption = "已收金额(分)";
            this.colReceiptedAMT.DisplayFormat.FormatString = "c";
            this.colReceiptedAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colReceiptedAMT.FieldName = "ReceiptedAMT";
            this.colReceiptedAMT.Name = "colReceiptedAMT";
            this.colReceiptedAMT.OptionsColumn.AllowEdit = false;
            this.colReceiptedAMT.OptionsColumn.ReadOnly = true;
            this.colReceiptedAMT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ReceiptedAMT", "{0:c}")});
            this.colReceiptedAMT.Visible = true;
            this.colReceiptedAMT.VisibleIndex = 7;
            // 
            // colUnReceiptedAMT
            // 
            this.colUnReceiptedAMT.Caption = "未收金额(分)";
            this.colUnReceiptedAMT.DisplayFormat.FormatString = "c";
            this.colUnReceiptedAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnReceiptedAMT.FieldName = "UnReceiptedAMT";
            this.colUnReceiptedAMT.Name = "colUnReceiptedAMT";
            this.colUnReceiptedAMT.OptionsColumn.AllowEdit = false;
            this.colUnReceiptedAMT.OptionsColumn.ReadOnly = true;
            this.colUnReceiptedAMT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UnReceiptedAMT", "{0:c}")});
            this.colUnReceiptedAMT.Visible = true;
            this.colUnReceiptedAMT.VisibleIndex = 8;
            // 
            // colLastReceiptedAMT
            // 
            this.colLastReceiptedAMT.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.colLastReceiptedAMT.AppearanceHeader.Options.UseForeColor = true;
            this.colLastReceiptedAMT.Caption = "本次收款(分)";
            this.colLastReceiptedAMT.DisplayFormat.FormatString = "c";
            this.colLastReceiptedAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLastReceiptedAMT.FieldName = "LastReceiptedAMT";
            this.colLastReceiptedAMT.Name = "colLastReceiptedAMT";
            this.colLastReceiptedAMT.OptionsColumn.AllowEdit = false;
            this.colLastReceiptedAMT.OptionsColumn.ReadOnly = true;
            this.colLastReceiptedAMT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LastReceiptedAMT", "{0:c}")});
            this.colLastReceiptedAMT.Visible = true;
            this.colLastReceiptedAMT.VisibleIndex = 9;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsColumn.AllowEdit = false;
            this.colRemark.OptionsColumn.ReadOnly = true;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 10;
            // 
            // lueBusinessContact
            // 
            this.lueBusinessContact.EnterMoveNextControl = true;
            this.lueBusinessContact.Location = new System.Drawing.Point(126, 72);
            this.lueBusinessContact.Name = "lueBusinessContact";
            this.lueBusinessContact.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.lueBusinessContact.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBusinessContact.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "代码", 38, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "名称", 41, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "地址", 53, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Contacts", "联系人", 58, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ContactTel", "联系电话", 74, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ContactCellPhone", "联系手机", 114, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueBusinessContact.Properties.DataSource = this.businessContactBindingSource;
            this.lueBusinessContact.Properties.DisplayMember = "Name";
            this.lueBusinessContact.Properties.DropDownRows = 15;
            this.lueBusinessContact.Properties.NullText = "";
            this.lueBusinessContact.Properties.PopupWidth = 500;
            this.lueBusinessContact.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lueBusinessContact.Properties.ValueMember = "ID";
            this.lueBusinessContact.Size = new System.Drawing.Size(178, 20);
            this.lueBusinessContact.StyleController = this.layoutControl;
            this.lueBusinessContact.TabIndex = 6;
            this.lueBusinessContact.EditValueChanged += new System.EventHandler(this.lueBusinessContact_EditValueChanged);
            // 
            // businessContactBindingSource
            // 
            this.businessContactBindingSource.DataSource = typeof(DBML.Company);
            // 
            // lueBillType
            // 
            this.lueBillType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBillHdBindingSource, "BillType", true));
            this.lueBillType.EnterMoveNextControl = true;
            this.lueBillType.Location = new System.Drawing.Point(126, 48);
            this.lueBillType.Name = "lueBillType";
            this.lueBillType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBillType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 41, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueBillType.Properties.DataSource = this.billTypeBindingSource;
            this.lueBillType.Properties.DisplayMember = "Name";
            this.lueBillType.Properties.NullText = "";
            this.lueBillType.Properties.PopupSizeable = false;
            this.lueBillType.Properties.ShowHeader = false;
            this.lueBillType.Properties.ValueMember = "No";
            this.lueBillType.Size = new System.Drawing.Size(178, 20);
            this.lueBillType.StyleController = this.layoutControl;
            this.lueBillType.TabIndex = 4;
            this.lueBillType.EditValueChanged += new System.EventHandler(this.lueBillType_EditValueChanged);
            // 
            // billTypeBindingSource
            // 
            this.billTypeBindingSource.DataSource = typeof(DBML.TypesList);
            // 
            // lueWarehouse
            // 
            this.lueWarehouse.EnterMoveNextControl = true;
            this.lueWarehouse.Location = new System.Drawing.Point(24, 96);
            this.lueWarehouse.Name = "lueWarehouse";
            this.lueWarehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueWarehouse.Properties.DisplayMember = "Name";
            this.lueWarehouse.Properties.NullText = "";
            this.lueWarehouse.Properties.PopupSizeable = false;
            this.lueWarehouse.Properties.ReadOnly = true;
            this.lueWarehouse.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueWarehouse.Properties.ValueMember = "ID";
            this.lueWarehouse.Size = new System.Drawing.Size(592, 20);
            this.lueWarehouse.StyleController = this.layoutControl;
            this.lueWarehouse.TabIndex = 1;
            // 
            // deAuditDate
            // 
            this.deAuditDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBillHdBindingSource, "AuditDate", true));
            this.deAuditDate.EditValue = null;
            this.deAuditDate.Enabled = false;
            this.deAuditDate.Location = new System.Drawing.Point(380, 120);
            this.deAuditDate.Name = "deAuditDate";
            this.deAuditDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deAuditDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deAuditDate.Size = new System.Drawing.Size(217, 20);
            this.deAuditDate.StyleController = this.layoutControl;
            this.deAuditDate.TabIndex = 11;
            // 
            // deMakeDate
            // 
            this.deMakeDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBillHdBindingSource, "MakeDate", true));
            this.deMakeDate.EditValue = null;
            this.deMakeDate.Enabled = false;
            this.deMakeDate.Location = new System.Drawing.Point(380, 96);
            this.deMakeDate.Name = "deMakeDate";
            this.deMakeDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deMakeDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deMakeDate.Size = new System.Drawing.Size(217, 20);
            this.deMakeDate.StyleController = this.layoutControl;
            this.deMakeDate.TabIndex = 9;
            // 
            // meRemark
            // 
            this.meRemark.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBillHdBindingSource, "Remark", true));
            this.meRemark.EnterMoveNextControl = true;
            this.meRemark.Location = new System.Drawing.Point(126, 144);
            this.meRemark.Name = "meRemark";
            this.meRemark.Size = new System.Drawing.Size(471, 39);
            this.meRemark.StyleController = this.layoutControl;
            this.meRemark.TabIndex = 12;
            // 
            // txtContacts
            // 
            this.txtContacts.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBillHdBindingSource, "Contacts", true));
            this.txtContacts.EnterMoveNextControl = true;
            this.txtContacts.Location = new System.Drawing.Point(380, 72);
            this.txtContacts.Name = "txtContacts";
            this.txtContacts.Size = new System.Drawing.Size(217, 20);
            this.txtContacts.StyleController = this.layoutControl;
            this.txtContacts.TabIndex = 7;
            // 
            // deBillDate
            // 
            this.deBillDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBillHdBindingSource, "BillDate", true));
            this.deBillDate.EditValue = null;
            this.deBillDate.EnterMoveNextControl = true;
            this.deBillDate.Location = new System.Drawing.Point(380, 24);
            this.deBillDate.Name = "deBillDate";
            this.deBillDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deBillDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deBillDate.Size = new System.Drawing.Size(217, 20);
            this.deBillDate.StyleController = this.layoutControl;
            this.deBillDate.TabIndex = 3;
            // 
            // txtBillNo
            // 
            this.txtBillNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBillHdBindingSource, "BillNo", true));
            this.txtBillNo.EnterMoveNextControl = true;
            this.txtBillNo.Location = new System.Drawing.Point(126, 24);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Properties.ReadOnly = true;
            this.txtBillNo.Size = new System.Drawing.Size(178, 20);
            this.txtBillNo.StyleController = this.layoutControl;
            this.txtBillNo.TabIndex = 2;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.Location = new System.Drawing.Point(24, 96);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(76, 20);
            this.lblWarehouse.StyleController = this.layoutControl;
            this.lblWarehouse.TabIndex = 1;
            this.lblWarehouse.Text = "仓库";
            // 
            // lueMaker
            // 
            this.lueMaker.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBillHdBindingSource, "Maker", true));
            this.lueMaker.Enabled = false;
            this.lueMaker.Location = new System.Drawing.Point(126, 96);
            this.lueMaker.Name = "lueMaker";
            this.lueMaker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMaker.Properties.DataSource = this.vUsersInfoBindingSource;
            this.lueMaker.Properties.DisplayMember = "姓名";
            this.lueMaker.Properties.NullText = "";
            this.lueMaker.Properties.ReadOnly = true;
            this.lueMaker.Properties.ValueMember = "ID";
            this.lueMaker.Size = new System.Drawing.Size(178, 20);
            this.lueMaker.StyleController = this.layoutControl;
            this.lueMaker.TabIndex = 8;
            // 
            // vUsersInfoBindingSource
            // 
            this.vUsersInfoBindingSource.DataSource = typeof(DBML.VUsersInfo);
            // 
            // lueAuditor
            // 
            this.lueAuditor.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBillHdBindingSource, "Auditor", true));
            this.lueAuditor.Enabled = false;
            this.lueAuditor.Location = new System.Drawing.Point(126, 120);
            this.lueAuditor.Name = "lueAuditor";
            this.lueAuditor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAuditor.Properties.DataSource = this.vUsersInfoBindingSource;
            this.lueAuditor.Properties.DisplayMember = "姓名";
            this.lueAuditor.Properties.NullText = "";
            this.lueAuditor.Properties.ReadOnly = true;
            this.lueAuditor.Properties.ValueMember = "ID";
            this.lueAuditor.Size = new System.Drawing.Size(178, 20);
            this.lueAuditor.StyleController = this.layoutControl;
            this.lueAuditor.TabIndex = 10;
            // 
            // luePOClear
            // 
            this.luePOClear.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBillHdBindingSource, "POClear", true));
            this.luePOClear.EnterMoveNextControl = true;
            this.luePOClear.Location = new System.Drawing.Point(380, 48);
            this.luePOClear.Name = "luePOClear";
            this.luePOClear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePOClear.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.luePOClear.Properties.DataSource = this.pOClearBindingSource;
            this.luePOClear.Properties.DisplayMember = "Name";
            this.luePOClear.Properties.NullText = "";
            this.luePOClear.Properties.PopupSizeable = false;
            this.luePOClear.Properties.ShowHeader = false;
            this.luePOClear.Properties.ValueMember = "No";
            this.luePOClear.Size = new System.Drawing.Size(217, 20);
            this.luePOClear.StyleController = this.layoutControl;
            this.luePOClear.TabIndex = 5;
            // 
            // pOClearBindingSource
            // 
            this.pOClearBindingSource.DataSource = typeof(DBML.TypesList);
            // 
            // meBalance
            // 
            this.meBalance.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBillHdBindingSource, "Balance", true));
            this.meBalance.Location = new System.Drawing.Point(126, 187);
            this.meBalance.Name = "meBalance";
            this.meBalance.Properties.Mask.EditMask = "c";
            this.meBalance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.meBalance.Size = new System.Drawing.Size(50, 20);
            this.meBalance.StyleController = this.layoutControl;
            this.meBalance.TabIndex = 13;
            this.meBalance.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.meBalance_EditValueChanging);
            // 
            // meLastAMT
            // 
            this.meLastAMT.Location = new System.Drawing.Point(241, 187);
            this.meLastAMT.Name = "meLastAMT";
            this.meLastAMT.Properties.Mask.EditMask = "c";
            this.meLastAMT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.meLastAMT.Properties.ReadOnly = true;
            this.meLastAMT.Size = new System.Drawing.Size(50, 20);
            this.meLastAMT.StyleController = this.layoutControl;
            this.meLastAMT.TabIndex = 14;
            // 
            // meTotalAMT
            // 
            this.meTotalAMT.Location = new System.Drawing.Point(333, 187);
            this.meTotalAMT.Name = "meTotalAMT";
            this.meTotalAMT.Properties.Mask.EditMask = "c";
            this.meTotalAMT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.meTotalAMT.Properties.ReadOnly = true;
            this.meTotalAMT.Size = new System.Drawing.Size(50, 20);
            this.meTotalAMT.StyleController = this.layoutControl;
            this.meTotalAMT.TabIndex = 15;
            this.meTotalAMT.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.meTotalAMT_EditValueChanging);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.lblWarehouse;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(80, 24);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(80, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(80, 24);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.lueWarehouse;
            this.layoutControlItem17.CustomizationFormText = "layoutControlItem17";
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(596, 24);
            this.layoutControlItem17.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem17.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.lciPrev,
            this.lciNext});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(651, 443);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciBillNo,
            this.lciBillDate,
            this.lciPOClear,
            this.lciContacts,
            this.lciMaker,
            this.lciMakeDate,
            this.lciAuditor,
            this.lciAuditDate,
            this.lciRemark,
            this.lciBillType,
            this.lciBusinessContact,
            this.layoutControlItem15,
            this.lciBalance,
            this.lciLastAMT,
            this.lciTotalAMT,
            this.lciReceiptedAM,
            this.lciUnReceiptedAMT});
            this.layoutControlGroup2.Location = new System.Drawing.Point(30, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(571, 423);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // lciBillNo
            // 
            this.lciBillNo.Control = this.txtBillNo;
            this.lciBillNo.Location = new System.Drawing.Point(0, 0);
            this.lciBillNo.MaxSize = new System.Drawing.Size(0, 24);
            this.lciBillNo.MinSize = new System.Drawing.Size(200, 24);
            this.lciBillNo.Name = "lciBillNo";
            this.lciBillNo.Size = new System.Drawing.Size(254, 24);
            this.lciBillNo.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciBillNo.Text = "收款单号";
            this.lciBillNo.TextSize = new System.Drawing.Size(69, 14);
            // 
            // lciBillDate
            // 
            this.lciBillDate.Control = this.deBillDate;
            this.lciBillDate.CustomizationFormText = "收款日期";
            this.lciBillDate.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lciBillDate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lciBillDate.ImageOptions.Image")));
            this.lciBillDate.Location = new System.Drawing.Point(254, 0);
            this.lciBillDate.Name = "lciBillDate";
            this.lciBillDate.Size = new System.Drawing.Size(293, 24);
            this.lciBillDate.Text = "收款日期";
            this.lciBillDate.TextSize = new System.Drawing.Size(69, 16);
            // 
            // lciPOClear
            // 
            this.lciPOClear.Control = this.luePOClear;
            this.lciPOClear.CustomizationFormText = "结算方式";
            this.lciPOClear.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lciPOClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lciPOClear.ImageOptions.Image")));
            this.lciPOClear.Location = new System.Drawing.Point(254, 24);
            this.lciPOClear.Name = "lciPOClear";
            this.lciPOClear.Size = new System.Drawing.Size(293, 24);
            this.lciPOClear.Text = "结算方式";
            this.lciPOClear.TextSize = new System.Drawing.Size(69, 16);
            // 
            // lciContacts
            // 
            this.lciContacts.Control = this.txtContacts;
            this.lciContacts.CustomizationFormText = "联系人";
            this.lciContacts.Location = new System.Drawing.Point(254, 48);
            this.lciContacts.MinSize = new System.Drawing.Size(54, 24);
            this.lciContacts.Name = "lciContacts";
            this.lciContacts.Size = new System.Drawing.Size(293, 24);
            this.lciContacts.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciContacts.Text = "联系人";
            this.lciContacts.TextSize = new System.Drawing.Size(69, 14);
            // 
            // lciMaker
            // 
            this.lciMaker.Control = this.lueMaker;
            this.lciMaker.Location = new System.Drawing.Point(0, 72);
            this.lciMaker.Name = "lciMaker";
            this.lciMaker.Size = new System.Drawing.Size(254, 24);
            this.lciMaker.Text = "制单人";
            this.lciMaker.TextSize = new System.Drawing.Size(69, 14);
            // 
            // lciMakeDate
            // 
            this.lciMakeDate.Control = this.deMakeDate;
            this.lciMakeDate.CustomizationFormText = "制单日期";
            this.lciMakeDate.Location = new System.Drawing.Point(254, 72);
            this.lciMakeDate.Name = "lciMakeDate";
            this.lciMakeDate.Size = new System.Drawing.Size(293, 24);
            this.lciMakeDate.Text = "制单日期";
            this.lciMakeDate.TextSize = new System.Drawing.Size(69, 14);
            // 
            // lciAuditor
            // 
            this.lciAuditor.Control = this.lueAuditor;
            this.lciAuditor.Location = new System.Drawing.Point(0, 96);
            this.lciAuditor.Name = "lciAuditor";
            this.lciAuditor.Size = new System.Drawing.Size(254, 24);
            this.lciAuditor.Text = "审核人";
            this.lciAuditor.TextSize = new System.Drawing.Size(69, 14);
            // 
            // lciAuditDate
            // 
            this.lciAuditDate.Control = this.deAuditDate;
            this.lciAuditDate.CustomizationFormText = "审核日期";
            this.lciAuditDate.Location = new System.Drawing.Point(254, 96);
            this.lciAuditDate.Name = "lciAuditDate";
            this.lciAuditDate.Size = new System.Drawing.Size(293, 24);
            this.lciAuditDate.Text = "审核日期";
            this.lciAuditDate.TextSize = new System.Drawing.Size(69, 14);
            // 
            // lciRemark
            // 
            this.lciRemark.Control = this.meRemark;
            this.lciRemark.Location = new System.Drawing.Point(0, 120);
            this.lciRemark.MaxSize = new System.Drawing.Size(0, 43);
            this.lciRemark.MinSize = new System.Drawing.Size(14, 43);
            this.lciRemark.Name = "lciRemark";
            this.lciRemark.Size = new System.Drawing.Size(547, 43);
            this.lciRemark.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciRemark.Text = "备注";
            this.lciRemark.TextSize = new System.Drawing.Size(69, 14);
            // 
            // lciBillType
            // 
            this.lciBillType.Control = this.lueBillType;
            this.lciBillType.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lciBillType.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lciBillType.ImageOptions.Image")));
            this.lciBillType.Location = new System.Drawing.Point(0, 24);
            this.lciBillType.Name = "lciBillType";
            this.lciBillType.Size = new System.Drawing.Size(254, 24);
            this.lciBillType.Text = "收款类型";
            this.lciBillType.TextSize = new System.Drawing.Size(69, 16);
            // 
            // lciBusinessContact
            // 
            this.lciBusinessContact.Control = this.lueBusinessContact;
            this.lciBusinessContact.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lciBusinessContact.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lciBusinessContact.ImageOptions.Image")));
            this.lciBusinessContact.Location = new System.Drawing.Point(0, 48);
            this.lciBusinessContact.Name = "lciBusinessContact";
            this.lciBusinessContact.Size = new System.Drawing.Size(254, 24);
            this.lciBusinessContact.Text = "业务往来";
            this.lciBusinessContact.TextSize = new System.Drawing.Size(69, 16);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.gridControl;
            this.layoutControlItem15.CustomizationFormText = "layoutControlItem15";
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 187);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(547, 212);
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // lciBalance
            // 
            this.lciBalance.Control = this.meBalance;
            this.lciBalance.CustomizationFormText = "上期结欠";
            this.lciBalance.Location = new System.Drawing.Point(0, 163);
            this.lciBalance.Name = "lciBalance";
            this.lciBalance.Size = new System.Drawing.Size(126, 24);
            this.lciBalance.Text = "上期结欠";
            this.lciBalance.TextSize = new System.Drawing.Size(69, 14);
            // 
            // lciLastAMT
            // 
            this.lciLastAMT.Control = this.meLastAMT;
            this.lciLastAMT.CustomizationFormText = "+本次收款";
            this.lciLastAMT.Location = new System.Drawing.Point(126, 163);
            this.lciLastAMT.Name = "lciLastAMT";
            this.lciLastAMT.Size = new System.Drawing.Size(115, 24);
            this.lciLastAMT.Text = "+本次收款";
            this.lciLastAMT.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciLastAMT.TextSize = new System.Drawing.Size(56, 14);
            this.lciLastAMT.TextToControlDistance = 5;
            // 
            // lciTotalAMT
            // 
            this.lciTotalAMT.Control = this.meTotalAMT;
            this.lciTotalAMT.CustomizationFormText = "=共欠";
            this.lciTotalAMT.Location = new System.Drawing.Point(241, 163);
            this.lciTotalAMT.Name = "lciTotalAMT";
            this.lciTotalAMT.Size = new System.Drawing.Size(92, 24);
            this.lciTotalAMT.Text = "=共欠";
            this.lciTotalAMT.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciTotalAMT.TextSize = new System.Drawing.Size(33, 14);
            this.lciTotalAMT.TextToControlDistance = 5;
            // 
            // lciReceiptedAM
            // 
            this.lciReceiptedAM.Control = this.meReceiptedAM;
            this.lciReceiptedAM.Location = new System.Drawing.Point(333, 163);
            this.lciReceiptedAM.Name = "lciReceiptedAM";
            this.lciReceiptedAM.Size = new System.Drawing.Size(107, 24);
            this.lciReceiptedAM.Text = "本次结款";
            this.lciReceiptedAM.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciReceiptedAM.TextSize = new System.Drawing.Size(48, 14);
            this.lciReceiptedAM.TextToControlDistance = 5;
            // 
            // lciUnReceiptedAMT
            // 
            this.lciUnReceiptedAMT.Control = this.meUnReceiptedAMT;
            this.lciUnReceiptedAMT.Location = new System.Drawing.Point(440, 163);
            this.lciUnReceiptedAMT.Name = "lciUnReceiptedAMT";
            this.lciUnReceiptedAMT.Size = new System.Drawing.Size(107, 24);
            this.lciUnReceiptedAMT.Text = "本期结欠";
            this.lciUnReceiptedAMT.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciUnReceiptedAMT.TextSize = new System.Drawing.Size(48, 14);
            this.lciUnReceiptedAMT.TextToControlDistance = 5;
            // 
            // lciPrev
            // 
            this.lciPrev.Control = this.btnPrev;
            this.lciPrev.CustomizationFormText = "Prev";
            this.lciPrev.Location = new System.Drawing.Point(0, 0);
            this.lciPrev.MaxSize = new System.Drawing.Size(30, 0);
            this.lciPrev.MinSize = new System.Drawing.Size(30, 26);
            this.lciPrev.Name = "lciPrev";
            this.lciPrev.Size = new System.Drawing.Size(30, 423);
            this.lciPrev.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciPrev.Text = "Prev";
            this.lciPrev.TextSize = new System.Drawing.Size(0, 0);
            this.lciPrev.TextVisible = false;
            // 
            // lciNext
            // 
            this.lciNext.Control = this.btnNext;
            this.lciNext.CustomizationFormText = "Next";
            this.lciNext.Location = new System.Drawing.Point(601, 0);
            this.lciNext.MaxSize = new System.Drawing.Size(30, 0);
            this.lciNext.MinSize = new System.Drawing.Size(30, 26);
            this.lciNext.Name = "lciNext";
            this.lciNext.Size = new System.Drawing.Size(30, 423);
            this.lciNext.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciNext.Text = "Next";
            this.lciNext.TextSize = new System.Drawing.Size(0, 0);
            this.lciNext.TextVisible = false;
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
            this.hideContainerBottom.Controls.Add(this.dpSOA);
            this.hideContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hideContainerBottom.Location = new System.Drawing.Point(0, 460);
            this.hideContainerBottom.Name = "hideContainerBottom";
            this.hideContainerBottom.Size = new System.Drawing.Size(640, 20);
            // 
            // dpSOA
            // 
            this.dpSOA.Controls.Add(this.dockPanel1_Container);
            this.dpSOA.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpSOA.ID = new System.Guid("b48774ad-553d-4aeb-8dc5-7c3912949701");
            this.dpSOA.Location = new System.Drawing.Point(0, 0);
            this.dpSOA.Name = "dpSOA";
            this.dpSOA.Options.ShowCloseButton = false;
            this.dpSOA.OriginalSize = new System.Drawing.Size(200, 400);
            this.dpSOA.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpSOA.SavedIndex = 0;
            this.dpSOA.SavedSizeFactor = 1D;
            this.dpSOA.Size = new System.Drawing.Size(640, 400);
            this.dpSOA.Text = "对账单";
            this.dpSOA.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gcSOA);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 24);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(632, 372);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // gcSOA
            // 
            this.gcSOA.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcSOA.DataSource = this.statementOfAccountToCustomerReportBindingSource;
            this.gcSOA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSOA.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcSOA.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcSOA.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcSOA.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcSOA.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcSOA.Location = new System.Drawing.Point(0, 0);
            this.gcSOA.MainView = this.gvSOA;
            this.gcSOA.Name = "gcSOA";
            this.gcSOA.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit});
            this.gcSOA.Size = new System.Drawing.Size(632, 372);
            this.gcSOA.TabIndex = 1;
            this.gcSOA.UseEmbeddedNavigator = true;
            this.gcSOA.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSOA});
            // 
            // statementOfAccountToCustomerReportBindingSource
            // 
            this.statementOfAccountToCustomerReportBindingSource.DataSource = typeof(DBML.StatementOfAccountToCustomerReport);
            // 
            // gvSOA
            // 
            this.gvSOA.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvSOA.Appearance.FilterPanel.Options.UseFont = true;
            this.gvSOA.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvSOA.Appearance.FooterPanel.Options.UseFont = true;
            this.gvSOA.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvSOA.Appearance.GroupFooter.Options.UseFont = true;
            this.gvSOA.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvSOA.Appearance.GroupPanel.Options.UseFont = true;
            this.gvSOA.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvSOA.Appearance.GroupRow.Options.UseFont = true;
            this.gvSOA.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvSOA.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvSOA.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvSOA.Appearance.Row.Options.UseFont = true;
            this.gvSOA.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F);
            this.gvSOA.AppearancePrint.FilterPanel.Options.UseFont = true;
            this.gvSOA.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvSOA.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvSOA.AppearancePrint.FooterPanel.Options.UseBackColor = true;
            this.gvSOA.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.gvSOA.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvSOA.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvSOA.AppearancePrint.GroupFooter.Options.UseBackColor = true;
            this.gvSOA.AppearancePrint.GroupFooter.Options.UseFont = true;
            this.gvSOA.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F);
            this.gvSOA.AppearancePrint.GroupRow.Options.UseFont = true;
            this.gvSOA.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvSOA.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvSOA.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gvSOA.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gvSOA.AppearancePrint.Row.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F);
            this.gvSOA.AppearancePrint.Row.Options.UseFont = true;
            this.gvSOA.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col收款单号,
            this.col收款日期,
            this.col状态,
            this.col客户代码,
            this.col客户名称,
            this.col客户类型,
            this.col结算类型,
            this.col出库日期,
            this.colGoodsType,
            this.col货号,
            this.col正唛,
            this.col品名,
            this.col箱数,
            this.col装箱数,
            this.col内盒,
            this.col总数量,
            this.col单价,
            this.col额外费用,
            this.col应收金额,
            this.col折扣,
            this.col实收金额,
            this.col包装方式,
            this.col外箱规格});
            this.gvSOA.GridControl = this.gcSOA;
            this.gvSOA.Name = "gvSOA";
            this.gvSOA.OptionsBehavior.Editable = false;
            this.gvSOA.OptionsBehavior.ReadOnly = true;
            this.gvSOA.OptionsFind.FindNullPrompt = "请输入查找内容...";
            this.gvSOA.OptionsFind.ShowCloseButton = false;
            this.gvSOA.OptionsNavigation.AutoFocusNewRow = true;
            this.gvSOA.OptionsView.ColumnAutoWidth = false;
            this.gvSOA.OptionsView.EnableAppearanceEvenRow = true;
            this.gvSOA.OptionsView.EnableAppearanceOddRow = true;
            this.gvSOA.OptionsView.ShowFooter = true;
            this.gvSOA.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.col结算类型, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.col出库日期, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // col收款单号
            // 
            this.col收款单号.FieldName = "收款单号";
            this.col收款单号.Name = "col收款单号";
            // 
            // col收款日期
            // 
            this.col收款日期.FieldName = "收款日期";
            this.col收款日期.Name = "col收款日期";
            // 
            // col状态
            // 
            this.col状态.FieldName = "状态";
            this.col状态.Name = "col状态";
            // 
            // col客户代码
            // 
            this.col客户代码.FieldName = "客户代码";
            this.col客户代码.Name = "col客户代码";
            // 
            // col客户名称
            // 
            this.col客户名称.FieldName = "客户名称";
            this.col客户名称.Name = "col客户名称";
            // 
            // col客户类型
            // 
            this.col客户类型.FieldName = "客户类型";
            this.col客户类型.Name = "col客户类型";
            // 
            // col结算类型
            // 
            this.col结算类型.FieldName = "结算类型";
            this.col结算类型.Name = "col结算类型";
            this.col结算类型.Visible = true;
            this.col结算类型.VisibleIndex = 0;
            this.col结算类型.Width = 89;
            // 
            // col出库日期
            // 
            this.col出库日期.FieldName = "出库日期";
            this.col出库日期.Name = "col出库日期";
            this.col出库日期.Visible = true;
            this.col出库日期.VisibleIndex = 1;
            this.col出库日期.Width = 89;
            // 
            // colGoodsType
            // 
            this.colGoodsType.Caption = "货品类型";
            this.colGoodsType.FieldName = "货品类型名称";
            this.colGoodsType.Name = "colGoodsType";
            this.colGoodsType.Visible = true;
            this.colGoodsType.VisibleIndex = 2;
            // 
            // col货号
            // 
            this.col货号.FieldName = "货号";
            this.col货号.Name = "col货号";
            this.col货号.Visible = true;
            this.col货号.VisibleIndex = 3;
            // 
            // col正唛
            // 
            this.col正唛.FieldName = "正唛";
            this.col正唛.Name = "col正唛";
            this.col正唛.Visible = true;
            this.col正唛.VisibleIndex = 4;
            // 
            // col品名
            // 
            this.col品名.FieldName = "品名";
            this.col品名.Name = "col品名";
            this.col品名.Visible = true;
            this.col品名.VisibleIndex = 5;
            // 
            // col箱数
            // 
            this.col箱数.FieldName = "箱数";
            this.col箱数.Name = "col箱数";
            this.col箱数.Visible = true;
            this.col箱数.VisibleIndex = 6;
            // 
            // col装箱数
            // 
            this.col装箱数.FieldName = "装箱数";
            this.col装箱数.Name = "col装箱数";
            this.col装箱数.Visible = true;
            this.col装箱数.VisibleIndex = 7;
            // 
            // col内盒
            // 
            this.col内盒.FieldName = "内盒";
            this.col内盒.Name = "col内盒";
            // 
            // col总数量
            // 
            this.col总数量.FieldName = "总数量";
            this.col总数量.Name = "col总数量";
            this.col总数量.Visible = true;
            this.col总数量.VisibleIndex = 8;
            // 
            // col单价
            // 
            this.col单价.FieldName = "单价";
            this.col单价.Name = "col单价";
            this.col单价.Visible = true;
            this.col单价.VisibleIndex = 9;
            // 
            // col额外费用
            // 
            this.col额外费用.FieldName = "额外费用";
            this.col额外费用.Name = "col额外费用";
            this.col额外费用.Visible = true;
            this.col额外费用.VisibleIndex = 10;
            // 
            // col应收金额
            // 
            this.col应收金额.FieldName = "应收金额";
            this.col应收金额.Name = "col应收金额";
            this.col应收金额.Visible = true;
            this.col应收金额.VisibleIndex = 11;
            // 
            // col折扣
            // 
            this.col折扣.FieldName = "折扣";
            this.col折扣.Name = "col折扣";
            this.col折扣.Visible = true;
            this.col折扣.VisibleIndex = 12;
            // 
            // col实收金额
            // 
            this.col实收金额.FieldName = "实收金额";
            this.col实收金额.Name = "col实收金额";
            this.col实收金额.Visible = true;
            this.col实收金额.VisibleIndex = 13;
            // 
            // col包装方式
            // 
            this.col包装方式.FieldName = "包装方式";
            this.col包装方式.Name = "col包装方式";
            // 
            // col外箱规格
            // 
            this.col外箱规格.FieldName = "外箱规格";
            this.col外箱规格.Name = "col外箱规格";
            // 
            // repositoryItemPictureEdit
            // 
            this.repositoryItemPictureEdit.Name = "repositoryItemPictureEdit";
            // 
            // ReceiptBillPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Controls.Add(this.hideContainerBottom);
            this.Name = "ReceiptBillPage";
            this.Size = new System.Drawing.Size(640, 480);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meUnReceiptedAMT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptBillHdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meReceiptedAM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vReceiptBillDtlBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBusinessContact.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessContactBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBillType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deAuditDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deAuditDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMakeDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMakeDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContacts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBillDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBillDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vUsersInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAuditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePOClear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOClearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meLastAMT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meTotalAMT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBillNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBillDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPOClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciContacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMaker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMakeDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAuditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAuditDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBillType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBusinessContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLastAMT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTotalAMT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciReceiptedAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUnReceiptedAMT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.hideContainerBottom.ResumeLayout(false);
            this.dpSOA.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSOA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statementOfAccountToCustomerReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSOA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.LookUpEdit lueBusinessContact;
        private DevExpress.XtraEditors.LookUpEdit lueBillType;
        private DevExpress.XtraEditors.LookUpEdit lueWarehouse;
        private DevExpress.XtraEditors.DateEdit deAuditDate;
        private DevExpress.XtraEditors.DateEdit deMakeDate;
        private DevExpress.XtraEditors.MemoEdit meRemark;
        private DevExpress.XtraEditors.TextEdit txtContacts;
        private DevExpress.XtraEditors.DateEdit deBillDate;
        private DevExpress.XtraEditors.TextEdit txtBillNo;
        private DevExpress.XtraEditors.LabelControl lblWarehouse;
        private DevExpress.XtraEditors.LookUpEdit lueMaker;
        private DevExpress.XtraEditors.LookUpEdit lueAuditor;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem lciBillNo;
        private DevExpress.XtraLayout.LayoutControlItem lciBillDate;
        private DevExpress.XtraLayout.LayoutControlItem lciPOClear;
        private DevExpress.XtraLayout.LayoutControlItem lciContacts;
        private DevExpress.XtraLayout.LayoutControlItem lciMaker;
        private DevExpress.XtraLayout.LayoutControlItem lciMakeDate;
        private DevExpress.XtraLayout.LayoutControlItem lciAuditor;
        private DevExpress.XtraLayout.LayoutControlItem lciAuditDate;
        private DevExpress.XtraLayout.LayoutControlItem lciRemark;
        private DevExpress.XtraLayout.LayoutControlItem lciBillType;
        private DevExpress.XtraLayout.LayoutControlItem lciBusinessContact;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraEditors.LookUpEdit luePOClear;
        private System.Windows.Forms.BindingSource receiptBillHdBindingSource;
        private System.Windows.Forms.BindingSource vReceiptBillDtlBindingSource;
        private System.Windows.Forms.BindingSource billTypeBindingSource;
        private System.Windows.Forms.BindingSource businessContactBindingSource;
        private System.Windows.Forms.BindingSource pOClearBindingSource;
        private System.Windows.Forms.BindingSource vUsersInfoBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colBillID;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyID;
        private DevExpress.XtraGrid.Columns.GridColumn colBillNo;
        private DevExpress.XtraGrid.Columns.GridColumn colBillDate;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colBillAMT;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiptedAMT;
        private DevExpress.XtraGrid.Columns.GridColumn colUnReceiptedAMT;
        private DevExpress.XtraGrid.Columns.GridColumn colLastReceiptedAMT;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierID;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colMainMark;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnPrev;
        private DevExpress.XtraLayout.LayoutControlItem lciPrev;
        private DevExpress.XtraLayout.LayoutControlItem lciNext;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerBottom;
        private DevExpress.XtraBars.Docking.DockPanel dpSOA;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.GridControl gcSOA;
        public DevExpress.XtraGrid.Views.Grid.GridView gvSOA;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit;
        private System.Windows.Forms.BindingSource statementOfAccountToCustomerReportBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn col收款单号;
        private DevExpress.XtraGrid.Columns.GridColumn col收款日期;
        private DevExpress.XtraGrid.Columns.GridColumn col状态;
        private DevExpress.XtraGrid.Columns.GridColumn col客户代码;
        private DevExpress.XtraGrid.Columns.GridColumn col客户名称;
        private DevExpress.XtraGrid.Columns.GridColumn col客户类型;
        private DevExpress.XtraGrid.Columns.GridColumn col结算类型;
        private DevExpress.XtraGrid.Columns.GridColumn col出库日期;
        private DevExpress.XtraGrid.Columns.GridColumn col货号;
        private DevExpress.XtraGrid.Columns.GridColumn col正唛;
        private DevExpress.XtraGrid.Columns.GridColumn col品名;
        private DevExpress.XtraGrid.Columns.GridColumn col箱数;
        private DevExpress.XtraGrid.Columns.GridColumn col装箱数;
        private DevExpress.XtraGrid.Columns.GridColumn col内盒;
        private DevExpress.XtraGrid.Columns.GridColumn col总数量;
        private DevExpress.XtraGrid.Columns.GridColumn col单价;
        private DevExpress.XtraGrid.Columns.GridColumn col折扣;
        private DevExpress.XtraGrid.Columns.GridColumn col额外费用;
        private DevExpress.XtraGrid.Columns.GridColumn col实收金额;
        private DevExpress.XtraGrid.Columns.GridColumn col包装方式;
        private DevExpress.XtraGrid.Columns.GridColumn col外箱规格;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsType;
        private DevExpress.XtraLayout.LayoutControlItem lciBalance;
        private DevExpress.XtraLayout.LayoutControlItem lciLastAMT;
        private DevExpress.XtraLayout.LayoutControlItem lciTotalAMT;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckItem;
        private System.Windows.Forms.ImageList imageListCheck;
        private DevExpress.XtraEditors.TextEdit meUnReceiptedAMT;
        private DevExpress.XtraEditors.TextEdit meReceiptedAM;
        private DevExpress.XtraEditors.TextEdit meBalance;
        private DevExpress.XtraEditors.TextEdit meLastAMT;
        private DevExpress.XtraEditors.TextEdit meTotalAMT;
        private DevExpress.XtraLayout.LayoutControlItem lciReceiptedAM;
        private DevExpress.XtraLayout.LayoutControlItem lciUnReceiptedAMT;
        private DevExpress.XtraGrid.Columns.GridColumn col应收金额;
    }
}
