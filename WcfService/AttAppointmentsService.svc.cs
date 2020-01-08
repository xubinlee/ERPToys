using Common;
using DAL;
using EDMX;
using Factory;
using IWcfServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    public class AttAppointmentsService : ServiceBase, IAttAppointmentsService
    {
        public void AddAndUpdate(List<AttAppointments> insertList, List<AttAppointments> updateList)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                DALFty.Create<BaseDAL>().AddAndUpdate<AttAppointments>(db, insertList, updateList);
            }
        }
    }
}
