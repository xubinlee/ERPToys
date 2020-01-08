using Common;
using EDMX;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace IWcfServiceInterface
{
    [ServiceContract(Name = "BaseService")]
    //[ServiceKnownType("GetKnownTypes", typeof(KnownTypesProvider))]
    public interface IBaseService
    {
        #region 添加

        /// <summary>
        /// 添加单个实体
        /// </summary>
        /// <param name="param">已序列化的参数类</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "POST", UriTemplate = "Add", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int Add(SerializedParam param);
        /// <summary>
        /// 海量数据插入方法
        /// </summary>
        /// <param name="param">已序列化的参数类</param>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "POST", UriTemplate = "AddByBulkCopy", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddByBulkCopy(SerializedParam param);
        #endregion

        #region 删除
        /// <summary>
        /// 删除(适用于先查询后删除的单个实体)
        /// </summary>
        /// <param name="param">已序列化的参数类</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "DELETE", UriTemplate = "Delete", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int Delete(SerializedParam param);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="param">已序列化的参数类</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "DELETE", UriTemplate = "DelByBulk", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int DelByBulk(SerializedParam param);
        #endregion

        #region 修改
        /// <summary>
        /// 修改单个实体
        /// </summary>
        /// <param name="param">已序列化的参数类</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "PUT", UriTemplate = "Modify", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int Modify(SerializedParam param);
        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="param">修改后的实体列表</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method ="PUT", UriTemplate = "ModifyByList", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int ModifyByList(SerializedParam param);
        #endregion

        #region 查询
        /// <summary>
        /// 按实体类型执行查询操作（返回List不需要修改或删除）
        /// </summary>
        /// <param name="entityTyp">实体类型</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "POST", UriTemplate = "GetListByNoTracking", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SerializedParam GetListByNoTracking(SerializedParam param);

        /// <summary>
        /// 按实体类型执行查询操作
        /// </summary>
        /// <param name="entityTyp">实体类型</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "POST", UriTemplate = "GetModelList", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SerializedParam GetModelList(SerializedParam param);

        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <param name="entityType">实体类型名称</param>
        /// <param name="sql">sql语句</param>
        /// <param name="pars">where参数</param>
        /// <returns></returns>
        //[OperationContract]
        //[FaultContract(typeof(ServiceExceptionDetail))]
        //[WebGet(UriTemplate = "ExecuteQuery?entityType={entityType}&sql={sql}&pars={pars}", BodyStyle = WebMessageBodyStyle.WrappedResponse, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //SerializedParam ExecuteQuery(string entityType, string sql, params SerializedSqlParam[] pars);

        /// <summary>
        /// 带where条件的查询
        /// </summary>
        /// <param name="entityType">实体类型名称</param>
        /// <param name="filter">where条件</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebInvoke(Method = "POST", UriTemplate = "ExecuteQueryByFilter", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SerializedParam ExecuteQueryByFilter(SerializedParam param);

        /// <summary>
        /// 贪婪加载列表
        /// 例子：http://localhost:51172/BaseService.svc/GetListByInclude?type=StockInBillHd&path=StockInBillDtl
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <param name="path">延迟加载对象</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        [WebGet(UriTemplate = "GetListByInclude?type={type}&path={path}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SerializedParam GetListByInclude(EntityType type, string path);
        #endregion

    }
}
