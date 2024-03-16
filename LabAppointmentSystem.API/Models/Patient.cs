using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabAppointmentSystem.API.Models
{
    [Table("Patients")]
    public class Patient : User
    {
        public DateTime DateOfBirth { get; set; }
        [BindNever]
        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<Invoice>? Invoices { get; set; }

    }
}
