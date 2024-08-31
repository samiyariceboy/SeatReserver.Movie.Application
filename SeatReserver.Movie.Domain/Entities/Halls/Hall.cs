using ProjectManager.Entities.Common;

namespace SeatReserver.Movie.Domain.Entities.Halls
{
    public class Hall : AggregateRoot<Guid>
    {
        #region Ctors

        #endregion

        #region Properteis
        public string Name { get; private set; }
        public string LocationName { get; private set; }
        #endregion

        #region Relations
        #region ForeignKey
        #endregion

        #region ICollections
        private readonly List<Seat> _seats;
        public virtual IReadOnlyCollection<Seat> Seats => _seats;
        #endregion
        #endregion

        #region Enums

        #endregion

        #region 

        #endregion
    }
}
