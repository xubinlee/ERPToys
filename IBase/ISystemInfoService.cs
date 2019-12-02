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
    [ServiceContract(Name = "SystemInfoService")]
    public interface ISystemInfoService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<SystemInfo> GetSystemInfo();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<SystemStatus> GetSystemStatus();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(SystemStatus obj);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(SystemStatus obj);
    }
}
