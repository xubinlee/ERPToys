using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    /// <summary>
    /// 客户端辅助类
    /// </summary>
    public class ClientHelper
    {
        /// <summary>
        /// 处理数据库主动抛出异常的XML结构的Message属性，返回异常的描述信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetErrorMessage(System.Exception ex)
        {
            if (ex == null || string.IsNullOrEmpty(ex.Message))
            {
                return string.Empty;
            }
            if (ex.Message.Contains("<ErrorMessages><ErrorMessage>"))
            {
                try
                {
                    ErrorMessages errors = SerializerHelper.DeserializeFromString<ErrorMessages>(ex.Message);

                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    for (int i = 0; i < errors.Messages.Count; i++)
                    {
                        sb.AppendFormat("{0}:{1}", errors.Messages[i].Number, errors.Messages[i].Message);
                        sb.AppendLine();
                    }

                    return sb.ToString();
                }
                catch
                {
                    return ex.Message;
                }
            }
            else
            {
                return ex.Message;
            }
        }
    }
}
