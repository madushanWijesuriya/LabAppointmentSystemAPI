using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Repositories
{
    public interface IReceptionRepository
    {
        IQueryable<Reception> GetAllReceptions();
        void SaveReception(Reception Reception);
    }
}
