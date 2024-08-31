using SeatReserver.Movie.Domain.Common.Utilities;
using System.Linq.Expressions;
using VoipService.Domain.Common;

namespace SeatReserver.Movie.Domain.FilterSpecifications.Movie.Movie.Criteria
{
    public class CheckMovieByIdCriteria : CriteriaSpecification<Entities.Movies.Movie>
    {
        private readonly Guid? _movieId;

        public CheckMovieByIdCriteria(Guid? movieId)
        {
            _movieId=movieId;
        }
        public override Expression<Func<Entities.Movies.Movie, bool>> ToExpression()
        {
            if (_movieId != null && _movieId.Value.GuidIsEmpty())
            {
                return current => true;
            }

            return current => current.Id == _movieId;
        }
    }
}
