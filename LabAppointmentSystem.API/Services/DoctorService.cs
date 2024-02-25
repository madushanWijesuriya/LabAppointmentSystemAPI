using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Mappers;
using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Repositories;

namespace LabAppointmentSystem.API.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public IQueryable<Doctor> GetAllDoctors()
        {
            var doctors = _doctorRepository.GetAllDoctors();

            return doctors.Select(DoctorMapper.ToDto)
                .AsQueryable();
        }

        public void CreateDoctor(Doctor doctor)
        {
            _doctorRepository.SaveDoctor(doctor);
        }
    }
}
