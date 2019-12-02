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
    [ServiceContract(Name = "AppointmentsService")]
    public interface IAppointmentsService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<Appointments> GetAppointments();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VAppointments> GetVAppointments();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(Appointments apt);

        [OperationContract(Name = "InsertForList")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(List<Appointments> list);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(List<Appointments> list);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(List<Appointments> list);

        [OperationContract(Name = "DeleteForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Int64 id);
    }
}
