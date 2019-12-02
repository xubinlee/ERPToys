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
    [ServiceContract(Name = "SupplierService")]
    public interface ISupplierService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VSupplier> GetVSupplier();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<Supplier> GetSupplier();

        [OperationContract(Name = "GetSupplierForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Supplier GetSupplier(Guid id);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(Supplier obj);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(Supplier obj);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Guid id);
    }
}
