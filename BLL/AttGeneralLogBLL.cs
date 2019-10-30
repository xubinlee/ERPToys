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
    public class AttGeneralLogBLL : IBLLBase
    {
        public List<VAttGeneralLog> GetVAttGeneralLog()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<AttGeneralLogDAL>().GetVAttGeneralLog(dcc);
            }
        }

        public List<AttGeneralLog> GetAttGeneralLog()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<AttGeneralLogDAL>().GetAttGeneralLog(dcc);
            }
        }

        public AttGeneralLog GetAttGeneralLog(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<AttGeneralLogDAL>().GetAttGeneralLog(dcc, id);
            }
        }

        public void Insert(List<AttGeneralLog> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AttGeneralLogDAL>().Insert(dcc, list);
                dcc.Save();
            }
        }

        public void Insert(AttGeneralLog obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AttGeneralLogDAL>().Insert(dcc, obj);
                dcc.Save();
            }
        }

        public void Update(AttGeneralLog obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AttGeneralLogDAL>().Update(dcc, obj);
                dcc.Save();
            }
        }

        public void Update(List<AttGeneralLog> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AttGeneralLogDAL>().Update(dcc, list);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AttGeneralLogDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }

        public void Delete(AttAppointments apt)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AttGeneralLogDAL>().Delete(dcc, apt);
                dcc.Save();
            }
        }
    }
}
