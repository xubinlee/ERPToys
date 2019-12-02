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
    [ServiceContract(Name = "StockInBillService")]
    public interface IStockInBillService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        string GetMaxBillNo();

        [OperationContract(Name = "GetStockInBillHdForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        StockInBillHd GetStockInBillHd(Guid id);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<StockInBillHd> GetStockInBillHd();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<StockInBillDtl> GetStockInBillDtl(Guid hdID);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<StockInBillDtl> GetVStockInBillDtlByBOM(Guid hdID, int bomType);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VStockInBill> GetStockInBill();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VMaterialStockInBill> GetMaterialStockInBill();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Audit(OrderHd orderhd, List<OrderDtl> orderdtl, StockInBillHd hd, List<StockInBillDtl> dtl);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(StockInBillHd hd, List<StockInBillDtl> dtl);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(StockInBillHd hd, List<StockInBillDtl> dtl);

        [OperationContract(Name = "UpdateForHead")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(StockInBillHd hd);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Guid id);
    }
}
