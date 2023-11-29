using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace PwC.Kurs.FooBar;

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public interface IWeatherService
{
    IEnumerable<WeatherForecast> Get();
}


public static class WeatherServiceExtension
{
    public static IServiceCollection AddWeatherServices(this IServiceCollection services)
    {
        services.AddSingleton<IWeatherService, WeatherServiceDummy>();

        return services;
    }
}  

file class WeatherServiceDummy : IWeatherService
{
    private readonly ILogger<WeatherServiceDummy> _logger;
    private static readonly string[] Summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    public WeatherServiceDummy(ILogger<WeatherServiceDummy> logger)
    {
        _logger = logger;
        _logger.LogInformation("created service");
    }

    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("dot");
        return Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    Summaries[Random.Shared.Next(Summaries.Length)]
                ));
    }
}