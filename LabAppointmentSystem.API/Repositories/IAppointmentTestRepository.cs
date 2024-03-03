using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Repositories
{
    public interface IAppointmentTestRepository
    {
        void SaveAppointmentTest(AppointmentTest appointmentTest);
    }
}
