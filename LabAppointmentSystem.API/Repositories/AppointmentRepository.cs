using LabAppointmentSystem.API.Data;
using LabAppointmentSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LabAppointmentSystem.API.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _dbContext;

        public AppointmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Appointment> GetAllAppointments() => _dbContext.Appointments.Include(r => r.AppointmentTests).Include(x => x.Invoice);

        public Appointment GetAppointment(int id)
        {
            return _dbContext.Appointments.Where(x => x.Id == id)
                .Include(x => x.Invoice)
                .Include(x => x.AppointmentTests)
                    .ThenInclude(at => at.Test)
                        .First();
        }

        public void SaveAppointment(Appointment Appointment)
        {
            _dbContext.Appointments.Add(Appointment);
            _dbContext.SaveChanges();
        }

        public void UpdateAppointment(int id, Appointment updatedAppointment)
        {
             var existingAppointment = _dbContext.Appointments.Find(updatedAppointment.Id);

            if (existingAppointment == null)
            {
                throw new ArgumentException("Appointment not found");
            }

            // Update appointment properties
            existingAppointment.Date = updatedAppointment.Date;
            existingAppointment.Time = updatedAppointment.Time;
            existingAppointment.WorkFlow = updatedAppointment.WorkFlow;
            existingAppointment.Status = updatedAppointment.Status;

            _dbContext.SaveChanges();
        }

        
    }
}
