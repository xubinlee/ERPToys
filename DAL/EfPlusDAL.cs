using IBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EfPlusDAL : IDALBase
    {
        /// <summary>
        /// 海量数据插入方法(该插件新增功能要收费，免费版本需要定期更新)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public virtual void AddByBulk<T>(DbContext db, List<T> list) where T : class, new()
        {
            db.Set<T>().BulkInsert(list);
        }

        /// <summary>
        /// 海量数据修改方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public virtual void UpdateByBulk<T>(DbContext db, List<T> list) where T : class, new()
        {
            db.Set<T>().BulkUpdate(list);
        }

        /// <summary>
        /// 海量数据插入和更新方法
        /// </summary>
        /// <param name="insertList">插入的实体列表</param>
        /// <param name="updateList">更新实体列表</param>
        /// <returns></returns>
        public virtual void AddAndUpdateByBulk<T>(DbContext db, List<T> insertList, List<T> updateList) where T : class, new()
        {
            using (DbContextTransaction trans = db.Database.BeginTransaction())
            {
                db.Set<T>().BulkInsert(insertList);
                db.Set<T>().BulkUpdate(updateList);
                trans.Commit();
            }
        }

        /// <summary>
        /// 添加表单方法
        /// </summary>
        /// <param name="hd">表头数据</param>
        /// <param name="dtlList">明细数据</param>
        /// <returns></returns>
        public virtual void AddBillByBulk<H, T>(DbContext db, H hd, List<T> dtlList) where H : class, new() where T : class, new()
        {
            using (DbContextTransaction trans = db.Database.BeginTransaction())
            {
                db.Set<H>().Add(hd);
                db.Set<T>().BulkInsert(dtlList);
                trans.Commit();
            }
        }

        /// <summary>
        /// 根据条件删除(支持批量删除)
        /// </summary>
        /// <param name="delWhere">传入Lambda表达式(生成表达式目录树)</param>
        /// <returns></returns>
        public virtual int DeleteByBulk<T>(DbContext db, Expression<Func<T, bool>> delWhere) where T : class, new()
        {
            return db.Set<T>().Where(delWhere).DeleteFromQuery();
        }

        /// <summary>
        /// 先删除再添加(批量操作)
        /// </summary>
        /// <param name="delWhere">传入Lambda表达式(生成表达式目录树)</param>
        /// <param name="insertList">插入列表</param>
        /// <returns></returns>
        public virtual void DeleteAndAdd<T>(DbContext db, Expression<Func<T, bool>> delWhere, List<T> insertList) where T : class, new()
        {
            using (DbContextTransaction trans = db.Database.BeginTransaction())
            {
                db.Set<T>().Where(delWhere).DeleteFromQuery();
                db.Set<T>().BulkInsert(insertList);
                trans.Commit();
            }
        }
    }
}
