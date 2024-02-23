using AirlineFlight.DataBase;
using AirlineFlight.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineFlight.Controllers;

public class HotFlightController: ControllerBase
{
    private readonly FlightDb _contextDb;
    private readonly IFlightService _flightService;
    public HotFlightController(FlightDb contextDb, IFlightService flightService)
    {
        _contextDb = contextDb;
        _flightService = flightService;
    }


    // Метод действия обрабатывает HTTP GET запрос по маршруту "hotflight".
    // Возвращает список объектов HotFlight, представляющих информацию о горячих авиабилетах.
    // В случае успешного выполнения запроса возвращается HTTP статус 200 и список HotFlight.
    // В случае ошибки возвращается HTTP статус 400 с соответствующим сообщением об ошибке.
    [HttpGet("hotflight")]
    [ProducesResponseType(200, Type = typeof(List<HotFlightEntity>))]
    [ProducesResponseType(400, Type = typeof(string))]
    public async Task<ActionResult<List<HotFlightEntity>>> HotFlightMethod()
    {
        var flights = await _contextDb.HotFlights.ToListAsync();
        return Ok(flights);
    }


}
