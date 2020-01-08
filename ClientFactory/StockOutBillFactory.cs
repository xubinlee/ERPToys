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
    public class StockOutBillFactory : IStockOutBillService
    {
        private static IStockOutBillService stockOutBillService = ServiceProxyFactory.Create<IStockOutBillService>("StockOutBillService");

        RedisHelper redis = new RedisHelper();

        /// <summary>
        /// 按实体类型查询实体列表数据（返回List不需要修改或删除）
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns></returns>
        public virtual List<StockOutBillHd> GetStockOutBill(Guid id)
        {
            string key = nameof(StockOutBillHd);// + "Include";
            if (!redis.KeyExists(key))
            {
                List<StockOutBillHd> list = stockOutBillService.GetStockOutBill(id);
                redis.StringSet(key, list);
                return list;
            }
            return redis.StringGet<List<StockOutBillHd>>(key);
        }

        public void Audit(StockOutBillHd hd, List<StockOutBillDtl> dtl, List<Inventory> ityList, List<AccountBook> abList, List<Alert> delList, List<Alert> alertList)
        {
            stockOutBillService.Audit(hd, dtl, ityList, abList, delList, alertList);
        }

        public void CancelAudit(StockOutBillHd hd, List<Inventory> ityList, List<AccountBook> abList)
        {
            stockOutBillService.CancelAudit(hd, ityList, abList);
        }

        public void SaveBill(StockOutBillHd hd, List<StockOutBillDtl> dtlList)
        {
            stockOutBillService.SaveBill(hd, dtlList);
        }

        public virtual bool Delete(Guid id)
        {
            return stockOutBillService.Delete(id);
        }
    }
}
