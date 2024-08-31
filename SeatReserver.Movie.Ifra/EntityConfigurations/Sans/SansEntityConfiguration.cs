using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SeatReserver.Movie.Infrastructure.EntityConfigurations.Sans
{
    public class SansEntityConfiguration : IEntityTypeConfiguration<Domain.Entities.Sans.Sans>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Sans.Sans> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(200);

            builder.HasMany(many => many.MovieSans)
                .WithOne(one => one.Sans);
        }
    }
}
