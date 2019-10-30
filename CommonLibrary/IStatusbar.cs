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
    /// 状态栏服务
    /// </summary>
    public interface IStatusbar
    {
        /// <summary>
        /// 设置状态栏面板1
        /// </summary>
        /// <param name="text">提示文本</param>
        void SetStatusBarPanel1(string text);

        /// <summary>
        /// 设置状态栏文本信息
        /// </summary>
        /// <param name="text">文本</param>
        void SetStatusBarPanel(string text);

        /// <summary>
        /// 在状态栏上加个Panel
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="image">文本旁的图标</param>
        /// <param name="lifecycleWith">控件</param>
        void SetStatusBarPanel(
            string text,
            Image image,
            Control lifecycleWith);

        /// <summary>
        /// 设置状态栏提示控件
        /// </summary>
        /// <param name="text">提示文本</param>
        /// <param name="iconType">图标类型</param>
        /// <param name="lifecycleWith">提示控件</param>
        void SetStatusBarPanel(
            string text,
            StatusIconType iconType,
            Control lifecycleWith);

        /// <summary>
        /// 设置状态错误提示控件
        /// </summary>
        /// <param name="ex">异常信息</param>
        /// <param name="lifecycleWith">提示控件</param>
        void SetStatusBarPanel(
            Exception ex,
            Control lifecycleWith);

        /// <summary>
        /// 添加一个控件（有处理逻辑的）
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="image">图标</param>
        /// <param name="clickEvent">事件处理逻辑</param>
        void AddNotifyIcon(
            string text,
            Image image,
            EventHandler clickEvent);
    }

    /// <summary>
    /// 状态栏图标样式
    /// </summary>
    public enum StatusIconType
    {
        /// <summary>
        /// 信息提示
        /// </summary>
        Info,

        /// <summary>
        /// 警告
        /// </summary>
        Warning,

        /// <summary>
        /// 错误
        /// </summary>
        Error,
    }
}
