using CustomMiddleware.Middlewares;

namespace CustomMiddleware.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseApiMonitoring(this IApplicationBuilder builder, Action<ApiMonitoringOption> configureOptions = null)
        {
            //configureOption nese verilmişse onu kullan, verilmemişse boş bir nesne oluştur
            var options = new ApiMonitoringOption();
            configureOptions?.Invoke(options);

            return builder.UseMiddleware<ApiMonitoringMiddleware>();
        }

        public static IServiceCollection AddApiMonitoring(this IServiceCollection services, Action<ApiMonitoringOption> configureOptions)
        {
            var options = new ApiMonitoringOption();
            configureOptions?.Invoke(options);
            //configureOptions null ise boş bir nesne oluştur:
            services.Configure(configureOptions ?? (o => { }));
            return services;
        }

    }
}
