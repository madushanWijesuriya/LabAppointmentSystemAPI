using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Services.Interfaces
{
    public interface ITechnicianService
    {
        IQueryable<TechnicianDto> GetAllTechnicians();
        void CreateTechnician(Technician TechnicianDto);
    }
}
