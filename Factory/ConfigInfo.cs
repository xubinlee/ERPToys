using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Utility;

namespace Factory
{
    class ConfigInfo
    {
        private static string m_SqlConStr;

        public static string SqlConStr
        {
            get
            {
                if (string.IsNullOrEmpty(m_SqlConStr)
                    && (Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("24FB02AD0EAB8D0BB569A4BD034AB3C1F57C3F6137CA54F7") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("56759C4F5C620766A3797FB5C37C76CBD58A8265F2246ED7") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("97432BA229443EB19F4AAAC2CF631A184EF5130ACDDA8FA4") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("1219D52BD03AA9AC9184FF823A877F6A7D71C97CBABC72E4") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("0C5821E22A6A2BC7A020DB19F98FE53A44EC005EA3413FA1") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("0C5821E22A6A2BC7A020DB19F98FE53A61347C762D7AD190") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("03C9ABA5F46511F8DBB72423114E2E8342E1C3874C83A44C") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("E1AC3B87E030D303EA9939AABF20FA06C6D659CEA3E0A208") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("E5F2BE64E5DCA8195A4683E62F2B45382642C89D9D8B13D9") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("E1AC3B87E030D3032D73982BF27543A09480D1D5FA0947DD") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("E1AC3B87E030D30352305B8BFDE963D77F3BFB9F9ACC5931") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("CC861CA10E73B7170BF845489BB128BD653EEDD945336D81") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("0C5821E22A6A2BC7A020DB19F98FE53A44EC005EA3413FA1") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("4B24D7B0F736A2971640A04E3F0D9C439156D4CCFCC05E2B") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("A98FC9E47D5B7294F08745F981EEBE294620415334ABCF72") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("E240173B1BD370ED5CC9A6BF4CB7B4BF7CF6D1570CDB3D31") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("9779C309A098BB3EB315BAEAB28D6E489EDAF0009AC2D7CE") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("56759C4F5C62076685A0B648D977F8B0889FC784249FF4BE") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("E1AC3B87E030D303665AA920EDC2C4FDA798B3AA5F853D40") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("A6F99163E0A1A3554D7A06035C170426F64F7A4BE1EA7860") ||
                    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("5EC6DE86044BABB67AAA0295141DC1A063CBA58723C01B66")))
                //亿棵
                //if (string.IsNullOrEmpty(m_SqlConStr)
                //&& (Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("24FB02AD0EAB8D0BB569A4BD034AB3C1F57C3F6137CA54F7") ||
                //Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("56759C4F5C620766D7D9E4D6D8D789B0BD7675497054D69C") ||
                //Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("5CCBE9C93521566EB0CB8449FD0FA36F4D6D27258972AD32")))
                //yasini
                //if (string.IsNullOrEmpty(m_SqlConStr)
                //&& (Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("24FB02AD0EAB8D0BB569A4BD034AB3C1F57C3F6137CA54F7") ||
                //Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("AA57721CEB9D8A0E7D4BBC1231A0BDB7FF15BB0EB9D3F6EF") ||
                //Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("5CCBE9C93521566EB0CB8449FD0FA36F4D6D27258972AD32")))
                //haihan
                //if (string.IsNullOrEmpty(m_SqlConStr)
                //&& (Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("E4854D630B2C9CFDB371022C364CFBF5631147E107692957") ||
                //Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("EE0B3CA367D9505FE48C9D90533228BA474BA59CE1931F80") ||
                //Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("A6F99163E0A1A35548DAC0F4BC31F88A7835E51A09880EFA")))
                //hao
                //if (string.IsNullOrEmpty(m_SqlConStr)
                //&& (Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("E4854D630B2C9CFDB371022C364CFBF5631147E107692957") ||
                //Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("4B24D7B0F736A29742D42E41BE17364BDD75A1D7DD693EB8") ||
                //Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("9F813376C767FD3EC0FDCDF1F7B35D6CB7E017AD59C19EDA")))
                //    //leyi
                //    if (string.IsNullOrEmpty(m_SqlConStr)
                //&& (Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("24FB02AD0EAB8D0BB569A4BD034AB3C1F57C3F6137CA54F7") ||
                //Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("56759C4F5C620766222B92F6EC1578D0878C13C97C5C27B7") ||
                //Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("56759C4F5C620766D0952D8A2FEB2620521F4F735770A5C0") ||
                //Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("EC1A07D533686D8132FF50A04B638539326B0A8F8FE07BB0") ||
                //Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("5778FD16C9B12BC02188D0A5AE5190F550E9E93CA17603C2")))
                //ming
                //if (string.IsNullOrEmpty(m_SqlConStr)
                //&& (Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("24FB02AD0EAB8D0BB569A4BD034AB3C1F57C3F6137CA54F7") ||
                //Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("376A4D22960A75F9EB906F337156EDBA3CD58F834FA1261F") ||
                //Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("56759C4F5C62076620055B322328A5453680DF271D83D1F8")))
                //dazheng
                //if (string.IsNullOrEmpty(m_SqlConStr)
                //    && (Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("1C37A9B3376F50BFB5FCB7C28AC6ED60809A594BD4E7ADE1") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("E1AC3B87E030D3033DD53231B5547D48DEC0A030B8876B7D") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("56759C4F5C620766354C009C610D9683B9AE7A7C7E27022D") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("ADD54FF7245C95F10C80C5A13004598358E6ECC4063E1EB7")))
                ///wei
                //if (string.IsNullOrEmpty(m_SqlConStr)
                //    && (Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("56759C4F5C620766D7D9E4D6D8D789B0BD7675497054D69C") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("5C39E32831ED4E9B93FE19459F1A7C810C61D48F564F1336") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("8B27CEF0128831219607BC77F86714BC64AF4831A336BDCD") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("1C37A9B3376F50BFB5FCB7C28AC6ED60809A594BD4E7ADE1") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("E1AC3B87E030D303464446FAF975F6F53C89ED939779F8EB")))
                //if (string.IsNullOrEmpty(m_SqlConStr)
                //    && (Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("1C37A9B3376F50BFB5FCB7C28AC6ED60809A594BD4E7ADE1") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("75745BDCC6102609525DBB0A16484FE25494EB27C1919EAA")))
                //meng
                //if (string.IsNullOrEmpty(m_SqlConStr)
                //    && (Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("E4854D630B2C9CFDB371022C364CFBF5631147E107692957") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("24FB02AD0EAB8D0BB569A4BD034AB3C1F57C3F6137CA54F7") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("5778FD16C9B12BC02188D0A5AE5190F529F72A7D263FA4D7") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("5F92C3AD9B80C9640002F139181909EE8CEB0B6268348861") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("CFEADB97E90415888519AD54973A3CD3605B539CBCC758B5") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("56759C4F5C62076658AC67F943D479F50992B31DBFE4D65E") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("56759C4F5C6207663AA3823A1D63681FF7AEBCF2F1182DE1") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("B293F803B6392BDD0694408D12C998859AE93EC88ADB0699")))
                //    //DA
                //    if (string.IsNullOrEmpty(m_SqlConStr)
                //    && (Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("1C37A9B3376F50BFB5FCB7C28AC6ED60809A594BD4E7ADE1") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("24FB02AD0EAB8D0BB569A4BD034AB3C1F57C3F6137CA54F7") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("ADD54FF7245C95F10C80C5A13004598358E6ECC4063E1EB7") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("1F2CC56984C63506346B1EE05555895A44B65B14829B6084") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("BCFDE229C60514A0F806709CBD4862C04B1D390BEF1D482F") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("E1AC3B87E030D3033DD53231B5547D48DEC0A030B8876B7D") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("5EC6DE86044BABB681EFE311E25C25585F92350038303470") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("5EC6DE86044BABB673F437CC4782EF1291280D26475FF84E")))
                //bo
                //if (string.IsNullOrEmpty(m_SqlConStr)
                //    && (Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("1C37A9B3376F50BFB5FCB7C28AC6ED60809A594BD4E7ADE1") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("24FB02AD0EAB8D0BB569A4BD034AB3C1F57C3F6137CA54F7") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("56759C4F5C62076654888BA9EDA26B1E0BBE7F016F1B93DA") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("4B24D7B0F736A29750EA9B9B67FABF965108C62D86E165B4") ||
                //    Security.Encrypt(SystemManagement.GetMacAddressByNetworkInformation()).Equals("376A4D22960A75F9CE4066F6BD7498EA1729979E4C48D6A4")))
                {
                    m_SqlConStr = Security.Decrypt(ConfigurationManager.ConnectionStrings["ERPToysConnectionString"].ConnectionString);
                }
                return m_SqlConStr;
            }
        }
    }
}
