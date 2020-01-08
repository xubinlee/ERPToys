using Common;
using DAL;
using EDMX;
using Factory;
using IWcfServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    public class GoodsService : ServiceBase, IGoodsService
    {
        public void AddAndUpdate(List<Goods> insertList, List<Goods> updateList)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                DALFty.Create<BaseDAL>().AddAndUpdate<Goods>(db, insertList, updateList);
            }
        }
    }
}
