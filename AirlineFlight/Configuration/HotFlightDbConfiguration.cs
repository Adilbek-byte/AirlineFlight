using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineFlight.Configuration;

public class HotFlightDbConfiguration : IEntityTypeConfiguration<HotFlightEntity>
{
    public void Configure(EntityTypeBuilder<HotFlightEntity> builder)
    {
        builder.ToTable("HotFlights");
        builder.HasKey(x => x.HotId);
        builder.HasMany(x => x.Direction)
            .WithOne()
            .HasForeignKey(x => x.HotId)
           .OnDelete(DeleteBehavior.Cascade);
           
    }
}
