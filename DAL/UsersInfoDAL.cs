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
    public class UsersInfoDAL : IDALBase
    {
        public List<VUsersInfo> GetVUsersInfo(DCC dcc)
        {
            return dcc.VUsersInfo.ToList();
        }

        public List<VUsersInfo> GetLoginUsersInfo(DCC dcc)
        {
            return dcc.VUsersInfo.Where(o => o.Password != null && o.Password != "").ToList();
        }

        public List<UsersInfo> GetUsersInfo(DCC dcc)
        {
            return dcc.UsersInfo.ToList();
        }

        public UsersInfo GetUsersInfo(DCC dcc,Guid id)
        {
            return dcc.UsersInfo.FirstOrDefault(o => o.ID == id);
        }

        public UsersInfo GetUsersInfo(DCC dcc,String code)
        {
            return dcc.UsersInfo.FirstOrDefault(o => o.Code == code);
        }

        public bool IsExistAttCardnumber(DCC dcc, UsersInfo user)
        {
            return dcc.UsersInfo.Where(o => o.ID != user.ID && o.AttCardnumber == user.AttCardnumber && o.AttCardnumber != "" && o.IsDel==false).Count() > 0;
        }

        public void Insert(DCC dcc, UsersInfo obj, List<Permission> pList, List<ButtonPermission> btnList)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.UsersInfo.InsertOnSubmit(obj);
                if (pList.Count > 0)
                    dcc.Permission.InsertAllOnSubmit(pList);
                if (btnList.Count > 0)
                    dcc.ButtonPermission.InsertAllOnSubmit(btnList);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, UsersInfo obj)
        {
            dcc.UsersInfo.Attach(obj);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, obj);
        }

        public void Delete(DCC dcc, UsersInfo obj)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.UsersInfo.Attach(obj);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, obj);
                var pList = dcc.Permission.Where(o => o.UserID == obj.ID);
                    dcc.Permission.DeleteAllOnSubmit(pList);
                var btnPList = dcc.ButtonPermission.Where(o => o.UserID == obj.ID);
                    dcc.ButtonPermission.DeleteAllOnSubmit(btnPList);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Delete(DCC dcc, Guid id)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var lst = dcc.UsersInfo.Where(o => o.ID == id);
                dcc.UsersInfo.DeleteAllOnSubmit(lst);
                var pList = dcc.Permission.Where(o => o.UserID == id);
                dcc.Permission.DeleteAllOnSubmit(pList);
                var btnPList = dcc.ButtonPermission.Where(o => o.UserID == id);
                dcc.ButtonPermission.DeleteAllOnSubmit(btnPList);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }
    }
}
