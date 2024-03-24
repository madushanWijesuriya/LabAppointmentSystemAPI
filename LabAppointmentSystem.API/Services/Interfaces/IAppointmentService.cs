using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Services.Interfaces
{
    public interface IAppointmentService
    {
        IQueryable<Appointment> RetrievAllAppointments();
        void CreateAppointment(Appointment AppointmentDto, string modifiedBy);
        Appointment GetAppointmentById(int id);
        void UpdateAppointment(int appointmentId, Appointment updatedAppointment, string modifiedBy);
        void AssignTests(List<int> testIds, int appointmentId, string modifiedBy);
    }
}
