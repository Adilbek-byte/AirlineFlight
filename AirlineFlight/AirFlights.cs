using AirlineFlightl;
using AirlineFlight.Models;
namespace AirlineFlight;

public class AirFlights
{
    /// <summary>
    /// This method is applied to create a list of elements within to use it as a database
    /// </summary>
    /// <returns> a list with full of objects inside serves as a database</returns>
    public static List<Flight> CreateFlights()
    {
        List<Flight> Flights = new List<Flight>()
    {
        new Flight(1, "TurkishAirline", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), new LocationPath(){ FromWhere = "Munich", ToWhere = "Istanbul"}, new FlightSchedule(), new TypeOfPrices(), new Passenger(), new WeatherForecast(), new Bonus()),

        new Flight(2, "AirBishkek", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPath(){ FromWhere = "Bishkek", ToWhere = "Osh"}, new FlightSchedule(), new TypeOfPrices(), new Passenger(), new WeatherForecast(), new Bonus()),

        new Flight(3, "AirDubai", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPath() { FromWhere ="Dubai", ToWhere ="Rome"}, new FlightSchedule(), new TypeOfPrices(), new Passenger(), new WeatherForecast(), new Bonus()),

        new Flight(4, "Airoflot", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPath(){FromWhere = "Moskow", ToWhere ="Baku"}, new FlightSchedule(), new TypeOfPrices(), new Passenger(), new WeatherForecast(), new Bonus()),

        new Flight(5, "FlyEmirates", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), new LocationPath(){ FromWhere = "Liverpool", ToWhere = "Madrid"}, new FlightSchedule(),  new TypeOfPrices(), new Passenger(), new WeatherForecast(), new Bonus()),

        new Flight(6, "BritishAirline", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), new LocationPath(){ FromWhere ="London", ToWhere = "New - Yourk"}, new FlightSchedule(), new TypeOfPrices(), new Passenger(), new WeatherForecast(), new Bonus()),

         new Flight(7, "FlyEthihad", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), new LocationPath(){FromWhere = "Ethihad", ToWhere = "Brusell"}, new FlightSchedule(), new TypeOfPrices(), new Passenger(), new WeatherForecast())

        new Flight(8, "FlyEthihad", Flight.IsGearedUp(), FlightClass.SetRandomClass(),  new LocationPath { FromWhere = "Astana", ToWhere = "Bishkek" }, new FlightSchedule(), new TypeOfPrices(), new Passenger(), new WeatherForecast()),
        new Flight(9, "Aeroflot", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPath { FromWhere = "Moscow", ToWhere = "Osh" }, new FlightSchedule(), new TypeOfPrices(), new Passenger(), new WeatherForecast()),
        new Flight(10, "Air Kyrgyzstan", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPath { FromWhere = "Jalal-Abad", ToWhere = "Bishkek" }, new FlightSchedule(), new TypeOfPrices(), new Passenger(), new WeatherForecast()),
        new Flight(11, "Air Kyrgyzstan", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPath { FromWhere = "Tamchy", ToWhere = "London" }, new FlightSchedule(), new TypeOfPrices(), new Passenger(), new WeatherForecast()),
        };
        return Flights;
    }


}