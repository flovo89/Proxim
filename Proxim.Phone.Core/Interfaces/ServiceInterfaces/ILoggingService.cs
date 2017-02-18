using Proxim.Phone.Core.Services.Logging;




namespace Proxim.Phone.Core.Interfaces.ServiceInterfaces
{
    public interface ILoggingService : IService
    {
        void DebugLog (string source, LogLevel level, string message, params object[] args);
    }
}
