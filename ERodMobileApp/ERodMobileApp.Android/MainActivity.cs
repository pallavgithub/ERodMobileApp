using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using ERodMobileApp.Droid.CustomRenderers;
using ERodMobileApp.Helpers;
using ERodMobileApp.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;

namespace ERodMobileApp.Droid
{
    [Activity(Theme = "@style/MainTheme", LaunchMode = LaunchMode.SingleTop,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;
            //ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.ReadPhoneNumbers, Manifest.Permission.ReadSms, Manifest.Permission.ReadPhoneState }, 0);
            base.OnCreate(savedInstanceState);
            //if (ContextCompat.CheckSelfPermission(this, permission) != Permission.Granted)
            //{
            //ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.ReadPhoneState, Manifest.Permission.ReadSms, Manifest.Permission.ReadPhoneNumbers }, 0);
            //}
            //else
            //{
            //    System.Diagnostics.Debug.WriteLine("Permission Granted!!!");
            //}
            CreateNotificationFromIntent(Intent);
            var uiOptions = (int)Window.DecorView.SystemUiVisibility;
            uiOptions ^= (int)SystemUiFlags.LayoutStable;
            uiOptions ^= (int)SystemUiFlags.LayoutFullscreen;
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
            Window.SetFlags(WindowManagerFlags.TranslucentStatus, WindowManagerFlags.TranslucentStatus);
            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            //allowing the device to change the screen orientation based on the rotation
            MessagingCenter.Subscribe<SignaturePage>(this, "allowLandScapePortrait", sender =>
            {
                RequestedOrientation = ScreenOrientation.Landscape;
            });

            //during page close setting back to portrait
            MessagingCenter.Subscribe<SignaturePage>(this, "preventLandScape", sender =>
            {
                RequestedOrientation = ScreenOrientation.Portrait;
            });
            Xamarin.Forms.DependencyService.Register<MessageAndroid>();

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(new AndroidInitializer()));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        protected override void OnNewIntent(Intent intent)
        {
            CreateNotificationFromIntent(intent);
        }
        void CreateNotificationFromIntent(Intent intent)
        {
            if (intent?.Extras != null)
            {
                MessagingCenter.Send("message", "FromNotification");
                string title = intent.GetStringExtra(AndroidNotificationManager.TitleKey);
                string message = intent.GetStringExtra(AndroidNotificationManager.MessageKey);
                DependencyService.Get<INotificationManager>().ReceiveNotification(title, message);
            }
        }

    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}

