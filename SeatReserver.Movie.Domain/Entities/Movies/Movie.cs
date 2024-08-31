using ProjectManager.Entities.Common;
using SeatReserver.Movie.Domain.Entities.Movie;
using SeatReserver.Movie.Domain.Entities.Sans;
using SeatReserver.Movie.Domain.Events.MovieEvents;
using System.ComponentModel.DataAnnotations;

namespace SeatReserver.Movie.Domain.Entities.Movies
{
    public class Movie : AggregateRoot<Guid>, IValidatableObject
    {

        #region Ctors
        private Movie() {}

        public Movie(string title, Genre genre)
        {
            Title = title;
            Genre=genre;
        }
        public Movie(string title, string description, Genre genre)
        {
            Title = title;
            Description=description;
            Genre=genre;
        }
        public Movie(string title, string description, string posterImage)
        {
            Title = title;
            Description=description;
            PosterImage=posterImage;
        }
        #endregion  

        #region Properteis
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public string? PosterImage { get; private set; }

        public Guid GenreId { get; set; }
        #endregion

        #region Relations

        #region ForeignKey
        public virtual Genre Genre { get; private set; }
        #endregion

        #region ICollection
        private readonly List<MovieSans> _movieSans;
        public virtual IReadOnlyCollection<MovieSans> MovieSans => _movieSans;

        #endregion
        #endregion

        #region Methods
        public void AddPosterImage(byte[] posterImage)
        {
            //TODO: in the First part save image in Event store and then store in s3!

            UpdateLastUpdatedDate();
            RaiseDomainEvent(new MoviePosterImageShoudBeSentOnObjectStorageEvent(Id, posterImage));
        }

        public void UpdateMovieData(string title, string description)
        {
            //TODO: CheckValidation title and desciption;
            Title = title;
            Description = description;
            RaiseDomainEvent(new MovieInfoUpdatedEvent(title, Description));
        }

        #endregion

        #region Validations
        /// <summary>
        /// this method implement for business logic
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Title.Length < 3)
            {
                yield return new ValidationResult("");
            }
        }
        #endregion

        #region MyRegion

        #endregion
    }
}
