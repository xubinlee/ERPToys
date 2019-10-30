using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    /// <summary>
    /// 实现了错误提示服务的Control
    /// </summary>
    public interface IErrorDisplayer
    {
        /// <summary>
        /// 
        /// </summary>
        IErrorTraceService TraceService { get; }
    }
}
