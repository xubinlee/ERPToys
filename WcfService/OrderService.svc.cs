using Common;
using DAL;
using EDMX;
using Factory;
using IWcfServiceInterface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Utility;
using Z.EntityFramework.Plus;

namespace WcfService
{
    public class OrderService : ServiceBase, IOrderService
    {
        RedisHelper redis = new RedisHelper();

        public void SaveBill(OrderHd hd, List<OrderDtl> dtlList)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                //DALFty.Create<OrderDAL>().SaveBill(db, hd, dtlList);
                using (DbContextTransaction trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        // 让使用typeof(T).Name标签的所有缓存过期
                        QueryCacheManager.ExpireTag(nameof(StockInBillHd));
                        QueryCacheManager.ExpireTag(nameof(StockInBillDtl));
                        redis.KeyDelete(nameof(StockInBillHd));
                        redis.KeyDelete(nameof(StockInBillDtl));

                        db.Set<OrderHd>().AddOrUpdateExtension(hd);
                        db.SaveChanges();
                        db.Set<OrderDtl>().AddOrUpdateExtension(dtlList);
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
}
