using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Enums;
using LabAppointmentSystem.API.Mappers;
using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Repositories;
using LabAppointmentSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace LabAppointmentSystem.API.Services.Classes
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _AppointmentRepository;
        private readonly IAppointmentTestRepository _AppointmentTestRepository;
        private readonly UserManager<User> _userManageService;

        public AppointmentService(IAppointmentRepository AppointmentRepository, UserManager<User> userManageService,
            IAppointmentTestRepository appointmentTestRepository)
        {
            _AppointmentRepository = AppointmentRepository;
            _userManageService = userManageService;
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

        public IQueryable<Appointment> RetrievAllAppointments()
        {
            return _AppointmentRepository.GetAllAppointments();
        }

        public Appointment GetAppointmentById(int id) 
        {
            return _AppointmentRepository.GetAppointment(id);
        }

        public void CreateAppointment(Appointment Appointment)
        {
            _AppointmentRepository.SaveAppointment(Appointment);
        }

        public void UpdateAppointment(int appointmentId, Appointment updatedAppointment)
        {
            _AppointmentRepository.UpdateAppointment(appointmentId, updatedAppointment);
        }

    }
}
