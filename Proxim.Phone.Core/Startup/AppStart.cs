using MvvmCross.Core.ViewModels;




namespace Proxim.Phone.Core.Startup
{
    public class AppStart : MvxNavigatingObject,
            IMvxAppStart
    {
        #region Interface: IMvxAppStart

        public void Start (object hint = null)
        {
            //Mvx.Resolve<ISessionService>().Initialize();
            //Mvx.Resolve<IDialogService>().Initialize();
            //Mvx.Resolve<IResourceService>().Initialize();
            //Mvx.Resolve<ILocationService>().Initialize();
            //Mvx.Resolve<ILoggingService>().Initialize();
            //Mvx.Resolve<IMessagingService>().Initialize();
            //Mvx.Resolve<ICommunicationService>().Initialize();
            //Mvx.Resolve<ILoginService>().Initialize();

            //this.ShowViewModel<MainViewModel>();
        }

        #endregion
    }
}
