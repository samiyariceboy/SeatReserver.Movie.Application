using SeatReserver.Movie.Domain.Common.InterfaceDependency;
using SeatReserver.Movie.Domain.DataAccess.Repositories.MovieRepositories;
using SeatReserver.Movie.Infrastructure.DbContexts.Sql.SqlServer;

namespace SeatReserver.Movie.Infrastructure.DataAccess.Repositories.MovieRepositories
{
    public class MovieRepository(ApplicationDbContext dbContext) 
        : BaseRepository<Domain.Entities.Movies.Movie>(dbContext), IMovieRepository, IScopedDependency
    {
    }
}
