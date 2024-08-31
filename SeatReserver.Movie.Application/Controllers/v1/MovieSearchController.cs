using Microsoft.AspNetCore.Mvc;
using SeatReserver.Movie.Application.Models;
using SeatReserver.Movie.Domain.DTO.MovieDtos;
using SeatReserver.Movie.Domain.Services.MovieDomainServices;

namespace SeatReserver.Movie.Application.Controllers.v1
{
    [ApiVersion("1")]
    public class MovieSearchController : BaseController
    {
        private readonly IMovieDomainService _movieDomainService;

        public MovieSearchController(IMovieDomainService movieDomainService)
        {
            _movieDomainService=movieDomainService;
        }

        /// <summary>
        /// this method returns movies by danamic filters 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<MovieSelectedDto>> GetMoviesByDanamicFilter([FromQuery] GetMoviesByDaynamicFilterDto filter, CancellationToken cancellationToken) 
        {
            var result = await _movieDomainService.GetMoviesByDanamicFilter(filter, cancellationToken);
            return Ok(result);
        }
    }
}
