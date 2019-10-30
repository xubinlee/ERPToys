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
    public class OrderDAL : IDALBase
    {
        public string GetMaxBillNo(DCC dcc)
        {
            return dcc.OrderHd.Max(o => o.BillNo);
        }

        public List<OrderHd> GetOrderHd(DCC dcc)
        {
            return dcc.OrderHd.OrderBy(o=>o.BillNo).ToList();
        }

        public OrderHd GetOrderHd(DCC dcc, Guid id)
        {
            return dcc.OrderHd.FirstOrDefault(o => o.ID == id);
        }

        public List<OrderDtl> GetOrderDtl(DCC dcc, Guid hdID)
        {
            return dcc.OrderDtl.Where(o => o.HdID == hdID).OrderBy(o => o.SerialNo).ToList();
        }

        public List<VOrder> GetOrder(DCC dcc, Guid hdID)
        {
            return dcc.VOrder.Where(o=>o.HdID== hdID).OrderByDescending(o => o.类型).OrderBy(o => o.状态).ToList();
        }

        public List<VOrder> GetOrder(DCC dcc)
        {
            return dcc.VOrder.OrderByDescending(o => o.类型).OrderBy(o=>o.状态).ToList();
        }

        public List<VOrderDtlByColor> GetVOrderDtlByColor(DCC dcc, Guid hdID, int bomType)
        {
            return dcc.VOrderDtlByColor.Where(o => o.HdID == hdID && o.Type == bomType).ToList();
        }

        public List<VOrderDtlByBOM> GetVOrderDtlByBOM(DCC dcc, Guid hdID, int bomType)
        {
            //List<OrderDtl> dtlList = new List<OrderDtl>();
            List<VOrderDtlByBOM> list = dcc.VOrderDtlByBOM.Where(o => o.HdID == hdID && o.Type == bomType).ToList();
            //foreach (VOrderDtlByBOM item in list)
            //{
            //    OrderDtl dtl = new OrderDtl();
            //    dtl.ID = item.ID;
            //    dtl.HdID = item.HdID;
            //    dtl.GoodsID = item.GoodsID;
            //    dtl.Qty = item.Qty.Value;
            //    dtl.PCS = item.PCS;
            //    dtl.InnerBox = (int)item.InnerBox;
            //    dtl.NWeight = item.NWeight == 0 ? 1 : item.NWeight;
            //    dtl.Price = item.Price;
            //    dtl.PriceNoTax = item.PriceNoTax;
            //    dtl.Discount = item.Discount;
            //    dtl.OtherFee = item.OtherFee;
            //    dtlList.Add(dtl);
            //}
            //return dtlList;
            return list;
        }

        public List<OrderDtl> GetVFSMOrderDtlByMoldList(DCC dcc, Guid hdID)
        {
            List<OrderDtl> dtlList = new List<OrderDtl>();
            List<VFSMOrderDtlByMoldList> list = dcc.VFSMOrderDtlByMoldList.Where(o => o.HdID == hdID).ToList();
            foreach (VFSMOrderDtlByMoldList item in list)
            {
                OrderDtl dtl = new OrderDtl();
                dtl.ID = item.ID;
                dtl.HdID = item.HdID;
                dtl.GoodsID = item.GoodsID;
                dtl.Qty = item.Qty.Value;
                dtl.PCS = item.PCS;
                dtl.InnerBox = item.InnerBox;
                //dtl.NWeight = item.NWeight == 0 ? 1 : item.NWeight;
                dtl.Price = item.Price;
                dtl.PriceNoTax = item.PriceNoTax;
                dtl.Discount = item.Discount;
                dtl.OtherFee = item.OtherFee;
                dtlList.Add(dtl);
            }
            return dtlList;
        }

        public List<OrderDtl> GetVFSMOrderDtlByMoldMaterial(DCC dcc, Guid hdID)
        {
            List<OrderDtl> dtlList = new List<OrderDtl>();
            List<VFSMOrderDtlByMoldMaterial> list = dcc.VFSMOrderDtlByMoldMaterial.Where(o => o.HdID == hdID).ToList();
            foreach (VFSMOrderDtlByMoldMaterial item in list)
            {
                OrderDtl dtl = new OrderDtl();
                dtl.ID = item.ID;
                dtl.HdID = item.HdID;
                dtl.GoodsID = item.GoodsID;
                dtl.Qty = item.Qty.Value;
                dtl.PCS = item.PCS;
                dtl.InnerBox = item.InnerBox;
                //dtl.NWeight = item.NWeight == 0 ? 1 : item.NWeight;
                dtl.Price = item.Price;
                dtl.PriceNoTax = item.PriceNoTax;
                dtl.Discount = item.Discount;
                dtl.OtherFee = item.OtherFee;
                dtlList.Add(dtl);
            }
            return dtlList;
        }

        //public List<VOrderDtlForPrint> GetOrderDtlForPrint(DCC dcc, Guid hdID)
        //{
        //    return dcc.VOrderDtlForPrint.Where(o => o.HdID == hdID).ToList();
        //}

        //public List<VOrderDtlForPrint> GetOrderDtlForPrint(DCC dcc)
        //{
        //    return dcc.VOrderDtlForPrint.OrderBy(o => o.货号).ToList();
        //}

        public List<VFSMOrder> GetFSMOrder(DCC dcc)
        {
            return dcc.VFSMOrder.OrderByDescending(o => o.类型).OrderBy(o => o.状态).ToList();
        }

        //public List<VFSMOrderDtlForPrint> GetFSMOrderDtlForPrint(DCC dcc, Guid hdID)
        //{
        //    return dcc.VFSMOrderDtlForPrint.Where(o => o.HdID == hdID).ToList();
        //}

        //public List<VFSMOrderDtlForPrint> GetFSMOrderDtlForPrint(DCC dcc)
        //{
        //    return dcc.VFSMOrderDtlForPrint.OrderBy(o => o.货号).ToList();
        //}

        public List<VProductionOrder> GetVProductionOrder(DCC dcc, Guid hdID)
        {
            return dcc.VProductionOrder.Where(o => o.HdID == hdID).OrderByDescending(o => o.类型).OrderBy(o => o.状态).ToList();
        }

        public List<VProductionOrder> GetProductionOrder(DCC dcc)
        {
            return dcc.VProductionOrder.OrderByDescending(o => o.类型).OrderBy(o => o.状态).ToList();
        }

        public List<VProductionOrderDtlForPrint> GetProductionOrderDtlForPrint(DCC dcc, Guid hdID)
        {
            return dcc.VProductionOrderDtlForPrint.Where(o => o.HdID == hdID).ToList();
        }

        public List<VProductionOrderDtlForPrint> GetProductionOrderDtlForPrint(DCC dcc)
        {
            return dcc.VProductionOrderDtlForPrint.OrderBy(o => o.货号).ToList();
        }

        public void Audit(DCC dcc, OrderHd orderhd, StockOutBillHd hd, List<StockOutBillDtl> dtl, OrderHd poHd, List<OrderDtl> poDtlList, List<Alert> delList)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.OrderHd.Attach(orderhd);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, orderhd);
                ////更新明细可能有新增记录，所有先将原有记录删除再全部添加
                //var lstdtl = dcc.OrderDtl.Where(o => o.HdID == orderhd.ID);
                //dcc.OrderDtl.DeleteAllOnSubmit(lstdtl);
                //foreach (OrderDtl item in orderdtl)
                //{
                //    item.ID = Guid.NewGuid();
                //    item.HdID = orderhd.ID;
                //}
                //dcc.OrderDtl.InsertAllOnSubmit(orderdtl);
                dcc.StockOutBillHd.InsertOnSubmit(hd);
                dcc.StockOutBillDtl.InsertAllOnSubmit(dtl);
                if (poHd != null && poDtlList !=null)
                {
                    dcc.OrderHd.InsertOnSubmit(poHd);
                    dcc.OrderDtl.InsertAllOnSubmit(poDtlList);
                }
                if (delList.Count > 0)
                {
                    dcc.Alert.AttachAll(delList);//附加实体---增加此段代码即可解决“无法删除尚未附加的实体”问题 
                    dcc.Alert.DeleteAllOnSubmit(delList);
                }
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void CancelAudit(DCC dcc, OrderHd orderHd)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.OrderHd.Attach(orderHd);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, orderHd);
                var lstInHd = dcc.StockInBillHd.Where(o => o.OrderID == orderHd.ID);
                dcc.StockInBillHd.DeleteAllOnSubmit(lstInHd);
                foreach (StockInBillHd inHd in lstInHd)
                {
                    var lstInDtl = dcc.StockInBillDtl.Where(o => o.HdID == inHd.ID);
                    dcc.StockInBillDtl.DeleteAllOnSubmit(lstInDtl);
                }
                var lstOutHd = dcc.StockOutBillHd.Where(o => o.OrderID == orderHd.ID);
                dcc.StockOutBillHd.DeleteAllOnSubmit(lstOutHd);
                foreach (StockOutBillHd outHd in lstOutHd)
                {
                    var lstOutDtl = dcc.StockOutBillDtl.Where(o => o.HdID == outHd.ID);
                    dcc.StockOutBillDtl.DeleteAllOnSubmit(lstOutDtl);
                }
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Insert(DCC dcc, OrderHd hd, List<OrderDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.OrderHd.InsertOnSubmit(hd);
                dcc.OrderDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, OrderHd hd, List<OrderDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.OrderHd.Attach(hd);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
                //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                var lstHd = dcc.OrderDtl.Where(o => o.HdID == hd.ID);
                dcc.OrderDtl.DeleteAllOnSubmit(lstHd);
                foreach (OrderDtl item in dtl)
                {
                    item.ID = Guid.NewGuid();
                    item.HdID = hd.ID;
                }
                dcc.OrderDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, OrderHd hd)
        {
            dcc.OrderHd.Attach(hd);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
        }

        public void Delete(DCC dcc, Guid hdID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var lstDtl = dcc.OrderHd.Where(o => o.ID == hdID);
                dcc.OrderHd.DeleteAllOnSubmit(lstDtl);
                var lstHd = dcc.OrderDtl.Where(o => o.HdID == hdID);
                dcc.OrderDtl.DeleteAllOnSubmit(lstHd);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }
    }
}
