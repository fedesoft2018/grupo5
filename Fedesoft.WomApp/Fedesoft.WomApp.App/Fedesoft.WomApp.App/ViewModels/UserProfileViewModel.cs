//-----------------------------------------------------------------------
// <copyright file="UserProfileViewModel.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.App.ViewModels
{
    using System;
    using System.Windows.Input;

    using Fedesoft.WomApp.App.ViewModels.Base;
    using Fedesoft.WomApp.CrossCutting;
    using Fedesoft.WomApp.Domain;
    using Fedesoft.WomApp.Services;

    using Plugin.Settings;

    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="UserProfileViewModel" />
    /// </summary>
    public class UserProfileViewModel : ViewModelBase
    {
        /// <summary>
        /// Defines the birthday
        /// </summary>
        private DateTime birthday;

        /// <summary>
        /// Defines the city
        /// </summary>
        private string city;

        /// <summary>
        /// Defines the name
        /// </summary>
        private string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileViewModel"/> class.
        /// </summary>
        public UserProfileViewModel()
        {
            //this.GetUserProfile();
            this.SaveProfileCommand = new Command(this.OnSaveProfile);
        }

        /// <summary>
        /// Gets or sets the Birthday
        /// </summary>
        public DateTime Birthday { get => birthday; set => this.SetProperty(ref this.birthday, value); }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        public string City
        {
            get { return city; }
            set => this.SetProperty(ref this.city, value);
        }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get => this.name; set => this.SetProperty(ref this.name, value); }

        /// <summary>
        /// Gets the SaveProfileCommand
        /// </summary>
        public ICommand SaveProfileCommand { get; }

        /// <summary>
        /// The GetUserFromService
        /// </summary>
        /// <returns>The <see cref="User"/></returns>
        private static User GetUserFromService()
        {
            var service = new UserService();
            var userTaks = service.GetDataAsync(CrossSettings.Current.GetValueOrDefault(Constants.UserIdKey, string.Empty));
            userTaks.Wait();
            var user = userTaks.Result;
            return user;
        }

        /// <summary>
        /// The GetUserProfile
        /// </summary>
        private void GetUserProfile()
        {
            var user = GetUserFromService();
            if (user != null && !string.IsNullOrEmpty(user.Name))
            {
                this.Name = user.Name;
                this.Birthday = user.BirthDay;
                this.City = user.City;
            }
        }

        /// <summary>
        /// The OnSaveProfile
        /// </summary>
        private async void OnSaveProfile()
        {
        }
    }
}
