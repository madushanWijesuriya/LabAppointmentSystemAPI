using LabAppointmentSystem.API.Data;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _dbContext;

        public AppointmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Appointment> GetAllAppointments() => _dbContext.Appointments;
        public void SaveAppointment(Appointment Appointment)
        {
            _dbContext.Appointments.Add(Appointment);
            _dbContext.SaveChanges();
        }
    }
}
