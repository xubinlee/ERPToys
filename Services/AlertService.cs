using Common;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBML;
using BLL;
using Microsoft.Practices.Unity;
using Factory;

namespace Services
{
    public class AlertService : ServiceBase, IAlertService
    {
        //[Dependency]
        //public WarehouseBLL BusinessComponent
        //{ get; set; }

        public List<Alert> GetAlert()
        {
            return BLLFty.Create<AlertBLL>().GetAlert();
        }

        public Alert GetAlert(Guid id)
        {
            return BLLFty.Create<AlertBLL>().GetAlert(id);
        }

        public List<VAlert> GetVAlert()
        {
            return BLLFty.Create<AlertBLL>().GetVAlert();
        }

        public void Insert(List<Alert> delList, List<Alert> insertList)
        {
            BLLFty.Create<AlertBLL>().Insert(delList, insertList);
        }

        public void Update(Alert obj)
        {
            BLLFty.Create<AlertBLL>().Update(obj);
        }

        public void Delete(Guid id)
        {
            BLLFty.Create<AlertBLL>().Delete(id);
        }

        public void DeleteBill()
        {
            BLLFty.Create<AlertBLL>().DeleteBill();
        }
    }
}

