using AirlineFlight.Helper;
using AirlineFlight.Models;
using AirlineFlight.Services;
using Microsoft.AspNetCore.Mvc;
using AirlineFlightl;
namespace AirlineFlight.Controllers;

[ApiController]
[Route("tickets")]
public class TicketsController: ControllerBase
{
    private readonly FlightService _flightService;
    public TicketsController(FlightService flightService) {
        _flightService = flightService;
    }

    public static List<Flight> planes = AirFlights.CreateFlights();

    /// <summary>
    /// GetPassenger allows the user to add the quantity of Adults and children then
    /// it'll sum up and give you totalSum 
    /// </summary>
    /// <param name="numOfPassenger"></param>
    /// <param name="typeOfPassenger"></param>
    /// <param name="direction"></param>
    /// <returns> a list with updated data </returns>



    // HTTP GET метод, обрабатывающий запрос на получение информации о доступных авиарейсах в зависимости от параметров пассажиров.
    // Принимает параметры: numOfPassenger - количество пассажиров, typeOfPassenger - категория пассажиров, direction - направление.

    [HttpGet("purchase-ticket", Name = "GetInfoPassengers")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    public ActionResult<List<Flight>> GetPassenger(int numOfPassenger, string typeOfPassenger, string direction)
    {
        var res = planes.Where(t => t.Direction?.ToWhere == direction).ToList();
        try
        {
            if (numOfPassenger <= 0) throw new Exception("the number of passengers should not be less or eqqual to zero! ");
            if (res.Count == 0) throw new Exception("such a location is not found");
            if (!Enum.TryParse<TypeOfPricesEntity.Category>(typeOfPassenger, out var category)) throw new Exception("Invalid passenger category");

            var output = InputHelper.getPassengerHelper(res, typeOfPassenger, numOfPassenger);
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


    // Метод действия обрабатывает HTTP GET запрос по маршруту "ById/{id}" и возвращает авиарейс(ы) по указанному идентификатору.
    // Принимает уникальный идентификатор id в качестве параметра.    
    // Ищет авиарейс(ы) с указанным идентификатором в списке planes.


    [HttpGet ("refund-ticket", Name = "GetOutPassengers")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    public ActionResult<List<Flight>> GetPassengerOut(int numOfPassenger, string typeOfPassenger, string direction)
    {
        var res = planes.Where(t => t.Direction?.ToWhere == direction).ToList();
        try
        {
            if (numOfPassenger <= 0) throw new Exception("the number of passengers should not be less or eqqual to zero! ");
            if (res.Count == 0) throw new Exception("such a location is not found");
            if (!Enum.TryParse<TypeOfPricesEntity.Category>(typeOfPassenger, out var category)) throw new Exception("Invalid passenger category");

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

    [HttpGet("bonus")]
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
        catch
        {
            return BadRequest("there is something going wrong");
        }
    }
}
