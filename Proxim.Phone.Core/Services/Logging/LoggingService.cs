using System;
using System.Diagnostics;
using System.Globalization;

using MvvmCross.Platform.Platform;

using Proxim.Phone.Core.Data;
using Proxim.Phone.Core.Interfaces;




namespace Proxim.Phone.Core.Services.Logging
{
    internal class LoggingService : ILoggingService
    {
        #region Instance Constructor/Destructor

        //TODO: Check for trace
        public LoggingService (IMvxTrace trace, ISessionService sessionService)
        {
            this.SessionService = sessionService;
        }

        #endregion




        #region Instance Properties/Indexer

        private ISessionService SessionService { get; }

        #endregion




        #region Interface: ILoggingService

        public void DebugLog (string source, LogLevel level, string message, params object[] args)
        {
            if (this.SessionService.DebugMode)
            {
                string logText = DateTime.Now.ToString().PadRight(25, ' ') + ( "[" + level + "]" ).PadRight(13, ' ') + " " + ( "[" + source + "]" ).PadRight(20, ' ') + " " + string.Format(CultureInfo.InvariantCulture, message, args);

                Debug.WriteLine(logText);
            }
        }

        public void Initialize ()
        {
        }

        #endregion
    }
}
