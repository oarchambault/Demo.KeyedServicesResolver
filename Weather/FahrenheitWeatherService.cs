using System;
using Demo.KeyedServices.Weather.Models;
using Microsoft.Extensions.Logging;

namespace Demo.KeyedServices.Weather;

public class FahrenheitWeatherService(ILogger<FahrenheitWeatherService> logger) : IWeatherService
{
    public WeatherForecast GetForecast()
    {
        logger.LogInformation($"{nameof(FahrenheitWeatherService)} providing forecast in Fahrenheit.");
        return new WeatherForecast(
            DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
            Random.Shared.Next(-4, 131),
            TempUnit.Fahrenheit,
            IWeatherService.Summaries[Random.Shared.Next(IWeatherService.Summaries.Length)]
        );
    }
}