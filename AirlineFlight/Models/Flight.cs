using System.ComponentModel.DataAnnotations.Schema;
using AirlineFlightl;
namespace AirlineFlight;

public class Flight
{
    
    public int Id { get; set; }

    public string? AviaName { get; set; }

    public bool IsAvailable { get; set; }

    public string? Type { get; set; }

    // Foreign key for LocationPath
    public int DirectionId { get; set; }
     

    public LocationPath? Direction { get; set; }

    // Foreign key for FlightSchedule
    public int DateId { get; set; }
  
    public FlightSchedule? Date { get; set; }

    // Foreign key for TypeOfPrices
    public int TypeOfPricesId { get; set; }

    public TypeOfPrices? TypeOfPrices { get; set; }

    // Foreign key for Passenger
    public int PassengerId { get; set; }

    public Passenger? Passengers { get; set; } = new();

     

   
}