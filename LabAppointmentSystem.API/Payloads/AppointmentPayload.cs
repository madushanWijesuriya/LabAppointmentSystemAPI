using LabAppointmentSystem.API.Enums;

namespace LabAppointmentSystem.API.Payloads
{
    public class AppointmentPayload
    {
        public DateTime Date { get; set; }
        public double Time { get; set; }
        public AppointmentStatus WorkFlow { get; set; }
        public Status Status { get; set; }
    }
}
