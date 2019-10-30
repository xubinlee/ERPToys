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
    public class WageBillBLL : IBLLBase
    {
        public string GetMaxBillNo()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<WageBillDAL>().GetMaxBillNo(dcc);
            }
        }

        public WageBillHd GetWageBillHd(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<WageBillDAL>().GetWageBillHd(dcc, id);
            }
        }

        public List<WageBillHd> GetWageBillHd()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<WageBillDAL>().GetWageBillHd(dcc);
            }
        }

        public List<WageBillDtl> GetWageBillDtl(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<WageBillDAL>().GetWageBillDtl(dcc, hdID);
            }
        }

        public List<VWageBillDtl> GetVWageBillDtl()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<WageBillDAL>().GetVWageBillDtl(dcc);
            }
        }

        public List<VWageBill> GetWageBill()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<WageBillDAL>().GetWageBill(dcc);
            }
        }

        public void Insert(WageBillHd hd, List<WageBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<WageBillDAL>().Insert(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Audit(WageBillHd hd, List<Appointments> aptList, List<Alert> delList)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<WageBillDAL>().Audit(dcc, hd, aptList, delList);
                dcc.Save();
            }
        }

        public void Update(WageBillHd hd, List<WageBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<WageBillDAL>().Update(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Update(WageBillHd hd)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<WageBillDAL>().Update(dcc, hd);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<WageBillDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
