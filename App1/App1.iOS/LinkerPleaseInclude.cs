using Esri.ArcGISRuntime.Xamarin.Forms.Platform.iOS;

namespace App1.iOS
{
    // Get around what seems to be a linker issue, allowing custom MapViewRenderer to be used.
    class LinkerPleaseInclude : MapViewRenderer
    {
    }
}
