﻿using VertiGIS.Mobile;
using VertiGIS.Mobile.Infrastructure.Configuration;
using VertiGIS.Mobile.Toolkit.Views;
using System;
using Xamarin.Forms;

namespace App1
{
    public class App : VertiGIS.Mobile.App
    {
        public App() : base()
        {
            // Add the styles from this page to the application - overrides styles from VertiGIS.Mobile
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
