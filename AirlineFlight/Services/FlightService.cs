using AirlineFlight;
using AirlineFlight.DataBase;
using AirlineFlight.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace AirlineFlight.Services;

public class FlightService : IFlightService
{
    private readonly FlightDb _context;

    public FlightService(FlightDb context)
    {
        _context = context;
    }

   public async Task<List<LocationPathEntity>> getDirection()
    {
        var directions = await _context.Flights.SelectMany(x => x.Direction!).ToListAsync(); 
        return directions;
    }

    public async Task<FlightEntity> PostFlight(FlightEntity flight, int flightId)
    {
        var res = await _context.Flights.FirstOrDefaultAsync(x => x.FlightId == flightId);
        if (res != null) throw new Exception("the id you are looking for already exists");
        flight.FlightId = flightId;
        _context.Flights.Add(flight);
        return res!;
    }
    
  

}
