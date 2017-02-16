using System.Collections.Generic;
using System.Reflection;

using Android.App;
using Android.Content;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Widget;

using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

using Proxim.Phone.Core.Startup;
using Proxim.Phone.Droid.Utilities;




namespace Proxim.Phone.Droid
{
    public class Setup : MvxAndroidSetup
    {
        #region Instance Constructor/Destructor

        public Setup (Context applicationContext)
                : base(applicationContext)
        {
        }

        #endregion




        #region Overrides

        protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
        {
            typeof(NavigationView).Assembly,
            typeof(FloatingActionButton).Assembly,
            typeof(Toolbar).Assembly,
            typeof(DrawerLayout).Assembly,
            typeof(ViewPager).Assembly
        };

        protected override IMvxApplication CreateApp ()
        {
            return new App();
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter ()
        {
            MvxFragmentsPresenter mvxFragmentsPresenter = new MvxFragmentsPresenter(this.AndroidViewAssemblies);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);

            //add a presentation hint handler to listen for pop to root
            mvxFragmentsPresenter.AddPresentationHintHandler<MvxPanelPopToRootPresentationHint>(hint =>
            {
                Activity activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
                FragmentActivity fragmentActivity = activity as FragmentActivity;

                for (int i = 0; i < fragmentActivity.SupportFragmentManager.BackStackEntryCount; i++)
                {
                    fragmentActivity.SupportFragmentManager.PopBackStack();
                }
                return true;
            });
            //register the presentation hint to pop to root
            //picked up in the third view model
            Mvx.RegisterSingleton<MvxPresentationHint>(() => new MvxPanelPopToRootPresentationHint());
            return mvxFragmentsPresenter;
        }

        protected override void InitializeFirstChance ()
        {
            base.InitializeFirstChance();

            int i = 0;

            //Mvx.RegisterSingleton<ILocationService>(new LocationService(this.ApplicationContext));
            //Mvx.RegisterSingleton<ISessionService>(new SessionService());
            //Mvx.RegisterSingleton<IDialogService>(new DialogService());
            //Mvx.RegisterSingleton<ILoginService>(new LoginService(this.ApplicationContext));
        }

        #endregion
    }
}
