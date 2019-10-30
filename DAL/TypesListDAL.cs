using DBML;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TypesListDAL:IDALBase
    {
        public List<TypesList> GetTypesList(DCC dcc)
        {
            return dcc.TypesList.ToList();
        }
    }
}
