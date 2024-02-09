using AirlineFlight;
using AirlineFlight.Services.Interfaces;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;

namespace AirlineFlight.Services;

public class FlightService: IFlightService
{
    private readonly List<Flight> formFlight = AirFlights.CreateFlights();   
    

    public async Task<List<Flight>> GetFligthsAsync()
    {
        await Task.Delay(1500);
        return formFlight;
    } 
     
}
