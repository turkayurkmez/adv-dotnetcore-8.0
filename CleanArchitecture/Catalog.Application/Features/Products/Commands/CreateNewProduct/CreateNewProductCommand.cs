using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.Commands.CreateNewProduct
{
    public record CreateNewProductCommand(string Name, string? Description, decimal Price, int? CategoryId, int? Stock) : IRequest<CreateNewProductCommandResponse>;

    public record CreateNewProductCommandResponse(int Id);


}
