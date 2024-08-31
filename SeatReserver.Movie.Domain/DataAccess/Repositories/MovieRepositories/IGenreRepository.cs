using SeatReserver.Movie.Domain.Entities.Movie;

namespace SeatReserver.Movie.Domain.DataAccess.Repositories.MovieRepositories
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Task<List<Genre>> GetGenres(CancellationToken cancellationToken);
    }
}