using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonLibrary
{
    /// <summary>
    /// 工具栏接口
    /// </summary>
    public interface IToolbar
    {
        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="image">图标</param>
        /// <param name="onClick">事件处理逻辑</param>
        void AddButton(
            string text,
            Image image,
            EventHandler onClick);

        /// <summary>
        /// 添加工具栏项
        /// </summary>
        /// <param name="item">工具栏项</param>
        void AddToolStripItem(ToolStripItem item);
    }
}
