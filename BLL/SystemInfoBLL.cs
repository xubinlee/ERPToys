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
    public class SystemInfoBLL : IBLLBase
    {
        public List<SystemInfo> GetSystemInfo()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<SystemInfoDAL>().GetSystemInfo(dcc);
            }
        }

        public List<SystemStatus> GetSystemStatus()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<SystemInfoDAL>().GetSystemStatus(dcc);
            }
        }

        public void Insert(SystemStatus obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<SystemInfoDAL>().Insert(dcc, obj);
                dcc.Save();
            }
        }

        public void Update(SystemStatus obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<SystemInfoDAL>().Update(dcc, obj);
                dcc.Save();
            }
        }
    }
}
