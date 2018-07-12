//-----------------------------------------------------------------------
// <copyright file="MainPageViewModel.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.App.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Fedesoft.WomApp.App.ViewModels.Base;
    using Fedesoft.WomApp.App.Views;
    using Fedesoft.WomApp.CrossCutting;
    using Fedesoft.WomApp.Domain;
    using Fedesoft.WomApp.Services;

    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="WelcomePageViewModel" />
    /// </summary>
    public class WelcomePageViewModel : ViewModelBase
    {
        /// <summary>
        /// Defines the email
        /// </summary>
        private string email;

        /// <summary>
        /// Defines the pass
        /// </summary>
        private string pass;

        /// <summary>
        /// Initializes a new instance of the <see cref="WelcomePageViewModel"/> class.
        /// </summary>
        /// <param name="page">The page<see cref="ContentPage"/></param>
        public WelcomePageViewModel(ContentPage page)
        {
            this.Page = page;
            this.FacebookCommand = new Command(this.GoToFacebook);
            this.RegisterCommand = new Command(this.GoToRegister);
            this.SignInCommand = new Command(this.OnSignIn);
        }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get => this.email; set => this.SetProperty(ref this.email, value); }

        /// <summary>
        /// Gets the FacebookCommand
        /// </summary>
        public ICommand FacebookCommand { get; }

        /// <summary>
        /// Gets the Page
        /// </summary>
        public ContentPage Page { get; }

        /// <summary>
        /// Gets or sets the Pass
        /// </summary>
        public string Pass { get => this.pass; set => this.SetProperty(ref this.pass, value); }

        /// <summary>
        /// Gets the RegisterCommand
        /// </summary>
        public ICommand RegisterCommand { get; }

        /// <summary>
        /// Gets the SignInCommand
        /// </summary>
        public ICommand SignInCommand { get; }

        /// <summary>
        /// Gets a value indicating whether IsDataFilled
        /// </summary>
        private bool IsDataFilled => string.IsNullOrEmpty(this.Email) || string.IsNullOrEmpty(this.Pass);

        /// <summary>
        /// The CreateUserEntity
        /// </summary>
        /// <returns>The <see cref="User"/></returns>
        private User CreateUserEntity()
        {
            return new User
            {
                Email = this.Email,
                Password = this.Pass
            };
        }

        /// <summary>
        /// The GoToFacebook
        /// </summary>
        private async void GoToFacebook()
        {
            await this.Page.Navigation.PushAsync(new FacebookLoginPage());
        }

        /// <summary>
        /// The GoToRegister
        /// </summary>
        private async void GoToRegister()
        {
            await this.Page.Navigation.PushAsync(new RegisterPage());
        }

        /// <summary>
        /// The OnSignIn
        /// </summary>
        private async void OnSignIn()
        {
            if (this.IsDataFilled)
            {
                await this.Page.DisplayAlert(Constants.WomAppTitle, "Los campos son requeridos", Constants.OkButton);
            }
            else
            {
                await ValidateUser();
            }
        }

        /// <summary>
        /// The ValidateUser
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        private async Task ValidateUser()
        {
            User user = this.CreateUserEntity();
            var service = new UserService();
            if (await service.ValidateUserAsync(user))
            {
                await this.Page.Navigation.PushAsync(new HomePage());
            }
            else
            {
                await this.Page.DisplayAlert(Constants.WomAppTitle, "Usuario o contraseña inválidos", Constants.OkButton);
            }
        }
    }
}
