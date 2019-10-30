using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class FileHelper
    {
        static string serverUrl = ConfigurationManager.AppSettings["ServerUrl"];

        public static void UploadFile(string uploadFile, string username, string password, string domain)
        {
            //if (!System.IO.Directory.Exists(serverFilePath))
            //    System.IO.Directory.CreateDirectory(serverFilePath);
            //string serverFile = serverFilePath + @"/UpdateList.xml";

            try
            {
                WebRequest req = WebRequest.Create(serverUrl);
                req.Credentials = new NetworkCredential(username, password, domain);
                WebResponse res = req.GetResponse();
                if (res.ContentLength > 0)
                {
                    try
                    {
                        using (WebClient wClient = new WebClient())
                        {
                            wClient.UploadFile(serverUrl, uploadFile);
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
            }
            catch
            {
                return;
            }
        }

        public static void DownloadFile(string downloadFileName, string username, string password, string domain)
        {
            //if (!System.IO.Directory.Exists(serverFilePath))
            //    System.IO.Directory.CreateDirectory(serverFilePath);
            //string serverFile = serverFilePath + @"/UpdateList.xml";

            try
            {
                WebRequest req = WebRequest.Create(serverUrl);
                req.Credentials = new NetworkCredential(username, password, domain);
                WebResponse res = req.GetResponse();
                if (res.ContentLength > 0)
                {
                    try
                    {
                        using (WebClient wClient = new WebClient())
                        {
                            wClient.DownloadFile(serverUrl, downloadFileName);
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
            }
            catch
            {
                return;
            }
        }
    }
}
