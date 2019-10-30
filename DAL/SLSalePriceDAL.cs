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
    public class SLSalePriceDAL : IDALBase
    {
        public List<SLSalePrice> GetSLSalePrice(DCC dcc, Guid businessContactID)
        {
            return dcc.SLSalePrice.Where(o => o.ID == businessContactID).ToList();
        }

        public List<SLSalePrice> GetSLSalePrice(DCC dcc)
        {
            return dcc.SLSalePrice.ToList();
        }

        public void Insert(DCC dcc, SLSalePrice obj)
        {
            dcc.SLSalePrice.InsertOnSubmit(obj);
        }

        public void Insert(DCC dcc, List<SLSalePrice> list)
        {
            dcc.SLSalePrice.InsertAllOnSubmit(list);
            dcc.SubmitChanges();
        }

        public void Update(DCC dcc, SLSalePrice obj)
        {
            dcc.SLSalePrice.Attach(obj);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, obj);
        }

        public void Update(DCC dcc, Guid businessContactID, List<SLSalePrice> list)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                var lst = dcc.SLSalePrice.Where(o => o.ID == businessContactID);
                dcc.SLSalePrice.DeleteAllOnSubmit(lst);
                dcc.SLSalePrice.InsertAllOnSubmit(list);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Delete(DCC dcc, Guid businessContactID)
        {
            var lst = dcc.SLSalePrice.Where(o => o.ID == businessContactID);
            dcc.SLSalePrice.DeleteAllOnSubmit(lst);
            dcc.SubmitChanges();
        }
    }
}
