//-----------------------------------------------------------------------
// <copyright file="SaveUserData.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.Functions
{
    using System.Net;
    using System.Net.Http;

    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;

    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="SaveUserData" />
    /// </summary>
    public static class SaveUserData
    {
        /// <summary>
        /// The Run
        /// </summary>
        /// <param name="req">The req<see cref="HttpRequestMessage"/></param>
        /// <param name="log">The log<see cref="TraceWriter"/></param>
        /// <param name="document">The document<see cref="dynamic"/></param>
        /// <returns>The <see cref="object"/></returns>
        [FunctionName("SaveUserData")]
        public static object Run(
            [HttpTrigger(WebHookType = "genericJson")]
            HttpRequestMessage req,
            TraceWriter log,
            [DocumentDB(
                    Utils.CosmosDBDataBase,
                    Utils.CosmosDBCollection,
                    CreateIfNotExists = true,
                    ConnectionStringSetting = Utils.CosmosDBConnectionString)]
                    out dynamic document)
        {
            log.Info($"Consulta de datos iniciada");
            var task = req.Content.ReadAsStringAsync();
            task.Wait();
            log.Info($"Se obtienen datos...");
            string jsonContent = task.Result;
            dynamic data = JsonConvert.DeserializeObject(jsonContent);
            log.Info($"Convirtiendo datos en formato JSON {jsonContent}");
            document = null;
            try
            {
                document = data;
                if (data != null)
                {
                    return req.CreateResponse(HttpStatusCode.OK, new
                    {
                        result = 1,
                        message = $"Solicitud recibida exitosamente"
                    });
                }
                else
                {
                    return req.CreateResponse(HttpStatusCode.BadRequest, new
                    {
                        result = 0,
                        message = $"No se recibió ningún elemento."
                    });
                }
            }
            catch (System.Exception ex)
            {
                log.Error("Error al guardar datos", ex);
                return req.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
