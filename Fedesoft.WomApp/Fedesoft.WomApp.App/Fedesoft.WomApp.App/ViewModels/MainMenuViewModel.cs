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

    using Plugin.Settings;
    
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
                new MainMenuItem { Title = "Línea Púrpura", LineNumber = "01800112137", Icon = $"{Constants.DefaultImagesBlobStorage}linea_purpura_32x32.png", IconWidth = 32, IconHeight = 32, MenuItemType = MenuItemType.Dial },
                new MainMenuItem { Title = "Línea 155", LineNumber="155", Icon = $"{Constants.DefaultImagesBlobStorage}linea_155_32x32.png", IconWidth = 32, IconHeight = 32, MenuItemType = MenuItemType.Dial },
                new MainMenuItem { Title = "Línea 123", LineNumber="123", Icon = $"{Constants.DefaultImagesBlobStorage}linea_123_32x32.png", IconWidth = 32, IconHeight = 32, MenuItemType = MenuItemType.Dial },
                new MainMenuItem { Title = "Prevención", Icon = $"{Constants.DefaultImagesBlobStorage}prevencion_32x32.png", IconWidth = 32, IconHeight = 32, MenuItemType = MenuItemType.Prevention }
            };

            if (!string.IsNullOrEmpty(CrossSettings.Current.GetValueOrDefault(Constants.UserIdKey, string.Empty)))
            {
                this.MenuItems.Add(new MainMenuItem { Title = "Perfil", Icon = $"{Constants.DefaultImagesBlobStorage}perfil_32x32.png", IconWidth = 32, IconHeight = 32, MenuItemType = MenuItemType.Profile });
                this.MenuItems.Add(new MainMenuItem { Title = "Cerrar Sesión", Icon = $"{Constants.DefaultImagesBlobStorage}cerrar_sesion_32x32.png", IconWidth = 32, IconHeight = 32, MenuItemType = MenuItemType.SignOut });
            }
        }

        /// <summary>
        /// Gets or sets the MenuItems
        /// </summary>
        public IList<MainMenuItem> MenuItems { get => this.menuItems; set => this.SetProperty(ref this.menuItems, value); }

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
        /// The MakeCall
        /// </summary>
        /// <param name="item">The item<see cref="MainMenuItem"/></param>
        private static void MakeCall(MainMenuItem item)
        {
            if (!string.IsNullOrEmpty(item.LineNumber))
            {
                Dialer.MakeCall(item.LineNumber);
            }
        }

        /// <summary>
        /// The ActByMenuType
        /// </summary>
        /// <param name="item">The item<see cref="MainMenuItem"/></param>
        private async void ActByMenuType(MainMenuItem item)
        {
            switch (item.MenuItemType)
            {
                case MenuItemType.Dial:
                    MakeCall(item);
                    break;
                case MenuItemType.Profile:
                    await App.NavPage.PushAsync(new UserProfilePage());
                    break;
                case MenuItemType.SignOut:
                    if (await App.NavPage.DisplayAlert(Constants.WomAppTitle, "Está seguro de cerrar la sesión", Constants.OkButton, Constants.CancelButton))
                    {
                        CrossSettings.Current.Remove(Constants.UserIdKey);
                    }

                    break;
                case MenuItemType.Prevention:
                    await App.NavPage.PushAsync(new PreventPage());
                    break;
                default:
                    break;
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

            this.ActByMenuType(item);
            var menu = App.Current.MainPage as MainMenu;
            //menu.IsPresented = false;
            this.Selected = null;
        }
    }
}
