using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Transactions;
using Common;
using DAL;
using EDMX;
using Factory;
using IWcfServiceInterface;
using Utility;
using Z.EntityFramework.Plus;

namespace WcfService
{
    public class StockOutBillService : ServiceBase, IStockOutBillService
    {
        RedisHelper redis = new RedisHelper();

        public List<StockOutBillHd> GetStockOutBill(Guid id)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                Expression<Func<StockOutBillHd, bool>> whereExpression = o => o.ID.Equals(id);
                return DALFty.Create<BaseDAL>().GetListByInclude<StockOutBillHd>(db, nameof(StockOutBillDtl), whereExpression);
            }
        }

        public void Audit(StockOutBillHd hd, List<StockOutBillDtl> dtl, List<Inventory> ityList, List<AccountBook> abList, List<Alert> delList, List<Alert> alertList)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                //DALFty.Create<InventoryDAL>().Audit(db, hd, dtl, ityList, abList, delList, alertList);
                using (TransactionScope ts = new TransactionScope())
                {
                    db.Entry(hd).State = EntityState.Modified;
                    db.SaveChanges();
                    //更新明细可能有新增记录
                    db.Set<StockOutBillDtl>().AddOrUpdateExtension(dtl);
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
        }

        public void CancelAudit(StockOutBillHd hd, List<Inventory> ityList, List<AccountBook> abList)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                //DALFty.Create<InventoryDAL>().CancelAudit(db, hd, ityList, abList);
                using (DbContextTransaction trans = db.Database.BeginTransaction())
                {
                    // 让使用typeof(T).Name标签的所有缓存过期
                    QueryCacheManager.ExpireTag(nameof(StockOutBillHd));
                    QueryCacheManager.ExpireTag(nameof(Inventory));
                    QueryCacheManager.ExpireTag(nameof(AccountBook));
                    redis.KeyDelete(nameof(StockOutBillHd));
                    redis.KeyDelete(nameof(Inventory));
                    redis.KeyDelete(nameof(AccountBook));

                    db.Entry(hd).State = EntityState.Modified;
                    db.SaveChanges();
                    try
                    {
                        if (!string.IsNullOrEmpty(hd.BillNo))
                        {
                            db.Set<Inventory>().Where(o => o.BillNo.Equals(hd.BillNo)).DeleteFromQuery();
                            db.Set<AccountBook>().Where(o => o.BillNo.Equals(hd.BillNo)).DeleteFromQuery();
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

        public void SaveBill(StockOutBillHd hd, List<StockOutBillDtl> dtlList)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                //DALFty.Create<StockOutBillDAL>().SaveBill(db, hd, dtlList);
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
        public bool Delete(Guid id)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                using (DbContextTransaction trans = db.Database.BeginTransaction())
                {
                    int hd = 0, dtl = 0;
                    try
                    {
                        Expression<Func<StockOutBillHd, bool>> whereHead = o => o.ID.Equals(id);
                        hd = DALFty.Create<BaseDAL>().DelBy<StockOutBillHd>(db, whereHead);
                        Expression<Func<StockOutBillDtl, bool>> whereDetail = o => o.HdID.Equals(id);
                        dtl = DALFty.Create<BaseDAL>().DelBy<StockOutBillDtl>(db, whereDetail);
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                    }
                    return (hd > 0 && dtl > 0);
                }
            }
        }
    }
}
