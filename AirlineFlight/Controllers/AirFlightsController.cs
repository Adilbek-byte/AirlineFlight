using AirlineFlight.DataBase;
using AirlineFlight.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineFlight.Controllers;

[ApiController]
[Route("flights")]


public class AirFlightsController : ControllerBase
{
    private readonly FlightDb _contextDb;
    private readonly IFlightService _flightService;
    
   

    public AirFlightsController(FlightDb contextDb, IFlightService flightService)
    {
        _contextDb = contextDb;
        _flightService = flightService;
    }



  

    [HttpGet]
    public async Task<IActionResult> GetFlights()
    {
        var movies = await _contextDb.Flights.OrderBy(x => x.Date).ToListAsync();
        return Ok(movies);
    }


    /// <summary>
    /// GetDirection displays all the directions 
    /// </summary>
    /// <returns>list of directions </returns>
    /// 

    

    [HttpGet("direction", Name = "GetDirection")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]

    public async Task<ActionResult<List<Flight>>> GetDirection()
    {
      
        try
        {
            var res = await _flightService.getDirection();
           
            return res.Count == 0 ? throw new Exception("nothing is found") : Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }




    /// <summary>
    /// 
    /// </summary>
    /// <param name="flight"></param>
    /// <param name="id"></param>
    /// <returns></returns>



    


    [HttpPost(Name = "PostNewFlight")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    [ProducesResponseType(500, Type = typeof(string))]

    public async Task<IActionResult> PostFlight(Flight flight, int id)
    {
        try
        {
            return Ok(await _flightService.PostFlight(flight, id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    /// <summary>
    /// UpdateFlight refreshed data of chosen flight by id 
    /// </summary>
    /// <param name="flight"></param>
    /// <param name="id"></param>
    /// <returns>a updated list </returns>

   

    [HttpPut("update", Name = "UpdateFlight")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    public async Task<ActionResult<List<Flight>>> UpdateFlights(string aviaName, int Id, int passId, string type)
    {
        try
        {
            var res = await _flightService.UpdateFlight(aviaName, Id, passId, type);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }


    /// <summary>
    /// GetNumberOfFlights delivers the number of flights you requested 
    /// </summary>
    /// <param name="numberOfFlights"></param>
    /// <returns>list </returns>

    // HTTP GET метод, обрабатывающий запрос на получение определенного количества авиарейсов.
    // Принимает параметр numberOfFlights, указывающий необходимое количество авиарейсов.

    [HttpGet("quantity", Name = "GetCurtainNumberOfFlights")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    public async Task<ActionResult<List<Flight>>> GetNumberOfFlights(int numberOfFlights)
    {
        try
        {
            if (numberOfFlights == 0) throw new Exception(" number of Flights mustn't be equal to 0");
            var res = await _flightService.GetNumberOfFlights(numberOfFlights) ?? throw new Exception("nothing is found");
            return Ok(res);
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


    


    // Метод действия обрабатывает HTTP POST запрос по маршруту "delete/{flightId}" для удаления авиарейса по его идентификатору.
    // Принимает flightId в качестве параметра, представляющего уникальный идентификатор авиарейса.

    [HttpDelete("delete/{flightId}")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    public ActionResult<List<Flight>> DeleteFlight(int flightId)
    {
        try
        {
            var res = _flightService.DeleteFlight(flightId);
            Console.WriteLine(res);
            return Ok($" flight with the {flightId} has been deleted");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

   


    









   

}
