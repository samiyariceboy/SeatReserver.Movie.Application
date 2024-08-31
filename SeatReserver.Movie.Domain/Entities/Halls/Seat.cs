using SeatReserver.Movie.Domain.Entities.Reserve;

namespace SeatReserver.Movie.Domain.Entities.Halls
{
    public class Seat : BaseEntity
    {

        #region Ctors
        private Seat() {}
        public Seat(Guid hallId, int seatNumber)
        {
            HallId = hallId;
            SeatNumber = seatNumber;
        }
        #endregion

        #region Properteis
        public int SeatNumber { get; private set; }
        public Guid HallId { get; private set; }
        #endregion

        #region Relations
        #region ForeignKey
        public virtual Hall Hall { get; private set; }
        #endregion

        #region ICollections
        private readonly List<ReserveSeat> _reserveSeats;
        public virtual IReadOnlyCollection<ReserveSeat> ReserveSeats => _reserveSeats;
        #endregion
        #endregion

        #region Enums

        #endregion

        #region 

        #endregion
    }
}
