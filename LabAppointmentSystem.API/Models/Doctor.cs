using System.ComponentModel.DataAnnotations.Schema;

namespace LabAppointmentSystem.API.Models
{
    [Table("Doctors")]
    public class Doctor : User
    {
        public string Specialization { get; set; }
    }
}
