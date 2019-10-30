using DBML;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppointmentsDAL: IDALBase
    {
        public List<Appointments> GetAppointments(DCC dcc)
        {
            return dcc.Appointments.ToList();
        }

        public List<VAppointments> GetVAppointments(DCC dcc)
        {
            return dcc.VAppointments.ToList();
        }

        public void Insert(DCC dcc, Appointments apt)
        {
            dcc.Appointments.InsertOnSubmit(apt);
        }

        public void Insert(DCC dcc, List<Appointments> list)
        {
            dcc.Appointments.InsertAllOnSubmit(list);
        }

        public void Update(DCC dcc, List<Appointments> list)
        {
            dcc.Appointments.AttachAll(list);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, list);
        }

        public void Delete(DCC dcc, List<Appointments> list)
        {
            dcc.Appointments.DeleteAllOnSubmit(list);
        }

        public void Delete(DCC dcc, Int64 id)
        {
            var lst = dcc.Appointments.Where(o => o.UniqueID == id);
            dcc.Appointments.DeleteAllOnSubmit(lst);
        }
    }
}
