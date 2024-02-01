using AirlineFlightl;

namespace AirlineFlight;

public class AirFlights 
{
    public static List<Flight> CreateFlights() {
        List<Flight> Flights = new List<Flight>()
    {
        new Flight(1, "TurkishAirline", Flight.IsGearedUp(), Flight.RandomTime(), FlightClass.BusinessClass, TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "Bishkek", ToWhere = "Delphi" } },
        new Flight(2, "AirBishkek", Flight.IsGearedUp(), Flight.RandomTime(), FlightClass.BusinessClass, TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Children))
        { Direction = new LocationPath { FromWhere = "Bishkek", ToWhere = "Rome" } },
        new Flight(3, "AirDubai", Flight.IsGearedUp(), Flight.RandomTime(), FlightClass.FirstClass, TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Children))
        { Direction = new LocationPath { FromWhere = "Osh", ToWhere = "Dubai" } },
        new Flight(4, "Airoflot", Flight.IsGearedUp(), Flight.RandomTime(), FlightClass.PremiumClass, TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "Astana", ToWhere = "Moskva" } }

    };
        return Flights;
    }
    

}