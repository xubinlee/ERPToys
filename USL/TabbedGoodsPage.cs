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
using DBML;
using Utility;

namespace USL
{
    public partial class TabbedGoodsPage : DevExpress.XtraEditors.XtraUserControl, IItemDetail, IExtensions
    {
        //Object currentObj;
        DBML.MainMenu mainMenu;
        PageGroup pageGroupCore;
        IList list;
        List<TypesList> types;   //类型列表
        Dictionary<String, DataQueryPage> queryPageList;
        public TabbedGoodsPage(DBML.MainMenu menu, PageGroup child, Dictionary<String, int> childButtonList)
        {
            InitializeComponent();
            mainMenu = menu;
            pageGroupCore = child;
            queryPageList = new Dictionary<String, DataQueryPage>();
            DataQueryPage queryPage = null;
            types = MainForm.dataSourceList[typeof(List<TypesList>)] as List<TypesList>;
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
                i = types.Find(o => o.Type == TypesListConstants.GoodsType && o.Name == panel.Text.Trim()).No;
                list = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type == i);
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
            int i = types.Find(o => o.Type == TypesListConstants.GoodsType && o.Name == MainForm.GoodsBigTypeName).No;
            list = ((List<VMaterial>)MainForm.dataSourceList[typeof(List<VMaterial>)]).FindAll(o => o.Type == i);
            queryPageList[MainForm.GoodsBigTypeName].InitGrid(list);
        }

        public void Add()
        {
            //MainForm.GoodsBigType = types.Find(o =>
            //    o.Type == TypesListConstants.GoodsType && o.Name == documentManager.View.ActiveDocument.Caption).No;
            //queryPageList[documentManager.View.ActiveDocument.Caption].Add();
            MainForm.GoodsBigType=types.Find(o =>
                o.Type == TypesListConstants.GoodsType && o.Name == MainForm.GoodsBigTypeName).No;
            queryPageList[MainForm.GoodsBigTypeName].Add();
            DataRefresh();
        }

        public void Edit()
        {
            MainForm.GoodsBigType = types.Find(o =>
                o.Type == TypesListConstants.GoodsType && o.Name == MainForm.GoodsBigTypeName).No;
            queryPageList[MainForm.GoodsBigTypeName].Edit();
            DataRefresh();
        }

        public void Del()
        {
            MainForm.GoodsBigType = types.Find(o =>
                o.Type == TypesListConstants.GoodsType && o.Name == MainForm.GoodsBigTypeName).No;
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
            MainForm.GoodsBigType = types.Find(o =>
                o.Type == TypesListConstants.GoodsType && o.Name == MainForm.GoodsBigTypeName).No;
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
            MainForm.GoodsBigType = types.Find(o =>
                o.Type == TypesListConstants.GoodsType && o.Name == MainForm.GoodsBigTypeName).No;
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
    }
}
