using Catalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services
{
    public class ProductService : IProductService
    {
        public Task CreateNewProduct(Product product)
        {
            throw new NotImplementedException();

        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsAvailable(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsProductActive(int id)
        {
            throw new NotImplementedException();
        }
    }
}
