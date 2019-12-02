using Common;
using DBML;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IBase
{
    [ServiceContract(Name = "ReportService")]
    public interface IReportService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<T> GetT<T>(String filter) where T : class, new();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        IList GetList(Type type, String filter);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<SalesSummaryByCustomerReport> GetSalesSummaryByCustomerReport(String filter);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<SalesSummaryByGoodsReport> GetSalesSummaryByGoodsReport(String filter);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<GoodsSalesSummaryByCustomerReport> GetGoodsSalesSummaryByCustomerReport(String filter);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<StatementOfAccountToCustomerReport> GetStatementOfAccountToCustomerReport(String filter);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<StatementOfAccountToSupplierReport> GetStatementOfAccountToSupplierReport(String filter);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VSalesBillSummary> GetSalesBillSummaryReport();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VSalesSummaryByCustomer> GetSalesSummaryByCustomerReport();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VSalesSummaryByGoods> GetSalesSummaryByGoodsReport();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VGoodsSalesSummaryByCustomer> GetGoodsSalesSummaryByCustomerReport();
    }
}
