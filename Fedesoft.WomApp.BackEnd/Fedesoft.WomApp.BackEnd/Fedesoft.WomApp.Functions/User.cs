//-----------------------------------------------------------------------
// <copyright file="User.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.Functions
{
    using System;

    /// <summary>
    /// Defines the <see cref="User" />
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the BirthDay
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the FacebookToken
        /// </summary>
        public string FacebookToken { get; set; }

        /// <summary>
        /// Gets or sets the Latitude
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the Longitude
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        public string UserId { get; set; }
    }
}
