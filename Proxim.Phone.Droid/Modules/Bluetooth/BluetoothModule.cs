using Android.Bluetooth;
using Android.Bluetooth.LE;
using Android.Content;

using MvvmCross.Platform;

using Plugin.BLE.Abstractions.Contracts;

using Proxim.Phone.Core.Interfaces.ModuleInterfaces;
using Proxim.Phone.Core.Interfaces.ServiceInterfaces;
using Proxim.Phone.Core.Services.Logging;




namespace Proxim.Phone.Droid.Modules.Bluetooth
{
    public class BluetoothModule : IBluetoothModule
    {
        #region Instance Constructor/Destructor

        public BluetoothModule (Context context)
        {
            BluetoothManager manager = (BluetoothManager)context.GetSystemService(Context.BluetoothService);
            BluetoothAdapter adapter = manager.Adapter;
            this.BluetoothLeAdvertiser = adapter.BluetoothLeAdvertiser;
        }

        #endregion




        #region Instance Properties/Indexer

        private IAdapter Adapter { get; set; }

        private BleAdvertiseCallback AdvertiseCallback { get; set; }

        private IBluetoothLE BluetoothLe { get; set; }

        private BluetoothLeAdvertiser BluetoothLeAdvertiser { get; }

        private ILoggingService LoggingService { get; set; }

        #endregion




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

        public void Initialize ()
        {
            this.LoggingService = Mvx.Resolve<ILoggingService>();
            this.BluetoothLe = Mvx.Resolve<IBluetoothLE>();
            this.Adapter = Mvx.Resolve<IAdapter>();
            

            this.AdvertiseCallback = new BleAdvertiseCallback(this.LoggingService);
        }

        public void StartAdvertising ()
        {
            AdvertiseSettings.Builder builder = new AdvertiseSettings.Builder();
            builder.SetAdvertiseMode(AdvertiseMode.LowLatency);
            builder.SetConnectable(true);
            builder.SetTimeout(0);
            builder.SetTxPowerLevel(AdvertiseTx.PowerHigh);
            AdvertiseData.Builder dataBuilder = new AdvertiseData.Builder();
            dataBuilder.SetIncludeDeviceName(true);
            //dataBuilder.AddServiceUuid(ParcelUuid.FromString("ffe0ecd2-3d16-4f8d-90de-e89e7fc396a5"));
            dataBuilder.SetIncludeTxPowerLevel(true);

            this.BluetoothLeAdvertiser.StartAdvertising(builder.Build(), dataBuilder.Build(), this.AdvertiseCallback);
        }

        public void StartDiscovery ()
        {
            this.Adapter.StartScanningForDevicesAsync();
        }

        public void StopAdvertising ()
        {
            this.BluetoothLeAdvertiser.StopAdvertising(this.AdvertiseCallback);
        }

        public void StopDiscovery ()
        {
            this.Adapter.StopScanningForDevicesAsync();
            
        }

        #endregion
    }




    public class BleAdvertiseCallback : AdvertiseCallback
    {
        #region Instance Constructor/Destructor

        public BleAdvertiseCallback (ILoggingService loggingService)
        {
            this.LoggingService = loggingService;
        }

        #endregion




        #region Instance Properties/Indexer

        private ILoggingService LoggingService { get; }

        #endregion




        #region Overrides

        public override void OnStartFailure (AdvertiseFailure errorCode)
        {
            this.LoggingService.DebugLog(nameof(BleAdvertiseCallback), LogLevel.Error, "Advertising failure during startup", null);
            base.OnStartFailure(errorCode);
        }

        public override void OnStartSuccess (AdvertiseSettings settingsInEffect)
        {
            this.LoggingService.DebugLog(nameof(BleAdvertiseCallback), LogLevel.Information, "Advertising started successfully", null);
            base.OnStartSuccess(settingsInEffect);
        }

        #endregion
    }
}
