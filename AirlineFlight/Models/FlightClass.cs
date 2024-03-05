using AirlineFlightl;
using System.Runtime.ExceptionServices;

namespace AirlineFlight;

public class FlightClass
{

    public int Id { get; set; }

    public int TypeOfPricesId { get; set; }
    public TypeOfPrices? TypeOfPrices { get; set; }
    public string? PlaneClass => FlightClass.SetRandomClass();

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
       int rndIndex = Random.Shared.Next(Enum.GetValues(typeof(AirClass)).Length);
       AirClass rndFlightClass = (AirClass)Enum.GetValues(typeof(AirClass)).GetValue(rndIndex)!;
        return rndFlightClass.ToString();   
    }

}