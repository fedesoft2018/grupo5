using Fedesoft.WomApp.App.Models;
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
                new MainMenuItem() { Title = "Línea Púrpura", LineNumber = "01800112137", Icon = "menu_inbox.png", TargetType = typeof(MainPage) },
                new MainMenuItem() { Title = "Línea 155", LineNumber="155", Icon = "menu_stock.png", TargetType = typeof(MainPage) },
                new MainMenuItem() { Title = "Línea 123", LineNumber="123", Icon = "menu_stock.png", TargetType = typeof(MainPage) },
                new MainMenuItem() { Title = "Prevención", Icon = "menu_stock.png", TargetType = typeof(MainPage) }
            };

            // Set the default page, this is the "home" page.
            Detail = new NavigationPage(new MainPage());
            this.InitializeComponent();
            //MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        public void MainMenuItem_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainMenuItem;
            if (item != null)
            {
                if (!string.IsNullOrEmpty(item.LineNumber))
                {
                    Dialer.MakeCall(item.LineNumber);
                }

                MenuListView.SelectedItem = null;
                IsPresented = false;
            }
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            var iconBytes = await BlobStorageManager.GetFileAsync(ContainerType.Images, "hamburger_menu.png");
        }
    }
}