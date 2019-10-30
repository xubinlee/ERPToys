using System;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010;
using DBML;

namespace USL
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public partial class GroupItemDetailPage : DevExpress.XtraEditors.XtraUserControl
    {
        PageGroup pageGroupCore;
        int indexCore;
        MainMenu mainMenu;
        public GroupItemDetailPage(MainMenu item, PageGroup child, int index)
        {
            InitializeComponent();
            mainMenu = item;
            pageGroupCore = child;
            indexCore = index;
            //labelTitle.Text = item.Title;
            labelTitle.Text = item.Caption;
            //labelSubtitle.Text = item.Subtitle;
            if (item.ImagePath !=null)
            imageControl.Image = DevExpress.Utils.ResourceImageHelper.CreateImageFromResources(item.ImagePath, typeof(ItemDetailPage).Assembly);
            //labelDescription.Text = item.Description;
        }
        private void imageControlClick(object sender, EventArgs e)
        {
            BaseContentContainer documentContainer = pageGroupCore.Parent as BaseContentContainer;
            if (documentContainer != null) ActivateContainer(documentContainer.Manager);
        }
        void ActivateContainer(DocumentManager manager)
        {
            WindowsUIView view = manager.View as WindowsUIView;
            if (view != null)
            {
                if (MainForm.hasItemDetailPage[mainMenu.Name] == null)
                {
                    MainForm.itemDetailPageList[mainMenu.Name].LoadBusinessData(mainMenu);
                    MainForm.hasItemDetailPage.Add(mainMenu.Name, true);
                }
                pageGroupCore.Parent = this.Tag as IContentContainer;
                pageGroupCore.SetSelected(pageGroupCore.Items[indexCore]);
                view.ActivateContainer(pageGroupCore);
            }
        }
    }
}
