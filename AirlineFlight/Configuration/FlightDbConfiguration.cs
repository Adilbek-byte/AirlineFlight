using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace AirlineFlight.Configuration;

public class FlightDbConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        
            builder.HasOne(f => f.Direction).
             WithOne()
             .HasForeignKey<Flight>(f => f.DirectionId);


            
       

    }
}
