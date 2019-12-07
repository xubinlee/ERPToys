using DAL;
using EDMX;
using Factory;
using IWcfServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    public class StockInBillService : IStockInBillService
    {
        public void Insert(StockInBillHd hd, List<StockInBillDtl> dtlList)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                DALFty.Create<BaseDAL>().AddBill(db, hd, dtlList);
            }
        }
    }
}
