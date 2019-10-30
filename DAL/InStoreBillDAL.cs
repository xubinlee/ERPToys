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
    public class InStoreBillDAL:IDALBase
    {
        public string GetMaxBillNo(DCC dcc)
        {
            return dcc.InStoreBillHd.Max(o => o.BillNo);
        }

        public InStoreBillHd GetInStoreBillHd(DCC dcc,Guid id)
        {
            return dcc.InStoreBillHd.FirstOrDefault(o => o.ID == id);
        }

        public List<InStoreBillDtl> GetInStoreBillDtl(DCC dcc,Guid hdID)
        {
            return dcc.InStoreBillDtl.Where(o => o.HdID == hdID).ToList();
        }

        public List<VInStoreBill> GetInStoreBill(DCC dcc)
        {
            return dcc.VInStoreBill.OrderByDescending(o=>o.入库单号).ToList();
        }


        public void Insert(DCC dcc, InStoreBillHd hd,List<InStoreBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.InStoreBillHd.InsertOnSubmit(hd);
                dcc.InStoreBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, InStoreBillHd hd, List<InStoreBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.InStoreBillHd.Attach(hd);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
                //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                var lstHd = dcc.InStoreBillDtl.Where(o => o.HdID == hd.ID);
                dcc.InStoreBillDtl.DeleteAllOnSubmit(lstHd);
                foreach (InStoreBillDtl item in dtl)
                {
                    item.ID = Guid.NewGuid();
                    item.HdID = hd.ID;
                }
                dcc.InStoreBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, InStoreBillHd hd)
        {
            dcc.InStoreBillHd.Attach(hd);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
        }

        public void Delete(DCC dcc, Guid hdID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var lstDtl = dcc.InStoreBillHd.Where(o => o.ID == hdID);
                dcc.InStoreBillHd.DeleteAllOnSubmit(lstDtl);
                var lstHd = dcc.InStoreBillDtl.Where(o => o.HdID == hdID);
                dcc.InStoreBillDtl.DeleteAllOnSubmit(lstHd);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }
    }
}
