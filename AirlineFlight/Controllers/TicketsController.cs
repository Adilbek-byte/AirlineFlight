using AirlineFlight.Helper;
using Microsoft.AspNetCore.Mvc;
using AirlineFlight.DataBase;
using AirlineFlight.Services.Interfaces;

namespace AirlineFlight.Controllers;

[ApiController]
[Route("tickets")]
public class TicketsController: ControllerBase
{
    private readonly IFlightService _flightService;
    private readonly FlightDb _context;
    public TicketsController(IFlightService flightService, FlightDb context) {
        _flightService = flightService;
        _context = context;
    }

   

    /// <summary>
    /// GetPassenger allows the user to add the quantity of Adults and children then
    /// it'll sum up and give you totalSum 
    /// </summary>
    /// <param name="numOfPassenger"></param>
    /// <param name="typeOfPassenger"></param>
    /// <param name="direction"></param>
    /// <returns> a list with updated data </returns>



    

    [HttpGet("purchase-ticket", Name = "GetInfoPassengers")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    public async Task<ActionResult<List<Flight>>> GetPassengerTicket(int numOfPassenger, string typeOfPassenger, string direction)
    {
        try { 
        var res = await _flightService.GetPassengerTicket(numOfPassenger, typeOfPassenger, direction);

            var output = InputHelper.GetPassengerHelper(res, typeOfPassenger, numOfPassenger);
            Console.WriteLine(output);
            return Ok(res);
        }
        catch (Exception ex)
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




    [HttpDelete ("refund-ticket", Name = "GetOutPassengers")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    public async Task <ActionResult<List<Flight>>> GetPassengerOut(int numOfPassenger, string typeOfPassenger, string direction)
    {
        try
        {
            var res = await _flightService.GetPassengerTicket(numOfPassenger, typeOfPassenger, direction);
            var output = InputHelper.GetPassengerOutHelper(res, typeOfPassenger, numOfPassenger);
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

    [HttpGet("bonus")]
    public async Task<IActionResult> GetBonus()
    {
        try
        { 
            var bonus = await _flightService.GetBonus();
            
            return Ok(bonus);
        }
        catch
        {
            return BadRequest("there is something going wrong");
        }
    }
}
            