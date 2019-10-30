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
    public class AttAppointmentsDAL: IDALBase
    {
        public List<AttAppointments> GetAttAppointments(DCC dcc)
        {
            return dcc.AttAppointments.ToList();
        }

        public List<VAttAppointments> GetVAttAppointments(DCC dcc)
        {
            return dcc.VAttAppointments.ToList();
        }

        public void Save(DCC dcc, List<AttAppointments> insertList, List<AttAppointments> updateList)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                if (insertList.Count>0)
                {
                    dcc.AttAppointments.InsertAllOnSubmit(insertList);
                }
                if (updateList.Count>0)
                {
                    dcc.AttAppointments.AttachAll(updateList);
                }
                dcc.SubmitChanges();
                ts.Complete();
            }
            if (updateList.Count > 0)
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, updateList);
        }

        public void Insert(DCC dcc, AttAppointments apt)
        {
            dcc.AttAppointments.InsertOnSubmit(apt);
        }

        public void Insert(DCC dcc, List<AttAppointments> list)
        {
            dcc.AttAppointments.InsertAllOnSubmit(list);
        }

        public void Update(DCC dcc, List<AttAppointments> list)
        {
            dcc.AttAppointments.AttachAll(list);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, list);
        }

        public void Delete(DCC dcc, List<AttAppointments> list)
        {
            dcc.AttAppointments.DeleteAllOnSubmit(list);
        }

        public void Delete(DCC dcc, Int64 id)
        {
            var lst = dcc.AttAppointments.Where(o => o.UniqueID == id);
            dcc.AttAppointments.DeleteAllOnSubmit(lst);
        }
    }
}
