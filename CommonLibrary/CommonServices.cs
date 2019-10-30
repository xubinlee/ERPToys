using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    /// <summary>
    /// UI通用服务
    /// </summary>
    public class CommonServices
    {
        public static Action AddInInstallFinishAction;
        static IStatusbar _statusBar;
        /// <summary>
        /// 状态栏服务
        /// </summary>
        public static IStatusbar Statusbar
        {
            get
            {

                return _statusBar;
            }
            set
            {
                _statusBar = value;
            }
        }

        /// <summary>
        /// 工具栏服务
        /// </summary>
        public static IToolbar ToolBar { get; set; }

        static IErrorTraceService _errorTrace;

        /// <summary>
        /// 错误提示服务 
        /// 用于在窗体下方的DockPanel里面显示多条异常信息
        /// </summary>
        public static IErrorTraceService ErrorTrace
        {
            get
            {

                return _errorTrace;
            }
            set
            {
                _errorTrace = value;
            }
        }

        /// <summary>
        /// 桌面管理服务
        /// </summary>
        public static IDesktop Desktop { get; set; }

        /// <summary>
        /// 权限管理服务
        /// </summary>
        //public static PermissionPackage PermissionService { get; set; }
    }
}
