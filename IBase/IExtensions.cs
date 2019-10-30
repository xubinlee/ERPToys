using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBase
{
    public interface IExtensions
    {
        /// <summary>
        /// 导入
        /// </summary>
        void Import();

        /// <summary>
        /// 导出
        /// </summary>
        void Export();

        /// <summary>
        /// 传送数据
        /// </summary>
        void SendData(Object data);

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <returns>收到的数据</returns>
        Object ReceiveData();
    }
}
