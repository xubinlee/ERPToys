using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Client
{
    /// <summary>
    /// 布局基类
    /// </summary>
    public abstract class BaseLayout : IBuilderStrategy, IDisposable
    {
        /// <summary>
        /// 根据布局属性，动态构造界面
        /// </summary>
        /// <param name="context"></param>
        public virtual object BuildUp(ILayoutBuilderContext context)
        {
            return null;
        }

        #region IDisposable 成员

        public virtual void Dispose()
        {

        }

        #endregion
    }
}
