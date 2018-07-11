//-----------------------------------------------------------------------
// <copyright file="MainPage.xaml.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.App.Views
{
    using Fedesoft.WomApp.App.ViewModels;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Defines the <see cref="WelcomePage" />
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WelcomePage"/> class.
        /// </summary>
        public WelcomePage()
        {
            this.BindingContext = new WelcomePageViewModel(this);
            this.InitializeComponent();
        }
    }
}
