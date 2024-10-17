using Demo.KeyedServices.Weather;
using Demo.KeyedServices.Weather.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
    
builder.Services.AddKeyedScoped<IWeatherService, CelsiusWeatherService>(TempUnit.Celsius);
builder.Services.AddKeyedScoped<IWeatherService, FahrenheitWeatherService>(TempUnit.Fahrenheit);

builder.Services.AddScoped<WeatherServiceResolver>();

builder.Services.AddHttpClient<IWeatherService, FahrenheitWeatherService>();

var app = builder.Build();

app.MapGet("/weatherForecast/{unit}", (
    [FromRoute] TempUnit unit,
    [FromServices] WeatherServiceResolver resolver) =>
{
    var weatherService = resolver.Resolve(unit);
    return weatherService.GetForecast();
});

// The other, less flexible way, to resolve keyed services, useless for this demo.
app.MapGet("/weatherForecast-C", (
    [FromKeyedServices(TempUnit.Celsius)] IWeatherService weatherService) => weatherService.GetForecast());

app.Run();