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
    public class ReceiptBillDAL : IDALBase
    {
        public string GetMaxBillNo(DCC dcc)
        {
            return dcc.ReceiptBillHd.Max(o => o.BillNo);
        }

        public ReceiptBillHd GetReceiptBillHd(DCC dcc, Guid id)
        {
            return dcc.ReceiptBillHd.FirstOrDefault(o => o.ID == id);
        }

        public List<ReceiptBillHd> GetReceiptBillHd(DCC dcc)
        {
            return dcc.ReceiptBillHd.OrderBy(o => o.BillNo).ToList();
        }

        public List<ReceiptBillDtl> GetReceiptBillDtl(DCC dcc, Guid hdID)
        {
            return dcc.ReceiptBillDtl.Where(o => o.HdID == hdID).ToList();
        }

        public List<VReceiptBillDtl> GetVReceiptBillDtl(DCC dcc)
        {
            return dcc.VReceiptBillDtl.OrderBy(o => o.BillNo).ToList();
            //获取ReceiptBillDtl没有的单据
            //var list = from r in dcc.VReceiptBillDtl where !dcc.ReceiptBillDtl.Select(o => o.BillID).Contains(r.BillID) select r;
            //return list.OrderBy(o => o.BillNo).ToList();
        }

        public List<VReceiptBill> GetReceiptBill(DCC dcc)
        {
            return dcc.VReceiptBill.OrderBy(o => o.状态).OrderByDescending(o => o.收款单号).ToList();
        }

        public List<VReceiptBill> GetReceiptBill(DCC dcc, Guid hdID)
        {
            return dcc.VReceiptBill.Where(o => o.HdID == hdID).OrderBy(o => o.状态).OrderByDescending(o => o.收款单号).ToList();
        }

        //public List<VReceiptBillDtlForPrint> GetVReceiptBillDtlForPrint(DCC dcc)
        //{
        //    return dcc.VReceiptBillDtlForPrint.ToList();
        //}

        public void Insert(DCC dcc, ReceiptBillHd hd, List<ReceiptBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.ReceiptBillHd.InsertOnSubmit(hd);
                dcc.ReceiptBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Audit(DCC dcc, ReceiptBillHd hd, List<StockInBillHd> siHdList, List<StockOutBillHd> soHdList, List<Alert> delList)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.ReceiptBillHd.Attach(hd);
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
                if (delList.Count > 0)
                {
                    dcc.Alert.AttachAll(delList);//附加实体---增加此段代码即可解决“无法删除尚未附加的实体”问题 
                    dcc.Alert.DeleteAllOnSubmit(delList);
                }
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, ReceiptBillHd hd, List<ReceiptBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.ReceiptBillHd.Attach(hd);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
                //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                var lstHd = dcc.ReceiptBillDtl.Where(o => o.HdID == hd.ID);
                dcc.ReceiptBillDtl.DeleteAllOnSubmit(lstHd);
                foreach (ReceiptBillDtl item in dtl)
                {
                    item.ID = Guid.NewGuid();
                    item.HdID = hd.ID;
                }
                dcc.ReceiptBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, ReceiptBillHd hd)
        {
            dcc.ReceiptBillHd.Attach(hd);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
        }

        public void Delete(DCC dcc, Guid hdID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var lstDtl = dcc.ReceiptBillHd.Where(o => o.ID == hdID);
                dcc.ReceiptBillHd.DeleteAllOnSubmit(lstDtl);
                var lstHd = dcc.ReceiptBillDtl.Where(o => o.HdID == hdID);
                dcc.ReceiptBillDtl.DeleteAllOnSubmit(lstHd);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }
    }
}
