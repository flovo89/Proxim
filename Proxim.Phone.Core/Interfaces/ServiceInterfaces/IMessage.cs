using System;




namespace Proxim.Phone.Core.Interfaces.ServiceInterfaces
{
    public interface IMessage
    {
        string Name { get; }

        DateTime Timestamp { get; }

        void AddMessageData (string key, object data);

        object GetMessageData (string key);
    }
}
