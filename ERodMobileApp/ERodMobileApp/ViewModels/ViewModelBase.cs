using ERodMobileApp.Helpers;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ERodMobileApp.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        private bool _isNotConnected;
        public bool IsNotConnected
        {
            get { return _isNotConnected; }
            set { SetProperty(ref _isNotConnected, value); }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }
        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
            Connectivity.ConnectivityChanged += Internet_ConnectionChanged;
            IsNotConnected = Connectivity.NetworkAccess != NetworkAccess.Internet;
        }
        ~ViewModelBase()
        {
            Connectivity.ConnectivityChanged -= Internet_ConnectionChanged;
        }
        void Internet_ConnectionChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var toast = DependencyService.Get<IMessage>();
            if (e.NetworkAccess != NetworkAccess.Internet)
            {
                //Application.Current.MainPage.DisplayAlert("Alert", "No Internet Connection", "OK");
                toast.LongAlert("No Internet Connection");
            }
            else
            {
                //Application.Current.MainPage.DisplayAlert("Alert", "Your Internet Connection is Back", "OK");
                toast.LongAlert("Your Internet Connection is Back");
            }
        }


        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
