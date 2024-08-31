using Mapster;
using SeatReserver.Movie.Domain.DTO.MovieDtos;
using SeatReserver.Movie.Domain.Entities.Movie;
using SeatReserver.Movie.Domain.Common.InterfaceDependency;
using SeatReserver.Movie.Domain.FilterSpecifications.Movie.Movie;
using SeatReserver.Movie.Domain.DataAccess.Repositories.MovieRepositories;

namespace SeatReserver.Movie.Domain.Services.MovieDomainServices
{
    public class MovieDomainService(IMovieRepository movieRepository, IGenreRepository genreRepository) : IMovieDomainService, IScopedDependency
    {
        private readonly IMovieRepository _movieRepository = movieRepository;
        private readonly IGenreRepository _genreRepository = genreRepository;

        public async Task<List<MovieSelectedDto>> GetMoviesByDanamicFilter(GetMoviesByDaynamicFilterDto filter, CancellationToken cancellationToken)
        {
            var result = await _movieRepository.ListAsync
                (new GetAvailableMoviesSpecification(filter.Adapt<GetMoviesByDanamicFilter>(),
                 MovieNavigationProperty.LoadMovieSanc), cancellationToken);

            return result.Select(s => new MovieSelectedDto 
            {
                MovieId = s.Id,
                Title = s.Title,
                MovieSancSelectedDtos = []
            }).ToList();
        }

        public async Task AddSansToMovie(Guid movieId, Stream stream, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.FirstOrDefaultAsync 
               (new GetAvailableMoviesSpecification(new GetMoviesByDanamicFilter 
               {
                   MovieId = movieId
               }, MovieNavigationProperty.LoadMovieSanc), cancellationToken);
        }

        public async Task<MovieSelectedDto> CreateMovie(CreateMovieDto createMovieDto, CancellationToken cancellationToken)
        {
            //TODO: check and add new genere

            var movie = new Entities.Movies.Movie(createMovieDto.Title, createMovieDto.Desciption,
                new Genre(createMovieDto.GenreName));
            var result = await _movieRepository.AddAsync(movie, cancellationToken);

            return new MovieSelectedDto()
            {
                MovieId = movie.Id,
                Title = movie.Title,
                MovieSancSelectedDtos = []
            };
        }

        public async Task<MovieSelectedDto> UpdateMovie(Guid movieId, UpdateMovieDto createMovieDto, CancellationToken cancellationToken)
        {
            //TODO: check and add new genere

            var movie = await _movieRepository.FirstOrDefaultAsync
              (new GetAvailableMoviesSpecification(new GetMoviesByDanamicFilter
              {
                  MovieId = movieId
              }), cancellationToken);

            movie.UpdateMovieData(createMovieDto.Title, createMovieDto.Desciption);
            await _movieRepository.UpdateAsync(movie, cancellationToken);


            //convet to factory pattern for mapping large data (movie sanc and another properties
            return new MovieSelectedDto()
            {
                MovieId = movie.Id,
                Title = movie.Title,
                MovieSancSelectedDtos = []
            };
        }


        public async Task<List<GenreSelectedDto>> GetGenres(CancellationToken cancellationToken)
        {
            var result = await _genreRepository.GetGenres(cancellationToken);
            return result.Adapt<List<GenreSelectedDto>>();
        }

        public Task AddMovieSanc()
        {
            return Task.CompletedTask;
        }

        public Task UpdateMovieSanc()
        {
            return Task.CompletedTask;
        }

        public Task DeleteMovieSanc()
        {
            return Task.CompletedTask;
        }
    }
}
