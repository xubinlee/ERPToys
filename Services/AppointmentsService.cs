using Common;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBML;
using BLL;
using Microsoft.Practices.Unity;
using Factory;

namespace Services
{
    public class AppointmentsService : ServiceBase, IAppointmentsService
    {
        //[Dependency]
        //public WarehouseBLL BusinessComponent
        //{ get; set; }

        public List<Appointments> GetAppointments()
        {
            return BLLFty.Create<AppointmentsBLL>().GetAppointments();
        }

        public List<VAppointments> GetVAppointments()
        {
            return BLLFty.Create<AppointmentsBLL>().GetVAppointments();
        }

        public void Insert(List<Appointments> list)
        {
            BLLFty.Create<AppointmentsBLL>().Insert(list);
        }

        public void Insert(Appointments apt)
        {
            BLLFty.Create<AppointmentsBLL>().Insert(apt);
        }

        public void Update(List<Appointments> list)
        {
            BLLFty.Create<AppointmentsBLL>().Update(list);
        }

        public void Delete(long id)
        {
            BLLFty.Create<AppointmentsBLL>().Delete(id);
        }

        public void Delete(List<Appointments> list)
        {
            BLLFty.Create<AppointmentsBLL>().Delete(list);
        }
    }
}

