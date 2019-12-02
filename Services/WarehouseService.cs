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
    public class WarehouseService : ServiceBase, IWarehouseService
    {
        //[Dependency]
        //public WarehouseBLL BusinessComponent
        //{ get; set; }

        public List<Warehouse> GetWarehouse()
        {
            //return new List<Warehouse>();
            //return this.BusinessComponent.GetWarehouse();
            return BLLFty.Create<WarehouseBLL>().GetWarehouse();
        }
    }
}

