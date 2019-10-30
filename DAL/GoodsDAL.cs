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
    public class GoodsDAL : IDALBase
    {
        public List<VGoodsByBOM> GetVGoodsByBOM(DCC dcc)
        {
            return dcc.VGoodsByBOM.OrderBy(o => o.货号).ToList();
        }

        public List<VParentGoodsByBOM> GetVParentGoodsByBOM(DCC dcc)
        {
            return dcc.VParentGoodsByBOM.OrderBy(o => o.货号).ToList();
        }

        public List<VGoodsByMoldAllot> GetVGoodsByMoldAllot(DCC dcc)
        {
            return dcc.VGoodsByMoldAllot.OrderBy(o => o.货号).ToList();
        }

        public List<VGoods> GetVGoods(DCC dcc)
        {
            return dcc.VGoods.OrderBy(o => o.货号).ToList();
        }

        public List<VMaterial> GetVMaterial(DCC dcc)
        {
            return dcc.VMaterial.OrderBy(o => o.货号).ToList();
        }

        public bool IsExist(DCC dcc, Goods goods)
        {
            return dcc.Goods.Any(o => o.ID != goods.ID && o.Code == goods.Code);
        }

        public List<Goods> GetGoods(DCC dcc)
        {
            return dcc.Goods.OrderBy(o => o.Code).ToList();
        }

        public Goods GetGoods(DCC dcc, Guid id)
        {
            return dcc.Goods.FirstOrDefault(o => o.ID == id);
        }

        public void Insert(DCC dcc, Goods obj)
        {
            dcc.Goods.InsertOnSubmit(obj);
        }

        public void Update(DCC dcc, Goods obj)
        {
            obj.UpdateTime = DateTime.Now;
            dcc.Goods.Attach(obj);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, obj);
        }

        public void Update(DCC dcc, List<Goods> list)
        {
            dcc.Goods.AttachAll(list);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, list);
        }

        public void Delete(DCC dcc, Guid id)
        {
            var lst = dcc.Goods.Where(o => o.ID == id);
            dcc.Goods.DeleteAllOnSubmit(lst);
        }

        public void Import(DCC dcc, List<Goods> insertList, List<Goods> updateList)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                if (insertList.Count > 0)
                    dcc.Goods.InsertAllOnSubmit(insertList);
                if (updateList.Count > 0)
                {
                    dcc.Goods.AttachAll(updateList);
                    dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, updateList);
                }
                dcc.SubmitChanges();
                ts.Complete();
            }
        }
    }
}
