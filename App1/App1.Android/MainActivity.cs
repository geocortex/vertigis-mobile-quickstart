using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Geocortex.Mobile;
using Geocortex.Mobile.Platform;
using Java.Lang;
using Xamarin.Forms;
using static Java.Lang.Thread;

namespace App1.Droid
{
    [Activity(Name = "app1.mainactivity", Label = "App1", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : GeocortexMobileActivity, IUncaughtExceptionHandler
    {
        protected override void OnCreate(Bundle bundle)
        {
            DefaultUncaughtExceptionHandler = this;
            HandleExceptions();
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            AndroidInitializer.Init(this, bundle);
            Forms.Init(this, bundle);

            // The app was launched with the splash screen theme, so change it to the main theme now
            base.SetTheme(Resource.Style.MainTheme);

            base.OnCreate(bundle);

            var app = new App();

            // Handle startup urls
            HandleOnCreateIntent(app); // Startup urls
            HandleFullyDrawn(app); // Android diagnostics
            HandleAppPermissions(app); // Location, bluetooth, etc.

            LoadApplication(app);
        }

        protected override void OnNewIntent(Intent intent)
        {
            // Handle Geocortex Mobile startup parameters
            // Need to add an intent-filter in AndroidManifest.xml, then uncomment code below
            // HandleNewIntent(intent);
        }

        public void UncaughtException(Thread t, Throwable e)
        {
            //DisplayError(e.Message);
        }
    }
}
