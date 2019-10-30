using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Client
{
    /// <summary>
    /// 服务容器接口
    /// </summary>
    public interface IServiceContainer
    {
        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <returns>返回指定类型的服务</returns>
        T GetService<T>();

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <param name="type">服务类型</param>
        /// <returns>返回指定类型的服务</returns>
        object GetService(Type type);




    }
}
