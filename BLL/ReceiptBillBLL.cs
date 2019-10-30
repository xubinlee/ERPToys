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
    public class ReceiptBillBLL : IBLLBase
    {
        public string GetMaxBillNo()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReceiptBillDAL>().GetMaxBillNo(dcc);
            }
        }

        public ReceiptBillHd GetReceiptBillHd(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReceiptBillDAL>().GetReceiptBillHd(dcc, id);
            }
        }

        public List<ReceiptBillHd> GetReceiptBillHd()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReceiptBillDAL>().GetReceiptBillHd(dcc);
            }
        }

        public List<ReceiptBillDtl> GetReceiptBillDtl(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReceiptBillDAL>().GetReceiptBillDtl(dcc, hdID);
            }
        }

        public List<VReceiptBillDtl> GetVReceiptBillDtl()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReceiptBillDAL>().GetVReceiptBillDtl(dcc);
            }
        }

        public List<VReceiptBill> GetReceiptBill()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReceiptBillDAL>().GetReceiptBill(dcc);
            }
        }

        public List<VReceiptBill> GetReceiptBill(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<ReceiptBillDAL>().GetReceiptBill(dcc, hdID);
            }
        }

        //public List<VReceiptBillDtlForPrint> GetVReceiptBillDtlForPrint()
        //{
        //    using (DCC dcc = DBMLFty.Dcc)
        //    {
        //        return DALFty.Create<ReceiptBillDAL>().GetVReceiptBillDtlForPrint(dcc);
        //    }
        //}

        public void Insert(ReceiptBillHd hd, List<ReceiptBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<ReceiptBillDAL>().Insert(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Audit(ReceiptBillHd hd, List<StockInBillHd> siHdList, List<StockOutBillHd> soHdList, List<Alert> delList)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<ReceiptBillDAL>().Audit(dcc, hd, siHdList, soHdList, delList);
                dcc.Save();
            }
        }

        public void Update(ReceiptBillHd hd, List<ReceiptBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<ReceiptBillDAL>().Update(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Update(ReceiptBillHd hd)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<ReceiptBillDAL>().Update(dcc, hd);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<ReceiptBillDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
