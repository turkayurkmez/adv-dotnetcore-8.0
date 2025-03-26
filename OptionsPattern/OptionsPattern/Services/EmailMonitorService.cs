
using Microsoft.Extensions.Options;
using OptionsPattern.Models;

namespace OptionsPattern.Services
{

    /*
     * 
     * Eğer appsettings.json içerisinde değişiklik olduğunda bu değişiklikleri anında  dinlemek ve yakalamak  istiyorsanız IOptionsMonitor kullanabilirsiniz.
     */
    public class EmailMonitorService : IHostedService
    {
        private readonly ILogger<EmailMonitorService> _logger;
        private readonly IOptionsMonitor<EmailSettings> _emailSettingsMonitoring;

        private IDisposable _mailListener;

        public EmailMonitorService(ILogger<EmailMonitorService> logger, IOptionsMonitor<EmailSettings> optionsMonitor)
        {
            _logger = logger;
            _emailSettingsMonitoring = optionsMonitor;




        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _emailSettingsMonitoring.OnChange(settings => {
                _logger.LogInformation($"Email settings changed. New SmtpServer: {settings.SmtpServer}");
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _mailListener?.Dispose();
            return Task.CompletedTask;
        }
    }
}
