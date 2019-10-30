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
    public class WarehouseBLL : IBLLBase
    {
        public List<Warehouse> GetWarehouse()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<WarehouseDAL>().GetWarehouse(dcc);
            }
        }
    }
}
