//-----------------------------------------------------------------------
// <copyright file="FacebookViewModel.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.App.ViewModels
{
    using System;
    using System.Windows.Input;

    using Fedesoft.WomApp.App.ViewModels.Base;
    using Fedesoft.WomApp.App.Views;
    using Fedesoft.WomApp.CrossCutting;
    using Fedesoft.WomApp.Domain;
    using Fedesoft.WomApp.Services;

    using Plugin.Settings;

    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="FacebookViewModel" />
    /// </summary>
    public class FacebookViewModel : ViewModelBase
    {
        /// <summary>
        /// Defines the facebookProfile
        /// </summary>
        private FacebookProfile facebookProfile;

        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookViewModel"/> class.
        /// </summary>
        public FacebookViewModel()
        {
            this.FacebookNavigatedCommand = new Command((e) => this.OnFacebookNavigated(e));
        }

        /// <summary>
        /// Gets the FacebookNavigatedCommand
        /// </summary>
        public ICommand FacebookNavigatedCommand { get; private set; }

        /// <summary>
        /// Gets or sets the FacebookProfile
        /// </summary>
        public FacebookProfile FacebookProfile { get => this.facebookProfile; set => this.SetProperty(ref this.facebookProfile, value); }

        /// <summary>
        /// Gets the FbUri
        /// </summary>
        public string FbUri =>
            $"https://www.facebook.com/dialog/oauth?client_id={Constants.FacebookClientId}&display=popup&response_type=token&redirect_uri=https://www.facebook.com/connect/login_success.html";

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
                if (url.Contains(Constants.FacebookAccessTokenKey) && url.Contains(Constants.FacebookExpiresKey))
                {
                    var at = url.Replace(Constants.HttpsFacebookUrl, string.Empty);
                    if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.UWP || Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.WPF)
                    {
                        at = url.Replace(Constants.HttpFacebookUrl, string.Empty);
                    }

                    accessToken = at.Remove(at.IndexOf(Constants.FacebookExpiresKey));
                }
            }
            catch (Exception)
            {
            }

            return accessToken;
        }

        /// <summary>
        /// The OnFacebookNavigated
        /// </summary>
        /// <param name="e">The e<see cref="object"/></param>
        private async void OnFacebookNavigated(object e)
        {
            WebNavigatedEventArgs args;
            if (e is WebNavigatedEventArgs)
            {
                args = e as WebNavigatedEventArgs;
            }
            else
            {
                return;
            }

            var accessToken = this.ExtractAccessTokenFromUrl(args.Url);
            try
            {
                if (!string.IsNullOrEmpty(accessToken))
                {
                    var service = new FacebookServices();
                    var user = await service.GetUserFromFacebookProfileAsync(accessToken);
                    CrossSettings.Current.AddOrUpdateValue(Constants.UserIdKey, user.UserId);
                    await App.NavPage.PushAsync(new UserProfilePage());
                }
            }
            catch (Exception)
            {
                await App.NavPage.DisplayAlert(Constants.WomAppTitle, "Error al crear el usuario", Constants.OkButton);
            }
        }
    }
}
