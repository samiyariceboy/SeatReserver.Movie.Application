using MassTransit;
using MediaService.Services.Services.OpenApiServices.AwsS3Service;
using SeatReserver.Movie.Domain.Events.MovieEvents;

namespace SeatReserver.Movie.Application.Services.ApplicationServices.MovieApplicationServices.Consumers
{
    public class MoviePosterImageShoudBeSentOnObjectStorageEventHandler
         : IConsumer<MoviePosterImageShoudBeSentOnObjectStorageEvent>
    {
        private readonly IAwsS3Service _objectStorage;

        public MoviePosterImageShoudBeSentOnObjectStorageEventHandler(IAwsS3Service objectStorage)
        {
            _objectStorage=objectStorage;
        }
        public async Task Consume(ConsumeContext<MoviePosterImageShoudBeSentOnObjectStorageEvent> context)
        {
            await _objectStorage.UploadMedia
                (new MemoryStream(context.Message.Image), "", $"Movie_{context.Message.MovieId}_{Guid.NewGuid()}", CancellationToken.None);
        }
    }
}
