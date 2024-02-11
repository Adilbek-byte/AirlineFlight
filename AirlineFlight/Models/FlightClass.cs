using System.Runtime.ExceptionServices;

namespace AirlineFlight;

public class FlightClass
{
    public static Random random = new Random();

    // AirClass enum stores data 
    public enum AirClass
    {
       FirstClass = 1, 
       BusinessClass = 2,
       PremiumClass = 3
    }
    
    /// <summary>
    /// Sets up random class taken from AirClass enum
    /// </summary>
    /// <returns> random generated string data out of AirClass enum </returns>
    public static string SetRandomClass()
    {
       int rndIndex = random.Next(Enum.GetValues(typeof(AirClass)).Length);
       AirClass rndFlightClass = (AirClass)Enum.GetValues(typeof(AirClass)).GetValue(rndIndex)!;
        return rndFlightClass.ToString();   
    }

}