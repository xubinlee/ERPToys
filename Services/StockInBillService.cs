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
    public class StockInBillService : ServiceBase, IStockInBillService
    {
        public List<VMaterialStockInBill> GetMaterialStockInBill()
        {
            return BLLFty.Create<StockInBillBLL>().GetMaterialStockInBill();
        }

        public string GetMaxBillNo()
        {
            return BLLFty.Create<StockInBillBLL>().GetMaxBillNo();
        }

        public List<VStockInBill> GetStockInBill()
        {
            return BLLFty.Create<StockInBillBLL>().GetStockInBill();
        }

        public List<StockInBillDtl> GetStockInBillDtl(Guid hdID)
        {
            return BLLFty.Create<StockInBillBLL>().GetStockInBillDtl(hdID);
        }

        public List<StockInBillHd> GetStockInBillHd()
        {
            return BLLFty.Create<StockInBillBLL>().GetStockInBillHd();
        }

        public StockInBillHd GetStockInBillHd(Guid id)
        {
            return BLLFty.Create<StockInBillBLL>().GetStockInBillHd(id);
        }

        public List<StockInBillDtl> GetVStockInBillDtlByBOM(Guid hdID, int bomType)
        {
            return BLLFty.Create<StockInBillBLL>().GetVStockInBillDtlByBOM(hdID, bomType);
        }

        public void Insert(StockInBillHd hd, List<StockInBillDtl> dtl)
        {
            BLLFty.Create<StockInBillBLL>().Insert(hd, dtl);
        }

        public void Update(StockInBillHd hd)
        {
            BLLFty.Create<StockInBillBLL>().Update(hd);
        }

        public void Update(StockInBillHd hd, List<StockInBillDtl> dtl)
        {
            BLLFty.Create<StockInBillBLL>().Update(hd, dtl);
        }

        public void Audit(OrderHd orderhd, List<OrderDtl> orderdtl, StockInBillHd hd, List<StockInBillDtl> dtl)
        {
            BLLFty.Create<StockInBillBLL>().Audit(orderhd, orderdtl, hd, dtl);
        }

        public void Delete(Guid id)
        {
            BLLFty.Create<StockInBillBLL>().Delete(id);
        }

    }
}

