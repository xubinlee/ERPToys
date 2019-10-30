using DBML;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CompanyDAL : IDALBase
    {
        public List<VCompany> GetVCompany(DCC dcc)
        {
            return dcc.VCompany.OrderBy(o => o.代码).ToList();
        }

        public List<Company> GetCompany(DCC dcc)
        {
            return dcc.Company.OrderBy(o => o.Code).ToList();
        }

        public Company GetCompany(DCC dcc,Guid id)
        {
            return dcc.Company.FirstOrDefault(o => o.ID == id);
        }

        public void Insert(DCC dcc, Company obj)
        {
            dcc.Company.InsertOnSubmit(obj);
        }

        public void Update(DCC dcc, Company obj)
        {
            obj.UpdateTime = DateTime.Now;
            dcc.Company.Attach(obj);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, obj);
        }

        public void Delete(DCC dcc, Guid id)
        {
            var lst = dcc.Company.Where(o => o.ID == id);
            dcc.Company.DeleteAllOnSubmit(lst);
        }
    }
}
