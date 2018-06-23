using Fedesoft.WomApp.App.Models;
using Fedesoft.WomApp.App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fedesoft.WomApp.App.ViewModels
{
    public class FacebookViewModel : INotifyPropertyChanged
    {
        private FacebookProfile facebookProfile;

        public FacebookProfile FacebookProfile
        {
            get { return this.facebookProfile; }
            set
            {
                this.facebookProfile = value;
                this.OnPropertyChanged();
            }
        }

        public async Task SetFacebookUserProfileAsync(string accessToken)
        {
            var facebookServices = new FacebookServices();
            this.FacebookProfile = await facebookServices.GetFacebookProfileAsync(accessToken);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
