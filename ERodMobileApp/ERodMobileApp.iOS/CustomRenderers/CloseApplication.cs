using ERodMobileApp.Helpers;
using ERodMobileApp.iOS.CustomRenderers;
using System.Threading;

[assembly: Xamarin.Forms.Dependency(typeof(CloseApplication))]

namespace ERodMobileApp.iOS.CustomRenderers
{
    public class CloseApplication : IExitApp
    {
        public void closeApplication()
        {
            Thread.CurrentThread.Abort();
        }
    }
}