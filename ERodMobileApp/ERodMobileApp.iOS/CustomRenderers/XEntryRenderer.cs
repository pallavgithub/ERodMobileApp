using System.ComponentModel;
using CoreGraphics;
using ERodMobileApp.CustomRenderers;
using ERodMobileApp.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(XEntry), typeof(XEntryRenderer))]
namespace ERodMobileApp.iOS.CustomRenderers
{
    class XEntryRenderer : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control != null)
            {
                var xEntry = (XEntry)Element;
                Control.VerticalAlignment = UIControlContentVerticalAlignment.Center; //Control: UiTextField
                /// Control.BackgroundColor = UIColor.FromRGB(252, 243, 237);
                Control.BorderStyle = UITextBorderStyle.None;

                if (xEntry != null && xEntry.RemovePadding)
                {
                    Control.LeftView = new UIView(new CGRect(0, 0, 0, 0));
                }
                else
                {
                    Control.LeftView = new UIView(new CGRect(0, 0, 15, 0));
                }
                Control.LeftViewMode = UITextFieldViewMode.Always;
                if (xEntry != null && xEntry.RemovePadding)
                {
                    Control.RightView = new UIView(new CGRect(0, 0, 0, 0));
                }
                else
                {
                    Control.RightView = new UIView(new CGRect(0, 0, 15, 0));
                }
                Control.RightViewMode = UITextFieldViewMode.Always;
                Control.Layer.CornerRadius = 5;
            }
        }
    }
}