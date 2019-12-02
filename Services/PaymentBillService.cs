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
    public class PaymentBillService : ServiceBase, IPaymentBillService
    {
        public string GetMaxBillNo()
        {
            return BLLFty.Create<PaymentBillBLL>().GetMaxBillNo();
        }

        public List<VPaymentBill> GetPaymentBill()
        {
            return BLLFty.Create<PaymentBillBLL>().GetPaymentBill();
        }

        public List<VPaymentBill> GetPaymentBill(Guid hdID)
        {
            return BLLFty.Create<PaymentBillBLL>().GetPaymentBill(hdID);
        }

        public List<PaymentBillDtl> GetPaymentBillDtl(Guid hdID)
        {
            return BLLFty.Create<PaymentBillBLL>().GetPaymentBillDtl(hdID);
        }

        public List<PaymentBillHd> GetPaymentBillHd()
        {
            return BLLFty.Create<PaymentBillBLL>().GetPaymentBillHd();
        }

        public PaymentBillHd GetPaymentBillHd(Guid id)
        {
            return BLLFty.Create<PaymentBillBLL>().GetPaymentBillHd(id);
        }

        public List<VPaymentBillDtl> GetVPaymentBillDtl()
        {
            return BLLFty.Create<PaymentBillBLL>().GetVPaymentBillDtl();
        }

        public void Insert(PaymentBillHd hd, List<PaymentBillDtl> dtl)
        {
            BLLFty.Create<PaymentBillBLL>().Insert(hd, dtl);
        }

        public void Update(PaymentBillHd hd)
        {
            BLLFty.Create<PaymentBillBLL>().Update(hd);
        }

        public void Update(PaymentBillHd hd, List<PaymentBillDtl> dtl)
        {
            BLLFty.Create<PaymentBillBLL>().Update(hd, dtl);
        }

        public void Audit(PaymentBillHd hd, List<StockInBillHd> siHdList, List<StockOutBillHd> soHdList)
        {
            BLLFty.Create<PaymentBillBLL>().Audit(hd, siHdList, soHdList);
        }

        public void Delete(Guid id)
        {
            BLLFty.Create<PaymentBillBLL>().Delete(id);
        }

    }
}

