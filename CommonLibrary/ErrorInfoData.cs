using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CommonLibrary
{
    /// <summary>
    /// 错误信息对象
    /// </summary>
    public class ErrorInfoData
    
    
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        public ErrorInfoData(
             Control owner,
            string message)
        {
            this.Owner = owner;
            this.Message = message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        /// <param name="className"></param>
        /// <param name="fieldName"></param>
        public ErrorInfoData(
             Control owner,
            string message,
            string className,
            string fieldName)
        {
            this.Owner = owner;
            this.Message = message;
            this.ClassName = className;
            this.FieldName = fieldName;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        public ErrorInfoData(
            ErrorInfoType errorType,
             Control owner,
            string message)
        {
            this.ErrorType = errorType;
            this.Owner = owner;
            this.Message = message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="exception"></param>
        public ErrorInfoData(
             Control owner,
            Exception exception)
        {
            this.Owner = owner;
            this.Exception = exception;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="owner"></param>
        /// <param name="exception"></param>
        public ErrorInfoData(
           ErrorInfoType errorType,
            Control owner,
           Exception exception)
        {
            this.Owner = owner;
            this.Exception = exception;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="owner"></param>
        /// <param name="exception"></param>
        /// <param name="image"></param>
        /// <param name="targetControl"></param>
        public ErrorInfoData(
         ErrorInfoType errorType,
         Control owner,
         Exception exception,
         Image image,
         Control targetControl)
        {
            this.Owner = owner;
            this.Exception = exception;
            this.ErrorType = errorType;
            this.ScreenImage = image;
            this.TargetControl = targetControl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="owner"></param>
        /// <param name="exception"></param>
        /// <param name="image"></param>
        /// <param name="targetControl"></param>
        /// <param name="className"></param>
        /// <param name="filedName"></param>
        public ErrorInfoData(
        ErrorInfoType errorType,
        Control owner,
        Exception exception,
        Image image,
        Control targetControl,
        string className,
        string filedName)
        {
            this.Owner = owner;
            this.Exception = exception;
            this.ErrorType = errorType;
            this.ScreenImage = image;
            this.TargetControl = targetControl;
            this.ClassName = className;
            this.FieldName = filedName;
        }


        /// <summary>
        /// 错误信息类型
        /// </summary>
        public ErrorInfoType ErrorType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Control Owner { get; set; }

        /// <summary>
        /// 模块名
        /// </summary>
        public string ModuleName
        {
            get
            {
                if (this.Owner != null)
                {
                    return this.Owner.Text;
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 属性名
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public Exception Exception { get; set; }

        string _message;
        /// <summary>
        /// 消息提示文本
        /// </summary>
        public string Message
        {
            get
            {
                if (this.Exception != null)
                {
                    _message = ClientHelper.GetErrorMessage(this.Exception);
                }
                return _message;
            }
            set
            {
                _message = value;
            }
        }

        /// <summary>
        /// 错误发生时候的抓屏图象(方便发送给系统管理查看原因)
        /// </summary>
        public Image ScreenImage { get; set; }

        Control _targetControl = null;
        /// <summary>
        /// 对应的目标控件
        /// </summary>
        public Control TargetControl
        {
            get
            {
                if (_targetControl != null)
                {
                    return _targetControl;
                }
                if (string.IsNullOrEmpty(this.FieldName))
                {
                    return null;
                }

                if (this.Owner != null)
                {
                    Control bingdingControl = GetControlByDataBindingProperty(this.Owner, this.FieldName);
                    _targetControl = bingdingControl;
                }

                return _targetControl;
            }
            set
            {
                _targetControl = value;
            }
        }

        private Control GetControlByDataBindingProperty(Control control, string propertyName)
        {
            if (control is DevExpress.XtraGrid.GridControl)
            {
                DevExpress.XtraGrid.GridControl gridControl = control as DevExpress.XtraGrid.GridControl;
                DevExpress.XtraGrid.Views.Grid.GridView mainView = (DevExpress.XtraGrid.Views.Grid.GridView)gridControl.MainView;
                if (mainView.DataSource == null) return null;

                BindingSource bs = mainView.DataSource as BindingSource;
                if (bs == null || bs.DataSource == null) return null;

                if (bs.DataSource.GetType().FullName.Contains(this.ClassName))
                {
                    return control;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                foreach (Binding bingding in control.DataBindings)
                {
                    if (bingding.BindingMemberInfo.BindingField == propertyName)
                    {
                        return bingding.Control;
                    }
                }

                foreach (Control child in control.Controls)
                {
                    Control temp = GetControlByDataBindingProperty(child, propertyName);
                    if (temp != null)
                    {
                        return temp;
                    }
                }

                return null;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ErrorInfoType
    {
        /// <summary>
        /// 错误
        /// </summary>
        Error,

        /// <summary>
        /// 信息
        /// </summary>
        Infomation
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ErrorMessage
    {
        /// <summary>
        /// 
        /// </summary>
        public ErrorMessage()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Number")]
        public string Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Message")]
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Property")]
        public string Property { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ErrorMessages
    {
        /// <summary>
        /// 
        /// </summary>
        public ErrorMessages()
        {
            this.Messages = new List<ErrorMessage>();
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("ErrorMessage")]
        public List<ErrorMessage> Messages { get; set; }

    }
}
