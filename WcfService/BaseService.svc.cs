using Common;
using DAL;
using EDMX;
using Factory;
using IWcfServiceInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    public class BaseService : ServiceBase, IBaseService
    {
        #region 添加
        public int Add(SerializedParam param)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                Parameter p = param.GetParameter();
                return DALFty.Create<BaseDAL>().Add(db, p.entityType, p.model);
            }
        }
        public void AddByBulkCopy(SerializedParam param)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                Parameter p = param.GetParameter();
                DALFty.Create<BaseDAL>().AddByBulkCopy(db, p.entityType, p.list);
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除(适用于先查询后删除的单个实体)
        /// </summary>
        /// <param name="model">需要删除的实体</param>
        /// <returns></returns>
        public int Delete(SerializedParam param)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                Parameter p = param.GetParameter();
                return DALFty.Create<BaseDAL>().Delete(db, p.entityType, p.model);
            }
        }
        #endregion

        #region 修改
        public int Modify(SerializedParam param)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                Parameter p = param.GetParameter();
                return DALFty.Create<BaseDAL>().Modify(db, p.model);
            }
        }
        public int ModifyByList(SerializedParam param)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                Parameter p = param.GetParameter();
                return DALFty.Create<BaseDAL>().ModifyByList(db, p.list);
            }
        }
        #endregion

        #region 查询

        private SerializedParam QueryableResult(IQueryable queryable)
        {
            Parameter parameter = new Parameter();
            // IQueryable反序列化回报异常，直接在客户端通过List<T>反序列化
            //parameter.entityType = typeof(IQueryable);
            parameter.queryable = queryable;
            SerializedParam param = new SerializedParam(parameter);
            return param;
        }

        public SerializedParam ExecuteQuery(Type type, string sql, params SerializedSqlParam[] serPars)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                SqlParameter[] pars = new SqlParameter[serPars.Length];
                for (int i = 0; i < serPars.Length; i++)
                {
                    pars[i] = (SqlParameter)serPars[i];
                }
                IQueryable queryable = DALFty.Create<BaseDAL>().ExecuteQuery(db, type, sql, pars);
                return QueryableResult(queryable);
            }
        }
        public SerializedParam ExecuteQueryByFilter(SerializedParam param)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                Parameter p = param.GetParameter();
                IList list = DALFty.Create<BaseDAL>().ExecuteQuery(db, p.entityType, p.filter);
                Parameter parameter = new Parameter();
                parameter.entityType = typeof(IList);
                parameter.list = list;
                SerializedParam result = new SerializedParam(parameter);
                return result;
            }
        }

        public SerializedParam GetListByNoTracking(SerializedParam param)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                Parameter p = param.GetParameter();
                IQueryable queryable = DALFty.Create<BaseDAL>().GetListByNoTracking(db, p.entityType);
                return QueryableResult(queryable);
            }
        }

        public SerializedParam GetModelList(SerializedParam param)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                Parameter p = param.GetParameter();
                IQueryable queryable = DALFty.Create<BaseDAL>().GetModelList(db, p.entityType);
                return QueryableResult(queryable);
            }
        }

        public SerializedParam GetListByInclude(EntityType entityType, string path)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                IQueryable queryable = DALFty.Create<BaseDAL>().GetListByInclude(db, entityType.GetType(), path);
                return QueryableResult(queryable);
            }
        }
        #endregion

    }
}
