using Common;
using EDMX;
using IWcfServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace ClientFactory
{
    public class PermissionFactory : IPermissionService
    {
        private static IPermissionService permissionService = ServiceProxyFactory.Create<IPermissionService>("PermissionService");

        RedisHelper redis = new RedisHelper();

        #region 复合操作
        public virtual void DeleteAndAdd(Guid userID, List<Permission> insertList)
        {
            permissionService.DeleteAndAdd(userID, insertList);
        }

        #endregion

        #region 添加

        #endregion

        #region 删除

        #endregion

        #region 修改

        #endregion

        #region 查询


        #endregion
    }
}
