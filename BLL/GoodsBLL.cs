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
    public class GoodsBLL : IBLLBase
    {
        public List<VGoodsByBOM> GetVGoodsByBOM()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<GoodsDAL>().GetVGoodsByBOM(dcc);
            }
        }

        public List<VParentGoodsByBOM> GetVParentGoodsByBOM()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<GoodsDAL>().GetVParentGoodsByBOM(dcc);
            }
        }

        public List<VGoodsByMoldAllot> GetVGoodsByMoldAllot()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<GoodsDAL>().GetVGoodsByMoldAllot(dcc);
            }
        }

        public bool IsExist(Goods goods)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<GoodsDAL>().IsExist(dcc, goods);
            }
        }

        public List<VGoods> GetVGoods()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<GoodsDAL>().GetVGoods(dcc);
            }
        }

        public List<VMaterial> GetVMaterial()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<GoodsDAL>().GetVMaterial(dcc);
            }
        }

        public List<Goods> GetGoods()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<GoodsDAL>().GetGoods(dcc);
            }
        }

        public Goods GetGoods(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<GoodsDAL>().GetGoods(dcc, id);
            }
        }

        public void Insert(Goods obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<GoodsDAL>().Insert(dcc, obj);
                dcc.Save();
            }
        }

        public void Update(Goods obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<GoodsDAL>().Update(dcc, obj);
                dcc.Save();
            }
        }

        public void Update(List<Goods> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<GoodsDAL>().Update(dcc, list);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<GoodsDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }

        public void Import(List<Goods> insertList, List<Goods> updateList)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<GoodsDAL>().Import(dcc, insertList, updateList);
                dcc.Save();
            }
        }
    }
}
