using AirlineFlight.Helper;
using AirlineFlightl;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Net.WebSockets;

namespace AirlineFlight.Controllers;

[ApiController]
[Route("flights")]
public class AirFlightsController: ControllerBase
{
    public static List<Flight> planes = AirFlights.CreateFlights();
    [HttpGet]
    public List<Flight> GetFlights()
    {
        return planes;
    }

    [HttpGet("quantity", Name = "GetCurtainNumberOfFlights")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    public async Task<ActionResult<List<Flight>>> GetNumberOfFlights(int numberOfFlights)
    {
        await Task.Delay(1000);
        List<Flight> result = new List<Flight>();
        try
        {
            if (numberOfFlights < 0)
                throw new Exception("The entered number should not be less than 0");
            else if (numberOfFlights > planes.Count) throw new Exception(" number out of scope");

            for(int i = 0; i < numberOfFlights && i < planes.Count; i++)
            {
                var flight = planes[i];
                result.Add(flight);
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpGet("{numOfPassenger}, {typeOfPassenger}, {direction}", Name = "GetInfoPassengers")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    public ActionResult<List<Flight>> GetPassenger(int numOfPassenger, string typeOfPassenger, string direction)
    {
        var res = planes.Where(t => t.Direction?.ToWhere == direction).ToList();
        try
        {   if (numOfPassenger <= 0) throw new Exception("the number of passengers should not be less or eqqual to zero! ");
            if (res.Count == 0) throw new Exception("such a location is not found");
            if (!Enum.TryParse<TypeOfPrices.Category>(typeOfPassenger, out var category)) throw new Exception("Invalid passenger category");
            
            var output = InputHelper.getPassengerHelper(res, typeOfPassenger, numOfPassenger);
            Console.WriteLine(output);
            return Ok(res);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpGet("ById/{id}", Name = "GetById")]
    public async Task<IActionResult>GetById(int id)
    {
        await Task.Delay(1000);
        try
        {
          var res = planes.Where(t => t.FlightId == id).ToList();
            if (res.Count == 0) throw new Exception("the id you are looking for is not found!");
            return Ok(res);
        }
        
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
       
    }

    [HttpPost("{id}", Name = "CreateFlightById")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
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
