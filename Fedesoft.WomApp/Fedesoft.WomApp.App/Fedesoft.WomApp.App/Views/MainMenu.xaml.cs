//-----------------------------------------------------------------------
// <copyright file="MainMenu.xaml.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.App.Views
{
    using System.Collections.Generic;

    using Fedesoft.WomApp.App.ViewModels;
    using Fedesoft.WomApp.Domain;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Defines the <see cref="MainMenu" />
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : MasterDetailPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenu"/> class.
        /// </summary>
        public MainMenu()
        {
            this.BindingContext = new MainMenuViewModel();
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the MainMenuItems
        /// </summary>
        public List<MainMenuItem> MainMenuItems { get; set; }
    }
}
