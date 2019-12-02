using Common;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBML;
using BLL;
using Microsoft.Practices.Unity;
using Factory;
using System.Collections;

namespace Services
{
    public class InventoryService : ServiceBase, IInventoryService
    {
        public List<VAccountBook> GetAccountBook()
        {
            return BLLFty.Create<InventoryBLL>().GetAccountBook();
        }

        public List<VInventory> GetInventory()
        {
            return BLLFty.Create<InventoryBLL>().GetInventory();
        }

        public List<Inventory> GetInventory(Guid warehouseID, Guid goodsID, int pcs)
        {
            return BLLFty.Create<InventoryBLL>().GetInventory(warehouseID, goodsID, pcs);
        }

        public List<VInventoryGroupByGoods> GetInventoryGroupByGoods()
        {
            return BLLFty.Create<InventoryBLL>().GetInventoryGroupByGoods();
        }

        public List<VMaterialInventory> GetMaterialInventory()
        {
            return BLLFty.Create<InventoryBLL>().GetMaterialInventory();
        }

        public List<VMaterialInventoryGroupByGoods> GetMaterialInventoryGroupByGoods()
        {
            return BLLFty.Create<InventoryBLL>().GetMaterialInventoryGroupByGoods();
        }

        public List<VProfitAndLoss> GetProfitAndLoss()
        {
            return BLLFty.Create<InventoryBLL>().GetProfitAndLoss();
        }

        public List<VStocktaking> GetStocktaking()
        {
            return BLLFty.Create<InventoryBLL>().GetStocktaking();
        }

        public void Insert(List<Stocktaking> stList)
        {
            BLLFty.Create<InventoryBLL>().Insert(stList);
        }

        public void Insert(object hd, IList dtl, List<Inventory> ityList, List<AccountBook> abList, List<Alert> delList, List<Alert> alertList)
        {
            BLLFty.Create<InventoryBLL>().Insert(hd, dtl, ityList, abList, delList, alertList);
        }

        public void StocktakingUpdate(Guid warehouseID, int goodsBigType, Guid? supplierID, List<Inventory> list, List<AccountBook> abList)
        {
            BLLFty.Create<InventoryBLL>().StocktakingUpdate(warehouseID, goodsBigType, supplierID, list, abList);
        }

        public void CancelAudit(object hd, List<Inventory> ityList, List<AccountBook> abList)
        {
            BLLFty.Create<InventoryBLL>().CancelAudit(hd, ityList, abList);
        }
    }
}

