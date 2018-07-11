//-----------------------------------------------------------------------
// <copyright file="RegisterPageViewModel.cs" company="Fedesoft">
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

    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="RegisterPageViewModel" />
    /// </summary>
    public class RegisterPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Defines the email
        /// </summary>
        private string email;

        /// <summary>
        /// Defines the isBusy
        /// </summary>
        private bool isBusy;

        /// <summary>
        /// Defines the password
        /// </summary>
        private string password;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterPageViewModel"/> class.
        /// </summary>
        /// <param name="page">The page<see cref="ContentPage"/></param>
        public RegisterPageViewModel(ContentPage page)
        {
            this.Page = page;
            this.SaveUserCommand = new Command(this.OnSaveUser);
        }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get => this.email; set => this.SetProperty(ref this.email, value); }

        /// <summary>
        /// Gets or sets a value indicating whether IsBusy
        /// </summary>
        public bool IsBusy { get => this.isBusy; set => this.SetProperty(ref this.isBusy, value); }

        /// <summary>
        /// Gets or sets the Page
        /// </summary>
        public ContentPage Page { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        public string Password { get => this.password; set => this.SetProperty(ref this.password, value); }

        /// <summary>
        /// Gets the SaveUserCommand
        /// </summary>
        public ICommand SaveUserCommand { get; private set; }

        /// <summary>
        /// The CreateUserEntity
        /// </summary>
        /// <returns>The <see cref="User"/></returns>
        private User CreateUserEntity()
        {
            return new User
            {
                Email = this.Email,
                Password = this.Password,
                UserId = Guid.NewGuid().ToString()
            };
        }

        /// <summary>
        /// The OnSaveUser
        /// </summary>
        private async void OnSaveUser()
        {
            try
            {
                this.IsBusy = true;
                User user = this.CreateUserEntity();
                await this.SaveUserAsync(user);
            }
            catch (Exception ex)
            {
                await this.Page.DisplayAlert(Constants.WomAppTitle, ex.Message, Constants.OkButton);
            }
        }

        /// <summary>
        /// The SaveUserAsync
        /// </summary>
        /// <param name="user">The user<see cref="User"/></param>
        /// <returns>The <see cref="System.Threading.Tasks.Task"/></returns>
        private async System.Threading.Tasks.Task SaveUserAsync(User user)
        {
            var service = new UserService();
            if (await service.CreateUser(user))
            {
                this.IsBusy = false;
                App.UserId = user.UserId;
                await App.NavPage.PushAsync(new UserProfilePage());
            }
            else
            {
                this.IsBusy = false;
                await this.Page.DisplayAlert(Constants.WomAppTitle, "Error al crear el usuario", Constants.OkButton);
            }
        }
    }
}
