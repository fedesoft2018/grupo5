//-----------------------------------------------------------------------
// <copyright file="FacebookServices.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Fedesoft.WomApp.Domain;
    using Fedesoft.WomApp.Services.RestBase;

    using Newtonsoft.Json;
    
    /// <summary>
    /// Defines the <see cref="FacebookServices" />
    /// </summary>
    public class FacebookServices : RestService<User>
    {
        /// <summary>
        /// Gets the EditUri
        /// </summary>
        protected override Uri EditUri => throw new NotImplementedException();

        /// <summary>
        /// Gets the MultipleUri
        /// </summary>
        protected override Uri MultipleUri => throw new NotImplementedException();

        /// <summary>
        /// Gets the SaveUri
        /// </summary>
        protected override Uri SaveUri => throw new NotImplementedException();

        /// <summary>
        /// Gets the SingleUri
        /// </summary>
        protected override Uri SingleUri => new Uri("https://womappprevention.azurewebsites.net/api/fbusers/{token}");

        /// <summary>
        /// Gets the SingleUriToken
        /// </summary>
        protected override string SingleUriToken => "{token}";

        /// <summary>
        /// The GetCurrentUserFromFabcebookIdAsync
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task{User}"/></returns>
        public async Task<User> GetCurrentUserFromFabcebookIdAsync(string id)
        {
            return await this.GetDataAsync(id);
        }

        /// <summary>
        /// The GetFacebookProfileAsync
        /// </summary>
        /// <param name="accessToken">The accessToken<see cref="string"/></param>
        /// <returns>The <see cref="Task{FacebookProfile}"/></returns>
        public async Task<FacebookProfile> GetFacebookProfileAsync(string accessToken)
        {
            var requestUrl =
                $"https://graph.facebook.com/v2.7/me/?fields=name,picture,work,location,locale,link,cover,age_range,birthday,email,first_name,last_name,gender,hometown&access_token={accessToken}";
            var httpClient = new HttpClient();
            var userJson = await httpClient.GetStringAsync(requestUrl);
            var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(userJson);
            return facebookProfile;
        }

        /// <summary>
        /// The GetUserFromFacebookProfileAsync
        /// </summary>
        /// <param name="accessToken">The accessToken<see cref="string"/></param>
        /// <returns>The <see cref="Task{User}"/></returns>
        public async Task<User> GetUserFromFacebookProfileAsync(string accessToken)
        {
            var profile = await this.GetFacebookProfileAsync(accessToken);
            var user = await this.GetCurrentUserFromFabcebookIdAsync(profile.Id);
            if (user == null || string.IsNullOrEmpty(user.FacebookToken))
            {
                user = new User
                {
                    Name = profile.Name,
                    FacebookToken = profile.Id,
                    UserId = Guid.NewGuid().ToString()
                };
                var userService = new UserService();
                await userService.CreateUserAsync(user);
            }

            return user;
        }
    }
}
