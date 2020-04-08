using Foundation;
using Geocortex.Mobile;
using Geocortex.Mobile.Composition.Logging;
using Geocortex.Mobile.Infrastructure.App;
using Geocortex.Mobile.Infrastructure.Configuration;
using Geocortex.Mobile.Infrastructure.Platform;
using Geocortex.Mobile.Platform;
using Geocortex.Mobile.Utilities;
using System;
using System.Diagnostics;
using System.Globalization;
using UIKit;
using Xamarin.Forms;

namespace App1.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : GeocortexAppDelegate
    {
        private Geocortex.Mobile.App _viewerApp;

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
