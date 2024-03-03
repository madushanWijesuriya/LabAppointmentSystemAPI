namespace LabAppointmentSystem.API.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartAt { get; set; }
        public TimeOnly EndAt { get; set; }
        public ICollection<AppointmentTest> AppointmentTests { get; set; }
    }
}
