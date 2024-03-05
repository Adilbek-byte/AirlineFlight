
using AirlineFlight;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security;


namespace AirlineFlightl;

public class TypeOfPrices
{
    public int PassengerId { get; set; }
    public string? Adults => $"{Random.Shared.Next(299, 1499)} $";
    public string? Children => $"{Random.Shared.Next(50, 300)} $";

    public List<Flight> Flights { get; set; } = new();

    public int FlightClassId { get; set; }
    public List<FlightClass> FlightClass { get; set; } = new();

    public enum Category
    {
        Adult = 1,
        Children = 2
    }

    
    
}