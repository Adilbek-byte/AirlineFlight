using AirlineFlightl;

namespace AirlineFlight;

public class Flight
{
    public static Random random = new Random(); 
    public Flight(int flightId, string? aviaName, bool isAvailable,  string type, int priceOfTicket)
    {
        FlightId = flightId;
        AviaName = aviaName;
        IsAvailable = isAvailable;
       
        Type = type;
        PriceOfTicket = priceOfTicket;
        
    }

    public int FlightId { get; set; }
    public string? AviaName { get; set; }
    public bool IsAvailable { get; set; }
   
    public string? Type { get; set; }
    public int PriceOfTicket { get; set; } 



    public LocationPath? Direction { get; set; }
    public FlightSchedule? Date { get; set; }





    public static bool IsGearedUp()
    {
        bool[] isReady = { true, false };
        return isReady[(int)(random.Next(isReady.Length))];
    }

}
