using Common;
using DAL;
using EDMX;
using Factory;
using IWcfServiceInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    public class BaseService : ServiceBase, IBaseService
    {
        #region 添加
        public int Add(object model)
        {
            using (ErpContext db = EDMXFty.Dc)
            {
                return DALFty.Create<BaseDAL>().Add(db, model);
            }
        }
        public void AddByBulkCopy(string entityType, IList list)
        {
            using (ErpContext db = EDMXFty.Dc)
            {
                DALFty.Create<BaseDAL>().AddByBulkCopy(db, entityType, list);
            }
        }
        #endregion

        #region 删除

        #endregion

        #region 修改
        public int Modify(SerializedParam param)
        {
            using (ErpContext db = EDMXFty.Dc)
            {
                Parameter p = param.GetParameter();
                if (p == null)
                    return 0;
                return DALFty.Create<BaseDAL>().Modify(db, p.model);
            }
        }
        public int ModifyByList(SerializedParam param)
        {
            using (ErpContext db = EDMXFty.Dc)
            {
                Parameter p = param.GetParameter();
                if (p == null)
                    return 0;
                return DALFty.Create<BaseDAL>().ModifyByList(db, p.list);
            }
        }
        #endregion

        #region 查询

        public string ExecuteQuery(string entityType, string sql, params SerializedSqlParam[] serPars)
        {
            using (ErpContext db = EDMXFty.Dc)
            {
                SqlParameter[] pars = new SqlParameter[serPars.Length];
                for (int i = 0; i < serPars.Length; i++)
                {
                    pars[i] = (SqlParameter)serPars[i];
                }
                return DALFty.Create<BaseDAL>().ExecuteQuery(db, entityType, sql, pars);
            }
        }
        public string ExecuteQueryByFilter(string entityType, string filter)
        {
            using (ErpContext db = EDMXFty.Dc)
            {
                return DALFty.Create<BaseDAL>().ExecuteQuery(db, entityType, filter);
            }
        }

        public string GetModelList(string entityType)
        {
            using (ErpContext db = EDMXFty.Dc)
            {
                return DALFty.Create<BaseDAL>().GetModelList(db, entityType);
            }
        }
        #endregion
    }
}
