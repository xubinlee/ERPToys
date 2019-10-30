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
    public class StockOutBillDAL : IDALBase
    {
        public string GetMaxBillNo(DCC dcc)
        {
            return dcc.StockOutBillHd.Max(o => o.BillNo);
        }

        public StockOutBillHd GetStockOutBillHd(DCC dcc, Guid id)
        {
            return dcc.StockOutBillHd.FirstOrDefault(o => o.ID == id);
        }

        public List<StockOutBillDtl> GetStockOutBillDtl(DCC dcc, Guid hdID)
        {
            return dcc.StockOutBillDtl.Where(o => o.HdID == hdID).OrderBy(o=>o.SerialNo).ToList();
        }

        public List<StockOutBillHd> GetStockOutBillHd(DCC dcc)
        {
            return dcc.StockOutBillHd.OrderBy(o=>o.BillNo).ToList();
        }

        public List<StockOutBillDtl> GetVStockOutBillDtlByBOM(DCC dcc, Guid hdID, int bomType)
        {
            List<StockOutBillDtl> dtlList = new List<StockOutBillDtl>();
            List<VStockOutBillDtlByBOM> list = dcc.VStockOutBillDtlByBOM.Where(o => o.HdID == hdID && o.Type == bomType).ToList();
            foreach (VStockOutBillDtlByBOM item in list)
            {
                StockOutBillDtl dtl = new StockOutBillDtl();
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

        public List<VStockOutBill> GetStockOutBill(DCC dcc)
        {
            return dcc.VStockOutBill.OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
        }

        //public List<VStockOutBillDtlForPrint> GetStockOutBillDtlForPrint(DCC dcc)
        //{
        //    return dcc.VStockOutBillDtlForPrint.OrderByDescending(o => o.货号).ToList();
        //}

        //public List<VStockOutBillDtlForPrint> GetStockOutBillDtlForPrint(DCC dcc, Guid hdID)
        //{
        //    return dcc.VStockOutBillDtlForPrint.Where(o => o.HdID == hdID).ToList();
        //}

        public List<VMaterialStockOutBill> GetMaterialStockOutBill(DCC dcc)
        {
            return dcc.VMaterialStockOutBill.OrderBy(o => o.状态).OrderByDescending(o => o.出库单号).ToList();
        }

        //public List<VMaterialStockOutBillDtlForPrint> GetMaterialStockOutBillDtlForPrint(DCC dcc)
        //{
        //    return dcc.VMaterialStockOutBillDtlForPrint.OrderByDescending(o => o.货号).ToList();
        //}

        //public List<VMaterialStockOutBillDtlForPrint> GetMaterialStockOutBillDtlForPrint(DCC dcc, Guid hdID)
        //{
        //    return dcc.VMaterialStockOutBillDtlForPrint.Where(o => o.HdID == hdID).ToList();
        //}

        public void Insert(DCC dcc, StockOutBillHd hd, List<StockOutBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.StockOutBillHd.InsertOnSubmit(hd);
                dcc.StockOutBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, StockOutBillHd hd, List<StockOutBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.StockOutBillHd.Attach(hd);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
                //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                var lstHd = dcc.StockOutBillDtl.Where(o => o.HdID == hd.ID);
                dcc.StockOutBillDtl.DeleteAllOnSubmit(lstHd);
                foreach (StockOutBillDtl item in dtl)
                {
                    item.ID = Guid.NewGuid();
                    item.HdID = hd.ID;
                }
                dcc.StockOutBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, StockOutBillHd hd)
        {
            dcc.StockOutBillHd.Attach(hd);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
        }

        public void Delete(DCC dcc, Guid hdID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                StockOutBillHd lstHd = dcc.StockOutBillHd.FirstOrDefault(o => o.ID == hdID);
                dcc.StockOutBillHd.DeleteOnSubmit(lstHd);
                var lstDtl = dcc.StockOutBillDtl.Where(o => o.HdID == hdID);                
                dcc.StockOutBillDtl.DeleteAllOnSubmit(lstDtl);
                if (lstHd.Type==0)//删除发货单
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
