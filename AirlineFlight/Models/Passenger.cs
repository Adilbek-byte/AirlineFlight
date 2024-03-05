using AirlineFlight.Controllers;
using AirlineFlightl;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Numerics;
using System.Transactions;

namespace AirlineFlight;

public class Passenger
{
    //Passenger data 

    
    public int Id { get; set; }
    public int Adult { get; set; } = 0;
    public int Child { get; set; } = 0;
    public int TotalPeople { get; set; } = 0;
    public string? TotalSum { get; set; } = null;
    public bool FreeTaxi { get; set; }
    public int FlightId { get; set; }
    
    public TypeOfPrices? Tickets { get; set; }
    public List<Flight>? Flights { get; set; } = new();
    

   


    
    
     
}