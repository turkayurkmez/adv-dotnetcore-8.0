using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usingFilters.Filters;
using usingFilters.Services;

namespace usingFilters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [IsExists]
        public IActionResult GetProduct(int id)
        {
            //if (!_productService.IsExist(id))
            //{
            //    return NotFound();
            //}
            return Ok(_productService.GetProducts().FirstOrDefault(x => x.Id == id));
        }

        [HttpPut("{id}")]
        [IsExists]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            //if (!_productService.IsExist(id))
            //{
            //    return NotFound();
            //}
            var productToUpdate = _productService.GetProducts().FirstOrDefault(x => x.Id == id);
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            return Ok(productToUpdate);
        }

        [HttpDelete("{id}")]
        [IsExists]
        public IActionResult DeleteProduct(int id)
        {
            //if (!_productService.IsExist(id))
            //{
            //    return NotFound();
            //}
            var productToDelete = _productService.GetProducts().FirstOrDefault(x => x.Id == id);
            //_productService.GetProducts().Remove(productToDelete);
            return Ok();
        }
    }
}
