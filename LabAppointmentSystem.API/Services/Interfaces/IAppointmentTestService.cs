using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Services.Interfaces
{
    public interface IAppointmentTestService
    {
        void UpdateAppointmentTest(string techId, int appointmentTestId, AppointmentTestPayload appointmentTestPayload);

        IQueryable<AppointmentTest> RetrievAllAppointmentTest(int appointmentId);
    }
}
