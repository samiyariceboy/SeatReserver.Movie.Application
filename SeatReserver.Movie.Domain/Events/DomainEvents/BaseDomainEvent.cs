using MediatR;

namespace SeatReserver.Movie.Domain.Events.DomainEvents
{
    public interface IDomainEvent : INotification
    {
        public EventLocation EventLocation { get; }
    }

    public enum EventLocation
    {
        Internal,
        External
    }
}
