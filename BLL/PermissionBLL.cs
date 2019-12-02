using DAL;
using DBML;
using Factory;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PermissionBLL : IBLLBase
    {
        public List<Permission> GetPermission()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<PermissionDAL>().GetPermission(dcc);
            }
        }

        public List<ButtonPermission> GetButtonPermission()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<PermissionDAL>().GetButtonPermission(dcc);
            }
        }

        public void Update(List<Permission> opList, List<ButtonPermission> btnList)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<PermissionDAL>().Update(dcc, opList, btnList);
                dcc.Save();
            }
        }

        public void Insert(Permission obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<PermissionDAL>().Insert(dcc, obj);
                dcc.Save();
            }
        }

        public void Update(Permission obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<PermissionDAL>().Update(dcc, obj);
                dcc.Save();
            }
        }

        public void Update(Guid userID, List<Permission> insertList)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<PermissionDAL>().Update(dcc, userID, insertList);
                dcc.Save();
            }
        }

    }
}
