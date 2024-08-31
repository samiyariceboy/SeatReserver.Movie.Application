using SeatReserver.Movie.Domain.Common.Utilities;

namespace SeatReserver.Movie.Domain.DTO.MovieDtos
{
    public class MovieSelectedDto
    {
        public Guid MovieId { get; init; }
        public string Title { get;  init; }
        public List<MovieSancSelectedDto> MovieSancSelectedDtos { get; init; }
    }


    public class MovieSancSelectedDto
    {
        public CustomDateTimeFormat  StartTimeOfSanc { get; set; }
        public CustomDateTimeFormat EndTimeOdSanc { get; set; }
    }
}
