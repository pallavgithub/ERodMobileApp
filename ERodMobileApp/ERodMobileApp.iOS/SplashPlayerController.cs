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
            bool IsFirstLogin = NSUserDefaults.StandardUserDefaults.BoolForKey("SmallVidIntro");


            if (IsFirstLogin)
            {
                avasset = AVAsset.FromUrl(NSUrl.FromFilename("an1.mp4"));
                
            }
            else
            {
                avasset = AVAsset.FromUrl(NSUrl.FromFilename("an2.mp4"));
                NSUserDefaults.StandardUserDefaults.SetBool(true, "SmallVidIntro");
            }

            avplayerItem = new AVPlayerItem(avasset);
            avplayer = new AVPlayer(avplayerItem);
            avplayerLayer = AVPlayerLayer.FromPlayer(avplayer);
            avplayerLayer.Frame = View.Frame;
            View.Layer.AddSublayer(avplayerLayer);
            avplayer.Play();

            NSNotificationCenter.DefaultCenter.AddObserver(AVPlayerItem.DidPlayToEndTimeNotification, MainScreenHandler);
           
        }

        public void MainScreenHandler(NSNotification notification)
        {
            MessagingCenter.Send<object, object>(this, "ShowMainScreen", null);
        }
    }
}