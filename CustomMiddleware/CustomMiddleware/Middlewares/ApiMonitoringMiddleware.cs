using Microsoft.Extensions.Options;
using Microsoft.IO;
using System.Diagnostics;

namespace CustomMiddleware.Middlewares
{
    public class ApiMonitoringMiddleware
    {
        //bir sonraki middleware'ı temsil eder
        private readonly RequestDelegate _next;
        private readonly ApiMonitoringOption _option;
        private readonly ILogger<ApiMonitoringMiddleware> _logger;

        private readonly RecyclableMemoryStreamManager _memoryStreamManager;

        public ApiMonitoringMiddleware(RequestDelegate next, IOptions<ApiMonitoringOption> option, ILogger<ApiMonitoringMiddleware> logger)
        {
            _next = next;
            _option = option.Value;
            _logger = logger;
            _memoryStreamManager = new RecyclableMemoryStreamManager();
        }

        //Invoke metodu middleware'ın çalıştığı yerdir
        public async Task InvokeAsync(HttpContext context)
        {
            var requestTime = DateTime.Now;
            var stopwatch = Stopwatch.StartNew();
            var originalBody = context.Request.Body;
            var requestBodyContent = string.Empty;

            if (_option.LogRequestBody && context.Request.ContentLength > 0)
            {
                await using var requestBodyStream = _memoryStreamManager.GetStream();
                await context.Request.Body.CopyToAsync(requestBodyStream);
                requestBodyStream.Seek(0, SeekOrigin.Begin);

                using var streamReader = new StreamReader(requestBodyStream);
                requestBodyContent = await streamReader.ReadToEndAsync();
                
                //request body'sini tekrar okuyabilmek için stream'i başa alıyoruz
                requestBodyStream.Seek(0, SeekOrigin.Begin);
                //DİKKAT:
                context.Request.Body = requestBodyStream;


            }

            var originalResponseBody = context.Response.Body;
            await using var responseBodyStream = _memoryStreamManager.GetStream();
            context.Response.Body = responseBodyStream;

            try
            {
                await _next(context);

                stopwatch.Stop();
                responseBodyStream.Seek(0, SeekOrigin.Begin);
                var responseBodyContent = await new StreamReader(responseBodyStream).ReadToEndAsync();
                responseBodyStream.Seek(0, SeekOrigin.Begin);
                await responseBodyStream.CopyToAsync(originalResponseBody);

                var elapsed = stopwatch.ElapsedMilliseconds;
                var statusCode = context.Response.StatusCode;

               LogApiMetrics(context, requestTime, elapsed, statusCode, requestBodyContent, _option.LogResponseBody ? requestBodyContent : null, responseBodyContent);
               // context.Request.Body.
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LogApiMetrics(HttpContext context, DateTime requestTime, long elapsed, int statusCode, string requestBodyContent, string? requestBody, string? responseBody)
        {
           
        }
    }
}
