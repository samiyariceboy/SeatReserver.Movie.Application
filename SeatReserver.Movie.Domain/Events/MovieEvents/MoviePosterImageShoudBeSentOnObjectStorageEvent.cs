using SeatReserver.Movie.Domain.Events.DomainEvents;

namespace SeatReserver.Movie.Domain.Events.MovieEvents
{
    public class MoviePosterImageShoudBeSentOnObjectStorageEvent(Guid movieId, byte[] image) : IDomainEvent
    {
        public Guid MovieId { get; } = movieId;
        public byte[] Image { get; } = image;

        public EventLocation EventLocation => EventLocation.External;
    }
}
