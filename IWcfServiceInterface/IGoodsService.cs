using Common;
using EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace IWcfServiceInterface
{
    [ServiceContract]
    public interface IGoodsService
    {
        /// <summary>
        /// 添加和更新实体列表
        /// </summary>
        /// <param name="insertList">插入的实体列表</param>
        /// <param name="updateList">更新实体列表</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "POST", UriTemplate = "AddAndUpdate", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddAndUpdate(List<Goods> insertList, List<Goods> updateList);
    }
}
