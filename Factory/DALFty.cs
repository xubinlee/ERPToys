using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using IBase;
using Utility.Interceptor;

namespace Factory
{
    public class DALFty
    {
        private static Hashtable m_Hashtable = null;

        public static T Create<T>() where T : class, IDALBase, new()
        {
            if (m_Hashtable == null)
            {
                m_Hashtable = new Hashtable();
            }
            T oT;
            object obj = m_Hashtable[typeof(T).Name];
            if (obj == null)
            {
                // 使用拦截器创建实例
                oT = LoggerInterceptor.CreateProxy<T>();
                m_Hashtable.Add(typeof(T).Name, oT);
            }
            else
            {
                oT = (T)obj;
            }
            return oT;
        }
    }
}
