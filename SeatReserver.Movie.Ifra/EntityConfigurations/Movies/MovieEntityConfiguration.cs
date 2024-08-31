using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SeatReserver.Movie.Infrastructure.EntityConfigurations.Movies
{
    public class MovieEntityConfiguration : IEntityTypeConfiguration<Domain.Entities.Movies.Movie>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Movies.Movie> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.PosterImage).HasMaxLength(500).IsRequired(false);


            builder.HasMany(many => many.MovieSans)
                .WithOne(one => one.Movie);

            builder.HasMany(many => many.MovieSans)
                .WithOne(one => one.Movie);

            builder.HasOne(one => one.Genre)
                .WithMany(many => many.Movies)
                .HasForeignKey(foreignKey => foreignKey.GenreId);
        }
    }
}
