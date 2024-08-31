using SeatReserver.Movie.Domain.Events.DomainEvents;

namespace SeatReserver.Movie.Domain.Events.MovieEvents
{
    public class MovieInfoUpdatedEvent(string MovieTitle, string MovieDescription) : IDomainEvent
    {
        public EventLocation EventLocation => EventLocation.External;

        public string MovieTitle { get; } = MovieTitle;
        public string MovieDescription { get; } = MovieDescription;
    }
}
