namespace LabAppointmentSystem.API.Models
{
    public class AppointmentTestPayload
    {
        public int AppointmentId { get; set; }
        public int TestId { get; set; }
        public string? Result { get; set; }
    }
}
