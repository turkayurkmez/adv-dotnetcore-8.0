using dotnetWithDocker.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetWithDocker.DataContext
{
    public class SampleDbContext : DbContext
    {
        public DbSet<Product>   Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothes" },
                new Category { Id = 3, Name = "Books" }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Description="Description of Laptop", Price = 1000, CategoryId = 1 },
                new Product { Id = 2, Name = "T-Shirt", Description= "Description of Tiört", Price = 20, CategoryId = 2 },
                new Product { Id = 3, Name = "Book", Price = 10, Description= "Description of Kitap", CategoryId = 3 }
            );
        }
    }
}
