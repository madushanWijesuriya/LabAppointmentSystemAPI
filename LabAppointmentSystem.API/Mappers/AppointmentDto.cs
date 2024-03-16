using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Mappers
{
    public class AppointmentDto
    {
        public static AppointmentDto ToDto(Appointment ppointment)
        {
            return new AppointmentDto
            {
                //Id = doctor.Id,
                //NIC = doctor.NIC,
                //Name = doctor.Name,
                //Specialization = doctor.Specialization,
            };
        }
    }
}
