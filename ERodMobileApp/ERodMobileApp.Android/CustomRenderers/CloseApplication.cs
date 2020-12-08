using ERodMobileApp.Droid.CustomRenderers;
using ERodMobileApp.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(CloseApplication))]

namespace ERodMobileApp.Droid.CustomRenderers
{
    public class CloseApplication : IExitApp
    {
        public void closeApplication()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}