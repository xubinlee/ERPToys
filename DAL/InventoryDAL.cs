using EDMX;
using Factory;
using IBase;
using System;
using System.Collections;
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
    public class InventoryDAL : IDALBase
    {
        RedisHelper redis = new RedisHelper();

        /// <summary>
        /// 出入库单审核
        /// </summary>
        /// <param name="db"></param>
        /// <param name="hd"></param>
        /// <param name="dtl"></param>
        /// <param name="ityList"></param>
        /// <param name="abList"></param>
        /// <param name="delList"></param>
        /// <param name="alertList"></param>
        public virtual void Audit(ERPToysContext db, Object hd, IList dtl, List<Inventory> ityList, List<AccountBook> abList, List<Alert> delList, List<Alert> alertList)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                if (dtl is StockInBillDtl)
                {
                    //更新明细可能有新增记录
                    db.Set<StockInBillDtl>().AddOrUpdateExtension((StockInBillDtl)dtl);
                    db.SaveChanges();
                }
                else if (dtl is StockOutBillDtl)
                {
                    //更新明细可能有新增记录
                    db.Set<StockOutBillDtl>().AddOrUpdateExtension((StockOutBillDtl)dtl);
                    db.SaveChanges();
                }
                else
                    return;
                db.Entry(hd).State = EntityState.Modified;
                db.SaveChanges();

                BaseDAL baseDAL = DALFty.Create<BaseDAL>();
                if (ityList.Count > 0)
                    baseDAL.AddByBulkCopy<Inventory>(db, ityList);
                if (abList.Count > 0)
                    baseDAL.AddByBulkCopy<AccountBook>(db, abList);

                if (delList.Count > 0)
                {
                    db.Set<Alert>().AttachRange(delList);
                    db.Set<Alert>().RemoveRange(delList);
                    db.SaveChanges();
                }
                if (alertList.Count > 0)
                    baseDAL.AddByBulkCopy<Alert>(db, alertList);
                ts.Complete();
            }
        }

        /// <summary>
        /// 出入库单取消审核
        /// </summary>
        /// <param name="db"></param>
        /// <param name="hd"></param>
        /// <param name="ityList"></param>
        /// <param name="abList"></param>
        /// <returns></returns>
        public virtual void CancelAudit(ERPToysContext db, Object hd, List<Inventory> ityList, List<AccountBook> abList)
        {
            using (DbContextTransaction trans = db.Database.BeginTransaction())
            {
                string billNo = string.Empty;
                if (hd is StockInBillHd)
                {
                    // 让使用typeof(T).Name标签的所有缓存过期
                    QueryCacheManager.ExpireTag(typeof(StockInBillHd).Name);
                    redis.KeyDelete(typeof(StockInBillHd).Name);

                    StockInBillHd head = hd as StockInBillHd;
                    billNo = head.BillNo;
                }
                else if (hd is StockOutBillHd)
                {
                    // 让使用typeof(T).Name标签的所有缓存过期
                    QueryCacheManager.ExpireTag(typeof(StockOutBillHd).Name);
                    redis.KeyDelete(typeof(StockOutBillHd).Name);

                    StockOutBillHd head = hd as StockOutBillHd;
                    billNo = head.BillNo;
                }
                else
                {
                    trans.Rollback();
                    return;
                }
                db.Entry(hd).State = EntityState.Modified;
                db.SaveChanges();
                QueryCacheManager.ExpireTag(typeof(Inventory).Name);
                QueryCacheManager.ExpireTag(typeof(AccountBook).Name);
                redis.KeyDelete(typeof(Inventory).Name);
                redis.KeyDelete(typeof(AccountBook).Name);
                try
                {
                    if (!string.IsNullOrEmpty(billNo))
                    {
                        db.Set<Inventory>().Where(o=>o.BillNo.Equals(billNo)).DeleteFromQuery();
                        db.Set<AccountBook>().Where(o => o.BillNo.Equals(billNo)).DeleteFromQuery();
                        trans.Commit();
                    }
                }
                catch
                {
                    trans.Rollback();
                }
            }
        }
    }
}
