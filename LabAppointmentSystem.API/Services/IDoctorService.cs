using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Services
{
    public interface IDoctorService
    {
        IQueryable<Doctor> GetAllDoctors();
        void CreateDoctor(Doctor doctorDto);
    }
}
