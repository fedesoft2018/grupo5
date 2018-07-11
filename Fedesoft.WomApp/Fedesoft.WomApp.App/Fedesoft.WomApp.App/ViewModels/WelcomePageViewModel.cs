//-----------------------------------------------------------------------
// <copyright file="MainPageViewModel.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.App.ViewModels
{
    using System.Windows.Input;

    using Fedesoft.WomApp.App.ViewModels.Base;
    using Fedesoft.WomApp.App.Views;

    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="WelcomePageViewModel" />
    /// </summary>
    public class WelcomePageViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WelcomePageViewModel"/> class.
        /// </summary>
        /// <param name="page">The page<see cref="ContentPage"/></param>
        public WelcomePageViewModel(ContentPage page)
        {
            this.Page = page;
            this.FacebookCommand = new Command(GoToFacebook);
            this.RegisterCommand = new Command(GoToRegister);
        }

        /// <summary>
        /// Gets the FacebookCommand
        /// </summary>
        public ICommand FacebookCommand { get; private set; }

        /// <summary>
        /// Gets the Page
        /// </summary>
        public ContentPage Page { get; private set; }

        /// <summary>
        /// Gets the RegisterCommand
        /// </summary>
        public ICommand RegisterCommand { get; private set; }

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
    }
}
