using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonLibrary.Client
{
    /// <summary>
    /// 默认UI生成器
    /// </summary>
    public class DefaultUIBuilder : IUIBuilder
    {
        static string culture = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
        /// <summary>
        /// 环境语言名
        /// </summary>
        public static string CultureName
        {
            get
            {
                return culture;
            }
            set
            {
                culture = value;
                //isenglish = value.ToLower().Contains("en");
            }
        }

        /// <summary>
        /// 显示在指定场景的Workpace里
        /// </summary>
        /// <param name="workitem">Workitem</param>
        /// <param name="workspaceName">WorkSpace名称</param>
        /// <param name="title">标题</param>
        /// <param name="layout">布局类</param>
        public void Build(WorkItem workitem, string workspaceName, string title, UILayout layout)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(CultureName);

            IWorkspace workspace = workitem.Workspaces[workspaceName];

            this.Build(workitem, workspace, title, layout);
        }


        /// <summary>
        /// 显示在指定场景的Workpace里
        /// </summary>
        /// <param name="workitem">Workitem</param>
        /// <param name="workspace">WorkSpace</param>
        /// <param name="title">标题</param>
        /// <param name="layout">布局类</param>
        public void Build(WorkItem workitem, IWorkspace workspace, string title, UILayout layout)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(CultureName);

            //根据布局生成界面
            Control control = this.BuildUp(workitem, title, layout);

            SmartPartInfo sp = new SmartPartInfo();
            sp.Title = title;
            sp.Description = control.Text;

            //显示界面
            workspace.Show(control, sp);

            control.Disposed += delegate(object orgsender, System.EventArgs ag)
            {

                DisposeWorkItem(workitem);
            };
        }
        private void DisposeWorkItem(WorkItem workItem)
        {
            MethodInfo method = workItem.GetType().GetMethod("Close");
            if (method != null)
            {
                method.Invoke(workItem, null);
            }
            workItem = null;
        }

        /// <summary>
        /// 显示在指定容器控件中
        /// </summary>
        /// <param name="workitem">WorkItem</param>
        /// <param name="container">容器</param>
        /// <param name="title">标题</param>
        /// <param name="layout">布局类</param>
        public void Build(WorkItem workitem, Control container, string title, UILayout layout)
        {

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(CultureName);

            //根据布局生成界面
            Control control = this.BuildUp(workitem, title, layout);

            container.Controls.Add(control);

            control.Disposed += delegate(object orgsender, System.EventArgs ag)
            {
                DisposeWorkItem(workitem);
            };
        }


        private Control BuildUp(WorkItem workitem, string title, UILayout layout)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(CultureName);

            //构造上下文
            LayoutBuilderContext context = new LayoutBuilderContext();
            context.WorkItem = workitem;

            //根据布局生成界面
            Control control = (Control)layout.Layout.BuildUp(context);
            SmartPartInfo sp = new SmartPartInfo();
            sp.Description = control.Text;
            sp.Title = title;

            //连接关系处理逻辑
            foreach (IPartRelation relation in layout.Relations)
            {
                relation.BuildUp(context);
            }
            control.Disposed += delegate(object orgsender, System.EventArgs ag)
            {
                DisposeWorkItem(workitem);
            };

            return control;
        }
    }
}
