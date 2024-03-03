using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Services.Interfaces
{
    public interface IReceptionService
    {
        IQueryable<Reception> GetAllReceptions();
        void CreateReception(Reception ReceptionDto);
    }
}
