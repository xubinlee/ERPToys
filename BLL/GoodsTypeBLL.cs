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
    public class GoodsTypeBLL : IBLLBase
    {
        public List<VGoodsType> GetVGoodsType()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<GoodsTypeDAL>().GetVGoodsType(dcc);
            }
        }

        public List<GoodsType> GetGoodsType()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<GoodsTypeDAL>().GetGoodsType(dcc);
            }
        }

        public GoodsType GetGoodsType(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<GoodsTypeDAL>().GetGoodsType(dcc,id);
            }
        }

        public void Insert(GoodsType obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<GoodsTypeDAL>().Insert(dcc, obj);
                dcc.Save();
            }
        }

        public void Update(List<GoodsType> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<GoodsTypeDAL>().Update(dcc, list);
                dcc.Save();
            }
        }

        public void Update(GoodsType obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<GoodsTypeDAL>().Update(dcc, obj);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<GoodsTypeDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
