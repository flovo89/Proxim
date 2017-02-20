using System.Collections.Generic;

using MvvmCross.Platform;

using Plugin.BLE.Abstractions.Contracts;

using Proxim.Phone.Core.Interfaces.ServiceInterfaces;
using Proxim.Phone.Core.Services.Messaging;




namespace Proxim.Phone.Core.ViewModels
{
    public class BluetoothViewModel : BaseViewModel
    {
        #region Instance Fields

        private IList<IDevice> _deviceList;

        #endregion




        #region Instance Properties/Indexer

        public IList<IDevice> DeviceList
        {
            get
            {
                return this._deviceList;
            }
            set
            {
                this._deviceList = value;
                this.RaisePropertyChanged(() => this.DeviceList);
            }
        }

        private IMessagingService MessagingService { get; set; }

        #endregion




        #region Instance Methods

        private void ReceiveMessage (IMessage message)
        {
            if (message.Name == MessageNames.DeviceDiscovered)
            {
                this.DeviceList = message.GetMessageData(MessageNames.DeviceDiscoveredKey1) as IList<IDevice>;
            }
        }

        #endregion




        #region Overrides

        public override void Start ()
        {
            this.MessagingService = Mvx.Resolve<IMessagingService>();
            this.MessagingService.SubscribeReceiver(this.ReceiveMessage);
        }

        #endregion
    }
}
