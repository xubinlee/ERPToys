using DAL;
using DBML;
using Factory;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderBLL : IBLLBase
    {
        public string GetMaxBillNo()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OrderDAL>().GetMaxBillNo(dcc);
            }
        }

        public List<OrderHd> GetOrderHd()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OrderDAL>().GetOrderHd(dcc);
            }
        }

        public OrderHd GetOrderHd(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OrderDAL>().GetOrderHd(dcc, id);
            }
        }

        public List<OrderDtl> GetOrderDtl(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OrderDAL>().GetOrderDtl(dcc, hdID);
            }
        }

        public List<VOrder> GetOrder(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OrderDAL>().GetOrder(dcc, hdID);
            }
        }

        public List<VOrder> GetOrder()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OrderDAL>().GetOrder(dcc);
            }
        }

        public List<VOrderDtlByColor> GetVOrderDtlByColor(Guid hdID, int bomType)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OrderDAL>().GetVOrderDtlByColor(dcc, hdID, bomType);
            }
        }

        public List<VOrderDtlByBOM> GetVOrderDtlByBOM(Guid hdID, int bomType)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OrderDAL>().GetVOrderDtlByBOM(dcc, hdID, bomType);
            }
        }

        public List<OrderDtl> GetVFSMOrderDtlByMoldList(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OrderDAL>().GetVFSMOrderDtlByMoldList(dcc, hdID);
            }
        }

        public List<OrderDtl> GetVFSMOrderDtlByMoldMaterial(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OrderDAL>().GetVFSMOrderDtlByMoldMaterial(dcc, hdID);
            }
        }

        //public List<VOrderDtlForPrint> GetOrderDtlForPrint(Guid hdID)
        //{
        //    using (DCC dcc = DBMLFty.Dcc)
        //    {
        //        return DALFty.Create<OrderDAL>().GetOrderDtlForPrint(dcc, hdID);
        //    }
        //}

        //public List<VOrderDtlForPrint> GetOrderDtlForPrint()
        //{
        //    using (DCC dcc = DBMLFty.Dcc)
        //    {
        //        return DALFty.Create<OrderDAL>().GetOrderDtlForPrint(dcc);
        //    }
        //}

        public List<VFSMOrder> GetFSMOrder()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OrderDAL>().GetFSMOrder(dcc);
            }
        }

        //public List<VFSMOrderDtlForPrint> GetFSMOrderDtlForPrint(Guid hdID)
        //{
        //    using (DCC dcc = DBMLFty.Dcc)
        //    {
        //        return DALFty.Create<OrderDAL>().GetFSMOrderDtlForPrint(dcc, hdID);
        //    }
        //}

        //public List<VFSMOrderDtlForPrint> GetFSMOrderDtlForPrint()
        //{
        //    using (DCC dcc = DBMLFty.Dcc)
        //    {
        //        return DALFty.Create<OrderDAL>().GetFSMOrderDtlForPrint(dcc);
        //    }
        //}

        public List<VProductionOrder> GetVProductionOrder(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OrderDAL>().GetVProductionOrder(dcc, hdID);
            }
        }

        public List<VProductionOrder> GetProductionOrder()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OrderDAL>().GetProductionOrder(dcc);
            }
        }

        public List<VProductionOrderDtlForPrint> GetProductionOrderDtlForPrint(Guid hdID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OrderDAL>().GetProductionOrderDtlForPrint(dcc, hdID);
            }
        }

        public List<VProductionOrderDtlForPrint> GetProductionOrderDtlForPrint()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<OrderDAL>().GetProductionOrderDtlForPrint(dcc);
            }
        }

        public void Audit(OrderHd orderhd, StockOutBillHd hd, List<StockOutBillDtl> dtl, OrderHd poHd, List<OrderDtl> poDtlList, List<Alert> delList)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<OrderDAL>().Audit(dcc, orderhd, hd, dtl, poHd, poDtlList, delList);
                dcc.Save();
            }
        }

        public void CancelAudit(OrderHd orderhd)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<OrderDAL>().CancelAudit(dcc, orderhd);
                dcc.Save();
            }
        }

        public void Insert(OrderHd hd, List<OrderDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<OrderDAL>().Insert(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Update(OrderHd hd, List<OrderDtl> dtl)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<OrderDAL>().Update(dcc, hd, dtl);
                dcc.Save();
            }
        }

        public void Update(OrderHd hd)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<OrderDAL>().Update(dcc, hd);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<OrderDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
