using DAL;
using DBML;
using Factory;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SLSalePriceBLL : IBLLBase
    {
        public List<SLSalePrice> GetSLSalePrice(Guid businessContactID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<SLSalePriceDAL>().GetSLSalePrice(dcc, businessContactID);
            }
        }

        public List<SLSalePrice> GetSLSalePrice()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<SLSalePriceDAL>().GetSLSalePrice(dcc);
            }
        }
        public void Insert(SLSalePrice obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<SLSalePriceDAL>().Insert(dcc, obj);
                dcc.Save();
            }
        }

        public void Insert(List<SLSalePrice> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<SLSalePriceDAL>().Insert(dcc, list);
                dcc.Save();
            }
        }

        public void Update(SLSalePrice obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<SLSalePriceDAL>().Update(dcc, obj);
                dcc.Save();
            }
        }


        public void Update(Guid parentGoodsID, List<SLSalePrice> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<SLSalePriceDAL>().Update(dcc, parentGoodsID, list);
                dcc.Save();
            }
        }

        public void Delete(Guid parentGoodsID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<SLSalePriceDAL>().Delete(dcc, parentGoodsID);
                dcc.Save();
            }
        }
    }
}
