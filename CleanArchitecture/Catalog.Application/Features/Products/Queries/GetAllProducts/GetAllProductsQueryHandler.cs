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
        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync();
            var productsForGetAll = products.Adapt<IEnumerable<ProductForGetAll>>();

            var response = new GetAllProductsQueryResponse(Products: productsForGetAll, Count: productsForGetAll.Count());

            return response;


        }
    }
}
