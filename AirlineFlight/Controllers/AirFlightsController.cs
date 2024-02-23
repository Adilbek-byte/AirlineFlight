using AirlineFlight.DataBase;
using AirlineFlight.Helper;
using AirlineFlight.Models;
using AirlineFlight.Services;
using AirlineFlight.Services.Interfaces;
using AirlineFlightl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Net.WebSockets;

namespace AirlineFlight.Controllers;
// Атрибут [ApiController] указывает, что этот класс является контроллером API и включает в себя дополнительные функциональные возможности.
// Атрибут [Route("flights")] определяет базовый маршрут для всех действий в контроллере, в данном случае - "flights".
[ApiController]
[Route("flights")]

// Класс AirFlightsController представляет контроллер для обработки HTTP запросов, связанных с авиарейсами.
// Наследуется от ControllerBase.
public class AirFlightsController : ControllerBase
{
    private readonly FlightDb _contextDb;
    private readonly IFlightService _flightService;
    // list named planes stores all the data 
    public static List<Flight> planes = AirFlights.CreateFlights();

    public AirFlightsController(FlightDb contextDb, IFlightService flightService)
    {
        _contextDb = contextDb;
        _flightService = flightService;
    }



    /// <summary>
    /// GetFlights displays the data
    /// </summary>
    /// <returns>the data on browser in the form of Json format</returns>

    // HTTP GET метод, обрабатывающий запрос на получение списка авиарейсов.
    // Использует асинхронный метод GetFlightsAsync() из сервиса _flightservice для получения данных.

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

    // HTTP GET метод, обрабатывающий запрос на получение списка направлений авиарейсов.
    // Использует асинхронный метод GetDirectionAsync() для получения данных.

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



    // HTTP POST метод, обрабатывающий запрос на добавление нового авиарейса.
    // Принимает объект Flight и уникальный идентификатор id в качестве параметров.
    // Использует асинхронный метод PostFlightAsync() для выполнения операции.
    // Возвращает HTTP статус 200 (OK) с обновленным списком авиарейсов в ответе.
    // В случае уже существующего id возвращает HTTP статус 400 с сообщением об ошибке.
    // В случае других ошибок возвращает HTTP статус 500 с сообщением об ошибке.


    [HttpPost(Name = "PostNewFlight")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    [ProducesResponseType(500, Type = typeof(string))]

    public async Task<IActionResult> PostFlight(FlightEntity flight, int id)
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

    // HTTP GET метод, обрабатывающий запрос на обновление информации об авиарейсе по идентификатору.
    // Принимает параметры: объект Flight с обновленной информацией и уникальный идентификатор id.
    // Возвращает HTTP статус 200 (OK) с обновленным списком авиарейсов в ответе.
    // В случае отсутствия указанного id возвращает HTTP статус 400 и сообщение об ошибке.

    [HttpPut("update", Name = "UpdateFlight")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    public ActionResult<List<Flight>> UpdateFlight([FromQuery] Flight flight, int id)
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
        await Task.Delay(1000);
        List<Flight> result = new List<Flight>();
        try
        {
            if (numberOfFlights < 0)
                throw new Exception("The entered number should not be less than 0");
            else if (numberOfFlights > planes.Count) throw new Exception(" number out of scope");

            for (int i = 0; i < numberOfFlights && i < planes.Count; i++)
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
    /// SetUpNewFlight inspects if any flights with the requested id exist or not if not 
    /// it creates a new one with the id 
    /// </summary>
    /// <param name="flight"></param>
    /// <param name="id"></param>
    /// <returns></returns>
   



    // Метод действия обрабатывает HTTP POST запрос по маршруту "{id}" и создает новый авиарейс с указанным идентификатором.
    // Принимает объект Flight и уникальный идентификатор id в качестве параметров.
    // После задержки в 1000 миллисекунд для имитации асинхронной операции выполняет следующие действия:
    // Проверяет, существует ли уже авиарейс с указанным идентификатором в списке planes.
    // Если авиарейс с таким id уже существует, выбрасывается исключение с сообщением "flight with the provided id already exists".



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


    


    // Метод действия обрабатывает HTTP POST запрос по маршруту "delete/{flightId}" для удаления авиарейса по его идентификатору.
    // Принимает flightId в качестве параметра, представляющего уникальный идентификатор авиарейса.

    [HttpDelete("delete/{flightId}")]
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
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

   


    









   

}
