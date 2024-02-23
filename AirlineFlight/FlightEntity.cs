using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AirlineFlightl;
using AirlineFlight.Models;

namespace AirlineFlight;

public class FlightEntity
{
    [Key]
    public int FlightId { get; set; }

    public string? AviaName { get; set; }

    public bool IsAvailable { get; set; }

    public string? Type { get; set; }

    // Foreign key for LocationPath
    public Guid DirectionId { get; set; }

    public List<LocationPathEntity>? Direction { get; set; }

    // Foreign key for FlightSchedule
    public int DateId { get; set; }
    [ForeignKey(nameof(DateId))]
    public FlightScheduleEntity? Date { get; set; }

    // Foreign key for TypeOfPrices
    public Guid PriceOfTicketId { get; set; }
  
    public List<TypeOfPricesEntity>? PriceOfTicket { get; set; }

    // Foreign key for Passenger
    public int PassengerId { get; set; }
    [ForeignKey(nameof(PassengerId))]
    public PassengerEntity? Passengers { get; set; }

    public WeatherForecastEntity? Weather { get; set; }

    // Foreign key for Bonus
    public int? BonusId { get; set; }
    [ForeignKey(nameof(BonusId))]
    public BonusEntity? Bonus { get; set; }
}