using System;
using System.Text.Json.Serialization;

namespace Demo.KeyedServices.Weather.Models;

public sealed record WeatherForecast(
    DateOnly Date,
    int Temperature,
    [property: JsonConverter(typeof(JsonStringEnumConverter))]
    TempUnit Unit,
    string? Summary);