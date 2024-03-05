using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineFlight.Configuration;

public class HotFlightDbConfiguration : IEntityTypeConfiguration<HotFlight>
{
    public void Configure(EntityTypeBuilder<HotFlight> builder)
    {
        builder.ToTable("HotFlights");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Direction)
            .WithMany(x => x.HotFlights)
            .HasForeignKey(x => x.PathId)
           .OnDelete(DeleteBehavior.Cascade);
           
    }
}
