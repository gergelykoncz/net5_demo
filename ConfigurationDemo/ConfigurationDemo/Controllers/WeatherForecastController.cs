using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration configuration;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            ForecastConfig config = this.configuration.GetSection("Forecast").Get<ForecastConfig>();

            var rng = new Random();

            return Enumerable.Range(1, 5).Select(index => CreateForecast(config, index, rng));
        }

        private WeatherForecast CreateForecast(ForecastConfig config, int index, Random rng)
        {
            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                Temperature = rng.Next(config.MinTemp, config.MaxTemp),
                Unit = config.Unit,
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }
    }
}
