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
    public class GoodsService : ServiceBase, IGoodsService
    {
        public List<Goods> GetGoods()
        {
            return BLLFty.Create<GoodsBLL>().GetGoods();
        }

        public Goods GetGoods(Guid id)
        {
            return BLLFty.Create<GoodsBLL>().GetGoods(id);
        }

        public List<VGoods> GetVGoods()
        {
            return BLLFty.Create<GoodsBLL>().GetVGoods();
        }

        public List<VGoodsByBOM> GetVGoodsByBOM()
        {
            return BLLFty.Create<GoodsBLL>().GetVGoodsByBOM();
        }

        public List<VGoodsByMoldAllot> GetVGoodsByMoldAllot()
        {
            return BLLFty.Create<GoodsBLL>().GetVGoodsByMoldAllot();
        }

        public List<VMaterial> GetVMaterial()
        {
            return BLLFty.Create<GoodsBLL>().GetVMaterial();
        }

        public List<VParentGoodsByBOM> GetVParentGoodsByBOM()
        {
            return BLLFty.Create<GoodsBLL>().GetVParentGoodsByBOM();
        }

        public void Import(List<Goods> insertList, List<Goods> updateList)
        {
            BLLFty.Create<GoodsBLL>().Import(insertList, updateList);
        }

        public void Insert(Goods obj)
        {
            BLLFty.Create<GoodsBLL>().Insert(obj);
        }

        public bool IsExist(Goods goods)
        {
            return BLLFty.Create<GoodsBLL>().IsExist(goods);
        }

        public void Update(Goods obj)
        {
            BLLFty.Create<GoodsBLL>().Update(obj);
        }

        public void Delete(Guid id)
        {
            BLLFty.Create<AlertBLL>().GetAlert();
        }
    }
}

