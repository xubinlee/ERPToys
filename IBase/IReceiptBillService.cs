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
    [ServiceContract(Name = "ReceiptBillService")]
    public interface IReceiptBillService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        string GetMaxBillNo();

        [OperationContract(Name = "GetReceiptBillHdForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        ReceiptBillHd GetReceiptBillHd(Guid id);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<ReceiptBillHd> GetReceiptBillHd();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<ReceiptBillDtl> GetReceiptBillDtl(Guid hdID);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VReceiptBillDtl> GetVReceiptBillDtl();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VReceiptBill> GetReceiptBill();

        [OperationContract(Name = "GetReceiptBillForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VReceiptBill> GetReceiptBill(Guid hdID);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(ReceiptBillHd hd, List<ReceiptBillDtl> dtl);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Audit(ReceiptBillHd hd, List<StockInBillHd> siHdList, List<StockOutBillHd> soHdList, List<Alert> delList);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(ReceiptBillHd hd, List<ReceiptBillDtl> dtl);

        [OperationContract(Name = "UpdateForHead")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(ReceiptBillHd hd);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Guid id);
    }
}
