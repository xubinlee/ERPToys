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
    public class BOMBLL : IBLLBase
    {
        public List<BOM> GetBOM(Guid parentGoodsID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<BOMDAL>().GetBOM(dcc, parentGoodsID);
            }
        }

        public List<BOM> GetBOM()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<BOMDAL>().GetBOM(dcc);
            }
        }

        public void Insert(List<BOM> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<BOMDAL>().Insert(dcc, list);
                dcc.Save();
            }
        }

        public void Update(int bomType, Guid parentGoodsID, List<BOM> list)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<BOMDAL>().Update(dcc,bomType, parentGoodsID, list);
                dcc.Save();
            }
        }

        public void Delete(Guid parentGoodsID)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<BOMDAL>().Delete(dcc, parentGoodsID);
                dcc.Save();
            }
        }

        public void Import(List<BOM> insertList, List<BOM> deleteList)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<BOMDAL>().Import(dcc, insertList, deleteList);
                dcc.Save();
            }
        }
    }
}
