using Fedesoft.WomApp.App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fedesoft.WomApp.App.Services
{
    public class FacebookServices
    {
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
