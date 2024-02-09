using AirlineFlightl;
using Microsoft.AspNetCore.Mvc;

namespace AirlineFlight;

public class AirFlights
{
    public static List<Flight> CreateFlights()
    {
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


    /*public static List<Flight> AirNameMethod(List<Flight> flights)
    {
        *//*var uniqueFlights = flights.Concat(avia)
                                   .GroupBy(x => x.AviaName)
                                   .Select(group => group.First())
                                   .OrderBy(x => x.AviaName)
                                   .ToList();*//*
        try
        {
            var flightsByName = flights.Select(z => z.Direction);
            if (flightsByName == null) throw new Exception("nothing is found");
            return flightsByName;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"that is wrong: " ex.Message);
        }
        
    }*/












    //public static List<Flight> AirNameMethod(List<Flight> flights)
    //{
    //    var uniqueFlights = flights.GroupBy(x => x.AviaName)
    //                           .Select(group => group.First())
    //                           .ToList();                                        kerek

    //    // Затем сортируем по свойству AviaName
    //    var sortedFlights = uniqueFlights.OrderBy(x => x.AviaName == x.AviaName).ToList();

    //    return sortedFlights;
    //}



    //public static List<Flight> AirNameMethod(List<Flight> flights, Flight avia)                  1)
    //{
    //    var uniqueFlights = flights.OrderBy(x => x.AviaName == avia.AviaName)                               
    //                           .ToList();
    //    uniqueFlights.Add(avia);
    //    // Затем сортируем по свойству AviaName
    //   // var sortedFlights = uniqueFlights.OrderBy(x => x.AviaName == x.AviaName).ToList();

    //    return uniqueFlights;
    //}







    //public static List<Flight> AirNameMethod(List<Flight> flights)
    //{
    //    List<Flight> filteredFlights = new List<Flight>();

    //    foreach (Flight item in filteredFlights)
    //    {
    //        var hasSameAviaName = filteredFlights.OrderBy(x => x.AviaName == item.AviaName);

    //        //var res = hasSameAviaName;

    //        var res = hasSameAviaName;
    //        return res.ToList();
    //    }

    //    return filteredFlights;
    //}




    //public static List<Flight> AirNameMethod()
    //{
    //    List<Flight> airName1 = new List<Flight>();

    //    foreach (Flight item in airName1)
    //    {
    //        airName1.Where(x => x.AviaName == item.AviaName);
    //        airName1.Add(item);

    //    }
    //    return airName1;
    //}
}
//Flight _airname = new Flight
//List<AirFlights> flights1 = new List<AirFlights>();
//public List<AirFlights> DirectionRes(this List<Flight> _flights, Flight _direction)
//{

//    var flights1 = _flights.OrderBy(x => x.Direction == _direction.Direction).ToList();
//    flights1.Add(_direction);
//    return 
//}