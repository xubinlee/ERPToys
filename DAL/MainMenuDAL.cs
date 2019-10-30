using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBase;
using DBML;

namespace DAL
{
    public class MainMenuDAL : IDALBase
    {
        public List<MainMenu> GetMainMenu(DCC dcc)
        {
            return dcc.MainMenu.Where(o => o.CheckBoxState == true).OrderBy(o => o.SerialNo).ToList();
        }
    }
}
