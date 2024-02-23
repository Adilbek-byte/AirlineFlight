using AirlineFlight.Controllers;
using AirlineFlightl;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Numerics;
using System.Transactions;

namespace AirlineFlight;

public class PassengerEntity
{
    //Passenger data 

    [Key]
    public int PassengerId { get; set; }
    public int Adult { get; set; } = 0;
    public int Child { get; set; } = 0;
    public int TotalPeople { get; set; } = 0;
    public string? TotalSum { get; set; } = null;
    public Guid FlightId { get; set; }
    public FlightEntity? Flights { get; set; }
    public List<FlightEntity>? FlightsList { get; set; }

   


    
    
     
}