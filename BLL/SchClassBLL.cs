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
    public class SchClassBLL : IBLLBase
    {
        public List<SchClass> GetSchClass()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<SchClassDAL>().GetSchClass(dcc);
            }
        }

        public void Insert(List<SchClass> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<SchClassDAL>().Insert(dcc, list);
                dcc.Save();
            }
        }

        public void Update(List<SchClass> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<SchClassDAL>().Update(dcc, list);
                dcc.Save();
            }
        }

        public void Delete(string name)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<SchClassDAL>().Delete(dcc, name);
                dcc.Save();
            }
        }
    }
}
