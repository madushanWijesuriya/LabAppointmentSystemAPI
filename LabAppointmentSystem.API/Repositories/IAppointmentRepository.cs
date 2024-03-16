using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Repositories
{
    public interface IAppointmentRepository
    {
        void SaveAppointment(Appointment appointment);
    }
}
