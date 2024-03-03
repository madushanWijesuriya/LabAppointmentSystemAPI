using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Mappers
{
    public static class TechnicianMapper
    {
        public static TechnicianDto ToDto(Technician Technician)
        {
            return new TechnicianDto
            {
                Id = Technician.Id,
                NIC = Technician.NIC,
                Name = Technician.Name,
                Email = Technician.Email,
            };
        }
    }
}
