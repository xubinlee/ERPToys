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
    [ServiceContract(Name = "DepartmentService")]
    public interface IDepartmentService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VDepartment> GetVDepartment();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<Department> GetDepartment();

        [OperationContract(Name = "GetDepartmentForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Department GetDepartment(Guid id);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(Department obj);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(Department obj);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Guid id);
    }
}
