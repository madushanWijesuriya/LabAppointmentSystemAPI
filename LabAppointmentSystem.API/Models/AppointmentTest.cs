namespace LabAppointmentSystem.API.Models
{
    public class AppointmentTest
    {
        public int AppointmentId { get; set; }
        public int TestId { get; set; }
        public string? TechnicianId { get; set; }
        public string? Result { get; set; }
        public Test Test { get; set; }
        public Appointment Appointment { get; set; }
        public Technician Technician { get; set; }

    }
}
