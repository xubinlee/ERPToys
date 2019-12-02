using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility
{
    public static class ImageHelper
    {
        /// <summary>
        /// 把图片转换并存储到字节流数组中
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] MakeBuff(Image img)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //存储到字节流数组中
            byte[] buffByte = new byte[ms.Length];
            buffByte = ms.GetBuffer();
            ms.Close();
            ms = null;
            img.Dispose();
            return buffByte;
        }

        /// <summary>
        /// 把字节流还原为图片
        /// </summary>
        /// <param name="buffByte"></param>
        /// <param name="width">图片的宽度（以象素为单位）</param>
        /// <param name="height">图片的高度（以象素为单位）</param>
        /// <returns></returns>
        public static Image ConvertToImage(byte[] buffByte, int width, int height)
        {
            Bitmap bmp = null;
            Bitmap bmp1 = null;
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(buffByte, true);
                bmp = new Bitmap(ms);
                buffByte = null;
                ms.Close();
                ms = null;

                bmp1 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(bmp1);
                g.DrawImage(bmp, new Rectangle(0, 0, width, height));//图像拷贝
                g.Dispose();
                bmp.Dispose();//释放bmp文件资源 

            }
            catch { }
            return (Image)bmp1;
        }


        /// <summary>
        /// 把图片转换并存储到字节流数组中
        /// </summary>
        /// <param name="img">要保存的图片的Image对象</param>
        /// <param name="imageQualityValue">图片要保存的压缩质量，该参数的值为1至100的整数，数值越大，保存质量越好</param>
        /// <returns></returns>
        public static byte[] MakeBuff(Image img, int imageQualityValue)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //以下代码为保存图片时，设置压缩质量
            EncoderParameters encoderParameters = new EncoderParameters();
            EncoderParameter encoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, imageQualityValue);
            encoderParameters.Param[0] = encoderParameter;
            ImageCodecInfo[] ImageCodecInfoArray = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo jpegImageCodecInfo = null;
            for (int i = 0; i < ImageCodecInfoArray.Length; i++)
            {
                if (ImageCodecInfoArray[i].FormatDescription.Equals("JPEG"))
                {
                    jpegImageCodecInfo = ImageCodecInfoArray[i];
                    break;
                }
            }
            img.Save(ms, jpegImageCodecInfo, encoderParameters);
            //存储到字节流数组中
            byte[] buffByte = new byte[ms.Length];
            buffByte = ms.GetBuffer();
            ms.Close();
            ms = null;
            return buffByte;
        }

        public static Image BinaryToImage(System.Data.Linq.Binary binaryData)
        {
            if (binaryData == null) return null;

            byte[] buffer = binaryData.ToArray();
            MemoryStream memStream = new MemoryStream();
            memStream.Write(buffer, 0, buffer.Length);
            return Image.FromStream(memStream);
        }

        /// <summary>
        /// 用Windows图片查看器打开图片
        /// </summary>
        /// <param name="img"></param>
        public static void WindowsPhotoViewer(Image img)
        {
            string fileName = Application.StartupPath + "\\temppic.jpg";
            img.Save(fileName);
            //用Windows图片查看器打开图片
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = "rundll32.exe C://WINDOWS//system32//shimgvw.dll,ImageView_Fullscreen";
            //此项为是否使用Shell执行程序，因系统默认为true，此项也可不设，但若设置必须为true    
            process.StartInfo.UseShellExecute = true;
            //此处可以更改进程所打开窗体的显示样式，可以不设    
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.Start();    //启动进程
            process.Close();
        }

        /// <summary>
        /// 生成缩略图重载方法1，返回缩略图的Image对象
        /// </summary>
        /// <param name="ResourceImage">原图</param>
        /// <param name="Width">缩略图的宽度</param>
        /// <param name="Height">缩略图的高度</param>
        /// <returns>缩略图的Image对象</returns>
        public static Image GetReducedImage(Image ResourceImage, int Width, int Height)
        {
            try
            {
                //用指定的大小和格式初始化Bitmap类的新实例
                Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
                //从指定的Image对象创建新Graphics对象
                Graphics graphics = Graphics.FromImage(bitmap);
                //清除整个绘图面并以透明背景色填充
                graphics.Clear(Color.Transparent);
                //在指定位置并且按指定大小绘制原图片对象
                graphics.DrawImage(ResourceImage, new Rectangle(0, 0, Width, Height));
                return bitmap;
            }
            catch 
            {
                //ErrMessage = e.Message;
                return null;
            }
        }
    }
}
