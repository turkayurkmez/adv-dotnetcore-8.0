using dotnetWithDocker.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnetWithDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SampleDbContext _context;

        public ProductsController(SampleDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }
    }
}
