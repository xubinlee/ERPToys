using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EfPlusDAL
    {
        /// <summary>
        /// 海量数据插入方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public void AddByBulk<T>(DbContext db, List<T> list) where T : class, new()
        {
            db.Set<T>().BulkInsert(list);
        }

        /// <summary>
        /// 海量数据修改方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public void UpdateByBulk<T>(DbContext db, List<T> list) where T : class, new()
        {
            db.Set<T>().BulkUpdate(list);
        }

        /// <summary>
        /// 根据条件删除(支持批量删除)
        /// </summary>
        /// <param name="delWhere">传入Lambda表达式(生成表达式目录树)</param>
        /// <returns></returns>
        public int DeleteByBulk<T>(DbContext db, Expression<Func<T, bool>> delWhere) where T : class, new()
        {
            return db.Set<T>().Where(delWhere).DeleteFromQuery();
        }
    }
}
