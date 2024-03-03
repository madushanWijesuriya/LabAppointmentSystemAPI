using LabAppointmentSystem.API.Data;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Repositories
{
    public class TechnicianRepository : ITechnicianRepository
    {
        private readonly AppDbContext _dbContext;

        public TechnicianRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Technician> GetAllTechnicians() => _dbContext.Technicians;
        public void SaveTechnician(Technician Technician)
        {
            _dbContext.Technicians.Add(Technician);
            _dbContext.SaveChanges();
        }
    }
}
