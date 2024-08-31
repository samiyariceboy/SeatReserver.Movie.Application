using Amazon.S3;
using Amazon.S3.Model;
using SeatReserver.Movie.Domain.Common.InterfaceDependency;

namespace MediaService.Services.Services.OpenApiServices.AwsS3Service
{
    public class AwsS3Service : IAwsS3Service, IScopedDependency
    {
        private readonly AmazonS3Client _amazonS3Client;
        public AwsS3Service(string accessKey, string secretKey, string endpointUrl)

        {
            _amazonS3Client = new AmazonS3Client(accessKey, secretKey, new AmazonS3Config { ServiceURL = endpointUrl });
        }

        public async Task<bool> UploadMedia(Stream media, string bucketName, string fileName, CancellationToken cancellationToken)
        {
            var objectStorageRequest = new PutObjectRequest()
            {
                InputStream = media,
                BucketName = bucketName,
                Key = fileName,
                BucketKeyEnabled = true,
                CannedACL = S3CannedACL.PublicRead
            };
            PutObjectResponse response = await _amazonS3Client.PutObjectAsync(objectStorageRequest);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                return true;
            return false;
        }
    }
}
