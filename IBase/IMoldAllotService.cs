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
    [ServiceContract(Name = "MoldAllotService")]
    public interface IMoldAllotService
    {
        [OperationContract(Name = "GetMoldAllotForSupplierID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<MoldAllot> GetMoldAllot(Guid supplierID);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<MoldAllot> GetMoldAllot();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(List<MoldAllot> list);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(Guid parentGoodsID, List<MoldAllot> list);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Guid parentGoodsID);
    }
}
