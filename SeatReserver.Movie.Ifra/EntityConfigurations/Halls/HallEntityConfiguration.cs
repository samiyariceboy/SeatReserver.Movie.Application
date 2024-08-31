using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeatReserver.Movie.Domain.Entities.Halls;

namespace SeatReserver.Movie.Infrastructure.EntityConfigurations.Halls
{
    public class HallEntityConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder.Property(p => p.LocationName).HasMaxLength(100);
            builder.Property(p => p.Name).HasMaxLength(100);

            builder.HasMany(many => many.Seats)
                .WithOne(one => one.Hall);
        }
    }
}
