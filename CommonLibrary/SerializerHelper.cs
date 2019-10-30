using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CommonLibrary
{
    /// <summary>
    /// 序列化帮助类
    /// </summary>
    public class SerializerHelper
    {
        /// <summary>
        /// 创建XmlWriter
        /// </summary>
        /// <param name="output">流对象</param>
        /// <returns>返回XmlWriter</returns>
        public static XmlWriter CreateXmlWriter(object output)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.OmitXmlDeclaration = true;
            settings.CloseOutput = true;
            settings.NewLineHandling = NewLineHandling.Entitize;
            settings.NewLineChars = "\r\n";
            if (output is string)
            {
                return XmlWriter.Create(output as string, settings);
            }
            else if (output is System.Text.StringBuilder)
            {
                return XmlWriter.Create(output as System.Text.StringBuilder, settings);
            }
            else if (output is TextWriter)
            {
                return XmlWriter.Create(output as TextWriter, settings);
            }

            return null;
        }

        /// <summary>
        /// 创建XmlReader
        /// </summary>
        /// <param name="output">流对象</param>
        /// <returns>返回XmlReader</returns>
        public static XmlTextReader CreateXmlReader(object output)
        {
            // XmlReaderSettings settings = new XmlReaderSettings();
            // settings.CloseInput = true;
            // settings.ValidationType = ValidationType.Schema;

            //  settings.IgnoreWhitespace = false;
            if (output is string)
            {
                //XmlTextReader reader=new XmlTextReader(
                return new XmlTextReader(output as string);
            }
            else if (output is TextReader)
            {
                return new XmlTextReader(output as TextReader);
            }

            return null;
        }

        /// <summary>
        /// 反序列化为对象
        /// </summary>
        /// <param name="content">要反序列化字符串的对象</param>
        /// <returns>返回反序列化的对象</returns>
        public static T DeserializeFromString<T>(
            string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return default(T);
            }

            using (TextReader reader = new StringReader(content))
            {
                using (XmlTextReader reader2 = SerializerHelper.CreateXmlReader(reader))
                {
                    XmlSerializer xz = new XmlSerializer(typeof(T));
                    return (T)xz.Deserialize(reader2);

                }
            }
        }

        #region 过期方法
        /// <summary>
        /// 反序列化为对象(已过期,请使用DeserializeFromString《T》(string content))
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="type">type</param>
        /// <param name="content">要反序列化字符串的对象</param>
        /// <returns>T</returns>
        public static T DeserializeFromString<T>(Type type,
            string content)
        {
            var d = DeserializeFromString<T>(content);
            return d;
        }

        /// <summary>
        /// 反序列化为对象(已过期,请使用DeserializeFromXMLDocument《T》(XmlDocument xmlContent))
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="type">type</param>
        /// <param name="xmlContent">要反序列化XmlDocument的对象</param>
        /// <returns>T</returns>
        public static T DeserializeFromXMLDocument<T>(Type type,
            XmlDocument xmlContent)
        {
            return DeserializeFromXMLDocument<T>(xmlContent);
        }

        #endregion


        /// <summary>
        /// 反序列化为对象
        /// </summary>
        /// <param name="xmlContent">要反序列化XmlDocument的对象</param>
        /// <returns>返回反序列化的对象</returns>
        public static T DeserializeFromXMLDocument<T>(
            XmlDocument xmlContent)
        {
            if (xmlContent == null)
            {
                return default(T);
            }

            using (TextReader reader = new StringReader(xmlContent.OuterXml))
            {
                using (XmlTextReader reader2 = SerializerHelper.CreateXmlReader(reader))
                {
                    XmlSerializer xz = new XmlSerializer(typeof(T));
                    return (T)xz.Deserialize(reader2);
                }
            }
        }


        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="type">序列的对象</param>
        /// <returns>返回序列化的字符串内容</returns>
        public static string SerializeToString<T>(T type)
        {
            if (type == null)
            {
                return null;
            }


            System.Text.StringBuilder xmContent = new System.Text.StringBuilder();
            using (XmlWriter sw = SerializerHelper.CreateXmlWriter(xmContent))
            {
                XmlSerializer xz = new XmlSerializer(typeof(T));

                xz.Serialize(sw, type);
            }

            return xmContent.ToString();
        }


        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="excludexmln">是否排除xmln信息</param>
        /// <param name="excludeNullNode">是否排除空节点</param>
        /// <returns>返回序列化的字符串内容</returns>
        public static string SerializeToString<T>(
            T type,
            bool excludexmln,
            bool excludeNullNode)
        {
            if (type == null)
            {
                return null;
            }


            System.Text.StringBuilder xmContent = new System.Text.StringBuilder();
            using (XmlWriter sw = SerializerHelper.CreateXmlWriter(xmContent))
            {
                XmlSerializer xz = new XmlSerializer(typeof(T));

                xz.Serialize(sw, type);
            }

            string result = xmContent.ToString();
            if (excludexmln)
            {
                result = result.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
            }

            if (excludeNullNode)
            {
                Regex reg1 = new Regex(@"<(.*?)/>", System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = reg1.Replace(result, "");
            }

            return result;
        }

        /// <summary>
        /// 序列化对象
        /// 创建时间：2011-07-20 11:56
        /// </summary>
        /// <param name="o">实例</param>
        /// <param name="excludexmln"></param>
        /// <param name="excludeNullNode"></param>
        /// <returns></returns>
        public static string SerializeToString(
            object o,
            bool excludexmln,
            bool excludeNullNode)
        {
            if (o == null)
            {
                return null;
            }


            System.Text.StringBuilder xmContent = new System.Text.StringBuilder();
            using (XmlWriter sw = SerializerHelper.CreateXmlWriter(xmContent))
            {
                XmlSerializer xz = new XmlSerializer(o.GetType());

                xz.Serialize(sw, o);
            }

            string result = xmContent.ToString();
            if (excludexmln)
            {
                result = result.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
            }

            if (excludeNullNode)
            {
                Regex reg1 = new Regex(@"<(.*?)/>", System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = reg1.Replace(result, "");
            }

            return result;
        }


        /// <summary>
        /// 序列化对象到XMLDocument
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="type">序列的对象</param>
        /// <returns>返回序列化的XMLDocument</returns>
        public static XmlDocument SerializeToXMLDocument<T>(T type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            System.Text.StringBuilder xmContent = new System.Text.StringBuilder();
            using (XmlWriter sw = SerializerHelper.CreateXmlWriter(xmContent))
            {
                XmlSerializer xz = new XmlSerializer(typeof(T));
                xz.Serialize(sw, type);
            }

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xmContent.ToString());
            return xd;
        }

        /// <summary>
        /// 序列化对象到XMLDocument
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="type">序列的对象</param>
        /// <param name="fileName">文件路径</param>
        /// <returns>返回序列化的XMLDocument</returns>
        public static void SerializeToXMLDocument<T>(
            T type,
            string fileName)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            System.Text.StringBuilder xmContent = new System.Text.StringBuilder();
            using (XmlWriter sw = SerializerHelper.CreateXmlWriter(xmContent))
            {
                XmlSerializer xz = new XmlSerializer(typeof(T));
                xz.Serialize(sw, type);
            }

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xmContent.ToString());
            xd.Save(fileName);

        }


        /// <summary>
        /// 反序列化为对象
        /// </summary>
        /// <param name="fileName">文件</param>
        /// <returns>返回反序列化的对象</returns>
        public static T DeserializeFromXMLDocument<T>(string fileName)
        {
            XmlDataDocument doc = new XmlDataDocument();
            doc.Load(fileName);
            using (TextReader reader = new StringReader(doc.OuterXml))
            {
                using (XmlTextReader reader2 = SerializerHelper.CreateXmlReader(reader))
                {
                    XmlSerializer xz = new XmlSerializer(typeof(T));
                    return (T)xz.Deserialize(reader2);
                }
            }
        }
    }
}
