using Foundation;
using UIKit;
using VertiGIS.Mobile;
using VertiGIS.Mobile.Platform;
using Xamarin.Forms;

namespace App1.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : VertiGISAppDelegate
    {
        private App _viewerApp;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            HandleExceptions();
            IOSInitializer.Init();
            Forms.Init();
            var viewerApp = new App();
            _viewerApp = viewerApp;

            // Handle startup urls
            // See below comment in OpenUrl, then uncomment the code below
            // SetLaunchUrl(viewerApp, options);

            LoadApplication(viewerApp);
            return base.FinishedLaunching(app, options);
        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            // Handle startup urls
            // Add a URL type to Info.plist, then uncomment the code below
            // return HandleOpenUrl(app, url, options, _viewerApp);
            return false;
        }

        override public UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow forWindow)
        {
            return GetSupportedOrientations();
        }
    }
}
