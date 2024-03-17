using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Repositories
{
    public interface IAppointmentTestRepository
    {
        IQueryable<AppointmentTest> GetAllAppointmentTests(int appointmentId);

        void SaveAppointmentTest(AppointmentTest appointmentTest);

        void UpdateAppointmentTest(string techId, int id, AppointmentTestPayload appointmentTestPayload);
        Appointment GetAppointmentTest(int id);
    }
}
