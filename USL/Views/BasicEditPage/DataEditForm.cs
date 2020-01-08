using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Navigation;
using Utility;
using IBase;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010.Views;
using System.Collections;
using Factory;
using BLL;
using EDMX;
using DevExpress.XtraGrid.Columns;
using CommonLibrary;
using Utility.Interceptor;
using MainMenu = EDMX.MainMenu;
using ClientFactory;

namespace USL
{
    public partial class DataEditForm : DevExpress.XtraEditors.XtraForm
    {
        private static BaseFactory baseFactory = LoggerInterceptor.CreateProxy<BaseFactory>();
        Dictionary<MainMenu, Object> editPage;
        MainMenu mainMenu;
        PageGroup pageGroupCore;
        IDataEdit dataEditPage;

        public DataEditForm(MainMenu menu, Object obj, PageGroup child)
        {
            InitializeComponent();
            editPage = new Dictionary<MainMenu, object>();
            mainMenu = menu;
            pageGroupCore = child;
            this.Text = mainMenu.Caption;
            if (obj == null)
                this.Text += "—添加";
            CreateToolsButton();
            dataEditPage = CreateEditPage(obj);
            if (obj != null && obj is VSupplier)
            {
                dpMoldAllot.Enabled = true;
                vGoodsByMoldAllotBindingSource.DataSource = baseFactory.GetModelList<VGoodsByMoldAllot>().FindAll(o => o.SupplierID == ((VSupplier)obj).ID);
                gridView.BestFitColumns();
                foreach (GridColumn col in gridView.Columns)
                {
                    if (col.Name.ToUpper().Contains("ID".ToUpper()))
                        col.Visible = false;
                    if (col.ColumnType.Equals(typeof(System.Data.Linq.Binary)))
                    {
                        col.Width = 50;  //调整图片的列宽度
                    }
                    if (col.FieldName == "单价" || col.FieldName == "售价")
                    {
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        col.DisplayFormat.FormatString = "c5";
                    }
                    if (col.FieldName.Contains("金额") || col.FieldName == "额外费用")
                    {
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        col.DisplayFormat.FormatString = "c";
                    }
                    if (col.FieldName == "去税单价")
                    {
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        col.DisplayFormat.FormatString = "c6";
                    }
                }
            }
            else
                dpMoldAllot.Enabled = false;
        }

        IDataEdit CreateEditPage(Object obj)
        {
            IDataEdit de = null;
            switch (Enum.Parse(typeof(MainMenuEnum), mainMenu.Name))
            {

                case MainMenuEnum.Department:
                    if (obj != null)
                        obj = baseFactory.GetModelList<Department>().Find(o => o.ID == ((VDepartment)obj).ID);
                    de = new DeptEditPage(obj);
                    ((DeptEditPage)de).Dock = DockStyle.Fill;
                    panelControl.Controls.Add((DeptEditPage)de);
                    break;
                case MainMenuEnum.Company:
                    if (obj != null)
                        obj = baseFactory.GetModelList<Company>().Find(o => o.ID == ((VCompany)obj).ID);
                    de = new CompanyEditPage(obj);
                    ((CompanyEditPage)de).Dock = DockStyle.Fill;
                    panelControl.Controls.Add((CompanyEditPage)de);
                    break;
                case MainMenuEnum.Supplier:
                    if (obj != null)
                        obj = baseFactory.GetModelList<Supplier>().Find(o => o.ID == ((VSupplier)obj).ID);
                    de = new SupplierEditPage(obj);
                    ((SupplierEditPage)de).Dock = DockStyle.Fill;
                    panelControl.Controls.Add((SupplierEditPage)de);
                    break;
                case MainMenuEnum.UsersInfo:
                    if (obj != null)
                        obj = baseFactory.GetModelList<UsersInfo>().Find(o => o.ID == ((VUsersInfo)obj).ID);
                    de = new UsersEditPage(obj);
                    ((UsersEditPage)de).Dock = DockStyle.Fill;
                    panelControl.Controls.Add((UsersEditPage)de);
                    break;
                case MainMenuEnum.Goods:
                case MainMenuEnum.Material:
                    if (obj != null)
                    {
                        if (obj is VGoods)
                            obj = baseFactory.GetModelList<Goods>().Find(o => o.ID == ((VGoods)obj).ID);
                        else
                            obj = baseFactory.GetModelList<Goods>().Find(o => o.ID == ((VMaterial)obj).ID);
                    }
                    de = new GoodsEditPage(mainMenu, obj);
                    ((GoodsEditPage)de).Dock = DockStyle.Fill;
                    panelControl.Controls.Add((GoodsEditPage)de);
                    break;
                case MainMenuEnum.GoodsType:
                    if (obj != null)
                        obj = baseFactory.GetModelList<GoodsType>().Find(o => o.ID == ((VGoodsType)obj).ID);
                    de = new GoodsTypeEditPage(obj);
                    ((GoodsTypeEditPage)de).Dock = DockStyle.Fill;
                    panelControl.Controls.Add((GoodsTypeEditPage)de);
                    break;
                case MainMenuEnum.Packaging:
                    if (obj != null)
                        obj = baseFactory.GetModelList<Packaging>().Find(o => o.ID == ((VPackaging)obj).ID);
                    de = new PackagingEditPage(obj);
                    ((PackagingEditPage)de).Dock = DockStyle.Fill;
                    panelControl.Controls.Add((PackagingEditPage)de);
                    break;
            }
            return de;
        }

        void CreateToolsButton()
        {
            //添加
            NavButton btnAdd = new NavButton();
            btnAdd.Caption = "添加";
            btnAdd.Glyph = global::USL.Properties.Resources.add;
            btnAdd.Name = "btnAdd";
            btnAdd.ElementClick += btnAdd_ElementClick;
            tileNavPane.Buttons.Add(btnAdd);
            //保存
            NavButton btnSave = new NavButton();
            btnSave.Caption = "保存";
            btnSave.Glyph = global::USL.Properties.Resources.save;
            btnSave.Name = "btnSave";
            btnSave.ElementClick += btnSave_ElementClick;
            tileNavPane.Buttons.Add(btnSave);
            //清空
            NavButton btnClear = new NavButton();
            btnClear.Caption = "清空";
            btnClear.Glyph = global::USL.Properties.Resources.clear;
            btnClear.Name = "btnClear";
            btnClear.ElementClick += btnClear_ElementClick;
            tileNavPane.Buttons.Add(btnClear);
        }

        void btnAdd_ElementClick(object sender, NavElementEventArgs e)
        {
            if (dataEditPage != null)
            {
                dataEditPage.Add();
                this.Text += "—添加";
            }
        }

        void btnSave_ElementClick(object sender, NavElementEventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (dataEditPage != null)
                {
                    this.Text = mainMenu.Caption;
                    if (dataEditPage.Save())
                    {
                        MainMenuEnum menuEnum = (MainMenuEnum)Enum.Parse(typeof(MainMenuEnum), mainMenu.Name);
                        baseFactory.DataPageRefresh(menuEnum);
                        CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "保存成功");
                    }
                }
            }
            catch (Exception ex)
            {
                CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), ex.Message);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        void btnClear_ElementClick(object sender, NavElementEventArgs e)
        {
            if (dataEditPage != null)
            {
                dataEditPage.Clear();
                this.Text += "—添加";
            }
        }
    }
}