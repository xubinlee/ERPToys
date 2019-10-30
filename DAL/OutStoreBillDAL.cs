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
    public class OutStoreBillDAL:IDALBase
    {
        public string GetMaxBillNo(DCC dcc)
        {
            return dcc.OutStoreBillHd.Max(o => o.BillNo);
        }

        public OutStoreBillHd GetOutStoreBillHd(DCC dcc,Guid id)
        {
            return dcc.OutStoreBillHd.FirstOrDefault(o => o.ID == id);
        }

        public List<OutStoreBillDtl> GetOutStoreBillDtl(DCC dcc,Guid hdID)
        {
            return dcc.OutStoreBillDtl.Where(o => o.HdID == hdID).ToList();
        }

        public List<VOutStoreBill> GetOutStoreBill(DCC dcc)
        {
            return dcc.VOutStoreBill.OrderByDescending(o=>o.发货单号).ToList();
        }


        public void Insert(DCC dcc, OutStoreBillHd hd,List<OutStoreBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.OutStoreBillHd.InsertOnSubmit(hd);
                dcc.OutStoreBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, OutStoreBillHd hd, List<OutStoreBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.OutStoreBillHd.Attach(hd);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
                //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                var lstHd = dcc.OutStoreBillDtl.Where(o => o.HdID == hd.ID);
                dcc.OutStoreBillDtl.DeleteAllOnSubmit(lstHd);
                foreach (OutStoreBillDtl item in dtl)
                {
                    item.ID = Guid.NewGuid();
                    item.HdID = hd.ID;
                }
                dcc.OutStoreBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, OutStoreBillHd hd)
        {
            dcc.OutStoreBillHd.Attach(hd);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
        }

        public void Delete(DCC dcc, Guid hdID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var lstDtl = dcc.OutStoreBillHd.Where(o => o.ID == hdID);
                dcc.OutStoreBillHd.DeleteAllOnSubmit(lstDtl);
                var lstHd = dcc.OutStoreBillDtl.Where(o => o.HdID == hdID);
                dcc.OutStoreBillDtl.DeleteAllOnSubmit(lstHd);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }
    }
}
