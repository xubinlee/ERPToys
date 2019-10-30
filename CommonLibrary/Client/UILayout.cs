using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Client
{
    /// <summary>
    /// UI布局类
    /// </summary>
    public class UILayout : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public UILayout()
        {
            this.Relations = new List<IPartRelation>();
        }

        /// <summary>
        /// UI布局
        /// </summary>
        public BaseLayout Layout { get; set; }

        /// <summary>
        /// 负责UI的交互
        /// </summary>
        public List<IPartRelation> Relations { get; set; }

        #region IDisposable 成员

        public void Dispose()
        {
            if (this.Layout != null)
            {
                this.Layout.Dispose();
                this.Layout = null;
            }
            if (this.Relations != null)
            {
                this.Relations.Clear();
                this.Relations = null;
            }
        }

        #endregion
    }
}
