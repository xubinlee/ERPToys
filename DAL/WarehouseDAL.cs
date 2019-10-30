using DBML;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class WarehouseDAL : IDALBase
    {
        public List<Warehouse> GetWarehouse(DCC dcc)
        {
            return dcc.Warehouse.ToList();
        }
    }
}
