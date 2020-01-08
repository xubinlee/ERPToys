using Common;
using EDMX;
using IWcfServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace ClientFactory
{
    public class StockInBillFactory : IStockInBillService
    {
        private static IStockInBillService stockInBillService = ServiceProxyFactory.Create<IStockInBillService>("StockInBillService");

        RedisHelper redis = new RedisHelper();

        public virtual void SaveBill(StockInBillHd hd, List<StockInBillDtl> dtlList)
        {
            stockInBillService.SaveBill(hd, dtlList);
        }

        public virtual bool Delete(Guid id)
        {
            return stockInBillService.Delete(id);
        }

        /// <summary>
        /// 按实体类型查询实体列表数据（返回List不需要修改或删除）
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns></returns>
        public virtual List<StockInBillHd> GetStockInBill(Guid id)
        {
            string key = nameof(StockInBillHd);// + "Include";
            if (!redis.KeyExists(key))
            {
                List<StockInBillHd> list = stockInBillService.GetStockInBill(id);
                redis.StringSet(key, list);
                return list;
            }
            return redis.StringGet<List<StockInBillHd>>(key);
        }

        public void Audit(StockInBillHd hd, List<StockInBillDtl> dtl, List<Inventory> ityList, List<AccountBook> abList, List<Alert> delList, List<Alert> alertList)
        {
            stockInBillService.Audit(hd, dtl, ityList, abList, delList, alertList);
        }

        public void CancelAudit(StockInBillHd hd, List<Inventory> ityList, List<AccountBook> abList)
        {
            stockInBillService.CancelAudit(hd, ityList, abList);
        }
    }
}
