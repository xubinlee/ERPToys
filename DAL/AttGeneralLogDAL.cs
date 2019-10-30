using DBML;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AttGeneralLogDAL : IDALBase
    {
        public List<VAttGeneralLog> GetVAttGeneralLog(DCC dcc)
        {
            return dcc.VAttGeneralLog.OrderBy(o => o.账号).OrderBy(o => o.出勤时间).ToList();
        }

        public List<AttGeneralLog> GetAttGeneralLog(DCC dcc)
        {
            return dcc.AttGeneralLog.OrderBy(o=>o.EnrollNumber).OrderBy(o => o.AttTime).ToList();
        }

        public AttGeneralLog GetAttGeneralLog(DCC dcc, Guid id)
        {
            return dcc.AttGeneralLog.FirstOrDefault(o => o.ID == id);
        }

        public void Insert(DCC dcc, List<AttGeneralLog> list)
        {
            dcc.AttGeneralLog.InsertAllOnSubmit(list);
        }

        public void Insert(DCC dcc, AttGeneralLog obj)
        {
            dcc.AttGeneralLog.InsertOnSubmit(obj);
        }

        public void Update(DCC dcc, AttGeneralLog obj)
        {
            dcc.AttGeneralLog.Attach(obj);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, obj);
        }

        public void Update(DCC dcc, List<AttGeneralLog> list)
        {
            dcc.AttGeneralLog.AttachAll(list);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, list);
        }

        public void Delete(DCC dcc, Guid id)
        {
            var lst = dcc.AttGeneralLog.Where(o => o.ID == id);
            dcc.AttGeneralLog.DeleteAllOnSubmit(lst);
        }

        public void Delete(DCC dcc, AttAppointments apt)
        {
            var lst = dcc.AttGeneralLog.Where(o => o.ID == apt.GLogStartID || o.ID == apt.GLogEndID);
            dcc.AttGeneralLog.DeleteAllOnSubmit(lst);
        }
    }
}
