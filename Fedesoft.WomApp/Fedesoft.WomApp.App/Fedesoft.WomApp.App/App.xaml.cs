//-----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Fedesoft.WomApp.App
{
    using Fedesoft.WomApp.App.Views;
    using Fedesoft.WomApp.CrossCutting;

    using Microsoft.AppCenter;
    using Microsoft.AppCenter.Analytics;
    using Microsoft.AppCenter.Crashes;
    using Plugin.Settings;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="App" />
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Defines the AndroidAnalyticsKey
        /// </summary>
        private const string AndroidAnalyticsKey = "fcaa7ba2-f60f-41fe-a691-59ef334ddc37";

        /// <summary>
        /// Defines the IosAnalyticsKey
        /// </summary>
        private const string IosAnalyticsKey = "202f7c5a-71c2-4012-94e9-014b89143032";

        /// <summary>
        /// Defines the UwpAnalyticsKey
        /// </summary>
        private const string UwpAnalyticsKey = "492cdaa5-d89a-4c09-996c-dbe99752c37d";

        /// <summary>
        /// Defines the NavPage
        /// </summary>
        public static NavigationPage NavPage = null;

        public static string UserId
        {
            get => CrossSettings.Current.GetValueOrDefault(Constants.UserIdKey, string.Empty);
            set => CrossSettings.Current.AddOrUpdateValue(Constants.UserIdKey, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The OnResume
        /// </summary>
        protected override void OnResume()
        {
            this.OpenFirstPage();
        }

        /// <summary>
        /// The OnSleep
        /// </summary>
        protected override void OnSleep()
        {
        }

        /// <summary>
        /// The OnStart
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
            this.OpenFirstPage();
            AppCenter.Start($"android={AndroidAnalyticsKey};uwp={UwpAnalyticsKey};ios={IosAnalyticsKey}", typeof(Analytics), typeof(Crashes));
        }

        private void OpenFirstPage()
        {
            var master = new MainMenu();
            SetNavPage();
            var masterPage = new MasterPage
            {
                Detail = NavPage,
                Master = master
            };
            this.MainPage = masterPage;
        }

        /// <summary>
        /// The SetNavPage
        /// </summary>
        private static void SetNavPage()
        {
            if (!string.IsNullOrEmpty(UserId))
            {
                NavPage = new NavigationPage(new UserProfilePage());
            }
            else
            {
                NavPage = new NavigationPage(new WelcomePage());
            }
        }
    }
}
