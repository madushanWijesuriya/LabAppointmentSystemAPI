using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Services.Interfaces
{
    public interface IAppointmentService
    {
        //IQueryable<Appointment> GetAllAppointments();
        void CreateAppointment(Appointment AppointmentDto);
        void AssignTests(List<int> testIds, int appointmentId);
    }
}
