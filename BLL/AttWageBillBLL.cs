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
    public class AttWageBillBLL : IBLLBase
    {
        public string GetMaxBillNo()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<AttWageBillDAL>().GetMaxBillNo(dcc);
            }
        }

        public AttWageBillHd GetAttWageBillHd(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<AttWageBillDAL>().GetAttWageBillHd(dcc, id);
            }
        }

        public List<AttWageBillHd> GetAttWageBillHd()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<AttWageBillDAL>().GetAttWageBillHd(dcc);
            }
        }

        public List<AttWageBillDtl> GetAttWageBillDtl(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<AttWageBillDAL>().GetAttWageBillDtl(dcc, hdID);
            }
        }

        public List<USPAttWageBillDtl> GetUSPAttWageBillDtl()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<AttWageBillDAL>().GetUSPAttWageBillDtl(dcc);
            }
        }

        public List<VAttWageBill> GetAttWageBill()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<AttWageBillDAL>().GetAttWageBill(dcc);
            }
        }

        public void Insert(AttWageBillHd hd, List<AttWageBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AttWageBillDAL>().Insert(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Audit(AttWageBillHd hd, List<AttAppointments> aptList, List<AttGeneralLog> logList, List<Alert> delList)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AttWageBillDAL>().Audit(dcc, hd, aptList, logList, delList);
                dcc.Save();
            }
        }

        public void Update(AttWageBillHd hd, List<AttWageBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AttWageBillDAL>().Update(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Update(AttWageBillHd hd)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AttWageBillDAL>().Update(dcc, hd);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AttWageBillDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
