using Common;
using EDMX;
using IWcfServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace ClientFactory
{
    public class InventoryFactory : IInventoryService
    {
        private static IInventoryService inventoryService = ServiceProxyFactory.Create<IInventoryService>("InventoryService");

        RedisHelper redis = new RedisHelper();

        public List<Inventory> GetListBy(Expression<Func<Inventory, bool>> whereLambda = null)
        {
            if (!redis.KeyExists(nameof(Inventory)))
            {
                List<Inventory> result = inventoryService.GetListBy(whereLambda);
                redis.StringSet(nameof(Inventory), result);
            }
            return redis.StringGet<List<Inventory>>(nameof(Inventory));
        }

        public List<Inventory> GetListByNoTracking(Expression<Func<Inventory, bool>> whereLambda = null)
        {
            if (!redis.KeyExists(nameof(Inventory)))
            {
                List<Inventory> result = inventoryService.GetListByNoTracking(whereLambda);
                redis.StringSet(nameof(Inventory), result);
            }
            return redis.StringGet<List<Inventory>>(nameof(Inventory));
        }

        public void StocktakingUpdate(Guid warehouseID, int goodsBigType, Guid? supplierID, List<Inventory> list, List<AccountBook> abList)
        {
            inventoryService.StocktakingUpdate(warehouseID, goodsBigType, supplierID, list, abList);
        }
    }
}
