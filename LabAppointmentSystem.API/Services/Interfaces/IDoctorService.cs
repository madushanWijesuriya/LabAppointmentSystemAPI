using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Services.Interfaces
{
    public interface IDoctorService
    {
        IQueryable<Doctor> GetAllDoctors();
        void CreateDoctor(Doctor doctorDto);
    }
}
