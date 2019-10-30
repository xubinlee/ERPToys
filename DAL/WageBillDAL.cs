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
    public class WageBillDAL : IDALBase
    {
        public string GetMaxBillNo(DCC dcc)
        {
            return dcc.WageBillHd.Max(o => o.BillNo);
        }

        public WageBillHd GetWageBillHd(DCC dcc, Guid id)
        {
            return dcc.WageBillHd.FirstOrDefault(o => o.ID == id);
        }

        public List<WageBillHd> GetWageBillHd(DCC dcc)
        {
            return dcc.WageBillHd.OrderBy(o => o.BillNo).ToList();
        }

        public List<WageBillDtl> GetWageBillDtl(DCC dcc, Guid hdID)
        {
            return dcc.WageBillDtl.Where(o => o.HdID == hdID).ToList();
        }

        public List<VWageBillDtl> GetVWageBillDtl(DCC dcc)
        {
            return dcc.VWageBillDtl.ToList();
        }

        public List<VWageBill> GetWageBill(DCC dcc)
        {
            return dcc.VWageBill.OrderBy(o => o.状态).OrderByDescending(o => o.工资单号).ToList();
        }

        public void Insert(DCC dcc, WageBillHd hd, List<WageBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.WageBillHd.InsertOnSubmit(hd);
                dcc.WageBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Audit(DCC dcc, WageBillHd hd, List<Appointments> aptList, List<Alert> delList)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.WageBillHd.Attach(hd);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
                if (aptList.Count > 0)
                {
                    dcc.Appointments.AttachAll(aptList);
                    dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, aptList);
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

        public void Update(DCC dcc, WageBillHd hd, List<WageBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.WageBillHd.Attach(hd);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
                //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                var lstHd = dcc.WageBillDtl.Where(o => o.HdID == hd.ID);
                dcc.WageBillDtl.DeleteAllOnSubmit(lstHd);
                foreach (WageBillDtl item in dtl)
                {
                    item.ID = Guid.NewGuid();
                    item.HdID = hd.ID;
                }
                dcc.WageBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, WageBillHd hd)
        {
            dcc.WageBillHd.Attach(hd);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
        }

        public void Delete(DCC dcc, Guid hdID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var lstDtl = dcc.WageBillHd.Where(o => o.ID == hdID);
                dcc.WageBillHd.DeleteAllOnSubmit(lstDtl);
                var lstHd = dcc.WageBillDtl.Where(o => o.HdID == hdID);
                dcc.WageBillDtl.DeleteAllOnSubmit(lstHd);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }
    }
}
