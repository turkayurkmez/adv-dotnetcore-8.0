using Microsoft.AspNetCore.Mvc;
using OptionsPattern.Services;

namespace OptionsPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly MailService _mailService;
        private readonly ConfigAwareService _configAwareService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, MailService mailService, ConfigAwareService configAwareService)
        {
            _logger = logger;
            _mailService = mailService;
            _configAwareService = configAwareService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _mailService.Send("to", "subject", "body");
            _configAwareService.Send("to", "subject", "body");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
