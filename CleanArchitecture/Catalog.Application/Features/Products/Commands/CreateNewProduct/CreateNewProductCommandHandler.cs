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
        public async Task<CreateNewProductCommandResponse> Handle(CreateNewProductCommand request, CancellationToken cancellationToken)
        {
            //validate request with FluentValidation:






            var product = request.Adapt<Product>();
           await productRepository.AddAsync(product);
            return new CreateNewProductCommandResponse(product.Id);
        }
    }

}
