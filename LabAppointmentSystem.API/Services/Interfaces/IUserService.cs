using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Services.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> GetAllUsers();

    }
}
