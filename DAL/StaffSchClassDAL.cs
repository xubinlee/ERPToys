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
    public class StaffSchClassDAL : IDALBase
    {
        public List<StaffSchClass> GetStaffSchClass(DCC dcc)
        {
            return dcc.StaffSchClass.ToList();
        }

        public List<VStaffSchClass> GetVStaffSchClass(DCC dcc)
        {
            return dcc.VStaffSchClass.ToList();
        }

        public void Insert(DCC dcc, List<StaffSchClass> list)
        {
            dcc.StaffSchClass.InsertAllOnSubmit(list);
            dcc.SubmitChanges();
        }

        public void Update(DCC dcc, List<StaffSchClass> list, Guid deptID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                //更新明细可能有新增记录，所以先将原有记录删除再全部添加
                var lst = dcc.StaffSchClass.Where(o => o.DeptID == deptID);
                dcc.StaffSchClass.DeleteAllOnSubmit(lst);
                //foreach (UsersInfo user in users)
                //{
                //    var lst = dcc.StaffSchClass.Where(o => o.UserID == user.ID);
                //    dcc.StaffSchClass.DeleteAllOnSubmit(lst);
                //}
                dcc.StaffSchClass.InsertAllOnSubmit(list);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Delete(DCC dcc, Guid id)
        {
            var lst = dcc.StaffSchClass.Where(o => o.ID == id);
            dcc.StaffSchClass.DeleteAllOnSubmit(lst);
            dcc.SubmitChanges();
        }
    }
}
