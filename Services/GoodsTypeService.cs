using Common;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBML;
using BLL;
using Microsoft.Practices.Unity;
using Factory;

namespace Services
{
    public class GoodsTypeService : ServiceBase, IGoodsTypeService
    {
        public List<GoodsType> GetGoodsType()
        {
            return BLLFty.Create<GoodsTypeBLL>().GetGoodsType();
        }

        public GoodsType GetGoodsType(Guid id)
        {
            return BLLFty.Create<GoodsTypeBLL>().GetGoodsType(id);
        }

        public List<VGoodsType> GetVGoodsType()
        {
            return BLLFty.Create<GoodsTypeBLL>().GetVGoodsType();
        }

        public void Insert(GoodsType obj)
        {
            BLLFty.Create<GoodsTypeBLL>().Insert(obj);
        }

        public void Update(GoodsType obj)
        {
            BLLFty.Create<GoodsTypeBLL>().Update(obj);
        }

        public void Update(List<GoodsType> list)
        {
            BLLFty.Create<GoodsTypeBLL>().Update(list);
        }

        public void Delete(Guid id)
        {
            BLLFty.Create<GoodsTypeBLL>().Delete(id);
        }
    }
}

