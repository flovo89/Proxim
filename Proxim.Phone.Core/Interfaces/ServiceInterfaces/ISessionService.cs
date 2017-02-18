using MvvmCross.Platform.Core;

using Proxim.Phone.Core.Data;




namespace Proxim.Phone.Core.Interfaces.ServiceInterfaces
{
    public interface ISessionService
    {
        Country Country { get; }

        bool DebugMode { get; }

        IMvxMainThreadDispatcher Dispatcher { get; }

        Language Langugage { get; }
    }
}
