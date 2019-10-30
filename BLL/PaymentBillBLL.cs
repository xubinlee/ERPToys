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
    public class PaymentBillBLL : IBLLBase
    {
        public string GetMaxBillNo()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<PaymentBillDAL>().GetMaxBillNo(dcc);
            }
        }

        public PaymentBillHd GetPaymentBillHd(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<PaymentBillDAL>().GetPaymentBillHd(dcc, id);
            }
        }

        public List<PaymentBillHd> GetPaymentBillHd()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<PaymentBillDAL>().GetPaymentBillHd(dcc);
            }
        }

        public List<PaymentBillDtl> GetPaymentBillDtl(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<PaymentBillDAL>().GetPaymentBillDtl(dcc, hdID);
            }
        }

        public List<VPaymentBillDtl> GetVPaymentBillDtl()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<PaymentBillDAL>().GetVPaymentBillDtl(dcc);
            }
        }

        public List<VPaymentBill> GetPaymentBill()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<PaymentBillDAL>().GetPaymentBill(dcc);
            }
        }

        public List<VPaymentBill> GetPaymentBill(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<PaymentBillDAL>().GetPaymentBill(dcc, hdID);
            }
        }

        //public List<VPaymentBillDtlForPrint> GetVPaymentBillDtlForPrint()
        //{
        //    using (DCC dcc = DBMLFty.Dcc)
        //    {
        //        return DALFty.Create<PaymentBillDAL>().GetVPaymentBillDtlForPrint(dcc);
        //    }
        //}

        public void Insert(PaymentBillHd hd, List<PaymentBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<PaymentBillDAL>().Insert(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Audit(PaymentBillHd hd, List<StockInBillHd> siHdList, List<StockOutBillHd> soHdList)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<PaymentBillDAL>().Audit(dcc, hd, siHdList, soHdList);
                dcc.Save();
            }
        }

        public void Update(PaymentBillHd hd, List<PaymentBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<PaymentBillDAL>().Update(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Update(PaymentBillHd hd)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<PaymentBillDAL>().Update(dcc, hd);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<PaymentBillDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
