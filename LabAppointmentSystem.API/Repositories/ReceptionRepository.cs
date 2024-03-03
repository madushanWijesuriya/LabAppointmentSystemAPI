using LabAppointmentSystem.API.Data;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Repositories
{
    public class ReceptionRepository : IReceptionRepository
    {
        private readonly AppDbContext _dbContext;

        public ReceptionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Reception> GetAllReceptions() => _dbContext.Receptions;
        public void SaveReception(Reception Reception)
        {
            _dbContext.Receptions.Add(Reception);
            _dbContext.SaveChanges();
        }
    }
}
