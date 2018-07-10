//-----------------------------------------------------------------------
// <copyright file="User.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.Domain
{
    /// <summary>
    /// Defines the <see cref="User" />
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        public string Password { get; set; }
    }
}
