using AirlineFlight.DataBase;
using AirlineFlight.Services.Interfaces;
using AirlineFlightl;
using Microsoft.EntityFrameworkCore;

namespace AirlineFlight.Services;

public class FlightService : IFlightService 
{
    private readonly FlightDb _context;

    public FlightService(FlightDb context)
    {
        _context = context;
    }

   public async Task<List<LocationPath>> getDirection()
    {
        var directions = await _context.Flights.Select(x => x.Direction!).ToListAsync(); 
        return directions;
    }

    public async Task<Flight> PostFlight(Flight flight, int flightId)
    {
        var res = await _context.Flights.FirstOrDefaultAsync(x => x.Id == flightId);
        if (res != null) throw new Exception("the id you are looking for already exists");
        flight.Id = flightId;
        _context.Flights.Add(flight);
        return res!;
    }

    public async Task<List<Flight>> GetPassengerTicket(int numOfPassenger,
        string typeOfPassenger,
        string direction)
    {
        var res = await _context.Flights.Where(t => t.Direction!.ToWhere == direction).ToListAsync();

        if (numOfPassenger <= 0) throw new Exception("the number of passengers should not be less or eqqual to zero! ");
        if (res.Count == 0) throw new Exception("such a location is not found");
        if (!Enum.TryParse<TypeOfPrices.Category>(typeOfPassenger, out var category)) throw new Exception("Invalid passenger category");
        return res;


    }

    public async Task<List<Flight>> GetNumberOfFlights(int number) => 
        await _context.Flights.Take(number).ToListAsync();

    public async Task<Flight> UpdateFlight(string aviaName, int Id, int passId, string type)
    {
         await _context.Flights.Where(x => x.Id == Id).ExecuteUpdateAsync(
            s => s
            .SetProperty(x => x.AviaName, aviaName)
            .SetProperty(x => x.Type, type)
            .SetProperty(x => x.PassengerId, passId)
            );

        return await _context.Flights.FindAsync(Id) ?? throw new Exception();
        
 
    }


    public async Task DeleteFlight(int Id)
    {
        /*var flightToDelete = await _context.Flights.FindAsync(Id);
        var res = flightToDelete == null ? throw new Exception() : _context.Flights.Remove(flightToDelete);*/
        await _context.Flights.Where(x => x.Id == Id).ExecuteDeleteAsync();
        await _context.SaveChangesAsync();
      

    }

    public async Task<List<Passenger>> GetBonus()
    {
        var bonus = await _context.Passengers.ToListAsync();
        var res = bonus.Any(x => x.TotalPeople >= 7);
        foreach (var item in bonus)
        {
            item!.FreeTaxi = res;
        }
        await _context.SaveChangesAsync();
        return bonus;
    }
   
        

}
