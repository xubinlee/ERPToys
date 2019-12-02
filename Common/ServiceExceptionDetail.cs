using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class ServiceExceptionDetail : ExceptionDetail
    {
        public ServiceExceptionDetail(Exception ex)
            : base(ex)
        {
            this.ExceptionAssemblyQualifiedName = ex.GetType().AssemblyQualifiedName;
            if (ex.InnerException != null)
            {
                this.InnerException = new ServiceExceptionDetail(ex.InnerException);
            }
        }

        [DataMember]
        public string ExceptionAssemblyQualifiedName
        { get; set; }

        [DataMember]
        public new ServiceExceptionDetail InnerException
        { get; set; }
    }
}
