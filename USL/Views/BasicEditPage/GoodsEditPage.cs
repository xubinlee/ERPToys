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
using System.Data.Linq;
using IBase;
using EDMX;
using BLL;
using Factory;
using Utility;
using CommonLibrary;
using System.IO;
using MainMenu = EDMX.MainMenu;
using Utility.Interceptor;

namespace USL
{
    public partial class GoodsEditPage : DevExpress.XtraEditors.XtraUserControl, IDataEdit
    {
        private static ClientFactory clientFactory = LoggerInterceptor.CreateProxy<ClientFactory>();
        MainMenu mainMenu;
        Goods goods = null;
        //string filePath = Application.StartupPath+"\\PicFile\\";//"D:\\ERPToysPic\\";

        public GoodsEditPage(MainMenu menu, Object obj)
        {
            InitializeComponent();
            mainMenu = menu;
            if (obj == null)
                goodsBindingSource.DataSource = new Goods();
            else
            {
                //将图片缩略图转为原图
                if (!System.IO.Directory.Exists(MainForm.DownloadFilePath))
                    System.IO.Directory.CreateDirectory(MainForm.DownloadFilePath);
                string fileName = MainForm.DownloadFilePath + String.Format("{0}.jpg", ((Goods)obj).Code);
                string strErrorinfo = string.Empty;
                bool result = true;
                if (((Goods)obj).Pic != null)
                {
                    if (!File.Exists(fileName))
                    {
                        //FileHelper.DownloadFile(fileName, MainForm.ServerUserName, MainForm.ServerPassword, MainForm.ServerDomain);
                        FtpUpDown ftpUpDown = new FtpUpDown(MainForm.ServerUrl, MainForm.ServerUserName, MainForm.ServerPassword);
                        result = ftpUpDown.Download(MainForm.DownloadFilePath, String.Format("{0}.jpg", ((Goods)obj).Code), out strErrorinfo);
                    }
                    if (result)
                    {
                        Image img = Image.FromFile(fileName);
                        ((Goods)obj).Pic = ImageHelper.MakeBuff(img);
                        img.Dispose();
                    }
                    else
                    {
                        XtraMessageBox.Show(string.Format("{0}，不能显示货品原图，只显示货品缩略图。", strErrorinfo), "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                goodsBindingSource.DataSource = obj;
                goods = (Goods)obj;
            }
            BindData();

            if (mainMenu.Name == MainMenuConstants.Goods)
                SetEditItem(DevExpress.XtraLayout.Utils.LayoutVisibility.Always);
            else
                SetEditItem(DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
        }

        void SetEditItem(DevExpress.XtraLayout.Utils.LayoutVisibility flag)
        {
            layoutControlItem4.Visibility = flag;
            layoutControlItem26.Visibility = flag;
            layoutControlItem7.Visibility = flag;
            layoutControlItem29.Visibility = flag;
            layoutControlItem8.Visibility = flag;
            layoutControlItem30.Visibility = flag;
            layoutControlItem11.Visibility = flag;
            layoutControlItem33.Visibility = flag;
            layoutControlItem12.Visibility = flag;
            layoutControlItem34.Visibility = flag;
            lciPurchasePrice.Visibility = flag;
            if (mainMenu.Name == MainMenuConstants.Goods)
                lblNWeight.Text = "净重(KGS)";
            else
                lblNWeight.Text = "净重(G)";
            //layoutControlItem13.Visibility = flag;
            //layoutControlItem35.Visibility = flag;
            layoutControlItem15.Visibility = flag;
            layoutControlItem37.Visibility = flag;
            lcgMainMark.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcgSideMark.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcgInnerMark.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            if (MainForm.Company.Contains("纸"))
            {
                layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem29.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem33.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem45.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciCycle.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciCavityNumber.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem37.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem38.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciPurchasePrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        public void BindData()
        {
            goodsTypeBindingSource.DataSource = MainForm.dataSourceList[typeof(List<GoodsType>)];
            packagingBindingSource.DataSource = MainForm.dataSourceList[typeof(List<Packaging>)];
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
                Goods obj = goodsBindingSource.DataSource as Goods;
                if (!System.IO.Directory.Exists(MainForm.DownloadFilePath))
                    System.IO.Directory.CreateDirectory(MainForm.DownloadFilePath);
                string fileName = MainForm.DownloadFilePath + String.Format("{0}.jpg", obj.Code);
                if (pePic.EditValue == System.DBNull.Value)
                    obj.Pic = null;
                else
                {
                    if (pePic.EditValue is Binary)
                        obj.Pic = ImageHelper.MakeBuff(ImageHelper.GetReducedImage(ImageHelper.BinaryToImage((Binary)pePic.EditValue), 24, 24));
                    else
                    {
                        ((Image)pePic.EditValue).Save(fileName);
                        //obj.PicPath = fileName;
                        //上传文件
                        //FileHelper.UploadFile(fileName, MainForm.ServerUserName, MainForm.ServerPassword, MainForm.ServerDomain);
                        FtpUpDown ftpUpDown = new FtpUpDown(MainForm.ServerUrl, MainForm.ServerUserName, MainForm.ServerPassword);
                        string error = string.Empty;
                        bool flag = ftpUpDown.Upload(fileName, out error);
                        if (flag == false)
                        {
                            XtraMessageBox.Show("保存失败。\r\n原因:图片上传失败\r\n"+error, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        obj.Pic = ImageHelper.MakeBuff(ImageHelper.GetReducedImage((Image)pePic.EditValue, 24, 24));
                    }
                }
                if (mainMenu.Name == MainMenuConstants.Goods)
                {
                    obj.Type = 0;
                    if (string.IsNullOrEmpty(obj.SideMark))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("\r\nITEM NO: {0}\r\n", obj.Code);
                        sb.Append("QTY:  PCS\r\n");
                        sb.AppendFormat("G.W: {0} KGS\r\n", obj.GWeight);
                        sb.AppendFormat("N.W: {0} KGS\r\n", obj.NWeight);
                        sb.AppendFormat("MEAS: {0} CM\r\n", obj.MEAS);
                        obj.SideMark = sb.ToString();
                    }
                }
                else
                {
                    obj.Type = MainForm.GoodsBigType;
                    obj.PackagingID = Guid.Empty;
                    obj.PCS = 1;
                }
                bool isExist = clientFactory.GetData<Goods>().Any(o => o.ID != obj.ID && o.Code.Equals(obj.Code));
                if (isExist)
                {
                    XtraMessageBox.Show(string.Format("货号：{0}已经存在，不允许添加重复货号。", obj.Code), "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (MainForm.Company.Contains("纸"))
                {
                    obj.PackagingID = new Guid("93fcc1eb-8d01-4465-9d27-c3ef00bf2251");
                    obj.PCS = 1;
                    obj.InnerBox = 1;
                }
                if (obj.NWeight == 0)
                    obj.NWeight = 1;
                if (obj.CavityNumber == 0)
                    obj.CavityNumber = 1;
                //添加
                if (goods == null)
                {
                    goods = obj;
                    goods.ID = Guid.NewGuid();
                    goods.AddTime = DateTime.Now;
                    clientFactory.Add<Goods>(goods);

                }
                else
                    clientFactory.Update<Goods>(goods);

                //CommonServices.ErrorTrace.SetSuccessfullyInfo(this.FindForm(), "保存成功");
                //保存成功后，显示原来清晰的图片
                if (goods.Pic != null && File.Exists(fileName))
                {
                    Image img = Image.FromFile(fileName);
                    goods.Pic = ImageHelper.MakeBuff(img);
                    img.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {
                //CommonServices.ErrorTrace.SetErrorInfo(this.FindForm(), ex.Message);
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
            goods = null;
            goodsBindingSource.DataSource = new Goods();
            txtCode.Focus();
        }

        private void pePic_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (pePic.EditValue != null && pePic.Image != null)
                {
                    ImageHelper.WindowsPhotoViewer(pePic.Image);
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
