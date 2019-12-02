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
    public class TypesListService : ServiceBase, ITypesListService
    {
        public List<TypesList> GetTypesList()
        {
            return BLLFty.Create<TypesListBLL>().GetTypesList();
        }
    }
}

