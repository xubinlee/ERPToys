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
    [ServiceContract(Name = "PackagingService")]
    public interface IPackagingService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VPackaging> GetVPackaging();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<Packaging> GetPackaging();

        [OperationContract(Name = "GetPackagingForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Packaging GetPackaging(Guid id);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(Packaging obj);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(Packaging obj);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Guid id);
    }
}
