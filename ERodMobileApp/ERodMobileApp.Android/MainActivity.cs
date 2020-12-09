using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using ERodMobileApp.Droid.CustomRenderers;
using Prism;
using Prism.Ioc;
using System;

namespace ERodMobileApp.Droid
{
    [Activity(Theme = "@style/MainTheme",
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.ReadPhoneNumbers, Manifest.Permission.ReadSms, Manifest.Permission.ReadPhoneState }, 0);
            base.OnCreate(savedInstanceState);
            //if (ContextCompat.CheckSelfPermission(this, permission) != Permission.Granted)
            //{
            ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.ReadPhoneState, Manifest.Permission.ReadSms, Manifest.Permission.ReadPhoneNumbers }, 0);
            //}
            //else
            //{
            //    System.Diagnostics.Debug.WriteLine("Permission Granted!!!");
            //}
            Xamarin.Forms.DependencyService.Register<MessageAndroid>();

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(new AndroidInitializer()));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
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

