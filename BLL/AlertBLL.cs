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
    public class AlertBLL : IBLLBase
    {
        public List<VAlert> GetVAlert()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<AlertDAL>().GetVAlert(dcc);
            }
        }

        public List<Alert> GetAlert()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<AlertDAL>().GetAlert(dcc);
            }
        }

        public Alert GetAlert(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<AlertDAL>().GetAlert(dcc, id);
            }
        }

        public void Insert(List<Alert> delList, List<Alert> insertList)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AlertDAL>().Insert(dcc, delList, insertList);
                dcc.Save();
            }
        }

        public void Update(Alert obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AlertDAL>().Update(dcc, obj);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AlertDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }

        public void DeleteBill()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AlertDAL>().DeleteBill(dcc);
                dcc.Save();
            }
        }
    }
}
