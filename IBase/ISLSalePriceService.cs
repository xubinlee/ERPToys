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
    [ServiceContract(Name = "SLSalePriceService")]
    public interface ISLSalePriceService
    {
        [OperationContract(Name = "GetSLSalePriceForBusinessContactID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<SLSalePrice> GetSLSalePrice(Guid businessContactID);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<SLSalePrice> GetSLSalePrice();

        [OperationContract(Name = "InsertForObject")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(SLSalePrice obj);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(List<SLSalePrice> list);

        [OperationContract(Name = "UpdateForObject")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(SLSalePrice obj);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(Guid parentGoodsID, List<SLSalePrice> list);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Guid parentGoodsID);
    }
}
