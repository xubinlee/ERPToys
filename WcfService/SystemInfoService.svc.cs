using DAL;
using EDMX;
using Factory;
using IWcfServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    public class SystemInfoService : ISystemInfoService
    {
        public int AddOrUpdate(SystemStatus entity)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                return DALFty.Create<BaseDAL>().AddOrUpdate(db, entity);
            }
        }
    }
}
