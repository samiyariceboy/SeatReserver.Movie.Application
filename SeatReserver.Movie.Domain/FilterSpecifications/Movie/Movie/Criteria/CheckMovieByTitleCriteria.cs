using SeatReserver.Movie.Domain.Common.Utilities;
using System.Linq.Expressions;
using VoipService.Domain.Common;

namespace SeatReserver.Movie.Domain.FilterSpecifications.Movie.Movie.Criteria
{
    internal class CheckMovieByTitleCriteria(string? title) : CriteriaSpecification<Entities.Movies.Movie>
    {
        private readonly string? _title = title;

        public override Expression<Func<Entities.Movies.Movie, bool>> ToExpression()
        {
            if (_title == null || !_title.HasValue())
            {
                return current => true;
            }
            return current => current.Title.Contains(_title);
        }
    }
}
