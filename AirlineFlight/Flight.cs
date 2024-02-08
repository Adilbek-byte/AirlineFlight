using AirlineFlightl;

namespace AirlineFlight;

public class Flight
{
    public static Random random = new Random();

    public Flight() {}
    public Flight(int flightId, string aviaName, bool isAvailable,  string type, LocationPath direction, FlightSchedule date, TypeOfPrices priceOfTicket, Passenger passenger)
    {
        FlightId = flightId;
        AviaName = aviaName;
        IsAvailable = isAvailable;
        Type = type;
        Direction = direction;
        Date = date;
        PriceOfTicket = priceOfTicket;
        Passengers = passenger;
    }

    public int FlightId { get; set; }
    public string? AviaName { get; set; }
    public bool IsAvailable { get; set; }
   
    public string? Type { get; set; }
    public LocationPath? Direction { get; set; }
    public FlightSchedule? Date { get; set; }
    public TypeOfPrices? PriceOfTicket { get; set; } 
    public Passenger? Passengers { get; set; }


    


    public static bool IsGearedUp()
    {
        bool[] isReady = { true, false };
        return isReady[(int)(random.Next(isReady.Length))];
    }

}
