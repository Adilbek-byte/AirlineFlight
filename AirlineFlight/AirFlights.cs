using AirlineFlightl;

namespace AirlineFlight;

public class AirFlights
{
    public static List<Flight> CreateFlights()
    {
        List<Flight> Flights = new List<Flight>()
    {
        new Flight(1, "TurkishAirline", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), new LocationPath(){ FromWhere = "Munich", ToWhere = "Istanbul"}, new FlightSchedule(), new TypeOfPrices(), new Passenger(), new WeatherForecast()),

        new Flight(2, "AirBishkek", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPath(){ FromWhere = "Bishkek", ToWhere = "Osh"}, new FlightSchedule(), new TypeOfPrices(), new Passenger(), new WeatherForecast()),

        new Flight(3, "AirDubai", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPath() { FromWhere ="Dubai", ToWhere ="Rome"}, new FlightSchedule(), new TypeOfPrices(), new Passenger(), new WeatherForecast()),

        new Flight(4, "Airoflot", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPath(){FromWhere = "Moskow", ToWhere ="Baku"}, new FlightSchedule(), new TypeOfPrices(), new Passenger(), new WeatherForecast()),

        new Flight(5, "FlyEmirates", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), new LocationPath(){ FromWhere = "Liverpool", ToWhere = "Madrid"}, new FlightSchedule(),  new TypeOfPrices(), new Passenger(), new WeatherForecast()),

        new Flight(6, "BritishAirline", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), new LocationPath(){ FromWhere ="London", ToWhere = "New - Yourk"}, new FlightSchedule(), new TypeOfPrices(), new Passenger(), new WeatherForecast()),

         new Flight(7, "FlyEthihad", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), new LocationPath(){FromWhere = "Ethihad", ToWhere = "Brusell"}, new FlightSchedule(), new TypeOfPrices(), new Passenger(), new WeatherForecast())

        { Direction = new LocationPath { FromWhere = "Astana", ToWhere = "Bishkek" } },
        new Flight(8, "Aeroflot", Flight.IsGearedUp(), Flight.RandomTime(), FlightClass.PremiumClass, TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "Moscow", ToWhere = "Osh" } },
         new Flight(9, "Air Kyrgyzstan", Flight.IsGearedUp(), Flight.RandomTime(), FlightClass.FirstClass, TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Children))
        { Direction = new LocationPath { FromWhere = "Jalal-Abad", ToWhere = "Bishkek" } },
        new Flight(10, "Air Kyrgyzstan", Flight.IsGearedUp(), Flight.RandomTime(), FlightClass.PremiumClass, TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "Tamchy", ToWhere = "London" } }
        };
        return Flights;
    }
}
