using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IBase;
using DevExpress.XtraBars.Docking;
using System.Collections;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using EDMX;
using Utility;
using MainMenu = EDMX.MainMenu;
using Utility.Interceptor;
using ClientFactory;

namespace USL
{
    public partial class TabbedGoodsPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail, IExtensions
    {
        private static BaseFactory baseFactory = LoggerInterceptor.CreateProxy<BaseFactory>();
        //Object currentObj;
        MainMenu mainMenu;
        PageGroup pageGroupCore;
        IList list;
        List<EnumHelper.ListItem<GoodsBigTypeEnum>> types;   //类型列表
        Dictionary<String, DataQueryPage> queryPageList;
        public TabbedGoodsPage(MainMenu menu, PageGroup child, Dictionary<String, int> childButtonList)
        {
            InitializeComponent();
            mainMenu = menu;
            pageGroupCore = child;
            queryPageList = new Dictionary<String, DataQueryPage>();
            DataQueryPage queryPage = null;
            types = EnumHelper.GetEnumValues<GoodsBigTypeEnum>(false);
            //单据类型
            int i = 0;
            List<DockPanel> dpList;
            if (MainForm.Company.Contains("纸"))
            {
                dpList = dockManager.RootPanels.Where(o => o.Name == "dpMaterial").ToList();
            }
            else
                dpList = dockManager.RootPanels.ToList();
            foreach (DockPanel panel in dpList)
            {
                //i = types.Find(o => o.Type == TypesListConstants.GoodsType && o.Name == panel.Text.Trim()).No;
                i = (int)Enum.Parse(typeof(GoodsBigTypeEnum), panel.Name.Replace("dp", ""));
                list = baseFactory.GetModelList<VMaterial>().FindAll(o => o.Type == i);
                queryPage = new DataQueryPage(menu, list, child, childButtonList);
                queryPage.Dock = DockStyle.Fill;
                panel.Controls.Add(queryPage);
                queryPageList.Add(panel.Text.Trim(), queryPage);
                //MainForm.SetQueryPageGridColumn(queryPage.gridView, menu);
            }
            MainForm.GoodsBigTypeName = "包装资料";
            ////去掉模具资料面板
            //tabbedView1.Documents.Remove(document4);
            //dockManager.RemovePanel(dpMold);
        }

        public void DataRefresh()
        {
            //int i = types.Find(o => o.Type == TypesListConstants.GoodsType && o.Name == MainForm.GoodsBigTypeName).No;
            int i = types.FirstOrDefault(o => o.Name.Equals(MainForm.GoodsBigTypeName)).Index;
            list = baseFactory.GetModelList<VMaterial>().FindAll(o => o.Type == i);
            queryPageList[MainForm.GoodsBigTypeName].BindData(list);
        }

        public void Add()
        {
            //MainForm.GoodsBigType = types.Find(o =>
            //    o.Type == TypesListConstants.GoodsType && o.Name == documentManager.View.ActiveDocument.Caption).No;
            //queryPageList[documentManager.View.ActiveDocument.Caption].Add();
            //MainForm.GoodsBigType=types.Find(o =>
            //o.Type == TypesListConstants.GoodsType && o.Name == MainForm.GoodsBigTypeName).No;
            MainForm.GoodsBigType = types.FirstOrDefault(o => o.Name.Equals(MainForm.GoodsBigTypeName)).Index;
            queryPageList[MainForm.GoodsBigTypeName].Add();
            DataRefresh();
        }

        public void Edit()
        {
            MainForm.GoodsBigType = types.FirstOrDefault(o => o.Name.Equals(MainForm.GoodsBigTypeName)).Index;
            queryPageList[MainForm.GoodsBigTypeName].Edit();
            DataRefresh();
        }

        public void Del()
        {
            MainForm.GoodsBigType = types.FirstOrDefault(o => o.Name.Equals(MainForm.GoodsBigTypeName)).Index;
            queryPageList[MainForm.GoodsBigTypeName].Del();
            DataRefresh();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Audit()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            MainForm.GoodsBigType = types.FirstOrDefault(o => o.Name.Equals(MainForm.GoodsBigTypeName)).Index;
            queryPageList[MainForm.GoodsBigTypeName].Print();
        }

        private void documentManager_DocumentActivate(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
        {
            if (e.Document != null)
                MainForm.GoodsBigTypeName = e.Document.Caption;
        }

        public void Import()
        {
            throw new NotImplementedException();
        }

        public void Export()
        {
            //借用于设置货品停产
            MainForm.GoodsBigType = types.FirstOrDefault(o => o.Name.Equals(MainForm.GoodsBigTypeName)).Index;
            queryPageList[MainForm.GoodsBigTypeName].Export();
            DataRefresh();
        }

        public void SendData(object data)
        {
            throw new NotImplementedException();
        }

        public object ReceiveData()
        {
            throw new NotImplementedException();
        }

        public void BindData(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
