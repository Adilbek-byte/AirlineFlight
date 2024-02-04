using AirlineFlightl;

namespace AirlineFlight;

public class AirFlights 
{
    public static List<Flight> CreateFlights() {
        List<Flight> Flights = new List<Flight>()
    {
        new Flight(1, "Turkish Airlines", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "Bishkek", ToWhere = "Delphi" }, Date = new FlightSchedule()},
        new Flight(2, "Air Bishkek", Flight.IsGearedUp(), FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Children))
        { Direction = new LocationPath { FromWhere = "Bishkek", ToWhere = "Rome" }, Date = new FlightSchedule()},
        new Flight(3, "Fly Dubai", Flight.IsGearedUp(), FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Children))
        { Direction = new LocationPath { FromWhere = "Osh", ToWhere = "Dubai" }, Date = new FlightSchedule() },
        new Flight(4, "Aeroflot", Flight.IsGearedUp(), FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "Astana", ToWhere = "Moskva" }, Date = new FlightSchedule() },
        new Flight(5, "Fly Emirates", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Children))
        { Direction = new LocationPath { FromWhere = "Doha", ToWhere = "Tokyo" }, Date = new FlightSchedule() },
        new Flight(6, "British Airline", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "London", ToWhere = "New-York" }, Date = new FlightSchedule()},
         new Flight(7, "Fly Ethihad", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "Ethihad", ToWhere = "Brusell" }, Date = new FlightSchedule()},
         new Flight(8, "Turkish Airlines", Flight.IsGearedUp(), FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "Tamchy", ToWhere = "Istanbul" } },
        new Flight(9, "Pegasus", Flight.IsGearedUp(), FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Children))
        { Direction = new LocationPath { FromWhere = "Bishkek", ToWhere = "Saudi Arabia, Riyadh" } },
        new Flight(10, "Air Astana", Flight.IsGearedUp(), FlightClass.SetRandomClass(),  TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Children))
        { Direction = new LocationPath { FromWhere = "Astana", ToWhere = "Bishkek" } },
        new Flight(11, "Aeroflot", Flight.IsGearedUp(), FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "Moscow", ToWhere = "Osh" } },
         new Flight(12, "Air Kyrgyzstan", Flight.IsGearedUp(), FlightClass.SetRandomClass(),  TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Children))
        { Direction = new LocationPath { FromWhere = "Jalal-Abad", ToWhere = "Bishkek" } },
        new Flight(13, "Air Kyrgyzstan", Flight.IsGearedUp(), FlightClass.SetRandomClass(), TypeOfPrices.PriceOfTickets(TypeOfPrices.Category.Adult))
        { Direction = new LocationPath { FromWhere = "Tamchy", ToWhere = "London" } }


    };
        return Flights;
    }
    

}