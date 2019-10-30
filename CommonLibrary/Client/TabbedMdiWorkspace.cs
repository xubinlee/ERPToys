using CABDevExpress.SmartPartInfos;
using CABDevExpress.Workspaces;
using DevExpress.XtraTabbedMdi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonLibrary.Client
{
    /// <summary>
    /// A workspace that displays smart parts within a <see cref="XtraTabbedMdiWorkspace"/>
    /// <remarks>
    /// </remarks>
    /// </summary>
    [Description("XtraTabbedMdi Workspace")]
    public class TabbedMdiWorkspace : XtraWindowWorkspace
    {
        private readonly XtraTabbedMdiManager tabbedMdiManager = new XtraTabbedMdiManager();
        private MdiMode mdiMode = MdiMode.Tabbed;
        private readonly Form parentMdiForm;

        public enum MdiMode
        {
            Tabbed,
            Windowed
        }
        public event MdiTabPageEventHandler PageAdded;
        /// <summary>
        /// Initializes a new <see cref="XtraTabWorkspace"/>
        /// </summary>
        public TabbedMdiWorkspace()
            : base()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new <see cref="XtraTabWorkspace"/>
        /// </summary>
        public TabbedMdiWorkspace(Form parentForm)
            : base(parentForm)
        {
            tabbedMdiManager.MdiParent = parentForm;
            parentMdiForm = parentForm;
            parentMdiForm.IsMdiContainer = true;
            Initialize();
            SetMdiMode();

        }

        /// <summary>
        /// Gets the parent MDI form.
        /// </summary>
        public Form ParentMdiForm
        {
            get { return parentMdiForm; }
        }


        public void Initialize()
        {
            // 
            // tabbedMdiManager
            // 
            TabbedMdiManager.AllowDragDrop = DevExpress.Utils.DefaultBoolean.True;
            TabbedMdiManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            //tabbedMdiManager.Controller = this.barAndDockingController1;
            TabbedMdiManager.HeaderButtons = ((DevExpress.XtraTab.TabButtons)(((DevExpress.XtraTab.TabButtons.Next | DevExpress.XtraTab.TabButtons.Close)
            | DevExpress.XtraTab.TabButtons.Default)));
            TabbedMdiManager.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.WhenNeeded;
            TabbedMdiManager.FloatOnDrag = DevExpress.Utils.DefaultBoolean.True;

            //tabbedMdiManager.SelectedPageChanged += new System.EventHandler(this.xtraTabbedMdiManager_SelectedPageChanged);
            // tabbedMdiManager.PageRemoved += new DevExpress.XtraTabbedMdi.MdiTabPageEventHandler(this.xtraTabbedMdiManager_PageRemoved);
            tabbedMdiManager.PageAdded += new MdiTabPageEventHandler(tabbedMdiManager_PageAdded);
            tabbedMdiManager.PageRemoved += new MdiTabPageEventHandler(tabbedMdiManager_PageRemoved);
        }

        void tabbedMdiManager_PageRemoved(object sender, MdiTabPageEventArgs e)
        {

            this.parentMdiForm.SuspendLayout();


            this.parentMdiForm.PerformLayout(null, null);

            this.parentMdiForm.ResumeLayout(false);


        }



        /// <summary>
        /// Shows the form as a child of the specified <see cref="ParentMdiForm"/>.
        /// </summary>
        /// <param name="smartPart">The <see cref="Control"/> to show in the workspace.</param>
        /// <param name="smartPartInfo">The information to use to show the smart part.</param>
        protected override void OnShow(Control smartPart, XtraWindowSmartPartInfo smartPartInfo)
        {
            parentMdiForm.SuspendLayout();

            Form mdiChild = this.GetOrCreateForm(smartPart);

            SetWindowProperties(mdiChild, smartPartInfo);

            SetWindowLocation(mdiChild, smartPartInfo);
            mdiChild.Tag = smartPartInfo;
            mdiChild.MdiParent = parentMdiForm;
            mdiChild.Show();
            mdiChild.BringToFront();
            parentMdiForm.ResumeLayout();

        }

        /// <summary>
        /// 
        /// </summary>
        public XtraTabbedMdiManager TabbedMdiManager
        {
            get { return tabbedMdiManager; }
        }

        private void xtraTabbedMdiManager_SelectedPageChanged(object sender, EventArgs e)
        {
            XtraMdiTabPage page = tabbedMdiManager.SelectedPage;
            if (page != null)
            {
                page.Image = page.MdiChild.Icon.ToBitmap();

                XtraWindowSmartPartInfo smartPartInfo = (XtraWindowSmartPartInfo)page.MdiChild.Tag;
                if (smartPartInfo != null)
                {
                    page.Tooltip = smartPartInfo.Description;
                }
            }

        }

        void tabbedMdiManager_PageAdded(object sender, MdiTabPageEventArgs e)
        {
            XtraWindowSmartPartInfo smartPartInfo = (XtraWindowSmartPartInfo)e.Page.MdiChild.Tag;
            if (smartPartInfo != null
                && string.IsNullOrEmpty(smartPartInfo.Description) == false)
            {
                e.Page.SuperTip = new DevExpress.Utils.SuperToolTip();
                e.Page.SuperTip.Items.AddTitle("提示");
                e.Page.SuperTip.Items.Add(smartPartInfo.Description);
            }
            if (this.PageAdded != null)
            {
                this.PageAdded(sender, e);
            }
            if (smartPartInfo.Title.Equals("邮件") || smartPartInfo.Title.Equals("Email"))
            {
                e.Page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        public void MdiChangeMode()
        {
            mdiMode = (mdiMode == MdiMode.Tabbed) ? MdiMode.Windowed : MdiMode.Tabbed; // Toggle
            SetMdiMode(mdiMode);
        }

        private void SetMdiMode()
        {
            SetMdiMode(mdiMode);
        }

        public void SetMdiMode(MdiMode mode)
        {
            TabbedMdiManager.MdiParent = (mode == MdiMode.Tabbed) ? parentMdiForm : null;
        }

        /// <summary>
        /// Set's Layout of Mdi Mode
        /// </summary>
        /// <param name="layout">one of the values of <see cref="MdiLayout"/> enum</param>
        public void LayoutMdi(MdiLayout layout)
        {
            SetMdiMode(MdiMode.Windowed);
            TabbedMdiManager.MdiParent = null;
            parentMdiForm.LayoutMdi(layout);
        }


    }
}
