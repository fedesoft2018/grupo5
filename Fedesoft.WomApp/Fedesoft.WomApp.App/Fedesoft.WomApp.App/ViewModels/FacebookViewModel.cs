//-----------------------------------------------------------------------
// <copyright file="FacebookViewModel.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.App.ViewModels
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    using Fedesoft.WomApp.App.Models;
    using Fedesoft.WomApp.App.Services;
    
    /// <summary>
    /// Defines the <see cref="FacebookViewModel" />
    /// </summary>
    public class FacebookViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Defines the facebookProfile
        /// </summary>
        private FacebookProfile facebookProfile;

        /// <summary>
        /// Defines the PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the FacebookProfile
        /// </summary>
        public FacebookProfile FacebookProfile
        {
            get { return this.facebookProfile; }
            set
            {
                this.facebookProfile = value;
                this.OnPropertyChanged();
            }
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

        /// <summary>
        /// The OnPropertyChanged
        /// </summary>
        /// <param name="propertyName">The propertyName<see cref="string"/></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
