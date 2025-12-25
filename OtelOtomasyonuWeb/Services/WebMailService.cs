using System;
using System.Net;
using System.Net.Mail;

namespace OtelOtomasyonuWeb.Services
{
    public class WebMailService
    {
        // CONSTANTS - In a real app, store these in appsettings.json
        private const string SmtpHost = "smtp.gmail.com";
        private const string SmtpPort = "587";
        private const string SenderEmail = "yazilimogrencisi016@gmail.com";
        private const string SenderPassword = "fudd kajx lqwn abzg"; // Note: Use App Password if 2FA is on

        public (bool success, string? errorMessage) SendEmail(string toEmail, string subject, string htmlBody)
        {
            try
            {
                if (string.IsNullOrEmpty(toEmail))
                {
                    return (false, "E-posta adresi boş olamaz.");
                }

                using (SmtpClient smtp = new SmtpClient(SmtpHost, int.Parse(SmtpPort)))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(SenderEmail, SenderPassword);

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(SenderEmail, "Ada Lovelady's Hotel");
                        mail.To.Add(toEmail);
                        mail.Subject = subject;
                        mail.Body = htmlBody;
                        mail.IsBodyHtml = true;

                        smtp.Send(mail);
                    }
                }

                return (true, null);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Mail Error: " + ex.Message);
                return (false, ex.Message);
            }
        }
    }
}

