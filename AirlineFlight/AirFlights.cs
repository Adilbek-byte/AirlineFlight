using AirlineFlightl;

namespace AirlineFlight;

public class AirFlights 
{
    public static List<Flight> CreateFlights() {
        List<Flight> Flights = new List<Flight>()
    {
        new Flight(1, "TurkishAirline", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "Bishkek", ToWhere = "Delphi" }, Date = new FlightSchedule()},
        new Flight(2, "AirBishkek", Flight.IsGearedUp(), FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Children))
        { Direction = new LocationPath { FromWhere = "Bishkek", ToWhere = "Rome" }, Date = new FlightSchedule()},
        new Flight(3, "AirDubai", Flight.IsGearedUp(), FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Children))
        { Direction = new LocationPath { FromWhere = "Osh", ToWhere = "Dubai" }, Date = new FlightSchedule() },
        new Flight(4, "Airoflot", Flight.IsGearedUp(), FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "Astana", ToWhere = "Moskva" }, Date = new FlightSchedule() },
        new Flight(5, "FlyEmirates", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Children))
        { Direction = new LocationPath { FromWhere = "Doha", ToWhere = "Tokyo" }, Date = new FlightSchedule() },
        new Flight(6, "BritishAirline", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "London", ToWhere = "New-York" }, Date = new FlightSchedule()},
         new Flight(7, "FlyEthihad", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "Ethihad", ToWhere = "Brusell" }, Date = new FlightSchedule()}


    };
        return Flights;
    }
    

}