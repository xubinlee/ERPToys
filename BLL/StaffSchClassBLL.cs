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
    public class StaffSchClassBLL : IBLLBase
    {
        public List<StaffSchClass> GetStaffSchClass()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StaffSchClassDAL>().GetStaffSchClass(dcc);
            }
        }

        public List<VStaffSchClass> GetVStaffSchClass()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<StaffSchClassDAL>().GetVStaffSchClass(dcc);
            }
        }

        public void Insert(List<StaffSchClass> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<StaffSchClassDAL>().Insert(dcc, list);
                dcc.Save();
            }
        }

        public void Update(List<StaffSchClass> list, Guid deptID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<StaffSchClassDAL>().Update(dcc, list, deptID);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<StaffSchClassDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
