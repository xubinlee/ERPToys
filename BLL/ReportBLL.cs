using DAL;
using DBML;
using Factory;
using IBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReportBLL : IBLLBase
    {
        public List<T> GetT<T>(String filter) where T : class, new()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReportDAL>().GetT<T>(dcc, filter);
            }
        }

        public IList GetList(Type type, String filter)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReportDAL>().GetList(dcc, type, filter);
            }

        }

        public List<SalesSummaryByCustomerReport> GetSalesSummaryByCustomerReport(String filter)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReportDAL>().GetSalesSummaryByCustomerReport(dcc, filter);
            }
        }

        public List<SalesSummaryByGoodsReport> GetSalesSummaryByGoodsReport(String filter)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReportDAL>().GetSalesSummaryByGoodsReport(dcc, filter);
            }
        }

        public List<SalesSummaryByGoodsPriceReport> GetSalesSummaryByGoodsPriceReport(String filter)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReportDAL>().GetSalesSummaryByGoodsPriceReport(dcc, filter);
            }
        }

        public List<GoodsSalesSummaryByCustomerReport> GetGoodsSalesSummaryByCustomerReport(String filter)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReportDAL>().GetGoodsSalesSummaryByCustomerReport(dcc, filter);
            }
        }

        public List<StatementOfAccountToCustomerReport> GetStatementOfAccountToCustomerReport(String filter)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReportDAL>().GetStatementOfAccountToCustomerReport(dcc, filter);
            }
        }

        public List<StatementOfAccountToSupplierReport> GetStatementOfAccountToSupplierReport(String filter)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReportDAL>().GetStatementOfAccountToSupplierReport(dcc, filter);
            }
        }

        public List<StatementOfAccountSummaryToSupplierReport> GetStatementOfAccountSummaryToSupplierReport(String filter)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReportDAL>().GetStatementOfAccountSummaryToSupplierReport(dcc, filter);
            }
        }
        public List<StatementOfAccountMaterialToSupplierReport> GetStatementOfAccountMaterialToSupplierReport(String billNo, Guid supplierID, DateTime startDate, DateTime endDate, String supplierType)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReportDAL>().GetStatementOfAccountMaterialToSupplierReport(dcc, billNo, supplierID, startDate, endDate, supplierType);
            }
        }
        public List<StatementOfAccountBasketToSupplierReport> GetStatementOfAccountBasketToSupplierReport(String billNo, Guid supplierID, DateTime startDate, DateTime endDate, String supplierType)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReportDAL>().GetStatementOfAccountBasketToSupplierReport(dcc, billNo, supplierID, startDate, endDate, supplierType);
            }
        }
        public List<StatementOfAccountMaterialToSupplierReport> GetStatementOfAccountOfEMSReport(String billNo, Guid supplierID, DateTime startDate, DateTime endDate)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReportDAL>().GetStatementOfAccountOfEMSReport(dcc, billNo, supplierID, startDate, endDate);
            }
        }

        //public List<FSMGoodsTrackingDailyReport> GetFSMGoodsTrackingDailyReport()
        //{
        //    using (DCC dcc = DBMLFty.Dcc)
        //    {
        //        return DALFty.Create<ReportDAL>().GetFSMGoodsTrackingDailyReport(dcc);
        //    }
        //}

        public List<VSalesBillSummary> GetSalesBillSummaryReport()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReportDAL>().GetSalesBillSummaryReport(dcc);
            }
        }

        public List<VSalesSummaryByCustomer> GetSalesSummaryByCustomerReport()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReportDAL>().GetSalesSummaryByCustomerReport(dcc);
            }
        }
        //public List<VSalesSummaryByCustomer> GetSalesSummaryByCustomerReport(String filter)
        //{
        //    using (DCC dcc = DBMLFty.Dcc)
        //    {
        //        return DALFty.Create<ReportDAL>().GetSalesSummaryByCustomerReport(dcc, filter);
        //    }
        //}

        public List<VSalesSummaryByGoods> GetSalesSummaryByGoodsReport()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReportDAL>().GetSalesSummaryByGoodsReport(dcc);
            }
        }

        public List<VGoodsSalesSummaryByCustomer> GetGoodsSalesSummaryByCustomerReport()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReportDAL>().GetGoodsSalesSummaryByCustomerReport(dcc);
            }
        }
    }
}
