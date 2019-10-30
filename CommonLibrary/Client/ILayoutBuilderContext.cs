using Microsoft.Practices.CompositeUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonLibrary.Client
{
    /// <summary>
    /// 布局创建上下文
    /// </summary>
    public interface ILayoutBuilderContext
    {
        /// <summary>
        /// 当前所属WorkItem
        /// </summary>
        WorkItem WorkItem { get; set; }

        /// <summary>
        /// 如果是WorkSpace就显示在Workspace中，如果是容器控件则显示在该容器控件中
        /// </summary>
        object Site { get; set; }

        /// <summary>
        /// 记录当前构造的所有控件字典，方便于对各个控件的控制
        /// </summary>
        IDictionary<string, Control> Controls { get; set; }

        /// <summary>
        /// 外界传入其它参数
        /// </summary>
        IDictionary<string, object> Parameters { get; set; }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <returns></returns>
        T GetService<T>();


        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <param name="key">唯一键</param>
        /// <returns></returns>
        T GetService<T>(string key);

        /// <summary>
        /// 父容器
        /// </summary>
        Control Parent { get; set; }
    }
}
