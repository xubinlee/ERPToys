using Common;
using DAL;
using EDMX;
using Factory;
using IWcfServiceInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Z.EntityFramework.Plus;

namespace WcfService
{
    public class InventoryService : ServiceBase, IInventoryService
    {
        public virtual List<Inventory> GetListBy(Expression<Func<Inventory, bool>> whereLambda = null)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                return DALFty.Create<BaseDAL>().GetListBy<Inventory>(db, whereLambda);
            }
        }

        public virtual List<Inventory> GetListByNoTracking(Expression<Func<Inventory, bool>> whereLambda = null)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                return DALFty.Create<BaseDAL>().GetListByNoTracking<Inventory>(db, whereLambda);
            }
        }

        public virtual void StocktakingUpdate(Guid warehouseID, int goodsBigType, Guid? supplierID, List<Inventory> list, List<AccountBook> abList)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                using (DbContextTransaction trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        //更新盘点数据之前先将原有记录删除再全部添加
                        List<Inventory> delList = new List<Inventory>();
                        List<Inventory> oldList = new List<Inventory>();
                        if (supplierID == null || supplierID == Guid.Empty)
                            oldList = db.Set<Inventory>().FromCache(nameof(Inventory)).Where(o => o.WarehouseID == warehouseID).ToList();
                        else
                            oldList = db.Set<Inventory>().FromCache(nameof(Inventory)).Where(o => o.WarehouseID == warehouseID && o.SupplierID == supplierID).ToList();
                        if (goodsBigType != -1)
                        {
                            List<Goods> goods = db.Set<Goods>().FromCache(nameof(Goods)).Where(o => o.Type == goodsBigType).ToList();
                            foreach (Inventory item in oldList)
                            {
                                if (goods.Exists(o => o.ID == item.GoodsID))
                                    delList.Add(item);
                            }
                        }
                        else
                            delList = oldList;
                        db.Set<Inventory>().RemoveRange(delList);
                        if (list.Count > 0)
                            DALFty.Create<BaseDAL>().AddByBulkCopy<Inventory>(db, list);
                        if (abList.Count > 0)
                            DALFty.Create<BaseDAL>().AddByBulkCopy<AccountBook>(db, abList);
                        //更新成功后删除导入数据
                        db.Set<Stocktaking>().DeleteFromQuery();
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
