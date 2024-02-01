using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace AirlineFlight.Controllers;

[ApiController]
[Route("flights")]
public class AirFlightsController: ControllerBase
{
    public static List<Flight> planes = AirFlights.CreateFlights();
    [HttpGet("flights")]
    public List<Flight> GetFlights()
    {
        return planes;
    }

    
}
