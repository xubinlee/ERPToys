using Common;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBML;
using BLL;
using Microsoft.Practices.Unity;
using Factory;

namespace Services
{
    public class UsersInfoService : ServiceBase, IUsersInfoService
    {
        //[Dependency]
        //public WarehouseBLL BusinessComponent
        //{ get; set; }

        public List<VUsersInfo> GetLoginUsersInfo()
        {
            return BLLFty.Create<UsersInfoBLL>().GetLoginUsersInfo();
        }

        public List<UsersInfo> GetUsersInfo()
        {
            return BLLFty.Create<UsersInfoBLL>().GetUsersInfo();
        }

        public UsersInfo GetUsersInfo(string code)
        {
            return BLLFty.Create<UsersInfoBLL>().GetUsersInfo(code);
        }

        public UsersInfo GetUsersInfo(Guid id)
        {
            return BLLFty.Create<UsersInfoBLL>().GetUsersInfo(id);
        }

        public List<VUsersInfo> GetVUsersInfo()
        {
            return BLLFty.Create<UsersInfoBLL>().GetVUsersInfo();
        }

        public void Insert(UsersInfo obj, List<Permission> pList, List<ButtonPermission> btnList)
        {
            BLLFty.Create<UsersInfoBLL>().Insert(obj, pList, btnList);
        }

        public void Update(UsersInfo obj)
        {
            BLLFty.Create<UsersInfoBLL>().Update(obj);
        }

        public void Delete(Guid id)
        {
            BLLFty.Create<UsersInfoBLL>().Delete(id);
        }
    }
}
