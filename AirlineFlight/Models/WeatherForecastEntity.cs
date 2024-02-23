using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AirlineFlight;

public class WeatherForecastEntity
{
    [Key]
    public int WeatherId { get; set; }
    private static readonly int temperatureC = WeatherForecastEntity.Forecast();

    public string? Weather { get; set; } = WeatherForecastEntity.WeatherCondition();
    public  string? TemperatureC { get; set; } = $"{temperatureC} °C";
    public string TemperatureF => $"{32 + (int)(temperatureC / 0.556)} °F";

    public static int Forecast() => Random.Shared.Next(-1, 36);
    
    
    /// <summary>
    /// WeatherCondition shuffles an array of elements 
    /// </summary>
    /// <returns>string by index </returns>

    public static string WeatherCondition()
    {
       
        string[] forecasts = { "rainy", "sunny", "windy", "foggy", "snowy", "cloudy" };
        return forecasts[Random.Shared.Next(forecasts.Length)];
    }


}
