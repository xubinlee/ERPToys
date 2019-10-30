using DBML;
using IBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL
{
    public class InventoryDAL : IDALBase
    {
        /// <summary>
        /// 获得货品的库存数量
        /// </summary>
        /// <param name="dcc"></param>
        /// <returns></returns>
        //public Dictionary<Guid, Decimal> GetGoodsTotalQty(DCC dcc, Guid warehouseID)
        //{
        //    var query = from i in dcc.Inventory
        //                where i.WarehouseID == warehouseID
        //                group i by i.GoodsID into g
        //                select new
        //                {
        //                    GoodsID = g.Key,
        //                    TotalQty = g.Sum(o => o.Qty)
        //                };
        //    return query.ToDictionary(k => k.GoodsID, v => v.TotalQty);
        //}

        public List<Inventory> GetInventory(DCC dcc, Guid warehouseID, Guid goodsID)
        {
            return dcc.Inventory.Where(o => o.WarehouseID == warehouseID && o.GoodsID == goodsID).OrderBy(o => o.EntryDate).ToList();
        }

        public List<Inventory> GetInventory(DCC dcc, Guid warehouseID, Guid goodsID, int pcs)
        {
            return dcc.Inventory.Where(o => o.WarehouseID == warehouseID && o.GoodsID == goodsID && o.PCS == pcs).OrderBy(o => o.EntryDate).ToList();
        }

        public List<VInventory> GetInventory(DCC dcc)
        {
            return dcc.VInventory.OrderBy(o => o.登帐日期).ToList();
        }

        public List<VInventoryGroupByGoods> GetInventoryGroupByGoods(DCC dcc)
        {
            return dcc.VInventoryGroupByGoods.OrderBy(o => o.货号).ToList();
        }

        public List<VMaterialInventory> GetMaterialInventory(DCC dcc)
        {
            return dcc.VMaterialInventory.OrderBy(o => o.登帐日期).ToList();
        }

        public List<VMaterialInventoryGroupByGoods> GetMaterialInventoryGroupByGoods(DCC dcc)
        {
            return dcc.VMaterialInventoryGroupByGoods.OrderBy(o => o.货号).ToList();
        }
        public List<VEMSInventoryGroupByGoods> GetEMSInventoryGroupByGoods(DCC dcc)
        {
            return dcc.VEMSInventoryGroupByGoods.OrderBy(o => o.货号).ToList();
        }
        public List<VFSMInventoryGroupByGoods> GetFSMInventoryGroupByGoods(DCC dcc)
        {
            return dcc.VFSMInventoryGroupByGoods.OrderBy(o => o.货号).ToList();
        }

        public List<VAccountBook> GetAccountBook(DCC dcc)
        {
            return dcc.VAccountBook.OrderBy(o => o.记帐日期).ToList();
        }

        #region 盘点

        public List<VStocktaking> GetStocktaking(DCC dcc)
        {
            return dcc.VStocktaking.OrderByDescending(o => o.盘点日期).ToList();
        }

        public List<VProfitAndLoss> GetProfitAndLoss(DCC dcc)
        {
            return dcc.VProfitAndLoss.OrderBy(o => o.货号).ToList();
        }

        public void Insert(DCC dcc, List<Stocktaking> stList)
        {
            dcc.Stocktaking.InsertAllOnSubmit(stList);
        }

        public void StocktakingUpdate(DCC dcc, Guid warehouseID, int goodsBigType, Guid? supplierID, List<Inventory> list, List<AccountBook> abList)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                //更新盘点数据之前先将原有记录删除再全部添加
                List<Inventory> delList = new List<Inventory>();
                List<Inventory> oldList = new List<Inventory>();
                if (supplierID == null || supplierID == Guid.Empty)
                    oldList = dcc.Inventory.Where(o => o.WarehouseID == warehouseID).ToList();
                else
                    oldList = dcc.Inventory.Where(o => o.WarehouseID == warehouseID && o.SupplierID == supplierID).ToList();
                if (goodsBigType != -1)
                {
                    List<Goods> goods = dcc.Goods.Where(o => o.Type == goodsBigType).ToList();
                    foreach (Inventory item in oldList)
                    {
                        if (goods.Exists(o => o.ID == item.GoodsID))
                            delList.Add(item);
                    }
                }
                else
                    delList = oldList;
                dcc.Inventory.DeleteAllOnSubmit(delList);
                dcc.Inventory.InsertAllOnSubmit(list);
                dcc.AccountBook.InsertAllOnSubmit(abList);
                //更新成功后删除导入数据
                var stList = dcc.Stocktaking.ToList();
                dcc.Stocktaking.DeleteAllOnSubmit(stList);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        #endregion

        public void Insert(DCC dcc, Object hd, IList dtl, List<Inventory> ityList, List<AccountBook> abList, List<Alert> delList, List<Alert> alertList)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                if (hd is StockInBillHd)
                {
                    dcc.StockInBillHd.Attach((StockInBillHd)hd);
                    dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
                    //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                    var lst = dcc.StockInBillDtl.Where(o => o.HdID == ((StockInBillHd)hd).ID);
                    dcc.StockInBillDtl.DeleteAllOnSubmit(lst);
                    foreach (StockInBillDtl item in (List<StockInBillDtl>)dtl)
                    {
                        item.ID = Guid.NewGuid();
                        item.HdID = ((StockInBillHd)hd).ID;
                    }
                    dcc.StockInBillDtl.InsertAllOnSubmit((List<StockInBillDtl>)dtl);
                }
                else if (hd is StockOutBillHd)
                {
                    dcc.StockOutBillHd.Attach((StockOutBillHd)hd);
                    dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
                    //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                    var lst = dcc.StockOutBillDtl.Where(o => o.HdID == ((StockOutBillHd)hd).ID);
                    dcc.StockOutBillDtl.DeleteAllOnSubmit(lst);
                    foreach (StockOutBillDtl item in (List<StockOutBillDtl>)dtl)
                    {
                        item.ID = Guid.NewGuid();
                        item.HdID = ((StockOutBillHd)hd).ID;
                    }
                    dcc.StockOutBillDtl.InsertAllOnSubmit((List<StockOutBillDtl>)dtl);
                }
                else
                    return;
                dcc.Inventory.InsertAllOnSubmit(ityList);
                dcc.AccountBook.InsertAllOnSubmit(abList);
                if (delList.Count > 0)
                {
                    dcc.Alert.AttachAll(delList);//附加实体---增加此段代码即可解决“无法删除尚未附加的实体”问题 
                    dcc.Alert.DeleteAllOnSubmit(delList);
                }
                if (alertList.Count > 0)
                    dcc.Alert.InsertAllOnSubmit(alertList);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void CancelAudit(DCC dcc, Object hd, List<Inventory> ityList, List<AccountBook> abList)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                string billNo = string.Empty;
                if (hd is StockInBillHd)
                {
                    dcc.StockInBillHd.Attach((StockInBillHd)hd);
                    billNo = ((StockInBillHd)hd).BillNo;
                }
                else if (hd is StockOutBillHd)
                {
                    dcc.StockOutBillHd.Attach((StockOutBillHd)hd);
                    billNo = ((StockOutBillHd)hd).BillNo;
                }
                else
                    return;
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
                if (!string.IsNullOrEmpty(billNo))
                {
                   //List<Inventory> i = dcc.Inventory.OrderByDescending(o=>o.EntryDate).FirstOrDefault(o => o.BillNo == billNo);
                    List<Inventory> i = dcc.Inventory.Where(o => o.BillNo == billNo).ToList();
                   if (i == null || i.Count == 0)
                   {
                       foreach (Inventory item in ityList)
                       {
                           item.Qty = -item.Qty;
                           item.BillNo = "取消审核调整";
                       }
                       dcc.Inventory.InsertAllOnSubmit(ityList);
                   }
                   else
                       dcc.Inventory.DeleteAllOnSubmit(i);
                    var ab = dcc.AccountBook.Where(o => o.BillNo == billNo);
                    dcc.AccountBook.DeleteAllOnSubmit(ab);
                }
                dcc.SubmitChanges();
                ts.Complete();
            }
        }
    }
}
