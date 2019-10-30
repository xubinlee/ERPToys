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
    public class AppointmentsBLL : IBLLBase
    {
        public List<Appointments> GetAppointments()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<AppointmentsDAL>().GetAppointments(dcc);
            }
        }

        public List<VAppointments> GetVAppointments()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<AppointmentsDAL>().GetVAppointments(dcc);
            }
        }

        public void Insert(Appointments apt)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AppointmentsDAL>().Insert(dcc, apt);
                dcc.Save();
            }
        }

        public void Insert(List<Appointments> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AppointmentsDAL>().Insert(dcc, list);
                dcc.Save();
            }
        }

        public void Update(List<Appointments> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AppointmentsDAL>().Update(dcc, list);
                dcc.Save();
            }
        }

        public void Delete(List<Appointments> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AppointmentsDAL>().Delete(dcc, list);
                dcc.Save();
            }
        }

        public void Delete(Int64 id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<AppointmentsDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
