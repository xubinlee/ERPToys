using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonLibrary
{
    /// <summary>
    /// 桌面接口
    /// </summary>
    public interface IDesktop
    {
        /// <summary>
        /// 导航指定的网页
        /// </summary>
        /// <param name="url"></param>
        void NavigateUrl(string url);

        /// <summary>
        /// 设置当前桌面Tab为活动面版
        /// </summary>
        void Active();

        /// <summary>
        /// 添加一个控件在桌面指定位置
        /// </summary>
        /// <param name="obj">控件</param>
        /// <param name="dock">停靠样式</param>
        void Add(
            object obj,
            DockStyle dock);
    }
}
