using System;
using System.Reflection;
using VertiGIS.Mobile.Platform;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace App1.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// The singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            WindowsAppHandlers.InitializeBackgrounding(this);
            WindowsAppHandlers.HandleExceptions(this);
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            /* Call any 3rd party library Init methods here */

            // Pass in any 'extra' assemblies, that will be passed along to a Xamarin.Forms Init() call
            WindowsAppHandlers.HandleOnLaunched(e, typeof(MainPage), Array.Empty<Assembly>());
        }

        protected override void OnActivated(IActivatedEventArgs args)
        {
            /* Call any 3rd party library Init methods here */

            // Handle VertiGIS Studio Mobile startup parameters
            // Need to add a uri schema declaration in the Package.appxmanifest, then uncomment code below
            // Pass in any 'extra' assemblies, that will be passed along to a Xamarin.Forms Init() call
            // WindowsAppHandlers.HandleOnActivated(args, typeof(MainPage), Array.Empty<Assembly>());
        }

        protected override void OnBackgroundActivated(BackgroundActivatedEventArgs args)
        {
            base.OnBackgroundActivated(args);

            WindowsAppHandlers.HandleOnBackgroundActivated(args);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private static void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
