using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace AirlineFlight.Configuration;

public class FlightDbConfiguration : IEntityTypeConfiguration<FlightEntity>
{
    public void Configure(EntityTypeBuilder<FlightEntity> builder)
    {
        
            builder.HasOne(f => f.Direction).
             WithMany()
             .HasForeignKey(f => f.DirectionId);

    
            builder.HasOne(f => f.Weather)
            .WithOne()
            .HasForeignKey<WeatherForecastEntity>(f => f.WeatherId);   

    }
}
