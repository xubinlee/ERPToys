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
    public class SystemInfoFactory : ISystemInfoService
    {
        private static ISystemInfoService systemInfoService = ServiceProxyFactory.Create<ISystemInfoService>("SystemInfoService");

        RedisHelper redis = new RedisHelper();

        #region 添加
        public virtual int AddOrUpdate(SystemStatus entity)
        {
            return systemInfoService.AddOrUpdate(entity);
        }

        #endregion

        #region 删除

        #endregion

        #region 修改

        #endregion

        #region 查询


        #endregion
    }
}
