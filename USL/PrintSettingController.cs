using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USL
{
    public class PrintSettingController
    {
        PrintingSystem ps = null;

        //string formName = null;

        PrintableComponentLink link = null;

        bool _IsBill = true;
        /// <summary>
        /// 打印内容是否单据 
        /// </summary>
        public bool IsBill
        {
            get { return _IsBill; }
            set
            {
                _IsBill = value;
            }
        }

        string _PrintCompany = null;
        /// <summary>
        /// 打印时的公司 
        /// </summary>
        public string PrintCompany
        {
            set
            {
                _PrintCompany = value;
            }
        }

        string _PrintHeader = null;
        /// <summary>
        /// 打印时的标题 
        /// </summary>
        public string PrintHeader
        {
            set
            {
                _PrintHeader = value;
            }
        }

        string _PrintSubTitle = null;

        public string PrintSubTitle
        {
            //get { return _PrintSubTitle; }
            set { _PrintSubTitle = value; }
        }

        string _PrintLeftHeader = null;
        /// <summary>
        /// 打印时的左页眉 
        /// </summary>
        public string PrintLeftHeader
        {
            set
            {
                _PrintLeftHeader = value;
            }
        }
        string _PrintCenterHeader = null;
        /// <summary>
        /// 打印时的中页眉 
        /// </summary>
        public string PrintCenterHeader
        {
            set
            {
                _PrintCenterHeader = value;
            }
        }
        string _PrintRightHeader = null;
        /// <summary>
        /// 打印时的右页眉 
        /// </summary>
        public string PrintRightHeader
        {
            set
            {
                _PrintRightHeader = value;
            }
        }
        string _PrintFooter = null;
        /// <summary>
        /// 打印时页脚 
        /// </summary>
        public string PrintFooter
        {
            set
            {
                _PrintFooter = value;
            }
        }
        string _PrintLeftFooter = null;
        /// <summary>
        /// 打印时左页脚 
        /// </summary>
        public string PrintLeftFooter
        {
            set
            {
                _PrintLeftFooter = value;
            }
        }
        string _PrintRightFooter = null;
        /// <summary>
        /// 打印时右页脚 
        /// </summary>
        public string PrintRightFooter
        {
            set
            {
                _PrintRightFooter = value;
            }
        }
        bool _landScape;
        /// <summary>
        /// 页面横纵向 
        /// </summary>
        public bool LandScape
        {
            set { _landScape = value; }
        }

        System.Drawing.Printing.PaperKind _paperKind;
        /// <summary>
        /// 纸型 
        /// </summary>
        public System.Drawing.Printing.PaperKind PaperKind
        {
            set { _paperKind = value; }
        }

        Size _paperSize;
        /// <summary>
        /// 纸张大小
        /// </summary>
        public Size PaperSize
        {
            get { return _paperSize; }
            set { _paperSize = value; }
        }

        ///*纸张宽度 单位定义为毫米mm*/
        //public float PaperWidth
        //{
        //    get { return iSPriner.DefaultPageSettings.PaperSize.Width / 100f * 25.4f; }
        //    set
        //    {
        //        //注意，只有自定义纸张才能修改该属性，否则将导致异常
        //        if (iSPriner.DefaultPageSettings.PaperSize.Kind == PaperKind.Custom)
        //            iSPriner.DefaultPageSettings.PaperSize.Width = (int)(value / 25.4 * 100);
        //    }
        //}

        ///*纸张高度 单位定义为毫米mm*/
        //public float PaperHeight
        //{
        //    get { return (int)iSPriner.PrinterSettings.DefaultPageSettings.PaperSize.Height / 100f * 25.4f; }
        //    set
        //    {
        //        //注意，只有自定义纸张才能修改该属性，否则将导致异常
        //        if (iSPriner.DefaultPageSettings.PaperSize.Kind == PaperKind.Custom)
        //            iSPriner.DefaultPageSettings.PaperSize.Height = (int)(value / 25.4 * 100);
        //    }
        //}

        String _palance;
        /// <summary>
        /// 未结余款
        /// </summary>
        public String Balance
        {
            get { return _palance; }
            set { _palance = value; }
        }
        
        /// <summary>
        /// 打印控制器 
        /// </summary>
        /// <param name="control">要打印的部件</param>
        public PrintSettingController(IPrintable control)
        {
            if (control == null) return;
            Control c = (Control)control;
            //formName = c.FindForm().GetType().FullName + "." + c.Name;
            ps = new DevExpress.XtraPrinting.PrintingSystem();
            link = new DevExpress.XtraPrinting.PrintableComponentLink(ps);
            ps.Links.Add(link);
            link.Component = control;
        }

        void PrintSetting()
        {
            if (_PrintHeader != null)
            //if (_IsBill)
            {
                PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter; 

                //设置页眉 
                //phf.Header.Content.Clear();
                //phf.Header.Content.AddRange(new string[] { _PrintLeftHeader, _IsBill ? _PrintCenterHeader : _PrintSubTitle, _PrintRightHeader });
                //phf.Header.Font = new System.Drawing.Font("宋体", _IsBill ?12:11, _IsBill ? System.Drawing.FontStyle.Regular : System.Drawing.FontStyle.Bold);
                //phf.Header.LineAlignment = BrickAlignment.Far;
                phf.Header.Content.Clear();
                phf.Header.Content.AddRange(new string[] { _PrintLeftHeader, _PrintCenterHeader, _PrintRightHeader });
                phf.Header.Font = new System.Drawing.Font("宋体", _IsBill ? 12 : 11, _IsBill ? System.Drawing.FontStyle.Regular : System.Drawing.FontStyle.Bold);
                phf.Header.LineAlignment = BrickAlignment.Far;

                //设置页脚 
                phf.Footer.Content.Clear();
                phf.Footer.Content.AddRange(new string[] { _PrintLeftFooter, _PrintFooter, _PrintRightFooter });
                phf.Footer.Font = new System.Drawing.Font("宋体", _IsBill ? 12 : 14, System.Drawing.FontStyle.Regular);
                phf.Footer.LineAlignment = BrickAlignment.Near;
            }
            link.CreateMarginalHeaderArea += link_CreateMarginalHeaderArea;
            link.CreateMarginalFooterArea += link_CreateMarginalFooterArea;
            link.AfterCreateAreas += link_AfterCreateAreas;
            link.PaperKind = ps.PageSettings.PaperKind;
            link.CustomPaperSize = _paperSize;
            link.Margins = ps.PageSettings.Margins;
            ////设置间距
            //link.Margins.Left = 0;
            //link.Margins.Right = 0;
            //link.Margins.Bottom = 10;
            link.Landscape = ps.PageSettings.Landscape;
            link.CreateDocument();
        }

        void link_AfterCreateAreas(object sender, EventArgs e)
        {
            if (_PrintHeader.Contains("对账单"))
            {
                if (!string.IsNullOrEmpty(_palance))
                {
                    BrickGraphics bg = new BrickGraphics(ps);
                    bg.Font = new System.Drawing.Font("宋体", 12, FontStyle.Bold);
                    bg.BackColor = Color.Transparent;
                    bg.DefaultBrickStyle.SetAlignment(DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center);
                    TextBrick text = bg.DrawString(_palance, Color.Black, new RectangleF(0, 20, 750, 21), BorderSide.Right);
                }
                if (!string.IsNullOrEmpty(MainForm.Accounts))
                {
                    BrickGraphics bgAccounts = new BrickGraphics(ps);
                    bgAccounts.Font = new System.Drawing.Font("宋体", 14, FontStyle.Bold);
                    bgAccounts.BackColor = Color.Transparent;
                    bgAccounts.DefaultBrickStyle.SetAlignment(DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center);
                    TextBrick textAccounts = bgAccounts.DrawString(MainForm.Accounts.Replace("\\r\\n", "\r\n"), Color.Black, new RectangleF(0, 40, 450, 120), BorderSide.None);
                }
            }
        }

        /// <summary>
        /// 打印预览 
        /// </summary>
        public void Preview()
        {
            try
            {
                //if (DevExpress.XtraPrinting.PrintHelper.IsPrintingAvailable)
                //{
                Cursor.Current = Cursors.AppStarting;
                PrintSetting();
                //汉化 
                //DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active = new Dxperience.LocalizationCHS.DxperienceXtraPrintingLocalizationCHS();
                ps.PreviewFormEx.Show();

                //}
                //else
                //{
                //    Cursor.Current = Cursors.Default;
                //    MessageBox.Show("打印机不可用 ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        void link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            //纯文本信息块，设置一些文字性说明信息，一般设置：简单的说明信息 
            //TextBrick text = e.Graph.DrawString("纯文字信息块", Color.Black, new RectangleF(100, 10, 100, 15), BorderSide.Bottom);

            ////BrickGraphics bg = e.Graph;
            ////bg.Font = new System.Drawing.Font("宋体", 18, FontStyle.Bold);
            
            //////TextBrick text = bg.DrawString(_PrintHeader, Color.Black, new RectangleF(450, 0, (_IsBill ? _PrintHeader.Length * 15 : 120), 21), BorderSide.Bottom);
            ////TextBrick text = bg.DrawString(_PrintHeader, Color.Black, new RectangleF(200, 0, 250, 21), BorderSide.None);
            //页信息块，可以设置页相关信息，一般设置：打印的页码信息 
            //if (_IsBill)
            //{
                PageInfoBrick vPageInfoBrick1 = e.Graph.DrawPageInfo(PageInfo.None, _PrintCompany, Color.Black,
                   new RectangleF(0, 0, 100, 40), BorderSide.None);
                vPageInfoBrick1.LineAlignment = BrickAlignment.None;
                vPageInfoBrick1.Alignment = BrickAlignment.Center;
                vPageInfoBrick1.AutoWidth = true;
                vPageInfoBrick1.Font = new System.Drawing.Font("宋体", 30, FontStyle.Bold);

                PageInfoBrick vPageInfoBrick2 = e.Graph.DrawPageInfo(PageInfo.None, _PrintHeader, Color.Black,
                    new RectangleF(0, 0, 200, _IsBill ? 60 : 20), BorderSide.None);
                vPageInfoBrick2.LineAlignment = BrickAlignment.Center;
                vPageInfoBrick2.Alignment = BrickAlignment.Center;
                vPageInfoBrick2.AutoWidth = true;
                vPageInfoBrick2.Font = new System.Drawing.Font("宋体", 14, FontStyle.Bold);
                //vPageInfoBrick2.Font = new System.Drawing.Font("宋体", _IsBill ? 22 : 14, FontStyle.Bold);
            //}
                ////if (_IsBill)
                ////{
                    //页信息块，可以设置页相关信息，一般设置：打印的页码信息 
                PageInfoBrick vPageInfoBrick3 = e.Graph.DrawPageInfo(PageInfo.None, _PrintSubTitle, Color.Black,
                    new RectangleF(0, 0, 100, _IsBill ? 18 : (_PrintHeader.Contains("对账单") && MainForm.Company.Contains("镇阳") ? 48 : 35)), BorderSide.None);
                    if (_IsBill)
                        vPageInfoBrick3.LineAlignment = BrickAlignment.Center;
                    else
                        vPageInfoBrick3.LineAlignment = BrickAlignment.Far;
                    vPageInfoBrick3.Alignment = BrickAlignment.Center;
                    vPageInfoBrick3.AutoWidth = true;
                    vPageInfoBrick3.Font = new System.Drawing.Font("宋体", 11, FontStyle.Bold);
                    vPageInfoBrick3.BackColor = Color.Transparent;
                ////}
            
        }

        void link_CreateMarginalFooterArea(object sender, CreateAreaEventArgs e)
        {
            if (_IsBill)
            {
                PageInfoBrick vPageInfoBrick1 = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, "第{0}页，共{1}页", Color.Black,
                    new RectangleF(0, 0, 100, 15), BorderSide.None);
                vPageInfoBrick1.LineAlignment = BrickAlignment.Far;
                vPageInfoBrick1.Alignment = BrickAlignment.Far;
                vPageInfoBrick1.AutoWidth = true;
                vPageInfoBrick1.Font = new System.Drawing.Font("宋体", 11f);

                //string pageInfo = string.Empty;
                //if (_IsBill)
                //    pageInfo = "第{0}页，共{1}页" + "\r\n" + "①白存根  ②红客户  ③黄回单";
                //else
                //    pageInfo = "第{0}页，共{1}页";
                PageInfoBrick vPageInfoBrick2 = e.Graph.DrawPageInfo(PageInfo.None, "①白存根  ②红客户  ③黄回单", Color.Black,
                        new RectangleF(0, 0, 100, 18), BorderSide.None);
                vPageInfoBrick2.LineAlignment = BrickAlignment.Far;
                vPageInfoBrick2.Alignment = BrickAlignment.Near;
                vPageInfoBrick2.AutoWidth = true;
            }
            //if (_IsBill)
            //{
            //    PageInfoBrick vPageInfoBrick1 = e.Graph.DrawPageInfo(PageInfo.None, "①白存根  ②红客户  ③黄回单", Color.Black,
            //        new RectangleF(0, 0, 100, 15), BorderSide.None);
            //    vPageInfoBrick1.LineAlignment = BrickAlignment.Far;
            //    vPageInfoBrick1.Alignment = BrickAlignment.Far;
            //    vPageInfoBrick1.AutoWidth = true;
            //    vPageInfoBrick1.Font = new System.Drawing.Font("宋体", 9f);
            //}
            ////string pageInfo = string.Empty;
            ////if (_IsBill)
            ////    pageInfo = "第{0}页，共{1}页" + "\r\n" + "①白存根  ②红客户  ③黄回单";
            ////else
            ////    pageInfo = "第{0}页，共{1}页";
            //PageInfoBrick vPageInfoBrick2 = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, "第{0}页，共{1}页", Color.Black,
            //        new RectangleF(0, 0, 100, 18), BorderSide.None);
            //    vPageInfoBrick2.LineAlignment = BrickAlignment.Center;
            //    vPageInfoBrick2.Alignment = BrickAlignment.Far;
            //    vPageInfoBrick2.AutoWidth = true;
            //    vPageInfoBrick2.Font = new System.Drawing.Font("宋体", 10f);
            //vPageInfoBrick2.Font = new System.Drawing.Font("宋体", 9f, FontStyle.Bold);
            PageInfoBrick logo = e.Graph.DrawPageInfo(PageInfo.None, "【开发公司:冰雪软件】", Color.Gray,
                    new RectangleF(0, 0, 100, 15), BorderSide.None);
            logo.LineAlignment = BrickAlignment.Far;
            logo.Alignment = BrickAlignment.Center;
            logo.AutoWidth = true;
            logo.Font = new System.Drawing.Font("宋体", 9f);
        }

        /// <summary>
        /// 打印 
        /// </summary>
        public void Print()
        {
            try
            {

                //if (DevExpress.XtraPrinting.PrintHelper.IsPrintingAvailable)
                //{
                PrintSetting();
                    
                    //汉化 
                    //DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active = new Dxperience.LocalizationCHS.DxperienceXtraPrintingLocalizationCHS();
                    ps.Print();
                //}
                //else
                //{
                //    Cursor.Current = Cursors.Default;
                //    MessageBox.Show("打印机不可用 ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            finally
            {
            }
        }

        //获取页面设置信息 
        public void LoadPageSetting()
        {

            System.Drawing.Printing.Margins margins = new System.Drawing.Printing.Margins(30, 30, (_IsBill ? 190 : (_PrintHeader.Contains("对账单") ? 145 : 120)), _IsBill ? 70 : 40);
            ////System.Drawing.Printing.Margins margins = new System.Drawing.Printing.Margins(10, 10, (_IsBill ? 160 : 120), _IsBill ? 70 : 40);
            ps.PageSettings.Assign(margins, _paperKind, _paperSize, _landScape);
            //ps.PageSettings.Assign(margins, _paperKind, _landScape);
        }

    }
}
