//-----------------------------------------------------------------------
// <copyright file="FacebookProfilePage.xaml.cs" company="Fedesoft">
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
    /// Defines the <see cref="FacebookProfilePage" />
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FacebookLoginPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookProfilePage"/> class.
        /// </summary>
        public FacebookLoginPage()
        {
            this.InitializeComponent();
            this.BindingContext = new FacebookViewModel(); 
        }
    }
}
