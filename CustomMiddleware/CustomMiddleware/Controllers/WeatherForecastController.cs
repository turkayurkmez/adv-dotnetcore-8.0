using Microsoft.AspNetCore.Mvc;

namespace CustomMiddleware.Controllers
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
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Test1")]
        public IActionResult Test1()
        {
            
            var sampleProducts = new List<Product>();
            for (int i = 1; i < 2000; i++)
            {
                sampleProducts.Add(new() { Id = i, Name = $"Ürün {i} ", Price = i * 100 });
            }

           
            return Ok(sampleProducts);
        }

        [HttpGet("notfound")]
        public IActionResult Test3()
        {
            return NotFound();
        }
    }
}
