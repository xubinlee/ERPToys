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
    public class MaterielInStoreBillBLL : IBLLBase
    {
        public string GetMaxBillNo()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<MaterielInStoreBillDAL>().GetMaxBillNo(dcc);
            }
        }

        public MaterielInStoreBillHd GetMaterielInStoreBillHd(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<MaterielInStoreBillDAL>().GetMaterielInStoreBillHd(dcc, id);
            }
        }

        public List<MaterielInStoreBillDtl> GetMaterielInStoreBillDtl(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<MaterielInStoreBillDAL>().GetMaterielInStoreBillDtl(dcc, hdID);
            }
        }

        public List<VMaterielInStoreBill> GetMaterielInStoreBill()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<MaterielInStoreBillDAL>().GetMaterielInStoreBill(dcc);
            }
        }

        public void Insert(MaterielInStoreBillHd hd, List<MaterielInStoreBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<MaterielInStoreBillDAL>().Insert(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Update(MaterielInStoreBillHd hd, List<MaterielInStoreBillDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<MaterielInStoreBillDAL>().Update(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<MaterielInStoreBillDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
