using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Proxim.Phone.Core.Data;




namespace Proxim.Phone.Core.Interfaces
{
    public interface ILoggingService : IService
    {
        void DebugLog(string source, LogLevel level, string message, params object[] args);
    }
}
