using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using usingFilters.Services;

namespace usingFilters.Filters
{
    public class IsExistsFilter : IActionFilter
    {
        private readonly IProductService _productService;
        public IsExistsFilter(IProductService productService)
        {
            _productService = productService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey("id"))
            {
                if (context.ActionArguments["id"] is int id)
                {
                    if (!_productService.IsExist(id))
                    {
                        context.Result = new NotFoundObjectResult(new { message=$"{id} id'li ürün veritabanında yok!"  });
                    }
                }

            }
        }
    }
}
