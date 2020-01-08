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
    public class OrderFactory : IOrderService
    {
        private static IOrderService orderService = ServiceProxyFactory.Create<IOrderService>("OrderService");

        RedisHelper redis = new RedisHelper();

        public void SaveBill(OrderHd hd, List<OrderDtl> dtlList)
        {
            orderService.SaveBill(hd, dtlList);
        }
    }
}
