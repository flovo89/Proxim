using Plugin.BLE.Abstractions.Contracts;




namespace Proxim.Phone.Core.Interfaces.ModuleInterfaces
{
    public interface IBluetoothModule : IModule
    {
        bool GetBluetoothAvailable ();

        bool GetBluetoothEnabled ();

        BluetoothState GetBluetoothState ();

        void StartAdvertising ();

        void StartDiscovery ();

        void StopAdvertising ();

        void StopDiscovery ();

        //TODO: Connect / Disconnect
    }
}
