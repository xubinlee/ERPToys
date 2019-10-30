using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    /// <summary>
    /// 公共辅助类
    /// </summary>
    public class CommonHelper
    {
        /// <summary>
        /// 构建异常信息
        /// <remarks>递归遍历所有内部异常</remarks>
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>异常及其所有内部异常的Message组合，以及调用参数的StackTrace</returns>
        public static string BuildExceptionString(Exception ex)
        {
            if (ex == null)
                return string.Empty;
            string result = ex.Message;
            Exception innerException = ex.InnerException;
            while (innerException != null)
            {
                result = result + innerException.Message;
                innerException = innerException.InnerException;

            }
            return result + ex.StackTrace;
        }
    }
}
