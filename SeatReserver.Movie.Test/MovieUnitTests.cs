using Moq;
using SeatReserver.Movie.Application.Controllers.v1;
using SeatReserver.Movie.Domain.DTO.MovieDtos;
using SeatReserver.Movie.Domain.Services.MovieDomainServices;

namespace SeatReserver.Movie.Test
{
    public class MovieUnitTests
    {
        private readonly Mock<IMovieDomainService> _movieDomainService;
        private readonly MovieController _movieController;
        public MovieUnitTests()
        {
            _movieDomainService = new Mock<IMovieDomainService>();
            _movieController = new MovieController(_movieDomainService.Object);
        }
        [Fact]
        public async void GetMovieCheck()
        {
            //run another logic 

            List<GenreSelectedDto> getGenresListService = [];

            _movieDomainService
                .Setup(service => service.GetGenres(CancellationToken.None))
                .ReturnsAsync(getGenresListService);


            var getGenresListController = await _movieController.GetGenres(CancellationToken.None);

            Assert.NotNull(getGenresListController);

            for (int i = 0; i < getGenresListService.Count; i++)
            {
                Assert.Equal(getGenresListService[i], getGenresListController.Value?[i]);
            }
        }
    }
}