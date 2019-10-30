using DBML;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL
{
    public class PaymentBillDAL : IDALBase
    {
        public string GetMaxBillNo(DCC dcc)
        {
            return dcc.PaymentBillHd.Max(o => o.BillNo);
        }

        public PaymentBillHd GetPaymentBillHd(DCC dcc, Guid id)
        {
            return dcc.PaymentBillHd.FirstOrDefault(o => o.ID == id);
        }

        public List<PaymentBillHd> GetPaymentBillHd(DCC dcc)
        {
            return dcc.PaymentBillHd.OrderBy(o=>o.BillNo).ToList();
        }

        public List<PaymentBillDtl> GetPaymentBillDtl(DCC dcc, Guid hdID)
        {
            return dcc.PaymentBillDtl.Where(o => o.HdID == hdID).ToList();
        }

        public List<VPaymentBillDtl> GetVPaymentBillDtl(DCC dcc)
        {
            return dcc.VPaymentBillDtl.OrderBy(o => o.BillNo).ToList();
            //获取ReceiptBillDtl没有的单据
            //var list = from p in dcc.VPaymentBillDtl where !dcc.PaymentBillDtl.Select(o => o.BillID).Contains(p.BillID) select p;
            //return list.OrderBy(o => o.BillNo).ToList();
        }

        public List<VPaymentBill> GetPaymentBill(DCC dcc)
        {
            return dcc.VPaymentBill.OrderBy(o => o.状态).OrderByDescending(o => o.付款单号).ToList();
        }

        public List<VPaymentBill> GetPaymentBill(DCC dcc, Guid hdID)
        {
            return dcc.VPaymentBill.Where(o => o.HdID == hdID).OrderBy(o => o.状态).OrderByDescending(o => o.付款单号).ToList();
        }

        //public List<VPaymentBillDtlForPrint> GetVPaymentBillDtlForPrint(DCC dcc)
        //{
        //    return dcc.VPaymentBillDtlForPrint.ToList();
        //}

        public void Insert(DCC dcc, PaymentBillHd hd, List<PaymentBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.PaymentBillHd.InsertOnSubmit(hd);
                dcc.PaymentBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Audit(DCC dcc, PaymentBillHd hd, List<StockInBillHd> siHdList, List<StockOutBillHd> soHdList)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.PaymentBillHd.Attach(hd);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
                if (siHdList.Count > 0)
                {
                    dcc.StockInBillHd.AttachAll(siHdList);
                    dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, siHdList);
                }
                if (soHdList.Count > 0)
                {
                    dcc.StockOutBillHd.AttachAll(soHdList);
                    dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, soHdList);
                }
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, PaymentBillHd hd, List<PaymentBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.PaymentBillHd.Attach(hd);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
                //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                var lstHd = dcc.PaymentBillDtl.Where(o => o.HdID == hd.ID);
                dcc.PaymentBillDtl.DeleteAllOnSubmit(lstHd);
                foreach (PaymentBillDtl item in dtl)
                {
                    item.ID = Guid.NewGuid();
                    item.HdID = hd.ID;
                }
                dcc.PaymentBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, PaymentBillHd hd)
        {
            dcc.PaymentBillHd.Attach(hd);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
        }

        public void Delete(DCC dcc, Guid hdID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var lstDtl = dcc.PaymentBillHd.Where(o => o.ID == hdID);
                dcc.PaymentBillHd.DeleteAllOnSubmit(lstDtl);
                var lstHd = dcc.PaymentBillDtl.Where(o => o.HdID == hdID);
                dcc.PaymentBillDtl.DeleteAllOnSubmit(lstHd);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }
    }
}
