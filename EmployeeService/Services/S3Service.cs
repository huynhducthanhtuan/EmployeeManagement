using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
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
            // Create S3 instance with AccessKey & SecretKey
            //_s3Client = new AmazonS3Client(
            //    configuration["AWS:AccessKey"],
            //    configuration["AWS:SecretKey"],
            //    RegionEndpoint.APSoutheast1
            //);
            //_bucketName = configuration["S3:BucketName"];
            //_bucketFolder = configuration["S3:BucketFolder"];

            // Create S3 instance with AccessKey & SecretKey are retrieve from role attach with EC2
            _s3Client = new AmazonS3Client(RegionEndpoint.APSoutheast1);
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

        public string GetPreSignedUrl(string key, int expireMinutes = 10) 
        { 
            var request = new GetPreSignedUrlRequest { 
                BucketName = _bucketName, 
                Key = key, 
                Expires = DateTime.UtcNow.AddMinutes(expireMinutes)
            }; 
            var presignedUrl = _s3Client.GetPreSignedURL(request);
            return presignedUrl;
        }
    }
}
