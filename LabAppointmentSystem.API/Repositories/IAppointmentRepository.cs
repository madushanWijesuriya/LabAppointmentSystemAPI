using LabAppointmentSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LabAppointmentSystem.API.Repositories
{
    public interface IAppointmentRepository
    {
        IQueryable<Appointment> GetAllAppointments();
        void SaveAppointment(Appointment appointment);
        void UpdateAppointment(int id, Appointment updatedAppointment);
        Appointment GetAppointment(int id);
    }
}
