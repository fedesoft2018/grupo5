//-----------------------------------------------------------------------
// <copyright file="FacebookProfile.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.Domain
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="FacebookProfile" />
    /// </summary>
    public class FacebookProfile
    {
        /// <summary>
        /// Gets or sets the AgeRange
        /// </summary>
        [JsonProperty("age_range")]
        public AgeRange AgeRange { get; set; }

        /// <summary>
        /// Gets or sets the Cover
        /// </summary>
        public Cover Cover { get; set; }

        /// <summary>
        /// Gets or sets the Devices
        /// </summary>
        public Device[] Devices { get; set; }

        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsVerified
        /// </summary>
        public bool IsVerified { get; set; }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Link
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the Locale
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Picture
        /// </summary>
        public Picture Picture { get; set; }
    }
}
