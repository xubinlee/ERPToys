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
    public class AttAppointmentsBLL : IBLLBase
    {
        public List<AttAppointments> GetAttAppointments()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<AttAppointmentsDAL>().GetAttAppointments(dcc);
            }
        }

        public List<VAttAppointments> GetVAttAppointments()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<AttAppointmentsDAL>().GetVAttAppointments(dcc);
            }
        }

        public void Save(List<AttAppointments> insertList, List<AttAppointments> updateList)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AttAppointmentsDAL>().Save(dcc, insertList, updateList);
                dcc.Save();
            }
        }

        public void Insert(AttAppointments apt)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AttAppointmentsDAL>().Insert(dcc, apt);
                dcc.Save();
            }
        }

        public void Insert(List<AttAppointments> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AttAppointmentsDAL>().Insert(dcc, list);
                dcc.Save();
            }
        }

        public void Update(List<AttAppointments> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AttAppointmentsDAL>().Update(dcc, list);
                dcc.Save();
            }
        }

        public void Delete(List<AttAppointments> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AttAppointmentsDAL>().Delete(dcc, list);
                dcc.Save();
            }
        }

        public void Delete(Int64 id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AttAppointmentsDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
