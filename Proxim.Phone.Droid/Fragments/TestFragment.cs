using Android.Runtime;

using Proxim.Phone.Core.ViewModels;




namespace Proxim.Phone.Droid.Fragments
{
    //[MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register ("Proxim.Phone.Droid.Fragments.TestFragment")]
    public class LoginFragment : BaseFragment<BluetoothViewModel>
    {
        #region Overrides

        protected override int FragmentId => Resource.Layout.Main;

        #endregion




        //public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //{
        //    this.ShowHamburgerMenu = true;
        //    return base.OnCreateView(inflater, container, savedInstanceState);
        //}
    }
}
