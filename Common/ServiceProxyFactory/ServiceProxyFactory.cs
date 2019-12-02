using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ServiceProxyFactory
    {
        public static T Create<T>(string endpointName)
        {
            if (string.IsNullOrEmpty(endpointName))
            {
                throw new ArgumentNullException("endpointName");
            }
            return (T)(new ServiceRealProxy<T>(endpointName).GetTransparentProxy());
        }
    }
}
