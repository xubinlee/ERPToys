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
    [ServiceContract(Name = "PaymentBillService")]
    public interface IPaymentBillService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        string GetMaxBillNo();

        [OperationContract(Name = "GetPaymentBillHdForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        PaymentBillHd GetPaymentBillHd(Guid id);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<PaymentBillHd> GetPaymentBillHd();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<PaymentBillDtl> GetPaymentBillDtl(Guid hdID);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VPaymentBillDtl> GetVPaymentBillDtl();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VPaymentBill> GetPaymentBill();

        [OperationContract(Name = "GetPaymentBillForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VPaymentBill> GetPaymentBill(Guid hdID);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(PaymentBillHd hd, List<PaymentBillDtl> dtl);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Audit(PaymentBillHd hd, List<StockInBillHd> siHdList, List<StockOutBillHd> soHdList);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(PaymentBillHd hd, List<PaymentBillDtl> dtl);

        [OperationContract(Name = "UpdateForHead")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(PaymentBillHd hd);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Guid id);
    }
}
