using System;
using System.Net;
using System.Net.Mail;
using OtelOtomasyonu.Data.Entities;

namespace OtelOtomasyonu.Services
{
    public class MailService
    {
        // CONSTANTS - In a real app, store these in App.config or Database
        private const string SmtpHost = "smtp.gmail.com";
        private const string SmtpPort = "587";
        private const string SenderEmail = "yazilimogrencisi016@gmail.com"; 
        private const string SenderPassword = "fudd kajx lqwn abzg"; // Note: Use App Password if 2FA is on

        public (bool success, string errorMessage) SendRoomSelectionEmail(string customerName, string customerEmail, string token)
        {
            try
            {
                // Dynamic Link - HTTP kullan (localhost için yeterli)
                string link = $"http://localhost:5000/RoomSelection/Index?token={token}";

                string subject = "Ada Lovelady's Hotel - Odanızı Seçin";
                
                // HTML Template (Gold/Black Theme)
                string body = $@"
<html>
<body style='background-color: #000; color: #D4AF37; font-family: Segoe UI, sans-serif; text-align: center; padding: 50px;'>
    <div style='border: 2px solid #D4AF37; padding: 40px; max-width: 600px; margin: auto; border-radius: 10px;'>
        <h1 style='color: #D4AF37;'>Hoş Geldiniz, {customerName}</h1>
        <p style='color: #fff; font-size: 16px;'>
            Ada Lovelady's Hotel'i tercih ettiğiniz için teşekkür ederiz.
            <br><br>
            Konaklamanızı özelleştirmek ve dilediğiniz odayı seçmek için lütfen aşağıdaki butona tıklayın:
        </p>
        <br>
        <a href='{link}' style='background-color: #D4AF37; color: #000; padding: 15px 30px; text-decoration: none; font-weight: bold; font-size: 18px; border-radius: 5px; display: inline-block;'>
            ODAMI SEÇ
        </a>
        <br><br>
        <p style='color: #888; font-size: 12px;'>
            Bu link 24 saat boyunca geçerlidir.
        </p>
    </div>
</body>
</html>";

                using (SmtpClient smtp = new SmtpClient(SmtpHost, int.Parse(SmtpPort)))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
                    
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(SenderEmail, "Ada Lovelady's Hotel");
                        mail.To.Add(customerEmail);
                        mail.Subject = subject;
                        mail.Body = body;
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

        public (bool success, string errorMessage) SendEmail(string toEmail, string subject, string htmlBody)
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
