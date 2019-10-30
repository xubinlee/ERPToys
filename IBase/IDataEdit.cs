using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBase
{
    public interface IDataEdit
    {
        void Add();
        bool Save();
        void Clear();
    }
}
