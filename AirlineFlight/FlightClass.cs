using System.Runtime.ExceptionServices;

namespace AirlineFlight;

public class FlightClass
{
    public static Random random = new Random();
    public enum AirClass
    {
       FirstClass = 1, 
       BusinessClass = 2,
       PremiumClass = 3
    }
            
    public static string SetRandomClass()
    {
       int rndIndex = random.Next(Enum.GetValues(typeof(AirClass)).Length);
       AirClass rndFlightClass = (AirClass)Enum.GetValues(typeof(AirClass)).GetValue(rndIndex)!;
        return rndFlightClass.ToString();   
    }

}