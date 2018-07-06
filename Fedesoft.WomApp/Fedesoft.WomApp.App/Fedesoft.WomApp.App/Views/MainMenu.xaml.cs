using Fedesoft.WomApp.App.Models;
using Fedesoft.WomApp.App.Views.Base;
using Fedesoft.WomApp.CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fedesoft.WomApp.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : MasterDetailPage
    {
        public List<MainMenuItem> MainMenuItems { get; set; }

        public MainMenu()
        {
            // Set the binding context to this code behind.
            BindingContext = this;

            // Build the Menu
            MainMenuItems = new List<MainMenuItem>()
            {
                new MainMenuItem() { Title = "Línea Púrpura", LineNumber = "01800112137", Icon = "linea_purpura_24x24.png", TargetType = typeof(MainPage), IconWith = 24, IconHeight = 24 },
                new MainMenuItem() { Title = "Línea 155", LineNumber="155", Icon = "linea_155_24x24.png", TargetType = typeof(MainPage), IconWith = 24, IconHeight = 24 },
                new MainMenuItem() { Title = "Línea 123", LineNumber="123", Icon = "linea_123_24x24.png", TargetType = typeof(MainPage), IconWith = 24, IconHeight = 24 },
                new MainMenuItem() { Title = "Prevención", Icon = "prevencion_24x24.png", TargetType = typeof(MainPage), IconWith = 24, IconHeight = 24 }
            };

            // Set the default page, this is the "home" page.
            this.Detail = new NavigationPage(new MainPage());
            this.InitializeComponent();
        }

        public void MainMenuItem_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is MainMenuItem item)
            {
                if (!string.IsNullOrEmpty(item.LineNumber))
                {
                    Dialer.MakeCall(item.LineNumber);
                }

                this.MenuListView.SelectedItem = null;
                this.IsPresented = false;
            }
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            var iconBytes = await BlobStorageManager.GetFileAsync(ContainerType.Images, "hamburger_menu.png");
        }
    }
}