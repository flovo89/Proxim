using System;
using System.Collections.Generic;

using Proxim.Phone.Core.Data;
using Proxim.Phone.Core.Interfaces;




namespace Proxim.Phone.Core.Services.Messaging
{
    public class MessagingService : IMessagingService
    {
        #region Instance Constructor/Destructor

        public MessagingService(ILoggingService loggingService, ISessionService sessionService)
        {
            this.SyncRoot = new object();
            this.ReceiverList = new List<Action<IMessage>>();
            this.LoggingService = loggingService;
            this.SessionService = sessionService;
        }

        #endregion




        #region Instance Properties/Indexer

        private ILoggingService LoggingService { get; }

        private List<Action<IMessage>> ReceiverList { get; }

        private ISessionService SessionService { get; }

        private object SyncRoot { get; }

        #endregion




        #region Interface: IMessagingService

        public IMessage CreateMessage(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            lock (this.SyncRoot)
            {
                return new Message(name);
            }
        }

        public void Initialize()
        {
        }

        public void PostMessage(IMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            this.SessionService.Dispatcher.RequestMainThreadAction(() =>
            {
                lock (this.SyncRoot)
                {
                    if (message is Message)
                    {
                        ((Message)message).Timestamp = DateTime.Now;
                    }

                    foreach (Action<IMessage> act in this.ReceiverList)
                    {
                        act(message);
                    }
                }

                this.LoggingService.DebugLog("MessageService", LogLevel.Information, "Message posted: " + message.Name);
            });
        }

        public void SubscribeReceiver(Action<IMessage> callback)
        {
            if (!this.ReceiverList.Contains(callback))
            {
                this.ReceiverList.Add(callback);
            }
        }

        #endregion
    }
}
