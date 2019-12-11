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
using Common;
using System.Linq.Expressions;
using System.Collections;
using IWcfServiceInterface;
using Newtonsoft.Json;
using Utility;
using EDMX;
using Utility.Interceptor;
using System.Data.Entity;

namespace USL
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        private static IStockInBillService stockInBillService = ServiceProxyFactory.Create<IStockInBillService>("StockInBillService");
        private static ClientFactory clientFactory = LoggerInterceptor.CreateProxy<ClientFactory>();
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
            usersInfoBindingSource.DataSource = clientFactory.GetData<UsersInfo>().FindAll(o => o.IsDel == false && !string.IsNullOrEmpty(o.Password));
            txtCode.EditValue = Utility.ConfigAppSettings.GetValue("User");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UsersInfo user = clientFactory.GetData<UsersInfo>().FirstOrDefault(o => o.Code.Equals(txtCode.Text.Trim()));
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