//-----------------------------------------------------------------------
// <copyright file="RestService.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.Services.RestBase
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    
    /// <summary>
    /// Defines the <see cref="RestService{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class RestService<TEntity> : IRestService<TEntity>
    {
        /// <summary>
        /// Defines the client
        /// </summary>
        private readonly HttpClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestService{TEntity}"/> class.
        /// </summary>
        public RestService()
        {
            this.client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        /// <summary>
        /// Gets the EditUri
        /// </summary>
        protected abstract Uri EditUri { get; }

        /// <summary>
        /// Gets the MultipleUri
        /// </summary>
        protected abstract Uri MultipleUri { get; }

        /// <summary>
        /// Gets the SaveUri
        /// </summary>
        protected abstract Uri SaveUri { get; }

        /// <summary>
        /// Gets the SingleUri
        /// </summary>
        protected abstract Uri SingleUri { get; }

        /// <summary>
        /// Gets the SingleUriToken
        /// </summary>
        protected virtual string SingleUriToken => "{id}";

        /// <summary>
        /// The DeleteItemAsync
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task{bool}"/></returns>
        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetDataAsync
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task{TEntity}"/></returns>
        public async Task<TEntity> GetDataAsync(string id)
        {
            var uri = new Uri(this.SingleUri.AbsoluteUri.Replace(this.SingleUriToken, id));
            var response = await this.client.GetAsync(uri);
            var entity = default(TEntity);
            if (response.IsSuccessStatusCode)
            {
                entity = JsonConvert.DeserializeObject<TEntity>(await response.Content.ReadAsStringAsync());
            }

            return entity;
        }

        /// <summary>
        /// The RefreshDataAsync
        /// </summary>
        /// <returns>The <see cref="Task{List{TEntity}}"/></returns>
        public Task<List<TEntity>> RefreshDataAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The SaveItemAsync
        /// </summary>
        /// <param name="item">The item<see cref="TEntity"/></param>
        /// <param name="isNewItem">The isNewItem<see cref="bool"/></param>
        /// <returns>The <see cref="Task{bool}"/></returns>
        public async Task<bool> SaveItemAsync(TEntity item, bool isNewItem)
        {
            var result = false;
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(this.SaveUri, content);
                }
                else
                {
                    response = await client.PostAsync(this.EditUri, content);
                }

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
