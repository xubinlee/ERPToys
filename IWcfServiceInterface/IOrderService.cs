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
    public interface IOrderService
    {
        /// <summary>
        /// 新增表单
        /// </summary>
        /// <param name="hd">表头数据</param>
        /// <param name="dtlList">明细数据</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "POST", UriTemplate = "SaveBill", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void SaveBill(OrderHd hd, List<OrderDtl> dtlList);
    }
}
