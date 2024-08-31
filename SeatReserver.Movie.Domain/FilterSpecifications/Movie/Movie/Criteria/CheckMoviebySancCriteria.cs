using System.Linq.Expressions;
using VoipService.Domain.Common;

namespace SeatReserver.Movie.Domain.FilterSpecifications.Movie.Movie.Criteria
{
    public class CheckMoviebySancCriteria(DateTime? startTimeOfSanc, DateTime? endTimeOfSanc) : CriteriaSpecification<Entities.Movies.Movie>
    {
        private readonly DateTime? _startTimeOfSanc = startTimeOfSanc == default ? DateTime.MinValue : startTimeOfSanc;
        private readonly DateTime? _endTimeOfSanc = endTimeOfSanc == default ? DateTime.MaxValue : endTimeOfSanc;

        public override Expression<Func<Entities.Movies.Movie, bool>> ToExpression()
        {
            if (_startTimeOfSanc == DateTime.MinValue && _endTimeOfSanc == DateTime.MaxValue)
            {
                return current => true;
            }

            return current => current.MovieSans.Any(a => a.Sans.StartTimeOfSans == _startTimeOfSanc &&
                                                         a.Sans.EndTImeOfSans == _endTimeOfSanc);
        }
    }
}
