using ERodMobileApp.ViewModels;
using ERodMobileApp.Views;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace ERodMobileApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnStart()
        {
           // await NavigationService.NavigateAsync("NavigationPage/LoginPage");
            await NavigationService.NavigateAsync("MainPage");
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            Device.SetFlags(new string[] { "MediaElement_Experimental" });
            Plugin.Media.CrossMedia.Current.Initialize();
           // MainPage = new NavigationPage(new MainPage());

        }

        protected override void OnSleep()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            // Handle when your app resumes
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                Page page;
                if (MainPage is NavigationPage)
                {
                    page = ((NavigationPage)MainPage).CurrentPage;
                }
                else
                {
                    page = MainPage;
                }

                //page.DisplayAlert("Status", "Internet has been disconnected.", "OK");
            }

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<NewOrderPage, NewOrderPageViewModel>();
            containerRegistry.RegisterForNavigation<ReviewOrderPage, ReviewOrderPageViewModel>();
            containerRegistry.RegisterForNavigation<SignaturePage, SignaturePageViewModel>();
            containerRegistry.RegisterForNavigation<ProductsPage, ProductsPageViewModel>();
        }

        public static async Task<PermissionStatus> CheckAndRequestPhonePermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Phone>();
            if (status == PermissionStatus.Granted)
                return status;
            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }
            status = await Permissions.RequestAsync<Permissions.Phone>();
            return status;
        }
        public async Task<PermissionStatus> CheckAndRequestSMSPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Sms>();
            if (status == PermissionStatus.Granted)
                return status;
            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }
            status = await Permissions.RequestAsync<Permissions.Sms>();
            return status;
        }
        public async Task<PermissionStatus> CheckAndRequestStorageReadPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
            if (status == PermissionStatus.Granted)
                return status;
            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }
            status = await Permissions.RequestAsync<Permissions.StorageRead>();
            return status;
        }
        public async Task<PermissionStatus> CheckAndRequestStorageWritePermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
            if (status == PermissionStatus.Granted)
                return status;
            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }
            status = await Permissions.RequestAsync<Permissions.StorageWrite>();
            return status;
        }
    }
}
