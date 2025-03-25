using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.Queries.GetAllProducts
{
    public  record GetAllProductsQuery() : IRequest<GetAllProductsQueryResponse>;

    public record GetAllProductsQueryResponse(IEnumerable<ProductForGetAll> Products, int Count);
    

    public record ProductForGetAll(int Id, string Name, string? Description, decimal Price, int? CategoryId, int? Stock);
    //public record GetAllWithDetail (IEnumerable<ProductForGetAll> Products, int Count);

}
