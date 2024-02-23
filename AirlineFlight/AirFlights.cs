using AirlineFlightl;
using AirlineFlight.Models;
namespace AirlineFlight;

public class AirFlights
{

    /// <summary>
    /// This method is applied to create a list of elements within to use it as a database
    /// </summary>
    /// <returns> a list with full of objects inside serves as a database</returns>
  
    public static List<Flight> CreateFlights() //метод для списка вместо базы

    {
        List<Flight> Flights = new List<Flight>()
    {
        new Flight(1, "TurkishAirline", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), new LocationPathEntity(){ FromWhere = "Munich", ToWhere = "Istanbul"}, new FlightScheduleEntity(), new TypeOfPricesEntity(), new PassengerEntity(), new WeatherForecastEntity(), new BonusEntity()),

        new Flight(2, "AirBishkek", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPathEntity(){ FromWhere = "Bishkek", ToWhere = "Osh"}, new FlightScheduleEntity(), new TypeOfPricesEntity(), new PassengerEntity(), new WeatherForecastEntity(), new BonusEntity()),

        new Flight(3, "AirDubai", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPathEntity() { FromWhere ="Dubai", ToWhere ="Rome"}, new FlightScheduleEntity(), new TypeOfPricesEntity(), new PassengerEntity(), new WeatherForecastEntity(), new BonusEntity()),

        new Flight(4, "Airoflot", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPathEntity(){FromWhere = "Moskow", ToWhere ="Baku"}, new FlightScheduleEntity(), new TypeOfPricesEntity(), new PassengerEntity(), new WeatherForecastEntity(), new BonusEntity()),

        new Flight(5, "FlyEmirates", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), new LocationPathEntity(){ FromWhere = "Liverpool", ToWhere = "Madrid"}, new FlightScheduleEntity(),  new TypeOfPricesEntity(), new PassengerEntity(), new WeatherForecastEntity(), new BonusEntity()),

        new Flight(6, "BritishAirline", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), new LocationPathEntity(){ FromWhere ="London", ToWhere = "New - Yourk"}, new FlightScheduleEntity(), new TypeOfPricesEntity(), new PassengerEntity(), new WeatherForecastEntity(), new BonusEntity()),

         new Flight(7, "FlyEthihad", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), new LocationPathEntity(){FromWhere = "Ethihad", ToWhere = "Brusell"}, new FlightScheduleEntity(), new TypeOfPricesEntity(), new PassengerEntity(), new WeatherForecastEntity(), new BonusEntity()), 

        new Flight(8, "FlyEthihad", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPathEntity { FromWhere = "Astana", ToWhere = "Bishkek" }, new FlightScheduleEntity(), new TypeOfPricesEntity(), new PassengerEntity(), new WeatherForecastEntity(), new BonusEntity()),
        new Flight(9, "Aeroflot", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPathEntity { FromWhere = "Moscow", ToWhere = "Osh" }, new FlightScheduleEntity(), new TypeOfPricesEntity(), new PassengerEntity(), new WeatherForecastEntity(), new BonusEntity()),
        new Flight(10, "Air Kyrgyzstan", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPathEntity { FromWhere = "Jalal-Abad", ToWhere = "Bishkek" }, new FlightScheduleEntity(), new TypeOfPricesEntity(), new PassengerEntity(), new WeatherForecastEntity(), new BonusEntity()),
        new Flight(11, "Air Kyrgyzstan", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPathEntity { FromWhere = "Tamchy", ToWhere = "London" }, new FlightScheduleEntity(), new TypeOfPricesEntity(), new PassengerEntity(), new WeatherForecastEntity(), new BonusEntity()),
        };
        return Flights;

        }
    }



