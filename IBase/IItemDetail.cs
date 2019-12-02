using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBase
{
    public interface IItemDetail
    {
        void Add();

        void Edit();

        void Del();

        //void Invalid();

        bool Save();

        bool Audit();

        void Print();

        void BindData(object obj);
    }
}
