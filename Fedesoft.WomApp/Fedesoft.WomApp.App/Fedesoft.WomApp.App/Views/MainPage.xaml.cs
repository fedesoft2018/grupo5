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
    /// Defines the <see cref="MainPage" />
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.BindingContext = new MainPageViewModel(this);
            this.InitializeComponent();
        }
    }
}
