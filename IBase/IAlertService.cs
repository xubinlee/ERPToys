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
    [ServiceContract(Name = "AlertService")]
    public interface IAlertService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VAlert> GetVAlert();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<Alert> GetAlert();

        [OperationContract(Name = "GetAlertForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Alert GetAlert(Guid id);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(List<Alert> delList, List<Alert> insertList);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(Alert obj);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Guid id);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void DeleteBill();
    }
}
