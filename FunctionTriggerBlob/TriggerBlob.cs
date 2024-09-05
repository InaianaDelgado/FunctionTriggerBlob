using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunctionTriggerBlob
{
    [StorageAccount("ClassLevelStorageAppSetting")]
    public static class TriggerBlob
    {
        [FunctionName("worker-blob-trigger")]
        [StorageAccount("FunctionLevelStorageAppSetting")]
        public static void Run([BlobTrigger("poc-blob/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob, string name, ILogger log)
        {
            var storageConnection = Environment.GetEnvironmentVariable("AzureWebJobsStorage");

            //CloudStorageAccount cloudStorageAccount;

            //if (CloudStorageAccount.TryParse(storageConnection, out var storageAccount))
            //{
            //    var cloudBlobClient = storageAccount.CreateCloudBlobClient();
            //    CloudBlobContainer blobContainer = cloudBlobClient.GetContainerReference("poc-blob");

            //    CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(name);
            //    Task<string> task = blockBlob.DownloadTextAsync();

            //    CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            //    CloudQueue queue = queueClient.GetQueueReference("poc-queue");
            //    queue.AddMessageAsync(new CloudQueueMessage(task.Result));
            //}

            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
