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
    public class DepartmentService : ServiceBase, IDepartmentService
    {
        //[Dependency]
        //public WarehouseBLL BusinessComponent
        //{ get; set; }

        public List<Department> GetDepartment()
        {
            return BLLFty.Create<DepartmentBLL>().GetDepartment();
        }

        public Department GetDepartment(Guid id)
        {
            return BLLFty.Create<DepartmentBLL>().GetDepartment(id);
        }

        public List<VDepartment> GetVDepartment()
        {
            return BLLFty.Create<DepartmentBLL>().GetVDepartment();
        }

        public void Insert(Department obj)
        {
            BLLFty.Create<DepartmentBLL>().Insert(obj);
        }

        public void Update(Department obj)
        {
            BLLFty.Create<DepartmentBLL>().Update(obj);
        }

        public void Delete(Guid id)
        {
            BLLFty.Create<DepartmentBLL>().Delete(id);
        }
    }
}

