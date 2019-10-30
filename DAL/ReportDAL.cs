using DBML;
using IBase;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReportDAL : IDALBase
    {
        public List<T> GetT<T>(DCC dcc, String dbName, String filter) where T : class, new()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select * from {0}", dbName);
            if (!string.IsNullOrEmpty(filter))
                sb.AppendFormat(" where {0}", filter);
            return dcc.ExecuteQuery<T>(sb.ToString()).ToList();
        }

        public List<SalesSummaryByCustomerReport> GetSalesSummaryByCustomerReport(DCC dcc, String filter)
        {
            ISingleResult<SalesSummaryByCustomerReport> result = dcc.USPGetSalesSummaryByCustomerReport(filter);
            return result.ToList();
        }

        public List<SalesSummaryByGoodsReport> GetSalesSummaryByGoodsReport(DCC dcc, String filter)
        {
            ISingleResult<SalesSummaryByGoodsReport> result = dcc.USPGetSalesSummaryByGoodsReport(filter);
            return result.ToList();
        }

        public List<SalesSummaryByGoodsPriceReport> GetSalesSummaryByGoodsPriceReport(DCC dcc, String filter)
        {
            ISingleResult<SalesSummaryByGoodsPriceReport> result = dcc.USPGetSalesSummaryByGoodsPriceReport(filter);
            return result.ToList();
        }

        public List<GoodsSalesSummaryByCustomerReport> GetGoodsSalesSummaryByCustomerReport(DCC dcc, String filter)
        {
            ISingleResult<GoodsSalesSummaryByCustomerReport> result = dcc.USPGetGoodsSalesSummaryByCustomerReport(filter);
            return result.ToList();
        }

        public List<StatementOfAccountToCustomerReport> GetStatementOfAccountToCustomerReport(DCC dcc, String filter)
        {
            ISingleResult<StatementOfAccountToCustomerReport> result = dcc.USPGetStatementOfAccountToCustomerReport(filter);
            return result.ToList();
        }

        public List<StatementOfAccountToSupplierReport> GetStatementOfAccountToSupplierReport(DCC dcc, String filter)
        {
            ISingleResult<StatementOfAccountToSupplierReport> result = dcc.USPGetStatementOfAccountToSupplierReport(filter);
            return result.ToList();
        }

        public List<StatementOfAccountSummaryToSupplierReport> GetStatementOfAccountSummaryToSupplierReport(DCC dcc, String filter)
        {
            ISingleResult<StatementOfAccountSummaryToSupplierReport> result = dcc.USPGetStatementOfAccountSummaryToSupplierReport(filter);
            return result.ToList();
        }
        public List<StatementOfAccountMaterialToSupplierReport> GetStatementOfAccountMaterialToSupplierReport(DCC dcc, String billNo, Guid supplierID, DateTime startDate, DateTime endDate, String supplierType)
        {
            ISingleResult<StatementOfAccountMaterialToSupplierReport> result = dcc.USPGetStatementOfAccountMaterialToSupplierReport(billNo, supplierID, startDate, endDate, supplierType);
            return result.ToList();
        }
        public List<StatementOfAccountBasketToSupplierReport> GetStatementOfAccountBasketToSupplierReport(DCC dcc, String billNo, Guid supplierID, DateTime startDate, DateTime endDate, String supplierType)
        {
            ISingleResult<StatementOfAccountBasketToSupplierReport> result = dcc.USPGetStatementOfAccountBasketToSupplierReport(billNo, supplierID, startDate, endDate, supplierType);
            return result.ToList();
        }
        public List<StatementOfAccountMaterialToSupplierReport> GetStatementOfAccountOfEMSReport(DCC dcc, String billNo, Guid supplierID, DateTime startDate, DateTime endDate)
        {
            ISingleResult<StatementOfAccountMaterialToSupplierReport> result = dcc.USPGetStatementOfAccountOfEMSReport(billNo, supplierID, startDate, endDate);
            return result.ToList();
        }

        //public List<FSMGoodsTrackingDailyReport> GetFSMGoodsTrackingDailyReport(DCC dcc)
        //{
        //    return dcc.USPGetFSMGoodsTrackingDailyReport().ToList();
        //}

        public List<VSalesBillSummary> GetSalesBillSummaryReport(DCC dcc)
        {
            return dcc.VSalesBillSummary.ToList();
        }

        public List<VSalesSummaryByCustomer> GetSalesSummaryByCustomerReport(DCC dcc)
        {
            return dcc.VSalesSummaryByCustomer.ToList();
        }

        public List<VSalesSummaryByGoods> GetSalesSummaryByGoodsReport(DCC dcc)
        {
            return dcc.VSalesSummaryByGoods.ToList();
        }

        public List<VGoodsSalesSummaryByCustomer> GetGoodsSalesSummaryByCustomerReport(DCC dcc)
        {
            return dcc.VGoodsSalesSummaryByCustomer.ToList();
        }

        //public List<VSalesSummaryByCustomer> GetSalesSummaryByCustomerReport(DCC dcc, String filter)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("select * from VSalesSummaryByCustomer");
        //    if (!string.IsNullOrEmpty(filter))
        //        sb.AppendFormat(" where {0}", filter);
        //    return dcc.ExecuteQuery<VSalesSummaryByCustomer>(sb.ToString()).ToList();
        //}
    }
}
