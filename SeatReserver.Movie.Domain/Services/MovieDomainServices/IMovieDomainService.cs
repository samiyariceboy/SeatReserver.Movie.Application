using SeatReserver.Movie.Domain.DTO.MovieDtos;

namespace SeatReserver.Movie.Domain.Services.MovieDomainServices
{
    public interface IMovieDomainService
    {
        Task AddMovieSanc();
        Task UpdateMovieSanc();
        Task DeleteMovieSanc();

        Task<MovieSelectedDto> UpdateMovie(Guid movieId, UpdateMovieDto createMovieDto, CancellationToken cancellationToken);
        Task<List<GenreSelectedDto>> GetGenres(CancellationToken cancellationToken);
        Task<MovieSelectedDto> CreateMovie(CreateMovieDto createMovieDto, CancellationToken cancellationToken);
        Task<List<MovieSelectedDto>> GetMoviesByDanamicFilter(GetMoviesByDaynamicFilterDto filter, CancellationToken cancellationToken);
    }
}