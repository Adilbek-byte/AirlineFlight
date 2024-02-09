using Microsoft.AspNetCore.Mvc;

namespace AirlineFlight;

public class WeatherForecast
{
    

    public string? Weather { get; set; } = WeatherForecast.WeatherCondition();
    public  string? TemperatureC { get; set; } = $"{WeatherForecast.Forecast()} °C";
    public string TemperatureF => $"{32 + (int)((int.Parse(string.Concat(TemperatureC!.Where(char.IsDigit)))) / 0.556)} °F";

    public static int Forecast() => Random.Shared.Next(-1, 36);
    
    


    public static string WeatherCondition()
    {
       
        string[] forecasts = { "rainy", "sunny", "windy", "foggy", "snowy", "cloudy" };
        return forecasts[Random.Shared.Next(forecasts.Length)];
    }


}
