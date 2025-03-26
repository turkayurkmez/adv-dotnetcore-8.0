using Catalog.Domain;
using Catalog.Domain.Contracts;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


            //Eğer otomatik validasyon yapılmasını istemeseydik aşağıdaki kodlar ile validasyon yapacaktık.

            //CreateNewProductCommandValidator validator = new();
            //var validationResult = await validator.ValidateAsync(request);

            ////throw exception:
            //if (!validationResult.IsValid)
            //{
            //    throw new ValidationException(string.Join(", ", validationResult.Errors));
            //}







            var product = request.Adapt<Product>();
           await productRepository.AddAsync(product);
            return new CreateNewProductCommandResponse(product.Id);
        }
    }

}
