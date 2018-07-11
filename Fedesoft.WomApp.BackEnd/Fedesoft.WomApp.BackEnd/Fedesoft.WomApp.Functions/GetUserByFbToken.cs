//-----------------------------------------------------------------------
// <copyright file="GetUserByFbToken.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.Functions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;

    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;
    
    /// <summary>
    /// Defines the <see cref="GetUserByFbToken" />
    /// </summary>
    public static class GetUserByFbToken
    {
        /// <summary>
        /// The Run
        /// </summary>
        /// <param name="req">The req<see cref="HttpRequestMessage"/></param>
        /// <param name="users">The users<see cref="IEnumerable{User}"/></param>
        /// <param name="log">The log<see cref="TraceWriter"/></param>
        /// <returns>The <see cref="HttpResponseMessage"/></returns>
        [FunctionName("GetUserByFbToken")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "fbusers/{token}")]
                HttpRequestMessage req,
            [DocumentDB(
                databaseName: Utils.CosmosDBDataBase,
                collectionName: Utils.CosmosDBCollection,
                ConnectionStringSetting = Utils.CosmosDBConnectionString,
                SqlQuery = "SELECT * FROM u WHERE u.FacebookToken = {token}")]
                IEnumerable<User> users,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            return users.Any() ? req.CreateResponse(HttpStatusCode.OK, users.FirstOrDefault()) : req.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
