//-----------------------------------------------------------------------
// <copyright file="ValidateUser.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Microsoft.Azure.Documents.Client;
    using Microsoft.Azure.Documents.Linq;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;

    using Newtonsoft.Json;
    
    /// <summary>
    /// Defines the <see cref="ValidateUser" />
    /// </summary>
    public static class ValidateUser
    {
        /// <summary>
        /// The Run
        /// </summary>
        /// <param name="req">The req<see cref="HttpRequestMessage"/></param>
        /// <param name="client">The client<see cref="DocumentClient"/></param>
        /// <param name="log">The log<see cref="TraceWriter"/></param>
        /// <returns>The <see cref="Task{HttpResponseMessage}"/></returns>
        [FunctionName("ValidateUser")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req,
            [DocumentDB(
                databaseName: Utils.CosmosDBDataBase,
                collectionName: Utils.CosmosDBCollection,
                ConnectionStringSetting = Utils.CosmosDBConnectionString)] DocumentClient client,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            var collectionUri = CreateCollectionUri();
            var data = await GetUserData(req);
            if (data == null || string.IsNullOrEmpty(data.Email))
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "No se recibió la información requerida.");
            }

            var users = await FilterUsesrs(client, log, collectionUri, data);
            return users.Any() ? req.CreateResponse(HttpStatusCode.OK) : req.CreateResponse(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// The CreateCollectionUri
        /// </summary>
        /// <returns>The <see cref="Uri"/></returns>
        private static Uri CreateCollectionUri()
        {
            return UriFactory.CreateDocumentCollectionUri(Utils.CosmosDBDataBase, Utils.CosmosDBCollection);
        }

        /// <summary>
        /// The FilterUsesrs
        /// </summary>
        /// <param name="client">The client<see cref="DocumentClient"/></param>
        /// <param name="log">The log<see cref="TraceWriter"/></param>
        /// <param name="collectionUri">The collectionUri<see cref="Uri"/></param>
        /// <param name="data">The data<see cref="User"/></param>
        /// <returns>The <see cref="Task{IList{User}}"/></returns>
        private static async Task<IList<User>> FilterUsesrs(DocumentClient client, TraceWriter log, Uri collectionUri, User data)
        {
            log.Info($"Searching for user email: {data.Email} using Uri: {collectionUri.ToString()}");
            IDocumentQuery<User> query = client.CreateDocumentQuery<User>(collectionUri)
                .Where(p => data.Email.Equals(p.Email) && data.Password.Equals(p.Password))
                .AsDocumentQuery();

            var users = new List<User>();
            while (query.HasMoreResults)
            {
                foreach (User result in await query.ExecuteNextAsync())
                {
                    users.Add(result);
                }
            }

            return users;
        }

        /// <summary>
        /// The GetUserData
        /// </summary>
        /// <param name="req">The req<see cref="HttpRequestMessage"/></param>
        /// <returns>The <see cref="Task{User}"/></returns>
        private static async Task<User> GetUserData(HttpRequestMessage req)
        {
            return JsonConvert.DeserializeObject<User>(await req.Content.ReadAsStringAsync());
        }
    }
}
