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
    public class StockInBillDAL : IDALBase
    {
        public string GetMaxBillNo(DCC dcc)
        {
            return dcc.StockInBillHd.Max(o => o.BillNo);
        }

        public StockInBillHd GetStockInBillHd(DCC dcc, Guid id)
        {
            return dcc.StockInBillHd.FirstOrDefault(o => o.ID == id);
        }

        public List<StockInBillHd> GetStockInBillHd(DCC dcc)
        {
            return dcc.StockInBillHd.OrderBy(o => o.BillNo).ToList();
        }

        public List<StockInBillDtl> GetStockInBillDtl(DCC dcc, Guid hdID)
        {
            return dcc.StockInBillDtl.Where(o => o.HdID == hdID).OrderBy(o=>o.SerialNo).ToList();
        }

        public List<VStockInBillDtlByColor> GetVStockInBillDtlByColor(DCC dcc, Guid hdID, int bomType)
        {
            return  dcc.VStockInBillDtlByColor.Where(o => o.HdID == hdID && o.Type == bomType).ToList();
        }

        public List<StockInBillDtl> GetVStockInBillDtlByBOM(DCC dcc, Guid hdID)
        {
            List<StockInBillDtl> dtlList = new List<StockInBillDtl>();
            List<VStockInBillDtlByBOM> list = dcc.VStockInBillDtlByBOM.Where(o => o.HdID == hdID).ToList();
            foreach (VStockInBillDtlByBOM item in list)
            {
                StockInBillDtl dtl = new StockInBillDtl();
                dtl.ID = item.ID.Value;
                dtl.HdID = item.HdID;
                dtl.GoodsID = item.GoodsID;
                dtl.Qty = item.Qty.Value;
                dtl.PCS = item.PCS;
                dtl.InnerBox = item.InnerBox;
                dtl.NWeight = item.NWeight == 0 ? 1 : item.NWeight;
                dtl.Price = item.Price;
                dtl.PriceNoTax = item.PriceNoTax;
                dtl.Discount = item.Discount;
                dtl.OtherFee = item.OtherFee;
                dtlList.Add(dtl);
            }
            return dtlList;
        }

        public List<StockInBillDtl> GetVStockInBillDtlByBOM(DCC dcc, Guid hdID, int bomType)
        {
            List<StockInBillDtl> dtlList = new List<StockInBillDtl>();
            List<VStockInBillDtlByBOM> list = dcc.VStockInBillDtlByBOM.Where(o => o.HdID == hdID && o.Type == bomType).ToList();
            foreach (VStockInBillDtlByBOM item in list)
            {
                StockInBillDtl dtl = new StockInBillDtl();
                dtl.ID = item.ID.Value;
                dtl.HdID = item.HdID;
                dtl.GoodsID = item.GoodsID;
                dtl.Qty = item.Qty.Value;
                dtl.PCS = item.PCS;
                dtl.InnerBox = item.InnerBox;
                dtl.NWeight = item.NWeight == 0 ? 1 : item.NWeight;
                dtl.Price = item.Price;
                dtl.PriceNoTax = item.PriceNoTax;
                dtl.Discount = item.Discount;
                dtl.OtherFee = item.OtherFee;
                dtlList.Add(dtl);
            }
            return dtlList;
        }

        public List<VStockInBillDtlByBOM> GetVStockInBillDtlByBOM2(DCC dcc, Guid hdID, int bomType)
        {
            return dcc.VStockInBillDtlByBOM.Where(o => o.HdID == hdID && o.Type == bomType).ToList();
        }

        public List<VStockInBill> GetStockInBill(DCC dcc)
        {
            return dcc.VStockInBill.OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
        }

        public List<VStockInBill> GetStockInBill(DCC dcc,Guid hdID)
        {
            return dcc.VStockInBill.Where(o => o.HdID == hdID).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
        }

        //public List<VStockInBillDtlForPrint> GetStockInBillDtlForPrint(DCC dcc)
        //{
        //    return dcc.VStockInBillDtlForPrint.OrderByDescending(o => o.货号).ToList();
        //}

        //public List<VStockInBillDtlForPrint> GetStockInBillDtlForPrint(DCC dcc, Guid hdID)
        //{
        //    return dcc.VStockInBillDtlForPrint.Where(o => o.HdID == hdID).ToList();
        //}

        public List<VMaterialStockInBill> GetMaterialStockInBill(DCC dcc)
        {
            return dcc.VMaterialStockInBill.OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
        }

        public List<VMaterialStockInBill> GetMaterialStockInBill(DCC dcc,Guid hdID)
        {
            return dcc.VMaterialStockInBill.Where(o=>o.HdID==hdID).OrderBy(o => o.状态).OrderByDescending(o => o.入库单号).ToList();
        }

        //public List<VMaterialStockInBillDtlForPrint> GetMaterialStockInBillDtlForPrint(DCC dcc)
        //{
        //    return dcc.VMaterialStockInBillDtlForPrint.OrderByDescending(o => o.货号).ToList();
        //}

        //public List<VMaterialStockInBillDtlForPrint> GetMaterialStockInBillDtlForPrint(DCC dcc, Guid hdID)
        //{
        //    return dcc.VMaterialStockInBillDtlForPrint.Where(o => o.HdID == hdID).ToList();
        //}

        public void Audit(DCC dcc, OrderHd orderhd, List<OrderDtl> orderdtl, StockInBillHd hd, List<StockInBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.OrderHd.Attach(orderhd);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, orderhd);
                //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                var lstdtl = dcc.OrderDtl.Where(o => o.HdID == orderhd.ID);
                dcc.OrderDtl.DeleteAllOnSubmit(lstdtl);
                foreach (OrderDtl item in orderdtl)
                {
                    item.ID = Guid.NewGuid();
                    item.HdID = orderhd.ID;
                }
                dcc.OrderDtl.InsertAllOnSubmit(orderdtl);
                dcc.StockInBillHd.InsertOnSubmit(hd);
                dcc.StockInBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Insert(DCC dcc, StockInBillHd hd, List<StockInBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.StockInBillHd.InsertOnSubmit(hd);
                dcc.StockInBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, StockInBillHd hd, List<StockInBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.StockInBillHd.Attach(hd);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
                //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                var lstHd = dcc.StockInBillDtl.Where(o => o.HdID == hd.ID);
                dcc.StockInBillDtl.DeleteAllOnSubmit(lstHd);
                foreach (StockInBillDtl item in dtl)
                {
                    item.ID = Guid.NewGuid();
                    item.HdID = hd.ID;
                }
                dcc.StockInBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, StockInBillHd hd)
        {
            dcc.StockInBillHd.Attach(hd);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);

            
        }

        public void Delete(DCC dcc, Guid hdID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                StockInBillHd lstHd = dcc.StockInBillHd.FirstOrDefault(o => o.ID == hdID);
                dcc.StockInBillHd.DeleteOnSubmit(lstHd);
                var lstDtl = dcc.StockInBillDtl.Where(o => o.HdID == hdID);
                dcc.StockInBillDtl.DeleteAllOnSubmit(lstDtl);
                if (lstHd.Type == 0 || lstHd.Type == 6)//删除成品入库单，材料入库单
                {
                    OrderHd order = dcc.OrderHd.FirstOrDefault(o => o.ID == lstHd.OrderID);
                    if (order != null)
                    {
                        order.Status = 0;
                        order.Auditor = null;
                        order.AuditDate = null;
                        //dcc.OrderHd.Attach(order);
                        dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, order);
                    }
                }
                dcc.SubmitChanges();
                ts.Complete();
            }
        }
    }
}
