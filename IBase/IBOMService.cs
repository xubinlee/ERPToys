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
    [ServiceContract(Name = "BOMService")]
    public interface IBOMService
    {
        [OperationContract(Name = "GetBOMForParentGoodsID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<BOM> GetBOM(Guid parentGoodsID);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<BOM> GetBOM();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(List<BOM> list);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(int bomType, Guid parentGoodsID, List<BOM> list);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Guid parentGoodsID);
    }
}
