using Microsoft.AspNetCore.Mvc;

namespace AirlineFlight;

public class WeatherForecast
{

    private static readonly int temperatureC = WeatherForecast.Forecast();

    public string? Weather { get; set; } = WeatherForecast.WeatherCondition();
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
