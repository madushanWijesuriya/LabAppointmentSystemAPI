using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Services.Interfaces
{
    public interface IAppointmentTestService
    {
        void UpdateAppointmentTest(int appointmentTestId, AppointmentTestPayload appointmentTestPayload);

        IQueryable<AppointmentTest> RetrievAllAppointmentTest(int appointmentId);
    }
}
