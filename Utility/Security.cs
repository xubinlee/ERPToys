using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Data;
using System.Xml.Serialization;
using System.Web.Security;

namespace Utility
{
    public static class Security
    {
        # region DataSet加密解密

        //密钥
        //获取或设置对称算法的机密密钥。机密密钥既用于加密，也用于解密。为了保证对称算法的安全，必须只有发送方和接收方知道该机密密钥。有效密钥大小是由特定对称算法实现指定的，密钥大小在 LegalKeySizes 中列出。
        private static byte[] DESKey = new byte[] { 11, 23, 93, 102, 72, 41, 18, 12 };
        //获取或设置对称算法的初始化向量
        private static byte[] DESIV = new byte[] { 75, 158, 46, 97, 78, 57, 17, 36 };

        /// <summary>
        /// 加密DataSet
        /// </summary>
        /// <param name="objDataSet">DataSet</param>
        /// <param name="outFilePath">输出路径</param>
        public static void EncryptDataSetToXml(DataSet objDataSet, string outXmlFilePath)
        {
            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
            FileStream fout = new FileStream(outXmlFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            //用指定的 Key 和初始化向量 (IV) 创建对称数据加密标准 (DES) 加密器对象
            CryptoStream objCryptoStream = new CryptoStream(fout, objDES.CreateEncryptor(DESKey, DESIV), CryptoStreamMode.Write);
            StreamWriter objStreamWriter = new StreamWriter(objCryptoStream);
            XmlSerializer objXmlSer = new XmlSerializer(typeof(DataSet));
            objXmlSer.Serialize(objStreamWriter, objDataSet);
            objStreamWriter.Close();
        }

        public static void EncryptDataSet(DataSet myDataSet)
        {
            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
            MemoryStream objMemoryStream = new MemoryStream();
            //用指定的 Key 和初始化向量 (IV) 创建对称数据加密标准 (DES) 加密器对象
            CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateEncryptor(DESKey, DESIV), CryptoStreamMode.Write);
            StreamWriter objStreamWriter = new StreamWriter(objCryptoStream);
            XmlSerializer objXmlSer = new XmlSerializer(typeof(DataSet));
            objXmlSer.Serialize(objStreamWriter, myDataSet);
            //SqlDataAdapter sda = new SqlDataAdapter();
            //sda.SelectCommand = new SqlCommand("insert into Test(myXml) values (@col)", SqlDBO.SqlConn);
            //BinaryWriter bw = new BinaryWriter(objStreamWriter.BaseStream);
            //BinaryReader br = new BinaryReader(objStreamWriter.BaseStream);
            //byte[] mywave = br.ReadBytes((int)objStreamWriter.BaseStream.Length);

            //////SqlCommand cmd = new SqlCommand("insert into Test(myXml) values (@col)", SqlDBO.SqlConn);
            //////cmd.Parameters.Add("@col", SqlDbType.Image).Value = mywave;
            //////cmd.ExecuteNonQuery();
            //new SqlCommandBuilder(sda);
            //sda.Fill(dsEx,tabname);
            //dsEx.Tables[1].Merge(dsEx.Tables[0]);
            //sda.Update(dsEx, tabname);
            //SqlDBO.SqlConn.Close();
            //SqlDBO.SqlConn.Dispose();
            //br.Close();
            objStreamWriter.Close();
            //OleDbConnection Mycon = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;data source=MyDb.mdb");
            //FileStream fs = new FileStream(filename,FileMode.Open, FileAccess.Read);
            //BinaryReader br = new BinaryReader(fs);
            //byte[] mywave = br.ReadBytes((int)fs.Length);
            //br.Close();
            //fs.Close();
            //Mycon.Open();
            //string sql = "insert into MyDataBase(wav,MyWord) VALUES (@wav,'" + textBox1.Text.Trim() + "')";
        }

        /// <summary>
        /// 解密XML并写入DataSet
        /// </summary>
        /// <param name="inXmlFilePath">读取路径</param>
        /// <returns>DataSet</returns>
        private static DataSet DecryptDataSetFromXml(string inXmlFilePath)
        {
            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
            FileStream fin = new FileStream(inXmlFilePath, FileMode.Open, FileAccess.Read);
            //用指定的 Key 和初始化向量 (IV) 创建对称数据加密标准 (DES) 加密器对象
            CryptoStream objCryptoStream = new CryptoStream(fin, objDES.CreateDecryptor(DESKey, DESIV), CryptoStreamMode.Read);
            TextReader objTxrReader = new StreamReader(objCryptoStream);
            XmlSerializer objXmlSer = new XmlSerializer(typeof(DataSet));
            DataSet ds = (DataSet)objXmlSer.Deserialize(objTxrReader);
            fin.Close();
            return ds;
        }

        # endregion

