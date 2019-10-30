using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    /// <summary>
    /// 服务端，客户端通用常量
    /// </summary>
    public static class GlobalConstants
    {
        /// <summary>
        /// 数据分割符号
        /// </summary>
        public const string DividedSymbol = "&#;";

        /// <summary>
        /// 显示分割符号
        /// </summary>
        public const string ShowDividedSymbol = ";";

        /// <summary>
        /// 新增行ID
        /// </summary>
        public readonly static Guid NewRowID = new Guid("11111111-1111-1111-1111-111111111111");
        /// <summary>
        /// 保存到数据库时间格式字符串
        /// </summary>
        public const string DATETIMEFORMAT = "yyyy-MM-dd HH:mm:ss";
        /// <summary>
        /// 系统版本号字典键值
        /// </summary>
        public const string SystemVersionNo = "versionNo";
    }
}
