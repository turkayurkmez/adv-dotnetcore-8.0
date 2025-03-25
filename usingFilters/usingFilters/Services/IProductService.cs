using System.ComponentModel.DataAnnotations;

namespace usingFilters.Services
{
    public interface IProductService
    {
        bool IsExist(int id);
        IEnumerable<Product> GetProducts();
    }

    public class ProductService : IProductService
    {
        private List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Kalem", Price = 100 },
            new Product { Id = 2, Name = "Silgi", Price = 200 },
            new Product { Id = 3, Name = "Defter", Price = 300 }
        };
        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
        public bool IsExist(int id)
        {
            return _products.Any(x => x.Id == id);
        }
    }
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ürün adı boş olamaz")]
        [MaxLength(50, ErrorMessage = "Ürün adı 50 karakterden fazla olamaz")]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
