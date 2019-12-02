using EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class EDMXFty
    {
        public static ErpContext Dc
        {
            get
            {
                ErpContext db = new ErpContext();// new DbContext(ConfigInfo.SqlConStr);                
                return db;
            }
        }
    }
}
