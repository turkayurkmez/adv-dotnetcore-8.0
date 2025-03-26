using Catalog.Domain.Contracts;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler(IProductRepository repository) : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResponse>
    {
        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
           var product = await repository.GetByIdAsync(request.Id);
            return product.Adapt<GetProductByIdQueryResponse>();
        }
    }
}
