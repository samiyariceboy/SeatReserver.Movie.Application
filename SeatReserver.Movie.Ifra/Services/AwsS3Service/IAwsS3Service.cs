using Amazon.S3;

namespace MediaService.Services.Services.OpenApiServices.AwsS3Service
{
    public interface IAwsS3Service
    {
        Task<bool> UploadMedia(Stream media, string bucketName, string fileName, CancellationToken cancellationToken);
    }
}