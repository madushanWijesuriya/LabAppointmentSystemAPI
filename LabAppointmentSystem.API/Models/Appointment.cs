using LabAppointmentSystem.API.Payloads;
using System.ComponentModel.DataAnnotations.Schema;
namespace LabAppointmentSystem.API.Models
{
    public class Appointment : AppointmentPayload
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        [NotMapped]
        public string? FormatedTime { get; set; }
        public virtual ICollection<AppointmentTest>? AppointmentTests { get; set; }
        public virtual Patient? Patient { get; set; }
        public virtual Invoice? Invoice { get; set; }
    }
}
