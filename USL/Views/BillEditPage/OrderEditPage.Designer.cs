namespace USL
{
    partial class OrderEditPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderEditPage));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrev = new DevExpress.XtraEditors.SimpleButton();
            this.lueWarehouseType = new DevExpress.XtraEditors.LookUpEdit();
            this.orderHdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.warehouseTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.meMainMark = new DevExpress.XtraEditors.MemoEdit();
            this.lueWarehouse = new DevExpress.XtraEditors.LookUpEdit();
            this.warehouseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lueBillType = new DevExpress.XtraEditors.LookUpEdit();
            this.billTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.orderDtlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHdID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLueGoods = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.vGoodsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPackaging = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMEAS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPEC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInnerBox = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAMT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceNoTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAMTNoTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtherFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.deAuditDate = new DevExpress.XtraEditors.DateEdit();
            this.deMakeDate = new DevExpress.XtraEditors.DateEdit();
            this.meRemark = new DevExpress.XtraEditors.MemoEdit();
            this.txtContacts = new DevExpress.XtraEditors.TextEdit();
            this.lueBusinessContact = new DevExpress.XtraEditors.LookUpEdit();
            this.businessContactBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deDeliveryDate = new DevExpress.XtraEditors.DateEdit();
            this.deOrderDate = new DevExpress.XtraEditors.DateEdit();
            this.txtBillNo = new DevExpress.XtraEditors.TextEdit();
            this.lueMaker = new DevExpress.XtraEditors.LookUpEdit();
            this.vUsersInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lueAuditor = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciBillNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciOrderDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDeliveryDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBusinessContact = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciContacts = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciMaker = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciMakeDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciAuditor = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciAuditDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBillType = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciWarehouse = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciMainMark = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciRemark = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciWarehouseType = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPrev = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNext = new DevExpress.XtraLayout.LayoutControlItem();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerBottom = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dpBOM = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcBOM = new DevExpress.XtraGrid.GridControl();
            this.billDtlByBOMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvBOM = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLueGoodsByBOM = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.vGoodsByBOMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPEC1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShortage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPCS1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInnerBox1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalQty1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCounts1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCavityNumber1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModulus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAMT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceNoTax1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAMTNoTax1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscount1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtherFee1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dpAssemble = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcAssemble = new DevExpress.XtraGrid.GridControl();
            this.billDtlByAssembleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvAssemble = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsID3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colName3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPEC3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockQty3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShortage3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPCS3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInnerBox3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalQty3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNWeight3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCounts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCavityNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModulus3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAMT3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceNoTax3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAMTNoTax3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscount3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtherFee3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dpMoldMaterial = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer2 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcMoldMaterial = new DevExpress.XtraGrid.GridControl();
            this.vFSMOrderDtlByMoldMaterialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvMoldMaterial = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPEC2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueWarehouseType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderHdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meMainMark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBillType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDtlBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLueGoods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGoodsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deAuditDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deAuditDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMakeDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMakeDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContacts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBusinessContact.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessContactBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDeliveryDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDeliveryDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOrderDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOrderDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vUsersInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAuditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBillNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOrderDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDeliveryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBusinessContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciContacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMaker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMakeDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAuditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAuditDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBillType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMainMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciWarehouseType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.hideContainerBottom.SuspendLayout();
            this.dpBOM.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billDtlByBOMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLueGoodsByBOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGoodsByBOMBindingSource)).BeginInit();
            this.dpAssemble.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAssemble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billDtlByAssembleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAssemble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.dpMoldMaterial.SuspendLayout();
            this.controlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMoldMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vFSMOrderDtlByMoldMaterialBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMoldMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.btnNext);
            this.layoutControl.Controls.Add(this.btnPrev);
            this.layoutControl.Controls.Add(this.lueWarehouseType);
            this.layoutControl.Controls.Add(this.meMainMark);
            this.layoutControl.Controls.Add(this.lueWarehouse);
            this.layoutControl.Controls.Add(this.lueBillType);
            this.layoutControl.Controls.Add(this.gridControl);
            this.layoutControl.Controls.Add(this.deAuditDate);
            this.layoutControl.Controls.Add(this.deMakeDate);
            this.layoutControl.Controls.Add(this.meRemark);
            this.layoutControl.Controls.Add(this.txtContacts);
            this.layoutControl.Controls.Add(this.lueBusinessContact);
            this.layoutControl.Controls.Add(this.deDeliveryDate);
            this.layoutControl.Controls.Add(this.deOrderDate);
            this.layoutControl.Controls.Add(this.txtBillNo);
            this.layoutControl.Controls.Add(this.lueMaker);
            this.layoutControl.Controls.Add(this.lueAuditor);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(470, 213, 371, 523);
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(640, 460);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(602, 12);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(26, 436);
            this.btnNext.StyleController = this.layoutControl;
            this.btnNext.TabIndex = 17;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(12, 12);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(26, 436);
            this.btnPrev.StyleController = this.layoutControl;
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "<";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // lueWarehouseType
            // 
            this.lueWarehouseType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderHdBindingSource, "WarehouseType", true));
            this.lueWarehouseType.EnterMoveNextControl = true;
            this.lueWarehouseType.Location = new System.Drawing.Point(126, 96);
            this.lueWarehouseType.Name = "lueWarehouseType";
            this.lueWarehouseType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueWarehouseType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueWarehouseType.Properties.DataSource = this.warehouseTypeBindingSource;
            this.lueWarehouseType.Properties.DisplayMember = "Name";
            this.lueWarehouseType.Properties.NullText = "";
            this.lueWarehouseType.Properties.PopupSizeable = false;
            this.lueWarehouseType.Properties.ShowHeader = false;
            this.lueWarehouseType.Properties.ValueMember = "Index";
            this.lueWarehouseType.Size = new System.Drawing.Size(131, 20);
            this.lueWarehouseType.StyleController = this.layoutControl;
            this.lueWarehouseType.TabIndex = 8;
            // 
            // orderHdBindingSource
            // 
            this.orderHdBindingSource.DataSource = typeof(EDMX.OrderHd);
            // 
            // meMainMark
            // 
            this.meMainMark.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderHdBindingSource, "MainMark", true));
            this.meMainMark.EnterMoveNextControl = true;
            this.meMainMark.Location = new System.Drawing.Point(126, 168);
            this.meMainMark.Name = "meMainMark";
            this.meMainMark.Size = new System.Drawing.Size(131, 36);
            this.meMainMark.StyleController = this.layoutControl;
            this.meMainMark.TabIndex = 14;
            // 
            // lueWarehouse
            // 
            this.lueWarehouse.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderHdBindingSource, "WarehouseID", true));
            this.lueWarehouse.EnterMoveNextControl = true;
            this.lueWarehouse.Location = new System.Drawing.Point(333, 96);
            this.lueWarehouse.Name = "lueWarehouse";
            this.lueWarehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueWarehouse.Properties.DataSource = this.warehouseBindingSource;
            this.lueWarehouse.Properties.DisplayMember = "Name";
            this.lueWarehouse.Properties.NullText = "";
            this.lueWarehouse.Properties.PopupSizeable = false;
            this.lueWarehouse.Properties.ReadOnly = true;
            this.lueWarehouse.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueWarehouse.Properties.ValueMember = "ID";
            this.lueWarehouse.Size = new System.Drawing.Size(253, 20);
            this.lueWarehouse.StyleController = this.layoutControl;
            this.lueWarehouse.TabIndex = 9;
            // 
            // warehouseBindingSource
            // 
            this.warehouseBindingSource.DataSource = typeof(EDMX.Warehouse);
            // 
            // lueBillType
            // 
            this.lueBillType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderHdBindingSource, "Type", true));
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
            this.lueBillType.Properties.ValueMember = "Index";
            this.lueBillType.Size = new System.Drawing.Size(131, 20);
            this.lueBillType.StyleController = this.layoutControl;
            this.lueBillType.TabIndex = 4;
            // 
            // gridControl
            // 
            this.gridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl.DataSource = this.orderDtlBindingSource;
            this.gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl.Location = new System.Drawing.Point(54, 208);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLueGoods,
            this.repositoryItemMemoExEdit1});
            this.gridControl.Size = new System.Drawing.Size(532, 228);
            this.gridControl.TabIndex = 16;
            this.gridControl.UseEmbeddedNavigator = true;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // orderDtlBindingSource
            // 
            this.orderDtlBindingSource.DataSource = typeof(EDMX.OrderDtl);
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
            this.gridView.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F);
            this.gridView.AppearancePrint.FilterPanel.Options.UseBorderColor = true;
            this.gridView.AppearancePrint.FilterPanel.Options.UseFont = true;
            this.gridView.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black;
            this.gridView.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Bold);
            this.gridView.AppearancePrint.FooterPanel.Options.UseBackColor = true;
            this.gridView.AppearancePrint.FooterPanel.Options.UseBorderColor = true;
            this.gridView.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.gridView.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black;
            this.gridView.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Bold);
            this.gridView.AppearancePrint.GroupFooter.Options.UseBackColor = true;
            this.gridView.AppearancePrint.GroupFooter.Options.UseBorderColor = true;
            this.gridView.AppearancePrint.GroupFooter.Options.UseFont = true;
            this.gridView.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black;
            this.gridView.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F);
            this.gridView.AppearancePrint.GroupRow.Options.UseBorderColor = true;
            this.gridView.AppearancePrint.GroupRow.Options.UseFont = true;
            this.gridView.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black;
            this.gridView.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Bold);
            this.gridView.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridView.AppearancePrint.HeaderPanel.Options.UseBorderColor = true;
            this.gridView.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridView.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black;
            this.gridView.AppearancePrint.Row.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F);
            this.gridView.AppearancePrint.Row.Options.UseBorderColor = true;
            this.gridView.AppearancePrint.Row.Options.UseFont = true;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colHdID,
            this.colGoodsID,
            this.colName,
            this.colPackaging,
            this.colMEAS,
            this.colSPEC,
            this.colQty,
            this.colPCS,
            this.colInnerBox,
            this.colTotalQty,
            this.colUnit,
            this.colPrice,
            this.colAMT,
            this.colPriceNoTax,
            this.colAMTNoTax,
            this.colDiscount,
            this.colOtherFee,
            this.colRemark});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridView.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView.OptionsView.EnableAppearanceOddRow = true;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridView_FocusedColumnChanged);
            this.gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_CellValueChanged);
            this.gridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView_CustomUnboundColumnData);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ReadOnly = true;
            // 
            // colHdID
            // 
            this.colHdID.FieldName = "HdID";
            this.colHdID.Name = "colHdID";
            // 
            // colGoodsID
            // 
            this.colGoodsID.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.colGoodsID.AppearanceHeader.Options.UseForeColor = true;
            this.colGoodsID.Caption = "货号";
            this.colGoodsID.ColumnEdit = this.repositoryItemLueGoods;
            this.colGoodsID.FieldName = "GoodsID";
            this.colGoodsID.Name = "colGoodsID";
            this.colGoodsID.Visible = true;
            this.colGoodsID.VisibleIndex = 0;
            this.colGoodsID.Width = 42;
            // 
            // repositoryItemLueGoods
            // 
            this.repositoryItemLueGoods.AutoHeight = false;
            this.repositoryItemLueGoods.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.repositoryItemLueGoods.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLueGoods.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("货号", "货号", 38, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("品名", "品名", 41, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("单价", "单价", 36, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("外箱规格", "外箱规格"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("规格", "规格"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("装箱数", "装箱数", 31, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("内盒", "内盒", 63, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("单位", "单位", 32, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemLueGoods.DataSource = this.vGoodsBindingSource;
            this.repositoryItemLueGoods.DisplayMember = "货号";
            this.repositoryItemLueGoods.DropDownRows = 15;
            this.repositoryItemLueGoods.Name = "repositoryItemLueGoods";
            this.repositoryItemLueGoods.PopupWidth = 600;
            this.repositoryItemLueGoods.ValueMember = "ID";
            this.repositoryItemLueGoods.EditValueChanged += new System.EventHandler(this.repositoryItemLueGoods_EditValueChanged);
            // 
            // vGoodsBindingSource
            // 
            this.vGoodsBindingSource.DataSource = typeof(EDMX.VGoods);
            // 
            // colName
            // 
            this.colName.Caption = "品名";
            this.colName.FieldName = "colName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 121;
            // 
            // colPackaging
            // 
            this.colPackaging.Caption = "包装方式";
            this.colPackaging.FieldName = "colPackaging";
            this.colPackaging.Name = "colPackaging";
            this.colPackaging.OptionsColumn.AllowEdit = false;
            this.colPackaging.OptionsColumn.ReadOnly = true;
            this.colPackaging.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colPackaging.Visible = true;
            this.colPackaging.VisibleIndex = 2;
            this.colPackaging.Width = 28;
            // 
            // colMEAS
            // 
            this.colMEAS.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.colMEAS.AppearanceHeader.Options.UseForeColor = true;
            this.colMEAS.Caption = "外箱规格";
            this.colMEAS.FieldName = "MEAS";
            this.colMEAS.Name = "colMEAS";
            this.colMEAS.Visible = true;
            this.colMEAS.VisibleIndex = 3;
            this.colMEAS.Width = 33;
            // 
            // colSPEC
            // 
            this.colSPEC.Caption = "规格";
            this.colSPEC.FieldName = "colSPEC";
            this.colSPEC.Name = "colSPEC";
            this.colSPEC.OptionsColumn.AllowEdit = false;
            this.colSPEC.OptionsColumn.ReadOnly = true;
            this.colSPEC.Visible = true;
            this.colSPEC.VisibleIndex = 4;
            this.colSPEC.Width = 33;
            // 
            // colQty
            // 
            this.colQty.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.colQty.AppearanceHeader.Options.UseForeColor = true;
            this.colQty.Caption = "箱数";
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0}")});
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 5;
            this.colQty.Width = 31;
            // 
            // colPCS
            // 
            this.colPCS.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.colPCS.AppearanceHeader.Options.UseForeColor = true;
            this.colPCS.Caption = "装箱数";
            this.colPCS.FieldName = "PCS";
            this.colPCS.Name = "colPCS";
            this.colPCS.Visible = true;
            this.colPCS.VisibleIndex = 6;
            this.colPCS.Width = 31;
            // 
            // colInnerBox
            // 
            this.colInnerBox.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.colInnerBox.AppearanceHeader.Options.UseForeColor = true;
            this.colInnerBox.Caption = "内盒";
            this.colInnerBox.FieldName = "InnerBox";
            this.colInnerBox.Name = "colInnerBox";
            this.colInnerBox.Visible = true;
            this.colInnerBox.VisibleIndex = 7;
            this.colInnerBox.Width = 20;
            // 
            // colTotalQty
            // 
            this.colTotalQty.Caption = "总数量";
            this.colTotalQty.FieldName = "colTotalQty";
            this.colTotalQty.Name = "colTotalQty";
            this.colTotalQty.OptionsColumn.AllowEdit = false;
            this.colTotalQty.OptionsColumn.ReadOnly = true;
            this.colTotalQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "colTotalQty", "{0}")});
            this.colTotalQty.UnboundExpression = "[Qty] * [PCS]";
            this.colTotalQty.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colTotalQty.Visible = true;
            this.colTotalQty.VisibleIndex = 8;
            this.colTotalQty.Width = 31;
            // 
            // colUnit
            // 
            this.colUnit.Caption = "单位";
            this.colUnit.FieldName = "colUnit";
            this.colUnit.Name = "colUnit";
            this.colUnit.OptionsColumn.AllowEdit = false;
            this.colUnit.OptionsColumn.ReadOnly = true;
            this.colUnit.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 9;
            this.colUnit.Width = 20;
            // 
            // colPrice
            // 
            this.colPrice.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.colPrice.AppearanceHeader.Options.UseForeColor = true;
            this.colPrice.Caption = "单价";
            this.colPrice.DisplayFormat.FormatString = "c5";
            this.colPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 10;
            this.colPrice.Width = 31;
            // 
            // colAMT
            // 
            this.colAMT.Caption = "金额";
            this.colAMT.DisplayFormat.FormatString = "c";
            this.colAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAMT.FieldName = "colAMT";
            this.colAMT.Name = "colAMT";
            this.colAMT.OptionsColumn.AllowEdit = false;
            this.colAMT.OptionsColumn.ReadOnly = true;
            this.colAMT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "colAMT", "{0:c}")});
            this.colAMT.UnboundExpression = "Round([Qty] * Iif([PCS] ==  0, 1 , [PCS]) * [Price] * [Discount]  +  [OtherFee], " +
    "2)";
            this.colAMT.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colAMT.Visible = true;
            this.colAMT.VisibleIndex = 13;
            this.colAMT.Width = 31;
            // 
            // colPriceNoTax
            // 
            this.colPriceNoTax.Caption = "去税单价";
            this.colPriceNoTax.DisplayFormat.FormatString = "c6";
            this.colPriceNoTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPriceNoTax.FieldName = "PriceNoTax";
            this.colPriceNoTax.Name = "colPriceNoTax";
            // 
            // colAMTNoTax
            // 
            this.colAMTNoTax.Caption = "去税金额";
            this.colAMTNoTax.DisplayFormat.FormatString = "c";
            this.colAMTNoTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAMTNoTax.FieldName = "colAMTNoTax";
            this.colAMTNoTax.Name = "colAMTNoTax";
            this.colAMTNoTax.OptionsColumn.ReadOnly = true;
            this.colAMTNoTax.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "colAMTNoTax", "{0}")});
            this.colAMTNoTax.UnboundExpression = "Iif(([Qty] * [PCS] * [PriceNoTax] * [Discount])==0,[Qty] * [PCS] * [PriceNoTax] *" +
    " [Discount]  , [Qty] * [PCS] * [PriceNoTax] * [Discount]  +  [OtherFee])";
            this.colAMTNoTax.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // colDiscount
            // 
            this.colDiscount.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.colDiscount.AppearanceHeader.Options.UseForeColor = true;
            this.colDiscount.Caption = "折扣";
            this.colDiscount.FieldName = "Discount";
            this.colDiscount.Name = "colDiscount";
            this.colDiscount.Visible = true;
            this.colDiscount.VisibleIndex = 11;
            this.colDiscount.Width = 20;
            // 
            // colOtherFee
            // 
            this.colOtherFee.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.colOtherFee.AppearanceHeader.Options.UseForeColor = true;
            this.colOtherFee.Caption = "额外费用";
            this.colOtherFee.DisplayFormat.FormatString = "c";
            this.colOtherFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOtherFee.FieldName = "OtherFee";
            this.colOtherFee.Name = "colOtherFee";
            this.colOtherFee.Visible = true;
            this.colOtherFee.VisibleIndex = 12;
            this.colOtherFee.Width = 31;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "colRemark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsColumn.AllowEdit = false;
            this.colRemark.OptionsColumn.ReadOnly = true;
            this.colRemark.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 14;
            this.colRemark.Width = 71;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // deAuditDate
            // 
            this.deAuditDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderHdBindingSource, "AuditDate", true));
            this.deAuditDate.EditValue = null;
            this.deAuditDate.Enabled = false;
            this.deAuditDate.Location = new System.Drawing.Point(333, 144);
            this.deAuditDate.Name = "deAuditDate";
            this.deAuditDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deAuditDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deAuditDate.Size = new System.Drawing.Size(253, 20);
            this.deAuditDate.StyleController = this.layoutControl;
            this.deAuditDate.TabIndex = 13;
            // 
            // deMakeDate
            // 
            this.deMakeDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderHdBindingSource, "MakeDate", true));
            this.deMakeDate.EditValue = null;
            this.deMakeDate.Enabled = false;
            this.deMakeDate.Location = new System.Drawing.Point(333, 120);
            this.deMakeDate.Name = "deMakeDate";
            this.deMakeDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deMakeDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deMakeDate.Size = new System.Drawing.Size(253, 20);
            this.deMakeDate.StyleController = this.layoutControl;
            this.deMakeDate.TabIndex = 11;
            // 
            // meRemark
            // 
            this.meRemark.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderHdBindingSource, "Remark", true));
            this.meRemark.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderHdBindingSource, "Remark", true));
            this.meRemark.EnterMoveNextControl = true;
            this.meRemark.Location = new System.Drawing.Point(333, 168);
            this.meRemark.Name = "meRemark";
            this.meRemark.Size = new System.Drawing.Size(253, 36);
            this.meRemark.StyleController = this.layoutControl;
            this.meRemark.TabIndex = 15;
            // 
            // txtContacts
            // 
            this.txtContacts.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderHdBindingSource, "Contacts", true));
            this.txtContacts.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderHdBindingSource, "Contacts", true));
            this.txtContacts.EnterMoveNextControl = true;
            this.txtContacts.Location = new System.Drawing.Point(333, 72);
            this.txtContacts.Name = "txtContacts";
            this.txtContacts.Size = new System.Drawing.Size(253, 20);
            this.txtContacts.StyleController = this.layoutControl;
            this.txtContacts.TabIndex = 7;
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
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("代码", "代码", 34, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("名称", "名称", 34, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("地址", "地址", 34, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("联系人", "联系人", 46, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("联系电话", "联系电话", 58, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueBusinessContact.Properties.DataSource = this.businessContactBindingSource;
            this.lueBusinessContact.Properties.DisplayMember = "名称";
            this.lueBusinessContact.Properties.DropDownRows = 15;
            this.lueBusinessContact.Properties.NullText = "";
            this.lueBusinessContact.Properties.PopupWidth = 500;
            this.lueBusinessContact.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lueBusinessContact.Properties.ValueMember = "ID";
            this.lueBusinessContact.Size = new System.Drawing.Size(131, 20);
            this.lueBusinessContact.StyleController = this.layoutControl;
            this.lueBusinessContact.TabIndex = 6;
            this.lueBusinessContact.EditValueChanged += new System.EventHandler(this.lueCompany_EditValueChanged);
            // 
            // businessContactBindingSource
            // 
            this.businessContactBindingSource.DataSource = typeof(EDMX.VCompany);
            // 
            // deDeliveryDate
            // 
            this.deDeliveryDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderHdBindingSource, "DeliveryDate", true));
            this.deDeliveryDate.EditValue = null;
            this.deDeliveryDate.EnterMoveNextControl = true;
            this.deDeliveryDate.Location = new System.Drawing.Point(333, 48);
            this.deDeliveryDate.Name = "deDeliveryDate";
            this.deDeliveryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDeliveryDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDeliveryDate.Size = new System.Drawing.Size(253, 20);
            this.deDeliveryDate.StyleController = this.layoutControl;
            this.deDeliveryDate.TabIndex = 5;
            // 
            // deOrderDate
            // 
            this.deOrderDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderHdBindingSource, "OrderDate", true));
            this.deOrderDate.EditValue = null;
            this.deOrderDate.EnterMoveNextControl = true;
            this.deOrderDate.Location = new System.Drawing.Point(333, 24);
            this.deOrderDate.Name = "deOrderDate";
            this.deOrderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deOrderDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deOrderDate.Size = new System.Drawing.Size(253, 20);
            this.deOrderDate.StyleController = this.layoutControl;
            this.deOrderDate.TabIndex = 3;
            // 
            // txtBillNo
            // 
            this.txtBillNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderHdBindingSource, "BillNo", true));
            this.txtBillNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderHdBindingSource, "BillNo", true));
            this.txtBillNo.EnterMoveNextControl = true;
            this.txtBillNo.Location = new System.Drawing.Point(126, 24);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Properties.ReadOnly = true;
            this.txtBillNo.Size = new System.Drawing.Size(131, 20);
            this.txtBillNo.StyleController = this.layoutControl;
            this.txtBillNo.TabIndex = 2;
            // 
            // lueMaker
            // 
            this.lueMaker.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderHdBindingSource, "Maker", true));
            this.lueMaker.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderHdBindingSource, "Maker", true));
            this.lueMaker.Enabled = false;
            this.lueMaker.Location = new System.Drawing.Point(126, 120);
            this.lueMaker.Name = "lueMaker";
            this.lueMaker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMaker.Properties.DataSource = this.vUsersInfoBindingSource;
            this.lueMaker.Properties.DisplayMember = "姓名";
            this.lueMaker.Properties.NullText = "";
            this.lueMaker.Properties.ReadOnly = true;
            this.lueMaker.Properties.ValueMember = "ID";
            this.lueMaker.Size = new System.Drawing.Size(131, 20);
            this.lueMaker.StyleController = this.layoutControl;
            this.lueMaker.TabIndex = 10;
            // 
            // vUsersInfoBindingSource
            // 
            this.vUsersInfoBindingSource.DataSource = typeof(EDMX.VUsersInfo);
            // 
            // lueAuditor
            // 
            this.lueAuditor.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderHdBindingSource, "Auditor", true));
            this.lueAuditor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderHdBindingSource, "Auditor", true));
            this.lueAuditor.Enabled = false;
            this.lueAuditor.Location = new System.Drawing.Point(126, 144);
            this.lueAuditor.Name = "lueAuditor";
            this.lueAuditor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAuditor.Properties.DataSource = this.vUsersInfoBindingSource;
            this.lueAuditor.Properties.DisplayMember = "姓名";
            this.lueAuditor.Properties.NullText = "";
            this.lueAuditor.Properties.ReadOnly = true;
            this.lueAuditor.Properties.ValueMember = "ID";
            this.lueAuditor.Size = new System.Drawing.Size(131, 20);
            this.lueAuditor.StyleController = this.layoutControl;
            this.lueAuditor.TabIndex = 12;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(640, 460);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciBillNo,
            this.lciOrderDate,
            this.lciDeliveryDate,
            this.lciBusinessContact,
            this.lciContacts,
            this.lciMaker,
            this.lciMakeDate,
            this.lciAuditor,
            this.lciAuditDate,
            this.layoutControlItem25,
            this.lciBillType,
            this.lciWarehouse,
            this.lciMainMark,
            this.lciRemark,
            this.lciWarehouseType});
            this.layoutControlGroup2.Location = new System.Drawing.Point(30, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(560, 440);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // lciBillNo
            // 
            this.lciBillNo.Control = this.txtBillNo;
            this.lciBillNo.CustomizationFormText = "订货单号";
            this.lciBillNo.Location = new System.Drawing.Point(0, 0);
            this.lciBillNo.MaxSize = new System.Drawing.Size(0, 24);
            this.lciBillNo.MinSize = new System.Drawing.Size(200, 24);
            this.lciBillNo.Name = "lciBillNo";
            this.lciBillNo.Size = new System.Drawing.Size(207, 24);
            this.lciBillNo.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciBillNo.Text = "订货单号";
            this.lciBillNo.TextSize = new System.Drawing.Size(69, 14);
            // 
            // lciOrderDate
            // 
            this.lciOrderDate.Control = this.deOrderDate;
            this.lciOrderDate.CustomizationFormText = "订货日期";
            this.lciOrderDate.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lciOrderDate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lciOrderDate.ImageOptions.Image")));
            this.lciOrderDate.Location = new System.Drawing.Point(207, 0);
            this.lciOrderDate.Name = "lciOrderDate";
            this.lciOrderDate.Size = new System.Drawing.Size(329, 24);
            this.lciOrderDate.Text = "订货日期";
            this.lciOrderDate.TextSize = new System.Drawing.Size(69, 16);
            // 
            // lciDeliveryDate
            // 
            this.lciDeliveryDate.Control = this.deDeliveryDate;
            this.lciDeliveryDate.CustomizationFormText = "交货日期";
            this.lciDeliveryDate.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lciDeliveryDate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lciDeliveryDate.ImageOptions.Image")));
            this.lciDeliveryDate.Location = new System.Drawing.Point(207, 24);
            this.lciDeliveryDate.Name = "lciDeliveryDate";
            this.lciDeliveryDate.Size = new System.Drawing.Size(329, 24);
            this.lciDeliveryDate.Text = "交货日期";
            this.lciDeliveryDate.TextSize = new System.Drawing.Size(69, 16);
            // 
            // lciBusinessContact
            // 
            this.lciBusinessContact.Control = this.lueBusinessContact;
            this.lciBusinessContact.CustomizationFormText = "业务往来";
            this.lciBusinessContact.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lciBusinessContact.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lciBusinessContact.ImageOptions.Image")));
            this.lciBusinessContact.Location = new System.Drawing.Point(0, 48);
            this.lciBusinessContact.Name = "lciBusinessContact";
            this.lciBusinessContact.Size = new System.Drawing.Size(207, 24);
            this.lciBusinessContact.Text = "业务往来";
            this.lciBusinessContact.TextSize = new System.Drawing.Size(69, 16);
            // 
            // lciContacts
            // 
            this.lciContacts.Control = this.txtContacts;
            this.lciContacts.CustomizationFormText = "联系人";
            this.lciContacts.Location = new System.Drawing.Point(207, 48);
            this.lciContacts.Name = "lciContacts";
            this.lciContacts.Size = new System.Drawing.Size(329, 24);
            this.lciContacts.Text = "联系人";
            this.lciContacts.TextSize = new System.Drawing.Size(69, 14);
            // 
            // lciMaker
            // 
            this.lciMaker.Control = this.lueMaker;
            this.lciMaker.CustomizationFormText = "制单人";
            this.lciMaker.Location = new System.Drawing.Point(0, 96);
            this.lciMaker.Name = "lciMaker";
            this.lciMaker.Size = new System.Drawing.Size(207, 24);
            this.lciMaker.Text = "制单人";
            this.lciMaker.TextSize = new System.Drawing.Size(69, 14);
            // 
            // lciMakeDate
            // 
            this.lciMakeDate.Control = this.deMakeDate;
            this.lciMakeDate.CustomizationFormText = "制单日期";
            this.lciMakeDate.Location = new System.Drawing.Point(207, 96);
            this.lciMakeDate.Name = "lciMakeDate";
            this.lciMakeDate.Size = new System.Drawing.Size(329, 24);
            this.lciMakeDate.Text = "制单日期";
            this.lciMakeDate.TextSize = new System.Drawing.Size(69, 14);
            // 
            // lciAuditor
            // 
            this.lciAuditor.Control = this.lueAuditor;
            this.lciAuditor.CustomizationFormText = "审核人";
            this.lciAuditor.Location = new System.Drawing.Point(0, 120);
            this.lciAuditor.Name = "lciAuditor";
            this.lciAuditor.Size = new System.Drawing.Size(207, 24);
            this.lciAuditor.Text = "审核人";
            this.lciAuditor.TextSize = new System.Drawing.Size(69, 14);
            // 
            // lciAuditDate
            // 
            this.lciAuditDate.Control = this.deAuditDate;
            this.lciAuditDate.CustomizationFormText = "审核日期";
            this.lciAuditDate.Location = new System.Drawing.Point(207, 120);
            this.lciAuditDate.Name = "lciAuditDate";
            this.lciAuditDate.Size = new System.Drawing.Size(329, 24);
            this.lciAuditDate.Text = "审核日期";
            this.lciAuditDate.TextSize = new System.Drawing.Size(69, 14);
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.gridControl;
            this.layoutControlItem25.CustomizationFormText = "layoutControlItem25";
            this.layoutControlItem25.Location = new System.Drawing.Point(0, 184);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(536, 232);
            this.layoutControlItem25.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem25.TextVisible = false;
            // 
            // lciBillType
            // 
            this.lciBillType.Control = this.lueBillType;
            this.lciBillType.CustomizationFormText = "单据类型";
            this.lciBillType.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lciBillType.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lciBillType.ImageOptions.Image")));
            this.lciBillType.Location = new System.Drawing.Point(0, 24);
            this.lciBillType.Name = "lciBillType";
            this.lciBillType.Size = new System.Drawing.Size(207, 24);
            this.lciBillType.Text = "单据类型";
            this.lciBillType.TextSize = new System.Drawing.Size(69, 16);
            // 
            // lciWarehouse
            // 
            this.lciWarehouse.Control = this.lueWarehouse;
            this.lciWarehouse.CustomizationFormText = "仓库";
            this.lciWarehouse.Location = new System.Drawing.Point(207, 72);
            this.lciWarehouse.Name = "lciWarehouse";
            this.lciWarehouse.Size = new System.Drawing.Size(329, 24);
            this.lciWarehouse.Text = "仓库";
            this.lciWarehouse.TextSize = new System.Drawing.Size(69, 14);
            // 
            // lciMainMark
            // 
            this.lciMainMark.Control = this.meMainMark;
            this.lciMainMark.CustomizationFormText = "正唛";
            this.lciMainMark.Location = new System.Drawing.Point(0, 144);
            this.lciMainMark.MaxSize = new System.Drawing.Size(0, 40);
            this.lciMainMark.MinSize = new System.Drawing.Size(86, 40);
            this.lciMainMark.Name = "lciMainMark";
            this.lciMainMark.Size = new System.Drawing.Size(207, 40);
            this.lciMainMark.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciMainMark.Text = "正唛";
            this.lciMainMark.TextSize = new System.Drawing.Size(69, 14);
            // 
            // lciRemark
            // 
            this.lciRemark.Control = this.meRemark;
            this.lciRemark.CustomizationFormText = "备注";
            this.lciRemark.Location = new System.Drawing.Point(207, 144);
            this.lciRemark.MaxSize = new System.Drawing.Size(0, 40);
            this.lciRemark.MinSize = new System.Drawing.Size(14, 40);
            this.lciRemark.Name = "lciRemark";
            this.lciRemark.Size = new System.Drawing.Size(329, 40);
            this.lciRemark.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciRemark.Text = "备注";
            this.lciRemark.TextSize = new System.Drawing.Size(69, 14);
            // 
            // lciWarehouseType
            // 
            this.lciWarehouseType.Control = this.lueWarehouseType;
            this.lciWarehouseType.CustomizationFormText = "仓库类型";
            this.lciWarehouseType.Location = new System.Drawing.Point(0, 72);
            this.lciWarehouseType.Name = "lciWarehouseType";
            this.lciWarehouseType.Size = new System.Drawing.Size(207, 24);
            this.lciWarehouseType.Text = "仓库类型";
            this.lciWarehouseType.TextSize = new System.Drawing.Size(69, 14);
            // 
            // lciPrev
            // 
            this.lciPrev.Control = this.btnPrev;
            this.lciPrev.CustomizationFormText = "Prev";
            this.lciPrev.Location = new System.Drawing.Point(0, 0);
            this.lciPrev.MaxSize = new System.Drawing.Size(30, 0);
            this.lciPrev.MinSize = new System.Drawing.Size(30, 26);
            this.lciPrev.Name = "lciPrev";
            this.lciPrev.Size = new System.Drawing.Size(30, 440);
            this.lciPrev.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciPrev.Text = "Prev";
            this.lciPrev.TextSize = new System.Drawing.Size(0, 0);
            this.lciPrev.TextVisible = false;
            // 
            // lciNext
            // 
            this.lciNext.Control = this.btnNext;
            this.lciNext.CustomizationFormText = "Next";
            this.lciNext.Location = new System.Drawing.Point(590, 0);
            this.lciNext.MaxSize = new System.Drawing.Size(30, 0);
            this.lciNext.MinSize = new System.Drawing.Size(30, 26);
            this.lciNext.Name = "lciNext";
            this.lciNext.Size = new System.Drawing.Size(30, 440);
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
            this.hideContainerBottom.Controls.Add(this.dpBOM);
            this.hideContainerBottom.Controls.Add(this.dpAssemble);
            this.hideContainerBottom.Controls.Add(this.dpMoldMaterial);
            this.hideContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hideContainerBottom.Location = new System.Drawing.Point(0, 460);
            this.hideContainerBottom.Name = "hideContainerBottom";
            this.hideContainerBottom.Size = new System.Drawing.Size(640, 20);
            // 
            // dpBOM
            // 
            this.dpBOM.Controls.Add(this.controlContainer1);
            this.dpBOM.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpBOM.ID = new System.Guid("a915ddcc-d19c-4a03-9433-aa5f76ca27a1");
            this.dpBOM.Location = new System.Drawing.Point(0, 0);
            this.dpBOM.Name = "dpBOM";
            this.dpBOM.Options.ShowCloseButton = false;
            this.dpBOM.OriginalSize = new System.Drawing.Size(200, 400);
            this.dpBOM.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpBOM.SavedIndex = 0;
            this.dpBOM.SavedSizeFactor = 1D;
            this.dpBOM.Size = new System.Drawing.Size(640, 400);
            this.dpBOM.Text = "包装清单";
            this.dpBOM.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.gcBOM);
            this.controlContainer1.Location = new System.Drawing.Point(4, 24);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(632, 372);
            this.controlContainer1.TabIndex = 0;
            // 
            // gcBOM
            // 
            this.gcBOM.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcBOM.DataSource = this.billDtlByBOMBindingSource;
            this.gcBOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBOM.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcBOM.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcBOM.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcBOM.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcBOM.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcBOM.Location = new System.Drawing.Point(0, 0);
            this.gcBOM.MainView = this.gvBOM;
            this.gcBOM.Name = "gcBOM";
            this.gcBOM.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLueGoodsByBOM});
            this.gcBOM.Size = new System.Drawing.Size(632, 372);
            this.gcBOM.TabIndex = 25;
            this.gcBOM.UseEmbeddedNavigator = true;
            this.gcBOM.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBOM});
            // 
            // billDtlByBOMBindingSource
            // 
            this.billDtlByBOMBindingSource.DataSource = typeof(EDMX.VOrderDtlByBOM);
            // 
            // gvBOM
            // 
            this.gvBOM.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.colName1,
            this.colSPEC1,
            this.colQty1,
            this.colStockQty,
            this.colShortage,
            this.colUnit1,
            this.colPCS1,
            this.colInnerBox1,
            this.colTotalQty1,
            this.colNWeight,
            this.colCounts1,
            this.colCavityNumber1,
            this.colModulus,
            this.colPrice1,
            this.colAMT1,
            this.colPriceNoTax1,
            this.colAMTNoTax1,
            this.colDiscount1,
            this.colOtherFee1,
            this.colRemark1});
            this.gvBOM.GridControl = this.gcBOM;
            this.gvBOM.Name = "gvBOM";
            this.gvBOM.OptionsBehavior.Editable = false;
            this.gvBOM.OptionsNavigation.AutoFocusNewRow = true;
            this.gvBOM.OptionsNavigation.AutoMoveRowFocus = false;
            this.gvBOM.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvBOM.OptionsView.EnableAppearanceEvenRow = true;
            this.gvBOM.OptionsView.EnableAppearanceOddRow = true;
            this.gvBOM.OptionsView.ShowFooter = true;
            this.gvBOM.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvBOM_CustomUnboundColumnData);
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "HdID";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "货号";
            this.gridColumn3.ColumnEdit = this.repositoryItemLueGoodsByBOM;
            this.gridColumn3.FieldName = "GoodsID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // repositoryItemLueGoodsByBOM
            // 
            this.repositoryItemLueGoodsByBOM.AutoHeight = false;
            this.repositoryItemLueGoodsByBOM.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.repositoryItemLueGoodsByBOM.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLueGoodsByBOM.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("货号", "货号", 34, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("品名", "品名", 34, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("数量", "数量", 34, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("单价", "单价", 34, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("单位", "单位", 34, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("规格", "规格", 34, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemLueGoodsByBOM.DataSource = this.vGoodsByBOMBindingSource;
            this.repositoryItemLueGoodsByBOM.DisplayMember = "货号";
            this.repositoryItemLueGoodsByBOM.DropDownRows = 15;
            this.repositoryItemLueGoodsByBOM.Name = "repositoryItemLueGoodsByBOM";
            this.repositoryItemLueGoodsByBOM.PopupWidth = 600;
            this.repositoryItemLueGoodsByBOM.ValueMember = "ID";
            // 
            // vGoodsByBOMBindingSource
            // 
            this.vGoodsByBOMBindingSource.DataSource = typeof(EDMX.VGoodsByBOM);
            // 
            // colName1
            // 
            this.colName1.Caption = "品名";
            this.colName1.FieldName = "colName1";
            this.colName1.Name = "colName1";
            this.colName1.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colName1.Visible = true;
            this.colName1.VisibleIndex = 1;
            // 
            // colSPEC1
            // 
            this.colSPEC1.Caption = "规格";
            this.colSPEC1.FieldName = "colSPEC1";
            this.colSPEC1.Name = "colSPEC1";
            this.colSPEC1.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colSPEC1.Visible = true;
            this.colSPEC1.VisibleIndex = 2;
            // 
            // colQty1
            // 
            this.colQty1.Caption = "数量";
            this.colQty1.FieldName = "Qty";
            this.colQty1.Name = "colQty1";
            this.colQty1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0}")});
            this.colQty1.Visible = true;
            this.colQty1.VisibleIndex = 3;
            // 
            // colStockQty
            // 
            this.colStockQty.Caption = "库存数量";
            this.colStockQty.FieldName = "StockQty";
            this.colStockQty.Name = "colStockQty";
            this.colStockQty.Visible = true;
            this.colStockQty.VisibleIndex = 4;
            // 
            // colShortage
            // 
            this.colShortage.Caption = "缺少数量";
            this.colShortage.FieldName = "Shortage";
            this.colShortage.Name = "colShortage";
            this.colShortage.Visible = true;
            this.colShortage.VisibleIndex = 5;
            // 
            // colUnit1
            // 
            this.colUnit1.Caption = "单位";
            this.colUnit1.FieldName = "colUnit1";
            this.colUnit1.Name = "colUnit1";
            this.colUnit1.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colUnit1.Visible = true;
            this.colUnit1.VisibleIndex = 6;
            // 
            // colPCS1
            // 
            this.colPCS1.Caption = "装箱数";
            this.colPCS1.FieldName = "PCS";
            this.colPCS1.Name = "colPCS1";
            this.colPCS1.OptionsColumn.ReadOnly = true;
            // 
            // colInnerBox1
            // 
            this.colInnerBox1.Caption = "内盒";
            this.colInnerBox1.FieldName = "InnerBox";
            this.colInnerBox1.Name = "colInnerBox1";
            this.colInnerBox1.OptionsColumn.ReadOnly = true;
            // 
            // colTotalQty1
            // 
            this.colTotalQty1.Caption = "总数量";
            this.colTotalQty1.FieldName = "colTotalQty";
            this.colTotalQty1.Name = "colTotalQty1";
            this.colTotalQty1.OptionsColumn.ReadOnly = true;
            this.colTotalQty1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "colTotalQty", "{0}")});
            this.colTotalQty1.UnboundExpression = "[Qty] * [PCS]";
            this.colTotalQty1.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // colNWeight
            // 
            this.colNWeight.Caption = "净重";
            this.colNWeight.FieldName = "NWeight";
            this.colNWeight.Name = "colNWeight";
            this.colNWeight.Visible = true;
            this.colNWeight.VisibleIndex = 7;
            // 
            // colCounts1
            // 
            this.colCounts1.Caption = "个数";
            this.colCounts1.FieldName = "Counts";
            this.colCounts1.Name = "colCounts1";
            this.colCounts1.Visible = true;
            this.colCounts1.VisibleIndex = 8;
            // 
            // colCavityNumber1
            // 
            this.colCavityNumber1.Caption = "一出几";
            this.colCavityNumber1.FieldName = "一出几";
            this.colCavityNumber1.Name = "colCavityNumber1";
            this.colCavityNumber1.Visible = true;
            this.colCavityNumber1.VisibleIndex = 9;
            // 
            // colModulus
            // 
            this.colModulus.Caption = "模数";
            this.colModulus.FieldName = "Modulus";
            this.colModulus.Name = "colModulus";
            this.colModulus.Visible = true;
            this.colModulus.VisibleIndex = 10;
            // 
            // colPrice1
            // 
            this.colPrice1.Caption = "单价";
            this.colPrice1.DisplayFormat.FormatString = "c4";
            this.colPrice1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrice1.FieldName = "Price";
            this.colPrice1.Name = "colPrice1";
            this.colPrice1.Visible = true;
            this.colPrice1.VisibleIndex = 11;
            // 
            // colAMT1
            // 
            this.colAMT1.Caption = "金额";
            this.colAMT1.DisplayFormat.FormatString = "c";
            this.colAMT1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAMT1.FieldName = "colAMT";
            this.colAMT1.Name = "colAMT1";
            this.colAMT1.OptionsColumn.ReadOnly = true;
            this.colAMT1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "colAMT", "{0:c}")});
            this.colAMT1.UnboundExpression = "[Qty] * [PCS] * [Price] * [Discount]  +  [OtherFee]";
            this.colAMT1.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colAMT1.Visible = true;
            this.colAMT1.VisibleIndex = 14;
            // 
            // colPriceNoTax1
            // 
            this.colPriceNoTax1.Caption = "去税单价";
            this.colPriceNoTax1.DisplayFormat.FormatString = "c6";
            this.colPriceNoTax1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPriceNoTax1.FieldName = "PriceNoTax";
            this.colPriceNoTax1.Name = "colPriceNoTax1";
            // 
            // colAMTNoTax1
            // 
            this.colAMTNoTax1.Caption = "去税金额";
            this.colAMTNoTax1.DisplayFormat.FormatString = "c";
            this.colAMTNoTax1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAMTNoTax1.FieldName = "colAMTNoTax";
            this.colAMTNoTax1.Name = "colAMTNoTax1";
            this.colAMTNoTax1.OptionsColumn.ReadOnly = true;
            this.colAMTNoTax1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "colAMTNoTax", "{0}")});
            this.colAMTNoTax1.UnboundExpression = "Iif(([Qty] * [PCS] * [PriceNoTax] * [Discount])==0,[Qty] * [PCS] * [PriceNoTax] *" +
    " [Discount]  , [Qty] * [PCS] * [PriceNoTax] * [Discount]  +  [OtherFee])";
            this.colAMTNoTax1.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // colDiscount1
            // 
            this.colDiscount1.Caption = "折扣";
            this.colDiscount1.FieldName = "Discount";
            this.colDiscount1.Name = "colDiscount1";
            this.colDiscount1.Visible = true;
            this.colDiscount1.VisibleIndex = 12;
            // 
            // colOtherFee1
            // 
            this.colOtherFee1.Caption = "额外费用";
            this.colOtherFee1.DisplayFormat.FormatString = "c";
            this.colOtherFee1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOtherFee1.FieldName = "OtherFee";
            this.colOtherFee1.Name = "colOtherFee1";
            this.colOtherFee1.Visible = true;
            this.colOtherFee1.VisibleIndex = 13;
            // 
            // colRemark1
            // 
            this.colRemark1.Caption = "备注";
            this.colRemark1.FieldName = "colRemark1";
            this.colRemark1.Name = "colRemark1";
            this.colRemark1.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colRemark1.Visible = true;
            this.colRemark1.VisibleIndex = 15;
            // 
            // dpAssemble
            // 
            this.dpAssemble.Controls.Add(this.dockPanel1_Container);
            this.dpAssemble.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpAssemble.FloatVertical = true;
            this.dpAssemble.ID = new System.Guid("4c517f94-4e9a-49f3-98ce-8ebb010a51bf");
            this.dpAssemble.Location = new System.Drawing.Point(0, 0);
            this.dpAssemble.Name = "dpAssemble";
            this.dpAssemble.Options.ShowCloseButton = false;
            this.dpAssemble.OriginalSize = new System.Drawing.Size(200, 400);
            this.dpAssemble.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpAssemble.SavedIndex = 0;
            this.dpAssemble.SavedSizeFactor = 1D;
            this.dpAssemble.Size = new System.Drawing.Size(640, 400);
            this.dpAssemble.Text = "装配清单";
            this.dpAssemble.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gcAssemble);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 24);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(632, 372);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // gcAssemble
            // 
            this.gcAssemble.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcAssemble.DataSource = this.billDtlByAssembleBindingSource;
            this.gcAssemble.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAssemble.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcAssemble.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcAssemble.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcAssemble.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcAssemble.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcAssemble.Location = new System.Drawing.Point(0, 0);
            this.gcAssemble.MainView = this.gvAssemble;
            this.gcAssemble.Name = "gcAssemble";
            this.gcAssemble.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gcAssemble.Size = new System.Drawing.Size(632, 372);
            this.gcAssemble.TabIndex = 26;
            this.gcAssemble.UseEmbeddedNavigator = true;
            this.gcAssemble.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAssemble});
            // 
            // billDtlByAssembleBindingSource
            // 
            this.billDtlByAssembleBindingSource.DataSource = typeof(EDMX.VOrderDtlByBOM);
            // 
            // gvAssemble
            // 
            this.gvAssemble.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.colGoodsID3,
            this.colName3,
            this.colSPEC3,
            this.colQty3,
            this.colStockQty3,
            this.colShortage3,
            this.colUnit3,
            this.colPCS3,
            this.colInnerBox3,
            this.colTotalQty3,
            this.colNWeight3,
            this.colCounts,
            this.colCavityNumber,
            this.colModulus3,
            this.colPrice3,
            this.colAMT3,
            this.colPriceNoTax3,
            this.colAMTNoTax3,
            this.colDiscount3,
            this.colOtherFee3,
            this.colRemark3});
            this.gvAssemble.GridControl = this.gcAssemble;
            this.gvAssemble.Name = "gvAssemble";
            this.gvAssemble.OptionsBehavior.Editable = false;
            this.gvAssemble.OptionsNavigation.AutoFocusNewRow = true;
            this.gvAssemble.OptionsNavigation.AutoMoveRowFocus = false;
            this.gvAssemble.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvAssemble.OptionsView.EnableAppearanceEvenRow = true;
            this.gvAssemble.OptionsView.EnableAppearanceOddRow = true;
            this.gvAssemble.OptionsView.ShowFooter = true;
            this.gvAssemble.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvAssemble_CustomUnboundColumnData);
            // 
            // gridColumn7
            // 
            this.gridColumn7.FieldName = "ID";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn8
            // 
            this.gridColumn8.FieldName = "HdID";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // colGoodsID3
            // 
            this.colGoodsID3.Caption = "货号";
            this.colGoodsID3.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colGoodsID3.FieldName = "GoodsID";
            this.colGoodsID3.Name = "colGoodsID3";
            this.colGoodsID3.Visible = true;
            this.colGoodsID3.VisibleIndex = 0;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("货号", "货号", 34, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("品名", "品名", 34, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("数量", "数量", 34, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("单价", "单价", 34, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("单位", "单位", 34, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("规格", "规格", 34, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemLookUpEdit1.DataSource = this.vGoodsByBOMBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "货号";
            this.repositoryItemLookUpEdit1.DropDownRows = 15;
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.PopupWidth = 600;
            this.repositoryItemLookUpEdit1.ValueMember = "ID";
            // 
            // colName3
            // 
            this.colName3.Caption = "品名";
            this.colName3.FieldName = "colName1";
            this.colName3.Name = "colName3";
            this.colName3.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colName3.Visible = true;
            this.colName3.VisibleIndex = 1;
            // 
            // colSPEC3
            // 
            this.colSPEC3.Caption = "规格";
            this.colSPEC3.FieldName = "colSPEC1";
            this.colSPEC3.Name = "colSPEC3";
            this.colSPEC3.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colSPEC3.Visible = true;
            this.colSPEC3.VisibleIndex = 2;
            // 
            // colQty3
            // 
            this.colQty3.Caption = "数量";
            this.colQty3.FieldName = "Qty";
            this.colQty3.Name = "colQty3";
            this.colQty3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0}")});
            this.colQty3.Visible = true;
            this.colQty3.VisibleIndex = 3;
            // 
            // colStockQty3
            // 
            this.colStockQty3.Caption = "库存数量";
            this.colStockQty3.FieldName = "StockQty";
            this.colStockQty3.Name = "colStockQty3";
            this.colStockQty3.Visible = true;
            this.colStockQty3.VisibleIndex = 4;
            // 
            // colShortage3
            // 
            this.colShortage3.Caption = "缺少数量";
            this.colShortage3.FieldName = "Shortage";
            this.colShortage3.Name = "colShortage3";
            this.colShortage3.Visible = true;
            this.colShortage3.VisibleIndex = 5;
            // 
            // colUnit3
            // 
            this.colUnit3.Caption = "单位";
            this.colUnit3.FieldName = "colUnit1";
            this.colUnit3.Name = "colUnit3";
            this.colUnit3.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colUnit3.Visible = true;
            this.colUnit3.VisibleIndex = 6;
            // 
            // colPCS3
            // 
            this.colPCS3.Caption = "装箱数";
            this.colPCS3.FieldName = "PCS";
            this.colPCS3.Name = "colPCS3";
            this.colPCS3.OptionsColumn.ReadOnly = true;
            // 
            // colInnerBox3
            // 
            this.colInnerBox3.Caption = "内盒";
            this.colInnerBox3.FieldName = "InnerBox";
            this.colInnerBox3.Name = "colInnerBox3";
            this.colInnerBox3.OptionsColumn.ReadOnly = true;
            // 
            // colTotalQty3
            // 
            this.colTotalQty3.Caption = "总数量";
            this.colTotalQty3.FieldName = "colTotalQty";
            this.colTotalQty3.Name = "colTotalQty3";
            this.colTotalQty3.OptionsColumn.ReadOnly = true;
            this.colTotalQty3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "colTotalQty", "{0}")});
            this.colTotalQty3.UnboundExpression = "[Qty] * [PCS]";
            this.colTotalQty3.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // colNWeight3
            // 
            this.colNWeight3.Caption = "净重";
            this.colNWeight3.FieldName = "NWeight";
            this.colNWeight3.Name = "colNWeight3";
            this.colNWeight3.Visible = true;
            this.colNWeight3.VisibleIndex = 7;
            // 
            // colCounts
            // 
            this.colCounts.Caption = "个数";
            this.colCounts.FieldName = "Counts";
            this.colCounts.Name = "colCounts";
            this.colCounts.Visible = true;
            this.colCounts.VisibleIndex = 8;
            // 
            // colCavityNumber
            // 
            this.colCavityNumber.Caption = "一出几";
            this.colCavityNumber.FieldName = "一出几";
            this.colCavityNumber.Name = "colCavityNumber";
            this.colCavityNumber.Visible = true;
            this.colCavityNumber.VisibleIndex = 9;
            // 
            // colModulus3
            // 
            this.colModulus3.Caption = "模数";
            this.colModulus3.FieldName = "Modulus";
            this.colModulus3.Name = "colModulus3";
            this.colModulus3.Visible = true;
            this.colModulus3.VisibleIndex = 10;
            // 
            // colPrice3
            // 
            this.colPrice3.Caption = "单价";
            this.colPrice3.DisplayFormat.FormatString = "c4";
            this.colPrice3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrice3.FieldName = "Price";
            this.colPrice3.Name = "colPrice3";
            this.colPrice3.Visible = true;
            this.colPrice3.VisibleIndex = 11;
            // 
            // colAMT3
            // 
            this.colAMT3.Caption = "金额";
            this.colAMT3.DisplayFormat.FormatString = "c";
            this.colAMT3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAMT3.FieldName = "colAMT";
            this.colAMT3.Name = "colAMT3";
            this.colAMT3.OptionsColumn.ReadOnly = true;
            this.colAMT3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "colAMT", "{0:c}")});
            this.colAMT3.UnboundExpression = "[Qty] * [PCS] * [Price] * [Discount]  +  [OtherFee]";
            this.colAMT3.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colAMT3.Visible = true;
            this.colAMT3.VisibleIndex = 14;
            // 
            // colPriceNoTax3
            // 
            this.colPriceNoTax3.Caption = "去税单价";
            this.colPriceNoTax3.DisplayFormat.FormatString = "c6";
            this.colPriceNoTax3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPriceNoTax3.FieldName = "PriceNoTax";
            this.colPriceNoTax3.Name = "colPriceNoTax3";
            // 
            // colAMTNoTax3
            // 
            this.colAMTNoTax3.Caption = "去税金额";
            this.colAMTNoTax3.DisplayFormat.FormatString = "c";
            this.colAMTNoTax3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAMTNoTax3.FieldName = "colAMTNoTax";
            this.colAMTNoTax3.Name = "colAMTNoTax3";
            this.colAMTNoTax3.OptionsColumn.ReadOnly = true;
            this.colAMTNoTax3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "colAMTNoTax", "{0}")});
            this.colAMTNoTax3.UnboundExpression = "Iif(([Qty] * [PCS] * [PriceNoTax] * [Discount])==0,[Qty] * [PCS] * [PriceNoTax] *" +
    " [Discount]  , [Qty] * [PCS] * [PriceNoTax] * [Discount]  +  [OtherFee])";
            this.colAMTNoTax3.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // colDiscount3
            // 
            this.colDiscount3.Caption = "折扣";
            this.colDiscount3.FieldName = "Discount";
            this.colDiscount3.Name = "colDiscount3";
            this.colDiscount3.Visible = true;
            this.colDiscount3.VisibleIndex = 12;
            // 
            // colOtherFee3
            // 
            this.colOtherFee3.Caption = "额外费用";
            this.colOtherFee3.DisplayFormat.FormatString = "c";
            this.colOtherFee3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOtherFee3.FieldName = "OtherFee";
            this.colOtherFee3.Name = "colOtherFee3";
            this.colOtherFee3.Visible = true;
            this.colOtherFee3.VisibleIndex = 13;
            // 
            // colRemark3
            // 
            this.colRemark3.Caption = "备注";
            this.colRemark3.FieldName = "colRemark1";
            this.colRemark3.Name = "colRemark3";
            this.colRemark3.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colRemark3.Visible = true;
            this.colRemark3.VisibleIndex = 15;
            // 
            // dpMoldMaterial
            // 
            this.dpMoldMaterial.Controls.Add(this.controlContainer2);
            this.dpMoldMaterial.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpMoldMaterial.FloatVertical = true;
            this.dpMoldMaterial.ID = new System.Guid("9e1a74aa-b77b-4ee7-9682-c3ad8b5d0e7e");
            this.dpMoldMaterial.Location = new System.Drawing.Point(0, 0);
            this.dpMoldMaterial.Name = "dpMoldMaterial";
            this.dpMoldMaterial.Options.ShowCloseButton = false;
            this.dpMoldMaterial.OriginalSize = new System.Drawing.Size(200, 400);
            this.dpMoldMaterial.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpMoldMaterial.SavedIndex = 0;
            this.dpMoldMaterial.SavedSizeFactor = 1D;
            this.dpMoldMaterial.Size = new System.Drawing.Size(640, 400);
            this.dpMoldMaterial.Text = "模具原料清单";
            this.dpMoldMaterial.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // controlContainer2
            // 
            this.controlContainer2.Controls.Add(this.gcMoldMaterial);
            this.controlContainer2.Location = new System.Drawing.Point(4, 24);
            this.controlContainer2.Name = "controlContainer2";
            this.controlContainer2.Size = new System.Drawing.Size(632, 372);
            this.controlContainer2.TabIndex = 0;
            // 
            // gcMoldMaterial
            // 
            this.gcMoldMaterial.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcMoldMaterial.DataSource = this.vFSMOrderDtlByMoldMaterialBindingSource;
            this.gcMoldMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMoldMaterial.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcMoldMaterial.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcMoldMaterial.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcMoldMaterial.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcMoldMaterial.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcMoldMaterial.Location = new System.Drawing.Point(0, 0);
            this.gcMoldMaterial.MainView = this.gvMoldMaterial;
            this.gcMoldMaterial.Name = "gcMoldMaterial";
            this.gcMoldMaterial.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit2});
            this.gcMoldMaterial.Size = new System.Drawing.Size(632, 372);
            this.gcMoldMaterial.TabIndex = 26;
            this.gcMoldMaterial.UseEmbeddedNavigator = true;
            this.gcMoldMaterial.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMoldMaterial});
            // 
            // vFSMOrderDtlByMoldMaterialBindingSource
            // 
            this.vFSMOrderDtlByMoldMaterialBindingSource.DataSource = typeof(EDMX.VFSMOrderDtlByMoldMaterial);
            // 
            // gvMoldMaterial
            // 
            this.gvMoldMaterial.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.colName2,
            this.colSPEC2,
            this.gridColumn9,
            this.colUnit2,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.colRemark2});
            this.gvMoldMaterial.GridControl = this.gcMoldMaterial;
            this.gvMoldMaterial.Name = "gvMoldMaterial";
            this.gvMoldMaterial.OptionsBehavior.Editable = false;
            this.gvMoldMaterial.OptionsNavigation.AutoFocusNewRow = true;
            this.gvMoldMaterial.OptionsNavigation.AutoMoveRowFocus = false;
            this.gvMoldMaterial.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvMoldMaterial.OptionsView.EnableAppearanceEvenRow = true;
            this.gvMoldMaterial.OptionsView.EnableAppearanceOddRow = true;
            this.gvMoldMaterial.OptionsView.ShowFooter = true;
            this.gvMoldMaterial.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvMoldMaterial_CustomUnboundColumnData);
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "ID";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn5
            // 
            this.gridColumn5.FieldName = "HdID";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "货号";
            this.gridColumn6.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.gridColumn6.FieldName = "GoodsID";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("货号", "货号", 34, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("品名", "品名", 34, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("数量", "数量", 34, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("单价", "单价", 34, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("单位", "单位", 34, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("规格", "规格", 34, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemLookUpEdit2.DataSource = this.vGoodsByBOMBindingSource;
            this.repositoryItemLookUpEdit2.DisplayMember = "货号";
            this.repositoryItemLookUpEdit2.DropDownRows = 15;
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.PopupWidth = 600;
            this.repositoryItemLookUpEdit2.ValueMember = "ID";
            // 
            // colName2
            // 
            this.colName2.Caption = "品名";
            this.colName2.FieldName = "colName2";
            this.colName2.Name = "colName2";
            this.colName2.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colName2.Visible = true;
            this.colName2.VisibleIndex = 1;
            // 
            // colSPEC2
            // 
            this.colSPEC2.Caption = "规格";
            this.colSPEC2.FieldName = "colSPEC2";
            this.colSPEC2.Name = "colSPEC2";
            this.colSPEC2.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colSPEC2.Visible = true;
            this.colSPEC2.VisibleIndex = 2;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "数量";
            this.gridColumn9.FieldName = "Qty";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0}")});
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            // 
            // colUnit2
            // 
            this.colUnit2.Caption = "单位";
            this.colUnit2.FieldName = "colUnit2";
            this.colUnit2.Name = "colUnit2";
            this.colUnit2.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colUnit2.Visible = true;
            this.colUnit2.VisibleIndex = 4;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "装箱数";
            this.gridColumn11.FieldName = "PCS";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "内盒";
            this.gridColumn12.FieldName = "InnerBox";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "总数量";
            this.gridColumn13.FieldName = "colTotalQty";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "colTotalQty", "{0}")});
            this.gridColumn13.UnboundExpression = "[Qty] * [PCS]";
            this.gridColumn13.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "单价";
            this.gridColumn14.DisplayFormat.FormatString = "c4";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "Price";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 5;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "金额";
            this.gridColumn15.DisplayFormat.FormatString = "c";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn15.FieldName = "colAMT";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "colAMT", "{0:c}")});
            this.gridColumn15.UnboundExpression = "[Qty] * [PCS] * [Price] * [Discount]  +  [OtherFee]";
            this.gridColumn15.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 8;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "去税单价";
            this.gridColumn16.DisplayFormat.FormatString = "c6";
            this.gridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn16.FieldName = "PriceNoTax";
            this.gridColumn16.Name = "gridColumn16";
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "去税金额";
            this.gridColumn17.DisplayFormat.FormatString = "c";
            this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn17.FieldName = "colAMTNoTax";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "colAMTNoTax", "{0}")});
            this.gridColumn17.UnboundExpression = "Iif(([Qty] * [PCS] * [PriceNoTax] * [Discount])==0,[Qty] * [PCS] * [PriceNoTax] *" +
    " [Discount]  , [Qty] * [PCS] * [PriceNoTax] * [Discount]  +  [OtherFee])";
            this.gridColumn17.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "折扣";
            this.gridColumn18.FieldName = "Discount";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 6;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "额外费用";
            this.gridColumn19.DisplayFormat.FormatString = "c";
            this.gridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn19.FieldName = "OtherFee";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 7;
            // 
            // colRemark2
            // 
            this.colRemark2.Caption = "备注";
            this.colRemark2.FieldName = "colRemark2";
            this.colRemark2.Name = "colRemark2";
            this.colRemark2.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colRemark2.Visible = true;
            this.colRemark2.VisibleIndex = 9;
            // 
            // OrderEditPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Controls.Add(this.hideContainerBottom);
            this.Name = "OrderEditPage";
            this.Size = new System.Drawing.Size(640, 480);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueWarehouseType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderHdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meMainMark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBillType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDtlBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLueGoods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGoodsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deAuditDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deAuditDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMakeDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMakeDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContacts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBusinessContact.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessContactBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDeliveryDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDeliveryDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOrderDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOrderDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vUsersInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAuditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBillNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOrderDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDeliveryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBusinessContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciContacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMaker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMakeDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAuditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAuditDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBillType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMainMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciWarehouseType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.hideContainerBottom.ResumeLayout(false);
            this.dpBOM.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcBOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billDtlByBOMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLueGoodsByBOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGoodsByBOMBindingSource)).EndInit();
            this.dpAssemble.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAssemble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billDtlByAssembleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAssemble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.dpMoldMaterial.ResumeLayout(false);
            this.controlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMoldMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vFSMOrderDtlByMoldMaterialBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMoldMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DateEdit deAuditDate;
        private DevExpress.XtraEditors.DateEdit deMakeDate;
        private DevExpress.XtraEditors.MemoEdit meRemark;
        private DevExpress.XtraEditors.TextEdit txtContacts;
        private DevExpress.XtraEditors.LookUpEdit lueBusinessContact;
        private DevExpress.XtraEditors.DateEdit deDeliveryDate;
        private DevExpress.XtraEditors.DateEdit deOrderDate;
        private DevExpress.XtraEditors.TextEdit txtBillNo;
        private DevExpress.XtraLayout.LayoutControlItem lciBillNo;
        private DevExpress.XtraLayout.LayoutControlItem lciBusinessContact;
        private DevExpress.XtraLayout.LayoutControlItem lciRemark;
        private DevExpress.XtraLayout.LayoutControlItem lciOrderDate;
        private DevExpress.XtraLayout.LayoutControlItem lciDeliveryDate;
        private DevExpress.XtraLayout.LayoutControlItem lciContacts;
        private DevExpress.XtraLayout.LayoutControlItem lciMaker;
        private DevExpress.XtraLayout.LayoutControlItem lciMakeDate;
        private DevExpress.XtraLayout.LayoutControlItem lciAuditor;
        private DevExpress.XtraLayout.LayoutControlItem lciAuditDate;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colHdID;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLueGoods;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPCS;
        private DevExpress.XtraGrid.Columns.GridColumn colInnerBox;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colAMT;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceNoTax;
        private DevExpress.XtraGrid.Columns.GridColumn colAMTNoTax;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private System.Windows.Forms.BindingSource orderDtlBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colOtherFee;
        private System.Windows.Forms.BindingSource orderHdBindingSource;
        private DevExpress.XtraEditors.LookUpEdit lueBillType;
        private DevExpress.XtraLayout.LayoutControlItem lciBillType;
        private System.Windows.Forms.BindingSource billTypeBindingSource;
        private DevExpress.XtraEditors.LookUpEdit lueWarehouse;
        private DevExpress.XtraLayout.LayoutControlItem lciWarehouse;
        private System.Windows.Forms.BindingSource warehouseBindingSource;
        private DevExpress.XtraEditors.LookUpEdit lueMaker;
        private DevExpress.XtraEditors.LookUpEdit lueAuditor;
        private System.Windows.Forms.BindingSource businessContactBindingSource;
        private System.Windows.Forms.BindingSource vUsersInfoBindingSource;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel dpAssemble;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private System.Windows.Forms.BindingSource billDtlByAssembleBindingSource;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerBottom;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPackaging;
        private DevExpress.XtraGrid.Columns.GridColumn colMEAS;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colSPEC;
        private DevExpress.XtraBars.Docking.DockPanel dpBOM;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraGrid.GridControl gcBOM;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBOM;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLueGoodsByBOM;
        private DevExpress.XtraGrid.Columns.GridColumn colName1;
        private DevExpress.XtraGrid.Columns.GridColumn colSPEC1;
        private DevExpress.XtraGrid.Columns.GridColumn colQty1;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit1;
        private DevExpress.XtraGrid.Columns.GridColumn colPCS1;
        private DevExpress.XtraGrid.Columns.GridColumn colInnerBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalQty1;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice1;
        private DevExpress.XtraGrid.Columns.GridColumn colAMT1;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceNoTax1;
        private DevExpress.XtraGrid.Columns.GridColumn colAMTNoTax1;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscount1;
        private DevExpress.XtraGrid.Columns.GridColumn colOtherFee1;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark1;
        private System.Windows.Forms.BindingSource billDtlByBOMBindingSource;
        private DevExpress.XtraBars.Docking.DockPanel dpMoldMaterial;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer2;
        private DevExpress.XtraGrid.GridControl gcMoldMaterial;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMoldMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colName2;
        private DevExpress.XtraGrid.Columns.GridColumn colSPEC2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark2;
        private System.Windows.Forms.BindingSource vFSMOrderDtlByMoldMaterialBindingSource;
        private System.Windows.Forms.BindingSource vGoodsByBOMBindingSource;
        private System.Windows.Forms.BindingSource vGoodsBindingSource;
        private DevExpress.XtraEditors.MemoEdit meMainMark;
        private DevExpress.XtraLayout.LayoutControlItem lciMainMark;
        private DevExpress.XtraEditors.LookUpEdit lueWarehouseType;
        private DevExpress.XtraLayout.LayoutControlItem lciWarehouseType;
        private System.Windows.Forms.BindingSource warehouseTypeBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnPrev;
        private DevExpress.XtraLayout.LayoutControlItem lciPrev;
        private DevExpress.XtraLayout.LayoutControlItem lciNext;
        private DevExpress.XtraGrid.GridControl gcAssemble;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAssemble;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsID3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colName3;
        private DevExpress.XtraGrid.Columns.GridColumn colSPEC3;
        private DevExpress.XtraGrid.Columns.GridColumn colQty3;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit3;
        private DevExpress.XtraGrid.Columns.GridColumn colPCS3;
        private DevExpress.XtraGrid.Columns.GridColumn colInnerBox3;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalQty3;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice3;
        private DevExpress.XtraGrid.Columns.GridColumn colAMT3;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceNoTax3;
        private DevExpress.XtraGrid.Columns.GridColumn colAMTNoTax3;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscount3;
        private DevExpress.XtraGrid.Columns.GridColumn colOtherFee3;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark3;
        private DevExpress.XtraGrid.Columns.GridColumn colStockQty;
        private DevExpress.XtraGrid.Columns.GridColumn colShortage;
        private DevExpress.XtraGrid.Columns.GridColumn colNWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colModulus;
        private DevExpress.XtraGrid.Columns.GridColumn colStockQty3;
        private DevExpress.XtraGrid.Columns.GridColumn colShortage3;
        private DevExpress.XtraGrid.Columns.GridColumn colNWeight3;
        private DevExpress.XtraGrid.Columns.GridColumn colModulus3;
        private DevExpress.XtraGrid.Columns.GridColumn colCounts1;
        private DevExpress.XtraGrid.Columns.GridColumn colCavityNumber1;
        private DevExpress.XtraGrid.Columns.GridColumn colCounts;
        private DevExpress.XtraGrid.Columns.GridColumn colCavityNumber;
    }
}
