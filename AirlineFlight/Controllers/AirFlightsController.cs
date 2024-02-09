using AirlineFlight.Helper;
using AirlineFlight.Services;
using AirlineFlight.Services.Interfaces;
using AirlineFlightl;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Net.WebSockets;

namespace AirlineFlight.Controllers;

[ApiController]
[Route("flights")]
public class AirFlightsController: ControllerBase
{
    private readonly IFlightService _flightservice;
    public AirFlightsController(IFlightService flightService)
    {
        _flightservice = flightService;
    }

    public static List<Flight> planes = AirFlights.CreateFlights();
    [HttpGet]
    public async Task<IActionResult> GetFlights()
    {
        var res = await _flightservice.GetFligthsAsync();
        return Ok(res);
    }

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
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
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

    public async Task<IActionResult> SetUpNewFlight(Flight flight, int id)
    {
        await Task.Delay(1000);
        try
        {
            
            if (planes.Any(x => x.FlightId == id)) throw new Exception("flight with the provided id already exists");
            flight.FlightId = id;
            planes.Add(flight);
            return CreatedAtRoute("CreateFlightById", new { id }, flight);
        }
        
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("delete/{flightId}")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    public ActionResult<List<Flight>> deleteFlight(int flightId)
    {
        try
        {
            var res = planes.FirstOrDefault(x => x.FlightId == flightId);
            var al = res == null ? throw new Exception("id not found") : planes.Remove(res);
            Console.WriteLine(al);
            return Ok($" flight with the {flightId} has been deleted");
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }











}