        #region 加密解密字符串
        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="Encode_String"></param>
        /// <returns></returns>
        public static string EncryptString(string Encode_String)
        {

            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
            MemoryStream objMemoryStream = new MemoryStream();
            //用指定的 Key 和初始化向量 (IV) 创建对称数据加密标准 (DES) 加密器对象
            CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateEncryptor(DESKey, DESIV), CryptoStreamMode.Write);
            StreamWriter objStreamWriter = new StreamWriter(objCryptoStream);
            objStreamWriter.Write(Encode_String);
            objStreamWriter.Flush();
            objCryptoStream.FlushFinalBlock();
            objMemoryStream.Flush();
            return Convert.ToBase64String(objMemoryStream.GetBuffer(), 0, (int)objMemoryStream.Length);
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="Encode_String"></param>
        /// <returns></returns>
        public static string DecryptString(string Encode_String)
        {
            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
            byte[] Input = Convert.FromBase64String(Encode_String);
            MemoryStream objMemoryStream = new MemoryStream(Input);
            //用指定的 Key 和初始化向量 (IV) 创建对称数据加密标准 (DES) 解密器对象
            CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateDecryptor(DESKey, DESIV), CryptoStreamMode.Read);
            StreamReader objStreamReader = new StreamReader(objCryptoStream);
            return objStreamReader.ReadToEnd();
        }
        #endregion

        #region MD5加密解密字符串

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Decrypt(string Text)
        {
            return Decrypt(Text, "Chinaman");
        }

        public static string Decrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            int num = Text.Length / 2;
            byte[] buffer = new byte[num];
            for (int i = 0; i < num; i++)
            {
                int num3 = Convert.ToInt32(Text.Substring(i * 2, 2), 0x10);
                buffer[i] = (byte)num3;
            }
            provider.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            provider.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            string s = Encoding.Default.GetString(stream.ToArray());
            return Encoding.Default.GetString(stream.ToArray());
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Encrypt(string Text)
        {
            return Encrypt(Text, "Chinaman");
        }

        public static string Encrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(Text);
            provider.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            provider.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            StringBuilder builder = new StringBuilder();
            foreach (byte num in stream.ToArray())
            {
                builder.AppendFormat("{0:X2}", num);
            }
            return builder.ToString();
        }

        #endregion

        /// <summary>
        /// 获取标准北京时间
        /// </summary>
        /// <returns></returns>
        public static DateTime DataStandardTime()
        {
            DateTime dt;

            //返回国际标准时间
            //只使用的时间服务器的IP地址，未使用域名
            try
            {
                string[,] 时间服务器 = new string[14, 2];
                int[] 搜索顺序 = new int[] { 3, 2, 4, 8, 9, 6, 11, 5, 10, 0, 1, 7, 12 };
                时间服务器[0, 0] = "time-a.nist.gov";
                时间服务器[0, 1] = "129.6.15.28";
                时间服务器[1, 0] = "time-b.nist.gov";
                时间服务器[1, 1] = "129.6.15.29";
                时间服务器[2, 0] = "time-a.timefreq.bldrdoc.gov";
                时间服务器[2, 1] = "132.163.4.101";
                时间服务器[3, 0] = "time-b.timefreq.bldrdoc.gov";
                时间服务器[3, 1] = "132.163.4.102";
                时间服务器[4, 0] = "time-c.timefreq.bldrdoc.gov";
                时间服务器[4, 1] = "132.163.4.103";
                时间服务器[5, 0] = "utcnist.colorado.edu";
                时间服务器[5, 1] = "128.138.140.44";
                时间服务器[6, 0] = "time.nist.gov";
                时间服务器[6, 1] = "192.43.244.18";
                时间服务器[7, 0] = "time-nw.nist.gov";
                时间服务器[7, 1] = "131.107.1.10";
                时间服务器[8, 0] = "nist1.symmetricom.com";
                时间服务器[8, 1] = "69.25.96.13";
                时间服务器[9, 0] = "nist1-dc.glassey.com";
                时间服务器[9, 1] = "216.200.93.8";
                时间服务器[10, 0] = "nist1-ny.glassey.com";
                时间服务器[10, 1] = "208.184.49.9";
                时间服务器[11, 0] = "nist1-sj.glassey.com";
                时间服务器[11, 1] = "207.126.98.204";
                时间服务器[12, 0] = "nist1.aol-ca.truetime.com";
                时间服务器[12, 1] = "207.200.81.113";
                时间服务器[13, 0] = "nist1.aol-va.truetime.com";
                时间服务器[13, 1] = "64.236.96.53";
                int portNum = 13;
                string hostName;
                byte[] bytes = new byte[1024];
                int bytesRead = 0;
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
                for (int i = 0; i < 13; i++)
                {
                    hostName = 时间服务器[搜索顺序[i], 1];
                    try
                    {
                        client.Connect(hostName, portNum);
                        System.Net.Sockets.NetworkStream ns = client.GetStream();
                        bytesRead = ns.Read(bytes, 0, bytes.Length);
                        client.Close();
                        break;
                    }
                    catch (System.Exception)
                    {
                    }
                }
                char[] sp = new char[1];
                sp[0] = ' ';
                dt = new DateTime();
                string str1;
                str1 = System.Text.Encoding.ASCII.GetString(bytes, 0, bytesRead);

                string[] s;
                s = str1.Split(sp);
                if (s.Length >= 2)
                {
                    dt = System.DateTime.Parse(s[1] + " " + s[2]);//得到标准时间
                    dt = dt.AddHours(8);//得到北京时间*/
                }
                else
                {
                    dt = DateTime.Parse("2015-01-01");
                }
            }
            catch (Exception)
            {
                dt = DateTime.Parse("2015-01-01");
            }
            return dt;
        }

    }
}
