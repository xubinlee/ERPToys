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
    public class PermissionService : ServiceBase, IPermissionService
    {
        public List<ButtonPermission> GetButtonPermission()
        {
            return BLLFty.Create<PermissionBLL>().GetButtonPermission();
        }

        public List<Permission> GetPermission()
        {
            return BLLFty.Create<PermissionBLL>().GetPermission();
        }

        public void Insert(Permission obj)
        {
            BLLFty.Create<PermissionBLL>().Insert(obj);
        }

        public void Update(Permission obj)
        {
            BLLFty.Create<PermissionBLL>().Update(obj);
        }

        public void Update(List<Permission> opList, List<ButtonPermission> btnList)
        {
            BLLFty.Create<PermissionBLL>().Update(opList, btnList);
        }
    }
}

