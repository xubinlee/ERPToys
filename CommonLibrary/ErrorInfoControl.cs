

namespace CommonLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.XtraBars;

    /// <summary>
    /// 
    /// </summary>
    public partial class ErrorInfoControl : UserControl, IErrorTraceService
    {
        /// <summary>
        /// 
        /// </summary>
        public ErrorInfoControl()
        {
            InitializeComponent();
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            this.bsErrorInfoList.DataSource = this.Errors;
            this.Disposed += delegate
            {
                this.gridErrorList.DataSource = null;
                if (this.bsErrorInfoList != null)
                {
                    this.bsErrorInfoList.DataSource = null;
                    this.bsErrorInfoList.DataSourceChanged -= this.bsErrorInfoList_DataSourceChanged;
                    this.bsErrorInfoList.Dispose();
                    this.bsErrorInfoList = null;
                    this.OnHidePanel = null;
                    this.OnShowPanel = null;
                    if (this.CurrentOwner != null)
                    {
                       // this.CurrentOwner.Dispose();
                        this.CurrentOwner = null;
                    }
                }
             
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.DesignMode == false)
            {

                InitControls();

                bsErrorInfoList.DataSourceChanged += new EventHandler(bsErrorInfoList_DataSourceChanged);

                this.OnShowPanel += new EventHandler(ErrorInfoControl_OnShowPanel);
                this.OnHidePanel += new EventHandler(ErrorInfoControl_OnHidePanel);
            }
        }

        void ErrorInfoControl_OnHidePanel(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void ErrorInfoControl_OnShowPanel(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void bsErrorInfoList_DataSourceChanged(object sender, EventArgs e)
        {
            //if (bsErrorInfoList.Count == 0)
            //{
            //    if (OnHidePanel != null)
            //    {
            //        OnHidePanel(sender, e);
            //    }
            //}
            //else
            //{
            //    if (OnShowPanel != null)
            //    {
            //        OnShowPanel(sender, e);
            //    }
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnShowPanel;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnHidePanel;

        List<ErrorInfoData> Errors = new List<ErrorInfoData>();

        #region IErrorInfoService 接口

        /// <summary>
        /// 
        /// </summary>
        public Control CurrentOwner
        {
            get
            {
                if (weakReference == null || weakReference.Target ==null)
                {
                    return null;
                }
                else
                {
                    return weakReference.Target as Control;
                }
            }
            set
            {
                if (weakReference == null)
                {
                    weakReference = new WeakReference(value);
                }
                else
                {
                    weakReference.Target = null;
                    weakReference.Target = value;
                }
            }
        }
       

        private WeakReference weakReference;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        public void SetSuccessfullyInfo(Control owner,string message)
        {
            if (CommonServices.Statusbar != null)
            {
                CommonServices.Statusbar.SetStatusBarPanel(message);
            }

            this.RemoveAll(owner);

            if (OnHidePanel != null)
            {
                OnHidePanel(owner, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            Errors.Clear();
            bsErrorInfoList.Clear();

            if (this.Errors.Count == 0)
            {
                if (OnHidePanel != null)
                {
                    OnHidePanel(null, null);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        public void RemoveAll(Control owner)
        {
            if (owner == null)
            {
                owner = this.CurrentOwner;
            }
            if (bsErrorInfoList == null)
            {
                return;
            }
            bsErrorInfoList.Clear();
            Errors.RemoveAll(
                delegate(ErrorInfoData e)
                {
                    return e.Owner == owner || e.Owner == owner.FindForm();
                });

           
            bsErrorInfoList.ResetBindings(false);
            if (this.Errors.Count == 0)
            {
                if (OnHidePanel != null)
                {
                    OnHidePanel(owner, null);
                }
            }
           // this.CurrentOwner = null;
           
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="className"></param>
        public void RemoveAll(Control owner,string className)
        {
            if (owner == null)
            {
                owner = this.CurrentOwner;
            }

            
            Errors.RemoveAll(
                delegate(ErrorInfoData e)
                {
                    return e.Owner == owner && e.ClassName==className;
                });
            this.bsErrorInfoList.ResetBindings(false);
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="className"></param>
        public void FilterAll(Control owner, string className)
        {
            if (owner == null)
            {
                owner = this.CurrentOwner;
            }

            List<ErrorInfoData> errors = Errors.FindAll(
                  delegate(ErrorInfoData e)
                  {
                      return e.Owner == owner && e.ClassName==className;
                  });
            this.Errors = errors;
            bsErrorInfoList.ResetBindings(false);

            //if (bsErrorInfoList.Count == 0)
            //{
            //    if (OnHidePanel != null)
            //    {
            //        OnHidePanel(this, null);
            //    }
            //}
            //else
            //{
            //    if (OnShowPanel != null)
            //    {
            //        OnShowPanel(this, null);
            //    }
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        public void FilterAll(Control owner)
        {
            if (owner == null)
            {
                owner = this.CurrentOwner;
            }
            
            List<ErrorInfoData> errors = Errors.FindAll(
                  delegate(ErrorInfoData e)
                  {
                      return e.Owner == owner;
                  });
            Errors = errors;
            if (bsErrorInfoList != null)
            {
                bsErrorInfoList.ResetBindings(false);
            }
            //if (bsErrorInfoList.Count == 0)
            //{
            //    if (OnHidePanel != null)
            //    {
            //        OnHidePanel(this, null);
            //    }
            //}
            //else
            //{
            //    if (OnShowPanel != null)
            //    {
            //        OnShowPanel(this, null);
            //    }
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        public void SetErrorInfo(
            Control owner,
            string message)
        {
            this.SetErrorInfo(
              owner,
              message,
              string.Empty,
              null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        /// <param name="control"></param>
        public void SetErrorInfo(
            Control owner,
            string message,
            Control control)
        {
            this.SetErrorInfo(
               owner,
               message,
               control,
               null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        /// <param name="image"></param>
        public void SetErrorInfo(
            Control owner,
            string message,
            Image image)
        {
            this.SetErrorInfo(
                owner,
                message,
                null,
                image);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        /// <param name="control"></param>
        /// <param name="image"></param>
        public void SetErrorInfo(
            Control owner,
            string message,
            Control control,
            Image image)
        {
            this.SetErrorInfo(
                  owner,
                  new System.Exception(message),
                  control,
                  null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="exception"></param>
        public void SetErrorInfo(
            Control owner,
            Exception exception)
        {
            this.SetErrorInfo(
               owner,
               exception,
               string.Empty,
               null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="exception"></param>
        /// <param name="image"></param>
        public void SetErrorInfo(
            Control owner,
            Exception exception,
            Image image)
        {
            this.SetErrorInfo(
                owner,
                exception,
                null,
                image);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="exception"></param>
        /// <param name="control"></param>
        public void SetErrorInfo(
            Control owner,
            Exception exception,
            Control control)
        {
            this.SetErrorInfo(
                owner,
                exception,
                control,
                null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        /// <param name="className"></param>
        /// <param name="fieldName"></param>
        public void SetErrorInfo(
           Control owner,
           string message,
           string className,
           string fieldName)
        {
            if (owner == null)
            {
                owner = this.CurrentOwner;
            }
            ErrorInfoData error = new ErrorInfoData(
             owner,
             ExceptionHelper.MaskSqlServerException(message),
             className,
             fieldName);
         
            InsertError(owner, error);
        }
          /// <summary>
        /// 批量设置异常信息
        /// </summary>
        /// <param name="errors"></param>
        public void SetErrorInfo(List<ErrorInfoData> errors)
        {
            if (errors == null || errors.Count <= 0)
            {
                return;
            }
            for (int i = 0; i < errors.Count; i++)
            {
                ErrorInfoData error = errors[i];
                if (error.Owner == null)
                {
                    error.Owner = this.CurrentOwner;
                }
                ErrorInfoData temperror = this.Errors.Find(delegate(ErrorInfoData e) { return error.ClassName == e.ClassName && error.FieldName == e.FieldName && e.Message == error.Message; });
                if (temperror != null)
                {
                    this.Errors.Remove(temperror);
                }

            }
            this.InsertErrors(errors);



        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="exception"></param>
        /// <param name="className"></param>
        /// <param name="fieldName"></param>
        public void SetErrorInfo(
            Control owner,
            Exception exception,
            string className,
            string fieldName)
        {
            if (owner == null)
            {
                owner = this.CurrentOwner;
            }
            ErrorInfoData temperror = this.Errors.Find(delegate(ErrorInfoData e) { return className == e.ClassName && fieldName == e.FieldName && e.Message == exception.Message; });
            if (temperror != null)
            {
                this.Errors.Remove(temperror);
            }
          
            ErrorInfoData error = new ErrorInfoData(
                ErrorInfoType.Error,
                owner,
                exception,
                null,
                null,
                className,
                fieldName);

            InsertError(owner, error);
        }
        private delegate void InsertErrorDelegate(Control owner, List<ErrorInfoData> errors);
        private void InsertError(Control owner,ErrorInfoData error)
        {
            if (this.InvokeRequired)
            {
                InsertErrorDelegate insertDelegate = new InsertErrorDelegate(InnerInsertError);
                this.Invoke(insertDelegate, owner,new List<ErrorInfoData>{error});
            }
            else
            {
                InnerInsertError(owner,new List<ErrorInfoData>{error});
            }
         
        }
        private void InsertErrors(List<ErrorInfoData> errors)
        {
            if (this.InvokeRequired)
            {
                InsertErrorDelegate insertDelegate = new InsertErrorDelegate(InnerInsertError);
                this.Invoke(insertDelegate, null, errors);
            }
            else
            {
                InnerInsertError(null, errors);
            }
        }
        private void InnerInsertError(Control owner, List<ErrorInfoData> errors)
        {
            if (this.IsDisposed)
            {
                return;
            }
            this.ClearLastErrors();

            this.Errors.AddRange(errors);
            this.bsErrorInfoList.DataSource = this.Errors;
            this.bsErrorInfoList.ResetBindings(false);
            if (this.OnShowPanel != null)
            {
                this.OnShowPanel(this, null);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="exception"></param>
        /// <param name="control"></param>
        /// <param name="image"></param>
        public void SetErrorInfo(
            Control owner,
            Exception exception,
            Control control,
            Image image)
        {

            if (owner == null)
            {
                owner = this.CurrentOwner;
            }
            ErrorInfoData error = new ErrorInfoData(
                ErrorInfoType.Error,
                owner,
                exception,
                image,
                control);
          
            InsertError(owner, error);
        }

        /// <summary>
        /// 智能清除上次的提示
        /// 先凑合用
        /// </summary>
        void ClearLastErrors()
        {
            //DockPanel panel = (DockPanel)this.Parent.Parent;
            if (!this.Visible)
            {
                this.RemoveAll(this);
            }
        }


        #endregion


        #region 本地方法,属性

        private void SetCNText()
        {
            colErrorType.Caption = ".";
            colMessage.Caption = "消息";
            colModuleName.Caption = "模块";

            barClear.Caption = "清除(&C)";
            barSendEmail.Caption = "反馈错误";
            barSendEmail.SuperTip = new DevExpress.Utils.SuperToolTip();
            barSendEmail.SuperTip.Items.Add("反馈错误给系统管理员.");
        }

        private void InitControls()
        {
            this.repositoryItemImageComboBox1.Items.Clear();
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("错误", ErrorInfoType.Error, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("警告", ErrorInfoType.Infomation, 0)});
        }

        ErrorInfoData Current
        {
            get
            {
                if (bsErrorInfoList.Count > 0 && bsErrorInfoList.Current != null)
                {
                    return bsErrorInfoList.Current as ErrorInfoData;
                }
                else
                {
                    return null;
                }
            }
        }
        List<ErrorInfoData> ErrorInfoList
        {
            get
            {
                if (bsErrorInfoList.Count > 0)
                {
                    return this.bsErrorInfoList.DataSource as List<ErrorInfoData>;
                }
                else
                {
                    return null;
                }
            }
        }


        #endregion

        #region 事件处理

        private void barClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.RemoveAll(null);
        }

        private void barSendEmail_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (this.ErrorInfoList == null)
            //{
            //    string tip = LocalData.IsEnglish ? "" : "错误列表没有错误记录，是否继续提交?";
            //}
            ////SnapScreenHelper helper = new SnapScreenHelper();
            ////string saveFileName = "Error" + DateTime.Now.ToString("yyyyMMddhhmmssmmmm") + ".png";
            ////string screenImagePath = helper.CaptureFullScreen(saveFileName);
            ////WorkItem workItem = ServiceClient.GetClientService<WorkItem>();
            ////workItem.State["ScreenImagePath"] = screenImagePath;
            ////string errorInfo = BuildErrorInfo();
            ////workItem.State["TotalErrorMessage"] = errorInfo;
            ////workItem.Commands["SYSTEM_NEWFEEDBACK"].Execute();

        }
        /// <summary>
        /// 构建错误信息字符串
        /// </summary>
        /// <returns></returns>
        private string BuildErrorInfo()
        {
            List<ErrorInfoData> errors = this.Errors;
            if (errors == null || errors.Count <= 0)
                return string.Empty;
            string totalMessage = "错误描述:" + Environment.NewLine;
            foreach (ErrorInfoData data in errors)
            {
                string message = string.Empty;
                if (data.Exception != null)
                {
                   message = CommonHelper.BuildExceptionString(data.Exception);
                }
                if (!string.IsNullOrEmpty(data.Message))
                {
                    message = data.Message + Environment.NewLine + message;
                }
                totalMessage += message;

            }
            return totalMessage;
        }
   

        #endregion

        private void gridErrorList_DoubleClick(object sender, EventArgs e)
        {
            if (this.Current == null)
            {
                return;
            }

            if (this.Current.TargetControl != null)
            {
                //this.Current.TargetControl.BackColor = Color.AliceBlue;
                //this.Current.TargetControl.Focus();
                this.SetFocus(this.Current.TargetControl);
            }
        }

        private void SetFocus(Control control)
        {
            Control parentControl=control;
            while (parentControl != this.Current.Owner)
            {
                if (parentControl is DevExpress.XtraTab.XtraTabPage)
                {
                    DevExpress.XtraTab.XtraTabPage page = (DevExpress.XtraTab.XtraTabPage)parentControl;
                    page.TabControl.SelectedTabPage = page;
                }
                parentControl = parentControl.Parent;
            }

            control.Focus();
        }

        #region IErrorTraceService 成员

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        public void ShowMessageBox(int messageId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageIds"></param>
        public void ShowMessageBox(int[] messageIds)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="messsage"></param>
        /// <param name="icon"></param>
        public void ShowMessageBox(string title, string messsage, MessageBoxIcon icon)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(this.FindForm(), messsage, title, MessageBoxButtons.OK, icon);
        }

        #endregion
    }
}
