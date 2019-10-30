using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace CommonLibrary
{
    public class ExceptionHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        static public string MaskSqlServerException(string message)
        {
            List<string> messages = new List<string>();

            Regex regex = new Regex("<ErrorMessages><ErrorMessage>(.*?)</ErrorMessage></ErrorMessages>");

            if (regex.IsMatch(message))
            {
                try
                {
                    MatchCollection mc = regex.Matches(message);
                    for (int i = 0; i < mc.Count; i++)
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.LoadXml(mc[0].Value);

                        XmlNodeList nodes = xml.SelectSingleNode("ErrorMessages").SelectNodes("ErrorMessage");
                        foreach (XmlNode node in nodes)
                        {
                            messages.Add(string.Format("{0}:{1}",
                                node.SelectSingleNode("Property").InnerText,
                                node.SelectSingleNode("Message").InnerText));
                        }
                    }
                }
                catch
                {
                    messages.Add(message);
                }
            }
            else
            {
                messages.Add(message);
            }

            return messages.ToArray().Join(",");
        }
    }
}
