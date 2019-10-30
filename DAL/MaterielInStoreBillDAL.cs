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
    public class MaterielInStoreBillDAL : IDALBase
    {
        public string GetMaxBillNo(DCC dcc)
        {
            return dcc.MaterielInStoreBillHd.Max(o => o.BillNo);
        }

        public MaterielInStoreBillHd GetMaterielInStoreBillHd(DCC dcc, Guid id)
        {
            return dcc.MaterielInStoreBillHd.FirstOrDefault(o => o.ID == id);
        }

        public List<MaterielInStoreBillDtl> GetMaterielInStoreBillDtl(DCC dcc, Guid hdID)
        {
            return dcc.MaterielInStoreBillDtl.Where(o => o.HdID == hdID).ToList();
        }

        public List<VMaterielInStoreBill> GetMaterielInStoreBill(DCC dcc)
        {
            return dcc.VMaterielInStoreBill.OrderByDescending(o => o.入库单号).ToList();
        }


        public void Insert(DCC dcc, MaterielInStoreBillHd hd, List<MaterielInStoreBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.MaterielInStoreBillHd.InsertOnSubmit(hd);
                dcc.MaterielInStoreBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, MaterielInStoreBillHd hd, List<MaterielInStoreBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.MaterielInStoreBillHd.Attach(hd);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
                //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                var lstHd = dcc.MaterielInStoreBillDtl.Where(o => o.HdID == hd.ID);
                dcc.MaterielInStoreBillDtl.DeleteAllOnSubmit(lstHd);
                foreach (MaterielInStoreBillDtl item in dtl)
                {
                    item.ID = Guid.NewGuid();
                    item.HdID = hd.ID;
                }
                dcc.MaterielInStoreBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Delete(DCC dcc, Guid hdID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var lstDtl = dcc.MaterielInStoreBillHd.Where(o => o.ID == hdID);
                dcc.MaterielInStoreBillHd.DeleteAllOnSubmit(lstDtl);
                var lstHd = dcc.MaterielInStoreBillDtl.Where(o => o.HdID == hdID);
                dcc.MaterielInStoreBillDtl.DeleteAllOnSubmit(lstHd);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }
    }
}
