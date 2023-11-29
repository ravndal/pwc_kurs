
using PwC.Kurs.FooBar;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddSingleton<IWeatherService, RandomWeatherService>()
    .AddSwaggerGen();
    


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", (IWeatherService weatherService) 
        => weatherService.Get())
    
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();


public class RandomWeatherService : IWeatherService
{
    public IEnumerable<WeatherForecast> Get()
    {
        var list = new List<WeatherForecast>();
        list.Add(new WeatherForecast(DateOnly.FromDateTime(DateTime.Now), 0, "foo"));
        return list;
    }
}