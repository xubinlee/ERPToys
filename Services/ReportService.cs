using Common;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBML;
using BLL;
using Microsoft.Practices.Unity;
using Factory;
using System.Collections;

namespace Services
{
    public class ReportService : ServiceBase, IReportService
    {
        public List<T> GetT<T>(string filter) where T : class, new()
        {
            return BLLFty.Create<ReportBLL>().GetT<T>(filter);
        }

        public IList GetList(Type type, string filter)
        {
            return BLLFty.Create<ReportBLL>().GetList(type, filter);
        }

        public List<VGoodsSalesSummaryByCustomer> GetGoodsSalesSummaryByCustomerReport()
        {
            return BLLFty.Create<ReportBLL>().GetGoodsSalesSummaryByCustomerReport();
        }

        public List<GoodsSalesSummaryByCustomerReport> GetGoodsSalesSummaryByCustomerReport(string filter)
        {
            return BLLFty.Create<ReportBLL>().GetGoodsSalesSummaryByCustomerReport(filter);
        }

        public List<VSalesBillSummary> GetSalesBillSummaryReport()
        {
            return BLLFty.Create<ReportBLL>().GetSalesBillSummaryReport();
        }

        public List<VSalesSummaryByCustomer> GetSalesSummaryByCustomerReport()
        {
            return BLLFty.Create<ReportBLL>().GetSalesSummaryByCustomerReport();
        }

        public List<SalesSummaryByCustomerReport> GetSalesSummaryByCustomerReport(string filter)
        {
            return BLLFty.Create<ReportBLL>().GetSalesSummaryByCustomerReport(filter);
        }

        public List<VSalesSummaryByGoods> GetSalesSummaryByGoodsReport()
        {
            return BLLFty.Create<ReportBLL>().GetSalesSummaryByGoodsReport();
        }

        public List<SalesSummaryByGoodsReport> GetSalesSummaryByGoodsReport(string filter)
        {
            return BLLFty.Create<ReportBLL>().GetSalesSummaryByGoodsReport(filter);
        }

        public List<StatementOfAccountToCustomerReport> GetStatementOfAccountToCustomerReport(string filter)
        {
            return BLLFty.Create<ReportBLL>().GetStatementOfAccountToCustomerReport(filter);
        }

        public List<StatementOfAccountToSupplierReport> GetStatementOfAccountToSupplierReport(string filter)
        {
            return BLLFty.Create<ReportBLL>().GetStatementOfAccountToSupplierReport(filter);
        }
    }
}

