//-----------------------------------------------------------------------
// <copyright file="FacebookProfilePage.xaml.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.App.Views
{
    using System;

    using Fedesoft.WomApp.App.ViewModels;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Defines the <see cref="FacebookProfilePage" />
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FacebookProfilePage : ContentPage
    {
        /// <summary>
        /// Defines the HttpFacebookUrl
        /// </summary>
        private const string HttpFacebookUrl = "http://www.facebook.com/connect/login_success.html#access_token=";

        /// <summary>
        /// Defines the HttpsFacebookUrl
        /// </summary>
        private const string HttpsFacebookUrl = "https://www.facebook.com/connect/login_success.html#access_token=";

        /// <summary>
        /// Defines the ClientId
        /// </summary>
        private string ClientId = "2149804661917953";

        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookProfilePage"/> class.
        /// </summary>
        public FacebookProfilePage()
        {
            try
            {
                this.InitializeComponent();
                var apiRequest =
                    $"https://www.facebook.com/dialog/oauth?client_id={ClientId}&display=popup&response_type=token&redirect_uri=https://www.facebook.com/connect/login_success.html";
                var webView = new WebView
                {
                    Source = apiRequest,
                    HeightRequest = 1
                };
                webView.Navigated += WebViewOnNavigated;
                Content = webView;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// The ExtractAccessTokenFromUrl
        /// </summary>
        /// <param name="url">The url<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        private string ExtractAccessTokenFromUrl(string url)
        {
            var accessToken = string.Empty;
            try
            {
                if (url.Contains("access_token") && url.Contains("&expires_in="))
                {
                    var at = url.Replace(HttpsFacebookUrl, string.Empty);
                    if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
                    {
                        at = url.Replace(HttpFacebookUrl, string.Empty);
                    }

                    accessToken = at.Remove(at.IndexOf("&expires_in="));
                }
            }
            catch (Exception)
            {
            }

            return accessToken;
        }

        /// <summary>
        /// The WebViewOnNavigated
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="WebNavigatedEventArgs"/></param>
        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {
            var accessToken = ExtractAccessTokenFromUrl(e.Url);
            try
            {
                if (!string.IsNullOrEmpty(accessToken))
                {
                    var vm = BindingContext as FacebookViewModel;
                    await vm.SetFacebookUserProfileAsync(accessToken);
                    this.Content = this.MainStackLayout;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
