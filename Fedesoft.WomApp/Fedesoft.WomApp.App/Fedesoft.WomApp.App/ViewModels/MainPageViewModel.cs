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
    /// Defines the <see cref="MainPageViewModel" />
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        public MainPageViewModel()
        {
            this.RegisterCommand = new Command(GoToRegister);
        }

        /// <summary>
        /// Gets the FacebookCommand
        /// </summary>
        public ICommand FacebookCommand { get; private set; }

        /// <summary>
        /// Gets the RegisterCommand
        /// </summary>
        public ICommand RegisterCommand { get; private set; }

        /// <summary>
        /// The GoToFacebook
        /// </summary>
        private async void GoToFacebook()
        {
            var menu = App.Current.MainPage as MainMenu;
            await menu.Detail.Navigation.PushAsync(new FacebookProfilePage());
        }

        /// <summary>
        /// The GoToRegister
        /// </summary>
        private async void GoToRegister()
        {
            var menu = App.Current.MainPage as MainMenu;
            await menu.Detail.Navigation.PushAsync(new RegisterPage());
        }
    }
}
