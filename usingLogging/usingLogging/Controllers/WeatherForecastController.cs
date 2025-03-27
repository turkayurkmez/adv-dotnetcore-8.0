using Microsoft.AspNetCore.Mvc;

namespace usingLogging.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("*** Get request talebi geldi... *****");
            try
            {
                _logger.LogDebug("Hava durumunu çekme işlemi başladı....");
                var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToArray();
                _logger.LogInformation("*** Başarıyla veri çekildi *****");
                return weatherForecasts;

            }
            catch (Exception ex)
            {
                _logger.LogError("Hata oluştu", ex.Message);
                throw;
                
            }


        }
    }
}
