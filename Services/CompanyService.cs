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
    public class CompanyService : ServiceBase, ICompanyService
    {
        //[Dependency]
        //public WarehouseBLL BusinessComponent
        //{ get; set; }

        public List<Company> GetCompany()
        {
            return BLLFty.Create<CompanyBLL>().GetCompany();
        }

        public Company GetCompany(Guid id)
        {
            return BLLFty.Create<CompanyBLL>().GetCompany(id);
        }

        public List<VCompany> GetVCompany()
        {
            return BLLFty.Create<CompanyBLL>().GetVCompany();
        }

        public void Insert(Company obj)
        {
            BLLFty.Create<CompanyBLL>().Insert(obj);
        }

        public void Update(Company obj)
        {
            BLLFty.Create<CompanyBLL>().Update(obj);
        }

        public void Delete(Guid id)
        {
            BLLFty.Create<CompanyBLL>().Delete(id);
        }
    }
}

