namespace SeatReserver.Movie.Domain.Entities.Sans
{
    public class Sans : BaseEntity
    {
        #region Ctros

        #endregion

        #region Properties
        public string Name { get; private set; }
        public DateTime StartTimeOfSans { get; private set; }
        public DateTime EndTImeOfSans { get; private set; }
        #endregion

        #region Relations
        #region ForeignKey

        #endregion
        #region ICollection
        private readonly List<MovieSans> _movieSans;
        public virtual IReadOnlyCollection<MovieSans> MovieSans => _movieSans;
        #endregion
        #endregion
    }
}
