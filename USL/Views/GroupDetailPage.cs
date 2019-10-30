using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System.Collections.Generic;
using DBML;

namespace USL
{
    /// <summary>
    /// A page that displays an overview of a single group, including a preview of the items
    /// within the group.
    /// </summary>
    public partial class GroupDetailPage : XtraUserControl
    {
        PageGroup pageGroupCore;
        public PageGroup PageGroup { get { return pageGroupCore; } }
        //public GroupDetailPage(SampleDataGroup dataGroup, PageGroup child)
        public GroupDetailPage(List<MainMenu> dataGroup, PageGroup child)
        {
            InitializeComponent();
            pageGroupCore = new PageGroup();
            MainMenu parentItem = dataGroup.Find(o => o.ParentID == null);
            //pageGroupCore.Caption = dataGroup.Title;
            pageGroupCore.Caption = parentItem.Caption;
            if (parentItem.ImagePath != null)
                imageControl.Image = DevExpress.Utils.ResourceImageHelper.CreateImageFromResources(parentItem.ImagePath, typeof(MainForm).Assembly);
            List<MainMenu> subItemList = dataGroup.FindAll(o => o.ParentID == parentItem.ID);
            ////labelSubtitle.Text = dataGroup.Subtitle;
            ////labelDescription.Text = dataGroup.Description;
            CreateLayout(subItemList, child);
        }
        //void CreateLayout(SampleDataGroup dataGroup, PageGroup child)
        //{
        //    for (int i = 0; i < dataGroup.Items.Count; i++)
        //        CreateLayoutCore(dataGroup.Items[i], child, i);
        //}
        void CreateLayout(List<MainMenu> dataGroup, PageGroup child)
        {
            for (int i = 0; i < dataGroup.Count; i++)
            {
                //根据用户权限控制是否显示Tile
                ////if (MainForm.userPermissions.Count > 0 && MainForm.userPermissions.Find(o => o.Caption.Trim() == dataGroup[i].Caption.Trim()).CheckBoxState)
                    CreateLayoutCore(dataGroup[i], child, i);
            }
        }
        void CreateLayoutCore(MainMenu item, PageGroup child, int index)
        {
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            DevExpress.XtraLayout.LayoutControlItem layoutTileItem = new DevExpress.XtraLayout.LayoutControlItem();
            GroupItemDetailPage page = new GroupItemDetailPage(item, child, index);
            page.Tag = pageGroupCore;
            layoutTileItem.Control = page;
            layoutTileItem.Location = new System.Drawing.Point(0, 0);
            layoutTileItem.MinSize = new System.Drawing.Size(winLayoutControl1.Width, page.Height);
            layoutTileItem.MaxSize = new System.Drawing.Size(0, page.Height);
            layoutTileItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutTileItem.TextSize = new System.Drawing.Size(0, 0);
            layoutTileItem.TextToControlDistance = 0;
            layoutTileItem.TextVisible = false;
            layoutControlGroup2.Add(layoutTileItem);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
        }
    }
}
