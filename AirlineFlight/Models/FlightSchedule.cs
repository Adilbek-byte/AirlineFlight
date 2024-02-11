using System;
using System.Text.Json.Serialization;

namespace AirlineFlight;

public class FlightSchedule
{
    public static Random random = new Random();

    public FlightSchedule()
    {
        Departure = RandomTime(30);
        Return = Departure.AddDays(random.Next(10, 13));
    }

    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime Departure { get; set; }

    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime Return { get; set; }

    
    
    public static DateTime RandomTime(int daysRange)
    {
        DateTime today = DateTime.Today;
        DateTime MonthAhead = today.AddDays(random.Next(0, daysRange));
        return MonthAhead;
      
        
    }

    
}
