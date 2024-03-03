using LabAppointmentSystem.API.Data;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly AppDbContext _dbContext;

        public TestRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Test> GetAllTests() => _dbContext.Tests;
        public void SaveTest(Test test)
        {
            _dbContext.Tests.Add(test);
            _dbContext.SaveChanges();
        }
    }
}
