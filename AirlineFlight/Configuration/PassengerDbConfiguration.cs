using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineFlight.Configuration;

public class PassengerDbConfiguration : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        builder.ToTable("Passengers");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Flights)
              .WithOne(x => x.Passengers);
         
            

    }
}
