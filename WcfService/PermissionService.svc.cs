using Common;
using DAL;
using EDMX;
using Factory;
using IWcfServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    public class PermissionService : ServiceBase, IPermissionService
    {
        public void DeleteAndAdd(Guid userID, List<Permission> insertList)
        {
            using (ERPToysContext db = EDMXFty.Dc)
            {
                Expression<Func<Permission, bool>> whereExpression = o=>o.UserID.Equals(userID);
                DALFty.Create<BaseDAL>().DeleteAndAdd<Permission>(db, whereExpression, insertList);
            }
        }
    }
}
