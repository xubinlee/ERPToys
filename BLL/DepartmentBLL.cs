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
    public class DepartmentBLL : IBLLBase
    {
        public List<VDepartment> GetVDepartment()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<DepartmentDAL>().GetVDepartment(dcc);
            }
        }

        public List<Department> GetDepartment()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<DepartmentDAL>().GetDepartment(dcc);
            }
        }

        public Department GetDepartment(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<DepartmentDAL>().GetDepartment(dcc, id);
            }
        }

        public void Insert(Department obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<DepartmentDAL>().Insert(dcc, obj);
                dcc.Save();
            }
        }

        public void Update(Department obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<DepartmentDAL>().Update(dcc, obj);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<DepartmentDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
