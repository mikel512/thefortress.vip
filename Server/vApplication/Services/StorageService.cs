using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using vDomain.Interface;

namespace vApplication.Services;

public class StorageService : IStorageService
{
    private readonly IConfiguration _configuration;

    public StorageService(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public async Task<string> StoreImageFile(IFormFile file)
    {

        var fileName = Path.GetFileName(Path.GetRandomFileName() + ".jpg");
        var url = _configuration["Storage:Base"];
        var containerName = _configuration["Storage:ImgContainer"];

        // get connection string from conif
        var connectionString = _configuration["Storage:ConnectionString"];

        // Get blob data
        BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

        var result = await container.UploadBlobAsync(fileName, file.OpenReadStream());

        // set final file destination
        //var picBlob = container.GetBlockBlobReference(filenameonly);
        //picBlob.Properties.ContentType = "image/jpg";
        // asynchronously upload file
        //await picBlob.UploadFromStreamAsync(file.OpenReadStream());

        Console.WriteLine(result.Value);

        // the url image is saved to
        return url + "/" + containerName + "/" + fileName;
    }
    public async Task<List<string>> GetAllImgsFromBlob()
    {
        var list = new List<string>();
        var url = _configuration["Storage:account1:Base"];
        var containerName = _configuration["Storage:account1:Containers:Flyers"];

        // Get blob data
        //var blobClient = new CloudBlobClient(new Uri(url), Credentials);
        //CloudBlobContainer container = blobClient.GetContainerReference(containerName);
        //var results  = await container.ListBlobsSegmentedAsync("",true, BlobListingDetails.Metadata, null, null,
        //    null, null);
        //foreach (var item in results.Results)
        //{
        //    var blob = (CloudBlob) item;
        //    list.Add(blob.Uri.ToString());               
        //}

        return list;
    }

    private async void AddQueueMessage(string jsonReport)
    {
        //var url = _configuration["Storage:account1:Queues:scan"];
        //var queueClient = new CloudQueueClient(new Uri( "https://storagethefortress.queue.core.windows.net"), Credentials);
        //var queue = queueClient.GetQueueReference("scan");
        //await queue.AddMessageAsync(new CloudQueueMessage(jsonReport));
    }

}