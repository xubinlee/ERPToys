using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBase;
using DBML;
using DAL;
using Factory;

namespace BLL
{
    public class MainMenuBLL : IBLLBase
    {
        public List<MainMenu> GetMainMenu()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<MainMenuDAL>().GetMainMenu(dcc);
            }
        }
    }
}
