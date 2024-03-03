using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Mappers;
using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Repositories;
using LabAppointmentSystem.API.Services.Interfaces;

namespace LabAppointmentSystem.API.Services.Classes
{
    public class ReceptionService : IReceptionService
    {
        private readonly IReceptionRepository _ReceptionRepository;

        public ReceptionService(IReceptionRepository ReceptionRepository)
        {
            _ReceptionRepository = ReceptionRepository;
        }

        public IQueryable<Reception> GetAllReceptions()
        {
            var Receptions = _ReceptionRepository.GetAllReceptions();

            return Receptions.Select(ReceptionMapper.ToDto)
                .AsQueryable();
        }

        public void CreateReception(Reception Reception)
        {
            _ReceptionRepository.SaveReception(Reception);
        }
    }
}
