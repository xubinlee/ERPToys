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
    public class SystemInfoService : ServiceBase, ISystemInfoService
    {
        public List<SystemInfo> GetSystemInfo()
        {
            return BLLFty.Create<SystemInfoBLL>().GetSystemInfo();
        }

        public List<SystemStatus> GetSystemStatus()
        {
            return BLLFty.Create<SystemInfoBLL>().GetSystemStatus();
        }

        public void Insert(SystemStatus obj)
        {
            BLLFty.Create<SystemInfoBLL>().Insert(obj);
        }

        public void Update(SystemStatus obj)
        {
            BLLFty.Create<SystemInfoBLL>().Update(obj);
        }
    }
}

