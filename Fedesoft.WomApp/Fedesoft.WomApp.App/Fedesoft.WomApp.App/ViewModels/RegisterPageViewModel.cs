//-----------------------------------------------------------------------
// <copyright file="RegisterPageViewModel.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.App.ViewModels
{
    using Fedesoft.WomApp.App.ViewModels.Base;
    using Fedesoft.WomApp.Domain;
    using Fedesoft.WomApp.Services;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="RegisterPageViewModel" />
    /// </summary>
    public class RegisterPageViewModel : ViewModelBase
    {
        public ContentPage Page { get; set; }

        public RegisterPageViewModel(ContentPage page)
        {
            this.Page = page;
            this.SaveUserCommand = new Command(OnSaveUser);
        }

        private async void OnSaveUser()
        {
            try
            {
                var user = new User
                {
                    Email = this.Email,
                    Password = this.Password
                };
                var service = new UserService();
                if (await service.CreateUser(user))
                {
                    await this.Page.DisplayAlert("WomApp", "Usuario creado correctamente", "OK");
                }
                else
                {
                    await this.Page.DisplayAlert("WomApp", "Error al crear el usuario", "OK");
                }
            }
            catch (Exception ex)
            {
                await this.Page.DisplayAlert("WomApp", ex.Message, "OK");
            }
        }

        /// <summary>
        /// Defines the email
        /// </summary>
        private string email;

        /// <summary>
        /// Defines the password
        /// </summary>
        private string password;

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get => this.email; set => this.SetProperty(ref this.email, value); }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        public string Password { get => this.password; set => this.SetProperty(ref this.password, value); }

        public ICommand SaveUserCommand { get; private set; }
    }
}
