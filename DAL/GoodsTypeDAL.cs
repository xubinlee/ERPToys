using DBML;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GoodsTypeDAL : IDALBase
    {
        public List<VGoodsType> GetVGoodsType(DCC dcc)
        {
            return dcc.VGoodsType.OrderBy(o => o.类型编码).ToList();
        }

        public List<GoodsType> GetGoodsType(DCC dcc)
        {
            return dcc.GoodsType.OrderBy(o => o.Code).ToList();
        }

        public GoodsType GetGoodsType(DCC dcc,Guid id)
        {
            return dcc.GoodsType.FirstOrDefault(o => o.ID == id);
        }

        public void Insert(DCC dcc, GoodsType obj)
        {
            dcc.GoodsType.InsertOnSubmit(obj);
        }

        public void Update(DCC dcc, List<GoodsType> list)
        {
            dcc.GoodsType.AttachAll(list);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, list);
        }

        public void Update(DCC dcc, GoodsType obj)
        {
            dcc.GoodsType.Attach(obj);
            dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, obj);
        }

        public void Delete(DCC dcc, Guid id)
        {
            var lst = dcc.GoodsType.Where(o => o.ID == id);
            dcc.GoodsType.DeleteAllOnSubmit(lst);
        }
    }
}
