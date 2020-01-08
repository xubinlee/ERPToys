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
    public interface IStockInBillService
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
        void SaveBill(StockInBillHd hd, List<StockInBillDtl> dtlList);

        /// <summary>
        /// 获取入库列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "POST", UriTemplate = "GetStockInBill?id={id}", BodyStyle = WebMessageBodyStyle.WrappedResponse, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<StockInBillHd> GetStockInBill(Guid id);

        /// <summary>
        /// 删除单据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "DELETE", UriTemplate = "Delete?id={id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool Delete(Guid id);

        /// <summary>
        /// 审核入库单
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "POST", UriTemplate = "Audit", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void Audit(StockInBillHd hd, List<StockInBillDtl> dtl, List<Inventory> ityList, List<AccountBook> abList, List<Alert> delList, List<Alert> alertList);

        /// <summary>
        /// 取消审核入库单
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "POST", UriTemplate = "CancelAudit", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void CancelAudit(StockInBillHd hd, List<Inventory> ityList, List<AccountBook> abList);
    }
}
