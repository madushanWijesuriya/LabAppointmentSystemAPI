using LabAppointmentSystem.API.Data;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<User> GetAllUsers() => _dbContext.Users;
    }
}
