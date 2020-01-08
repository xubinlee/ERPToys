﻿using EDMX;
using IBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Utility;
using Z.EntityFramework.Plus;

namespace DAL
{
    public class StockInBillDAL : IDALBase
    {
        RedisHelper redis = new RedisHelper();

        /// <summary>
        /// 保存表单方法
        /// </summary>
        /// <param name="hd">表头数据</param>
        /// <param name="dtlList">明细数据</param>
        /// <returns></returns>
        public virtual void SaveBill(ERPToysContext db, StockInBillHd hd, List<StockInBillDtl> dtlList)
        {
            using (DbContextTransaction trans = db.Database.BeginTransaction())
            {
                try
                {
                    // 让使用typeof(T).Name标签的所有缓存过期
                    QueryCacheManager.ExpireTag(nameof(StockInBillHd));
                    QueryCacheManager.ExpireTag(nameof(StockInBillDtl));
                    redis.KeyDelete(nameof(StockInBillHd));
                    redis.KeyDelete(nameof(StockInBillDtl));
                    
                    db.Set<StockInBillHd>().AddOrUpdateExtension(hd);
                    db.SaveChanges();
                    db.Set<StockInBillDtl>().AddOrUpdateExtension(dtlList);
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