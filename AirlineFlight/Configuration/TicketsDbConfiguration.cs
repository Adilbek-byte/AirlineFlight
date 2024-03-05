using AirlineFlightl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineFlight.Configuration;

public class TicketsDbConfiguration : IEntityTypeConfiguration<TypeOfPrices>
{
    public void Configure(EntityTypeBuilder<TypeOfPrices> builder)
    {
        builder.ToTable("Tickets");
        builder.HasKey(x => x.PassengerId);
        builder.HasMany(x => x.FlightClass)
            .WithOne(x => x.TypeOfPrices);
            
            
    }
}
