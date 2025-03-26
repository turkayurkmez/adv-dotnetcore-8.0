using Catalog.Domain;
using Catalog.Domain.Contracts;
using Catalog.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository(SampleCatalogDbContext dbContext) : IProductRepository
    {

        public async Task AddAsync(Product entity)
        {
            await dbContext.Products.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await dbContext.Products.FindAsync(id);
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await dbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await dbContext.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            return await dbContext.Products.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            dbContext.Products.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
