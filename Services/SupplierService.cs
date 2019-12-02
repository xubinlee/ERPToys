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
    public class SupplierService : ServiceBase, ISupplierService
    {
        public List<Supplier> GetSupplier()
        {
            return BLLFty.Create<SupplierBLL>().GetSupplier();
        }

        public Supplier GetSupplier(Guid id)
        {
            return BLLFty.Create<SupplierBLL>().GetSupplier(id);
        }

        public List<VSupplier> GetVSupplier()
        {
            return BLLFty.Create<SupplierBLL>().GetVSupplier();
        }

        public void Insert(Supplier obj)
        {
            BLLFty.Create<SupplierBLL>().Insert(obj);
        }

        public void Update(Supplier obj)
        {
            BLLFty.Create<SupplierBLL>().Update(obj);
        }

        public void Delete(Guid id)
        {
            BLLFty.Create<SupplierBLL>().Delete(id);
        }

    }
}

