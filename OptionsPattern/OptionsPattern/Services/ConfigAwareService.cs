using Microsoft.Extensions.Options;
using OptionsPattern.Models;

namespace OptionsPattern.Services
{
    /*
     * Eğer appsettings.json dosyasında bulunan değerleri dinamik olarak kullanacaksanız IOptionsSnapshot kullanabilirsiniz.
     */
    public class ConfigAwareService 
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<ConfigAwareService> _logger;
        public ConfigAwareService(IOptionsSnapshot<EmailSettings> emailSettings, ILogger<ConfigAwareService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }
        public void Send(string to, string subject, string body)
        {
            // Use _emailSettings to send email
            _logger.LogInformation($"Gönderen sunucu adresi: {_emailSettings.SmtpServer}, gönderici adı: {_emailSettings.SenderName}");
        }
    }
}
