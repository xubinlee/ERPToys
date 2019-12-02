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
using DBML;
using Factory;
using BLL;
using System.Configuration;
using Common;
using System.Linq.Expressions;
using System.Collections;
using IWcfServiceInterface;
using Newtonsoft.Json;
using Utility;

namespace USL
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
            BindData();
        }

        public void BindData()
        {
            List<EDMX.UsersInfo> users = ClientFactory.ExecuteQuery<EDMX.UsersInfo>(string.Empty);
            int i = ClientFactory.ModifyByList<EDMX.UsersInfo>(users);
            //EDMX.UsersInfo u = users[0];
            //u.Remark = "test";
            //int i= ClientFactory.Modify<EDMX.UsersInfo>(u);
            vUsersInfoBindingSource.DataSource = BLLFty.Create<UsersInfoBLL>().GetLoginUsersInfo();
            txtCode.EditValue = Utility.ConfigAppSettings.GetValue("User");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UsersInfo user = BLLFty.Create<UsersInfoBLL>().GetUsersInfo(txtCode.Text.Trim());
            if (user == null)
            {
                XtraMessageBox.Show("用户不存在。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                txtCode.SelectAll();
            }
            else if (user.Password == null || user.Password.Equals(string.Empty))
            {
                XtraMessageBox.Show("该用户没有登录权限，请为该用户设置密码。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                txtCode.SelectAll();
            }
            else if (user.Password != txtPassword.Text.Trim())
            {
                XtraMessageBox.Show("密码不正确。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                txtPassword.SelectAll();
            }
            else
            {
                Utility.ConfigAppSettings.SetValue("User", user.Code);
                MainForm.usersInfo = user;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}