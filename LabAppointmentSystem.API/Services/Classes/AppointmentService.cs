using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Mappers;
using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Repositories;
using LabAppointmentSystem.API.Services.Interfaces;

namespace LabAppointmentSystem.API.Services.Classes
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _AppointmentRepository;

        public AppointmentService(IAppointmentRepository AppointmentRepository)
        {
            _AppointmentRepository = AppointmentRepository;
        }

        //public IQueryable<Appointment> GetAllAppointments()
        //{
        //    var Appointments = _AppointmentRepository.GetAllAppointments();

        //    return Appointments.Select(AppointmentMapper.ToDto)
        //        .AsQueryable();
        //}

        public void CreateAppointment(Appointment Appointment)
        {
            _AppointmentRepository.SaveAppointment(Appointment);
        }
    }
}
