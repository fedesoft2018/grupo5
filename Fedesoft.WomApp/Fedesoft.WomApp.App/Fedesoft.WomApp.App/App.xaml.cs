using Fedesoft.WomApp.App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Fedesoft.WomApp.App
{
    using Microsoft.AppCenter;
    using Microsoft.AppCenter.Analytics;
    using Microsoft.AppCenter.Crashes;

    public partial class App : Application
	{
        private const string AndroidAnalyticsKey = "fcaa7ba2-f60f-41fe-a691-59ef334ddc37";
        private const string UwpAnalyticsKey = "492cdaa5-d89a-4c09-996c-dbe99752c37d";
        private const string IosAnalyticsKey = "202f7c5a-71c2-4012-94e9-014b89143032";

        public App ()
		{
			this.InitializeComponent();
			MainPage = new MainMenu();
            //MainPage = new MapPage();
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
            AppCenter.Start($"android={AndroidAnalyticsKey};uwp={UwpAnalyticsKey};ios={IosAnalyticsKey}", typeof(Analytics), typeof(Crashes));
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
