using System;
using System.Collections.Generic;

using Proxim.Phone.Core.Interfaces.ServiceInterfaces;




namespace Proxim.Phone.Core.Services.Messaging
{
    public class Message : IMessage
    {
        #region Instance Constructor/Destructor

        public Message (string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.Name = name;
            this.Data = new Dictionary<string, object>();
            this.Id = Guid.NewGuid();
            this.Timestamp = DateTime.Now;
        }

        #endregion




        #region Instance Properties/Indexer

        public IDictionary<string, object> Data { get; }

        public Guid Id { get; }

        #endregion




        #region Interface: IMessage

        public string Name { get; }

        public DateTime Timestamp { get; set; }

        public void AddMessageData (string key, object data)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            this.Data.Add(new KeyValuePair<string, object>(key, data));
        }

        public object GetMessageData (string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            object obj;

            if (!this.Data.TryGetValue(key, out obj))
            {
                throw new ArgumentException(nameof(key));
            }

            return obj;
        }

        #endregion
    }
}
