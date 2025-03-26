using Microsoft.Extensions.Options;
using OptionsPattern.Models;

namespace OptionsPattern.Services
{

    /*
     * Eğer appsettings.json dosyasında bulunan değerleri bir kere okuyup kullanacaksanız IOptions kullanabilirsiniz.
     */
    public class MailService 
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<MailService> _logger;
        public MailService(IOptions<EmailSettings> emailSettings, ILogger<MailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }
        public void Send(string to, string subject, string body)
        {
            // Use _emailSettings to send email
            _logger.LogInformation($"Gönderen adresi: {_emailSettings.SenderEmail}, gönderici adı: {_emailSettings.SenderName}");


        }
    }
}
