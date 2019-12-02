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
    [ServiceContract(Name = "CompanyService")]
    public interface ICompanyService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VCompany> GetVCompany();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<Company> GetCompany();

        [OperationContract(Name = "GetCompanyForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Company GetCompany(Guid id);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(Company obj);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(Company obj);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Guid id);
    }
}
