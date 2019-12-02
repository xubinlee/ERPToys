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
    public class SLSalePriceService : ServiceBase, ISLSalePriceService
    {
        public List<SLSalePrice> GetSLSalePrice()
        {
            return BLLFty.Create<SLSalePriceBLL>().GetSLSalePrice();
        }

        public List<SLSalePrice> GetSLSalePrice(Guid businessContactID)
        {
            return BLLFty.Create<SLSalePriceBLL>().GetSLSalePrice(businessContactID);
        }

        public void Insert(List<SLSalePrice> list)
        {
            BLLFty.Create<SLSalePriceBLL>().Insert(list);
        }

        public void Insert(SLSalePrice obj)
        {
            BLLFty.Create<SLSalePriceBLL>().Insert(obj);
        }

        public void Update(SLSalePrice obj)
        {
            BLLFty.Create<SLSalePriceBLL>().Update(obj);
        }

        public void Update(Guid parentGoodsID, List<SLSalePrice> list)
        {
            BLLFty.Create<SLSalePriceBLL>().Update(parentGoodsID, list);
        }

        public void Delete(Guid parentGoodsID)
        {
            BLLFty.Create<SLSalePriceBLL>().Delete(parentGoodsID);
        }

    }
}

