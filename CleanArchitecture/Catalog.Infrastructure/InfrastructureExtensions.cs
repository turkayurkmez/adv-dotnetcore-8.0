using Catalog.Domain.Contracts;
using Catalog.Infrastructure.DataContext;
using Catalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure
{
    public static  class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddDbContext<SampleCatalogDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
