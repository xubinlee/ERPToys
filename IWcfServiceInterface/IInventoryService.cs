using Common;
using EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace IWcfServiceInterface
{
    [ServiceContract]
    public interface IInventoryService
    {
        /// <summary>
        /// 盘点更新
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "POST", UriTemplate = "StocktakingUpdate", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void StocktakingUpdate(Guid warehouseID, int goodsBigType, Guid? supplierID, List<Inventory> list, List<AccountBook> abList);

        /// <summary>
        /// 查询库存
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebGet(UriTemplate = "GetListBy", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Inventory> GetListBy(Expression<Func<Inventory, bool>> whereLambda = null);

        /// <summary>
        /// 查询库存（返回List不需要修改或删除）
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebGet(UriTemplate = "GetListByNoTracking", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Inventory> GetListByNoTracking(Expression<Func<Inventory, bool>> whereLambda = null);
    }
}
