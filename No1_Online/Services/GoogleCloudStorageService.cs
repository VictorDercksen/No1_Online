using Google.Cloud.Storage.V1;

namespace No1_Online.Services
{
    public class GoogleCloudStorageService
    {
        private readonly StorageClient _storageClient;
        private readonly string _bucketName;

        public GoogleCloudStorageService(string bucketName)
        {
            // Create a StorageClient using Application Default Credentials
            _storageClient = StorageClient.Create();
            _bucketName = bucketName;
        }

        public async Task<string> UploadReportAsync(string reportName, byte[] reportData)
        {
            using (var stream = new MemoryStream(reportData))
            {
                var storageObject = await _storageClient.UploadObjectAsync(_bucketName, reportName, "application/pdf", stream);
                return storageObject.MediaLink; // URL to the uploaded report
            }
        }

        public async Task<List<string>> ListReportsAsync()
        {
            var reportList = new List<string>();

            var storageObjects = _storageClient.ListObjectsAsync(_bucketName);
            await foreach (var storageObject in storageObjects)
            {
                reportList.Add(storageObject.Name);
            }

            return reportList;
        }
    }
}
