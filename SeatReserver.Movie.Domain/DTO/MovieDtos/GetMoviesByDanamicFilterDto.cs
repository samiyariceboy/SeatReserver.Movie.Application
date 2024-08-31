namespace SeatReserver.Movie.Domain.DTO.MovieDtos
{
    public class GetMoviesByDaynamicFilterDto 
    {
        public string? Title { get; init; }
        public string? Genres { get; init; }
        public DateTime? StartTimeOfSanc { get; init; }
        public DateTime? EndTimeOfSanc { get; init; }
    }

    public class GetMoviesByDanamicFilter 
    {
        public Guid MovieId { get; init; }
        public string? Title { get; init; }
        public DateTime? StartTimeOfSanc { get; init; }
        public DateTime? EndTimeOfSanc { get; init; }
    }
}
