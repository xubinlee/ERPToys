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
    public class PackagingService : ServiceBase, IPackagingService
    {
        public List<Packaging> GetPackaging()
        {
            return BLLFty.Create<PackagingBLL>().GetPackaging();
        }

        public Packaging GetPackaging(Guid id)
        {
            return BLLFty.Create<PackagingBLL>().GetPackaging(id);
        }

        public List<VPackaging> GetVPackaging()
        {
            return BLLFty.Create<PackagingBLL>().GetVPackaging();
        }

        public void Insert(Packaging obj)
        {
            BLLFty.Create<PackagingBLL>().Insert(obj);
        }

        public void Update(Packaging obj)
        {
            BLLFty.Create<PackagingBLL>().Update(obj);
        }

        public void Delete(Guid id)
        {
            BLLFty.Create<PackagingBLL>().Delete(id);
        }

    }
}

