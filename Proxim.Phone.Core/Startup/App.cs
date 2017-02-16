using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;




namespace Proxim.Phone.Core.Startup
{
    public class App : MvxApplication
    {
        #region Overrides

        public override void Initialize ()
        {
            this.CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();

            Mvx.ConstructAndRegisterSingleton<IMvxAppStart, AppStart>();

            IMvxAppStart appStart = Mvx.Resolve<IMvxAppStart>();

            this.RegisterAppStart(appStart);
        }

        #endregion
    }
}
