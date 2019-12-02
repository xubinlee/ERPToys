using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Utility;

namespace Factory
{
    class ConfigInfo
    {
        static string license = string.Empty;

        public static string License
        {
            get { return license; }
            set { license = value; }
        }

        private static string m_SqlConStr;

        public static string SqlConStr
        {
            get
            {
                license = ConfigurationManager.AppSettings["License"];
                if (license.Equals(Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation())))
                {
                    m_SqlConStr = Security.Decrypt(ConfigurationManager.ConnectionStrings["ErpContext"].ConnectionString);
                }
                return m_SqlConStr;
            }
        }
    }
}
