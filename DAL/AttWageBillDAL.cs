using DBML;
using IBase;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL
{
    public class AttWageBillDAL : IDALBase
    {
        public string GetMaxBillNo(DCC dcc)
        {
            return dcc.AttWageBillHd.Max(o => o.BillNo);
        }

        public AttWageBillHd GetAttWageBillHd(DCC dcc, Guid id)
        {
            return dcc.AttWageBillHd.FirstOrDefault(o => o.ID == id);
        }

        public List<AttWageBillHd> GetAttWageBillHd(DCC dcc)
        {
            return dcc.AttWageBillHd.OrderBy(o => o.BillNo).ToList();
        }

        public List<AttWageBillDtl> GetAttWageBillDtl(DCC dcc, Guid hdID)
        {
            return dcc.AttWageBillDtl.Where(o => o.HdID == hdID).ToList();
        }

        public List<USPAttWageBillDtl> GetUSPAttWageBillDtl(DCC dcc)
        {
            ISingleResult<USPAttWageBillDtl> result = dcc.USPGetAttWageBillDtl();
            return result.ToList();
        }

        public List<VAttWageBill> GetAttWageBill(DCC dcc)
        {
            return dcc.VAttWageBill.OrderBy(o => o.状态).OrderByDescending(o => o.工资单号).ToList();
        }

        public void Insert(DCC dcc, AttWageBillHd hd, List<AttWageBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.AttWageBillHd.InsertOnSubmit(hd);
                dcc.AttWageBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Audit(DCC dcc, AttWageBillHd hd, List<AttAppointments> aptList, List<AttGeneralLog> logList, List<Alert> delList)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.AttWageBillHd.Attach(hd);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
                if (aptList.Count > 0)
                {
                    dcc.AttAppointments.AttachAll(aptList);
                    dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, aptList);
                }
                if (logList.Count > 0)
                {
                    dcc.AttGeneralLog.AttachAll(logList);//附加实体---增加此段代码即可解决“无法删除尚未附加的实体”问题 
                    dcc.AttGeneralLog.DeleteAllOnSubmit(logList);
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

        public void Update(DCC dcc, AttWageBillHd hd, List<AttWageBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.AttWageBillHd.Attach(hd);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
                //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                var lstHd = dcc.AttWageBillDtl.Where(o => o.HdID == hd.ID);
                dcc.AttWageBillDtl.DeleteAllOnSubmit(lstHd);
                foreach (AttWageBillDtl item in dtl)
                {
                    item.ID = Guid.NewGuid();
                    item.HdID = hd.ID;
                }
                dcc.AttWageBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, AttWageBillHd hd)
        {
            dcc.AttWageBillHd.Attach(hd);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
        }

        public void Delete(DCC dcc, Guid hdID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var lstDtl = dcc.AttWageBillHd.Where(o => o.ID == hdID);
                dcc.AttWageBillHd.DeleteAllOnSubmit(lstDtl);
                var lstHd = dcc.AttWageBillDtl.Where(o => o.HdID == hdID);
                dcc.AttWageBillDtl.DeleteAllOnSubmit(lstHd);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }
    }
}
