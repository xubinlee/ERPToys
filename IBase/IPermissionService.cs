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
    [ServiceContract(Name = "PermissionService")]
    public interface IPermissionService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<Permission> GetPermission();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<ButtonPermission> GetButtonPermission();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(List<Permission> opList, List<ButtonPermission> btnList);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(Permission obj);

        [OperationContract(Name = "UpdateForObject")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(Permission obj);
    }
}
