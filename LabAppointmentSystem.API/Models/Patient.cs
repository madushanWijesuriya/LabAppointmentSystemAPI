using System.ComponentModel.DataAnnotations.Schema;

namespace LabAppointmentSystem.API.Models
{
    [Table("Patients")]
    public class Patient : User
    {
        public DateTime DateOfBirth { get; set; }
    }
}
