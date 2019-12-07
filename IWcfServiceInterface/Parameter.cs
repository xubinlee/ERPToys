using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWcfServiceInterface
{
    public class Parameter
    {
        public Type entityType { get; set; }

        public string filter { get; set; }

        public object model { get; set; }

        public IList list { get; set; }

        public IQueryable queryable { get; set; }
    }
}
