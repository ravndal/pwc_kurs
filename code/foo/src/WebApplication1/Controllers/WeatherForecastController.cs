using Microsoft.AspNetCore.Mvc;
using PwC.Kurs.FooBar;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(IWeatherService weatherService)
        {
              _weatherService = weatherService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
            => _weatherService.Get();
        

        //[HttpGet(Name = "GetWeatherForecast2")]
        //public IEnumerable<WeatherForecast> Get2([FromServices] WeatherService weatherService)
        //{
        //    return weatherService.Get();
        //}
    }
}
