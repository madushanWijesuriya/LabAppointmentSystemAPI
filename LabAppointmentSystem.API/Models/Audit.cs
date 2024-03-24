namespace LabAppointmentSystem.API.Models
{
    public class Audit
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ModifiedBy { get; set; }

    }
}
