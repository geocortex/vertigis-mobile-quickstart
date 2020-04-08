using Geocortex.Mobile;
using Geocortex.Mobile.Infrastructure.Configuration;
using Geocortex.Mobile.Infrastructure.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static Xamarin.Forms.Device;

namespace App1
{
    public class App : Geocortex.Mobile.App
    {
        public App()
            : base(new Uri("resource://app.json"))
        {
            // Add the styles from this page to the application - overrides styles from Geocortex.Mobile
            var res = new Styles().Resources;
            this.Resources.MergedDictionaries.Add(res);

            MainPage = new ContentPage()
            {
                Content = GetContent()
            };

            // Register additional assemblies to search for configured assembly attributes.
            AssemblyManager.RegisterAssemblies(this.GetType().Assembly);
        }

        protected override async void OnStart()
        {
            await InitializeAsync();
            var appPage = await Bootstrapper.LoadAppAysnc(new Uri("resource://app.json"));
            await Bootstrapper.DisplayAppAsync(appPage.Page);
        }

        private View GetContent()
        {
            // Stack
            var stack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 15
            };

            // Spinner
            var spinner = new EnhancedActivityIndicator()
            {
                IsRunning = true
            };
            spinner.WidthRequest = 75;
            spinner.HeightRequest = 75;
            stack.Children.Add(spinner);

            // Label
            var label = new Label()
            {
                TextColor = Color.Black
            };
            stack.Children.Add(label);

            void ShowStatus(object sender, LoadingEventArgs e)
            {
                if (GlobalConfiguration.Instance.StartupLoadStatus)
                {
                    label.Text = e.LoadAction;
                }
                else
                {
                    LoadingAction -= ShowStatus;
                }
            }

            LoadingAction += ShowStatus;

            return stack;
        }
    }
}
