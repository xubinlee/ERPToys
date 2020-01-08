using Common;
using EDMX;
using IBase;
using IWcfServiceInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Utility.Interceptor;

namespace ClientFactory
{
    public class BaseFactory
    {
        private static IBaseService baseService = ServiceProxyFactory.Create<IBaseService>("BaseService");
        // 数据集
        //public static Dictionary<Type, object> dataSourceList = new Dictionary<Type, object>();
        // 界面列表（ItemDetailPage页面所有加载的Control）
        public static Dictionary<String, IItemDetail> itemDetailList = new Dictionary<String, IItemDetail>();
        RedisHelper redis = new RedisHelper();

        /// <summary>
        /// 更新缓存
        /// </summary>
        //public List<T> UpdateCache<T>() where T : class, new()
        //{
        //    List<T> list = GetModelList<T>();
        //    //if (dataSourceList.ContainsKey(typeof(T)))
        //    //{
        //    //    dataSourceList[typeof(T)] = list;
        //    //}
        //    //else
        //    //{
        //    //    dataSourceList.Add(typeof(T), list);
        //    //}
        //    return list;
        //}

        #region 添加
        /// <summary>
        /// 添加单个实体
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <returns></returns>
        public virtual int Add<T>(T model) where T : class, new()
        {
            Parameter parameter = new Parameter();
            parameter.entityType = typeof(T);
            parameter.model = model;
            SerializedParam param = new SerializedParam(parameter);
            int iResult = baseService.Add(param);
            // 删除缓存
            if (iResult > 0)
                redis.KeyDelete(typeof(T).Name);
            return iResult;
        }

