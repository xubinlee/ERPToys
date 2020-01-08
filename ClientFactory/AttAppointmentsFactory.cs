using Common;
using EDMX;
using IWcfServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace ClientFactory
{
    public class AttAppointmentsFactory : IAttAppointmentsService
    {
        private static IAttAppointmentsService attAppointmentsService = ServiceProxyFactory.Create<IAttAppointmentsService>("AttAppointmentsService");

        RedisHelper redis = new RedisHelper();

        public virtual void AddAndUpdate(List<AttAppointments> insertList, List<AttAppointments> updateList)
        {
            attAppointmentsService.AddAndUpdate(insertList, updateList);
        }
    }
}
