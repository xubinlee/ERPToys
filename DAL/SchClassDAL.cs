using DBML;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL
{
    public class SchClassDAL : IDALBase
    {
        public List<SchClass> GetSchClass(DCC dcc)
        {
            return dcc.SchClass.ToList();
        }


        public void Insert(DCC dcc, List<SchClass> list)
        {
            dcc.SchClass.InsertAllOnSubmit(list);
            dcc.SubmitChanges();
        }

        public void Update(DCC dcc, List<SchClass> list)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                //更新明细可能有新增记录，所以先将原有记录删除再全部添加
                var lst = dcc.SchClass;
                dcc.SchClass.DeleteAllOnSubmit(lst);
                dcc.SchClass.InsertAllOnSubmit(list);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Delete(DCC dcc, string name)
        {
            var lst = dcc.SchClass.Where(o => o.Name == name);
            dcc.SchClass.DeleteAllOnSubmit(lst);
            dcc.SubmitChanges();
        }
    }
}
