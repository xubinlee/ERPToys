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
using EDMX;
using Factory;
using BLL;
using Utility;
using System.Data.Linq;
using CommonLibrary;
using Utility.Interceptor;
using ClientFactory;
using MainMenu = EDMX.MainMenu;

namespace USL
{
    public partial class UsersEditPage : DevExpress.XtraEditors.XtraUserControl, IDataEdit
    {
        private static BaseFactory baseFactory = LoggerInterceptor.CreateProxy<BaseFactory>();
        UsersInfo user = null;
        //List<TypesList> types;   //类型列表
        public UsersEditPage(Object obj)
        {
            InitializeComponent();
            BindData();
            if (MainForm.usersInfo.AttPrivilege == 1)
            {
                lciPassword.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciWageType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciWages.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciSchClassWage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciTimeWage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lciPassword.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciWageType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciWages.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciSchClassWage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciTimeWage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            //types = baseFactory.GetModelList<TypesList>();
            typesListBindingSource.DataSource = EnumHelper.GetEnumValues<PrivilegeTypeEnum>(false);// types.FindAll(o => o.Type == TypesListConstants.PrivilegeType);
            wageTypeBindingSource.DataSource = EnumHelper.GetEnumValues<WageTypeEnum>(false);//types.FindAll(o => o.Type == TypesListConstants.WageType);
            if (obj == null)
            {
                user = new UsersInfo();
                user.AttEnabled = true;
                usersInfoBindingSource.DataSource = user;
            }
            else
            {
                usersInfoBindingSource.DataSource = user = (UsersInfo)obj;
                //user = (UsersInfo)obj;
            }
        }

        public void BindData()
        {
            departmentBindingSource.DataSource = baseFactory.GetModelList<Department>();
        }

        public void Add()
        {
            Clear();
        }

        public bool Save()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                UsersInfo obj = usersInfoBindingSource.DataSource as UsersInfo;
                if (pePhoto.EditValue == System.DBNull.Value)
                    obj.Photo = null;
                else
                {
                    if (pePhoto.EditValue is byte[])
                        obj.Photo = (byte[])pePhoto.EditValue;
                    else
                        obj.Photo = ImageHelper.MakeBuff((Image)pePhoto.EditValue);
                }
                bool isExist = baseFactory.GetModelList<UsersInfo>().Any(o => o.ID != obj.ID && o.AttCardnumber == obj.AttCardnumber && !string.IsNullOrEmpty(o.AttCardnumber) && o.IsDel == false);
                if (isExist)
                {
                    XtraMessageBox.Show(string.Format("考勤卡号：{0}已经存在，不允许添加重复考勤卡号。", obj.AttCardnumber), "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //添加
                //if (user == null)
                if (user.ID==null || user.ID==Guid.Empty)
                {
                    //user = obj;
                    user.ID = Guid.NewGuid();

                    //添加功能权限信息
                    List<Permission> pList = new List<Permission>();
                    List<ButtonPermission> btnList = new List<ButtonPermission>();
                    List<MainMenu> menuList = baseFactory.GetModelList<MainMenu>();
                    int i=0;
                    foreach (MainMenu menu in menuList)
                    {
                        Permission p = new Permission();
                        p.ID = ++i;
                        if (menu.ParentID == null)
                            p.ParentID = 0;
                        else if (menu.SerialNo.ToString().Length > 2)
                            p.ParentID = int.Parse(menu.SerialNo.ToString().Substring(0, menu.SerialNo.ToString().Length - 2));
                        p.SerialNo = menu.SerialNo;
                        p.UserID = user.ID;
                        p.Caption = menu.Caption;
                        p.CheckBoxState = false;
                        pList.Add(p);
                    }
                    //添加按钮权限信息
                    foreach (ButtonType btn in Enum.GetValues(typeof(ButtonType)))
                    {
                        ButtonPermission btnP = new ButtonPermission();
                        btnP.UserID = user.ID;
                        btnP.Name = btn.ToString();
                        btnP.Caption = EnumHelper.GetDescription<ButtonType>(btn, false);
                        btnP.CheckBoxState = false;
                        btnList.Add(btnP);
                    }
                    BLLFty.Create<UsersInfoBLL>().Insert(user, pList, btnList);
                }
                else
                    BLLFty.Create<UsersInfoBLL>().Update(obj);
                //CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "保存成功");
                return true;
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232060)  //违反了PRIMARY KEY约束
                    XtraMessageBox.Show(string.Format("账号:{0}已经存在,请重新设置账号。", user.Code), "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    XtraMessageBox.Show(ex.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        public void Clear()
        {
            //user = null;
            user = new UsersInfo();
            user.AttEnabled = true;
            usersInfoBindingSource.DataSource = user;
            txtName.Focus();
        }

        private void pePhoto_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (pePhoto.EditValue != null && pePhoto.Image != null)
                {
                    ImageHelper.WindowsPhotoViewer(pePhoto.Image);
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
    }
}
