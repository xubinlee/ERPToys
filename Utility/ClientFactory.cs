using Common;
using IBase;
using IWcfServiceInterface;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class ClientFactory
    {
        private static IBaseService baseService = ServiceProxyFactory.Create<IBaseService>("BaseService");
        // 数据集
        public static Dictionary<Type, object> dataSourceList = new Dictionary<Type, object>();
        // 界面列表（ItemDetailPage页面所有加载的Control）
        public static Dictionary<String, IItemDetail> itemDetailList = new Dictionary<string, IItemDetail>();

        #region 添加

        #endregion

        #region 删除

        #endregion

        #region 修改
        public static int Modify<T>(T model) where T : class, new()
        {
            Parameter parameter = new Parameter();
            parameter.model = model;
            SerializedParam param = new SerializedParam(parameter);
            return baseService.Modify(param);
        }

        public static int ModifyByList<T>(List<T> list) where T : class, new()
        {
            Parameter parameter = new Parameter();
            parameter.list = list;
            SerializedParam param = new SerializedParam(parameter);
            return baseService.ModifyByList(param);
        }
        #endregion

        #region 查询

        public static List<T> GetModelList<T>() where T : class, new()
        {
            string type = typeof(T).AssemblyQualifiedName;
            string json = baseService.GetModelList(type);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public static IList ExecuteQuery(string entytyType, string filter)
        {
            if (string.IsNullOrWhiteSpace(entytyType))
            {
                throw new ArgumentNullException("实体类型名称不能为空");
            }
            string type = entytyType.GetType().AssemblyQualifiedName;
            string json = baseService.ExecuteQueryByFilter(type, filter);
            return JsonConvert.DeserializeObject<IList>(json);
        }

        public static List<T> ExecuteQuery<T>(string filter) where T : class, new()
        {
            string type = typeof(T).AssemblyQualifiedName;
            //SqlParameter para = new SqlParameter("@Code", "benlee");
            //SerializedSqlParam sp = (SerializedSqlParam)para;
            //SerializedSqlParam[] paras ={
            //    sp,
            //};
            string json = baseService.ExecuteQueryByFilter(type, filter);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        /// <summary>
        /// 从数据库获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static List<T> GetDBData<T>(string filter) where T : class, new()
        {
            List<T> list = ExecuteQuery<T>(filter);
            if (dataSourceList.ContainsKey(typeof(T)))
            {
                dataSourceList[typeof(T)] = list;
            }
            else
            {
                dataSourceList.Add(typeof(T), list);
            }
            return list;
        }

        /// <summary>
        /// 从缓存获取数据，缓存没有再从数据库取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetData<T>() where T : class, new()
        {
            List<T> list = new List<T>();
            if (dataSourceList.ContainsKey(typeof(T)))
                list = (List<T>)dataSourceList[typeof(T)];
            else
            {
                list = GetModelList<T>();
                dataSourceList.Add(typeof(T), list);
            }
            return list;
        }

        /// <summary>
        /// 刷新类型对应的查询界面
        /// </summary>
        /// <param name="entityType">实体类型名称</param>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public static IList DataPageRefresh(String entityType, String filter)
        {
            IList list = ExecuteQuery(entityType, filter);
            foreach (KeyValuePair<String, IItemDetail> kvp in itemDetailList)
            {
                kvp.Value.BindData(list);
            }
            return list;
        }

        /// <summary>
        /// 刷新所有界面
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        public static List<T> DataPageRefresh<T>() where T : class, new()
        {
            List<T> list = GetDBData<T>(string.Empty);
            foreach (KeyValuePair<String, IItemDetail> kvp in itemDetailList)
            {
                kvp.Value.BindData(list);
            }
            return list;
        }
        #endregion
    }
}
