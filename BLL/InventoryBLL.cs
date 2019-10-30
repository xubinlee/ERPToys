using DAL;
using DBML;
using Factory;
using IBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InventoryBLL : IBLLBase
    {
        //public Dictionary<Guid, Decimal> GetGoodsTotalQty(Guid warehouseID)
        //{
        //    using (DCC dcc = DBMLFty.Dcc)
        //    {
        //        return DALFty.Create<InventoryDAL>().GetGoodsTotalQty(dcc, warehouseID);
        //    }
        //}

        public List<Inventory> GetInventory(Guid warehouseID, Guid goodsID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<InventoryDAL>().GetInventory(dcc, warehouseID, goodsID);
            }
        }

        public List<Inventory> GetInventory(Guid warehouseID, Guid goodsID, int pcs)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<InventoryDAL>().GetInventory(dcc, warehouseID, goodsID, pcs);
            }
        }

        public List<VInventory> GetInventory()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<InventoryDAL>().GetInventory(dcc);
            }
        }

        public List<VInventoryGroupByGoods> GetInventoryGroupByGoods()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<InventoryDAL>().GetInventoryGroupByGoods(dcc);
            }
        }

        public List<VMaterialInventory> GetMaterialInventory()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<InventoryDAL>().GetMaterialInventory(dcc);
            }
        }

        public List<VMaterialInventoryGroupByGoods> GetMaterialInventoryGroupByGoods()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<InventoryDAL>().GetMaterialInventoryGroupByGoods(dcc);
            }
        }

        public List<VEMSInventoryGroupByGoods> GetEMSInventoryGroupByGoods()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<InventoryDAL>().GetEMSInventoryGroupByGoods(dcc);
            }
        }

        public List<VFSMInventoryGroupByGoods> GetFSMInventoryGroupByGoods()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<InventoryDAL>().GetFSMInventoryGroupByGoods(dcc);
            }
        }

        public List<VAccountBook> GetAccountBook()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<InventoryDAL>().GetAccountBook(dcc);
            }
        }

        #region 盘点

        public List<VStocktaking> GetStocktaking()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<InventoryDAL>().GetStocktaking(dcc);
            }
        }

        public List<VProfitAndLoss> GetProfitAndLoss()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<InventoryDAL>().GetProfitAndLoss(dcc);
            }
        }

        public void Insert(List<Stocktaking> stList)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<InventoryDAL>().Insert(dcc, stList);
                dcc.Save();
            }
        }

        public void StocktakingUpdate(Guid warehouseID, int goodsBigType, Guid? supplierID, List<Inventory> list, List<AccountBook> abList)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<InventoryDAL>().StocktakingUpdate(dcc, warehouseID, goodsBigType, supplierID, list, abList);
                dcc.Save();
            }
        }

        #endregion

        public void Insert(Object hd, IList dtl, List<Inventory> ityList, List<AccountBook> abList, List<Alert> delList, List<Alert> alertList)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<InventoryDAL>().Insert(dcc, hd, dtl, ityList, abList, delList, alertList);
                dcc.Save();
            }
        }

        public void CancelAudit(Object hd, List<Inventory> ityList, List<AccountBook> abList)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<InventoryDAL>().CancelAudit(dcc, hd, ityList, abList);
                dcc.Save();
            }
        }
    }
}
