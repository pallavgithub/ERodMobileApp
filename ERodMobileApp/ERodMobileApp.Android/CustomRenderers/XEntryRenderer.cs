using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using ERodMobileApp.CustomRenderers;
using ERodMobileApp.Droid.CustomRenderers;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(XEntry), typeof(XEntryRenderer))]

namespace ERodMobileApp.Droid.CustomRenderers
{
    class XEntryRenderer : EntryRenderer
    {
        public XEntryRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control != null)
            {
                // do whatever you want to the UITextField here!
                Control.Background = new ColorDrawable(Android.Graphics.Color.Rgb(255, 245, 246));
                Control.SetPadding(20, 0, 20, 0);
                Control.Gravity = GravityFlags.CenterVertical;
                TextAlignment = Android.Views.TextAlignment.Center;
                Control.TextAlignment = Android.Views.TextAlignment.Center;
                GradientDrawable gd = new GradientDrawable();
                gd.SetCornerRadius(5);
                this.Control.SetBackground(gd);
            }
        }
    }
}