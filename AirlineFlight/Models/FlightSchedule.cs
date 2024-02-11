using System;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace AirlineFlight;

public class FlightSchedule
{
    //random instance to obtain from
    public static Random random = new Random();

    public FlightSchedule()
    {
        Departure = RandomTime(30);
        Return = Departure.AddDays(random.Next(10, 13));
    }
    //this json decorator used for installing the customized date format
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime Departure { get; set; }

    //this json decorator used for installing the customized date format
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime Return { get; set; }

    
    /// <summary>
    /// RandomTime method consoles out days within the range of 1 day till 30
    /// </summary>
    /// <param name="daysRange"></param>
    /// <returns>random datetime </returns>
    public static DateTime RandomTime(int daysRange)
    {
        DateTime today = DateTime.Today;
        DateTime MonthAhead = today.AddDays(random.Next(0, daysRange));
        return MonthAhead;
      
        
    }
    
   
}
