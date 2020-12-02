using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using Xamarin.Essentials;

namespace ERodMobileApp.Droid
{
    [Activity(Theme = "@style/MainTheme.Splash",
              MainLauncher = true,
              NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();

            SetContentView(Resource.Layout.SplashLayout);

            VideoView videoView = (VideoView)FindViewById<VideoView>(Resource.Id.splashVideo);

            var isLongVideoRun = Preferences.Get("IsLongVideoRun", false);
            String uriPath;
            if (isLongVideoRun)
            {
                uriPath = "android.resource://" + Android.App.Application.Context.PackageName + "/" + Resource.Raw.an1;
            }
            else
            {
                uriPath = "android.resource://" + Android.App.Application.Context.PackageName + "/" + Resource.Raw.an2;
                Preferences.Set("IsLongVideoRun", true);
            }

            Android.Net.Uri videoPlay = Android.Net.Uri.Parse(uriPath);
            videoView.SetVideoURI(videoPlay);
            videoView.Visibility = ViewStates.Visible;

            videoView.Prepared += delegate {
                videoView.Start();
            };

            videoView.Completion += delegate {
                //Intent intent = new Intent(this, typeof(MainActivity));
                //StartActivity(intent);
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            };
        }
    }
}
