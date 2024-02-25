using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Repositories
{
    public interface IDoctorRepository
    {
        IQueryable<Doctor> GetAllDoctors();
        void SaveDoctor(Doctor doctor);
    }
}
