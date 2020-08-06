namespace App1.UWP
{
    /// <summary>
    /// The main entry point to the app.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new App1.App());
        }
    }
}
