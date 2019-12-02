using Common;
using DBML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IBase
{
    [ServiceContract(Name = "TypesListService")]
    public interface ITypesListService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<TypesList> GetTypesList();
    }
}
