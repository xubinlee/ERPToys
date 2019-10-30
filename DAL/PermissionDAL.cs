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
    public class PermissionDAL : IDALBase
    {
        public List<Permission> GetPermission(DCC dcc)
        {
            return dcc.Permission.OrderBy(o => o.SerialNo).ToList();
        }

        public List<ButtonPermission> GetButtonPermission(DCC dcc)
        {
            return dcc.ButtonPermission.OrderBy(o => o.ID).ToList();
        }

        public void Update(DCC dcc, List<Permission> opList, List<ButtonPermission> btnList)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.Permission.AttachAll(opList);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, opList);
                dcc.ButtonPermission.AttachAll(btnList);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, btnList);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Insert(DCC dcc, Permission obj)
        {
            dcc.Permission.InsertOnSubmit(obj);
        }

        public void Update(DCC dcc, Permission obj)
        {
            dcc.Permission.Attach(obj);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, obj);
        }
    }
}
