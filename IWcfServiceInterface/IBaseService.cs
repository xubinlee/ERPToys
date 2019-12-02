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
        /// <param name="model">实体对象</param>
        /// <returns></returns>
        int Add(object model);
        /// <summary>
        /// 海量数据插入方法
        /// </summary>
        /// <param name="entityType">实体类型名称</param>
        /// <param name="list">对象列表</param>
        void AddByBulkCopy(string entityType, IList list);
        #endregion

        #region 删除

        #endregion

        #region 修改
        /// <summary>
        /// 修改单个实体
        /// </summary>
        /// <param name="param">已序列化的参数类</param>
        /// <returns></returns>
        int Modify(SerializedParam param);
        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="list">修改后的实体列表</param>
        /// <returns></returns>
        int ModifyByList(SerializedParam param);
        #endregion

        #region 查询
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        string GetModelList(string entityType);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        string ExecuteQuery(string entityType, string sql, params SerializedSqlParam[] pars);
        
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        string ExecuteQueryByFilter(string entityType, string filter);
        #endregion

    }
}
