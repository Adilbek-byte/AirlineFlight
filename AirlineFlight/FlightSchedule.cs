using System;

namespace AirlineFlight;

public class FlightSchedule
{
    public static Random random = new Random(); 
   /* private readonly DateTime _start;
    private readonly DateTime _end;*/

    public DateTime Departure { get {
            return RandomTime(30);
        }  }
         
    public DateTime Return { get {
            return Departure.AddDays(random.Next(10, 13));
        } }

    public static DateTime RandomTime(int daysRange)
    {
        DateTime today = DateTime.Today;
        DateTime MonthAhead = today.AddDays(random.Next(0, daysRange));
        return MonthAhead;
      

    }
}
