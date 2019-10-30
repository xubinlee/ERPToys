using DBML;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SupplierDAL : IDALBase
    {
        public List<VSupplier> GetVSupplier(DCC dcc)
        {
            return dcc.VSupplier.OrderBy(o => o.代码).ToList();
        }

        public List<Supplier> GetSupplier(DCC dcc)
        {
            return dcc.Supplier.OrderBy(o => o.Code).ToList();
        }

        public Supplier GetSupplier(DCC dcc, Guid id)
        {
            return dcc.Supplier.FirstOrDefault(o => o.ID == id);
        }

        public void Insert(DCC dcc, Supplier obj)
        {
            dcc.Supplier.InsertOnSubmit(obj);
        }

        public void Update(DCC dcc, Supplier obj)
        {
            obj.UpdateTime = DateTime.Now;
            dcc.Supplier.Attach(obj);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, obj);
        }

        public void Delete(DCC dcc, Guid id)
        {
            var lst = dcc.Supplier.Where(o => o.ID == id);
            dcc.Supplier.DeleteAllOnSubmit(lst);
        }
    }
}
