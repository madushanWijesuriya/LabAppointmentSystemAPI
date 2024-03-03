using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Mappers
{
    public static class ReceptionMapper
    {
        public static ReceptionDto ToDto(Reception Reception)
        {
            return new ReceptionDto
            {
                Id = Reception.Id,
                NIC = Reception.NIC,
                Name = Reception.Name,
            };
        }
    }
}
