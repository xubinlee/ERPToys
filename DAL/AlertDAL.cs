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
    public class AlertDAL : IDALBase
    {
        public List<VAlert> GetVAlert(DCC dcc)
        {
            return dcc.VAlert.OrderByDescending(o=>o.添加时间).ToList();
        }

        public List<Alert> GetAlert(DCC dcc)
        {
            return dcc.Alert.OrderByDescending(o => o.AddTime).ToList();
        }

        public Alert GetAlert(DCC dcc, Guid id)
        {
            return dcc.Alert.FirstOrDefault(o => o.ID == id);
        }

        public void Insert(DCC dcc, List<Alert> delList, List<Alert> insertList)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                if (delList.Count > 0)
                {
                    dcc.Alert.AttachAll(delList);//附加实体---增加此段代码即可解决“无法删除尚未附加的实体”问题 
                    dcc.Alert.DeleteAllOnSubmit(delList);
                }
                if (insertList.Count > 0)
                    dcc.Alert.InsertAllOnSubmit(insertList);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, Alert obj)
        {
            dcc.Alert.Attach(obj);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, obj);
        }

        public void Delete(DCC dcc, Guid id)
        {
            var lst = dcc.Alert.Where(o => o.ID == id);
            dcc.Alert.DeleteAllOnSubmit(lst);
        }

        public void DeleteBill(DCC dcc)
        {
            var lst = dcc.Alert.Where(o => o.BillID != null);
            dcc.Alert.DeleteAllOnSubmit(lst);
        }
    }
}
