//-----------------------------------------------------------------------
// <copyright file="HomePageViewModel.cs" company="Fedesoft">
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
    /// Defines the <see cref="HomePageViewModel" />
    /// </summary>
    public class HomePageViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageViewModel"/> class.
        /// </summary>
        /// <param name="page">The page<see cref="ContentPage"/></param>
        public HomePageViewModel(ContentPage page)
        {
            this.Page = page;
            this.ReportCommand = new Command(this.OnReportCommand);
            this.PreventCommand = new Command(this.OnPreventCommand);
            this.MeetCommand = new Command(this.OnMeetCommand);
            this.ProfileCommand = new Command(this.OnProfileCommand);
        }

        /// <summary>
        /// Gets the MeetCommand
        /// </summary>
        public ICommand MeetCommand { get; }

        /// <summary>
        /// Gets the Page
        /// </summary>
        public ContentPage Page { get; }

        /// <summary>
        /// Gets the PreventCommand
        /// </summary>
        public ICommand PreventCommand { get; }

        /// <summary>
        /// Gets the ProfileCommand
        /// </summary>
        public ICommand ProfileCommand { get; }

        /// <summary>
        /// Gets the ReportCommand
        /// </summary>
        public ICommand ReportCommand { get; }

        /// <summary>
        /// The OnMeetCommand
        /// </summary>
        private async void OnMeetCommand()
        {
            await App.NavPage.PushAsync(new MeetPage());
        }

        /// <summary>
        /// The OnPreventCommand
        /// </summary>
        private async void OnPreventCommand()
        {
            await App.NavPage.PushAsync(new PreventPage());
        }

        /// <summary>
        /// The OnProfileCommand
        /// </summary>
        private async void OnProfileCommand()
        {
            await App.NavPage.PushAsync(new UserProfilePage());
        }

        /// <summary>
        /// The OnReportCommand
        /// </summary>
        private async void OnReportCommand()
        {
        }
    }
}
