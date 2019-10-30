using DBML;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PackagingDAL : IDALBase
    {
        public List<VPackaging> GetVPackaging(DCC dcc)
        {
            return dcc.VPackaging.ToList();
        }

        public List<Packaging> GetPackaging(DCC dcc)
        {
            return dcc.Packaging.ToList();
        }

        public Packaging GetPackaging(DCC dcc,Guid id)
        {
            return dcc.Packaging.FirstOrDefault(o => o.ID == id);
        }

        public void Insert(DCC dcc, Packaging obj)
        {
            dcc.Packaging.InsertOnSubmit(obj);
        }

        public void Update(DCC dcc, Packaging obj)
        {
            dcc.Packaging.Attach(obj);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, obj);
        }

        public void Delete(DCC dcc, Guid id)
        {
            var lst = dcc.Packaging.Where(o => o.ID == id);
            dcc.Packaging.DeleteAllOnSubmit(lst);
        }
    }
}
