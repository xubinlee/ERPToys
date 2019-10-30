using DAL;
using DBML;
using Factory;
using IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PackagingBLL : IBLLBase
    {
        public List<VPackaging> GetVPackaging()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<PackagingDAL>().GetVPackaging(dcc);
            }
        }

        public List<Packaging> GetPackaging()
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<PackagingDAL>().GetPackaging(dcc);
            }
        }

        public Packaging GetPackaging(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                return DALFty.Create<PackagingDAL>().GetPackaging(dcc,id);
            }
        }

        public void Insert(Packaging obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<PackagingDAL>().Insert(dcc, obj);
                dcc.Save();
            }
        }

        public void Update(Packaging obj)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<PackagingDAL>().Update(dcc, obj);
                dcc.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (DCC dcc = DBMLFty.Dcc)
            {
                DALFty.Create<PackagingDAL>().Delete(dcc, id);
                dcc.Save();
            }
        }
    }
}
