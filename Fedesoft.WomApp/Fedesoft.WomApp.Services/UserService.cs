//-----------------------------------------------------------------------
// <copyright file="UserService.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.Services
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using Fedesoft.WomApp.Domain;
    using Fedesoft.WomApp.Services.RestBase;

    using Newtonsoft.Json;
    
    /// <summary>
    /// Defines the <see cref="UserService" />
    /// </summary>
    public class UserService : RestService<User>
    {
        /// <summary>
        /// Gets the EditUri
        /// </summary>
        protected override Uri EditUri { get => throw new NotImplementedException(); }

        /// <summary>
        /// Gets the MultipleUri
        /// </summary>
        protected override Uri MultipleUri { get => throw new NotImplementedException(); }

        /// <summary>
        /// Gets the SaveUri
        /// </summary>
        protected override Uri SaveUri => new Uri("https://womappprevention.azurewebsites.net/api/SaveUserData?code=Aa0UMT82K3V/Wt/gbd6CMNjjOre///Gau9mLc0Hjq65ova6Z67hnqQ==&clientId=default");

        /// <summary>
        /// Gets the SingleUri
        /// </summary>
        protected override Uri SingleUri => new Uri("https://womappprevention.azurewebsites.net/api/users/{id}");

        /// <summary>
        /// The CreateUser
        /// </summary>
        /// <param name="user">The user<see cref="User"/></param>
        /// <returns>The <see cref="Task{bool}"/></returns>
        public async Task<bool> CreateUserAsync(User user)
        {
            return await this.SaveItemAsync(user, true);
        }

        /// <summary>
        /// The ValidateUserAsync
        /// </summary>
        /// <param name="user">The user<see cref="User"/></param>
        /// <returns>The <see cref="Task{bool}"/></returns>
        public async Task<bool> ValidateUserAsync(User user)
        {
            var result = false;
            try
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                var validateUri = new Uri("https://womappprevention.azurewebsites.net/api/ValidateUser");
                response = await client.PostAsync(validateUri, content);
                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return result;
        }
    }
}
