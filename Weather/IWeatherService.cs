using Demo.KeyedServices.Weather.Models;

namespace Demo.KeyedServices.Weather;

public interface IWeatherService
{
    static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    WeatherForecast GetForecast();
}