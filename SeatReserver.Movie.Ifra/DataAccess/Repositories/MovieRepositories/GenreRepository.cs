using EFCoreSecondLevelCacheInterceptor;
using Microsoft.EntityFrameworkCore;
using SeatReserver.Movie.Domain.Common.InterfaceDependency;
using SeatReserver.Movie.Domain.DataAccess.Repositories.MovieRepositories;
using SeatReserver.Movie.Domain.Entities.Movie;
using SeatReserver.Movie.Domain.FilterSpecifications.Movie.Movie;
using SeatReserver.Movie.Infrastructure.DbContexts.Sql.SqlServer;

namespace SeatReserver.Movie.Infrastructure.DataAccess.Repositories.MovieRepositories
{
    public class GenreRepository(ApplicationDbContext dbContext) : BaseRepository<Genre>(dbContext),
        IGenreRepository, IScopedDependency
    {
        public Task<List<Genre>> GetGenres(CancellationToken cancellationToken)
        {
            return ApplySpecification(new GetMovieGenre())
            .Cacheable()
            .ToListAsync(cancellationToken);
        }
    }
}
