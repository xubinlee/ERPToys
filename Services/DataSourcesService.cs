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
    public class DataSourcesService : ServiceBase, IDataSourcesService
    {
        //[Dependency]
        //public WarehouseBLL BusinessComponent
        //{ get; set; }

        public Dictionary<Type, object> GetDataSources()
        {
            return BLLFty.Create<DataSourcesBLL>().GetDataSources();
        }
    }
}

