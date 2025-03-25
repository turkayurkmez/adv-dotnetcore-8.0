using Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.DataContext
{
    internal class SampleCatalogDbContext : DbContext
    {
        public SampleCatalogDbContext(DbContextOptions<SampleCatalogDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p=>p.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().Property(p => p.Stock).HasDefaultValue(0);

            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId);

            //seed data
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Electronics" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "Clothing" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Name = "Accessories" });

            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, Name = "Iphone 12", Price = 10000, Stock = 100, CategoryId = 1 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 2, Name = "Samsung S21", Price = 9000, Stock = 100, CategoryId = 1 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 3, Name = "Xiaomi Mi 11", Price = 8000, Stock = 100, CategoryId = 1 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 4, Name = "T-shirt", Price = 100, Stock = 100, CategoryId = 2 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 5, Name = "Polo neck", Price = 150, Stock = 100, CategoryId = 2 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 6, Name = "Shirt", Price = 200, Stock = 100, CategoryId = 2 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 7, Name = "Watch", Price = 500, Stock = 100, CategoryId = 3 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 8, Name = "Necklace", Price = 300, Stock = 100, CategoryId = 3 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 9, Name = "Earrings", Price = 200, Stock = 100, CategoryId = 3 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 10, Name = "Bracelet", Price = 150, Stock = 100, CategoryId = 3 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 11, Name = "Hat", Price = 50, Stock = 100, CategoryId = 3 });

        }
    }
}
