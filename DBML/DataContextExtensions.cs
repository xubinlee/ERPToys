using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Linq;
using System.Data.Common;

namespace DBML
{
    public static class DataContextExtensions
    {
        public static List<T> ExecuteQuery<T>(this DataContext dcxt, IQueryable query)
        {
            DbCommand command = dcxt.GetCommand(query);
            dcxt.OpenConnection();

            using (DbDataReader reader = command.ExecuteReader())
            {
                return dcxt.Translate<T>(reader).ToList();
            }
        }

        private static void OpenConnection(this DataContext dcxt)
        {
            if (dcxt.Connection.State == ConnectionState.Closed)
                dcxt.Connection.Open();
        }
    }
}
