using Ardalis.Specification;
using SeatReserver.Movie.Domain.DTO.MovieDtos;
using SeatReserver.Movie.Domain.FilterSpecifications.Movie.Movie.Criteria;
using VoipService.Domain.Common;

namespace SeatReserver.Movie.Domain.FilterSpecifications.Movie.Movie
{
    public class GetAvailableMoviesSpecification : Specification<Entities.Movies.Movie>
    {
        private readonly GetMoviesByDanamicFilter _filter;
        private readonly MovieNavigationProperty[] _movieNavigationProperties;

        public GetAvailableMoviesSpecification(GetMoviesByDanamicFilter filter, params MovieNavigationProperty[] movieNavigationProperties)
        {
            _filter = filter;
            _movieNavigationProperties=movieNavigationProperties;
            Query.Where(Criteria().ToExpression());
            AddNavigationPropertyArray();
        }

        private void AddNavigationPropertyArray()
        {
            _movieNavigationProperties.ToList().ForEach(AddNavigationProperty);
        }

        private void AddNavigationProperty(MovieNavigationProperty contactGroupNavigationProperty)
        {
            switch (contactGroupNavigationProperty)
            {
                case MovieNavigationProperty.LoadMovieSanc:
                    Query.Include(inc => inc.MovieSans);
                    break;
                default:
                    break;
            }
        }
        private CriteriaSpecification<Entities.Movies.Movie> Criteria()
        {
            return new CheckMovieByIdCriteria(_filter.MovieId)
                .And(new CheckMovieByTitleCriteria(_filter.Title))
                .And(new CheckMoviebySancCriteria(_filter.StartTimeOfSanc, _filter.EndTimeOfSanc));
        }
    }

    public enum MovieNavigationProperty
    {
        LoadMovieSanc
    }
}
