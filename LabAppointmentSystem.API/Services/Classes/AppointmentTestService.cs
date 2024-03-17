using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Repositories;
using LabAppointmentSystem.API.Services.Interfaces;

namespace LabAppointmentSystem.API.Services.Classes
{
    public class AppointmentTestService : IAppointmentTestService
    {
        private readonly IAppointmentTestRepository _AppointmentTestRepository;

        public AppointmentTestService(IAppointmentTestRepository appointmentTestRepository)
        {
            _AppointmentTestRepository = appointmentTestRepository;
        }
        public IQueryable<AppointmentTest> RetrievAllAppointmentTest(int appointmentId)
        {
            return _AppointmentTestRepository.GetAllAppointmentTests(appointmentId);
        }

        public void UpdateAppointmentTest(string techId,int appointmentTestId, AppointmentTestPayload appointmentTestPayload)
        {
            _AppointmentTestRepository.UpdateAppointmentTest(techId,appointmentTestId, appointmentTestPayload);
        }
    }
}
