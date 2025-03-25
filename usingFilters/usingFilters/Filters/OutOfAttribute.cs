using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace usingFilters.Filters
{
    public class OutOfAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {

            if (context.Exception is ArgumentOutOfRangeException)
            {
                var outputMessage = new ObjectResult(new
                {
                    message = "Gönderilen parametreler hatalıdır.",
                    status = 400,
                    detail = context.Exception.Message
                })
                { StatusCode = StatusCodes.Status400BadRequest};

                context.Result = outputMessage;


            }

        }
    }
}
