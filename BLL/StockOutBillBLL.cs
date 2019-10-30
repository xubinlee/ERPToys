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
    public class StockOutBillBLL : IBLLBase
    {
        public string GetMaxBillNo()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockOutBillDAL>().GetMaxBillNo(dcc);
            }
        }

        public StockOutBillHd GetStockOutBillHd(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockOutBillDAL>().GetStockOutBillHd(dcc, id);
            }
        }

        public List<StockOutBillHd> GetStockOutBillHd()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockOutBillDAL>().GetStockOutBillHd(dcc);
            }
        }

        public List<StockOutBillDtl> GetStockOutBillDtl(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockOutBillDAL>().GetStockOutBillDtl(dcc, hdID);
            }
        }

        public List<StockOutBillDtl> GetVStockOutBillDtlByBOM(Guid hdID, int bomType)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockOutBillDAL>().GetVStockOutBillDtlByBOM(dcc, hdID, bomType);
            }
        }

        public List<VStockOutBill> GetStockOutBill()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockOutBillDAL>().GetStockOutBill(dcc);
            }
        }

        //public List<VStockOutBillDtlForPrint> GetStockOutBillDtlForPrint()
        //{
        //    using (DCC dcc = DBMLFty.Dcc)
        //    {
        //        return DALFty.Create<StockOutBillDAL>().GetStockOutBillDtlForPrint(dcc);
        //    }
        //}

        //public List<VStockOutBillDtlForPrint> GetStockOutBillDtlForPrint(Guid hdID)
        //{
        //    using (DCC dcc = DBMLFty.Dcc)
        //    {
        //        return DALFty.Create<StockOutBillDAL>().GetStockOutBillDtlForPrint(dcc, hdID);
        //    }
        //}

        public List<VMaterialStockOutBill> GetMaterialStockOutBill()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockOutBillDAL>().GetMaterialStockOutBill(dcc);
            }
        }

        //public List<VMaterialStockOutBillDtlForPrint> GetMaterialStockOutBillDtlForPrint()
        //{
        //    using (DCC dcc = DBMLFty.Dcc)
        //    {
        //        return DALFty.Create<StockOutBillDAL>().GetMaterialStockOutBillDtlForPrint(dcc);
        //    }
        //}

        //public List<VMaterialStockOutBillDtlForPrint> GetMaterialStockOutBillDtlForPrint(Guid hdID)
        //{
        //    using (DCC dcc = DBMLFty.Dcc)
        //    {
        //        return DALFty.Create<StockOutBillDAL>().GetMaterialStockOutBillDtlForPrint(dcc, hdID);
        //    }
        //}

        public void Insert(StockOutBillHd hd, List<StockOutBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<StockOutBillDAL>().Insert(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Update(StockOutBillHd hd, List<StockOutBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<StockOutBillDAL>().Update(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Update(StockOutBillHd hd)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<StockOutBillDAL>().Update(dcc, hd);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<StockOutBillDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
