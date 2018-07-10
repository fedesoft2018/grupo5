//-----------------------------------------------------------------------
// <copyright file="IRestService.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.Services.RestBase
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IRestService{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRestService<TEntity>
    {
        /// <summary>
        /// The DeleteItemAsync
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task{bool}"/></returns>
        Task<bool> DeleteItemAsync(string id);

        /// <summary>
        /// The GetDataAsync
        /// </summary>
        /// <returns>The <see cref="Task{TEntity}"/></returns>
        Task<TEntity> GetDataAsync();

        /// <summary>
        /// The RefreshDataAsync
        /// </summary>
        /// <returns>The <see cref="Task{List{TEntity}}"/></returns>
        Task<List<TEntity>> RefreshDataAsync();

        /// <summary>
        /// The SaveItemAsync
        /// </summary>
        /// <param name="item">The item<see cref="TEntity"/></param>
        /// <param name="isNewItem">The isNewItem<see cref="bool"/></param>
        /// <returns>The <see cref="Task{bool}"/></returns>
        Task<bool> SaveItemAsync(TEntity item, bool isNewItem);
    }
}
