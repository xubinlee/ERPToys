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
    public class CompanyBLL : IBLLBase
    {
        public List<VCompany> GetVCompany()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<CompanyDAL>().GetVCompany(dcc);
            }
        }

        public List<Company> GetCompany()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<CompanyDAL>().GetCompany(dcc);
            }
        }

        public Company GetCompany(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<CompanyDAL>().GetCompany(dcc, id);
            }
        }

        public void Insert(Company obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<CompanyDAL>().Insert(dcc, obj);
                dcc.Save();
            }
        }

        public void Update(Company obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<CompanyDAL>().Update(dcc, obj);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<CompanyDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
