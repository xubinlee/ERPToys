using EDMX;
using IBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Z.EntityFramework.Plus;

namespace DAL
{
    public class StockOutBillDAL : IDALBase
    {
        RedisHelper redis = new RedisHelper();

        /// <summary>
        /// 保存表单方法
        /// </summary>
        /// <param name="hd">表头数据</param>
        /// <param name="dtlList">明细数据</param>
        /// <returns></returns>
        public virtual void SaveBill(ERPToysContext db, StockOutBillHd hd, List<StockOutBillDtl> dtlList)
        {
            using (DbContextTransaction trans = db.Database.BeginTransaction())
            {
                try
                {
                    // 让使用typeof(T).Name标签的所有缓存过期
                    QueryCacheManager.ExpireTag(nameof(StockOutBillHd));
                    QueryCacheManager.ExpireTag(nameof(StockOutBillDtl));
                    redis.KeyDelete(nameof(StockOutBillHd));
                    redis.KeyDelete(nameof(StockOutBillDtl));

                    db.Set<StockOutBillHd>().AddOrUpdateExtension(hd);
                    db.SaveChanges();
                    db.Set<StockOutBillDtl>().AddOrUpdateExtension(dtlList);
                    db.SaveChanges();
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                }
            }
        }
    }
}
