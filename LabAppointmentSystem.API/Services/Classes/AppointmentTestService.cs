using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Repositories;
using LabAppointmentSystem.API.Services.Interfaces;

namespace LabAppointmentSystem.API.Services.Classes
{
    public class AppointmentTestService : IAppointmentTestService
    {
        private readonly IAppointmentTestRepository _AppointmentTestRepository;
        private readonly IAuditService _auditService;

        public AppointmentTestService(IAppointmentTestRepository appointmentTestRepository, IAuditService auditService)
        {
            _AppointmentTestRepository = appointmentTestRepository;
            _auditService = auditService;
        }
        public IQueryable<AppointmentTest> RetrievAllAppointmentTest(int appointmentId)
        {
            return _AppointmentTestRepository.GetAllAppointmentTests(appointmentId);
        }

        public void UpdateAppointmentTest(string techId,int appointmentTestId, AppointmentTestPayload appointmentTestPayload, string modifiedBy)
        {
            var appointmentTest = new AppointmentTest
            {
                AppointmentId = appointmentTestPayload.AppointmentId,
                TestId = appointmentTestPayload.TestId,
                Result = appointmentTestPayload.Result,
            };

            _auditService.SetAuditFields(appointmentTest, modifiedBy);
            _AppointmentTestRepository.UpdateAppointmentTest(techId, appointmentTestId, appointmentTest);
        }
    }
}
