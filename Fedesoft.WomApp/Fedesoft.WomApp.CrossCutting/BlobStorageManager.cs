using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fedesoft.WomApp.CrossCutting
{
    public static class BlobStorageManager
    {
        private const string StorageConnection = "DefaultEndpointsProtocol=https;AccountName=womapp;AccountKey=+WJGY1mGfHxmarf0c8clCImPiV3Q77qWmC/FVksv1jY762r3WDMyodMbanUGuh5L/dGuQSq5IBeHMNvqKX3hdg==;EndpointSuffix=core.windows.net";

        public static CloudBlobContainer GetContainer(ContainerType containerType)
        {
            var account = CloudStorageAccount.Parse(StorageConnection);
            var client = account.CreateCloudBlobClient();
            return client.GetContainerReference(containerType.ToString().ToLower());
        }

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
