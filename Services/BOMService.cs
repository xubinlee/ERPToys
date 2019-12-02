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
    public class BOMService : ServiceBase, IBOMService
    {
        //[Dependency]
        //public WarehouseBLL BusinessComponent
        //{ get; set; }

        public List<BOM> GetBOM()
        {
            return BLLFty.Create<BOMBLL>().GetBOM();
        }

        public List<BOM> GetBOM(Guid parentGoodsID)
        {
            return BLLFty.Create<BOMBLL>().GetBOM(parentGoodsID);
        }

        public void Insert(List<BOM> list)
        {
            BLLFty.Create<BOMBLL>().Insert(list);
        }

        public void Update(int bomType, Guid parentGoodsID, List<BOM> list)
        {
            BLLFty.Create<BOMBLL>().Update(bomType, parentGoodsID, list);
        }

        public void Delete(Guid parentGoodsID)
        {
            BLLFty.Create<BOMBLL>().Delete(parentGoodsID);
        }
    }
}

