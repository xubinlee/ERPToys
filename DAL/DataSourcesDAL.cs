using DBML;
using IBase;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace DAL
{
    public class DataSourcesDAL : IDALBase
    {
        public Dictionary<Type, object> GetVDataSources(DCC dcc)
        {

            IMultipleResults dataSources = dcc.USPGetDataSources();
            Dictionary<Type, object> dataSourceList = new Dictionary<Type, object>();
            dataSourceList.Add(typeof(List<VStockInBill>), dataSources.GetResult<VStockInBill>().OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList());
            dataSourceList.Add(typeof(List<VStockOutBill>), dataSources.GetResult<VStockOutBill>().OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList());
            dataSourceList.Add(typeof(List<VMaterialStockInBill>), dataSources.GetResult<VMaterialStockInBill>().OrderBy(o=>o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList());
            dataSourceList.Add(typeof(List<VMaterialStockOutBill>), dataSources.GetResult<VMaterialStockOutBill>().OrderBy(o=>o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList());
            dataSourceList.Add(typeof(List<StockInBillHd>), dataSources.GetResult<StockInBillHd>().OrderBy(o => o.BillNo).ToList());
            dataSourceList.Add(typeof(List<StockOutBillHd>), dataSources.GetResult<StockOutBillHd>().OrderBy(o => o.BillNo).ToList());
            dataSourceList.Add(typeof(List<OrderHd>), dataSources.GetResult<OrderHd>().OrderBy(o => o.BillNo).ToList());
            dataSourceList.Add(typeof(List<ReceiptBillHd>), dataSources.GetResult<ReceiptBillHd>().OrderBy(o => o.BillNo).ToList());
            dataSourceList.Add(typeof(List<PaymentBillHd>), dataSources.GetResult<PaymentBillHd>().OrderBy(o => o.BillNo).ToList());
            dataSourceList.Add(typeof(List<VPO>), dataSources.GetResult<VPO>().OrderBy(o => o.订货单号).ToList());
            dataSourceList.Add(typeof(List<VOrder>), dataSources.GetResult<VOrder>().OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o=>o.订货单号).ToList());
            dataSourceList.Add(typeof(List<VFSMOrder>), dataSources.GetResult<VFSMOrder>().OrderByDescending(o => o.类型).OrderBy(o => o.状态).ToList());
            dataSourceList.Add(typeof(List<VProductionOrder>), dataSources.GetResult<VProductionOrder>().OrderByDescending(o => o.类型).OrderBy(o => o.状态).ToList());
            dataSourceList.Add(typeof(List<VInventory>), dataSources.GetResult<VInventory>().OrderBy(o => o.登帐日期).ToList());
            dataSourceList.Add(typeof(List<VInventoryGroupByGoods>), dataSources.GetResult<VInventoryGroupByGoods>().OrderBy(o => o.货号).ToList());
            dataSourceList.Add(typeof(List<VMaterialInventory>), dataSources.GetResult<VMaterialInventory>().OrderBy(o => o.登帐日期).ToList());
            dataSourceList.Add(typeof(List<VMaterialInventoryGroupByGoods>), dataSources.GetResult<VMaterialInventoryGroupByGoods>().OrderBy(o => o.货号).ToList());
            dataSourceList.Add(typeof(List<VEMSInventoryGroupByGoods>), dataSources.GetResult<VEMSInventoryGroupByGoods>().OrderBy(o => o.货号).ToList());
            dataSourceList.Add(typeof(List<VFSMInventoryGroupByGoods>), dataSources.GetResult<VFSMInventoryGroupByGoods>().OrderBy(o => o.货号).ToList());
            dataSourceList.Add(typeof(List<VAccountBook>), dataSources.GetResult<VAccountBook>().OrderBy(o => o.记帐日期).ToList());
            dataSourceList.Add(typeof(List<VStocktaking>), dataSources.GetResult<VStocktaking>().OrderByDescending(o => o.盘点日期).ToList());
            dataSourceList.Add(typeof(List<VProfitAndLoss>), dataSources.GetResult<VProfitAndLoss>().OrderBy(o => o.货号).ToList());
            //dataSourceList.Add(typeof(List<EMSGoodsTrackingDailyReport>), dataSources.GetResult<EMSGoodsTrackingDailyReport>().ToList());
            //dataSourceList.Add(typeof(List<FSMGoodsTrackingDailyReport>), dataSources.GetResult<FSMGoodsTrackingDailyReport>().ToList());
            dataSourceList.Add(typeof(List<SalesSummaryMonthlyReport>), dataSources.GetResult<SalesSummaryMonthlyReport>().ToList());
            dataSourceList.Add(typeof(List<AnnualSalesSummaryByCustomerReport>), dataSources.GetResult<AnnualSalesSummaryByCustomerReport>().ToList());
            dataSourceList.Add(typeof(List<AnnualSalesSummaryByGoodsReport>), dataSources.GetResult<AnnualSalesSummaryByGoodsReport>().ToList());
            dataSourceList.Add(typeof(List<VSalesBillSummary>), new List<VSalesBillSummary>());
            //dataSourceList.Add(typeof(List<VSalesSummaryByCustomer>), dataSources.GetResult<VSalesSummaryByCustomer>().ToList());
            //dataSourceList.Add(typeof(List<VSalesSummaryByGoods>), dataSources.GetResult<VSalesSummaryByGoods>().ToList());
            //dataSourceList.Add(typeof(List<VGoodsSalesSummaryByCustomer>), dataSources.GetResult<VGoodsSalesSummaryByCustomer>().ToList());
            //dataSourceList.Add(typeof(List<VStockInBillDtlForPrint>), dataSources.GetResult<VStockInBillDtlForPrint>().OrderByDescending(o => o.货号).ToList());
            //dataSourceList.Add(typeof(List<VStockOutBillDtlForPrint>), dataSources.GetResult<VStockOutBillDtlForPrint>().OrderByDescending(o => o.货号).ToList());
            //dataSourceList.Add(typeof(List<VMaterialStockInBillDtlForPrint>), dataSources.GetResult<VMaterialStockInBillDtlForPrint>().OrderByDescending(o => o.货号).ToList());
            //dataSourceList.Add(typeof(List<VMaterialStockOutBillDtlForPrint>), dataSources.GetResult<VMaterialStockOutBillDtlForPrint>().OrderByDescending(o => o.货号).ToList());
            //dataSourceList.Add(typeof(List<VOrderDtlForPrint>), dataSources.GetResult<VOrderDtlForPrint>().OrderBy(o => o.货号).ToList());
            //dataSourceList.Add(typeof(List<VFSMOrderDtlForPrint>), dataSources.GetResult<VFSMOrderDtlForPrint>().OrderBy(o => o.货号).ToList());
            dataSourceList.Add(typeof(List<VProductionOrderDtlForPrint>), dataSources.GetResult<VProductionOrderDtlForPrint>().OrderBy(o => o.货号).ToList());
            dataSourceList.Add(typeof(List<VAlert>), dataSources.GetResult<VAlert>().ToList());
            dataSourceList.Add(typeof(List<Alert>), dataSources.GetResult<Alert>().ToList());
            dataSourceList.Add(typeof(List<VReceiptBillDtl>), dataSources.GetResult<VReceiptBillDtl>().OrderBy(o => o.BillNo).ToList());
            dataSourceList.Add(typeof(List<VReceiptBill>), dataSources.GetResult<VReceiptBill>().OrderBy(o => o.状态).OrderByDescending(o => o.收款单号).ToList());
            //dataSourceList.Add(typeof(List<VStatementOfAccountToCustomer>), dataSources.GetResult<VStatementOfAccountToCustomer>().ToList());
            //dataSourceList.Add(typeof(List<VReceiptBillDtlForPrint>), dataSources.GetResult<VReceiptBillDtlForPrint>().ToList());
            dataSourceList.Add(typeof(List<VPaymentBillDtl>), dataSources.GetResult<VPaymentBillDtl>().OrderBy(o => o.BillDate).OrderBy(o=>o.Type).ToList());
            dataSourceList.Add(typeof(List<VPaymentBill>), dataSources.GetResult<VPaymentBill>().OrderBy(o => o.状态).OrderByDescending(o => o.付款单号).ToList());
            //dataSourceList.Add(typeof(List<VStatementOfAccountToSupplier>), dataSources.GetResult<VStatementOfAccountToSupplier>().ToList());
            //dataSourceList.Add(typeof(List<VPaymentBillDtlForPrint>), dataSources.GetResult<VPaymentBillDtlForPrint>().ToList());
            dataSourceList.Add(typeof(List<StatementOfAccountToBulkSalesReport>), dataSources.GetResult<StatementOfAccountToBulkSalesReport>().ToList());
            dataSourceList.Add(typeof(List<StatementOfAccountToCustomerReport>), dataSources.GetResult<StatementOfAccountToCustomerReport>().ToList());//.OrderBy(o => o.结算类型).OrderBy(o => o.出库日期).ToList());
            dataSourceList.Add(typeof(List<StatementOfAccountToSupplierReport>), dataSources.GetResult<StatementOfAccountToSupplierReport>().ToList());//.OrderBy(o => o.结算类型).OrderBy(o => o.结算日期).ToList());
            dataSourceList.Add(typeof(List<VCustomerSettlement>), dataSources.GetResult<VCustomerSettlement>().ToList());
            dataSourceList.Add(typeof(List<VSupplierSettlement>), dataSources.GetResult<VSupplierSettlement>().ToList());
            dataSourceList.Add(typeof(List<VSampleStockOut>), dataSources.GetResult<VSampleStockOut>().OrderBy(o => o.SerialNo).OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList());
            dataSourceList.Add(typeof(List<Resources>), dataSources.GetResult<Resources>().ToList());
            dataSourceList.Add(typeof(List<Appointments>), dataSources.GetResult<Appointments>().ToList());
            dataSourceList.Add(typeof(List<VAppointments>), dataSources.GetResult<VAppointments>().ToList());
            dataSourceList.Add(typeof(List<WageDesign>), dataSources.GetResult<WageDesign>().ToList());
            dataSourceList.Add(typeof(List<WageBillHd>), dataSources.GetResult<WageBillHd>().ToList());
            dataSourceList.Add(typeof(List<WageBillDtl>), dataSources.GetResult<WageBillDtl>().ToList());
            dataSourceList.Add(typeof(List<VWageBillDtl>), dataSources.GetResult<VWageBillDtl>().ToList());
            dataSourceList.Add(typeof(List<VWageBill>), dataSources.GetResult<VWageBill>().ToList());
            dataSourceList.Add(typeof(List<SalesSummaryByCustomerReport>), new List<SalesSummaryByCustomerReport>());
            dataSourceList.Add(typeof(List<SalesSummaryByGoodsReport>), new List<SalesSummaryByGoodsReport>());
            dataSourceList.Add(typeof(List<SalesSummaryByGoodsPriceReport>), new List<SalesSummaryByGoodsPriceReport>());
            dataSourceList.Add(typeof(List<GoodsSalesSummaryByCustomerReport>), new List<GoodsSalesSummaryByCustomerReport>());
            //dataSourceList.Add(typeof(List<AttParameters>), dataSources.GetResult<AttParameters>().ToList());
            dataSourceList.Add(typeof(List<AttGeneralLog>), dataSources.GetResult<AttGeneralLog>().OrderBy(o => o.AttTime).ToList());
            dataSourceList.Add(typeof(List<VAttGeneralLog>), dataSources.GetResult<VAttGeneralLog>().OrderBy(o => o.出勤时间).ToList());
            dataSourceList.Add(typeof(List<AttAppointments>), dataSources.GetResult<AttAppointments>().OrderBy(o=>o.CheckInTime).ToList());
            dataSourceList.Add(typeof(List<VAttAppointments>), dataSources.GetResult<VAttAppointments>().ToList());
            dataSourceList.Add(typeof(List<AttWageBillHd>), dataSources.GetResult<AttWageBillHd>().ToList());
            dataSourceList.Add(typeof(List<AttWageBillDtl>), dataSources.GetResult<AttWageBillDtl>().ToList());
            dataSourceList.Add(typeof(List<USPAttWageBillDtl>), dataSources.GetResult<USPAttWageBillDtl>().ToList());
            dataSourceList.Add(typeof(List<VAttWageBill>), dataSources.GetResult<VAttWageBill>().ToList());
            dataSources.Dispose();
            System.GC.Collect();
            return dataSourceList;
        }
        public Dictionary<Type, object> GetDataSources(DCC dcc)
        {

            IMultipleResults dataSources = dcc.USPGetDataBaseSources();
            Dictionary<Type, object> dataSourceList = new Dictionary<Type, object>();
            dataSourceList.Add(typeof(List<DBML.MainMenu>), dataSources.GetResult<DBML.MainMenu>().OrderBy(o => o.SerialNo).ToList());
            dataSourceList.Add(typeof(List<Permission>), dataSources.GetResult<Permission>().OrderBy(o => o.SerialNo).ToList());
            dataSourceList.Add(typeof(List<ButtonPermission>), dataSources.GetResult<ButtonPermission>().OrderBy(o => o.ID).ToList());
            dataSourceList.Add(typeof(List<SystemInfo>), dataSources.GetResult<SystemInfo>().ToList());
            dataSourceList.Add(typeof(List<TypesList>), dataSources.GetResult<TypesList>().ToList());
            dataSourceList.Add(typeof(List<Warehouse>), dataSources.GetResult<Warehouse>().ToList());
            dataSourceList.Add(typeof(List<VDepartment>), dataSources.GetResult<VDepartment>().OrderBy(o => o.代码).ToList());
            dataSourceList.Add(typeof(List<Department>), dataSources.GetResult<Department>().OrderBy(o => o.Code).ToList());
            dataSourceList.Add(typeof(List<VCompany>), dataSources.GetResult<VCompany>().OrderBy(o => o.代码).ToList());
            dataSourceList.Add(typeof(List<Company>), dataSources.GetResult<Company>().OrderBy(o => o.Code).ToList());
            dataSourceList.Add(typeof(List<VSupplier>), dataSources.GetResult<VSupplier>().OrderBy(o => o.代码).ToList());
            dataSourceList.Add(typeof(List<Supplier>), dataSources.GetResult<Supplier>().OrderBy(o => o.Code).ToList());
            dataSourceList.Add(typeof(List<VUsersInfo>), dataSources.GetResult<VUsersInfo>().ToList());
            dataSourceList.Add(typeof(List<UsersInfo>), dataSources.GetResult<UsersInfo>().ToList());
            dataSourceList.Add(typeof(List<GoodsType>), dataSources.GetResult<GoodsType>().OrderBy(o => o.Code).ToList());
            dataSourceList.Add(typeof(List<VGoodsType>), dataSources.GetResult<VGoodsType>().OrderBy(o => o.类型编码).ToList());
            dataSourceList.Add(typeof(List<Goods>), dataSources.GetResult<Goods>().OrderBy(o => o.Code).ToList());
            dataSourceList.Add(typeof(List<VGoods>), dataSources.GetResult<VGoods>().OrderBy(o => o.货号).ToList());
            dataSourceList.Add(typeof(List<VMaterial>), dataSources.GetResult<VMaterial>().OrderBy(o => o.货号).ToList());
            dataSourceList.Add(typeof(List<VGoodsByBOM>), dataSources.GetResult<VGoodsByBOM>().OrderBy(o => o.货号).ToList());
            dataSourceList.Add(typeof(List<VParentGoodsByBOM>), dataSources.GetResult<VParentGoodsByBOM>().OrderBy(o => o.货号).ToList());
            dataSourceList.Add(typeof(List<VGoodsByMoldAllot>), dataSources.GetResult<VGoodsByMoldAllot>().OrderBy(o => o.货号).ToList());
            dataSourceList.Add(typeof(List<VGoodsBySLSalePrice>), dataSources.GetResult<VGoodsBySLSalePrice>().OrderBy(o => o.货号).ToList());
            dataSourceList.Add(typeof(List<VPackaging>), dataSources.GetResult<VPackaging>().ToList());
            dataSourceList.Add(typeof(List<Packaging>), dataSources.GetResult<Packaging>().ToList());
            dataSourceList.Add(typeof(List<BOM>), dataSources.GetResult<BOM>().ToList());
            dataSourceList.Add(typeof(List<MoldAllot>), dataSources.GetResult<MoldAllot>().ToList());
            dataSourceList.Add(typeof(List<SLSalePrice>), dataSources.GetResult<SLSalePrice>().ToList());
            dataSourceList.Add(typeof(List<AttParameters>), dataSources.GetResult<AttParameters>().ToList());
            dataSourceList.Add(typeof(List<SchClass>), dataSources.GetResult<SchClass>().OrderBy(o => o.SerialNo).ToList());
            dataSourceList.Add(typeof(List<StaffSchClass>), dataSources.GetResult<StaffSchClass>().ToList());
            dataSourceList.Add(typeof(List<VStaffSchClass>), dataSources.GetResult<VStaffSchClass>().ToList());
            dataSources.Dispose();
            System.GC.Collect();
            return dataSourceList;
        }
    }
}
