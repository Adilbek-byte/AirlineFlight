﻿using AspAirlineFlight.Models;

namespace AspAirlineFlight.Models;

public class AirFlights
{
    public static List<Flight> CreateFlights()
    {
        List<Flight> Flights = new List<Flight>()
    {
        new Flight(1, "TurkishAirline", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), new LocationPath(){ FromWhere = "Munich", ToWhere = "Istanbul"}, new FlightSchedule(), new TypeOfPrices(), new Passenger()),

        new Flight(2, "AirBishkek", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPath(){ FromWhere = "Bishkek", ToWhere = "Osh"}, new FlightSchedule(), new TypeOfPrices(), new Passenger()),

        new Flight(3, "AirDubai", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPath() { FromWhere ="Dubai", ToWhere ="Rome"}, new FlightSchedule(), new TypeOfPrices(), new Passenger()),

        new Flight(4, "Airoflot", Flight.IsGearedUp(), FlightClass.SetRandomClass(), new LocationPath(){FromWhere = "Moskow", ToWhere ="Baku"}, new FlightSchedule(), new TypeOfPrices(), new Passenger()),

        new Flight(5, "FlyEmirates", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), new LocationPath(){ FromWhere = "Liverpool", ToWhere = "Madrid"}, new FlightSchedule(),  new TypeOfPrices(), new Passenger()),

        new Flight(6, "BritishAirline", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), new LocationPath(){ FromWhere ="London", ToWhere = "New - Yourk"}, new FlightSchedule(), new TypeOfPrices(), new Passenger()),

         new Flight(7, "FlyEthihad", Flight.IsGearedUp(),  FlightClass.SetRandomClass(), new LocationPath(){FromWhere = "Ethihad", ToWhere = "Brusell"}, new FlightSchedule(), new TypeOfPrices(), new Passenger())



    };
        return Flights;
    }


}