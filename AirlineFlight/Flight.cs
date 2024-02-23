using AirlineFlight.Models;
using AirlineFlightl;

namespace AirlineFlight;
 
public class Flight
{
    // random instance to access random methods from 
    public static Random random = new Random();

    // Empty parameterless Flight constuctor serves to deals with the issues of deseresilization 
    public Flight() {}
    
    // Flight constuctor with parameters initializes the properties down below
    public Flight(int flightId, string aviaName, bool isAvailable,  string type, LocationPathEntity direction, FlightScheduleEntity date, TypeOfPricesEntity priceOfTicket, PassengerEntity passenger, WeatherForecastEntity weather, BonusEntity bonus)
    {
        FlightId = flightId;
        AviaName = aviaName;
        IsAvailable = isAvailable;
        Type = type;
        Direction = direction;
        Date = date;
        PriceOfTicket = priceOfTicket;
        Passengers = passenger;
        Weather = weather;
        Bonus = bonus;
    }
    
    public int FlightId { get; set; }
    public string? AviaName { get; set; }
    public bool IsAvailable { get; set; }
   
    public string? Type { get; set; }
    public LocationPathEntity? Direction { get; set; }
    public FlightScheduleEntity? Date { get; set; }
    public TypeOfPricesEntity? PriceOfTicket { get; set; } 
    public PassengerEntity? Passengers { get; set; }
    public WeatherForecastEntity? Weather { get; set; }

    public BonusEntity? Bonus { get; set; }
    
    /// <summary>
    /// isGearedUp is used to determine if flight is available or not 
    /// </summary>
    /// <returns> boolean value </returns>

    public static bool IsGearedUp()
    {
        bool[] isReady = { true, false };
        return isReady[(int)(random.Next(isReady.Length))];
    }

}
