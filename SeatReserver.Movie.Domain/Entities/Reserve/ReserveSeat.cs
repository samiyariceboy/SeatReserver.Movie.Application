using ProjectManager.Entities.Common;
using SeatReserver.Movie.Domain.Entities.Halls;
using SeatReserver.Movie.Domain.Entities.Sans;

namespace SeatReserver.Movie.Domain.Entities.Reserve
{
    public class ReserveSeat : AggregateRoot<Guid>
    {
        #region Ctors

        #endregion

        #region Propeties
        public Guid UserId { get; private set; }
        public Guid SeatId { get; private set; }
        public Guid MovieSancId { get; private set; }
        public ReserveStatusType ReserveStatus { get; private set; }
        #endregion

        #region Methods

        #endregion

        #region Relations
        #region ForeignKey
        public virtual Seat Seat { get; private set; }
        public virtual MovieSans MovieSans { get; private set; }
        #endregion

        #region ICollections

        #endregion
        #endregion

        public enum ReserveStatusType
        {
            Created,
            Payed,
            Canceled,
            Finalized
        }
    }
}
