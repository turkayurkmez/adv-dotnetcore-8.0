using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace usingFilters.Filters
{
    public class PerformanceTrackerAttribute : ActionFilterAttribute
    {
        private Stopwatch _stopwatch;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();




        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            var elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;

            if (context.Result != null)
            {
                var okResult = (OkObjectResult)context.Result;
                var info = (ModelInfo)okResult.Value;
                info.ResultMessage += $"Bu işlem {elapsedMilliseconds} ms sürdü.";

                //context.Result = new OkObjectResult(info);
            }


          
            

            // loglama işlemleri
        }
    }
}
