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
    public interface IStockOutBillService
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
        void SaveBill(StockOutBillHd hd, List<StockOutBillDtl> dtlList);

        /// <summary>
        /// 获取出库列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "POST", UriTemplate = "GetStockOutBill?id={id}", BodyStyle = WebMessageBodyStyle.WrappedResponse, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<StockOutBillHd> GetStockOutBill(Guid id);

        /// <summary>
        /// 审核出库单
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "POST", UriTemplate = "Audit", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void Audit(StockOutBillHd hd, List<StockOutBillDtl> dtl, List<Inventory> ityList, List<AccountBook> abList, List<Alert> delList, List<Alert> alertList);

        /// <summary>
        /// 取消审核出库单
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "POST", UriTemplate = "CancelAudit", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void CancelAudit(StockOutBillHd hd, List<Inventory> ityList, List<AccountBook> abList);

        /// <summary>
        /// 删除单据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "DELETE", UriTemplate = "Delete?id={id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool Delete(Guid id);
    }
}
