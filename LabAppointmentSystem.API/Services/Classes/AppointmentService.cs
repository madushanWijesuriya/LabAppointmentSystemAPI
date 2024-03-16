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
        private readonly IAppointmentTestRepository _AppointmentTestRepository;

        public AppointmentService(IAppointmentRepository AppointmentRepository, IAppointmentTestRepository appointmentTestRepository)
        {
            _AppointmentRepository = AppointmentRepository;
            _AppointmentTestRepository = appointmentTestRepository;
        }

        public void AssignTests(List<int> testIds, int appointmentId)
        {
            foreach (int testId in testIds)
            {
                var appointmentTest = new AppointmentTest
                {
                    AppointmentId = appointmentId,
                    TestId = testId,
                };

                _AppointmentTestRepository.SaveAppointmentTest(appointmentTest);
            }
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
