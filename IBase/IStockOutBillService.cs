using Common;
using DBML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IBase
{
    [ServiceContract(Name = "StockOutBillService")]
    public interface IStockOutBillService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        string GetMaxBillNo();

        [OperationContract(Name = "GetStockOutBillHdForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        StockOutBillHd GetStockOutBillHd(Guid id);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<StockOutBillHd> GetStockOutBillHd();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<StockOutBillDtl> GetStockOutBillDtl(Guid hdID);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<StockOutBillDtl> GetVStockOutBillDtlByBOM(Guid hdID, int bomType);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VStockOutBill> GetStockOutBill();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VMaterialStockOutBill> GetMaterialStockOutBill();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(StockOutBillHd hd, List<StockOutBillDtl> dtl);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(StockOutBillHd hd, List<StockOutBillDtl> dtl);

        [OperationContract(Name = "UpdateForHead")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(StockOutBillHd hd);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Guid id);
    }
}
