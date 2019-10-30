using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBML
{
    public class DCC : DCDataContext, IDisposable
    {
        public DCC(string conStr)
            : base(conStr)
        {
        }

        public void Save()
        {
            base.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
        }

        #region IDisposable 成员

        void IDisposable.Dispose()
        {
            base.Dispose();
        }

        #endregion
    }
}
