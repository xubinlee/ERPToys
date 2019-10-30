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
    public class CustomerSLSalePriceBLL : IBLLBase
    {
        public List<CustomerSLSalePrice> GetCustomerSLSalePrice(Guid supplierID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<CustomerSLSalePriceDAL>().GetCustomerSLSalePrice(dcc, supplierID);
            }
        }

        public List<CustomerSLSalePrice> GetCustomerSLSalePrice()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<CustomerSLSalePriceDAL>().GetCustomerSLSalePrice(dcc);
            }
        }
        public void Insert(CustomerSLSalePrice obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<CustomerSLSalePriceDAL>().Insert(dcc, obj);
                dcc.Save();
            }
        }

        public void Insert(List<CustomerSLSalePrice> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<CustomerSLSalePriceDAL>().Insert(dcc, list);
                dcc.Save();
            }
        }

        public void Update(CustomerSLSalePrice obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<CustomerSLSalePriceDAL>().Update(dcc, obj);
                dcc.Save();
            }
        }


        public void Update(Guid parentGoodsID, List<CustomerSLSalePrice> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<CustomerSLSalePriceDAL>().Update(dcc, parentGoodsID, list);
                dcc.Save();
            }
        }

        public void Delete(Guid parentGoodsID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<CustomerSLSalePriceDAL>().Delete(dcc, parentGoodsID);
                dcc.Save();
            }
        }
    }
}
