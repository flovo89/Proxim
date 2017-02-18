using System;




namespace Proxim.Phone.Core.Interfaces.ServiceInterfaces
{
    public interface IMessagingService : IService
    {
        IMessage CreateMessage (string name);

        void PostMessage (IMessage message);

        void SubscribeReceiver (Action<IMessage> callback);
    }
}
