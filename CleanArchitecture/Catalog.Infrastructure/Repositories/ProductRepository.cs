using Catalog.Domain;
using Catalog.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {

        public Task<Product> AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
