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
    public class StockInBillBLL : IBLLBase
    {
        public string GetMaxBillNo()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockInBillDAL>().GetMaxBillNo(dcc);
            }
        }

        public StockInBillHd GetStockInBillHd(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockInBillDAL>().GetStockInBillHd(dcc, id);
            }
        }

        public List<StockInBillHd> GetStockInBillHd()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockInBillDAL>().GetStockInBillHd(dcc);
            }
        }

        public List<StockInBillDtl> GetStockInBillDtl(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockInBillDAL>().GetStockInBillDtl(dcc, hdID);
            }
        }

        public List<VStockInBillDtlByColor> GetVStockInBillDtlByColor(Guid hdID, int bomType)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockInBillDAL>().GetVStockInBillDtlByColor(dcc, hdID, bomType);
            }
        }

        public List<StockInBillDtl> GetVStockInBillDtlByBOM(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockInBillDAL>().GetVStockInBillDtlByBOM(dcc, hdID);
            }
        }

        public List<StockInBillDtl> GetVStockInBillDtlByBOM(Guid hdID, int bomType)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockInBillDAL>().GetVStockInBillDtlByBOM(dcc, hdID, bomType);
            }
        }

        public List<VStockInBillDtlByBOM> GetVStockInBillDtlByBOM2(Guid hdID, int bomType)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockInBillDAL>().GetVStockInBillDtlByBOM2(dcc, hdID, bomType);
            }
        }

        public List<VStockInBill> GetStockInBill()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockInBillDAL>().GetStockInBill(dcc);
            }
        }

        public List<VStockInBill> GetStockInBill(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockInBillDAL>().GetStockInBill(dcc, hdID);
            }
        }

        //public List<VStockInBillDtlForPrint> GetStockInBillDtlForPrint()
        //{
        //    using (DCC dcc = DBMLFty.Dcc)
        //    {
        //        return DALFty.Create<StockInBillDAL>().GetStockInBillDtlForPrint(dcc);
        //    }
        //}

        //public List<VStockInBillDtlForPrint> GetStockInBillDtlForPrint(Guid hdID)
        //{
        //    using (DCC dcc = DBMLFty.Dcc)
        //    {
        //        return DALFty.Create<StockInBillDAL>().GetStockInBillDtlForPrint(dcc, hdID);
        //    }
        //}

        public List<VMaterialStockInBill> GetMaterialStockInBill()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockInBillDAL>().GetMaterialStockInBill(dcc);
            }
        }

        public List<VMaterialStockInBill> GetMaterialStockInBill(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StockInBillDAL>().GetMaterialStockInBill(dcc,hdID);
            }
        }

        //public List<VMaterialStockInBillDtlForPrint> GetMaterialStockInBillDtlForPrint()
        //{
        //    using (DCC dcc = DBMLFty.Dcc)
        //    {
        //        return DALFty.Create<StockInBillDAL>().GetMaterialStockInBillDtlForPrint(dcc);
        //    }
        //}

        //public List<VMaterialStockInBillDtlForPrint> GetMaterialStockInBillDtlForPrint(Guid hdID)
        //{
        //    using (DCC dcc = DBMLFty.Dcc)
        //    {
        //        return DALFty.Create<StockInBillDAL>().GetMaterialStockInBillDtlForPrint(dcc, hdID);
        //    }
        //}

        public void Audit(OrderHd orderhd, List<OrderDtl> orderdtl, StockInBillHd hd, List<StockInBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<StockInBillDAL>().Audit(dcc, orderhd, orderdtl, hd, dtl);
                dcc.Save();
            }
        }

        public void Insert(StockInBillHd hd, List<StockInBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<StockInBillDAL>().Insert(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Update(StockInBillHd hd, List<StockInBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<StockInBillDAL>().Update(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Update(StockInBillHd hd)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<StockInBillDAL>().Update(dcc, hd);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<StockInBillDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
