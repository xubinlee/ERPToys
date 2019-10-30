using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using IBase;

namespace Factory
{
    public class BLLFty:IFactoryBase
    {
        private static Hashtable m_Hashtable = null;

        public static T Create<T>() where T : class, IBLLBase, new()
        {
            if (m_Hashtable == null)
            {
                m_Hashtable = new Hashtable();
            }

            T oT;
            object obj = m_Hashtable[typeof(T).Name];
            if (obj == null)
            {
                oT = new T();
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
