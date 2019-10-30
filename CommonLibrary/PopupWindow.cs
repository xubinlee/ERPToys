using System;
using System.Drawing;
using CommonLibrary;

namespace ICP.Framework.ClientComponents.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PopupWindow : DevExpress.XtraEditors.XtraForm,
         IErrorDisplayer
    {
        /// <summary>
        /// 
        /// </summary>
        public PopupWindow()
        {
            InitializeComponent();

            this.Load += new EventHandler(ExceptionsPopupWindow_Load);
        }

        void ExceptionsPopupWindow_Load(object form, EventArgs e)
        {

            errorInfoControl1.CurrentOwner = this;
            //错误面板设置
            dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            this.errorInfoControl1.OnShowPanel += delegate(object sender, EventArgs e1)
            {
                if (this.Height < 268)
                {
                    this.Height += 80;
                }

                dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
                dockPanel1.Show();
            };
            this.errorInfoControl1.OnHidePanel += delegate(object sender, EventArgs e2)
            {
                dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            };
         
        }

        /// <summary>
        /// 
        /// </summary>
        public ErrorInfoControl ErrorListControl
        {
            get
            {
                return this.errorInfoControl1;
            }
        }

        #region IErrorDisplayer 成员

        /// <summary>
        /// 
        /// </summary>
        public IErrorTraceService TraceService
        {
            get { return this.ErrorListControl; }
        }

        #endregion

        private void PopupWindow_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                this.Close();
            }
        }


    }
}
