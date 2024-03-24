namespace LabAppointmentSystem.API.Models
{
    public class Invoice : IAuditable
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public int AppointmentId { get; set; }
        public bool IsPaid { get; set; }
        public double Amount { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Appointment Appointment { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}
