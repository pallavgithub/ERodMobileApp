using AVFoundation;
using Foundation;
using UIKit;
using Xamarin.Forms;

namespace ERodMobileApp.iOS
{
    class SplashPlayerController : UIViewController
    {
        AVPlayer avplayer;
        AVPlayerLayer avplayerLayer;
        AVAsset avasset;
        AVPlayerItem avplayerItem;


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            avasset = AVAsset.FromUrl(NSUrl.FromFilename("an1.mp4"));
            avplayerItem = new AVPlayerItem(avasset);
            avplayer = new AVPlayer(avplayerItem);
            avplayerLayer = AVPlayerLayer.FromPlayer(avplayer);
            avplayerLayer.Frame = View.Frame;
            View.Layer.AddSublayer(avplayerLayer);
            avplayer.Play();

            NSTimer.CreateScheduledTimer(7, false, (obj) =>
            {
                MessagingCenter.Send<object, object>(this, "ShowMainScreen", null);
            });

            // Perform any additional setup after loading the view, typically from a nib.  
        }

    }
}