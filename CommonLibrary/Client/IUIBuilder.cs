using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonLibrary.Client
{
    /// <summary>
    /// UI 生成器
    /// </summary>
    public interface IUIBuilder
    {
        /// <summary>
        /// 显示在指定场景的Workpace里
        /// </summary>
        /// <param name="workitem">Workitem</param>
        /// <param name="workspaceName">WorkSpace名称</param>
        /// <param name="title">标题</param>
        /// <param name="layout">布局类</param>
        void Build(WorkItem workitem, string workspaceName, string title, UILayout layout);


        /// <summary>
        /// 显示在指定场景的Workpace里
        /// </summary>
        /// <param name="workitem">Workitem</param>
        /// <param name="workspace">WorkSpace</param>
        /// <param name="title">标题</param>
        /// <param name="layout">布局类</param>
        void Build(WorkItem workitem, IWorkspace workspace, string title, UILayout layout);

        /// <summary>
        /// 显示在指定容器控件中
        /// </summary>
        /// <param name="workitem">WorkItem</param>
        /// <param name="container">容器</param>
        /// <param name="title">标题</param>
        /// <param name="layout">布局类</param>
        void Build(WorkItem workitem, Control container, string title, UILayout layout);
    }
}
