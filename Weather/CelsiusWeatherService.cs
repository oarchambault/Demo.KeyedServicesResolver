using System;
using Demo.KeyedServices.Weather.Models;
using Microsoft.Extensions.Logging;

namespace Demo.KeyedServices.Weather;

public class CelsiusWeatherService(ILogger<CelsiusWeatherService> logger) : IWeatherService
{
    public WeatherForecast GetForecast()
    {
        logger.LogInformation($"{nameof(CelsiusWeatherService)} providing forecast in Celsius.");
        return new WeatherForecast(
            DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
            Random.Shared.Next(-20, 55),
            TempUnit.Celsius,
            IWeatherService.Summaries[Random.Shared.Next(IWeatherService.Summaries.Length)]
        );
    }
}