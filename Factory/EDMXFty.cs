using EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Utility.Interceptor;

namespace Factory
{
    public class EDMXFty
    {
        public static ERPToysContext Dc
        {
            get
            {
                // 解决【对象名 'dbo.EdmMetadata和dbo .__MigrationHistory' 无效。】的问题
                // 由于数据库已经存在，不会有dbo.EdmMetadata和dbo .__MigrationHistory表
                Database.SetInitializer<ERPToysContext>(null);
                // 注册侦听器
                //1.记录执行非异步命令时的警告信息
                //2.记录执行任何命令引发的异常信息
                DbInterception.Add(new NLogCommandInterceptor());
                ERPToysContext db = new ERPToysContext();// new DbContext(ConfigInfo.SqlConStr);
                return db;
            }
        }
    }
}
