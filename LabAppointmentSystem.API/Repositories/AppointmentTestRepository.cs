using LabAppointmentSystem.API.Data;
using LabAppointmentSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LabAppointmentSystem.API.Repositories
{
    public class AppointmentTestRepository : IAppointmentTestRepository
    {
        private readonly AppDbContext _dbContext;

        public AppointmentTestRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<AppointmentTest> GetAllAppointmentTests(int appointmentId)
        {
            return _dbContext.AppointmentTests.Where(c => c.AppointmentId == appointmentId)
                .Include(x => x.Appointment)
                    .Include(x => x.Test);
        }

        public AppointmentTest GetAppointmentTest(int testId, int appointmentId)
        {
            return _dbContext.AppointmentTests
                .Where(x => x.TestId == testId && x.AppointmentId == appointmentId)
                    .First();
        }

        public Appointment GetAppointmentTest(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveAppointmentTest(AppointmentTest AppointmentTest)
        {
            _dbContext.AppointmentTests.Add(AppointmentTest);
            _dbContext.SaveChanges();
        }

        public void UpdateAppointmentTest(string techId,int id, AppointmentTestPayload appointmentTestPayload)
        {
            var existingAppointmentTest = _dbContext.AppointmentTests.Where(x => 
                x.AppointmentId == appointmentTestPayload.AppointmentId 
                    && x.TestId == appointmentTestPayload.TestId)
                        .FirstOrDefault();
          

            if (existingAppointmentTest == null)
            {
                throw new ArgumentException("Appointment not found");
            }

            existingAppointmentTest.Result = appointmentTestPayload.Result;
            existingAppointmentTest.TechnicianId = techId;
            _dbContext.SaveChanges();
        }
    }
}
