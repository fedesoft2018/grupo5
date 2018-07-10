//-----------------------------------------------------------------------
// <copyright file="UserService.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.Services
{
    using System;
    using System.Threading.Tasks;

    using Fedesoft.WomApp.Domain;
    using Fedesoft.WomApp.Services.RestBase;
    
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
        protected override Uri SingleUri { get => throw new NotImplementedException(); }

        /// <summary>
        /// The CreateUser
        /// </summary>
        /// <param name="user">The user<see cref="User"/></param>
        /// <returns>The <see cref="Task{bool}"/></returns>
        public async Task<bool> CreateUser(User user)
        {
            return await this.SaveItemAsync(user, true);
        }
    }
}
