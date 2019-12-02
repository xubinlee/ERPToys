﻿using EDMX;
using IBase;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace DAL
{
    public class BaseDAL : IDALBase
    {
        // 静态初始化单例模式
        //private static readonly ErpContext db = null;

        //static BaseDAL()
        //{
        //    if (db == null)
        //    {
        //        db = new ErpContext();
        //    }
        //}

        #region EF调用SQL语句

        /// <summary>
        /// 执行增加,删除,修改操作(或调用存储过程)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public int ExecuteSql(DbContext db, string sql, params SqlParameter[] pars)
        {
            return db.Database.ExecuteSqlCommand(sql, pars);
        }

        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public List<T> ExecuteQuery<T>(DbContext db, string sql, params SqlParameter[] pars)
        {
            return db.Database.SqlQuery<T>(sql, pars).ToList();
        }

        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <typeparam name="db"></typeparam>
        /// <param name="entityType"></param>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public string ExecuteQuery(DbContext db,string entityType, string sql, params SqlParameter[] pars)
        {
            Type type = Type.GetType(entityType);
            var query = db.Database.SqlQuery(type, sql, pars);
            var listType = typeof(List<>);
            Type[] typeArgs = { type };
            var makeme = listType.MakeGenericType(typeArgs);
            IList list = (IList)Activator.CreateInstance(makeme, true);
            foreach (var item in query)
            {
                list.Add(item);
            }
            return JsonConvert.SerializeObject(list);
        }

        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <typeparam name="db"></typeparam>
        /// <param name="entityType"></param>
        /// <param name="filter">where条件</param>
        /// <returns></returns>
        public string ExecuteQuery(DbContext db, string entityType, string filter)
        {
            Type type = Type.GetType(entityType);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select * from {0}", type.Name);
            if (!string.IsNullOrEmpty(filter))
                sb.AppendFormat(" where {0}", filter);
            var query = db.Database.SqlQuery(type, sb.ToString());
            var listType = typeof(List<>);
            Type[] typeArgs = { type };
            var makeme = listType.MakeGenericType(typeArgs);
            IList list = (IList)Activator.CreateInstance(makeme, true);
            foreach (var item in query)
            {
                list.Add(item);
            }
            return JsonConvert.SerializeObject(list);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 海量数据插入方法
        /// </summary>
        /// <typeparam name="db"></typeparam>
        /// <typeparam name="entityType">实体类型名称</typeparam>
        /// <param name="list"></param>
        public void AddByBulkCopy(DbContext db, string entityType, IList list)
        {
            DataSet ds = IListDataSet.ToDataSet(list);
            if (ds.Tables.Count > 0)
            {
                AddByBulkCopy(db.Database.Connection.ConnectionString, ds.Tables[0], entityType);
            }
        }

        /// <summary>
        /// 海量数据插入方法
        /// </summary>
        /// <typeparam name="db"></typeparam>
        /// <param name="list"></param>
        public void AddByBulkCopy<T>(DbContext db, List<T> list) where T : class, new()
        {
            DataSet ds = IListDataSet.ToDataSet<T>(list);
            if (ds.Tables.Count > 0)
            {
                AddByBulkCopy(db.Database.Connection.ConnectionString, ds.Tables[0], typeof(T).Name);
            }
        }

        /// <summary>
        /// 海量数据插入方法
        /// (调用该方法需要注意，DataTable中的字段名称必须和数据库中的字段名称一一对应)
        /// </summary>
        /// <param name="connectstring">数据连接字符串</param>
        /// <param name="table">内存表数据</param>
        /// <param name="tableName">目标数据的名称</param>
        private static void AddByBulkCopy(string connectstring, DataTable table, string tableName)
        {
            if (table != null && table.Rows.Count > 0)
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(connectstring))
                {
                    bulk.BatchSize = 1000;
                    bulk.BulkCopyTimeout = 100;
                    bulk.DestinationTableName = tableName;
                    bulk.WriteToServer(table);
                }
            }
        }

        public int Add<T>(DbContext db, T model) where T : class, new()
        {
            DbSet<T> dst = db.Set<T>();
            dst.Add(model);
            return db.SaveChanges();
        }

        public int Add(DbContext db, string entityType, object model)
        {
            Type type = Type.GetType(entityType);
            db.Set(type).Add(model);
            return db.SaveChanges();
        }
        #endregion

        #region 删除

        /// <summary>
        /// 删除(适用于先查询后删除的单个实体)
        /// </summary>
        /// <param name="model">需要删除的实体</param>
        /// <returns></returns>
        public int Del<T>(DbContext db, T model) where T : class, new()
        {
            db.Set<T>().Attach(model);
            db.Set<T>().Remove(model);
            return db.SaveChanges();
        }

        /// <summary>
        /// 根据条件删除(支持批量删除)
        /// </summary>
        /// <param name="delWhere">传入Lambda表达式(生成表达式目录树)</param>
        /// <returns></returns>
        public int DelBy<T>(DbContext db, Expression<Func<T, bool>> delWhere) where T : class, new()
        {
            List<T> listDels = db.Set<T>().Where(delWhere).ToList();
            listDels.ForEach(d =>
            {
                db.Set<T>().Attach(d);
                db.Set<T>().Remove(d);
            });
            return db.SaveChanges();
        }
        #endregion

        #region 查询

        /// <summary>
        /// 按实体类型查询实体列表数据（返回List不需要修改或删除）
        /// </summary>
        /// <param name="db">数据源</param>
        /// <param name="entityType">实体类型</param>
        /// <returns></returns>
        public string GetModelList(DbContext db, string entityType)
        {
            Type type = Type.GetType(entityType);
            var lst = db.Set(type).AsNoTracking();
            var listType = typeof(List<>);
            Type[] typeArgs = { type };
            var makeme = listType.MakeGenericType(typeArgs);
            IList list = (IList)Activator.CreateInstance(makeme, true);
            foreach (var item in lst)
            {
                list.Add(item);
            }
            return JsonConvert.SerializeObject(list);
        }

        /// <summary>
        /// 根据条件查询（返回List不需要修改或删除）
        /// </summary>
        /// <param name="whereLambda">查询条件(lambda表达式的形式生成表达式目录树)</param>
        /// <returns></returns>
        public List<T> GetListByNoTracking<T>(DbContext db, Expression<Func<T, bool>> whereLambda) where T : class, new()
        {
            return db.Set<T>().Where(whereLambda).AsNoTracking().ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="whereLambda">查询条件(lambda表达式的形式生成表达式目录树)</param>
        /// <returns></returns>
        public List<T> GetListBy<T>(DbContext db, Expression<Func<T, bool>> whereLambda) where T : class, new()
        {
            return db.Set<T>().Where(whereLambda).ToList();
        }

        /// <summary>
        /// 根据条件排序和查询
        /// </summary>
        /// <typeparam name="Tkey">排序字段类型</typeparam>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderLambda">排序条件</param>
        /// <param name="isAsc">升序or降序</param>
        /// <returns></returns>
        public List<T> GetListBy<T, Tkey>(DbContext db, Expression<Func<T, bool>> whereLambda, Expression<Func<T, Tkey>> orderLambda, bool isAsc = true) where T : class, new()
        {
            List<T> list = null;
            if (isAsc)
            {
                list = db.Set<T>().Where(whereLambda).OrderBy(orderLambda).ToList();
            }
            else
            {
                list = db.Set<T>().Where(whereLambda).OrderByDescending(orderLambda).ToList();
            }
            return list;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="Tkey">排序字段类型</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderLambda">排序条件</param>
        /// <param name="isAsc">升序or降序</param>
        /// <returns></returns>
        public List<T> GetPageList<T, Tkey>(DbContext db, int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, Tkey>> orderLambda, bool isAsc = true) where T : class, new()
        {

            List<T> list = null;
            if (isAsc)
            {
                list = db.Set<T>().Where(whereLambda).OrderBy(orderLambda)
               .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                list = db.Set<T>().Where(whereLambda).OrderByDescending(orderLambda)
              .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            return list;
        }

        /// <summary>
        /// 分页查询输出总行数
        /// </summary>
        /// <typeparam name="Tkey">排序字段类型</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderLambda">排序条件</param>
        /// <param name="isAsc">升序or降序</param>
        /// <returns></returns>
        public List<T> GetPageList<T, Tkey>(DbContext db, int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, Tkey>> orderLambda, bool isAsc = true) where T : class, new()
        {
            int count = 0;
            List<T> list = null;
            count = db.Set<T>().Where(whereLambda).Count();
            if (isAsc)
            {
                var iQueryList = db.Set<T>().Where(whereLambda).OrderBy(orderLambda)
                   .Skip((pageIndex - 1) * pageSize).Take(pageSize);

                list = iQueryList.ToList();
            }
            else
            {
                var iQueryList = db.Set<T>().Where(whereLambda).OrderByDescending(orderLambda)
                 .Skip((pageIndex - 1) * pageSize).Take(pageSize);
                list = iQueryList.ToList();
            }
            rowCount = count;
            return list;
        }

        #endregion

        #region 修改

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">修改后的实体</param>
        /// <returns></returns>
        public int Modify<T>(DbContext db, T model) where T : class, new()
        {
            db.Entry(model).State = EntityState.Modified;
            return db.SaveChanges();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">修改后的实体</param>
        /// <returns></returns>
        public int Modify(DbContext db, object model)
        {
            db.Entry(model).State = EntityState.Modified;
            return db.SaveChanges();
        }

        /// <summary>
        /// 批量数据修改
        /// </summary>
        /// <param name="list">修改后的实体列表</param>
        /// <returns></returns>
        public int ModifyByList(DbContext db, IList list)
        {
            foreach (var model in list)
            {
                db.Entry(model).State = EntityState.Modified;
            }
            return db.SaveChanges();
        }

        /// <summary>
        /// 批量修改（非lambda）
        /// </summary>
        /// <param name="model">要修改实体中 修改后的属性 </param>
        /// <param name="whereLambda">查询实体的条件</param>
        /// <param name="proNames">lambda的形式表示要修改的实体属性名</param>
        /// <returns></returns>
        public int ModifyBy<T>(DbContext db, T model, Expression<Func<T, bool>> whereLambda, params string[] proNames) where T : class, new()
        {
            List<T> listModifes = db.Set<T>().Where(whereLambda).ToList();
            Type t = typeof(T);
            List<PropertyInfo> proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            Dictionary<string, PropertyInfo> dicPros = new Dictionary<string, PropertyInfo>();
            proInfos.ForEach(p =>
            {
                if (proNames.Contains(p.Name))
                {
                    dicPros.Add(p.Name, p);
                }
            });
            foreach (string proName in proNames)
            {
                if (dicPros.ContainsKey(proName))
                {
                    PropertyInfo proInfo = dicPros[proName];
                    object newValue = proInfo.GetValue(model, null);
                    foreach (T m in listModifes)
                    {
                        proInfo.SetValue(m, newValue, null);
                    }
                }
            }
            return db.SaveChanges();
        }
        #endregion
    }
}