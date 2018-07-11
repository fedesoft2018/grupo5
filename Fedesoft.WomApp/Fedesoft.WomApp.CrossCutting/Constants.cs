//-----------------------------------------------------------------------
// <copyright file="Constants.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.CrossCutting
{
    /// <summary>
    /// Defines the <see cref="Constants" />
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Defines the OkButton
        /// </summary>
        public const string OkButton = "OK";

        /// <summary>
        /// Defines the UserIdKey
        /// </summary>
        public const string UserIdKey = "UserId";

        /// <summary>
        /// Defines the WomAppTitle
        /// </summary>
        public const string WomAppTitle = "WomApp";

        public const string FacebookClientId = "2149804661917953";

        /// <summary>
        /// Defines the HttpFacebookUrl
        /// </summary>
        public const string HttpFacebookUrl = "http://www.facebook.com/connect/login_success.html#access_token=";

        /// <summary>
        /// Defines the HttpsFacebookUrl
        /// </summary>
        public const string HttpsFacebookUrl = "https://www.facebook.com/connect/login_success.html#access_token=";

        public const string FacebookAccessTokenKey = "access_token";

        public const string FacebookExpiresKey = "&expires_in=";
    }
}
