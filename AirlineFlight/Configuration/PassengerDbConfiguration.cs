using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineFlight.Configuration;

public class PassengerDbConfiguration : IEntityTypeConfiguration<PassengerEntity>
{
    public void Configure(EntityTypeBuilder<PassengerEntity> builder)
    {
        builder.ToTable("Passengers");
        builder.HasKey(x => x.PassengerId);
        builder.HasMany(p => p.FlightsList)
              .WithOne(f => f.Passengers)
              .HasForeignKey(p => p.FlightId)
              .OnDelete(DeleteBehavior.Cascade);

    }
}
