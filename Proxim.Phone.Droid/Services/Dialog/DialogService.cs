using Android.App;

using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

using Proxim.Phone.Core.Interfaces.ServiceInterfaces;




namespace Proxim.Phone.Droid.Services.Dialog
{
    public class DialogService : IDialogService
    {
        #region Interface: IDialogService

        public void Alert (string message, string btnText)
        {
            IMvxAndroidCurrentTopActivity top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            Activity act = top.Activity;

            AlertDialog.Builder adb = new AlertDialog.Builder(act);
            adb.SetMessage(message);
            adb.SetPositiveButton(btnText, (sender, args) =>
            {
                //No logic necessary!
            });
            adb.Create().Show();
        }

        public void Initialize ()
        {
        }

        #endregion
    }
}
