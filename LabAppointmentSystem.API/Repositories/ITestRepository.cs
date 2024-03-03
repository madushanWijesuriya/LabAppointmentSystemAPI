using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Repositories
{
    public interface ITestRepository
    {
        IQueryable<Test> GetAllTests();
        void SaveTest(Test Test);
    }
}
