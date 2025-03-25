using Catalog.Domain;
using Catalog.Domain.Contracts;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.Commands.CreateNewProduct
{
    public class CreateNewProductCommandHandler(IProductRepository productRepository) : IRequestHandler<CreateNewProductCommand, CreateNewProductCommandResponse>
    {
        public Task<CreateNewProductCommandResponse> Handle(CreateNewProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Product>();
            productRepository.AddAsync(product);
            return Task.FromResult(new CreateNewProductCommandResponse(product.Id));
        }
    }

}