        /// <summary>
        /// 海量数据插入方法
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="list">数据列表</param>
        public virtual void AddByBulkCopy<T>(List<T> list) where T : class, new()
        {
            Parameter parameter = new Parameter();
            parameter.entityType = typeof(List<T>);
            parameter.list = list;
            SerializedParam param = new SerializedParam(parameter);
            baseService.AddByBulkCopy(param);
            // 删除缓存
            redis.KeyDelete(typeof(T).Name);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除(适用于先查询后删除的单个实体)
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="model">实体对象</param>
        /// <returns></returns>
        public virtual int Delete<T>(T model) where T : class, new()
        {
            Parameter parameter = new Parameter();
            parameter.entityType = typeof(T);
            parameter.model = model;
            SerializedParam param = new SerializedParam(parameter);
            int iResult = baseService.Delete(param);
            // 删除缓存
            if (iResult > 0)
                redis.KeyDelete(typeof(T).Name);
            return iResult;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="list">实体对象列表</param>
        /// <returns></returns>
        public virtual int DelByBulk<T>(List<T> list) where T : class, new()
        {
            Parameter parameter = new Parameter();
            parameter.entityType = typeof(List<T>);
            parameter.list = list;
            SerializedParam param = new SerializedParam(parameter);
            int iResult = baseService.DelByBulk(param);
            // 删除缓存
            if (iResult > 0)
                redis.KeyDelete(typeof(T).Name);
            return iResult;
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改单个实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="model">实体对象</param>
        /// <returns></returns>
        public virtual int Update<T>(T model) where T : class, new()
        {
            Parameter parameter = new Parameter();
            parameter.entityType = typeof(T);
            parameter.model = model;
            SerializedParam param = new SerializedParam(parameter);
            int iResult = baseService.Modify(param);
            // 删除缓存
            if (iResult > 0)
                redis.KeyDelete(typeof(T).Name);
            return iResult;
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="list">数据列表</param>
        /// <returns></returns>
        public virtual int ModifyByList<T>(List<T> list) where T : class, new()
        {
            Parameter parameter = new Parameter();
            parameter.entityType = typeof(List<T>);
            parameter.list = list;
            SerializedParam param = new SerializedParam(parameter);
            int iResult = baseService.ModifyByList(param);
            // 删除缓存
            if (iResult > 0)
                redis.KeyDelete(typeof(T).Name);
            return iResult;
        }
        #endregion

        #region 查询

        /// <summary>
        /// 按实体类型查询实体列表数据（返回List不需要修改或删除）
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns></returns>
        public virtual List<T> GetListByNoTracking<T>() where T : class, new()
        {
            if (!redis.KeyExists(typeof(T).Name))
            {
                Parameter parameter = new Parameter();
                parameter.entityType = typeof(T);
                SerializedParam param = new SerializedParam(parameter);
                SerializedParam result = baseService.GetListByNoTracking(param);
                //Parameter p = param.GetParameter();
                //return p.queryable.Cast<T>().ToList();
                redis.StringSet(typeof(T).Name, result.queryable);
            }
            return redis.StringGet<List<T>>(typeof(T).Name);
            //return JsonConvert.DeserializeObject<List<T>>(result.queryable);
        }

        /// <summary>
        /// 按实体类型查询实体列表数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns></returns>
        public virtual List<T> GetModelList<T>() where T : class, new()
        {
            if (!redis.KeyExists(typeof(T).Name))
            {
                Parameter parameter = new Parameter();
                parameter.entityType = typeof(T);
                SerializedParam param = new SerializedParam(parameter);
                SerializedParam result = baseService.GetModelList(param);
                //return JsonConvert.DeserializeObject<List<T>>(result.queryable);
                redis.StringSet(typeof(T).Name, result.queryable);
            }
            return redis.StringGet<List<T>>(typeof(T).Name);
        }

        /// <summary>
        /// 通过反射取得类型
        /// </summary>
        /// <param name="entityName">实体名称</param>
        /// <returns></returns>
        private Type Reflect(MainMenuEnum entityName)
        {
            string assemblyString = nameof(EDMX);
            Assembly assembly = Assembly.Load(assemblyString);
            return assembly.GetType(string.Format("{0}.{1}", assemblyString, entityName));
        }

        public virtual IList ExecuteQuery(MainMenuEnum entityName, string filter)
        {
            if (!redis.KeyExists(entityName.ToString()))
            {
                Type type = Reflect(entityName);
                Parameter parameter = new Parameter();
                parameter.entityType = type;
                parameter.filter = filter;
                SerializedParam param = new SerializedParam(parameter);
                SerializedParam result = baseService.ExecuteQueryByFilter(param);
                //return JsonConvert.DeserializeObject<IList>(result.list);
                redis.StringSet(entityName.ToString(), result.list);
            }
            return redis.StringGet<IList>(entityName.ToString());
        }

        public virtual List<T> ExecuteQuery<T>(string filter) where T : class, new()
        {
            if (!redis.KeyExists(typeof(T).Name))
            {
                //SqlParameter para = new SqlParameter("@Code", "benlee");
                //SerializedSqlParam sp = (SerializedSqlParam)para;
                //SerializedSqlParam[] paras ={
                //    sp,
                //};
                Parameter parameter = new Parameter();
                parameter.entityType = typeof(T);
                parameter.filter = filter;
                SerializedParam param = new SerializedParam(parameter);
                SerializedParam result = baseService.ExecuteQueryByFilter(param);
                //return JsonConvert.DeserializeObject<List<T>>(result.queryable);
                redis.StringSet(typeof(T).Name, result.queryable);
            }
            return redis.StringGet<List<T>>(typeof(T).Name);
        }

        /// <summary>
        /// 贪婪加载
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="path">贪婪加载对象</param>
        /// <returns></returns>
        public virtual List<T> GetListByInclude<T>(string path) where T : class, new()
        {
            string key = typeof(T).Name;// + "Include";
            if (!redis.KeyExists(key))
            {
                EntityType entityType = new EntityType(typeof(T));
                SerializedParam result = baseService.GetListByInclude(entityType, path);
                //return JsonConvert.DeserializeObject<List<T>>(result.queryable);
                redis.StringSet(key, result.queryable);
            }
            return redis.StringGet<List<T>>(key);
        }
        public virtual IList GetListByInclude(MainMenuEnum entityName, string path)
        {
            Type type = Reflect(entityName);
            string key = type.Name + "Include";
            if (!redis.KeyExists(key))
            {
                EntityType entityType = new EntityType(type);
                SerializedParam result = baseService.GetListByInclude(entityType, path);
                redis.StringSet(key, result.queryable);
            }
            return redis.StringGet<IList>(key);
        }

        /// <summary>
        /// 从数据库获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        //public virtual List<T> GetDBData<T>(string filter) where T : class, new()
        //{
        //    List<T> list = ExecuteQuery<T>(filter);
        //    if (dataSourceList.ContainsKey(typeof(T)))
        //    {
        //        dataSourceList[typeof(T)] = list;
        //    }
        //    else
        //    {
        //        dataSourceList.Add(typeof(T), list);
        //    }
        //    return list;
        //}

        /// <summary>
        /// 从缓存获取数据，缓存没有再从数据库取
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns></returns>
        //public virtual List<T> GetData<T>() where T : class, new()
        //{
        //    List<T> list = new List<T>();
        //    //if (dataSourceList.ContainsKey(typeof(T)))
        //    //{
        //    //    list = (List<T>)dataSourceList[typeof(T)];
        //    //}
        //    //else
        //    //{
        //    //    list = GetModelList<T>();
        //    //    dataSourceList.Add(typeof(T), list);
        //    //}
        //    return list;
        //}

        /// <summary>
        /// 刷新所有界面（直接从数据库取数）
        /// </summary>
        /// <param name="entityName">实体类型名称</param>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public virtual IList DataPageRefresh(MainMenuEnum entityName, String filter)
        {
            IList list = ExecuteQuery(entityName, filter);
            if (list != null)
            {
                //if (dataSourceList.ContainsKey(type))
                //{
                //    dataSourceList[type] = list;
                //}
                //else
                //{
                //    dataSourceList.Add(type, list);
                //}
                foreach (KeyValuePair<String, IItemDetail> kvp in itemDetailList)
                {
                    kvp.Value.BindData(list);
                }
            }
            return list;
        }


        /// <summary>
        /// 刷新所有界面（直接从数据库取数）
        /// </summary>
        /// <param name="entityName">实体类型名称</param>
        /// <returns></returns>
        public virtual IList DataPageRefresh(MainMenuEnum entityName)
        {
            return DataPageRefresh(entityName, string.Empty);
        }

        /// <summary>
        /// 刷新界面,同时更新缓存
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        public virtual List<T> DataPageRefresh<T>() where T : class, new()
        {
            List<T> list = GetModelList<T>();// GetData<T>();
            foreach (KeyValuePair<String, IItemDetail> kvp in itemDetailList)
            {
                kvp.Value.BindData(list);
            }
            return list;
        }
        #endregion
    }
}
