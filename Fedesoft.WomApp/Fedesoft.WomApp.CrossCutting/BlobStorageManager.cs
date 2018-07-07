//-----------------------------------------------------------------------
// <copyright file="BlobStorageManager.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.CrossCutting
{
    using System.Threading.Tasks;

    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    
    /// <summary>
    /// Defines the <see cref="BlobStorageManager" />
    /// </summary>
    public static class BlobStorageManager
    {
        /// <summary>
        /// Defines the StorageConnection
        /// </summary>
        private const string StorageConnection = "DefaultEndpointsProtocol=https;AccountName=womapp;AccountKey=+WJGY1mGfHxmarf0c8clCImPiV3Q77qWmC/FVksv1jY762r3WDMyodMbanUGuh5L/dGuQSq5IBeHMNvqKX3hdg==;EndpointSuffix=core.windows.net";

        /// <summary>
        /// The GetContainer
        /// </summary>
        /// <param name="containerType">The containerType<see cref="ContainerType"/></param>
        /// <returns>The <see cref="CloudBlobContainer"/></returns>
        public static CloudBlobContainer GetContainer(ContainerType containerType)
        {
            var account = CloudStorageAccount.Parse(StorageConnection);
            var client = account.CreateCloudBlobClient();
            return client.GetContainerReference(containerType.ToString().ToLower());
        }

        /// <summary>
        /// The GetFileAsync
        /// </summary>
        /// <param name="containerType">The containerType<see cref="ContainerType"/></param>
        /// <param name="name">The name<see cref="string"/></param>
        /// <returns>The <see cref="Task{byte[]}"/></returns>
        public static async Task<byte[]> GetFileAsync(ContainerType containerType, string name)
        {
            var container = GetContainer(containerType);

            var blob = container.GetBlobReference(name);
            if (await blob.ExistsAsync())
            {
                await blob.FetchAttributesAsync();
                byte[] blobBytes = new byte[blob.Properties.Length];

                await blob.DownloadToByteArrayAsync(blobBytes, 0);
                return blobBytes;
            }

            return null;
        }
    }
}
