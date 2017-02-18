using Android.Bluetooth.LE;

using MvvmCross.Platform;

using Plugin.BLE.Abstractions.Contracts;

using Proxim.Phone.Core.Interfaces.ModuleInterfaces;




namespace Proxim.Phone.Droid.Modules.Bluetooth
{
    public class BluetoothModule : IBluetoothModule
    {
        #region Instance Properties/Indexer

        private IAdapter Adapter { get; set; }

        private IBluetoothLE BluetoothLe { get; set; }

        private BluetoothLeAdvertiser BluetoothLeAdvertiser { get; set; }

        #endregion


        //TODO: Check how to use BluetoothLeAdvertiser

        #region Interface: IBluetoothModule

        public bool GetBluetoothAvailable ()
        {
            return this.BluetoothLe.IsAvailable;
        }

        public bool GetBluetoothEnabled ()
        {
            return this.BluetoothLe.IsOn;
        }

        public BluetoothState GetBluetoothState ()
        {
            return this.BluetoothLe.State;
        }

        public void StartAdvertising ()
        {
            throw new System.NotImplementedException();
        }

        public void StopAdvertising ()
        {
            throw new System.NotImplementedException();
        }

        public void Initialize ()
        {
            this.BluetoothLe = Mvx.Resolve<IBluetoothLE>();
            this.Adapter = Mvx.Resolve<IAdapter>();
        }

        #endregion
    }
}
