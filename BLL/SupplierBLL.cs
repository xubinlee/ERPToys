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
    public class SupplierBLL : IBLLBase
    {
        public List<VSupplier> GetVSupplier()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<SupplierDAL>().GetVSupplier(dcc);
            }
        }

        public List<Supplier> GetSupplier()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<SupplierDAL>().GetSupplier(dcc);
            }
        }

        public Supplier GetSupplier(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<SupplierDAL>().GetSupplier(dcc, id);
            }
        }

        public void Insert(Supplier obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<SupplierDAL>().Insert(dcc, obj);
                dcc.Save();
            }
        }

        public void Update(Supplier obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<SupplierDAL>().Update(dcc, obj);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<SupplierDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
