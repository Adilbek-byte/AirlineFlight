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
// Атрибут [ApiController] указывает, что этот класс является контроллером API и включает в себя дополнительные функциональные возможности.
// Атрибут [Route("flights")] определяет базовый маршрут для всех действий в контроллере, в данном случае - "flights".
[ApiController]
[Route("flights")]

// Класс AirFlightsController представляет контроллер для обработки HTTP запросов, связанных с авиарейсами.
// Наследуется от ControllerBase.
public class AirFlightsController : ControllerBase
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
    /// GetDirection displays all the directions 
    /// </summary>
    /// <returns>list of directions </returns>
    /// 
    [HttpGet("Direction", Name = "GetDirection")]
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

    [HttpGet("update", Name = "UpdateFlight")]
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
    /// GetPassenger allows the user to add the quantity of Adults and children then
    /// it'll sum up and give you totalSum 
    /// </summary>
    /// <param name="numOfPassenger"></param>
    /// <param name="typeOfPassenger"></param>
    /// <param name="direction"></param>
    /// <returns> a list with updated data </returns>



    // HTTP GET метод, обрабатывающий запрос на получение информации о доступных авиарейсах в зависимости от параметров пассажиров.
    // Принимает параметры: numOfPassenger - количество пассажиров, typeOfPassenger - категория пассажиров, direction - направление.

    [HttpGet("{numOfPassenger}, {typeOfPassenger}, {direction}", Name = "GetInfoPassengers")]
    [ProducesResponseType(200, Type = typeof(List<Flight>))]
    [ProducesResponseType(400, Type = typeof(string))]
    public ActionResult<List<Flight>> GetPassenger(int numOfPassenger, string typeOfPassenger, string direction)
    {
        var res = planes.Where(t => t.Direction?.ToWhere == direction).ToList();
        try
        {
            if (numOfPassenger <= 0) throw new Exception("the number of passengers should not be less or eqqual to zero! ");
            if (res.Count == 0) throw new Exception("such a location is not found");
            if (!Enum.TryParse<TypeOfPrices.Category>(typeOfPassenger, out var category)) throw new Exception("Invalid passenger category");

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
    public async Task<IActionResult> GetById(int id)
    {
        await Task.Delay(1000);
        try
        {
            var res = planes.Where(t => t.FlightId == id).ToList();
            if (res.Count == 0) throw new Exception("the id you are looking for is not found!");
            return Ok(res);
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
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    









    // Метод действия обрабатывает HTTP GET запрос по маршруту "hotflight".
    // Возвращает список объектов HotFlight, представляющих информацию о горячих авиабилетах.
    // В случае успешного выполнения запроса возвращается HTTP статус 200 и список HotFlight.
    // В случае ошибки возвращается HTTP статус 400 с соответствующим сообщением об ошибке.
    [HttpGet("hotflight")]
    [ProducesResponseType(200, Type = typeof(List<HotFlight>))]
    [ProducesResponseType(400, Type = typeof(string))]

    public ActionResult<List<HotFlight>> HotFlightMethod()
    {
        List<HotFlight> hotflight = HotFlight.CreateHotFlights();
        return Ok(hotflight);
    }

}
