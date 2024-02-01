using AirlineFlightl;

namespace AirlineFlight;

public class Flight
{
    public static Random random = new Random(); 
    public Flight(int flightId, string? aviaName, bool isAvailable, DateTime date, FlightClass type, int priceOfTicket)
    {
        FlightId = flightId;
        AviaName = aviaName;
        IsAvailable = isAvailable;
        Date = date;
        Type = type;
        PriceOfTicket = priceOfTicket;
        
    }

    public int FlightId { get; set; }
    public string? AviaName { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime Date { get; } = Flight.RandomTime();
    public FlightClass Type { get; set; }
    public int PriceOfTicket { get; set; } 



    public LocationPath? Direction { get; set; }




    public static DateTime RandomTime()
    {
        DateTime today = DateTime.Today;
        DateTime MonthAhead = today.AddMonths(1);
        int randomNumberofDays = random.Next(0, (int)(MonthAhead - today).TotalDays);
        DateTime randomDateTime = today.AddDays(randomNumberofDays);
        return randomDateTime;

    }

    public static bool IsGearedUp()
    {
        bool[] isReady = { true, false };
        return isReady[(int)(random.Next(isReady.Length))];
    }

}
