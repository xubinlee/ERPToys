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
    public class MoldAllotBLL : IBLLBase
    {
        public List<MoldAllot> GetMoldAllot(Guid supplierID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<MoldAllotDAL>().GetMoldAllot(dcc, supplierID);
            }
        }

        public List<MoldAllot> GetMoldAllot()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<MoldAllotDAL>().GetMoldAllot(dcc);
            }
        }

        public void Insert(List<MoldAllot> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<MoldAllotDAL>().Insert(dcc, list);
                dcc.Save();
            }
        }

        public void Update(Guid parentGoodsID, List<MoldAllot> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<MoldAllotDAL>().Update(dcc, parentGoodsID, list);
                dcc.Save();
            }
        }

        public void Delete(Guid parentGoodsID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<MoldAllotDAL>().Delete(dcc, parentGoodsID);
                dcc.Save();
            }
        }
    }
}
