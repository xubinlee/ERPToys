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
    /// 设置错误信息服务
    /// </summary>
    public interface IErrorTraceService
    {
        /// <summary>
        /// 错误面板当前关联的窗体控件
        /// </summary>
        Control CurrentOwner { get; set; }

        /// <summary>
        /// 清空所有错误
        /// </summary>
        void Clear();

        /// <summary>
        /// 删除全部与指定控件有关的错误
        /// </summary>
        /// <param name="owner">窗体控件</param>
        void RemoveAll(Control owner);

        /// <summary>
        /// 删除全部与指定控件有关对象的错误
        /// </summary>
        /// <param name="owner">窗体控件</param>
        /// <param name="className">对象类名</param>
        void RemoveAll(
            Control owner,
            string className);

        /// <summary>
        /// 过滤指定控件的错误
        /// </summary>
        /// <param name="owner">窗体控件</param>
        void FilterAll(Control owner);

        /// <summary>
        /// 过滤指定对象的错误
        /// </summary>
        /// <param name="owner">窗体控件</param>
        /// <param name="className">类名</param>
        void FilterAll(
            Control owner,
            string className);

        /// <summary>
        /// 设置指定窗体控件的错误信息
        /// </summary>
        /// <param name="owner">窗体控件</param>
        /// <param name="message">错误信息</param>
        void SetErrorInfo(
            Control owner,
            string message);

        /// <summary>
        /// 设置错误信息
        /// </summary>
        /// <param name="owner">窗体控件</param>
        /// <param name="message">错误消息</param>
        /// <param name="control">窗体控件上与错误信息相关的控件</param>
        void SetErrorInfo(
            Control owner,
            string message,
            Control control);

        /// <summary>
        /// 设置错误信息
        /// </summary>
        /// <param name="owner">窗体控件</param>
        /// <param name="message">错误消息</param>
        /// <param name="className">类名</param>
        /// <param name="filedName">与错误信息相关的对象属性</param>
        void SetErrorInfo(
            Control owner,
            string message,
            string className,
            string filedName);





        /// <summary>
        /// 设置错误消息
        /// </summary>
        /// <param name="owner">窗体控件</param>
        /// <param name="message">错误消息</param>
        /// <param name="image">错误图标</param>
        void SetErrorInfo(
            Control owner,
            string message,
            Image image);

        /// <summary>
        /// 设置错误消息
        /// </summary>
        /// <param name="owner">窗体控件</param>
        /// <param name="message">错误消息</param>
        /// <param name="control">与错误相关的控件</param>
        /// <param name="image">错误图标</param>
        void SetErrorInfo(
            Control owner,
            string message,
            Control control,
            Image image);

        /// <summary>
        /// 设置错误消息
        /// </summary>
        /// <param name="owner">窗体控件</param>
        /// <param name="exception">异常消息</param>
        void SetErrorInfo(
            Control owner,
            Exception exception);

        /// <summary>
        /// 设置错误消息
        /// </summary>
        /// <param name="owner">窗体控件</param>
        /// <param name="exception">错误消息</param>
        /// <param name="image">错误图表</param>
        void SetErrorInfo(
            Control owner,
            Exception exception,
            Image image);

        /// <summary>
        /// 设置错误消息
        /// </summary>
        /// <param name="owner">窗体控件</param>
        /// <param name="exception">异常消息</param>
        /// <param name="control">与错误相关的控件</param>
        void SetErrorInfo(
            Control owner,
            Exception exception,
            Control control);

        /// <summary>
        /// 设置错误消息
        /// </summary>
        /// <param name="owner">窗体控件</param>
        /// <param name="exception">异常消息</param>
        /// <param name="className">类名</param>
        /// <param name="filedName">与错误相关的对象属性</param>
        void SetErrorInfo(
            Control owner,
            Exception exception,
            string className,
            string filedName);

        /// <summary>
        /// 设置错误信息
        /// </summary>
        /// <param name="owner">窗体控件</param>
        /// <param name="exception">异常消息</param>
        /// <param name="control">与错误相关的控件</param>
        /// <param name="image">错误图标</param>
        void SetErrorInfo(
            Control owner,
            Exception exception,
            Control control,
            Image image);

        /// <summary>
        /// 设置成功提示信息
        /// </summary>
        /// <param name="owner">窗体控件</param>
        /// <param name="message">成功提示信息</param>
        void SetSuccessfullyInfo(
            Control owner,
            string message);

        /// <summary>
        /// 显示自定义消息
        /// </summary>
        /// <param name="messageId"></param>
        void ShowMessageBox(int messageId);

        /// <summary>
        /// 显示多个自定义消息
        /// </summary>
        /// <param name="messageIds"></param>
        void ShowMessageBox(int[] messageIds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="messsage"></param>
        /// <param name="icon"></param>
        void ShowMessageBox(string title, string messsage, MessageBoxIcon icon);
        /// <summary>
        /// 批量设置异常信息
        /// </summary>
        /// <param name="errors"></param>
        void SetErrorInfo(List<ErrorInfoData> errors);
    }
}
