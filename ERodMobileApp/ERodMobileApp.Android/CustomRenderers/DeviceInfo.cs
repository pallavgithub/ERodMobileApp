using Android.Telephony;
using ERodMobileApp.Droid.CustomRenderers;
using ERodMobileApp.Helpers;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceInfo))]
namespace ERodMobileApp.Droid.CustomRenderers
{
    public class DeviceInfo : IDeviceInfo
    {
        [System.Obsolete]
        public string GetPhoneNumber()
        {
            var tMgr = (TelephonyManager)Forms.Context.ApplicationContext.GetSystemService(Android.Content.Context.TelephonyService);
            return tMgr.Line1Number;
        }
    }
}