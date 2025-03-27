using System.Diagnostics;
using CachingMechanism.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Caching.Memory;

namespace CachingMechanism.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public IActionResult Index()
        {
          var options = new MemoryCacheEntryOptions();
            //TTL (Time to Live) - Cache'te ne kadar süre kalacağını belirler:"
            //sadece birini kullanabiliriz:
            options.AbsoluteExpiration = DateTime.Now.AddSeconds(60);
            //options.SlidingExpiration = TimeSpan.FromSeconds(30);
            //Cache'ten veri silindiğinde çalışacak metot
            //öncelik belirleme:
            //options.SetPriority





            options.PostEvictionCallbacks.Add(new PostEvictionCallbackRegistration
            {
                EvictionCallback = (key, value, reason, state) =>
                {
                    
                    _logger.LogInformation($"Cache entry was removed. Reason: {reason}");
                }
            });
            //Eğer cache'te veri yoksa cache'e ekleyip döndür (Lazy initialization)
            if (!_cache.TryGetValue("Employees", out List<Employee> employees))
            {
                employees = new List<Employee>
                {
                    new Employee { Id = 1, Name = "Ahmet", Department = "IT" },
                    new Employee { Id = 2, Name = "Mehmet", Department = "HR" },
                    new Employee { Id = 3, Name = "Ayşe", Department = "IT" },
                    new Employee { Id = 4, Name = "Fatma", Department = "HR" }
                };


                _cache.Set("Employees", employees, TimeSpan.FromSeconds(60));
            }

            ViewBag.Employees = employees;
            return View();
        }

        public IActionResult Privacy()
        {
            var employees = _cache.Get<List<Employee>>("Employees");
            ViewBag.Employees = employees;
            return View();
        }

        
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        [HttpGet("api/employees/{id}")]
        public IActionResult Get(int id)
        {
            var employee = new Employee
            {
                Id = id,
                Name = "Türkay",
                Department = "Finans"
            };

            return Ok(new { data = employee, DateInfo = DateTime.Now });
        }

        public IActionResult CacheHelper(int? id)
        {
            Employee employee = null;
            if (id.HasValue)
            {
                employee = new Employee
                {
                    Id = id.Value,
                    Name = "Ayşe",
                    Department = "Yazılım"
                };
            }
            else
            {
                employee = new Employee
                {
                    Id = 5,
                    Name = "Türkay",
                    Department = "Finans"
                };
            }


            return View(employee);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
