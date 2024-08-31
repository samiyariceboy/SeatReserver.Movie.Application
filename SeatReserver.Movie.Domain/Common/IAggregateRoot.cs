using SeatReserver.Movie.Domain.Entities;
using SeatReserver.Movie.Domain.Events.DomainEvents;

namespace SeatReserver.Movie.Domain.Common
{
    public interface IAggregateRoot : IEntity
    {
        void ClearDomainEvents();
        IReadOnlyList<IDomainEvent> DomainEvents { get; }
    }
}