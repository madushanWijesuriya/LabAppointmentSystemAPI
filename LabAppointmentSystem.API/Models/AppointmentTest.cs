namespace LabAppointmentSystem.API.Models
{
    public class AppointmentTest : IAuditable
    {
        public int AppointmentId { get; set; }
        public int TestId { get; set; }
        public string? TechnicianId { get; set; }
        public string? Result { get; set; }
        public Test Test { get; set; }
        public Appointment Appointment { get; set; }
        public virtual Technician? Technician { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}
