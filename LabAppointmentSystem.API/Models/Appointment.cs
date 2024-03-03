using LabAppointmentSystem.API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabAppointmentSystem.API.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public AppointmentStatus WorkFlow { get; set; }
        public Status Status { get; set; }
        public ICollection<AppointmentTest> AppointmentTests { get; set; }
    }
}
