using AirlineFlight.Configuration;
using AirlineFlight.Models;
using AirlineFlightl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace AirlineFlight.DataBase;

public class FlightDb: DbContext    
{ 
    public FlightDb(DbContextOptions<FlightDb> options ) : base(options)
    {   

    }

    public DbSet<FlightEntity> Flights => Set<FlightEntity>();
    
    public DbSet<HotFlightEntity> HotFlights => Set<HotFlightEntity>();
    public DbSet<PassengerEntity> Passengers => Set<PassengerEntity>();
    public DbSet<LocationPathEntity> LocationPaths { get; } = null!;
    public DbSet<FlightScheduleEntity> FlightSchedules => Set<FlightScheduleEntity>();
    public DbSet<TypeOfPricesEntity> TypeOfPrices { get; } = null!;


   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new FlightDbConfiguration());
        modelBuilder.ApplyConfiguration(new HotFlightDbConfiguration());
        modelBuilder.ApplyConfiguration(new PassengerDbConfiguration());


    }


}
