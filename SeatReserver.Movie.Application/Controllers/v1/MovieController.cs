using Microsoft.AspNetCore.Mvc;
using SeatReserver.Movie.Application.Models;
using SeatReserver.Movie.Domain.DTO.MovieDtos;
using SeatReserver.Movie.Domain.Services.MovieDomainServices;

namespace SeatReserver.Movie.Application.Controllers.v1
{
    [ApiVersion("1")]
    public class MovieController : BaseController
    {
        private readonly IMovieDomainService _movieDomainService;

        public MovieController(IMovieDomainService movieDomainService)
        {
            _movieDomainService = movieDomainService;
        }

        [HttpGet("[action]")]
        public virtual async Task<ActionResult<List<MovieSelectedDto>>> GetMovies([FromQuery] GetMoviesByDaynamicFilterDto getMoviesByDanamicFilterDto, CancellationToken cancellationToken)
        {
            var result = await _movieDomainService.GetMoviesByDanamicFilter(getMoviesByDanamicFilterDto, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// this method create sample vide 
        /// </summary>
        /// <param name="createMovieDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public virtual async Task<ActionResult<MovieSelectedDto>> CreateMovie(CreateMovieDto createMovieDto, CancellationToken cancellationToken)
        {
            var result = await _movieDomainService.CreateMovie(createMovieDto, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// this method update movie 
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="updateMovieDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("[action]/{movieId}")]
        public virtual async Task<ActionResult<MovieSelectedDto>> UpdateMovie([FromRoute] Guid movieId, UpdateMovieDto updateMovieDto, CancellationToken cancellationToken)
        {
            var result = await _movieDomainService.UpdateMovie(movieId, updateMovieDto, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// this method retrun Genre
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public virtual async Task<ActionResult<List<GenreSelectedDto>>> GetGenres(CancellationToken cancellationToken)
        {
            var result = await _movieDomainService.GetGenres(cancellationToken);
            return Ok(result);
        }
    }
}