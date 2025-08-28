using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using EmployeeService.Interfaces;

namespace EmployeeService.Services
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;
        private readonly string _bucketFolder;

        public S3Service(IConfiguration configuration)
        {
            _s3Client = new AmazonS3Client(
                configuration["AWS:AccessKey"],
                configuration["AWS:SecretKey"],
                RegionEndpoint.APSoutheast1
            );
            _bucketName = configuration["S3:BucketName"];
            _bucketFolder = configuration["S3:BucketFolder"];
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var fileName = $"{_bucketFolder}/{file.FileName}";

            using var newMemoryStream = new MemoryStream();
            await file.CopyToAsync(newMemoryStream);

            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = newMemoryStream,
                Key = fileName,
                BucketName = _bucketName,
                ContentType = file.ContentType
            };

            var fileTransferUtility = new TransferUtility(_s3Client);
            await fileTransferUtility.UploadAsync(uploadRequest);

            var imageURL = $"https://{_bucketName}.s3.ap-southeast-1.amazonaws.com/{fileName}";
            return imageURL;
        }
    }
}
