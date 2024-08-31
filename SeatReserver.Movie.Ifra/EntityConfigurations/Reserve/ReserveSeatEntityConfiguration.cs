using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeatReserver.Movie.Domain.Entities.Reserve;

namespace SeatReserver.Movie.Infrastructure.EntityConfigurations.Reserve
{
    public class ReserveSeatEntityConfiguration : IEntityTypeConfiguration<ReserveSeat>
    {
        public void Configure(EntityTypeBuilder<ReserveSeat> builder)
        {
            builder.HasOne(one => one.Seat)
                .WithMany(many => many.ReserveSeats)
                .HasForeignKey(foreignKey => foreignKey.SeatId);

            builder.HasOne(one => one.MovieSans)
              .WithMany(many => many.ReserveSeats)
              .HasForeignKey(foreignKey => foreignKey.MovieSancId);
        }
    }
}
