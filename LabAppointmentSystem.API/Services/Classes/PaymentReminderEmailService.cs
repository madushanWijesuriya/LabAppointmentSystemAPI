using System.Net.Mail;
using System.Net;
using LabAppointmentSystem.API.Services.Interfaces;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Services.Classes
{
    public class PaymentReminderEmailService : AbstractEmailService
    {
        public override void createEmailBodyAndSendEmail(User user, Appointment appointment)
        {
            var emailBody = $"Hi {user.Name},\n\n" +
                        $"Your test result has been completed and uploaded to the user portal. " +
                        $"Please make sure to pay the full amount to check test results..\n\n" +
                        $"Appointment Details:\n" +
                        $"Id: {appointment.Id}\n" +
                        $"Date: {appointment.Date}\n" +
                        $"Time: {appointment.Time}\n" +
                        $"Thank you for choosing our services.\n\n" +
                        $"Best regards,\n" +
                        $"ICBT Appointment Lab";

            this.SendEmail(user.Email, "ICBT Lab Payment Reminder", emailBody);
        }
    }
}
