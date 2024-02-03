using AirlineFlightl;

namespace AirlineFlight;

public class AirFlights 
{
    public static List<Flight> CreateFlights() {
        List<Flight> Flights = new List<Flight>()
    {
        new Flight(1, "Turkish Airlines", Flight.IsGearedUp(), Flight.RandomTime(), FlightClass.BusinessClass, TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "Bishkek", ToWhere = "Delphi" } },
        new Flight(2, "Air Kyrgyzstan", Flight.IsGearedUp(), Flight.RandomTime(), FlightClass.BusinessClass, TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Children))
        { Direction = new LocationPath { FromWhere = "Bishkek", ToWhere = "Rome" } },
        new Flight(3, "Fly Dubai", Flight.IsGearedUp(), Flight.RandomTime(), FlightClass.FirstClass, TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Children))
        { Direction = new LocationPath { FromWhere = "Osh", ToWhere = "Dubai" } },
        new Flight(4, "Aeroflot", Flight.IsGearedUp(), Flight.RandomTime(), FlightClass.PremiumClass, TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "Astana", ToWhere = "Moskva" } },
        new Flight(5, "Turkish Airlines", Flight.IsGearedUp(), Flight.RandomTime(), FlightClass.BusinessClass, TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "Tamchy", ToWhere = "Istanbul" } },
        new Flight(6, "Pegasus", Flight.IsGearedUp(), Flight.RandomTime(), FlightClass.BusinessClass, TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Children))
        { Direction = new LocationPath { FromWhere = "Bishkek", ToWhere = "Saudi Arabia, Riyadh" } },
        new Flight(7, "Air Astana", Flight.IsGearedUp(), Flight.RandomTime(), FlightClass.FirstClass, TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Children))
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