using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBML;

namespace Factory
{
    public class DBMLFty
    {
        public static DCC Dcc
        {
            get
            {
                DCC obj = new DCC(ConfigInfo.SqlConStr);
                obj.DeferredLoadingEnabled = false;
                return obj;
            }
        }
    }
}
