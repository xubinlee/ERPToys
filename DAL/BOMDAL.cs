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
    public class BOMDAL : IDALBase
    {
        public List<BOM> GetBOM(DCC dcc, Guid parentGoodsID)
        {
            return dcc.BOM.Where(o => o.ParentGoodsID == parentGoodsID).ToList();
        }

        public List<BOM> GetBOM(DCC dcc)
        {
            return dcc.BOM.ToList();
        }


        public void Insert(DCC dcc, List<BOM> list)
        {
            dcc.BOM.InsertAllOnSubmit(list);
            dcc.SubmitChanges();
        }

        public void Update(DCC dcc,int bomType, Guid parentGoodsID,  List<BOM> list)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                //更新明细可能有新增记录，所有先将原有记录删除再全部添加
                var lst = dcc.BOM.Where(o => o.Type == bomType && o.ParentGoodsID == parentGoodsID);
                dcc.BOM.DeleteAllOnSubmit(lst);
                dcc.BOM.InsertAllOnSubmit(list);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }

        public void Delete(DCC dcc, Guid parentGoodsID)
        {
            var lst = dcc.BOM.Where(o => o.ParentGoodsID == parentGoodsID);
            dcc.BOM.DeleteAllOnSubmit(lst);
            dcc.SubmitChanges();
        }

        public void Import(DCC dcc, List<BOM> insertList, List<BOM> deleteList)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                //if (updateList.Count > 0)
                //{
                //    dcc.BOM.AttachAll(updateList);
                //    dcc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, updateList);
                //}
                if (deleteList.Count > 0)
                {
                    //dcc.BOM.AttachAll(deleteList);//附加实体---增加此段代码即可解决“无法删除尚未附加的实体”问题 
                    foreach (BOM item in deleteList)
                    {
                        var list = dcc.BOM.Where(o => o.ParentGoodsID == item.ParentGoodsID);
                        dcc.BOM.DeleteAllOnSubmit(list);
                    }
                }
                if (insertList.Count > 0)
                    dcc.BOM.InsertAllOnSubmit(insertList);
                dcc.SubmitChanges();
                ts.Complete();
            }
        }
    }
}
