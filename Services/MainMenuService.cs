using Common;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBML;
using BLL;
using Microsoft.Practices.Unity;
using Factory;

namespace Services
{
    public class MainMenuService : ServiceBase, IMainMenuService
    {
        public List<MainMenu> GetMainMenu()
        {
            return BLLFty.Create<MainMenuBLL>().GetMainMenu();
        }
    }
}

