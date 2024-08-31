using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeatReserver.Movie.Domain.Entities.Halls;

namespace SeatReserver.Movie.Infrastructure.EntityConfigurations.Halls
{
    public class SeatEntityConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.Property(p => p.SeatNumber).HasMaxLength(100);

            builder.HasOne(one => one.Hall)
                .WithMany(many => many.Seats)
                .HasForeignKey(foreignKey => foreignKey.HallId);

            builder.HasMany(many => many.ReserveSeats)
                .WithOne(one => one.Seat);
        }
    }
}
