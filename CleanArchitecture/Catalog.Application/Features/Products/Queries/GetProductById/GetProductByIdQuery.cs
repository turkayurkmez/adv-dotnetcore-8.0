using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(int Id) : IRequest<GetProductByIdQueryResponse>;

    public record GetProductByIdQueryResponse(int Id, string Name, string? Description, decimal Price, int? CategoryId, int? Stock);

}
