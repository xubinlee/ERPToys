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
    [ServiceContract(Name = "WageBillService")]
    public interface IWageBillService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        string GetMaxBillNo();

        [OperationContract(Name = "GetWageBillHdForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        WageBillHd GetWageBillHd(Guid id);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<WageBillHd> GetWageBillHd();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<WageBillDtl> GetWageBillDtl(Guid hdID);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VWageBillDtl> GetVWageBillDtl();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VWageBill> GetWageBill();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(WageBillHd hd, List<WageBillDtl> dtl);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Audit(WageBillHd hd, List<Appointments> aptList, List<Alert> delList);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(WageBillHd hd, List<WageBillDtl> dtl);

        [OperationContract(Name = "GetWageBillHdForHead")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(WageBillHd hd);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Guid hdID);
    }
}
