using Fedesoft.WomApp.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fedesoft.WomApp.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FacebookProfilePage : ContentPage
	{
        private const string HttpsFacebookUrl = "https://www.facebook.com/connect/login_success.html#access_token=";
        private const string HttpFacebookUrl = "http://www.facebook.com/connect/login_success.html#access_token=";
        private string ClientId = "2149804661917953";

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

        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {
            var accessToken = ExtractAccessTokenFromUrl(e.Url);
            if (!string.IsNullOrEmpty(accessToken))
            {
                var vm = BindingContext as FacebookViewModel;
                await vm.SetFacebookUserProfileAsync(accessToken);
                this.Content = this.MainStackLayout;
            }
        }

        private string ExtractAccessTokenFromUrl(string url)
        {
            var accessToken = string.Empty;
            if (url.Contains("access_token") && url.Contains("&expires_in="))
            {
                var at = url.Replace(HttpsFacebookUrl, string.Empty);
                if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WPF)
                {
                    at = url.Replace(HttpFacebookUrl, string.Empty);
                }

                accessToken = at.Remove(at.IndexOf("&expires_in="));
            }

            return accessToken;
        }
    }
}