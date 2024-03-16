using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetAllUsers();
    }
}
