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
    [ServiceContract(Name = "GoodsService")]
    public interface IGoodsService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VGoodsByBOM> GetVGoodsByBOM();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VParentGoodsByBOM> GetVParentGoodsByBOM();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VGoodsByMoldAllot> GetVGoodsByMoldAllot();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool IsExist(Goods goods);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VGoods> GetVGoods();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VMaterial> GetVMaterial();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<Goods> GetGoods();

        [OperationContract(Name = "GetGoodsForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Goods GetGoods(Guid id);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(Goods obj);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(Goods obj);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Guid id);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Import(List<Goods> insertList, List<Goods> updateList);
    }
}
