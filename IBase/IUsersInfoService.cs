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
    [ServiceContract(Name = "UsersInfoService")]
    public interface IUsersInfoService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VUsersInfo> GetVUsersInfo();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VUsersInfo> GetLoginUsersInfo();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<UsersInfo> GetUsersInfo();

        [OperationContract(Name = "GetUsersInfoForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        UsersInfo GetUsersInfo(Guid id);

        [OperationContract(Name = "GetUsersInfoForCode")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        UsersInfo GetUsersInfo(String code);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(UsersInfo obj, List<Permission> pList, List<ButtonPermission> btnList);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(UsersInfo obj);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Guid id);
    }
}
