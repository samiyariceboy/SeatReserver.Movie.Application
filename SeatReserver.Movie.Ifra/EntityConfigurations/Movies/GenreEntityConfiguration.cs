using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeatReserver.Movie.Domain.Entities.Movie;

namespace SeatReserver.Movie.Infrastructure.EntityConfigurations.Movies
{
    public class GenreEntityConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(100);

            builder.HasMany(many => many.Movies)
                .WithOne(one => one.Genre);
        }
    }
}
