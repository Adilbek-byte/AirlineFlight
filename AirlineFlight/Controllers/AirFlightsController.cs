using AirlineFlight;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.WebSockets;

namespace AirlineFlight.Controllers;

[ApiController]
[Route("flights")]
public class AirFlightsController : ControllerBase
{
    public static List<Flight> planes = AirFlights.CreateFlights();

    [HttpGet("flights")]
    public List<Flight> GetFlights()
    {
        return planes;
    }

    [HttpPost("report")]
    public Flight Post(Flight flight)
    {
        return flight;
    }

    private Flight? flightId;

    [HttpGet("Direction")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]

    public async Task<ActionResult<List<Flight>>> GetDirection()
    {
        await Task.Delay(1000);
        try
        {
            var res = planes.Select(x => x.Direction).ToList();
            if (res.Count == 0) throw new Exception("nothing is found");
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("id")]
    public Flight GetFlight(Flight flight, int fligthId)
    {
        return flightId!;
    }

    [HttpPost("{id}", Name = "PostNewFlight")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    [ProducesResponseType(500, Type = typeof(string))]

    public async Task<IActionResult> PostFlight(Flight flight, int id)
    {
        await Task.Delay(1000);
        try
        {
            var res = planes.FirstOrDefault(x => x.FlightId == id);
            if (res != null) throw new Exception("the id you are looking for already exists");
            
            flight.FlightId = id;
            planes.Add(flight);
            return CreatedAtRoute("PostNewFlight", new { id }, flight);            
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("update", Name = "UpdateFlight")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    public ActionResult<List<Flight>> UpdateFlight([FromQuery]Flight flight, int id) 
    {    
        try
        {
            var res = planes.FirstOrDefault(x => x.FlightId == id);
            if (res == null) throw new Exception("the id has not been found");

            res.Direction = flight.Direction;
            res.Type = flight.Type;
            res.AviaName = flight.AviaName;
            res.PriceOfTicket = flight.PriceOfTicket;
            res.FlightId = flight.FlightId;

            return CreatedAtRoute("UpdateFlight", new { id }, flight);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
}
