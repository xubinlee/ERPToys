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
    public class WageBillService : ServiceBase, IWageBillService
    {
        //[Dependency]
        //public WarehouseBLL BusinessComponent
        //{ get; set; }

        public string GetMaxBillNo()
        {
            return BLLFty.Create<WageBillBLL>().GetMaxBillNo();
        }

        public WageBillHd GetWageBillHd(Guid id)
        {
            return BLLFty.Create<WageBillBLL>().GetWageBillHd(id);
        }

        public List<WageBillHd> GetWageBillHd()
        {
            return BLLFty.Create<WageBillBLL>().GetWageBillHd();
        }

        public List<WageBillDtl> GetWageBillDtl(Guid hdID)
        {
            return BLLFty.Create<WageBillBLL>().GetWageBillDtl(hdID);
        }

        public List<VWageBillDtl> GetVWageBillDtl()
        {
            return BLLFty.Create<WageBillBLL>().GetVWageBillDtl();
        }

        public List<VWageBill> GetWageBill()
        {
            return BLLFty.Create<WageBillBLL>().GetWageBill();
        }

        public void Insert(WageBillHd hd, List<WageBillDtl> dtl)
        {
            BLLFty.Create<WageBillBLL>().Insert(hd, dtl);
        }

        public void Audit(WageBillHd hd, List<Appointments> aptList, List<Alert> delList)
        {
            BLLFty.Create<WageBillBLL>().Audit(hd, aptList, delList);
        }

        public void Update(WageBillHd hd, List<WageBillDtl> dtl)
        {
            BLLFty.Create<WageBillBLL>().Update(hd, dtl);
        }

        public void Update(WageBillHd hd)
        {
            BLLFty.Create<WageBillBLL>().Update(hd);
        }

        public void Delete(Guid id)
        {
            BLLFty.Create<WageBillBLL>().Delete(id);
        }
    }
}
