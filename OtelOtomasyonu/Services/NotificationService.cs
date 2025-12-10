using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace OtelOtomasyonu.Services
{
    public class NotificationService : IDisposable
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _smsProviderUrl;
        private readonly string _smsToken;
        private readonly HttpClient _httpClient;

        public NotificationService()
        {
            var host = ConfigurationManager.AppSettings["SmtpHost"];
            var portSetting = ConfigurationManager.AppSettings["SmtpPort"];
            var user = ConfigurationManager.AppSettings["SmtpUser"];
            var password = ConfigurationManager.AppSettings["SmtpPassword"];
            _smsProviderUrl = ConfigurationManager.AppSettings["SmsProviderUrl"];
            _smsToken = ConfigurationManager.AppSettings["SmsProviderToken"];

            if (!string.IsNullOrWhiteSpace(host))
            {
                var port = 587;
                int.TryParse(portSetting, out port);

                _smtpClient = new SmtpClient(host, port)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(user, password)
                };
            }

            if (!string.IsNullOrWhiteSpace(_smsProviderUrl))
            {
                _httpClient = new HttpClient();
            }
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            if (_smtpClient == null)
            {
                throw new InvalidOperationException("E-posta gönderimi için App.config dosyasında SMTP ayarlarını yapmalısınız (SmtpHost, SmtpUser, SmtpPassword).");
            }

            var mail = new MailMessage
            {
                From = new MailAddress(ConfigurationManager.AppSettings["SmtpUser"], "Otel Otomasyonu"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mail.To.Add(to);

            await _smtpClient.SendMailAsync(mail);
        }

        public async Task SendSmsAsync(string phoneNumber, string message)
        {
            if (_httpClient == null)
            {
                throw new InvalidOperationException("SMS gönderimi için App.config dosyasında SMS sağlayıcı ayarlarını yapmalısınız (SmsProviderUrl, SmsProviderToken).");
            }

            var serializer = new JavaScriptSerializer();
            var payload = serializer.Serialize(new
            {
                to = phoneNumber,
                text = message
            });

            var request = new HttpRequestMessage(HttpMethod.Post, _smsProviderUrl);
            request.Headers.Add("Authorization", $"Bearer {_smsToken}");
            request.Content = new StringContent(payload, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                throw new Exception($"SMS gönderimi başarısız: {response.StatusCode} - {responseBody}");
            }
        }

        public void Dispose()
        {
            _smtpClient?.Dispose();
            _httpClient?.Dispose();
        }
    }
}
