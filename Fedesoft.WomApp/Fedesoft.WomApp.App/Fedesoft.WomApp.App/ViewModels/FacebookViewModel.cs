//-----------------------------------------------------------------------
// <copyright file="FacebookViewModel.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.App.ViewModels
{
    using System.Threading.Tasks;

    using Fedesoft.WomApp.App.ViewModels.Base;
    using Fedesoft.WomApp.Domain;
    using Fedesoft.WomApp.Services;

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
        /// Gets or sets the FacebookProfile
        /// </summary>
        public FacebookProfile FacebookProfile
        {
            get => this.facebookProfile;
            set => this.SetProperty(ref this.facebookProfile, value);
        }

        /// <summary>
        /// The SetFacebookUserProfileAsync
        /// </summary>
        /// <param name="accessToken">The accessToken<see cref="string"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task SetFacebookUserProfileAsync(string accessToken)
        {
            var facebookServices = new FacebookServices();
            this.FacebookProfile = await facebookServices.GetFacebookProfileAsync(accessToken);
        }
    }
}
