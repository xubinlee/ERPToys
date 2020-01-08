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
using Factory;
using BLL;
using System.Configuration;
using System.Linq.Expressions;
using System.Collections;
using Utility;
using EDMX;
using Utility.Interceptor;
using System.Data.Entity;
using ClientFactory;

namespace USL
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        private static BaseFactory baseFactory = LoggerInterceptor.CreateProxy<BaseFactory>();
        public LoginForm()
        {
            InitializeComponent();
            //using (ERPToysContext context = EDMXFty.Dc)
            //{
            //    context.UsersInfo.Load();
            //    object o = context.UsersInfo.Local.ToBindingList();
            //}
            BindData();
        }

        public void BindData()
        {
            usersInfoBindingSource.DataSource = baseFactory.GetListByNoTracking<UsersInfo>().FindAll(o => o.IsDel == false && !string.IsNullOrEmpty(o.Password));
            txtCode.EditValue = Utility.ConfigAppSettings.GetValue("User");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UsersInfo user = baseFactory.GetListByNoTracking<UsersInfo>().FirstOrDefault(o => o.Code.Equals(txtCode.Text.Trim()));
            if (user == null)
            {
                XtraMessageBox.Show("用户不存在。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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