using Android.Widget;

using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;




namespace Proxim.Phone.Droid.Fragments
{
    public abstract class BaseFragment : MvxFragment
    {
        #region Instance Constructor/Destructor

        protected BaseFragment ()
        {
            this.RetainInstance = true;
        }

        #endregion




        #region Instance Properties/Indexer

        //protected MvxActionBarDrawerToggle DrawerToggle { get; private set; }

        protected bool ShowHamburgerMenu { get; set; } = false;

        protected Toolbar Toolbar { get; private set; }

        #endregion




        #region Abstracts

        protected abstract int FragmentId { get; }

        #endregion




        //    if (this.Toolbar != null)
        //    base.OnActivityCreated(savedInstanceState);
        //{

        //public override void OnActivityCreated(Bundle savedInstanceState)
        //    {
        //        this.DrawerToggle?.SyncState();
        //    }
        //}

        //public override void OnConfigurationChanged(Configuration newConfig)
        //{
        //    base.OnConfigurationChanged(newConfig);
        //    if (this.Toolbar != null)
        //    {
        //        this.DrawerToggle?.OnConfigurationChanged(newConfig);
        //    }
        //}

        //public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //{
        //    base.OnCreateView(inflater, container, savedInstanceState);
        //
        //    View view = this.BindingInflate(this.FragmentId, null);
        //
        //    this.Toolbar = view.FindViewById<Toolbar>(Resource.Id.toolbar);
        //
        //    if (this.Toolbar != null)
        //    {
        //        MainActivity mainActivity = this.Activity as MainActivity;
        //        if (mainActivity == null)
        //        {
        //            return view;
        //        }
        //
        //        mainActivity.SetSupportActionBar(this.Toolbar);
        //
        //        if (this.ShowHamburgerMenu)
        //        {
        //            mainActivity.SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
        //
        //            this.DrawerToggle = new MvxActionBarDrawerToggle(this.Activity, mainActivity.DrawerLayout, this.Toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
        //
        //            this.DrawerToggle.DrawerOpened += (sender, e) => mainActivity.HideSoftKeyboard();
        //            mainActivity.DrawerLayout.AddDrawerListener(this.DrawerToggle);
        //        }
        //    }
        //    return view;
        //}
    }




    public abstract class BaseFragment <TViewModel> : BaseFragment
            where TViewModel : class, IMvxViewModel
    {
        #region Instance Properties/Indexer

        public new TViewModel ViewModel
        {
            get
            {
                return (TViewModel)base.ViewModel;
            }
            set
            {
                base.ViewModel = value;
            }
        }

        #endregion
    }
}
