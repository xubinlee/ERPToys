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
    public class UsersInfoBLL : IBLLBase
    {
        public List<VUsersInfo> GetVUsersInfo()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<UsersInfoDAL>().GetVUsersInfo(dcc);
            }
        }

        public List<VUsersInfo> GetLoginUsersInfo()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<UsersInfoDAL>().GetLoginUsersInfo(dcc);
            }
        }

        public List<UsersInfo> GetUsersInfo()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<UsersInfoDAL>().GetUsersInfo(dcc);
            }
        }

        public UsersInfo GetUsersInfo(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<UsersInfoDAL>().GetUsersInfo(dcc, id);
            }
        }

        public UsersInfo GetUsersInfo(String code)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<UsersInfoDAL>().GetUsersInfo(dcc, code);
            }
        }

        public bool IsExistAttCardnumber(UsersInfo user)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<UsersInfoDAL>().IsExistAttCardnumber(dcc, user);
            }
        }

        public void Insert(UsersInfo obj, List<Permission> pList, List<ButtonPermission> btnList)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<UsersInfoDAL>().Insert(dcc, obj, pList, btnList);
                dcc.Save();
            }
        }

        public void Update(UsersInfo obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<UsersInfoDAL>().Update(dcc, obj);
                dcc.Save();
            }
        }

        public void Delete(UsersInfo obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<UsersInfoDAL>().Delete(dcc, obj);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<UsersInfoDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
