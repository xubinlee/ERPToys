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
    public class MaterielOutStoreBillDAL : IDALBase
    {
        public string GetMaxBillNo(DCC dcc)
        {
            return dcc.MaterielOutStoreBillHd.Max(o => o.BillNo);
        }

        public MaterielOutStoreBillHd GetMaterielOutStoreBillHd(DCC dcc, Guid id)
        {
            return dcc.MaterielOutStoreBillHd.FirstOrDefault(o => o.ID == id);
        }

        public List<MaterielOutStoreBillDtl> GetMaterielOutStoreBillDtl(DCC dcc, Guid hdID)
        {
            return dcc.MaterielOutStoreBillDtl.Where(o => o.HdID == hdID).ToList();
        }

        public List<MaterielOutStoreBillDtl> GetVBillDtlByBOM(DCC dcc, Guid hdID)
        {
            List<MaterielOutStoreBillDtl> dtlList = new List<MaterielOutStoreBillDtl>();
            List<VBillDtlByBOM> list = dcc.VBillDtlByBOM.Where(o => o.HdID == hdID).ToList();
            foreach (VBillDtlByBOM item in list)
            {
                MaterielOutStoreBillDtl dtl = new MaterielOutStoreBillDtl();
                dtl.ID = item.ID;
                dtl.HdID = item.HdID;
                dtl.GoodsID = item.GoodsID;
                dtl.Qty = item.Qty.Value;
                dtl.PCS = item.PCS;
                dtl.InnerBox = item.InnerBox;
                dtl.Price = item.Price;
                dtl.PriceNoTax = item.PriceNoTax;
                dtlList.Add(dtl);
            }
            return dtlList;
        }

        public List<VMaterielOutStoreBill> GetMaterielOutStoreBill(DCC dcc)
        {
            return dcc.VMaterielOutStoreBill.OrderByDescending(o => o.出库单号).ToList();
        }


        public void Insert(DCC dcc, MaterielOutStoreBillHd hd, List<MaterielOutStoreBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.MaterielOutStoreBillHd.InsertOnSubmit(hd);
                dcc.MaterielOutStoreBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Update(DCC dcc, MaterielOutStoreBillHd hd, List<MaterielOutStoreBillDtl> dtl)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                dcc.MaterielOutStoreBillHd.Attach(hd);
                dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, hd);
                //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                var lstHd = dcc.MaterielOutStoreBillDtl.Where(o => o.HdID == hd.ID);
                dcc.MaterielOutStoreBillDtl.DeleteAllOnSubmit(lstHd);
                foreach (MaterielOutStoreBillDtl item in dtl)
                {
                    item.ID = Guid.NewGuid();
                    item.HdID = hd.ID;
                }
                dcc.MaterielOutStoreBillDtl.InsertAllOnSubmit(dtl);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Delete(DCC dcc, Guid hdID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var lstDtl = dcc.MaterielOutStoreBillHd.Where(o => o.ID == hdID);
                dcc.MaterielOutStoreBillHd.DeleteAllOnSubmit(lstDtl);
                var lstHd = dcc.MaterielOutStoreBillDtl.Where(o => o.HdID == hdID);
                dcc.MaterielOutStoreBillDtl.DeleteAllOnSubmit(lstHd);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }
    }
}
