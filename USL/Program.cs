using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using Utility;
using DevExpress.XtraEditors;
using System.Configuration;

namespace USL
{
    static class Program
    {
        private static ClientFactory clientFactory = Utility.Interceptor.LoggerInterceptor.CreateProxy<ClientFactory>();
        private static DateTime sysDateTime = DateTime.Now;

        public static DateTime SysDateTime
        {
            get
            {
                return sysDateTime;
            }

            set
            {
                sysDateTime = value;
            }
        }

        static string license = string.Empty;

        public static string License
        {
            get { return license; }
            set { license = value; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //UserLookAndFeel.Default.SkinName = "Visual Studio 2013 Light";
            DevExpress.UserSkins.BonusSkins.Register();
            //if (Security.DataStandardTime().ToString("MM-dd").Equals("02-14") || Security.DataStandardTime().ToString("MM-dd").Equals("02-22"))
            //    UserLookAndFeel.Default.SkinName = "Valentine";
            ////else
            //UserLookAndFeel.Default.SkinName = "Xmas 2008 Blue";
            UserLookAndFeel.Default.SkinName = "Office 2016 Colorfull";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
            license = Utility.ConfigAppSettings.GetValue("License");
            if (license.Equals(Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation())))
            {
                LoginForm loginForm = new LoginForm();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    int trialDay = (Convert.ToDateTime(Security.Decrypt("57D58C8A2BC084018F9968BEFD6705F2")) - sysDateTime).Days;// Security.DataStandardTime()).Days;//2017-12-30
                    //int trialDay = (Convert.ToDateTime(Security.Decrypt("D0EB083A96761F6A1B3E6BB21FD1B850")) - Security.DataStandardTime()).Days;//2017-03-01
                    if (trialDay < 1)
                    {
                        XtraMessageBox.Show("系统已过试用期，购买咨询:15989744575 李先生。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //else if (Security.Encrypt(Security.DataStandardTime().ToString("yyyy-MM-dd")).Equals("7877984B2FAE09F6A4B7C75AC9DD29BC"))//2015-01-01 即不能上网，获取不了系统时间
                    else if (Security.Encrypt(sysDateTime.ToString("yyyy-MM-dd")).Equals("7877984B2FAE09F6A4B7C75AC9DD29BC"))//2015-01-01
                    {
                        XtraMessageBox.Show("系统未授权使用，请联系系统开发人员。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (trialDay <= 5)
                        {
                            XtraMessageBox.Show(string.Format("试用期剩余{0}天，购买咨询:15989744575 李先生。", trialDay), "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        CABApplication application = new CABApplication();
                        application.Run();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("系统未授权使用，请联系系统开发人员。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
