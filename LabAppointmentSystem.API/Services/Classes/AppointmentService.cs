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
        private readonly IAuditService _auditService;

        public AppointmentService(IAppointmentRepository AppointmentRepository, UserManager<User> userManageService,
            IAppointmentTestRepository appointmentTestRepository, IAuditService auditService)
        {
            _AppointmentRepository = AppointmentRepository;
            _userManageService = userManageService;
            _AppointmentTestRepository = appointmentTestRepository;
            _auditService = auditService;
        }

        public void AssignTests(List<int> testIds, int appointmentId, string modifiedBy)
        {
            foreach (int testId in testIds)
            {

                var appointmentTest = new AppointmentTest
                {
                    AppointmentId = appointmentId,
                    TestId = testId,
                };

                _auditService.SetAuditFields(appointmentTest, modifiedBy);

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

        public void CreateAppointment(Appointment appointment, string modifiedBy)
        {
            _auditService.SetAuditFields(appointment, modifiedBy);
            _AppointmentRepository.SaveAppointment(appointment);
        }

        public void UpdateAppointment(int appointmentId, Appointment updatedAppointment, string modifiedBy)
        {
            _auditService.SetAuditFields(updatedAppointment, modifiedBy);
            _AppointmentRepository.UpdateAppointment(appointmentId, updatedAppointment);
        }

    }
}
