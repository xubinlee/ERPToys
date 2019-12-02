using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class ExcelHelper
    {
        private static DataSet ImportExcelOleDb(string connStr)
        {
            //把EXCEL导入到DataSet
            DataSet ds = new DataSet();
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                ArrayList al = new ArrayList();
                conn.Open();
                DataTable sheetNames = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                foreach (DataRow item in sheetNames.Rows)
                {
                    al.Add(item[2]);  //itme[2]是获取Excel表单薄名称
                }
                int n = al.Count;
                string[] SheetSet = new string[n];
                for (int i = 0; i < n; i++)
                {
                    SheetSet[i] = (string)al[i];
                }
                OleDbDataAdapter da;
                for (int i = 0; i < n; i++)
                {
                    string sql = "select * from [" + SheetSet[i] + "] ";
                    da = new OleDbDataAdapter(sql, conn);
                    da.Fill(ds, SheetSet[i]);
                    da.Dispose();
                }
                conn.Close();
                conn.Dispose();
            }
            return ds;
        }

        public static DataSet ImportExcel(string fileName)
        {
            var _file = new FileInfo(fileName);
            DataSet _ds = new DataSet();
            DataSet ds = null;
            string connStr = null;
            Microsoft.Win32.RegistryKey regKey = null;
            Microsoft.Win32.RegistryKey regSubKey_2003 = null;
            Microsoft.Win32.RegistryKey regSubKey_2007 = null;
            Microsoft.Win32.RegistryKey regSubKey_2010 = null;
            //Microsoft.Win32.RegistryKey regSubKey_2013 = null;

            regKey = Microsoft.Win32.Registry.LocalMachine;

            if (_file.FullName.Substring(_file.FullName.LastIndexOf(".")).ToUpper() == ".XLSX")
            {

                //connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=" + _file.FullName + ";" + "Extended Properties=\"Excel 12.0 Xml;HDR=No\"";
                connStr = "Provider=Microsoft.Ace.OleDb.12.0;Data Source = " + _file.FullName + ";Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1';";
                ds = ImportExcelOleDb(connStr);
            }
            else
            {
                regSubKey_2003 = regKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\11.0\Common\InstallRoot", false);
                regSubKey_2007 = regKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\12.0\Common\InstallRoot", false);
                regSubKey_2010 = regKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\14.0\Common\InstallRoot", false);
                if (regSubKey_2007 != null || regSubKey_2010 != null)
                {
                    connStr = "Provider=Microsoft.Ace.OleDb.12.0;Data Source = " + _file.FullName + ";Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1;'";
                    ds = ImportExcelOleDb(connStr);
                }
                //else if (regSubKey_2010 != null)
                //{
                //    connStr = "Provider=Microsoft.Ace.OleDb.14.0;Data Source = " + _file.FullName + ";Extended Properties = 'Excel 14.0;HDR=YES;IMEX=1;'";
                //    ds = ImportExcelOleDb(connStr);
                //}
                else if (regSubKey_2003 != null)
                {
                    connStr = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + _file.FullName + ";Extended Properties=Excel 8.0";
                    ds = ImportExcelOleDb(connStr);
                }
                else
                {
                    ds = null;
                }
            }
            return ds;
        }
    }
}
