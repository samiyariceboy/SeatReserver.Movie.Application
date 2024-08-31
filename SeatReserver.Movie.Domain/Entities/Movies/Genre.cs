using SeatReserver.Movie.Domain.Common.Utilities;
using System.ComponentModel.DataAnnotations;

namespace SeatReserver.Movie.Domain.Entities.Movie
{
    public class Genre : BaseEntity, IValidatableObject
    {
        #region Ctors
        private Genre()
        {
            
        }
        public Genre(string title)
        {
            Title = title;
            Id = Guid.NewGuid();
        }
        #endregion  

        #region Properteis
        public string Title { get; private set; }
        #endregion

        #region Relations
        #region ICollections

        private readonly List<Movies.Movie> _movies;
        public virtual IReadOnlyCollection<Movies.Movie> Movies => _movies;
        #endregion
        #endregion

        #region Methods
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var resultErros = new List<ValidationResult>();
            if (!Title.HasValue())
            {
                yield return new ValidationResult("");
            }
        }
        #endregion

    }
}
