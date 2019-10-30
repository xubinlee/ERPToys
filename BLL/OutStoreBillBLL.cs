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
    public class OutStoreBillBLL : IBLLBase
    {
        public string GetMaxBillNo()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OutStoreBillDAL>().GetMaxBillNo(dcc);
            }
        }

        public OutStoreBillHd GetOutStoreBillHd(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OutStoreBillDAL>().GetOutStoreBillHd(dcc, id);
            }
        }

        public List<OutStoreBillDtl> GetOutStoreBillDtl(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OutStoreBillDAL>().GetOutStoreBillDtl(dcc, hdID);
            }
        }

        public List<VOutStoreBill> GetOutStoreBill()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OutStoreBillDAL>().GetOutStoreBill(dcc);
            }
        }

        public void Insert(OutStoreBillHd hd, List<OutStoreBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<OutStoreBillDAL>().Insert(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Update(OutStoreBillHd hd, List<OutStoreBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<OutStoreBillDAL>().Update(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Update(OutStoreBillHd hd)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<OutStoreBillDAL>().Update(dcc, hd);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<OutStoreBillDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
