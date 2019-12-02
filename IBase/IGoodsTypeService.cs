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
    [ServiceContract(Name = "GoodsTypeService")]
    public interface IGoodsTypeService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VGoodsType> GetVGoodsType();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<GoodsType> GetGoodsType();

        [OperationContract(Name = "GetGoodsTypeForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        GoodsType GetGoodsType(Guid id);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(GoodsType obj);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(List<GoodsType> list);

        [OperationContract(Name = "UpdateForObject")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(GoodsType obj);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Guid id);
    }
}
