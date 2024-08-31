using FluentValidation;
using FluentValidation.AspNetCore;

namespace SeatReserver.Movie.Application.Registeration
{
    public static class RegisterFluent
    {
        public static void RegisterFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<Program>();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
        }
    }
}
