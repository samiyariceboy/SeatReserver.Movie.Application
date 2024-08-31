using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeatReserver.Movie.Domain.Entities.Sans;

namespace SeatReserver.Movie.Infrastructure.EntityConfigurations.Sans
{
    public class MovieSansentityConfiguration : IEntityTypeConfiguration<MovieSans>
    {
        public void Configure(EntityTypeBuilder<MovieSans> builder)
        {
            builder.HasOne(one => one.Movie)
                .WithMany(many => many.MovieSans)
                .HasForeignKey(foreignKey => foreignKey.MovieId);

            builder.HasOne(one => one.Sans)
               .WithMany(many => many.MovieSans)
               .HasForeignKey(foreignKey => foreignKey.SancId);

            builder.HasMany(many => many.ReserveSeats)
                .WithOne(one => one.MovieSans);

        }
    }
}