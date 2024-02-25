using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Mappers
{
    public static class DoctorMapper
    {
        public static DoctorDto ToDto(Doctor doctor)
        {
            return new DoctorDto
            {
                Id = doctor.Id,
                NIC = doctor.NIC,
                Name = doctor.Name,
                Specialization = doctor.Specialization,
            };
        }
    }
}
