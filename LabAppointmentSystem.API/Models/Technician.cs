using LabAppointmentSystem.API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace labappointmentsystem.api.models
{
    [Table("Technicians")]

    public class Technician : User
    {
    }
}
