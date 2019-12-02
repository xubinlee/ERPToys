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
    public class StockOutBillService : ServiceBase, IStockOutBillService
    {
        public List<VMaterialStockOutBill> GetMaterialStockOutBill()
        {
            return BLLFty.Create<StockOutBillBLL>().GetMaterialStockOutBill();
        }

        public string GetMaxBillNo()
        {
            return BLLFty.Create<StockOutBillBLL>().GetMaxBillNo();
        }

        public List<VStockOutBill> GetStockOutBill()
        {
            return BLLFty.Create<StockOutBillBLL>().GetStockOutBill();
        }

        public List<StockOutBillDtl> GetStockOutBillDtl(Guid hdID)
        {
            return BLLFty.Create<StockOutBillBLL>().GetStockOutBillDtl(hdID);
        }

        public List<StockOutBillHd> GetStockOutBillHd()
        {
            return BLLFty.Create<StockOutBillBLL>().GetStockOutBillHd();
        }

        public StockOutBillHd GetStockOutBillHd(Guid id)
        {
            return BLLFty.Create<StockOutBillBLL>().GetStockOutBillHd(id);
        }

        public List<StockOutBillDtl> GetVStockOutBillDtlByBOM(Guid hdID, int bomType)
        {
            return BLLFty.Create<StockOutBillBLL>().GetVStockOutBillDtlByBOM(hdID, bomType);
        }

        public void Insert(StockOutBillHd hd, List<StockOutBillDtl> dtl)
        {
            BLLFty.Create<StockOutBillBLL>().Insert(hd, dtl);
        }

        public void Update(StockOutBillHd hd)
        {
            BLLFty.Create<StockOutBillBLL>().Update(hd);
        }

        public void Update(StockOutBillHd hd, List<StockOutBillDtl> dtl)
        {
            BLLFty.Create<StockOutBillBLL>().Update(hd, dtl);
        }

        public void Delete(Guid id)
        {
            BLLFty.Create<StockOutBillBLL>().Delete(id);
        }

    }
}

