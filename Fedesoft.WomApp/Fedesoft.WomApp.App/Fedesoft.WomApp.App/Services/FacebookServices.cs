//-----------------------------------------------------------------------
// <copyright file="FacebookServices.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.App.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using Fedesoft.WomApp.App.Models;

    using Newtonsoft.Json;
    
    /// <summary>
    /// Defines the <see cref="FacebookServices" />
    /// </summary>
    public class FacebookServices
    {
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
    }
}
