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
    public class LayoutBuilderContext : ILayoutBuilderContext
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public LayoutBuilderContext()
        {
            this.Controls = new Dictionary<string, Control>();
            this.Parameters = new Dictionary<string, object>();
        }

        /// <summary>
        /// 当前所属WorkItem
        /// </summary>
        public WorkItem WorkItem { get; set; }

        /// <summary>
        /// 如果是WorkSpace就显示在Workspace中，如果是容器控件则显示在该容器控件中
        /// </summary>
        public object Site { get; set; }

        /// <summary>
        /// 记录当前构造的所有控件字典，方便于对各个控件的控制
        /// </summary>
        public IDictionary<string, Control> Controls { get; set; }

        /// <summary>
        /// 获取指定类型的服务
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <returns></returns>
        public T GetService<T>()
        {
            if (this.Controls.Count == 0)
            {
                return default(T);
            }

            foreach (Control c in this.Controls.Values)
            {
                if (c is T)
                {
                    return (T)(object)c;
                }
            }

            return default(T);
        }


        /// <summary>
        /// 获取指定类型的服务
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <param name="key">唯一键</param>
        /// <returns></returns>
        public T GetService<T>(string key)
        {
            if (this.Controls.Count == 0)
            {
                return default(T);
            }

            return (T)(object)this.Controls[key];
        }

        /// <summary>
        /// 外界传入其它参数
        /// </summary>
        public IDictionary<string, object> Parameters { get; set; }

        /// <summary>
        /// 父控件
        /// </summary>
        public Control Parent { get; set; }

    }
}
