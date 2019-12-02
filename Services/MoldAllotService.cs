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
    public class MoldAllotService : ServiceBase, IMoldAllotService
    {
        public List<MoldAllot> GetMoldAllot()
        {
            return BLLFty.Create<MoldAllotBLL>().GetMoldAllot();
        }

        public List<MoldAllot> GetMoldAllot(Guid supplierID)
        {
            return BLLFty.Create<MoldAllotBLL>().GetMoldAllot(supplierID);
        }

        public void Insert(List<MoldAllot> list)
        {
            BLLFty.Create<MoldAllotBLL>().Insert(list);
        }

        public void Update(Guid parentGoodsID, List<MoldAllot> list)
        {
            BLLFty.Create<MoldAllotBLL>().Update(parentGoodsID, list);
        }

        public void Delete(Guid parentGoodsID)
        {
            BLLFty.Create<MoldAllotBLL>().Delete(parentGoodsID);
        }
    }
}

