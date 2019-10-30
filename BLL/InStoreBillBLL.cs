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
    public class InStoreBillBLL:IBLLBase
    {
        public string GetMaxBillNo()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<InStoreBillDAL>().GetMaxBillNo(dcc);
            }
        }

        public InStoreBillHd GetInStoreBillHd(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<InStoreBillDAL>().GetInStoreBillHd(dcc,id);
            }
        }

        public List<InStoreBillDtl> GetInStoreBillDtl(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<InStoreBillDAL>().GetInStoreBillDtl(dcc,hdID);
            }
        }

        public List<VInStoreBill> GetInStoreBill()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<InStoreBillDAL>().GetInStoreBill(dcc);
            }
        }

        public void Insert(InStoreBillHd hd,List<InStoreBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<InStoreBillDAL>().Insert(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Update(InStoreBillHd hd, List<InStoreBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<InStoreBillDAL>().Update(dcc, hd,dtl);
                dcc.Save();
            }
        }

        public void Update(InStoreBillHd hd)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<InStoreBillDAL>().Update(dcc, hd);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<InStoreBillDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
