using Microsoft.Practices.ObjectBuilder;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Client
{
    public class ServiceClient : IServiceClient
    {
        static WeakRefDictionary<Type, object> clientServices = new WeakRefDictionary<Type, object>();

        public static T GetClientService<T>()
        {
            return (T)GetClientService(typeof(T));

        }
        public static object GetClientService(Type type)
        {
            try
            {
                if (clientServices.ContainsKey(type))
                    return clientServices[type];
                if (clientServices.ContainsKey(typeof(IServiceContainer)))
                {
                    IServiceContainer serviceContainer = clientServices[typeof(IServiceContainer)] as IServiceContainer;
                    return serviceContainer.GetService(type);
                }
                else
                    return null;
            }
            catch 
            {
                return null;
            }
        }

        public static void AddClientService(Type clientServiceType, object serviceInstance)
        {

            if (clientServiceType.FullName.ToLower().Contains("workitem"))
                return;
            //if (IsWCFContractType(clientServiceType))
            //    return;

            if (clientServices.ContainsKey(clientServiceType))
                return;
            clientServices.Add(clientServiceType, serviceInstance);

        }
    }
}
