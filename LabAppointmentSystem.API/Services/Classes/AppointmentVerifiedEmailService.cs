using System.Net.Mail;
using System.Net;
using LabAppointmentSystem.API.Services.Interfaces;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Services.Classes
{
    public class AppointmentVerifiedEmailService : AbstractEmailService
    {
        public override void createEmailBodyAndSendEmail(User user, Appointment appointment)
        {
            var emailBody = $"Hi {user.Name},\n\n" +
                        $"This is a reminder that your appointment is now in progress. " +
                        $"We will inform you once test result out.\n\n" +
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
