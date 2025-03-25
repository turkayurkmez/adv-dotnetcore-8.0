using Catalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services
{
    public interface IProductService
    {
        /*
         * Yeni ürün ekler.
         * Ada göre ürün arar.
         * Id'ye göre ürün bulur.
         * 
         * Kategoriye göre ürünleri listeler.
         * 
         * 
         */

        Task CreateNewProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<Product> GetProductByName(string name);
        Task<List<Product>> GetProductsByCategory(int categoryId);

        Task<bool> IsAvailable(int categoryId);
        Task<bool> IsProductActive(int id);

    }
}
