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
    public class ReceiptBillService : ServiceBase, IReceiptBillService
    {
        public string GetMaxBillNo()
        {
            return BLLFty.Create<ReceiptBillBLL>().GetMaxBillNo();
        }

        public List<VReceiptBill> GetReceiptBill()
        {
            return BLLFty.Create<ReceiptBillBLL>().GetReceiptBill();
        }

        public List<VReceiptBill> GetReceiptBill(Guid hdID)
        {
            return BLLFty.Create<ReceiptBillBLL>().GetReceiptBill(hdID);
        }

        public List<ReceiptBillDtl> GetReceiptBillDtl(Guid hdID)
        {
            return BLLFty.Create<ReceiptBillBLL>().GetReceiptBillDtl(hdID);
        }

        public List<ReceiptBillHd> GetReceiptBillHd()
        {
            return BLLFty.Create<ReceiptBillBLL>().GetReceiptBillHd();
        }

        public ReceiptBillHd GetReceiptBillHd(Guid id)
        {
            return BLLFty.Create<ReceiptBillBLL>().GetReceiptBillHd(id);
        }

        public List<VReceiptBillDtl> GetVReceiptBillDtl()
        {
            return BLLFty.Create<ReceiptBillBLL>().GetVReceiptBillDtl();
        }

        public void Insert(ReceiptBillHd hd, List<ReceiptBillDtl> dtl)
        {
            BLLFty.Create<ReceiptBillBLL>().Insert(hd, dtl);
        }

        public void Update(ReceiptBillHd hd)
        {
            BLLFty.Create<ReceiptBillBLL>().Update(hd);
        }

        public void Update(ReceiptBillHd hd, List<ReceiptBillDtl> dtl)
        {
            BLLFty.Create<ReceiptBillBLL>().Update(hd, dtl);
        }

        public void Audit(ReceiptBillHd hd, List<StockInBillHd> siHdList, List<StockOutBillHd> soHdList, List<Alert> delList)
        {
            BLLFty.Create<ReceiptBillBLL>().Audit(hd, siHdList, soHdList, delList);
        }

        public void Delete(Guid id)
        {
            BLLFty.Create<ReceiptBillBLL>().Delete(id);
        }

    }
}

