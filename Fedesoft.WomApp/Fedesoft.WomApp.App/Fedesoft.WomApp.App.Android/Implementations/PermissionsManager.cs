using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Fedesoft.WomApp.App.Droid.Implementations;
using Fedesoft.WomApp.Contracts;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

[assembly: Dependency(typeof(PermissionsManager))]
namespace Fedesoft.WomApp.App.Droid.Implementations
{
    public class PermissionsManager : IPermissionsManager
    {
        public async Task<bool> CheckLocationPermissions()
        {
            var result = true;
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    //if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    //{
                    //    await DisplayAlert("Need location", "Gunna need that location", "OK");
                    //}

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                    {
                        status = results[Permission.Location];
                    }

                    result = status == PermissionStatus.Granted;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
    }
}