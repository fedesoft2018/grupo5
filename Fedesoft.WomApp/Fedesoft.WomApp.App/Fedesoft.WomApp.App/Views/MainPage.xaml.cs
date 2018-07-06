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
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			this.InitializeComponent();
		}

        private async void LoginWithFacebook_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new FacebookProfilePage());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new RegisterPage());
        }
    }
}