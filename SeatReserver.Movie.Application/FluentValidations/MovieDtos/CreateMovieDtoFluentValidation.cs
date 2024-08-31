using FluentValidation;
using SeatReserver.Movie.Domain.DTO.MovieDtos;

namespace SeatReserver.Movie.Application.FluentValidations.MovieDtos
{
    public class CreateMovieDtoFluentValidation : AbstractValidator<CreateMovieDto>
    {
        public CreateMovieDtoFluentValidation()
        {
            RuleFor(c => c.Title).MaximumLength(255).NotEmpty();
            RuleFor(c => c.Desciption).MaximumLength(500);
        }
    }
}
