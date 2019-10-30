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
    public class MoldAllotDAL : IDALBase
    {
        public List<MoldAllot> GetMoldAllot(DCC dcc, Guid supplierID)
        {
            return dcc.MoldAllot.Where(o => o.SupplierID == supplierID).ToList();
        }

        public List<MoldAllot> GetMoldAllot(DCC dcc)
        {
            return dcc.MoldAllot.ToList();
        }


        public void Insert(DCC dcc, List<MoldAllot> list)
        {
            dcc.MoldAllot.InsertAllOnSubmit(list);
            dcc.SubmitChanges();
        }

        public void Update(DCC dcc, Guid supplierID, List<MoldAllot> list)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                var lst = dcc.MoldAllot.Where(o => o.SupplierID == supplierID);
                dcc.MoldAllot.DeleteAllOnSubmit(lst);
                dcc.MoldAllot.InsertAllOnSubmit(list);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Delete(DCC dcc, Guid supplierID)
        {
            var lst = dcc.MoldAllot.Where(o => o.SupplierID == supplierID);
            dcc.MoldAllot.DeleteAllOnSubmit(lst);
            dcc.SubmitChanges();
        }
    }
}
