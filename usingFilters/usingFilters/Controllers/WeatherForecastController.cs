using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using usingFilters.Filters;
using usingFilters.Services;

namespace usingFilters.Controllers
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
        private readonly IProductService _productService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize]

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

        [HttpGet("sample")]
        [OutOf]
        [PerformanceTracker]
        public IActionResult Sample(int min)
        {
            Thread.Sleep(1500);
            if (min < 0)
            {
                throw new ArgumentOutOfRangeException(paramName:nameof(min),message: $"{nameof(min)} parametesi 0'dan küçük olamaz.");
            }
            return Ok(new ModelInfo() { Items = new List<string>() { "A","B","C"} });

        }
        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

    }
}
