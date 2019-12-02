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

namespace Services
{
    public class OrderService : ServiceBase, IOrderService
    {
        public List<VFSMOrder> GetFSMOrder()
        {
            return BLLFty.Create<OrderBLL>().GetFSMOrder();
        }

        public string GetMaxBillNo()
        {
            return BLLFty.Create<OrderBLL>().GetMaxBillNo();
        }

        public List<VOrder> GetOrder()
        {
            return BLLFty.Create<OrderBLL>().GetOrder();
        }

        public List<OrderDtl> GetOrderDtl(Guid hdID)
        {
            return BLLFty.Create<OrderBLL>().GetOrderDtl(hdID);
        }

        public List<OrderHd> GetOrderHd()
        {
            return BLLFty.Create<OrderBLL>().GetOrderHd();
        }

        public OrderHd GetOrderHd(Guid id)
        {
            return BLLFty.Create<OrderBLL>().GetOrderHd(id);
        }

        public List<VProductionOrder> GetProductionOrder()
        {
            return BLLFty.Create<OrderBLL>().GetProductionOrder();
        }

        public List<VProductionOrderDtlForPrint> GetProductionOrderDtlForPrint()
        {
            return BLLFty.Create<OrderBLL>().GetProductionOrderDtlForPrint();
        }

        public List<VProductionOrderDtlForPrint> GetProductionOrderDtlForPrint(Guid hdID)
        {
            return BLLFty.Create<OrderBLL>().GetProductionOrderDtlForPrint(hdID);
        }

        public List<OrderDtl> GetVFSMOrderDtlByMoldList(Guid hdID)
        {
            return BLLFty.Create<OrderBLL>().GetVFSMOrderDtlByMoldList(hdID);
        }

        public List<OrderDtl> GetVFSMOrderDtlByMoldMaterial(Guid hdID)
        {
            return BLLFty.Create<OrderBLL>().GetVFSMOrderDtlByMoldMaterial(hdID);
        }

        public List<VOrderDtlByBOM> GetVOrderDtlByBOM(Guid hdID, int bomType)
        {
            return BLLFty.Create<OrderBLL>().GetVOrderDtlByBOM(hdID, bomType);
        }

        public void Insert(OrderHd hd, List<OrderDtl> dtl)
        {
            BLLFty.Create<OrderBLL>().Insert(hd, dtl);
        }

        public void Update(OrderHd hd)
        {
            BLLFty.Create<OrderBLL>().Update(hd);
        }

        public void Update(OrderHd hd, List<OrderDtl> dtl)
        {
            BLLFty.Create<OrderBLL>().Update(hd, dtl);
        }

        public void Audit(OrderHd orderhd, StockOutBillHd hd, List<StockOutBillDtl> dtl, OrderHd poHd, List<OrderDtl> poDtlList, List<Alert> delList)
        {
            BLLFty.Create<OrderBLL>().Audit(orderhd, hd, dtl, poHd, poDtlList, delList);
        }

        public void Delete(Guid id)
        {
            BLLFty.Create<OrderBLL>().Delete(id);
        }

    }
}

