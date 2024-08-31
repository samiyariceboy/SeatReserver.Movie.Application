namespace SeatReserver.Movie.Domain.DTO.MovieDtos
{
    public record CreateMovieDto(string Title, string GenreName)
    {
        public string? Desciption { get; init; }
    }

    public record UpdateMovieDto
    {
        public string? Title { get; init; }
        public string? Desciption { get; init; }
    }
}
