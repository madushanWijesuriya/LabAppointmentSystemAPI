using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Repositories
{
    public interface ITechnicianRepository
    {
        IQueryable<Technician> GetAllTechnicians();
        void SaveTechnician(Technician Technician);
    }
}
