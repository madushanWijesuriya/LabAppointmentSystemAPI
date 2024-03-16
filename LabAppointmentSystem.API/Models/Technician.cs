using System.ComponentModel.DataAnnotations.Schema;

namespace LabAppointmentSystem.API.Models
{
    [Table("Technicians")]

    public class Technician : User
    {
        public virtual ICollection<AppointmentTest>? AppointmentTests { get; set; }
    }
}
