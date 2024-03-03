using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Mappers;
using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Repositories;
using LabAppointmentSystem.API.Services.Interfaces;

namespace LabAppointmentSystem.API.Services.Classes
{
    public class TechnicianService : ITechnicianService
    {
        private readonly ITechnicianRepository _TechnicianRepository;

        public TechnicianService(ITechnicianRepository TechnicianRepository)
        {
            _TechnicianRepository = TechnicianRepository;
        }

        public IQueryable<TechnicianDto> GetAllTechnicians()
        {
            var Technicians = _TechnicianRepository.GetAllTechnicians();

            return Technicians.Select(TechnicianMapper.ToDto)
                .AsQueryable();
        }

        public void CreateTechnician(Technician Technician)
        {
            _TechnicianRepository.SaveTechnician(Technician);
        }
    }
}
