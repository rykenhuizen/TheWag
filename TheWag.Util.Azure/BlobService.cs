using Azure.Identity;
using Azure.Storage.Blobs;

namespace TheWag.Util.Azure
{
    public class BlobService
    {
        private BlobServiceClient _client;

        public BlobService(string accountName)
        {
            _client = new(
               new Uri($"https://{accountName}.blob.core.windows.net"),
               new DefaultAzureCredential());
        }

        public void UploadBlob(string container, string fileName, BinaryData data)
        {
            //var acctName = "thewagstorage";
            //var blobContainer = vm.IsDog ? "dogpictures" : "invalidPictures";

            //var bs = new BlobStorage();
            //var bsc = bs.GetBlobServiceClient(acctName);
            var bcc = _client.GetBlobContainerClient(container);

            //var fileName = Guid.NewGuid().ToString() + e.File.Name;

            var response = bcc.UploadBlob(fileName, data);
        }

    }
}
