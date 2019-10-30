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
    public class CustomerSLSalePriceDAL : IDALBase
    {
        public List<CustomerSLSalePrice> GetCustomerSLSalePrice(DCC dcc, Guid customerID)
        {
            return dcc.CustomerSLSalePrice.Where(o => o.CustomerID == customerID).ToList();
        }

        public List<CustomerSLSalePrice> GetCustomerSLSalePrice(DCC dcc)
        {
            return dcc.CustomerSLSalePrice.ToList();
        }

        public void Insert(DCC dcc, CustomerSLSalePrice obj)
        {
            dcc.CustomerSLSalePrice.InsertOnSubmit(obj);
        }

        public void Insert(DCC dcc, List<CustomerSLSalePrice> list)
        {
            dcc.CustomerSLSalePrice.InsertAllOnSubmit(list);
            dcc.SubmitChanges();
        }

        public void Update(DCC dcc, CustomerSLSalePrice obj)
        {
            dcc.CustomerSLSalePrice.Attach(obj);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, obj);
        }

        public void Update(DCC dcc, Guid customerID, List<CustomerSLSalePrice> list)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                var lst = dcc.CustomerSLSalePrice.Where(o => o.CustomerID == customerID);
                dcc.CustomerSLSalePrice.DeleteAllOnSubmit(lst);
                dcc.CustomerSLSalePrice.InsertAllOnSubmit(list);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Delete(DCC dcc, Guid customerID)
        {
            var lst = dcc.CustomerSLSalePrice.Where(o => o.CustomerID == customerID);
            dcc.CustomerSLSalePrice.DeleteAllOnSubmit(lst);
            dcc.SubmitChanges();
        }
    }
}
