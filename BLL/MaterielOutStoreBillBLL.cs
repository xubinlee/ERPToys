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
    public class MaterielOutStoreBillBLL : IBLLBase
    {
        public string GetMaxBillNo()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<MaterielOutStoreBillDAL>().GetMaxBillNo(dcc);
            }
        }

        public MaterielOutStoreBillHd GetMaterielOutStoreBillHd(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<MaterielOutStoreBillDAL>().GetMaterielOutStoreBillHd(dcc, id);
            }
        }

        public List<MaterielOutStoreBillDtl> GetMaterielOutStoreBillDtl(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<MaterielOutStoreBillDAL>().GetMaterielOutStoreBillDtl(dcc, hdID);
            }
        }

        public List<MaterielOutStoreBillDtl> GetVBillDtlByBOM(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<MaterielOutStoreBillDAL>().GetVBillDtlByBOM(dcc, hdID);
            }
        }

        public List<VMaterielOutStoreBill> GetMaterielOutStoreBill()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<MaterielOutStoreBillDAL>().GetMaterielOutStoreBill(dcc);
            }
        }

        public void Insert(MaterielOutStoreBillHd hd, List<MaterielOutStoreBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<MaterielOutStoreBillDAL>().Insert(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Update(MaterielOutStoreBillHd hd, List<MaterielOutStoreBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<MaterielOutStoreBillDAL>().Update(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<MaterielOutStoreBillDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
