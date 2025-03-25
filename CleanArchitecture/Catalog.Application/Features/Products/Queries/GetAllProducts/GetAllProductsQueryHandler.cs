using Catalog.Domain.Contracts;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, GetAllProductsQueryResponse>
    {
        public Task<GetAllProductsQueryResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = productRepository.GetAllAsync().Result;
            var productsForGetAll = products.Adapt<IEnumerable<ProductForGetAll>>();

            var response = new GetAllProductsQueryResponse(Products: productsForGetAll, Count: productsForGetAll.Count());

            return Task.FromResult(response);


        }
    }
}
