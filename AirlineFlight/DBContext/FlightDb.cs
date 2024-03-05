using AirlineFlight.Configuration;
using AirlineFlightl;
using Microsoft.EntityFrameworkCore;

namespace AirlineFlight.DataBase;

public class FlightDb : DbContext
{
    public FlightDb(DbContextOptions<FlightDb> options) : base(options)
    {

    }

    public DbSet<Flight> Flights => Set<Flight>();
    
    public DbSet<HotFlight> HotFlights => Set<HotFlight>();
    public DbSet<Passenger> Passengers => Set<Passenger>();
    public DbSet<LocationPath> LocationPaths { get; } = null!;
    public DbSet<FlightSchedule> FlightSchedules => Set<FlightSchedule>();
    public DbSet<TypeOfPrices> TypeOfPrices { get; } = null!;



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new FlightDbConfiguration());
        modelBuilder.ApplyConfiguration(new HotFlightDbConfiguration());
        modelBuilder.ApplyConfiguration(new PassengerDbConfiguration());
        modelBuilder.ApplyConfiguration(new TicketsDbConfiguration());

        modelBuilder.Entity<FlightSchedule>().HasKey(x => x.FlightId);
        modelBuilder.Entity<TypeOfPrices>().HasKey(x => x.PassengerId);

        modelBuilder.Entity<Flight>()
            .HasOne(x => x.TypeOfPrices)
            .WithMany(x => x.Flights)
            .HasForeignKey(x => x.TypeOfPricesId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}