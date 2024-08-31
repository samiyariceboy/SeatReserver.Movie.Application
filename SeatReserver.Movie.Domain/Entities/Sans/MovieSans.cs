using SeatReserver.Movie.Domain.Common.Utilities;
using SeatReserver.Movie.Domain.Entities.Reserve;
using System.ComponentModel.DataAnnotations;

namespace SeatReserver.Movie.Domain.Entities.Sans
{
    public class MovieSans : BaseEntity, IValidatableObject
    {
        #region Ctors
        private MovieSans() {}
        public MovieSans(Guid movieId, Guid sancId)
        {
            MovieId = movieId;
            SancId = sancId;
        }
        public MovieSans(Movies.Movie movie, Sans sans)
        {
            Movie= movie;
            Sans = sans;
        }
        #endregion

        #region Propeteis
        public Guid MovieId { get; private set; }
        public Guid SancId { get; private set; }
        public Guid HallId { get; private set; }
        #endregion

        #region Relations 
        #region ForeignKey
        public virtual Movies.Movie Movie { get; private set; }
        public virtual Sans Sans { get; private set; }
        #endregion

        #region ICollection

        #endregion
        #region ICollection
        private readonly List<ReserveSeat> _reserveSeats;
        public virtual IReadOnlyCollection<ReserveSeat> ReserveSeats => _reserveSeats;
        #endregion
        #endregion

        #region Methods
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SancId.GuidIsEmpty() || MovieId.GuidIsEmpty())
            {
                yield return new ValidationResult("");
            }
        }
        #endregion
    }
}
