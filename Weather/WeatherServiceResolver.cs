using System;
using Demo.KeyedServices.Weather.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.KeyedServices.Weather;

public sealed class WeatherServiceResolver(IServiceProvider serviceProvider)
{
    public IWeatherService Resolve(TempUnit unit) => serviceProvider.GetRequiredKeyedService<IWeatherService>(unit);
}

// An alternative implementation using generic base class.
public sealed class WeatherServiceResolverWithGenericBase(IServiceProvider serviceProvider)
    : AbstractServiceResolver<TempUnit, IWeatherService>(serviceProvider);

// This could be the base class for all Resolver implementations.
public abstract class AbstractServiceResolver<TKey, TResult>(IServiceProvider serviceProvider)
    where TResult : notnull
{
    public TResult Resolve(TKey key) => serviceProvider.GetRequiredKeyedService<TResult>(key);
}