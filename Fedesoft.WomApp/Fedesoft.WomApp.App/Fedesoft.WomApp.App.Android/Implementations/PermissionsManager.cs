//-----------------------------------------------------------------------
// <copyright file="PermissionsManager.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

using Fedesoft.WomApp.App.Droid.Implementations;

using Xamarin.Forms;

[assembly: Dependency(typeof(PermissionsManager))]
namespace Fedesoft.WomApp.App.Droid.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Fedesoft.WomApp.Contracts;

    using Plugin.Permissions;
    using Plugin.Permissions.Abstractions;
    
    /// <summary>
    /// Defines the <see cref="PermissionsManager" />
    /// </summary>
    public class PermissionsManager : IPermissionsManager
    {
        /// <summary>
        /// The CheckLocationPermissions
        /// </summary>
        /// <returns>The <see cref="Task{bool}"/></returns>
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
