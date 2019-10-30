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
    public class DataSourcesBLL : IBLLBase
    {
        public Dictionary<Type, object> GetDataSources()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<DataSourcesDAL>().GetDataSources(dcc);
            }
        }
        public Dictionary<Type, object> GetVDataSources()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<DataSourcesDAL>().GetVDataSources(dcc);
            }
        }
    }

}
