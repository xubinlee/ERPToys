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

namespace WcfService
{
    public class InventoryService : IInventoryService
    {
        public void StocktakingUpdate(Guid warehouseID, int goodsBigType, Guid? supplierID, List<Inventory> list, List<AccountBook> abList)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                using (DbContextTransaction trans = db.Database.BeginTransaction())
                {
                //更新盘点数据之前先将原有记录删除再全部添加
                //List<Inventory> delList = new List<Inventory>();
                //List<Inventory> oldList = new List<Inventory>();
                //if (supplierID == null || supplierID == Guid.Empty)
                //    oldList = dcc.Inventory.Where(o => o.WarehouseID == warehouseID).ToList();
                //else
                //    oldList = dcc.Inventory.Where(o => o.WarehouseID == warehouseID && o.SupplierID == supplierID).ToList();
                //if (goodsBigType != -1)
                //{
                //    List<Goods> goods = dcc.Goods.Where(o => o.Type == goodsBigType).ToList();
                //    foreach (Inventory item in oldList)
                //    {
                //        if (goods.Exists(o => o.ID == item.GoodsID))
                //            delList.Add(item);
                //    }
                //}
                //else
                //    delList = oldList;
                //dcc.Inventory.DeleteAllOnSubmit(delList);
                //dcc.Inventory.InsertAllOnSubmit(list);
                //dcc.AccountBook.InsertAllOnSubmit(abList);
                ////更新成功后删除导入数据
                //var stList = dcc.Stocktaking.ToList();
                //dcc.Stocktaking.DeleteAllOnSubmit(stList);
                //dcc.SubmitChanges();
                    trans.Commit();
                }
            }
        }
    }
}
