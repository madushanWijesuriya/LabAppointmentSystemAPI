using LabAppointmentSystem.API.Data;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Repositories
{
    public class AppointmentTestRepository : IAppointmentTestRepository
    {
        private readonly AppDbContext _dbContext;

        public AppointmentTestRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveAppointmentTest(AppointmentTest AppointmentTest)
        {
            _dbContext.AppointmentTests.Add(AppointmentTest);
            _dbContext.SaveChanges();
        }
    }
}
