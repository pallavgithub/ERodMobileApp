﻿using ERodMobileApp.iOS.CustomRenderers;
using Foundation;
using Prism;
using Prism.Ioc;
using UIKit;
using Xamarin.Forms;
namespace ERodMobileApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var controller = new SplashPlayerController();


            var NavController = new UINavigationController(controller);

            Window.RootViewController = NavController;
            Window.MakeKeyAndVisible();

            MessagingCenter.Subscribe<object, object>(this, "ShowMainScreen", (sender, args) =>
            {
                LoadApplication(new App(new iOSInitializer()));
                base.FinishedLaunching(app, options);
            });


            return true;

        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}
