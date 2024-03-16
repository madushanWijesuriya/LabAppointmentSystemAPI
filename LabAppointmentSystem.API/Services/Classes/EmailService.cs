using System.Net.Mail;
using System.Net;

namespace LabAppointmentSystem.API.Services.Classes
{
    public class EmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            var fromAddress = new MailAddress("shanwijesuriya.madushan@gmail.com", "ICBT LAB");
            var toAddress = new MailAddress(to);

            var smtp = new SmtpClient
            {
                Host = "sandbox.smtp.mailtrap.io",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("6559d61ff58652", "c0e89e33ff40b4")
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
