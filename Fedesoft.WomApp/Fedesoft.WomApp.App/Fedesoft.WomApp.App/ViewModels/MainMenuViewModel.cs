//-----------------------------------------------------------------------
// <copyright file="MainMenuViewModel.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.App.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Fedesoft.WomApp.App.ViewModels.Base;
    using Fedesoft.WomApp.App.Views;
    using Fedesoft.WomApp.CrossCutting;
    using Fedesoft.WomApp.Domain;
    
    /// <summary>
    /// Defines the <see cref="MainMenuViewModel" />
    /// </summary>
    public class MainMenuViewModel : ViewModelBase
    {
        /// <summary>
        /// Defines the menuItems
        /// </summary>
        private IList<MainMenuItem> menuItems;

        /// <summary>
        /// Defines the selected
        /// </summary>
        private MainMenuItem selected;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenuViewModel"/> class.
        /// </summary>
        public MainMenuViewModel()
        {
            this.MenuItems = new ObservableCollection<MainMenuItem>()
            {
                new MainMenuItem() { Title = "Línea Púrpura", LineNumber = "01800112137", Icon = "linea_purpura_24x24.png", IconWith = 24, IconHeight = 24 },
                new MainMenuItem() { Title = "Línea 155", LineNumber="155", Icon = "linea_155_24x24.png", IconWith = 24, IconHeight = 24 },
                new MainMenuItem() { Title = "Línea 123", LineNumber="123", Icon = "linea_123_24x24.png", IconWith = 24, IconHeight = 24 },
                new MainMenuItem() { Title = "Prevención", Icon = "prevencion_24x24.png", IconWith = 24, IconHeight = 24 }
            };
        }

        /// <summary>
        /// Gets or sets the MenuItems
        /// </summary>
        public IList<MainMenuItem> MenuItems
        {
            get => this.menuItems;
            set
            {
                this.menuItems = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Selected
        /// </summary>
        public MainMenuItem Selected
        {
            get => this.selected;
            set
            {
                this.SetProperty(ref this.selected, value);
                this.ActOnSelected(value);
            }
        }

        /// <summary>
        /// The ActOnSelected
        /// </summary>
        /// <param name="item">The item<see cref="MainMenuItem"/></param>
        private void ActOnSelected(MainMenuItem item)
        {
            if (item == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(item.LineNumber))
            {
                Dialer.MakeCall(item.LineNumber);
            }

            var menu = App.Current.MainPage as MainMenu;
            menu.IsPresented = false;
            this.Selected = null;
        }
    }
}
