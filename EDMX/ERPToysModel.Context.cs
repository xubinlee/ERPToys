﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EDMX
{
    using System;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ERPToysContext : DbContext
    {
    	public ERPToysContext()
            : this(false) { }
    
        public ERPToysContext(bool proxyCreationEnabled)
            : base("name=ERPToysContext")
        {
    		        this.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }
    	
        public ERPToysContext(string connectionString)
          : this(connectionString, false) { }
    	  
        public ERPToysContext(string connectionString, bool proxyCreationEnabled)
            : base(connectionString)
        {
    		        this.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }	
    	
        public ObjectContext ObjectContext
        {
          get { return ((IObjectContextAdapter)this).ObjectContext; }
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccountBook> AccountBook { get; set; }
        public virtual DbSet<Alert> Alert { get; set; }
        public virtual DbSet<AnnualSalesSummaryByCustomerReport> AnnualSalesSummaryByCustomerReport { get; set; }
        public virtual DbSet<AnnualSalesSummaryByGoodsReport> AnnualSalesSummaryByGoodsReport { get; set; }
        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<AttAppointments> AttAppointments { get; set; }
        public virtual DbSet<AttGeneralLog> AttGeneralLog { get; set; }
        public virtual DbSet<AttWageBillDtl> AttWageBillDtl { get; set; }
        public virtual DbSet<AttWageBillHd> AttWageBillHd { get; set; }
        public virtual DbSet<BOM> BOM { get; set; }
        public virtual DbSet<ButtonPermission> ButtonPermission { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<EMSGoodsTrackingDailyReport> EMSGoodsTrackingDailyReport { get; set; }
        public virtual DbSet<FSMGoodsTrackingDailyReport> FSMGoodsTrackingDailyReport { get; set; }
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<GoodsSalesSummaryByCustomerReport> GoodsSalesSummaryByCustomerReport { get; set; }
        public virtual DbSet<GoodsType> GoodsType { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<MainMenu> MainMenu { get; set; }
        public virtual DbSet<MoldAllot> MoldAllot { get; set; }
        public virtual DbSet<OrderDtl> OrderDtl { get; set; }
        public virtual DbSet<OrderHd> OrderHd { get; set; }
        public virtual DbSet<Packaging> Packaging { get; set; }
        public virtual DbSet<PaymentBillDtl> PaymentBillDtl { get; set; }
        public virtual DbSet<PaymentBillHd> PaymentBillHd { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<ReceiptBillDtl> ReceiptBillDtl { get; set; }
        public virtual DbSet<ReceiptBillHd> ReceiptBillHd { get; set; }
        public virtual DbSet<Resources> Resources { get; set; }
        public virtual DbSet<SalesSummaryByCustomerReport> SalesSummaryByCustomerReport { get; set; }
        public virtual DbSet<SalesSummaryByGoodsPriceReport> SalesSummaryByGoodsPriceReport { get; set; }
        public virtual DbSet<SalesSummaryByGoodsReport> SalesSummaryByGoodsReport { get; set; }
        public virtual DbSet<SalesSummaryMonthlyReport> SalesSummaryMonthlyReport { get; set; }
        public virtual DbSet<SchClass> SchClass { get; set; }
        public virtual DbSet<SLSalePrice> SLSalePrice { get; set; }
        public virtual DbSet<StaffSchClass> StaffSchClass { get; set; }
        public virtual DbSet<StatementOfAccountBasketToSupplierReport> StatementOfAccountBasketToSupplierReport { get; set; }
        public virtual DbSet<StatementOfAccountMaterialToSupplierReport> StatementOfAccountMaterialToSupplierReport { get; set; }
        public virtual DbSet<StatementOfAccountSummaryToSupplierReport> StatementOfAccountSummaryToSupplierReport { get; set; }
        public virtual DbSet<StatementOfAccountToBulkSalesReport> StatementOfAccountToBulkSalesReport { get; set; }
        public virtual DbSet<StatementOfAccountToCustomerReport> StatementOfAccountToCustomerReport { get; set; }
        public virtual DbSet<StatementOfAccountToSupplierReport> StatementOfAccountToSupplierReport { get; set; }
        public virtual DbSet<StockInBillDtl> StockInBillDtl { get; set; }
        public virtual DbSet<StockInBillHd> StockInBillHd { get; set; }
        public virtual DbSet<StockOutBillDtl> StockOutBillDtl { get; set; }
        public virtual DbSet<StockOutBillHd> StockOutBillHd { get; set; }
        public virtual DbSet<Stocktaking> Stocktaking { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SystemInfo> SystemInfo { get; set; }
        public virtual DbSet<SystemStatus> SystemStatus { get; set; }
        public virtual DbSet<TonerLabel> TonerLabel { get; set; }
        public virtual DbSet<TypesList> TypesList { get; set; }
        public virtual DbSet<UsersInfo> UsersInfo { get; set; }
        public virtual DbSet<USPAttWageBillDtl> USPAttWageBillDtl { get; set; }
        public virtual DbSet<WageBillDtl> WageBillDtl { get; set; }
        public virtual DbSet<WageBillHd> WageBillHd { get; set; }
        public virtual DbSet<WageDesign> WageDesign { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<AttParameters> AttParameters { get; set; }
        public virtual DbSet<VAccountBook> VAccountBook { get; set; }
        public virtual DbSet<VAlert> VAlert { get; set; }
        public virtual DbSet<VAppointments> VAppointments { get; set; }
        public virtual DbSet<VAttAppointments> VAttAppointments { get; set; }
        public virtual DbSet<VAttGeneralLog> VAttGeneralLog { get; set; }
        public virtual DbSet<VAttWageBill> VAttWageBill { get; set; }
        public virtual DbSet<VCompany> VCompany { get; set; }
        public virtual DbSet<VCustomerSalesReceiptedSummary> VCustomerSalesReceiptedSummary { get; set; }
        public virtual DbSet<VCustomerSettlement> VCustomerSettlement { get; set; }
        public virtual DbSet<VDepartment> VDepartment { get; set; }
        public virtual DbSet<VEMSInventoryGroupByGoods> VEMSInventoryGroupByGoods { get; set; }
        public virtual DbSet<VFSMInventoryGroupByGoods> VFSMInventoryGroupByGoods { get; set; }
        public virtual DbSet<VFSMOrder> VFSMOrder { get; set; }
        public virtual DbSet<VFSMOrderDtlByMoldList> VFSMOrderDtlByMoldList { get; set; }
        public virtual DbSet<VFSMOrderDtlByMoldMaterial> VFSMOrderDtlByMoldMaterial { get; set; }
        public virtual DbSet<VGoods> VGoods { get; set; }
        public virtual DbSet<VGoodsByBOM> VGoodsByBOM { get; set; }
        public virtual DbSet<VGoodsByMoldAllot> VGoodsByMoldAllot { get; set; }
        public virtual DbSet<VGoodsBySLSalePrice> VGoodsBySLSalePrice { get; set; }
        public virtual DbSet<VGoodsSalesSummaryByCustomer> VGoodsSalesSummaryByCustomer { get; set; }
        public virtual DbSet<VGoodsType> VGoodsType { get; set; }
        public virtual DbSet<VInventory> VInventory { get; set; }
        public virtual DbSet<VInventoryGroupByGoods> VInventoryGroupByGoods { get; set; }
        public virtual DbSet<VMaterial> VMaterial { get; set; }
        public virtual DbSet<VMaterialInventory> VMaterialInventory { get; set; }
        public virtual DbSet<VMaterialInventoryGroupByGoods> VMaterialInventoryGroupByGoods { get; set; }
        public virtual DbSet<VMaterialStockInBill> VMaterialStockInBill { get; set; }
        public virtual DbSet<VMaterialStockOutBill> VMaterialStockOutBill { get; set; }
        public virtual DbSet<VMO> VMO { get; set; }
        public virtual DbSet<VMPS> VMPS { get; set; }
        public virtual DbSet<VOrder> VOrder { get; set; }
        public virtual DbSet<VOrderDtlByBOM> VOrderDtlByBOM { get; set; }
        public virtual DbSet<VOrderDtlByColor> VOrderDtlByColor { get; set; }
        public virtual DbSet<VPackaging> VPackaging { get; set; }
        public virtual DbSet<VParentGoodsByBOM> VParentGoodsByBOM { get; set; }
        public virtual DbSet<VPaymentBill> VPaymentBill { get; set; }
        public virtual DbSet<VPaymentBillDtl> VPaymentBillDtl { get; set; }
        public virtual DbSet<VPO> VPO { get; set; }
        public virtual DbSet<VProductionOrder> VProductionOrder { get; set; }
        public virtual DbSet<VProductionOrderDtlForPrint> VProductionOrderDtlForPrint { get; set; }
        public virtual DbSet<VProfitAndLoss> VProfitAndLoss { get; set; }
        public virtual DbSet<VReceiptBill> VReceiptBill { get; set; }
        public virtual DbSet<VReceiptBillDtl> VReceiptBillDtl { get; set; }
        public virtual DbSet<VSalesBillSummary> VSalesBillSummary { get; set; }
        public virtual DbSet<VSalesSummaryByCustomer> VSalesSummaryByCustomer { get; set; }
        public virtual DbSet<VSalesSummaryByGoods> VSalesSummaryByGoods { get; set; }
        public virtual DbSet<VSampleStockOut> VSampleStockOut { get; set; }
        public virtual DbSet<VStaffSchClass> VStaffSchClass { get; set; }
        public virtual DbSet<VStatementOfAccountToCustomer> VStatementOfAccountToCustomer { get; set; }
        public virtual DbSet<VStatementOfAccountToSupplier> VStatementOfAccountToSupplier { get; set; }
        public virtual DbSet<VStockInBill> VStockInBill { get; set; }
        public virtual DbSet<VStockInBillDtlByBOM> VStockInBillDtlByBOM { get; set; }
        public virtual DbSet<VStockInBillDtlByColor> VStockInBillDtlByColor { get; set; }
        public virtual DbSet<VStockOutBill> VStockOutBill { get; set; }
        public virtual DbSet<VStockOutBillDtlByBOM> VStockOutBillDtlByBOM { get; set; }
        public virtual DbSet<VStocktaking> VStocktaking { get; set; }
        public virtual DbSet<VSupplier> VSupplier { get; set; }
        public virtual DbSet<VSupplierSettlement> VSupplierSettlement { get; set; }
        public virtual DbSet<VUsersInfo> VUsersInfo { get; set; }
        public virtual DbSet<VWageBill> VWageBill { get; set; }
        public virtual DbSet<VWageBillDtl> VWageBillDtl { get; set; }
    }
}
