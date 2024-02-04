using Microsoft.AspNetCore.Mvc;
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

    [HttpPost("report")]
    public Flight Post(Flight flight)
    {
        return flight;
    }

    [HttpGet("quantity", Name = "GetCurtainNumberOfFlights")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    public ActionResult<List<Flight>> GetNumberOfFlights(int number)
    {
        List<Flight> result = new List<Flight>();
        try
        {
            if (number < 0)
                throw new Exception("The entered number should not be less than 0");
            else if (number > planes.Count) throw new Exception(" number out of scope");

            for(int i = 0; i < number && i < planes.Count; i++)
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


    

    
}
