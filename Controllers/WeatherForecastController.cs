using Microsoft.AspNetCore.Mvc;

using WeatherForecastApi.Models;

namespace WeatherForecastApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private enum Summaries 
        { 
            None = 0,
            Cold,
            Warm,
            Hot
        }

        private Summaries GetSummaryBasedOnTemperature(int temperature)
        {
            if (temperature >= 0 && temperature <= 10)
                return Summaries.Cold;
            else if (temperature >= 11 && temperature <= 20)
                return Summaries.Warm;
            else if (temperature >= 21 && temperature <= 30)
                return Summaries.Hot;

            return Summaries.None;
        }

        [HttpGet]
        public IEnumerable<WeatherForecastClass> Get()
        {
            var rng = new Random();
            return Enumerable.Range(0, 5).Select(index =>
            {
                var temperatureC = rng.Next(0, 31); 
                return new WeatherForecastClass
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = temperatureC,
                    Summary = GetSummaryBasedOnTemperature(temperatureC).ToString()
                };
            })
            .ToArray();
        }
    }
}
