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
    [ServiceContract(Name = "DataSourcesService")]
    public interface IDataSourcesService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Dictionary<Type, object> GetDataSources();
    }
}
