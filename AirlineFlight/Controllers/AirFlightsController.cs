using AirlineFlight.Helper;
using AirlineFlight.Models;
using AirlineFlight.Services;
using AirlineFlight.Services.Interfaces;
using AirlineFlightl;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Net.WebSockets;

namespace AirlineFlight.Controllers;

[ApiController]
[Route("flights")]
public class AirFlightsController: ControllerBase
{
    
    // list named planes stores all the data 
    public static List<Flight> planes = AirFlights.CreateFlights();

    /// <summary>
    /// GetFlights displays the data
    /// </summary>
    /// <returns>the data on browser in the form of Json format</returns>
    [HttpGet]
    public List<Flight> GetFlights()
    {

        return planes;
    }
    /// <summary>
    /// GetNumberOfFlights delivers the number of flights you requested 
    /// </summary>
    /// <param name="numberOfFlights"></param>
    /// <returns>list </returns>

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

    /// <summary>
    /// GetPassenger allows the user to add the quantity of Adults and children then
    /// it'll sum up and give you totalSum 
    /// </summary>
    /// <param name="numOfPassenger"></param>
    /// <param name="typeOfPassenger"></param>
    /// <param name="direction"></param>
    /// <returns> a list with updated data </returns>


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
    /// <summary>
    /// GetPassenger takes passengers out and recalculates totalSum
    /// </summary>
    /// <param name="numOfPassenger"></param>
    /// <param name="typeOfPassenger"></param>
    /// <param name="direction"></param>
    /// <returns>a list with updated data </returns>


    [HttpGet("flight/{numOfPassenger}, {typeOfPassenger}, {direction}", Name = "GetOutPassengers")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    public ActionResult<List<Flight>> GetPassengerOut(int numOfPassenger, string typeOfPassenger, string direction)
    {
        var res = planes.Where(t => t.Direction?.ToWhere == direction).ToList();
        try
        {
            if (numOfPassenger <= 0) throw new Exception("the number of passengers should not be less or eqqual to zero! ");
            if (res.Count == 0) throw new Exception("such a location is not found");
            if (!Enum.TryParse<TypeOfPrices.Category>(typeOfPassenger, out var category)) throw new Exception("Invalid passenger category");

            var output = InputHelper.getPassengerOutHelper(res, typeOfPassenger, numOfPassenger);
            Console.WriteLine(output);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// this contoller keeps track of if anyone purchases more or equal to 7 tickets if so
    /// it'll provide them with a free taxi
    /// </summary>
    /// <returns> a list with  </returns>

    [HttpGet("Bonus")]
    public async Task<IActionResult> GetBonus()
    {
        await Task.Delay(1000);
        var bonus = planes.Where(x => x.Passengers!.TotalPeople >= 7).ToList();  
        try
        {
            foreach (var item in bonus)
            {
                if (bonus.Any())
                    item.Bonus!.FreeTaxi = true;
                else
                    item.Bonus!.FreeTaxi = false;
            }
            return Ok(bonus);
        }
        catch {
            return BadRequest("there is something going wrong");
        }
    }

    /// <summary>
    /// GetById looks for a flight with the searched id 
    /// </summary>
    /// <param name="id"></param>
    /// <returns> a flight wiht the requested id </returns>

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
    /// <summary>
    /// SetUpNewFlight inspects if any flights with the requested id exist or not if not 
    /// it creates a new one with the id 
    /// </summary>
    /// <param name="flight"></param>
    /// <param name="id"></param>
    /// <returns></returns>
   

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

    /// <summary>
    /// deleteFlight removes a flight by id 
    /// </summary>
    /// <param name="flightId"></param>
    /// <returns>string message</returns>

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
